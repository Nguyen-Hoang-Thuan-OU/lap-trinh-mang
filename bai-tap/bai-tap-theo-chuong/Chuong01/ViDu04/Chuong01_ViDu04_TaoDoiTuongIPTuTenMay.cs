using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ViDu04
{
    class Chuong01_ViDu04_TaoDoiTuongIPTuTenMay
    {
        public static void taoEndPointTuTenMay()
        {
            /* 
             * Tạo đối tượng IP từ tên của máy
             * thông qua phương thức tĩnh Dns.GetHostAddresses của lớp DNS
             * (lớp DNS sử dụng các hàm dùng để thực hiện phân giải tên, địa chỉ,...)
             * 
             * [0]: lấy IP của card mạng đầu tiên
            */
            IPAddress taoIPAddress = Dns.GetHostAddresses("www.google.com")[0];

            // Truyền IPAddress và port vào cho hàm để khởi tạo IPEndPoint
            IPEndPoint taoIPEndPoint = new IPEndPoint(taoIPAddress, 54321);

            // In ra địa chỉ IPv6 của card mạng đầu tiên của host
            Console.WriteLine("Dia chi IPv6 cua card mang dau tien va port: " + taoIPEndPoint);
        }

        static void Main(string[] args)
        {
            taoEndPointTuTenMay();
            Console.ReadKey();
        }
    }
}
