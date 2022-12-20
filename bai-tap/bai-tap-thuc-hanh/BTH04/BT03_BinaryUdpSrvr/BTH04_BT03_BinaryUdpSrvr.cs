using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class BTH04_BT03_BinaryUdpSrvr
{
    public static void Main()
    {
        // Tạo mảng data có 1024 byte để lưu trữ dữ liệu
        byte[] data = new byte[1024];

        /*
         * Tạo IPEndPoint ở phía server và chấp nhận kết nối
         * trên bất kỳ card mạng nào với port 9050
         */
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);

        // Tạo ra socket và kết nối socket đến IPEndPoint
        UdpClient newsock = new UdpClient(ipep);

        // In ra thông báo chờ Client
        Console.WriteLine("Waiting for a client...");

        /*
         * Tạo IPEndPoint để lưu lại thông tin của Client,
         * cho phép đọc thông tin từ tất cả các IP và port
         */
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

        // Nhận thông tin về IP và port của Client
        data = newsock.Receive(ref sender);

        // In ra màn hình của Server thông tin về IP và port của Client
        Console.WriteLine("Message received from {0}:", sender.ToString());

        // Nhận câu thăm dò từ Client
        Console.WriteLine(Encoding.ASCII.GetString(data, 0, data.Length));

        // Chuỗi chào mừng Client
        string welcome = "Welcome to my test server";

        // Chuyển chuỗi chào mừng thành mảng byte
        data = Encoding.ASCII.GetBytes(welcome);

        // Gửi chuỗi chào mừng dạng mảng byte sang Client
        newsock.Send(data, data.Length, sender);

        /*
         * Tạo mảng mới để nhận thông điệp từ Client theo từng kiểu dữ liệu
         * và in thông điệp ra màn hình của Server
         */
        byte[] data1 = newsock.Receive(ref sender);
        int test1 = BitConverter.ToInt32(data1, 0);
        Console.WriteLine("test1 = {0}", test1);

        byte[] data2 = newsock.Receive(ref sender);
        double test2 = BitConverter.ToDouble(data2, 0);
        Console.WriteLine("test2 = {0}", test2);

        byte[] data3 = newsock.Receive(ref sender);
        int test3 = BitConverter.ToInt32(data3, 0);
        Console.WriteLine("test3 = {0}", test3);

        byte[] data4 = newsock.Receive(ref sender);
        bool test4 = BitConverter.ToBoolean(data4, 0);
        Console.WriteLine("test4 = {0}", test4.ToString());

        byte[] data5 = newsock.Receive(ref sender);
        string test5 = Encoding.ASCII.GetString(data5);
        Console.WriteLine("test5 = {0}", test5);

        // Đóng đối tượng UdpClient
        newsock.Close();
    }
}