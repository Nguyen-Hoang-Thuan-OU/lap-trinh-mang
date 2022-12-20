using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
class StreamTcpClient
{
    public static void Main()
    {
        // Tạo chuỗi để chứa dữ liệu
        string data;

        // Tạo chuỗi để nhập dữ liệu
        string input;

        // Tạo IPEndPoint
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        // Tạo socket
        Socket server = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream, ProtocolType.Tcp);
        try
        {
            // Kết nối với server
            server.Connect(ipep);
        }
        catch (SocketException e)
        {
            Console.WriteLine("Unable to connect to server.");
            Console.WriteLine(e.ToString());
            return;
        }

        // Tạo ra một đối tượng NetworkStream từ đối tượng Socket
        NetworkStream ns = new NetworkStream(server);

        /*
         * Tạo ra các đối tượng StreamReader và StreamWriter
         * để đọc và ghi các thông điệp text từ mạng
         */
        StreamReader sr = new StreamReader(ns);
        StreamWriter sw = new StreamWriter(ns);

        /*
         * Phương thức ReadLine() đọc các ký tự từ stream
         * cho tới khi nó gặp ký tự xuống dòng
         */
        data = sr.ReadLine();

        // In ra màn hình của client câu chào của server
        Console.WriteLine(data);


        /*
         * Vòng lặp dùng để nhập và gửi thông điệp sang server,
         * sau đó nhận lại từ server nội dung client đã gửi
         */
        while (true)
        {
            // Nhập dữ liệu từ bàn phím kèm ký tự xuống dòng
            input = Console.ReadLine();

            /*
             * Kiểm tra từ vừa chuỗi vừa nhập có phải là exit,
             * nếu phải sẽ kết thúc vòng lặp
             */
            if (input == "exit")
                break;

            // Gửi chuỗi đã nhập sang server
            sw.WriteLine(input);

            // Đẩy tất cả dữ liệu từ NetworkStream đi
            sw.Flush();

            // Nhận lại nội dung do chính client gửi cho server
            data = sr.ReadLine();

            // In nội dung ra màn hình của client
            Console.WriteLine(data);
        }

        // In ra thông báo khi client chủ động ngắt kết nối
        Console.WriteLine("Disconnecting from server...");

        // Đóng đối tượng StreamWriter
        sw.Close();

        // Đóng đối tượng StreamReader
        sr.Close();

        // Đóng đối tượng NetworkStream
        ns.Close();

        // Dừng kết nối, không cho phép nhận và gửi dữ liệu
        server.Shutdown(SocketShutdown.Both);

        // Đóng socket giao tiếp với server
        server.Close();

        Console.ReadKey();
    }
}