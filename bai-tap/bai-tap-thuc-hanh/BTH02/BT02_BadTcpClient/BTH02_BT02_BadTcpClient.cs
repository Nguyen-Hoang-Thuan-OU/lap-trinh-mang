// Chương Trình TCP Client kém hiệu quả (Bad TCP Client)

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class BadTcpClient
{
    public static void Main()
    {
        /*
         * Tạo mảng data có 1024 byte
         * (bộ đệm để gởi và nhận dữ liệu)
         */
        byte[] data = new byte[1024];

        // Tạo biến để client nhập nội dung
        string stringData;

        /*
         * Tạo IPEndPoint với IPAddress và port 9050
         * (do là máy cục bộ nên IPAddress là 127.0.0.1)
         */
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        // Tạo socket ở phía client kết nối với server thông qua IPEndPoint
        Socket server = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream, ProtocolType.Tcp);

        // Thực hiện bắt lỗi nếu có lỗi xảy ra
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
            Console.WriteLine("Khong the ket noi voi server!");
            Console.WriteLine(e.ToString());
            return;
        }

        /*
         * Số byte dữ liệu mà client thật sự nhận từ server,
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

        /*
         * Client lập tức chuyển thông điệp thành byte
         * và gửi qua cho server mà không cần nhận lại
         */
        server.Send(Encoding.ASCII.GetBytes("Thong diep 1"));
        server.Send(Encoding.ASCII.GetBytes("Thong diep 2"));
        server.Send(Encoding.ASCII.GetBytes("Thong diep 3"));
        server.Send(Encoding.ASCII.GetBytes("Thong diep 4"));
        server.Send(Encoding.ASCII.GetBytes("Thong diep 5"));

        /*
         * Client thực hiện xong năm phương thức Send()
         * sẽ đóng kết nối với Server
         */
        Console.WriteLine("Dang ngat ket noi voi server...");

        // Dừng kết nối, không cho phép nhận và gởi dữ liệu
        server.Shutdown(SocketShutdown.Both);

        // Đóng socket giao tiếp với server
        server.Close();

        Console.ReadKey();
    }
}