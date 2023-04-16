// Chương trình Bad UDP Client cải tiến (có thể hạn chế mất dữ liệu)

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BTH03_BT05_BetterdUdpClient
{
    class BetterdUdpClient
    {
        static void Main(string[] args)
        {
            // Khai báo mảng data chỉ 30 byte
            byte[] data = new byte[30];

            // Tạo biến để nhập và nhận chuỗi
            string input, stringData;
            // Tạo IPEndPoint
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

            // Tạo UDP socket
            Socket server = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Dgram, ProtocolType.Udp);

            // Tạo chuỗi hỏi thăm server
            string welcome = "Hello, are you there?";

            // Chuyển chuỗi hỏi thăm thành byte
            data = Encoding.ASCII.GetBytes(welcome);

            // Gửi chuỗi hỏi thăm sang server và chờ phản hồi
            server.SendTo(data, data.Length, SocketFlags.None, ipep);

            /*
             * Tạo IPEndPoint để lưu lại thông tin của server,
             * cho phép đọc thông tin từ tất cả các IP và port
             */
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            // Gán thông tin IP và port của client vào biến tmpRemote
            EndPoint tmpRemote = (EndPoint)sender;

            // Tạo mảng data 30 byte
            data = new byte[30];

            /*
             * Nhận dữ liệu gồm chuỗi chào mừng,
             * địa chỉ IP và port từ server
             */
            int recv = server.ReceiveFrom(data, ref tmpRemote);

            // In thông tin IP và port của server ra màn hình của client
            Console.WriteLine("Message received from {0}:", tmpRemote.ToString());

            // In chuỗi chào mừng của server ra màn hình của client
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            // Tạo biến i để tăng kích thước bộ đệm
            int i = 30;

            // Vòng lặp để gửi và nhận dữ liệu
            while (true)
            {
                // Đọc dữ liệu mà client nhập vào từ bàn phím
                input = Console.ReadLine();

                // Nếu nhận về chuỗi "exit" thì thoát vòng lặp và đóng kết nối
                if (input == "exit")
                    break;

                // Client gửi chuỗi dữ liệu vừa nhập sang cho server
                server.SendTo(Encoding.ASCII.GetBytes(input), tmpRemote);

                // Tạo mảng data có kích thước ban đầu là 30 byte
                data = new byte[i];

                /*
                 * Đặt phương thức ReceiveFrom() trong khối try-catch,
                 * khi dữ liệu bị mất bởi kích thước bộ đệm nhỏ,
                 * ta có thể tăng kích thước bộ đệm vào lần kế tiếp nhận dữ liệu
                 * thay vì sử dụng mảng data với chiều dài cố định
                 */
                try
                {
                    // Nhận dữ liệu từ server như bình thường
                    recv = server.ReceiveFrom(data, ref tmpRemote);

                    // Chuyển dữ liệu từ mảng byte thành chuỗi
                    stringData = Encoding.ASCII.GetString(data, 0, recv);

                    // In chuỗi dữ liệu do server gửi ra màn hình của client
                    Console.WriteLine(stringData);
                }
                catch (SocketException)
                {
                    // Ném ra cảnh báo mất dữ liệu
                    Console.WriteLine("WARNING: data lost, retry message.");

                    // Tăng kích thước của mảng data lên 10 byte
                    i += 10;
                }
            }

            // In ra thông báo ngắt kết nối với server
            Console.WriteLine("Stopping client");


            // Đóng socket
            server.Close();

            Console.ReadKey();
        }
    }
}
