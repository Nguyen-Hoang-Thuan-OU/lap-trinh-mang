// Chương trình TCP Client đơn giản (Simple TCP Client)

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class SimpleTcpClient
{
    public static void Main()
    {
        // Tạo mảng data có 1024 byte (bộ đệm)
        byte[] data = new byte[1024];

        /*
         * Tạo chuỗi input để client nhập dữ liệu (chuỗi nhập),
         * chuỗi stringData để client nhận dữ liệu (chuỗi nhận)
         */
        string input, stringData;

        /*
         * Tạo IPEndPoint với thông tin IPAddress và port 9050 của server
         * (do server là máy cục bộ nên IPAddress là 127.0.0.1)
         */
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        /*
         * Tạo socket ở phía client
         * để kết nối với server thông qua IPEndPoint
         */
        Socket server = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream, ProtocolType.Tcp);

        // Thực hiện bắt lỗi nếu có lỗi xảy ra (lỗi chưa chạy server)
        try
        {
            /*
             * Kết nối socket đến IPEndPoint (IP và port) của server
             * 
             * Hàm Connect() sẽ bị block lại
             * và chờ khi kết nối được với server thì mới hết block
             */
            server.Connect(ipep);
        }
        catch (SocketException e)
        {
            // Báo lỗi khi không thể kết nối
            Console.WriteLine("Khong the ket noi den server!");
            Console.WriteLine(e.ToString());
            return;
        }

        /*
         * Số byte mà client thực sự nhận được từ server,
         * truyền vào mảng data
         */
        int recv = server.Receive(data);

        // Chuyển mảng mới nhận được từ server thành dạng chuỗi
        stringData = Encoding.ASCII.GetString(data, 0, recv);

        /*
         * In chuỗi dữ liệu server gửi ra màn hình
         * (trong trường hợp này là câu chào)
         */
        Console.WriteLine(stringData);

        Console.WriteLine("-----------------------------------------------");

        // Tạo một vòng lặp vô tận để nhập và nhận dữ liệu
        while (true)
        {
            /*
             * Cho client nhập vào một dòng
             * và gán nội dung vào chuỗi input đã tạo ở trên
             */
            Console.Write("Nhap noi dung client muon gui sang server: ");
            input = Console.ReadLine();

            // Sẽ thoát và đóng socket khi nhập "exit"
            if (input == "exit")
                break;

            /*
             * Nội dung client nhập khác "exit"
             * sẽ được chuyển thành mảng byte để gửi sang server
             */
            server.Send(Encoding.ASCII.GetBytes(input));

            /*
             * Tạo mảng có 1024 byte để nhận lại dữ liệu từ server
             * (Reset lại bộ đệm)
             */
            data = new byte[1024];

            // Dữ liệu server gửi lại sẽ được đưa vào mảng data
            recv = server.Receive(data);

            /*
             * Chuyển mảng data do server gửi thành chuỗi
             * và xuất ra màn hình của client
             */
            stringData = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine("--> Server gui lai client: {0}\n", stringData);
        }

        // Client ngắt kết nối với server
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine("Dang ngat ket noi voi server...");
        Console.WriteLine("-----------------------------------------------");

        // Dừng kết nối, không cho phép nhận và gửi dữ liệu
        server.Shutdown(SocketShutdown.Both);

        // Đóng socket giao tiếp với server
        server.Close();

        Console.ReadKey();
    }
}