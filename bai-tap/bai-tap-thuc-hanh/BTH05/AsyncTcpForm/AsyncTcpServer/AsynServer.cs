using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace AsyncTcp
{
    public partial class AsynServer : Form
    {
        //public AsynServer()
        //{
        //    InitializeComponent();
        //}

        // Tạo mảng data 1024 byte để chứa dữ liệu
        private byte[] data = new byte[1024];
        private int size = 1024;

        // Khai báo socket cho Server
        private Socket server;

        // Hàm kết nối bất đồng bộ
        public AsynServer()
        {
            InitializeComponent();

            // Tạo socket cho Server
            server = new Socket(AddressFamily.InterNetwork,
                                SocketType.Stream, ProtocolType.Tcp);

            // Tạo IPEndPoint với card mạng bất kỳ và port 9050
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);

            // Gán socket cho IPEndPoint
            server.Bind(iep);

            // Lắng nghe kết nối từ Client, tối đa 5 kết nối
            server.Listen(5);

            // Chấp nhận kết nối bất đồng bộ
            server.BeginAccept(new AsyncCallback(AcceptConn), server);
        }

        // Hàm chấp nhận kết nối
        void AcceptConn(IAsyncResult iar)
        {
            // Lấy trạng thái của socket
            Socket oldserver = (Socket)iar.AsyncState;

            // Dùng phương thức EndAccept() để kết thúc việc chấp nhận Socket
            Socket client = oldserver.EndAccept(iar);

            // Lấy thông tin EndPoint của Client
            conStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();

            // Tạo chuỗi chào mừng, chuyển thành mảng byte và gửi sang Client
            string stringData = "Welcome to my server";
            byte[] message1 = Encoding.ASCII.GetBytes(stringData);
            client.BeginSend(message1, 0, message1.Length, SocketFlags.None,
                                new AsyncCallback(SendData), client);
        }

        // Hàm gửi bất đồng bộ
        void SendData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);
            client.BeginReceive(data, 0, size, SocketFlags.None,
                                new AsyncCallback(ReceiveData), client);
        }

        // Hàm nhận bất đồng bộ
        void ReceiveData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int recv = client.EndReceive(iar);
            if (recv == 0)
            {
                client.Close();
                conStatus.Text = "Waiting for client...";
                server.BeginAccept(new AsyncCallback(AcceptConn), server);
                return;
            }
            string receivedData = Encoding.ASCII.GetString(data, 0, recv);
            results.Items.Add(receivedData);
            byte[] message2 = Encoding.ASCII.GetBytes(receivedData);
            client.BeginSend(message2, 0, message2.Length, SocketFlags.None,
                                new AsyncCallback(SendData), client);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
