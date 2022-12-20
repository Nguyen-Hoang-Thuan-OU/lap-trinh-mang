using System;
using System.Net;

class IPEndPointSample
{
    public static void Main()
    {
        // Tạo một đối tượng IPAddress từ chuỗi địa chỉ IP
        IPAddress test1 = IPAddress.Parse("192.168.1.1");

        /* 
         * Tạo một đối tượng IPendpoint từ IPAddress ở trên
         * với địa chỉ cổng (port) 8000
         */
        IPEndPoint ie = new IPEndPoint(test1, 8000);

        // In ra IPEndPoint (cả địa chỉ IP và port) ở dạng chuỗi
        Console.WriteLine("The IPEndPoint is: {0}", ie.ToString());

        // In tách biệt địa chỉ IP và port ở dạng chuỗi
        Console.WriteLine("The address is: {0}, and the port is: {1}",
                                    ie.Address, ie.Port);

        // In ra phân loại của đối tượng IPEndPoint (là IPv4 hay IPv6)
        Console.WriteLine("The AddressFamily is: {0}\n", ie.AddressFamily);

        // In ra địa chỉ port nhỏ nhất, dùng phương thức tĩnh của IPEndPoint
        Console.WriteLine("The min port number is: {0}", IPEndPoint.MinPort);

        // In ra địa chỉ port lớn nhất, dùng phương thức tĩnh của IPEndPoint
        Console.WriteLine("The max port number is: {0}\n", IPEndPoint.MaxPort);

        // Thay đổi địa chỉ port 8000 của đối tượng IPEndPoint trên thành 80
        ie.Port = 80;

        /*
         * In ra địa chỉ đầy đủ (IP và port) của đối tượng IPEndPoint
         * sau khi đã thay đổi port thành 80
         */
        Console.WriteLine("The changed IPEndPoint value is: {0} ", ie.ToString());

        /*
         * Dùng Serialize để sắp xếp lại IPEndPoint theo thứ tự của SocketAddress
         */
        SocketAddress sa = ie.Serialize();

        // In ra địa chỉ của đối tượng SocketAddress trên
        Console.WriteLine("The SocketAddress is: {0}", sa.ToString());

        Console.ReadKey();
    }
}