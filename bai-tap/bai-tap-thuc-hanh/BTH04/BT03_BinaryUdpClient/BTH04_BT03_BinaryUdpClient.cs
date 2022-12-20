using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class BTH04_BT03_BinaryUdpClient
{
    public static void Main()
    {
        // Tạo mảng data có 1024 byte để lưu trữ dữ liệu
        byte[] data = new byte[1024];

        // Tạo biến để nhận chuỗi dữ liệu
        string stringData;

        // Tạo đối tượng UdpClient với địa chỉ IP cục bộ và port 9050
        UdpClient server = new UdpClient("127.0.0.1", 9050);

        /*
         * Tạo IPEndPoint để lưu lại thông tin của Server,
         * cho phép đọc thông tin từ tất cả các IP và port
         */
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

        // Tạo chuỗi thăm dò
        string welcome = "Hello, are you there?";

        // Chuyển chuỗi thành mảng byte
        data = Encoding.ASCII.GetBytes(welcome);

        /*
         * Dùng phương thức tạo lập của lớp UdpClient
         * để chỉ ra thiết bị ở xa và gửi chuỗi sang Server
         */
        server.Send(data, data.Length);

        // Tạo mảng data có 1024 byte để lưu trữ dữ liệu
        data = new byte[1024];

        // Nhận thông tin về IP và port của Server
        data = server.Receive(ref sender);

        // In ra màn hình của Client thông tin về IP và port của Server
        Console.WriteLine("Message received from {0}:", sender.ToString());

        // Chuyển câu chào mừng của Server thành chuỗi
        stringData = Encoding.ASCII.GetString(data, 0, data.Length);

        // In câu chào mừng ra màn hình của Client
        Console.WriteLine(stringData);

        // Tạo ra các biến để gửi sang cho Server
        int test1 = 45;
        double test2 = 3.14159;
        int test3 = -1234567890;
        bool test4 = false;
        string test5 = "This is a test.";

        // Chuyển các giá trị của biến thành mảng byte và gửi sang Server
        byte[] data1 = BitConverter.GetBytes(test1);
        server.Send(data1, data1.Length);

        byte[] data2 = BitConverter.GetBytes(test2);
        server.Send(data2, data2.Length);

        byte[] data3 = BitConverter.GetBytes(test3);
        server.Send(data3, data3.Length);

        byte[] data4 = BitConverter.GetBytes(test4);
        server.Send(data4, data4.Length);

        byte[] data5 = Encoding.ASCII.GetBytes(test5);
        server.Send(data5, data5.Length);

        // In ra kêu ngắt kết nối
        Console.WriteLine("Stopping client");

        // Đóng đối tượng UdpClient
        server.Close();
    }
}