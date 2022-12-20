// Chương trình UDP Server đơn giản

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace BTH03_BT01_Server
{
    class SimpleUdpSrvr
    {
        public static void Main()
        {
            /* 
             * Tạo biến recv chứa số lượng byte dữ liệu
             * mà server nhận được từ client
             * (Ví dụ: abc --> 3 byte)
             */
            int recv;

            // Tạo mảng data có 1024 byte để lưu trữ dữ liệu
            byte[] data = new byte[1024];

            /*
             * Tạo IPEndPoint ở phía Server
             * với địa chỉ lắng nghe trên tất cả các card mạng và port 9050
             */
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);

            /*
             * Tạo mới một UDP socket ở phía server
             * 1. Kiểu địa chỉ IPv4
             * 2. Kiểu socket không ổn định, không tin cậy
             * 3. Kết nối giao thức UDP
             */
            Socket newsock = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Dgram, ProtocolType.Udp);

            // Kết nối Socket đến một IPEndPoint cục bộ
            newsock.Bind(ipep);

            /* 
             * Xuất ra câu thông báo chờ ở phía server
             * khi chưa có bất kỳ client nào kết nối đến
             */
            Console.WriteLine("Waiting for a client...");

            /*
             * Tạo IPEndPoint để lưu lại thông tin của client,
             * cho phép đọc thông tin từ tất cả các IP và port
             */
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

            // Gán thông tin IP và port của client vào biến Remote
            EndPoint Remote = (EndPoint)(sender);

            /*
             * Phương thức ReceiveFrom() sẽ đặt thông tin EndPoint từ client
             * vào vùng bộ nhớ của đối tượng EndPoint tham chiếu đến
             * 
             * Nhận thông tin địa chỉ IP và port của phía client,
             * truyền vào tham chiếu của đối tượng EndPoint
             * tham chiếu đến vị trí bộ nhớ nơi biến được lưu trữ
             */
            recv = newsock.ReceiveFrom(data, ref Remote);

            // In ra bên server thông tin địa chỉ IP và port của client
            Console.WriteLine("Message received from {0}:", Remote.ToString());

            /*
             * Chuyển dữ liệu nhận được từ client từ dạng byte thành chuỗi
             * (vì client có gửi câu hỏi thăm) và in ra màn hình của server
             */
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            /*
             * Server tạo ra chuỗi chào mừng client
             * sau khi nhận được câu hỏi thăm của client
             */
            string welcome = "Welcome client to my test server";

            /* 
             * Chuyển chuỗi chào mừng thành mảng byte
             * vì hàm SendTo() bên dưới nhận giá trị là một mảng byte
             */
            data = Encoding.ASCII.GetBytes(welcome);

            /* 
             * Dùng hàm SendTo() để gửi thông điệp chào mừng đến client
             * kèm theo IPEndPoint của client
             */
            newsock.SendTo(data, data.Length, SocketFlags.None, Remote);

            /* 
             * Vòng lặp để nhận và gửi lại cho client
             * chính nội dung mà client đã gửi qua cho server
             */
            while (true)
            {
                // Tạo mảng data có 1024 byte để lưu trữ dữ liệu
                data = new byte[1024];

                // Nhận dữ liệu từ phía client
                recv = newsock.ReceiveFrom(data, ref Remote);

                // Chuyển dữ liệu nhận được từ byte sang chuỗi
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

                /*
                 * Dùng phương thức SendTo() để gửi lại cho client
                 * chính nội dung mà client đã gửi qua cho server
                 */
                newsock.SendTo(data, recv, SocketFlags.None, Remote);
            }
        }
    }

}
