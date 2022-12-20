using System;
using System.Net;

class AddressSample
{
    public static void Main()
    {
        // Tạo địa chỉ IP test1 192.168.1.18 (địa chỉ của máy đang dùng)
        IPAddress test1 = IPAddress.Parse("192.168.1.18");

        // Tạo địa chỉ IP test2 trả về địa chỉ IP lặp
        IPAddress test2 = IPAddress.Loopback;

        // Tạo địa chỉ IP test3 là địa chỉ quảng bá
        IPAddress test3 = IPAddress.Broadcast;

        // Tạo địa chỉ IP test4 là 0.0.0.0
        IPAddress test4 = IPAddress.Any;

        // Sử dụng khi máy không có interface (card) mạng
        IPAddress test5 = IPAddress.None;

        /*
         * Dùng phương thức GetHostEntry của lớp DNS
         * để lấy HostName và thông tin về host trả về cho IPHostEntry
         */
        IPHostEntry ihe = Dns.GetHostEntry(Dns.GetHostName());

        /*
         * Lấy địa chỉ IPAddress đầu tiên trong máy bằng AddressList[0]
         * trả về cho myself (địa chỉ local)
         */
        IPAddress myself = ihe.AddressList[0];

        // In ra địa chỉ local
        Console.WriteLine("The Local IP address is: {0}\n", myself.ToString());

        // Kiểm tra test2 có phải là địa chỉ loopback
        if (IPAddress.IsLoopback(test2))
            Console.WriteLine("The Loopback address is: {0}", test2.ToString());
        else
            Console.WriteLine("Error obtaining the loopback address");

        // So sánh myself (địa chỉ local) với test2 (địa chỉ loopback)
        if (myself == test2)
            Console.WriteLine("The loopback address is the same as local address.\n");
        else
            Console.WriteLine("The loopback address is not the local address.\n");

        Console.WriteLine("The test address is: {0}", test1.ToString());
        Console.WriteLine("Broadcast address: {0}", test3.ToString());
        Console.WriteLine("The ANY address is: {0}", test4.ToString());
        Console.WriteLine("The NONE address is: {0}", test5.ToString());

        Console.ReadKey();
    }
}