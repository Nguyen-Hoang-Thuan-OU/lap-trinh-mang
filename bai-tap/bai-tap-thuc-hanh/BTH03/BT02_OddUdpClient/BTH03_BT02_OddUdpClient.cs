// Chương trình UDP Client dùng phương thức Connect()

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BTH03_BT02_OddUdpClient
{
    class OddUdpClient
    {
        public static void Main()
        {
            // Tạo mảng data có 1024 byte
            byte[] data = new byte[1024];

            // Tạo chuỗi để nhập và nhận dữ liệu
            string input, stringData;

            // Định nghĩa một IPEndPoint mà UDP Server sẽ gởi các gói tin
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

            // Tạo UDP socket để giao tiếp với server
            Socket server = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Dgram, ProtocolType.Udp);

            /*
             * Dùng phương thức Connect()
             * giống như trong chương trình TCP để chỉ ra UDP Server ở xa,
             * từ giờ có thể dùng phương thức Send() và Receive()
             * để truyền tải dữ liệu giữa các thiết bị với nhau
             */
            server.Connect(ipep);

            // Tạo chuỗi hỏi thăm
            string welcome = "Hello, are you there?";

            // Chuyển chuỗi sang byte
            data = Encoding.ASCII.GetBytes(welcome);

            // Dùng hàm send() để gửi mảng hỏi thăm sang server
            server.Send(data);

            // Tạo mảng data có 1024 byte
            data = new byte[1024];

            // Nhận mảng chứa câu chào của server
            int recv = server.Receive(data);

            // In thông tin IP và port của server ra màn hình của client
            Console.WriteLine("Message received from {0}:", ipep.ToString());

            // In câu chào của server ra màn hình của client
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            // Vòng lặp để gửi và nhận dữ liệu
            while (true)
            {
                // Đọc chuỗi dữ liệu được nhập từ bàn phím
                input = Console.ReadLine();

                /*
                 * Nếu chuỗi nhập là "exit" thì vòng lặp sẽ thoát
                 * và kết nối bị đóng lại
                 */
                if (input == "exit")
                    break;

                // Chuyển chuỗi đã nhập thành byte và chuyển sang server
                server.Send(Encoding.ASCII.GetBytes(input));

                // Tạo mảng data có 1024 byte
                data = new byte[1024];

                // Nhận mảng byte do server gửi lại
                recv = server.Receive(data);

                // Chuyển mảng byte thành dạng chuỗi
                stringData = Encoding.ASCII.GetString(data, 0, recv);

                // In chuỗi ra màn hình của client
                Console.WriteLine(stringData);
            }

            // In ra thông báo ngắt kết nối
            Console.WriteLine("Stopping client");

            // Đóng socket
            server.Close();

            Console.ReadKey();
        }

    }
}
