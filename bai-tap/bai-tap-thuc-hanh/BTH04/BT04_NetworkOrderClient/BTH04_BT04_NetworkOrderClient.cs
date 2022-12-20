
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
class NetworkOrderClient
{
    public static void Main()
    {
        //tao mang kieu byte, tao server
        byte[] data = new byte[1024];
        string stringData;
        TcpClient server;
        try
        {
            server = new TcpClient("127.0.0.1", 9050);
        }
        catch (SocketException)
        {
            Console.WriteLine("Unable to connect to server");
            return;
        }
        //tao luong stream de gui va nhan thong tin
        NetworkStream ns = server.GetStream();
        //bien recv luu do dai du lieu nhan duoc
        int recv = ns.Read(data, 0, data.Length);
        //chuyen du lieu nhan duoc sang kieu chuoi
        stringData = Encoding.ASCII.GetString(data, 0, recv);
        Console.WriteLine(stringData);
        short test1 = 45;
        int test2 = 314159;
        long test3 = -123456789033452;
        //chuyen gia tri sang byte mạng
        short test1b = IPAddress.HostToNetworkOrder(test1);
        data = BitConverter.GetBytes(test1b);
        Console.WriteLine("sending test1 = {0}", test1);
        //gui chuoi
        ns.Write(data, 0, data.Length);
        //xoa du lieu khoi luong
        ns.Flush();
        int test2b = IPAddress.HostToNetworkOrder(test2);
        data = BitConverter.GetBytes(test2b);
        Console.WriteLine("sending test2 = {0}", test2);
        ns.Write(data, 0, data.Length);
        ns.Flush();
        long test3b = IPAddress.HostToNetworkOrder(test3);
        data = BitConverter.GetBytes(test3b);
        Console.WriteLine("sending test3 = {0}", test3);
        ns.Write(data, 0, data.Length);
        ns.Flush();
        //dong luong doc, ghi du lieu stream
        ns.Close();
        //ngat ket noi server
        server.Close();
    }
}