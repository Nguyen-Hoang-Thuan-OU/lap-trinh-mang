using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class BTH04_BT03_BinaryDataTest
{
    public static void Main()
    {
        // Tạo ra các biến để với các kiểu dữ liệu khác nhau
        int test1 = 45;
        double test2 = 3.14159;
        int test3 = -1234567890;
        bool test4 = false;

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

        data = BitConverter.GetBytes(test4);
        output = BitConverter.ToString(data);
        Console.WriteLine("test4 = {0}, string = {1}", test4, output);
    }
}