using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ViDu05
{
    class Chuong01_ViDu05_LayTatCaDiaChiIPBangLopDNS
    {
        private static void hienDiaChiIP()
        {
            // Lấy tất cả địa chỉ IP (IPv4 và IPv6) của host
            IPAddress[] mangDanhSachDiaChiIP = Dns.GetHostAddresses("google.com");

            // Cách 1
            //foreach (IPAddress tungDiaChiIP in mangDanhSachDiaChiIP)
            //    Console.WriteLine(diaChiIP.ToString());

            // Cách 2
            for (int i = 0; i < mangDanhSachDiaChiIP.Length; i++)
            {
                Console.WriteLine(mangDanhSachDiaChiIP[i].ToString());
            }
        }

        static void Main(string[] args)
        {
            hienDiaChiIP();
            Console.ReadKey();
        }
    }
}
