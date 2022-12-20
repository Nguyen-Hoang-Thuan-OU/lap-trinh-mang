/*
 * Chương trình UDP Client kiểm tra việc phân biệt các thông điệp UDP
 * (khả năng xử lý thông điệp mà không cần quan tâm đến biên thông điệp)
 */

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class TestUdpClient
{
    public static void Main()
    {
        // Tạo mảng data 1024 byte
        byte[] data = new byte[1024];

        // Tạo IPEndPoint
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        // Tạo UDP socket
        Socket server = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Dgram, ProtocolType.Udp);

        // Tạo chuỗi hỏi thăm client
        string welcome = "Hello, are you there?";

        // Chuyển chuỗi hỏi thăm sang kiểu byte
        data = Encoding.ASCII.GetBytes(welcome);

        // Gửi câu hỏi thăm server và chờ phản hồi
        server.SendTo(data, data.Length, SocketFlags.None, ipep);

        /*
         * Tạo IPEndPoint để lưu lại thông tin của server,
         * cho phép đọc thông tin từ tất cả các IP và port
         */
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

        // Gán thông tin IP và port của client vào biến tmpRemote
        EndPoint tmpRemote = (EndPoint)sender;

        // Tảo mảng data 1024 byte
        data = new byte[1024];

        /*
         * Nhận câu chào từ server gồm mảng dữ liệu,
         * địa chỉ IP và port của server
         */
        int recv = server.ReceiveFrom(data, ref tmpRemote);

        // In ra thông tin IP và port của server
        Console.WriteLine("Message received from {0}:", tmpRemote.ToString());

        // In câu chào của server ra màn hình của client
        Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

        // Dùng hàm SendTo() để liên tục gửi thông điệp qua cho server
        server.SendTo(Encoding.ASCII.GetBytes("message 1"), tmpRemote);
        server.SendTo(Encoding.ASCII.GetBytes("message 2"), tmpRemote);
        server.SendTo(Encoding.ASCII.GetBytes("message 3"), tmpRemote);
        server.SendTo(Encoding.ASCII.GetBytes("message 4"), tmpRemote);
        server.SendTo(Encoding.ASCII.GetBytes("message 5"), tmpRemote);

        // In ra thông báo ngắt kết nối với server ở màn hình client
        Console.WriteLine("Stopping client");

        // Đóng socket
        server.Close();
    }
}