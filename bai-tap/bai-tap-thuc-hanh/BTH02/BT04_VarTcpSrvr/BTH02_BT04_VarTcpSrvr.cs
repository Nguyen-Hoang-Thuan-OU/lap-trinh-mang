// Chương trình Server nhận thông điệp kèm kích thước thông điệp

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace BT04_VarTcpSrvr
{
    class BTH02_BT04_VarTcpSrvr
    {
        /*
         * Lấy kích thước của thông điệp
         * và gắn nó vào đầu của thông điệp trước khi gửi,
         * kích thước này là một số interger 4 byte,
         * kích thước tối đa của mỗi thông điệp này là 65KB
         * (khi gửi sang client sẽ có gửi kèm kích thước)
         */
        private static int SendVarData(Socket s, byte[] data)
        {
            /*
             * Lưu tổng số byte dạng interger đã chuyển cho client
             * (có bao nhiêu byte dữ liệu đã được gửi đi)
             */
            int total = 0;

            /*
             * Tạo biến size có độ dài
             * bằng kích thước với data dạng interger,
             * lưu số byte dữ liệu mà server muốn gửi đi
             */
            int size = data.Length;

            /*
             * Lưu tổng số byte dạng interger còn lại phải chuyển,
             * sẽ giảm dần
             */
            int dataleft = size;

            // Tạo biến sent dạng interger để lưu những dữ liệu đã gửi
            int sent;

            // Tạo mảng để lưu dữ liệu
            byte[] datasize = new byte[4];

            /*
             * Dùng hàm GetBytes() của lớp BitConverter
             * để chuyển giá trị interger 4 byte (size) này
             * thành mảng các byte để chuyển qua client
             * cho client chuẩn bị một mảng byte để nhận dữ liệu
             */
            datasize = BitConverter.GetBytes(size);

            // Chuyển mảng byte dữ liệu chứa size sang client
            sent = s.Send(datasize);

            /*
             * Sau khi gửi kích thước thông điệp xong,
             * dùng vòng lặp để gửi phần chính của thông điệp đi,
             * lặp cho đến khi tất cả các byte đã được gửi
             */
            while (total < size)
            {
                /*
                 * Chuyển dữ liệu sang client
                 * và lưu lượng dữ liệu đã gửi đi
                 */
                sent = s.Send(data, total, dataleft, SocketFlags.None);

                // Tăng dần số dữ liệu đã gửi lên
                total += sent;

                // Số dữ liệu còn lại phải gửi, giảm dần xuống
                dataleft -= sent;
            }

            // Trả về số byte dữ liệu đã gửi
            return total;
        }

        /*
         * Hàm ReceiveVarData nhận 4 byte đầu tiên của thông điệp
         * và chuẩn bị vùng chứa dữ liệu, sau đó đến toàn bộ thông điệp
         * (đầu tiên nhận kích thước, sau đó chuyển kích thước
         * thành số nguyên rồi tạo ra mảng byte
         * bằng đúng kích thước của số nguyên đó để nhận dữ liệu)
         */
        private static byte[] ReceiveVarData(Socket s)
        {
            /*
             * Lưu tổng số byte đã nhận từ client
             * (có bao nhiêu byte dữ liệu đã nhận được)
             */
            int total = 0;

            // Tạo biến lưu những dữ liệu đã nhận
            int recv;

            /*
             * Tạo mảng để lưu kích thước mà client chuyển qua
             * (kích thước mà server sẽ nhận được)
             */
            byte[] datasize = new byte[4];

            /*
             * Nhận vào mảng datasize từ 0 --> 4 byte
             * (0 cuối cùng = SocketFlags.None)
             */
            recv = s.Receive(datasize, 0, 4, 0);

            /*
             * Dùng phương thức GetInt32() của lớp BitConverter
             * chuyển 4 byte đầu tiên của thông điệp
             * thành giá trị interger
             */
            int size = BitConverter.ToInt32(datasize, 0);

            // Tạo biến dataleft
            int dataleft = size;

            // Tạo ra mảng bằng với kích thước của size
            byte[] data = new byte[size];

            // Vòng lặp để nhận dữ liệu
            while (total < size)
            {
                //Nhận dữ liệu từ client và lưu lượng dữ liệu đã nhận
                recv = s.Receive(data, total, dataleft, 0);

                // Nếu không còn gì để nhận
                if (recv == 0)
                {
                    data = Encoding.ASCII.GetBytes("exit");
                    break;
                }

                // Tăng dần số dữ liệu đã nhận lên
                total += recv;

                // Số dữ liệu còn lại phải nhận, giảm dần xuống
                dataleft -= recv;
            }

            // Trả về số byte dữ liệu đã nhận
            return data;
        }

        static void Main(string[] args)
        {
            // Tạo ra mảng data
            byte[] data = new byte[1024];

            // Tạo IPEndPoint bằng card mạng bất kỳ và port 9050
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9050);

            // Tạo ra socket ở phía server
            Socket newsock = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream, ProtocolType.Tcp);

            // Kết nối IPEndPoint với socket
            newsock.Bind(ipep);

            // Lắng kết nối từ client, tối đa 10 kết nối
            newsock.Listen(10);

            // In ra câu thông báo ở phía server
            Console.WriteLine("Dang doi ket noi tu client..");

            // Tạo ra socket để chấp nhận kết nối từ client
            Socket client = newsock.Accept();

            // Tạo IPEndPoint để lấy thông tin của client kết nối đến
            IPEndPoint newclient = (IPEndPoint)client.RemoteEndPoint;

            // In thông tin IP và port của client ra màn hình server
            Console.WriteLine("Da ket noi voi {0} tai port {1}",
                                newclient.Address, newclient.Port);

            // Tạo ra chuỗi chào mừng client
            string welcome = "---CHAO MUNG DEN VOI TEST SERVER---";

            // Chuyển chuỗi thành byte
            data = Encoding.ASCII.GetBytes(welcome);

            /*
             * Dùng hàm SendVarData
             * để chuyển chuỗi chào mừng sang client
             */
            int sent = SendVarData(client, data);

            /*
             * Dùng vòng lặp để nhận và xuất ra
             * năm thông điệp riêng biệt từ client
             */
            for (int i = 0; i < 5; i++)
            {
                // Dùng hàm ReceiveVarData để nhận dữ liệu từ client
                data = ReceiveVarData(client);

                // In thông điệp ra màn hình của server
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
}
