using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

/*
 * Lớp TcpListener cung cấp các phương thức đơn giản
 * để lắng nghe và chấp nhận các yêu cầu kết nối đến,
 * cho phép chúng ta tạo ra các chương trình TCP Server một cách dễ dàng
 */
class TcpListenerSample
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

        // Gắn đối tượng TcpListener vào port 9050 để lắng nghe
        TcpListener newsock = new TcpListener(9050);

        /*
         * Phương thức Start() kết nối socket đến EndPoint
         * để bắt đầu lắng nghe kết nối
         * (giống phương thức Bind() và Listen() ở lớp socket)
         */
        newsock.Start();

        /* 
         * Xuất ra câu thông báo chờ ở phía server
         * khi chưa có bất kỳ client nào kết nối đến
         */
        Console.WriteLine("Waiting for a client...");

        /*
         * Phương thức AcceptTcpClient() chờ kết nối TCP đến,
         * chấp nhận kết nối trên port 9050 và gán kết nối cho đối tượng TCPClient
         * (giống phương thức Accept() của socket)
         * 
         * Từ giờ, tất cả các truyền thông với thiết bị ở xa
         * được thực hiện bằng đối tượng TcpClient mới thay vì TcpListener,
         * do đó, lúc này, đối tượng TcpListener
         * có thể được dùng để chấp nhận kết nối khác
         */
        TcpClient client = newsock.AcceptTcpClient();

        /*
         * Phương thức GetStream() tạo ra luồng Stream
         * để gửi và nhận dữ liệu
         * 
         * Lớp NetworkStream được gán vào
         * để cung cấp các phương thức và thuộc tính
         * hỗ trợ gửi và nhận dữ liệu với máy ở xa,
         * Tất cả các thông tin liên lạc đều được thực hiện
         * bằng cách dùng phương thức Read() và Write()
         * 
         */
        NetworkStream ns = client.GetStream();

        // In câu chào ra màn hình của client
        string welcome = "Welcome to my test server";

        // Chuyển chuỗi câu chào ở trên thành byte
        data = Encoding.ASCII.GetBytes(welcome);

        /*
         * Phương thức Write() dùng để gửi dữ liệu đi,
         * yêu cầu mảng ở dạng byte
         * 
         * data.Length là số byte sau khi chuyển chuỗi sang byte
         * (VD: abc --> 3 byte)
         */
        ns.Write(data, 0, data.Length);

        /* 
         * Vòng lặp để nhận và gửi lại cho client
         * chính nội dung mà client đã gửi qua cho server
         */
        while (true)
        {
            // Tạo mảng data có 1024 byte để lưu trữ dữ liệu
            data = new byte[1024];

            // Dùng phương thức Read() để nhận dữ liệu do client gửi
            recv = ns.Read(data, 0, data.Length);

            // Nếu không nhận được gì từ client
            if (recv == 0)
                break;

            // Nếu nhận được dữ liệu từ client
            Console.Write("Tin nhan Client gui cho Server: ");

            /* 
             * Chuyển dữ liệu từ byte thành chuỗi
             * rồi in ra màn hình của server
             */
            Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));

            /*
             * Dùng phương thức Write() để gửi lại cho client
             * chính nội dung mà client đã gửi qua cho server
             */
            ns.Write(data, 0, recv);
        }

        // Đóng đối tượng NetworkStream 
        ns.Close();

        // Đóng đối tượng TcpClient
        client.Close();

        // Đóng đối tượng TcpListener
        newsock.Stop();

        Console.ReadKey();
    }
}