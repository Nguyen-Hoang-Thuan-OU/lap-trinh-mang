// Chương trình Client gửi thông điệp kèm kích thước thông điệp

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace BT04_VarTcpClient
{
    class BTH02_BT04_VarTcpClient
    {
        // Hàm SendVarData có kèm kích thước thông điệp
        private static int SendVarData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = s.Send(datasize);
            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }
            return total;
        }

        // Hàm ReceiveVarData để nhận và chuẩn bị vùng chứa dữ liệu
        private static byte[] ReceiveVarData(Socket s)
        {
            int total = 0;
            int recv;
            byte[] datasize = new byte[4];
            recv = s.Receive(datasize, 0, 4, 0);
            int size = BitConverter.ToInt32(datasize, 0);
            int dataleft = size;
            byte[] data = new byte[size];

            while (total < size)
            {
                recv = s.Receive(data, total, dataleft, 0);
                if (recv == 0)
                {
                    data = Encoding.ASCII.GetBytes("exit ");
                    break;
                }
                total += recv;
                dataleft -= recv;
            }
            return data;
        }

        static void Main(string[] args)
        {
            // Tạo mảng byte
            byte[] data = new byte[1024];

            // Tạo biến sent để gửi dữ liệu sang server
            int sent;

            // Tạo IPEndPoint để kết nối với server
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

            // Tạo Socket để kết nối với server
            Socket server = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // Kết nối với server
                server.Connect(ipep);
            }
            catch (SocketException e)
            {
                // In ra thông báo ở màn hình của client
                Console.WriteLine("Khong the ket noi voi server!");
                Console.WriteLine(e.ToString());
                return;
            }

            // Dùng hàm ReceiveVarData để nhận câu chào của server
            data = ReceiveVarData(server);

            // Chuyển câu chào từ byte thành chuỗi
            string stringData = Encoding.ASCII.GetString(data);

            // In câu chào ra màn hình của client
            Console.WriteLine(stringData);

            // Tạo ra các biến thông điệp để gửi sang server
            string thongDiep1 = "Day la thong diep dau tien";
            string thongDiep2 = "Thong diep ngan";
            string thongDiep3 = "Thong diep nay dai hon cac thong diep khac. Con cáo nâu nhanh nhẹn nhảy qua con chó lười biếng.";
            string thongDiep4 = "a";
            string thongDiep5 = "Thong diep cuoi cung";

            // Dùng hàm SendVarData để gửi dữ liệu sang server
            sent = SendVarData(server, Encoding.ASCII.GetBytes(thongDiep1));
            sent = SendVarData(server, Encoding.ASCII.GetBytes(thongDiep2));
            sent = SendVarData(server, Encoding.ASCII.GetBytes(thongDiep3));
            sent = SendVarData(server, Encoding.ASCII.GetBytes(thongDiep4));
            sent = SendVarData(server, Encoding.ASCII.GetBytes(thongDiep5));

            /*
             * Client thực hiện xong năm phương thức SendVarData()
             * sẽ đóng kết nối với Server
             */
            Console.WriteLine("Dang ngat ket noi voi server...");

            //Dừng kết nối, không cho phép nhận và gởi dữ liệu
            server.Shutdown(SocketShutdown.Both);

            //Đóng Socket
            server.Close();
        }
    }
}
