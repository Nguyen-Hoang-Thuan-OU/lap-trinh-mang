using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ControlClientForm
{
    public partial class BTH05_ControlClientForm : Form
    {
        public BTH05_ControlClientForm()
        {
            InitializeComponent();
        }

        // Tạo hằng PORT = 9050 để lưu giá trị port
        const int PORT = 9050;

        // Tạo hằng BUFF = 10000 để lưu giá trị bộ nhớ đệm
        const int BUFF = 10000;

        // Tạo đối tượng TcpClient ở phía client
        TcpClient client;

        // Tạo mảng để lưu số byte của bộ nhớ đệm
        byte[] readbuff = new byte[BUFF];

        // Hàm gửi dữ liệu
        void SendData(string data)
        {
            /*
             * Trạng thái lock là để tránh tình trạng deadlock,
             * đảm bảo rằng một khối mã chạy đến khi hoàn thành
             * mà không bị các luồng khác làm gián đoạn
             * 
             * Phương thức GetStream tạo ra luồng Stream
             * để gửi và nhận dữ liệu
             */
            lock (client.GetStream())
            {
                /*
                 * Lớp StreamWriter điều khiển việc ghi
                 * các thông điệp text từ mạng
                 */
                StreamWriter sw = new StreamWriter(client.GetStream());

                // Phương thức Write() dùng để ghi dữ liệu dạng ký tự vào luồng
                sw.Write(data + (char)13);

                /*
                 * Phương thức Flush() dùng để gửi tất cả dữ liệu
                 * trong bộ đệm StreamWriter ra Stream
                 */
                sw.Flush();
            }
        }

        // Hàm thực hiện lệnh
        private void ProcessCommand(string message)
        {
            // Khai báo mảng DataArr dạng chuỗi
            string[] DataArr;

            // Tách chuỗi mỗi khi gặp dấu cộng
            DataArr = message.Split('+');

            switch (DataArr[0])
            {
                case "THONGBAO":
                    {
                        /*
                         * MessageBoxButtons.YesNo: hiện nút chọn Có hoặc Không
                         * MessageBoxIcon.Warning: hiện thông báo dạng cảnh báo
                         * DialogResult.Yes: hộp thoại sẽ đóng nếu chọn Có
                         */
                        if (MessageBox.Show("Các chương trình sau đây: \r" + DataArr[2] +
                                            "đang chạy ở server. Bạn có muốn tiếp tục?", "CẢNH BÁO",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                                            == DialogResult.Yes)
                        {
                            /*
                             * -F sẽ buộc các chương trình đang chạy đóng lại
                             * mà không có cảnh báo.
                             */
                            if (DataArr[1] == "SHUTDOWN -F")
                                SendData("SHUTDOWN + YES + OK");
                            if (DataArr[1] == "SHUTDOWN")
                                SendData("SHUTDOWN + NO + OK");
                            if (DataArr[1] == "RESTART -F")
                                SendData("RESTART + YES + OK");
                            if (DataArr[1] == "RESTART")
                                SendData("RESTART + NO + OK");
                            if (DataArr[1] == "LOCK")
                                SendData("LOCK + NO + OK");
                            if (DataArr[1] == "LOGOFF")
                                SendData("LOGOFF + NO + OK");
                        }
                        break;
                    }
            }
        }

        // Hàm đọc trạng thái của một hoạt động bất đồng bộ
        void DoRead(IAsyncResult ar)
        {
            // Tạo mảng byteRead để đọc số byte được chỉ định từ luồng hiện tại
            int byteRead;

            // Tạo chuỗi thông điệp
            string message;

            try
            {
                // Phương thức EndRead() dùng để chờ quá trình đọc bất đồng bộ hoàn tất
                byteRead = client.GetStream().EndRead(ar);
                if (byteRead < 1)
                {
                    return;
                }

                // Chuyển mảng byte readbuff thành chuỗi
                message = Encoding.ASCII.GetString(readbuff, 0, byteRead - 2);

                // Gọi hàm ProcessCommand() để thực hiện thông điệp trong chuỗi
                ProcessCommand(message);

                /* 
                 * Bắt đầu đọc không đồng bộ từ NetworkStream bằng phương thức
                 * NetworkStream.BeginRead(Byte[], Int32, Int32, AsyncCallback, Object)\
                 * 
                 * - readbuff: mảng byte readbuff
                 * - 0: vị trí bắt đầu (0 - đầu tiên)
                 * - BUFF: giá trị hằng của bộ nhớ đệm
                 * - AsyncCallback: tự động gọi lại khi hoàn thành phương thức BeginRead()
                 * - null: Đối tượng chứa bất kỳ dữ liệu bổ sung nào do người dùng xác định
                 */
                client.GetStream().BeginRead(readbuff, 0, BUFF, new AsyncCallback(DoRead), null);
            }
            catch (Exception e) {}
        }

        // Nút tắt nguồn
        private void buttonTatNguon_Click(object sender, EventArgs e)
        {
            // Nếu ấn nút mà chưa kết nối đến server
            if (client == null)
                MessageBox.Show("Hãy kết nối với server trước!");
            else
            {
                /*
                 * Nếu có chọn nút ép buộc
                 * thì chương trình sẽ thực thi mà không hiện thông báo
                 */
                if (checkBoxEpBuoc.Checked == true)
                    SendData("SHUTDOWN+YES+");
                else
                    SendData("SHUTDOWN+NO+");
            }
        }

        // Nút khởi động lại
        private void buttonKhoiDongLai_Click(object sender, EventArgs e)
        {
            // Nếu ấn nút mà chưa kết nối đến server
            if (client == null)
                MessageBox.Show("Hãy kết nối với server trước!");
            else
            {
                /*
                 * Nếu có chọn nút ép buộc
                 * thì chương trình sẽ thực thi mà không hiện thông báo
                 */
                if (checkBoxEpBuoc.Checked == true)
                    SendData("RESTART+YES+");
                else
                    SendData("RESTART+NO+");
            }
        }

        // Nút khoá máy
        private void buttonKhoaMay_Click(object sender, EventArgs e)
        {
            // Nếu ấn nút mà chưa kết nối đến server
            if (client == null)
                MessageBox.Show("Hãy kết nối với server trước!");
            else
                SendData("LOGOFF+YES+");
        }

        // Nút đăng xuất
        private void buttonDangXuat_Click(object sender, EventArgs e)
        {
            // Nếu ấn nút mà chưa kết nối đến server
            if (client == null)
                MessageBox.Show("Hãy kết nối với server trước!");
            else
                SendData("LOCK+YES+");
        }

        // Nút kết nối
        private void buttonKetNoi_Click(object sender, EventArgs e)
        {
            // Nếu người dùng không nhập gì vào
            if (textBoxHienThi.Text == "")
            {
                MessageBox.Show("Xin hãy nhập vào địa chỉ IP!");
                return;
            }

            try
            {
                /*
                 * Tạo TcpClient để kết nối giữa client với server,
                 * nhận vào địa chỉ IP và port do người dùng nhập
                 */
                client = new TcpClient(textBoxHienThi.Text, PORT);
                client.GetStream().BeginRead(readbuff, 0, BUFF, new AsyncCallback(DoRead), null);
                MessageBox.Show("Kết nối thành công!");

                /*
                 * Ngăn không cho bấm nút kết nối lần nữa
                 * khi đã kết nối thành công
                 */
                buttonKetNoi.Enabled = false;
            }
            catch
            {
                MessageBox.Show("Không thể kết nối đến server!");

                // Đóng luồng, dẹp bộ nhớ và giải phóng tài nguyên
                this.Dispose();
            }
        }
    }
}
