using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ThreadTCPChatForm
{
    public partial class ThreadTCPChatForm : Form
    {
        private static Socket client;
        private static byte[] data = new byte[1024];

        public ThreadTCPChatForm()
        {
            InitializeComponent();
        }

        // Khi form đóng vai trò là server
        private void buttonLangNghe_Click(object sender, EventArgs e)
        {
            // Bỏ qua lỗi khi xử lý dữ liệu ngoài luồng
            //CheckForIllegalCrossThreadCalls = true;

            // Hiện thông điệp chờ ở list box
            listBoxKetQua.Items.Add("Đang đợi client kết nối đến...");
            listBoxKetQua.Items.Add("--------------------------------------------");

            // Khởi tạo socket
            Socket newsock = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream, ProtocolType.Tcp);

            // Khởi tạo endpoint với port 9050
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);

            // Gán socket vào endpoint
            newsock.Bind(iep);

            // Bắt đầu lắng nghe, tối đa 5 kết nối
            newsock.Listen(5);

            // Chấp nhận kết nối đến bằng hàm bất đồng bộ
            newsock.BeginAccept(new AsyncCallback(AcceptConn), newsock);
        }

        // Khi form đóng vai trò là client
        private void buttonKetNoi_Click(object sender, EventArgs e)
        {
            // In ra thông điệp đang kết nối
            listBoxKetQua.Items.Add("Đang kết nối server...");
            listBoxKetQua.Items.Add("--------------------------------------------");

            // Khởi tạo socket mới dùng để giao tiếp
            client = new Socket(AddressFamily.InterNetwork,
                                SocketType.Stream, ProtocolType.Tcp);

            // Tạo endpoint với địa chỉ localhost và port 9050
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

            // Bắt đầu kết nối bằng hàm bất đồng bộ
            client.BeginConnect(iep, new AsyncCallback(Connected), client);
        }

        private void buttonGui_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ text box và chuyển thành byte
            byte[] message = Encoding.ASCII.GetBytes(textBoxNoiDungTinNhan.Text);

            // Xoá nội dung trong ô text box khi đã nhấn nút gửi
            textBoxNoiDungTinNhan.Clear();

            // Gửi nội dung đi bằng hàm bất đồng bộ
            client.BeginSend(message, 0, message.Length, 0,
                                new AsyncCallback(SendData), client);
        }

        void AcceptConn(IAsyncResult iar)
        {
            // Lấy ra socket của server
            Socket oldserver = (Socket)iar.AsyncState;

            // Chấp nhận kết nối đến

            client = oldserver.EndAccept(iar);

            // Hiện thông báo kèm địa chỉ của server
            listBoxKetQua.Items.Add("Kết nối từ client: " + client.RemoteEndPoint.ToString());
            listBoxKetQua.Items.Add("--------------------------------------------");

            // Tạo một luồng mới để nhận dữ liệu
            Thread receiver = new Thread(new ThreadStart(ReceiveData));

            // Bắt đầu thực thi luồng
            receiver.Start();
        }

        void Connected(IAsyncResult iar)
        {
            try
            {
                // Hoàn thành quá trình kết nối
                client.EndConnect(iar);

                // Hiện địa chỉ của server lên list box
                listBoxKetQua.Items.Add("Kết nối đến server: " + client.RemoteEndPoint.ToString());
                listBoxKetQua.Items.Add("--------------------------------------------");

                // Tạo một luồng mới để nhận dữ liệu
                Thread receiver = new Thread(new ThreadStart(ReceiveData));

                // Bắt đầu thực thi luồng
                receiver.Start();
            }
            catch (SocketException)
            {
                // Hiện thông báo nếu xảy ra lỗi
                listBoxKetQua.Items.Add("Xảy ra lỗi khi kết nối!);
            }
        }

        void SendData(IAsyncResult iar)
        {
            // Lấy thông tin socket
            Socket remote = (Socket)iar.AsyncState;

            // Hoàn thành quá trình gửi dữ liệu
            int sent = remote.EndSend(iar);
        }

        void ReceiveData()
        {
            // Tạo biến để nhận dữ liệu
            int recv;
            string stringData;

            while (true)
            {
                // Nhận dữ liệu
                recv = client.Receive(data);

                // Chuyển dữ liệu từ byte thành chuỗi
                stringData = Encoding.ASCII.GetString(data, 0, recv);

                /*
                 * Nếu dữ liệu là các chuỗi này
                 * thì sẽ thoát vòng lặp và in ra câu chào tạm biệt
                 */
                if (stringData == "bye" || stringData == "exit")
                    break;

                // In chuỗi ra list box
                listBoxKetQua.Items.Add(stringData);
            }

            // In ra câu chào tạm biệt
            stringData = "bye";

            // Chuyển chuỗi tạm biệt thành byte
            byte[] message = Encoding.ASCII.GetBytes(stringData);

            // Gửi mảng byte đi
            client.Send(message);

            // Đóng kết nối hiện tại
            client.Close();

            // In lên list box thông điệp đã ngắt kết nối
            listBoxKetQua.Items.Add("Đã ngắt kết nối");
            return;
        }
    }
}