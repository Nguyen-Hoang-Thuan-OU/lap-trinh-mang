// Chương trình TCP Server đơn giản (Simple TCP Server)

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BTH02_BT01
{
    class SimpleTcpSrvr
    {
        static void Main(string[] args)
        {
            /* 
             * Số lượng byte dữ liệu thật sự
             * mà server nhận được từ client bằng hàm Receive()
             * (Ví dụ: abc --> 3 byte)
             */
            int recv;

            /*
             * Tạo mảng data có 1024 byte
             * làm bộ đệm để nhận và gửi dữ liệu
             */
            byte[] data = new byte[1024];

            /*
             * Tạo IPEndPoint ở phía server và chấp nhận kết nối
             * trên bất kỳ card mạng nào với port 9050
             */
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);

            /*
             * Tạo mới một socket ở phía server
             * để tiến hành lắng nghe kết nối từ client
             * 
             * AddressFamily.InterNetwork: họ địa chỉ IP version 4
             * 
             * SocketType.Stream: kiểu Socket Stream
             * dùng trong các giao thức hướng kết nối,
             * yêu cầu kết nối trước khi truyền dữ liệu
             * 
             * ProtocolType.Tcp: kiểu giao thức tin cậy TCP
             */
            Socket newsock = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream, ProtocolType.Tcp);

            // Kết nối IPEndPoint với socket
            newsock.Bind(ipep);

            // Lắng nghe kết nối từ client, tối đa 10 kết nối
            newsock.Listen(10);

            /* 
             * In ra câu thông báo
             * khi client chưa được khởi chạy (chưa kết nối)
             */
            Console.WriteLine("Dang doi client ket noi den...");
            Console.WriteLine("----------------------------------------");

            /*
             * Sau khi socket "newsock" ở server
             * chấp nhận kết nối từ client sẽ tạo ra socket "client",
             * server giao tiếp với client thông qua socket "client" này
             * (server tạo ra kênh ảo để giao tiếp với client)
             * 
             * Từ giờ, server có thể gửi và nhận dữ liệu với client
             * thông qua phương thức Send() và Receive()
             * 
             * Hàm Accept() sẽ block server lại
             * đến khi có client kết nối đến
             */
            Socket client = newsock.Accept();

            /*
             * Tạo thêm IPEndPoint 
             * để lấy thông tin IPEndPoint (IP và port) của client
             */
            IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;

            // In thông tin IPEndPoint của client ra màn hình server
            Console.WriteLine("Da ket noi voi dia chi {0} tai port {1}",
                                clientep.Address, clientep.Port);

            /*
             * Server tạo ra chuỗi chào mừng ở màn hình của client
             * ngay khi client vừa kết nối đến
             */
            string welcome = "---CHAO MUNG DEN VOI SERVER THU NGHIEM---";

            /* 
             * Chuyển chuỗi chào mừng thành mảng byte
             * vì hàm Send() bên dưới nhận giá trị là một mảng byte
             */
            data = Encoding.ASCII.GetBytes(welcome);

            /*
             * Dùng hàm Send() để gửi giá trị qua socket "client",
             * 
             * data: mảng các byte cần gửi
             * 
             * data.Length: tổng số byte cần gửi
             * sau khi đã chuyển chuỗi sang byte (VD: abc --> 3 byte)
             * 
             * SocketFlags.None: chỉ ra cách gửi dữ liệu trên Socket,
             * ở đây là không thực hiện các tuỳ chọn
             */
            client.Send(data, data.Length, SocketFlags.None);

            Console.WriteLine("----------------------------------------");

            // Tạo ra một vòng lặp vô tận để nhận về dữ liệu từ client
            while (true)
            {
                /*
                 * Khai báo mảng data có 1024 byte (Reset lại bộ đệm)
                 * 
                 * Phương thức Receive() bên dưới
                 * sẽ đặt dữ liệu vào mảng data (bộ đệm),
                 * nếu bộ đệm không được thiết lập lại,
                 * lần gọi phương thức Receive() kế tiếp
                 * sẽ chỉ có thể nhận được dữ liệu tối đa
                 * bằng lần nhận dữ liệu trước
                 */
                data = new byte[1024];

                /*
                 * Dùng phương thức Receive() để nhận và trả về
                 * số byte dữ liệu thật sự mà client gửi qua bằng 
                 * 
                 * Nếu không có dữ liệu được nhận,
                 * phương thức Receive() sẽ bị dừng lại
                 * và chờ cho tới khi có dữ liệu
                 */
                recv = client.Receive(data);

                //Nếu Client ngắt kết nối thì thoát khỏi vòng lặp
                if (recv == 0)
                    break;

                /*
                 * In thông điệp ra màn hình của server
                 * 
                 * Vì hàm Send() bên client gửi mảng byte
                 * nên nếu server nhận được thông điệp từ client
                 * thì sẽ chuyển thông điệp từ byte sang chuỗi
                 */
                Console.Write("Noi dung do client gui: ");
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

                /*
                 * Gửi dữ liệu (dạng byte) lại cho bên client
                 * (client gửi qua server nội dung gì
                 * thì server gửi lại cho client nội dung y chang)
                 */
                client.Send(data, recv, SocketFlags.None);
            }

            /*
             * Thoát vòng lặp khi client chủ động ngắt kết nối
             * và in ra địa chỉ IP của client đã ngắt kết nối
             */
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Da ngat ket noi voi {0}", clientep.Address);
            Console.WriteLine("----------------------------------------");

            // Đóng socket (kênh ảo) thực hiện giao tiếp với client
            client.Close();

            /*
             * Đóng socket mà server dùng để thực hiện
             * lắng nghe kết nối của client
             */
            newsock.Close();

            Console.ReadKey();
        }
    }
}