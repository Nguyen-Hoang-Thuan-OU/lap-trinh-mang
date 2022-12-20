// Chương trình Server gửi và nhận dữ liệu với kích thước cố định

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class FixedTcpSrvr
{
    /*
     * Tạo hàm gửi dữ liệu,
     * đính kèm socket của client và dữ liệu
     * mà server muốn truyền vào
     */
    private static int SendData(Socket s, byte[] data)
    {
        /*
         * Tổng số byte có trong mảng data (bộ đệm),
         * dùng để kiểm tra xem có bao nhiêu byte dữ liệu
         * đã được gửi đi, ban đầu = 0
         */
        int total = 0;

        /*
         * Tạo biến size có độ dài bằng kích thước với data,
         * lưu số byte dữ liệu mà server muốn gửi đi
         */
        int size = data.Length;

        /*
         * Số dữ liệu còn lại phải gửi,
         * bằng với size (data) ban đầu
         * (vì size cần phải là một số cố định để so sánh
         * nên phải tạo ra một bản sao để thực hiện vòng lặp)
         */
        int dataleft = size;

        // Tạo biến sent để lưu những dữ liệu đã gửi
        int sent;

        /*
         * Vòng lặp kiểm tra số byte thực sự đã gửi
         * với kích thước cố định
         * 
         * Vẫn tiếp tục gửi
         * nếu số byte dữ liệu đã gửi < số byte dữ liệu muốn gửi đi
         */
        while (total < size)
        {
            /*
             * Dùng hàm Send() gửi dữ liệu sang client
             * và gán cho biến sent lưu lượng dữ liệu đã gửi đi
             */
            sent = s.Send(data, total, dataleft, SocketFlags.None);

            /*
             * Tăng dần số dữ liệu đã gửi lên
             * (total tăng bao nhiêu là đã gửi được bấy nhiêu)
             */
            total += sent;

            // Số dữ liệu còn lại phải gửi, giảm dần xuống
            dataleft -= sent;
        }

        // Trả về số byte dữ liệu đã gửi
        return total;
    }

    /*
     * Phương thức ReceiveData() sẽ nhận và đọc dữ liệu
     * với đối số được truyền vào là socket của client
     * và size là kích thước số byte mà client sẽ gửi
     * để server chờ nhận dữ liệu từ client
     * (bên client sẽ gửi size cho server
     * để server tạo ra bộ đệm đủ chứa nội dung do client gửi
     * để tránh hiện tượng tràn dữ liệu)
     */
    private static byte[] ReceiveData(Socket s, int size)
    {
        /*
         * Số byte dữ liệu đã được gửi đi
         * (số byte mà server đã nhận được)
         */
        int total = 0;

        /*
         * Số dữ liệu còn lại phải gửi,
         * bằng với size (data) ban đầu
         */
        int dataleft = size;

        /*
         * Sau khi đã có được thông tin size từ client
         * sẽ tạo ra mảng byte để nhận dữ liệu
         */
        byte[] data = new byte[size];

        // Tạo biến lưu những dữ liệu đã nhận
        int recv;

        /*
         * Dùng vòng lặp gọi phương thức Receive()
         * để nhận được toàn bộ dữ liệu mong muốn
         * 
         * Nếu số byte thực sự đọc được
         * còn nhỏ hơn số byte truyền vào phương thức ReceiveData()
         * thì vòng lặp sẽ tiếp tục cho đến khi số byte đọc được
         * đúng bằng kích thước yêu cầu
         */
        while (total < size)
        {
            /*
             * Dùng hàm Receive() gửi dữ liệu sang client
             * và gán cho biến sent lưu lượng dữ liệu đã gửi đi
             */
            recv = s.Receive(data, total, dataleft, 0);

            // Nếu không còn gì để nhận
            if (recv == 0)
            {
                data = Encoding.ASCII.GetBytes("exit");
                break;
            }

            /*
             * Tăng dần số dữ liệu đã nhận lên
             * (total tăng bao nhiêu là đã nhận được bấy nhiêu)
             */
            total += recv;

            // Số dữ liệu còn lại phải nhận, giảm dần xuống
            dataleft -= recv;
        }

        // Trả về số byte dữ liệu đã nhận
        return data;
    }


    public static void Main()
    {
        // Tạo mảng data có 1024 byte
        byte[] data = new byte[1024];

        /*
         * Tạo IPEndPoint ở phía server và chấp nhận kết nối
         * trên bất kỳ card mạng nào với port 9050
         */
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);

        // Tạo mới một socket ở phía server
        Socket newsock = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Stream, ProtocolType.Tcp);

        // Kết nối IPEndPoint với socket
        newsock.Bind(ipep);

        // Lắng nghe kết nối từ client, tối đa 10 kết nối
        newsock.Listen(10);

        /* 
         * Xuất ra câu thông báo
         * khi client chưa được khởi chạy (chưa kết nối)
         */
        Console.WriteLine("Dang doi ket noi tu client...");

        /*
         * Sau khi socket ở server chấp nhận kết nối
         * sẽ tạo ra socket client, server giao tiếp với client
         * thông qua socket (kênh ảo) này
         */
        Socket client = newsock.Accept();

        // Lấy thông tin IPEndPoint (IP và port) của client
        IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;

        // Xuất thông tin IPEndPoint của client
        Console.WriteLine("Da ket noi voi {0} tai port {1}",
                            newclient.Address, newclient.Port);

        /*
         * Server tạo ra chuỗi chào mừng client
         * ngay khi client vừa kết nối đến
         */
        string welcome = "---CHAO MUNG DEN VOI TEST SERVER---";

        /* 
         * Chuyển chuỗi chào mừng thành mảng byte
         * vì hàm Send() bên dưới nhận giá trị là một mảng byte
         */
        data = Encoding.ASCII.GetBytes(welcome);

        // Dùng hàm SendData() để gửi thông điệp chào mừng đến client
        int sent = SendData(client, data);

        /*
         * Dùng vòng lặp để cố gắng nhận và xuất ra
         * năm thông điệp riêng biệt từ client
         */
        for (int i = 0; i < 5; i++)
        {
            /*
             * Dùng hàm ReceiveData() nhận mảng byte từ client
             * với độ dài kích thước cố định là 12 byte
             */
            data = ReceiveData(client, 12);

            // Chuyển thông điệp từ byte sang chuỗi để xuất ra
            Console.WriteLine(Encoding.ASCII.GetString(data));
        }

        // Ngắt kết nối với client khi đã nhận thông điệp quá 5 lần
        Console.WriteLine("Da ngat ket noi voi {0}", newclient.Address);

        // Đóng socket giao tiếp với client
        client.Close();

        // Đóng socket thực hiện listen ở phía server
        newsock.Close();

        Console.ReadKey();
    }
}