using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace ViDu06
{
    class Chuong01_ViDu06_TaoIPHostEntry
    {
        private static void taoIPHostEntry()
        {
            IPHostEntry iphe1, iphe2, iphe3;

            IPAddress diaChiIP = IPAddress.Parse("127.0.0.1");
            iphe1 = Dns.GetHostEntry("localhost");
            iphe2 = Dns.GetHostEntry("172.0.0.1");
            iphe3 = Dns.GetHostEntry(diaChiIP);

            Console.WriteLine(iphe1.HostName);
            Console.WriteLine(iphe2.HostName);
            Console.WriteLine(iphe3.HostName);
        }

        static void Main(string[] args)
        {
            taoIPHostEntry();
            Console.ReadKey();
        }
    }
}
