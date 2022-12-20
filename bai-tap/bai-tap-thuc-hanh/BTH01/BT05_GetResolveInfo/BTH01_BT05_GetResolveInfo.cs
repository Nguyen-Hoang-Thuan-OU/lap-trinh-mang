using System;
using System.Net;

class GetResolveInfo
{
    public static void Main(string[] argv)
    {
        // Kiểm tra xem người dùng có truyền chuỗi vào không
        if (argv.Length != 1)
        {
            Console.WriteLine("Usage: GetResolveInfo address");
            return;
        }

        /*
         * Khi truyền vào một hostname thì hàm Resolve sẽ thực hiện phân giải,
         * lấy những thông tin trong hostname đó đưa vào IPHostEntry
         */
        IPHostEntry iphe = Dns.Resolve(argv[0]);
        // IPHostEntry iphe = Dns.GetHostEntry(argv[0]);

        // Xuất thông báo về thông tin của hostname
        Console.WriteLine("Information for {0}", argv[0]);

        // Xuất ra tên máy chủ của host
        Console.WriteLine("Host name: {0}", iphe.HostName);

        /*
         * Chạy vòng lặp in ra danh sách các bí danh (alias) được liên kết với host
         * (Do host có thể có nhiều alias)
         */
        foreach (string alias in iphe.Aliases)
        {
            Console.WriteLine("Alias: {0}", alias);
        }

        /*
         * Chạy vòng lặp in ra từng địa chỉ ip của host
         * (Do host có thể có nhiều card mạng)
         */
        foreach (IPAddress address in iphe.AddressList)
        {
            Console.WriteLine("Address: {0}", address);
        }

        Console.ReadKey();
    }
}
