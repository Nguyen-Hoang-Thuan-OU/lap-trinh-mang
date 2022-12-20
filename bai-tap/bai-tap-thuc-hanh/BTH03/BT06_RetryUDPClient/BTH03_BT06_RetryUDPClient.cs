// Chương trình UDP Client điều khiển việc truyền lại các gói tin

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class RetryUDPClient
{
    // Tạo mảng data gồm 1024 phần tử
    private byte[] data = new byte[1024];

    // Tạo đối tượng IPEndpoint để lắng nghe yêu cầu trên tất cả các card mạng
    private static IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);

    // Tạo đối tượng EndPoint chứa địa chỉ IP và port của thiết bị ở xa 
    private static EndPoint Remote = (EndPoint)sender;

    /*
     * Gửi, nhận dữ liệu đến thiết bị ở xa
     * 
     * Phương thức có thể được dùng bất cứ đâu trong chương trình
     * nơi có dữ liệu được gửi tới thiết bị ở xa và chờ câu trả lời
     */
    private int SndRcvData(Socket s, byte[] message, EndPoint rmtdevice)
    {
        // Tạo giá trị độ dài dữ liệu nhận được
        int recv;

        // Gán số lần thử lại = 0
        int retry = 0;

        while (true)
        {
            // Xuất thông báo số lần thử lại
            Console.WriteLine("Truyen lai lan thu #{0}", retry);

            try
            {
                // 1. Gửi dữ liệu đến thiết bị ở xa bằng phương thức SendTo()
                s.SendTo(message, message.Length, SocketFlags.None, rmtdevice);

                // Tạo mảng data 1024 byte
                data = new byte[1024];

                /* 
                 * 2. Sau khi gửi thông điệp, phương thức SndRcvData()
                 * sẽ block ở phương thức ReceiveFrom() và chờ thông điệp trả về
                 */
                recv = s.ReceiveFrom(data, ref Remote);
            }

            /* 
             * Nếu không có thông điệp trả về
             * khi kết thúc giá trị ReceiveTimeout
             * sẽ tiến hành xử lý ngoại lệ
             */
            catch (SocketException)
            {
                // Giá trị recv được thiết lập về 0
                recv = 0;
            }

            // Sau khối try-catch, giá trị recv sẽ được kiểm tra

            /* 
             * 3. Kiểm tra lại giá trị recv trong khoảng giá trị ReceiveTimeout,
             * dương nghĩa là thông điệp đã được nhận thành công
             */
            if (recv > 0)

                /*
                 * phương thức SndRcvData() sẽ đặt dữ liệu vào mảng byte
                 * đã được định nghĩa trong lớp,
                 * thoát khỏi phương thức với dữ liệu nhận
                 * và trả về số byte kích thước của dữ liệu
                 */
                return recv;

            /* 
             * 4. Nếu không nhận được câu trả lời, thông điệp nào
             * trong khoảng thời gian time-out
             * (biến recv trả về là số 0)
             */
            else
            {
                // Tăng biến đếm thử retry lên 1 đơn vị, tăng tối đa 3 lần
                retry++;

                /*
                 * 5. Kiểm tra biến đếm thử (retry),
                 * nếu retry nhỏ hơn số lần đã định nghĩa trước (giá trị tối đa)
                 * thì toàn bộ quá trình sẽ được lặp lại
                 * và bắt đầu gửi lại thông điệp (bắt đầu lại bước 1)
                 */
                if (retry > 4)

                    /* 
                     * Phương thức SndRcvData() sẽ trả về 0
                     * nếu đã bằng số lần đã định nghĩa trước (giá trị tối đa)
                     */
                    return 0;
            }
        }
    }

    /*
     * Ngăn cản mất gói tin bằng cơ chế hồi báo,
     * cho thiết bị gửi biết đã nhận thành công hay chưa.
     * 
     * Nếu gói tin hồi báo không được nhận
     * trong một khoảng thời gian nào đó
     * thì thiết bị nhận sẽ truyền lại các gói tin
     */
    public RetryUDPClient()
    {
        // Khai báo chuỗi để nhập và nhận dữ liệu
        string input, stringData;

        // Tạo biến recv lưu giá trị độ dài dữ liệu nhận được
        int recv;

        // Tạo đối tượng IPEndpoint với địa localhost và port 9050
        IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

        // Tạo socket UDP
        Socket server = new Socket(AddressFamily.InterNetwork,
                                    SocketType.Dgram, ProtocolType.Udp);

        /*
         * ReceiveTimeout thiết lập một khoảng thời gian ban đầu = 0
         * cho biết nó sẽ chờ dữ liệu mãi mãi
         * (khoảng thời gian mà socket sẽ chờ dữ liệu đến từ server)
         * 
         * Phương thức GetSocketOption() trả về một đối tượng Object,
         * vì thế nó phải được ép kiểu thành kiểu interger
         */
        int sockopt = (int)server.GetSocketOption(SocketOptionLevel.Socket,
                                                    SocketOptionName.ReceiveTimeout);

        // Lấy và hiển thị giá trị ReceiveTimeout ban đầu
        Console.WriteLine("Gia tri timeout mac dinh: {0}", sockopt);

        /*
         * Dùng phương thức SetSocketOpition()
         * để thiết lập lại giá trị ReceiveTimeout thành 3 giây,
         * hàm ReceiveFrom() sẽ chờ để đọc dữ liệu mà server gửi
         * trong tối đa 3 giây,
         * sau khoảng thời gian này nếu không có dữ liệu để đọc
         * thì nó sẽ phát sinh ra biệt lệ
         */
        server.SetSocketOption(SocketOptionLevel.Socket,
                                SocketOptionName.ReceiveTimeout, 3000);

        /*
         * Tạo lại một khoảng thời gian chờ phản hồi từ server
         * bằng giá trị ReceiveTimeout
         */
        sockopt = (int)server.GetSocketOption(SocketOptionLevel.Socket,
                                                SocketOptionName.ReceiveTimeout);

        // Lấy và hiển thị giá trị ReceiveTimeout mới
        Console.WriteLine("Gia tri timeout moi: {0}", sockopt);

        // Tạo chuỗi hỏi thăm
        string welcome = "Hello, are you there?";

        // Chuyển chuỗi hỏi thăm thành mảng byte
        data = Encoding.ASCII.GetBytes(welcome);

        // Tiến hành gửi sang server và nhận dữ liệu về
        recv = SndRcvData(server, data, ipep);

        // Nếu nhận được thông điệp từ server
        if (recv > 0)
        {
            // Đọc và xuất chuỗi vừa nhận được
            stringData = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine(stringData);
        }
        else
        {
            // In ra câu thông báo nếu không nhận được thông điệp từ server
            Console.WriteLine("Khong the lien lac voi thiet bi o xa");
            return;
        }

        // Vòng lặp để gửi và nhận dữ liệu
        while (true)
        {
            // Nhập chuỗi từ bàn phím
            input = Console.ReadLine();

            // Nếu gặp chuỗi "exit" sẽ thoát vòng lặp và kết thúc chương trình
            if (input == "exit")
                break;

            // Gửi chuỗi vừa nhập sang server
            recv = SndRcvData(server, Encoding.ASCII.GetBytes(input), ipep);
            
            // Nếu server có gửi lại dữ liệu
            if (recv > 0)
            {
                // Chuyển mảng dữ liệu thành chuỗi và in ra màn hình
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);
            }
            else
                // In ra thông báo nếu server không gửi lại dữ liệu
                Console.WriteLine("Khong nhan duoc cau tra loi");
        }

        // In ra thông báo ngắt kết nối với server
        Console.WriteLine("Dang dong client");

        // Đóng socket
        server.Close();
    }

    public static void Main()
    {
        // Tạo mới một đối tượng từ lớp RetryUDPClient
        RetryUDPClient ruc = new RetryUDPClient();

        Console.ReadKey();
    }
}