using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ViDu03
{
    // Khởi tạo IPEndPoint
    class Chuong01_ViDu03_KhoiTaoIPEndPoint
    {
        public static void IPEndPoint()
        {
            /*
             * Tạo một địa chỉ IP,
             * phương thức Parse() dùng để chuyển IP ở dạng chuỗi
             * thành một địa chỉ IP chuẩn
             */
            IPAddress taoIPAddress = IPAddress.Parse("192.168.1.18");

            /*
             * Đối tượng IPEndPoint được dùng để gắn kết các Socket
             * với các địa chỉ cục bộ hoặc các địa chỉ ở xa.
             * 
             * Truyền IPAddress và port vào cho hàm để khởi tạo IPEndPoint
             */
            IPEndPoint taoIPEndPoint = new IPEndPoint(taoIPAddress, 54321);

            // In ra màn hình địa chỉ IP và port
            Console.WriteLine("Dia chi IP va Port la: " + taoIPEndPoint);
        }

        static void Main(string[] args)
        {
            IPEndPoint();
            Console.ReadKey();
        }
    }
}
