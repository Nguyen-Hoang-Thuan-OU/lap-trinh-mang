using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class TcpClientSample
{
    public static void Main()
    {
        // Tạo mảng data có 1024 byte để lưu trữ dữ liệu
        byte[] data = new byte[1024];

        // Tạo biến để nhập và nhận chuỗi dữ liệu
        string input, stringData;

        // Khai báo đối tượng TcpClient
        TcpClient server;
        try
        {
            // Tạo đối tượng TcpClient với địa chỉ IP cục bộ và port 9050
            server = new TcpClient("127.0.0.1", 9050);
        }

        // Ném ngoại lệ khi không thể kết nối đến server
        catch (SocketException)
        {
            Console.WriteLine("Unable to connect to server");
            return;
        }

        /*
         * Phương thức GetStream() tạo ra luồng Stream
         * để gửi và nhận dữ liệu
         */
        NetworkStream ns = server.GetStream();

        // Phương thức Read() dùng để nhận dữ liệu từ server
        int recv = ns.Read(data, 0, data.Length);

        // Chuyển chuỗi dữ liệu nhận được từ server thành byte
        stringData = Encoding.ASCII.GetString(data, 0, recv);

        // In câu chào của server ra màn hình
        Console.WriteLine(stringData);

        // Tạo vòng lập để gửi nhận dữ liệu đến server
        while (true)
        {
            // Nhập dữ liệu từ bàn phím
            input = Console.ReadLine();

            // Nếu nhập exit thì dừng
            if (input == "exit")
                break;

            /*
             * Chuyển chuỗi đã nhập thành byte
             * và dùng phương thức Write() để gửi dữ liệu đến server
             */
            ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);

            // Gửi tất cả dữ liệu trong bộ đệm đi
            ns.Flush();

            // Tạo mảng data có 1024 byte để lưu trữ dữ liệu
            data = new byte[1024];

            // Dùng phương thức Read() để nhận dữ liệu do server gửi
            recv = ns.Read(data, 0, data.Length);

            // Chuyển dữ liệu nhận được từ byte thành chuỗi
            stringData = Encoding.ASCII.GetString(data, 0, recv);

            // In dữ liệu ra màn hình của client
            Console.WriteLine(stringData);
        }

        // In thông báo ngắt kết nối
        Console.WriteLine("Disconnecting from server...");

        // Đóng đối tượng NetworkStream 
        ns.Close();

        // Đóng đối tượng TcpClient
        server.Close();
    }
}