// Chương trình UDP Client đơn giản

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BTH03_BT01_Client
{
    class SimpleUdpClient
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

            // Tạo chuỗi hỏi thăm server
            string welcome = "Hello, are you there?";

            // Chuyển chuỗi hỏi thăm sang byte
            data = Encoding.ASCII.GetBytes(welcome);

            /*
             * Client gửi thông điệp hỏi thăm đến server
             * và chờ câu chào trả về từ server
             */
            server.SendTo(data, data.Length, SocketFlags.None, ipep);

            /*
             * Tạo IPEndPoint để lưu lại thông tin của server,
             * cho phép đọc thông tin từ tất cả các IP và port
             */
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            // Gán thông tin IP và port vào biến Remote
            EndPoint Remote = (EndPoint)sender;

            // Tạo mảng data có 1024 byte
            data = new byte[1024];

            // Client sẽ nhận câu chào từ server
            int recv = server.ReceiveFrom(data, ref Remote);

            // In ra thông tin IP và port của server
            Console.WriteLine("Message received from {0}:", Remote.ToString());

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

                // Gửi chuỗi đã nhập sang server
                server.SendTo(Encoding.ASCII.GetBytes(input), Remote);

                // Tạo mảng data có 1024 byte
                data = new byte[1024];

                // Nhận mảng byte do server gửi lại
                recv = server.ReceiveFrom(data, ref Remote);

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
