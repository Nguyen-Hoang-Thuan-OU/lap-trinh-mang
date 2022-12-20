using System;
using System.Net;

class GetDNSHostInfo
{

    public static void Main(string[] argv)
    {
        /* 
         * Kiểm tra xem người dùng có truyền chuỗi vào không,
         * nếu truyền vào khoảng trắng sẽ báo lỗi
         */
        if (argv.Length != 1)
        {
            // Xuất ra thông báo nếu người dùng không truyền chuỗi vào
            Console.WriteLine("Usage: GetDNSHostInfo hostname");
            return;
        }

        // Trả về thông tin DNS (Hostname, IP, alias) của một trạm
        IPHostEntry results = Dns.GetHostByName(argv[0]);
        // IPHostEntry results = Dns.GetHostEntry(argv[0]);

        // In ra tên máy chủ của host
        Console.WriteLine("Host name: {0}", results.HostName);

        // Duyệt và in ra toàn bộ các bí danh liên kết với host
        foreach (string alias in results.Aliases)
        {
            Console.WriteLine("Alias: {0}", alias);
        }

        /*
         * Duyệt và in ra toàn bộ danh sách các địa chỉ IP liên kết với host,
         * in địa chỉ ra ở dạng chuỗi ở dạng ký pháp có dấu chấm
         */
        foreach (IPAddress address in results.AddressList)
        {
            Console.WriteLine("Address: {0}", address.ToString());
        }

        Console.ReadKey();
    }
}