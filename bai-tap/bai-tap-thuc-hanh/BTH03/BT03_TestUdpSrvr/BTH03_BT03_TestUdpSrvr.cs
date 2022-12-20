/*
 * Chương trình UDP Server kiểm tra việc phân biệt các thông điệp UDP
 * (khả năng xử lý thông điệp mà không cần quan tâm đến biên thông điệp)
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TestUdpSrvr
{
    public static void Main()
    {
        // Tạo biến lưu trữ độ dài của dữ liệu thực sự nhận được
        int recv;

        // Tạo mảng data 1024 byte
        byte[] data = new byte[1024];

        // Tạo IPEndPoint trên card mạng bất kỳ và port 9050
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);

        // Tạo UDP socket
        Socket newsock = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Dgram, ProtocolType.Udp);
        // Gắn socket với IPEndPoint
        newsock.Bind(ipep);

        // In ra câu đợi client ở phía server
        Console.WriteLine("Waiting for a client...");

        /*
         * Tạo IPEndPoint để lưu lại thông tin của client,
         * cho phép đọc thông tin từ tất cả các IP và port
         */
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

        // Gán thông tin IP và port của client vào biến tmpRemote
        EndPoint tmpRemote = (EndPoint)(sender);

        /*
         * Nhận thông điệp từ client gồm mảng dữ liệu,
         * địa chỉ ip và port của máy client
         */
        recv = newsock.ReceiveFrom(data, ref tmpRemote);

        // In thông tin IP và port của client ra màn hình server
        Console.WriteLine("Message received from {0}:", tmpRemote.ToString());

        // Chuyển mảng dữ liệu thành chuỗi
        Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

        // Tạo câu chào client
        string welcome = "Welcome to my test server";

        // Chuyển câu chào thành mảng byte
        data = Encoding.ASCII.GetBytes(welcome);

        // Gửi câu chào sang client thông qua tmpRemote
        newsock.SendTo(data, data.Length, SocketFlags.None, tmpRemote);

        // Nhận dữ liệu từ client và in ra màn hình client
        for (int i = 0; i < 5; i++)
        {
            // Tạo mảng data 1024 byte
            data = new byte[1024];

            /*
             * Nhận dữ liệu từ client
             * 
             * Mỗi lần gọi phương thức ReceiveFrom()
             * nó chỉ đọc dữ liệu được gửi từ một phương thức SendTo(),
             * dùng các đánh dấu bởi thông tin IP
             * để phân biệt được client nào gửi dữ liệu
             */
            recv = newsock.ReceiveFrom(data, ref tmpRemote);

            // In dữ liệu nhận được ra màn hình
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
        }
        //ngắt kết nối server
        newsock.Close();

        Console.ReadKey();
    }
}