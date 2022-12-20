// Chương trình Client gửi và nhận dữ liệu với kích thước cố định

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class FixedTcpClient
{
    // Tạo phương thức gửi dữ liệu
    private static int SendData(Socket s, byte[] data)
    {
        int total = 0;
        int size = data.Length;
        int dataleft = size;
        int sent;
        while (total < size)
        {
            sent = s.Send(data, total, dataleft, SocketFlags.None);
            total += sent;
            dataleft -= sent;
        }
        return total;
    }

    // Tạo phương thức nhận dữ liệu
    private static byte[] ReceiveData(Socket s, int size)
    {
        int total = 0;
        int dataleft = size;
        byte[] data = new byte[size];
        int recv;
        while (total < size)
        {
            recv = s.Receive(data, total, dataleft, 0);
            if (recv == 0)
            {
                data = Encoding.ASCII.GetBytes("exit");
                break;
            }
            total += recv;
            dataleft -= recv;
        }
        return data;
    }
    public static void Main()
    {
        // Tạo mảng data có 1024 byte
        byte[] data = new byte[1024];

        // Tạo biến sent để lưu những dữ liệu đã gửi
        int sent;


        /*
         * Tạo IPEndPoint với IPAddress và port 9050
         * (do là máy cục bộ nên IPAddress là 127.0.0.1)
         */
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        // Tạo socket để giao tiếp với server
        Socket server = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream, ProtocolType.Tcp);
        // Kiểm tra kết nối
        try
        {
            // Kết nối đến server
            server.Connect(ipep);
        }
        catch (SocketException e)
        {
            /*
             * In ra thông báo ở dạng chuỗi
             * khi không kết nối được với server
             */
            Console.WriteLine("Khong the ket noi den server!");
            Console.WriteLine(e.ToString());
            return;
        }

        // Nhận câu chào từ server và chứa trong biến recv
        int recv = server.Receive(data);

        // Chuyển chuỗi nhận được sang dạng chuỗi
        string stringData = Encoding.ASCII.GetString(data, 0, recv);

        // In chuỗi nhận được ra màn hình của client
        Console.WriteLine(stringData);

        /*
         * Client lập tức chuyển thông điệp thành byte
         * và gửi qua cho server mà không cần nhận lại
         * 
         * Tất cả các thông điệp đều phải cùng kích thước,
         * nếu không cùng thì phải thêm phần đệm vào
         */
        sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 1"));
        sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 2"));
        sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 3"));
        sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 4"));
        sent = SendData(server, Encoding.ASCII.GetBytes("Thong diep 5"));

        /*
         * Client thực hiện xong năm phương thức SendData()
         * sẽ đóng kết nối với Server
         */
        Console.WriteLine("Dang ngat ket noi voi server...");

        // Dừng kết nối, không cho phép nhận và gởi dữ liệu
        server.Shutdown(SocketShutdown.Both);

        // Đóng socket giao tiếp với server
        server.Close();
    }
}