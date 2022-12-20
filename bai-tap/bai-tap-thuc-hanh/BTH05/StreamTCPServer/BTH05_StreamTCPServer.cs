using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
class StreamTcpSrvr
{
    public static void Main()
    {
        // Tạo chuỗi để chứa dữ liệu
        string data;

        // Tạo IPEndPoint bằng card mạng bất kỳ và port 9050
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);

        // Tạo socket ở phía server
        Socket newsock = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream, ProtocolType.Tcp);

        // Gắn socket với IPEndPoint
        newsock.Bind(ipep);

        // Lắng nghe kết nối từ client, tối đa 10 kết nối
        newsock.Listen(10);

        // In ra thông báo chờ ở màn hình server
        Console.WriteLine("Waiting for a client...");

        // Chấp nhận kết nối từ client và tạo socket mới
        Socket client = newsock.Accept();

        // Tạo mới một IPEndPoint để lấy thông tin của client
        IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;

        // In thông tin của client
        Console.WriteLine("Connected with {0} at port {1}",
                            newclient.Address, newclient.Port);

        // Tạo ra một đối tượng NetworkStream từ đối tượng Socket
        NetworkStream ns = new NetworkStream(client);

        /*
         * StreamReader và StreamWriter điều khiển việc đọc
         * và ghi các thông điệp text từ mạng,
         * giải quyết các vấn đề với biên thông điệp
         * 
         * Tạo ra các đối tượng StreamReader và StreamWriter
         * từ đối tượng NetworkStream
         */
        StreamReader sr = new StreamReader(ns);
        StreamWriter sw = new StreamWriter(ns);

        // Tạo chuỗi chào mừng client
        string welcome = "Welcome to my test server";

        /* 
         * Dùng phương thức WriteLine() của lớp StreamWriter
         * để gửi các thông điệp text
         * và kết thúc bằng ký tự xuống dòng ra stream
         */
        sw.WriteLine(welcome);

        /*
         * Dùng phương thức Flush() sau khi gọi phương thức WriteLine()
         * để đảm bảo rằng đẩy tất cả dữ liệu từ NetworkStream đi
         */
        sw.Flush();

        /*
         * Vòng lặp dùng để đọc và in nội dung ra màn của server,
         * sau đó gửi lại cho client nội dung giống vậy
         */
        while (true)
        {
            /*
             * Vì phương thức ReadLine() hoạt động trên stream
             * chứ không phải là Socket nên nó không thể
             * trả về giá trị 0 khi Client ngắt kết nối.
             * Thay vì vậy, phương thức ReadLine()
             * sẽ phát sinh ra một biệt lệ nếu Client ngắt kết nối
             * và ta phải dùng catch để bắt biệt lệ này
             * và xử lý khi Client ngắt kết nối
             */
            try
            {
                /*
                 * Phương thức ReadLine() đọc các ký tự từ stream
                 * cho tới khi nó gặp ký tự xuống dòng
                 * (dùng ký tự xuống dòng
                 * như một ký tự phân tách các thông điệp)
                 */
                data = sr.ReadLine();
            }
            catch (IOException)
            {
                break;
            }

            /*
             * Phương thức WriteLine() của lớp StreamWriter
             * sẽ so khớp thông điệp với phương thức ReadLine
             * của lớp StreamReader sau đó in ra màn hình của server
             */
            Console.WriteLine(data);

            // Gửi dữ liệu cùng ký tự xuống dòng ra stream
            sw.WriteLine(data);

            // Gửi tất cả dữ liệu trong bộ đệm StreamWriter ra stream
            sw.Flush();
        }

        /*
         * In ra thông báo kèm địa chị IP của client
         * khi client chủ động ngắt kết nối
         */
        Console.WriteLine("Disconnected from {0}", newclient.Address);

        // Đóng đối tượng StreamWriter
        sw.Close();

        // Đóng đối tượng StreamReader
        sr.Close();

        // Đóng đối tượng NetworkStream
        ns.Close();

        Console.ReadKey();
    }
}