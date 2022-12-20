using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ViDu02
{
    // Chuyển địa chỉ hiện hành (số long) thành IPAddress
    class Chuong01_ViDu02_ChuyenDiaChiHienHanhThanhMang
    {
        public static void chuyenDoi()
        {
            // Khởi tạo một địa chỉ IP bằng kiểu long
            IPAddress diaChiIPHienHanh = new IPAddress(696969696);

            // Cách 1

            // Tạo mảng mangBonByte gồm 4 byte
            Byte[] mangBonByte = new Byte[4];

            /*
             * Dùng phương thức GetAddressBytes
             * để lấy địa chỉ dạng byte gán cho mảng mangBonByte
             */
            mangBonByte = diaChiIPHienHanh.GetAddressBytes();

            // Xuất ra các phần tử của mảng mangBonByte
            Console.WriteLine("Dia chi IP la: "
                                + mangBonByte[0] + "."
                                + mangBonByte[1] + "."
                                + mangBonByte[2] + "."
                                + mangBonByte[3] + ".");

            // Cách 2
            Console.WriteLine("Dia chi IP hien hanh la: " + diaChiIPHienHanh);
        }

        static void Main(string[] args)
        {
            chuyenDoi();
            Console.ReadKey();
        }
    }
}
