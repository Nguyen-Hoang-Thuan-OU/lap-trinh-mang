// Chương Trình TCP Server kém hiệu quả (Bad TCP Server)

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BTH02_BT02_Server
{
    class BadTcpSrvr
    {
        public static void Main()
        {
            /* 
             * Số lượng byte dữ liệu mà server nhận được từ client
             * khi dùng hàm Receive()
             * (Ví dụ: abc --> 3 byte)
             */
            int recv;

            /*
             * Tạo mảng data có 1024 byte
             * (bộ đệm để nhận và gởi dữ liệu
             */
            byte[] data = new byte[1024];

            /*
             * Tạo IPEndPoint ở phía server và chấp nhận kết nối
             * trên bất kỳ card mạng nào với port 9050
             */
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);

            // Tạo mới một socket ở phía server
            Socket newsock = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream, ProtocolType.Tcp);

            // Kết nối IPEndPoint với socket
            newsock.Bind(ipep);

            // Lắng nghe kết nối từ client, tối đa 10 kết nối
            newsock.Listen(10);

            /* 
             * Xuất ra câu thông báo
             * khi client chưa được khởi chạy (chưa kết nối)
             */
            Console.WriteLine("Dang doi ket noi tu client...");

            /*
             * Sau khi socket ở server chấp nhận kết nối
             * sẽ tạo ra socket client,
             * server giao tiếp với client
             * thông qua socket (kênh ảo) này
             * 
             * Hàm Accept() sẽ block server lại
             * cho đến khi có Client kết nối đến
             */
            Socket client = newsock.Accept();

            /*
             * Server tạo ra chuỗi chào mừng client
             * ngay khi client vừa kết nối đến
             */
            string welcome = "---CHAO MUNG DEN VOI TEST SERVER---";

            /* 
             * Chuyển chuỗi chào mừng thành mảng byte
             * vì hàm Send() bên dưới nhận giá trị là một mảng byte
             */
            data = Encoding.ASCII.GetBytes(welcome);

            /*
             * Dùng hàm Send() để gửi giá trị qua socket ở client
             * 
             * data: mảng byte chứa chuỗi chào mừng
             * 
             * data.Length là tổng số byte sau khi chuyển chuỗi sang byte
             * (VD: abc --> 3 byte)
             * 
             * SocketFlags.None chỉ ra cách gửi dữ liệu trên Socket,
             * ở đây là không thực hiện các tuỳ chọn
             */
            client.Send(data, data.Length, SocketFlags.None);

            // Lấy thông tin IPEndPoint (IP và port) của client
            IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;

            // In thông tin IPEndPoint của client ra màn hình server
            Console.WriteLine("Da ket noi voi dia chi {0} tai port {1}",
                                newclient.Address, newclient.Port);

            /*
             * Dùng vòng lặp để cố gắng nhận và xuất ra
             * năm thông điệp riêng biệt từ client
             * 
             * Mỗi khi được gọi, phương thức Receive()
             * sẽ đọc toàn bộ dữ liệu trong bộ đệm TCP,
             * sau khi nhận năm thông điệp, kết nối được đóng lại
             */
            for (int i = 0; i < 5; i++)
            {
                // Nhận dữ liệu từ client gửi qua
                recv = client.Receive(data);

                // Chuyển thông điệp từ byte sang chuỗi để xuất ra
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
            }

            // Ngắt kết nối với client khi đã nhận thông điệp quá 5 lần
            Console.WriteLine("Dang ngat ket noi voi {0}", newclient.Address);

            // Đóng socket giao tiếp với client
            client.Close();

            // Đóng socket thực hiện listen ở phía server
            newsock.Close();

            Console.ReadKey();
        }
    }
}
