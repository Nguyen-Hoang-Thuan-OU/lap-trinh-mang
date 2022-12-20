using System;
using System.Net;
using System.Net.Sockets;

class SockProp
{
    public static void Main()
    {
        // Khởi tạo địa chỉ IP 127.0.0.1
        IPAddress ia = IPAddress.Parse("127.0.0.1");

        // Khởi tạo IPEndPoint có địa chỉ IP là IPAddress và port 8000
        IPEndPoint ie = new IPEndPoint(ia, 8000);

        // Tạo socket
        Socket test = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        // Xuất loại địa chỉ IP của socket (IPv4 hay IPv6)
        Console.WriteLine("AddressFamily: {0}", test.AddressFamily);

        // Xuất kiểu của socket
        Console.WriteLine("SocketType: {0}", test.SocketType);

        // Xuất kiểu giao thức của socket
        Console.WriteLine("ProtocolType: {0}", test.ProtocolType);

        /*
         * Xuất tình trạng Socket ở chế độ chặn hay không,
         * mặc định là chặn cho đến khi có Client kết nối đến
         */
        Console.WriteLine("Blocking: {0}", test.Blocking);

        // Bỏ chặn socket
        test.Blocking = false;

        // Xuất tình trạng socket hiện tại khi bỏ chặn
        Console.WriteLine("New Blocking: {0}", test.Blocking);

        // Xuất kết quả cho biết socket được kết nối với thiết bị ở xa hay chưa
        Console.WriteLine("Connected: {0}", test.Connected);

        // Server yêu cầu gán port cho socket
        test.Bind(ie);

        // Khởi tạo iep với endpoint cục bộ
        IPEndPoint iep = (IPEndPoint)test.LocalEndPoint;

        // Xuất endpoint cục bộ dạng địa chỉ ip:port
        Console.WriteLine("Local EndPoint: {0}", iep.ToString());

        // Đóng kết nối socket và giải phóng tài nguyên
        test.Close();

        Console.ReadKey();
    }
}