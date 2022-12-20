using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ThreadTcpServer
{
    class ThreadTcpServer
    {
        private TcpListener client;

        public ThreadTcpServer()
        {
            // Khởi tạo TcpListener tại port 9050
            client = new TcpListener(9050);

            // Bắt đầu lắng nghe
            client.Start();

            // In ra thông điệp ở phía server
            Console.WriteLine("Waiting for clients...");

            // Xử lý nếu có kết nối
            while(true)
            {
                // Nếu không có kết nối đang chờ xử lý
                while (!client.Pending())
                {
                    // Tạm dừng luồng hiện tại trong 1000 mili giây (1 giây)
                    Thread.Sleep(1000);
                }

                // Tạo một luồng mới để xử lý kết nối đến
                ConnectionThread newconnection = new ConnectionThread();

                /*
                 * Trả TcpListener client về
                 * để chương trình tiếp tục lắng nghe kết nối khác
                 */
                newconnection.threadListener = this.client;

                // Khởi tạo một luồng mới
                Thread newthread = new Thread(new ThreadStart(newconnection.HandleConnection));
                newthread.Start();
            }
        }

        static void Main(string[] args)
        {
            // Tạo mới một đối tượng ThreadTcpServer
            ThreadTcpServer server = new ThreadTcpServer();
        }

        // Xử lý các luồng được TcpListener client chuyển giao
        class ConnectionThread
        {
            public TcpListener threadListener;

            // Tổng số kết nối đến
            private static int connections = 0;

            // Xử lý kết nối đến
            public void HandleConnection()
            {
                // Tạo biến, mảng để nhận dữ liệu
                int recv;
                byte[] data = new byte[1024];

                // Chấp nhận kết nối đến
                TcpClient client = threadListener.AcceptTcpClient();

                // Tạo ra luồng để đọc và gửi dữ liệu
                NetworkStream ns = client.GetStream();

                // Tăng số kết nối lên 1
                connections++;

                // In số kết nối đang kết nối đến
                Console.WriteLine("New client accepted: {0} active connections", connections);

                // In ra câu chào và gửi qua client bằng NetworkStream
                string welcome = "Welcome to my test server";
                data = Encoding.ASCII.GetBytes(welcome);
                ns.Write(data, 0, data.Length);

                // Đọc dữ liệu do phía client gửi qua
                while (true)
                {
                    /*
                     * Tạo mảng và biến để lưu trữ dữ liệu và số byte,
                     * dùng hàm Read() để đọc từ NetworkStream
                     */
                    data = new byte[1024];
                    recv = ns.Read(data, 0, data.Length);

                    // Nếu không nhận được dữ liệu
                    if (recv == 0)
                        break;

                    /*
                     * Dùng NetworkStream để gửi lại cho client
                     * chính thông điệp mà cliet đã gửi qua server
                     */
                    ns.Write(data, 0, recv);
                }

                // Đóng NetworkStream
                ns.Close();

                // Ngắt kết nối
                client.Close();

                // Giảm tổng số kết nối
                connections--;

                // In lại tổng số kết nối hiện còn kết nối
                Console.WriteLine("Client disconnected: {0} active connections", connections);
            }
        }
    }
}
