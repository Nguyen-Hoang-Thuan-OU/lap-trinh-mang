using System;
using System.Net;
using System.Text;

class BTH04_BT04_BinaryNetworkByteOrder
{
    public static void Main()
    {
        // Tạo ra các biến để với các kiểu dữ liệu khác nhau
        short test1 = 45;
        int test2 = 314159;
        long test3 = -123456789033452;

        // Tạo mảng data có 1024 byte để lưu trữ dữ liệu
        byte[] data = new byte[1024];

        // Tạo biến kiểu chuỗi
        string output;

        // Chuyển dữ liệu thành dạng byte và dạng chuỗi
        data = BitConverter.GetBytes(test1);
        output = BitConverter.ToString(data);
        Console.WriteLine("test1 = {0}, string = {1}", test1, output);

        data = BitConverter.GetBytes(test2);
        output = BitConverter.ToString(data);
        Console.WriteLine("test2 = {0}, string = {1}", test2, output);

        data = BitConverter.GetBytes(test3);
        output = BitConverter.ToString(data);
        Console.WriteLine("test3 = {0}, string = {1}", test3, output);

        // Sắp xếp lại thứ tự của chuỗi
        short test1b = IPAddress.HostToNetworkOrder(test1);
        data = BitConverter.GetBytes(test1b);
        output = BitConverter.ToString(data);
        Console.WriteLine("test1 = {0}, nbo = {1}", test1b, output);

        int test2b = IPAddress.HostToNetworkOrder(test2);
        data = BitConverter.GetBytes(test2b);
        output = BitConverter.ToString(data);
        Console.WriteLine("test2 = {0}, nbo = {1}", test2b, output);

        long test3b = IPAddress.HostToNetworkOrder(test3);
        data = BitConverter.GetBytes(test3b);
        output = BitConverter.ToString(data);
        Console.WriteLine("test3 = {0}, nbo = {1}", test3b, output);

        Console.ReadKey();
    }
}