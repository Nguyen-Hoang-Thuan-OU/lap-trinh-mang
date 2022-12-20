using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class BTH04_BT04_NetworkOrderSrvr
{
    public static void Main()
    {
        //tao bien luu do dai du lieu nhan duoc
        int recv;
        //tao mang
        byte[] data = new byte[1024];
        //dat tcplis port 9050
        TcpListener server = new TcpListener(9050);
        //bat dau lang nghe cac yeu cau tu client
        server.Start();
        Console.WriteLine("waiting for a client...");
        //chap nhan yeu cau
        TcpClient client = server.AcceptTcpClient();
        //tao luong stream de gui va nhan thong tin
        NetworkStream ns = client.GetStream();
        string welcome = "Welcome to my test server";
        data = Encoding.ASCII.GetBytes(welcome);
        //gui chuoi
        ns.Write(data, 0, data.Length);
        //xoa du lieu khoi luong
        ns.Flush();
        data = new byte[2];
        recv = ns.Read(data, 0, data.Length);
        //
        short test1t = BitConverter.ToInt16(data, 0);
        //chuyen gia tri sang byte mạng
        short test1 = IPAddress.NetworkToHostOrder(test1t);
        Console.WriteLine("received test1 = {0}", test1);
        data = new byte[4];
        //doc du lieu tu networkstream va luu vao mang byte
        recv = ns.Read(data, 0, data.Length);
        int test2t = BitConverter.ToInt32(data, 0);
        int test2 = IPAddress.NetworkToHostOrder(test2t);
        Console.WriteLine("received test2 = {0}", test2);
        data = new byte[8];
        recv = ns.Read(data, 0, data.Length);
        long test3t = BitConverter.ToInt64(data, 0);
        long test3 = IPAddress.NetworkToHostOrder(test3t);
        Console.WriteLine("received test3 = {0}", test3);
        //dong luong doc, ghi du lieu stream
        ns.Close();
        //ngat ket noi
        client.Close();
        //ngung nghe yeu cau
        server.Stop();
    }
}
