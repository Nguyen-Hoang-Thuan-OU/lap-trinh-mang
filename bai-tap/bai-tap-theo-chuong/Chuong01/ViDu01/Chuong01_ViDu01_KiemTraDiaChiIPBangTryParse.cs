using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ViDu01
{
    // Kiểm tra địa chỉ có phải là địa chỉ IP bằng hàm TryParse
    class Chuong01_ViDu01_KiemTraDiaChiIPBangTryParse
    {
        public static void kiemTra()
        {
            IPAddress diaChiIP;

            // Truyền chuỗi vào
            String diaChiIP1 = "192.168.1.18";
            String diaChiIP2 = "4444.4444.4444.4444";

            /*
             * Phương thức TryParse(String, Int32)
             * dùng để kiểm tra xem một địa chỉ IP ở dạng chuỗi
             * có đúng là địa chỉ hợp lệ hay không, phải = true
             * 
             * diaChiIP1, diaChiIP2 là dữ liệu cần chuyển đổi
             * diaChiIP là biến chứa kết quả
             */
            Console.WriteLine(IPAddress.TryParse(diaChiIP1, out diaChiIP));
            Console.WriteLine(IPAddress.TryParse(diaChiIP2, out diaChiIP).ToString());
        }

        static void Main(string[] args)
        {
            kiemTra();
            Console.ReadKey();
        }
    }
}
