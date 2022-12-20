using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace popclient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private TcpClient mailclient;
        private NetworkStream ns;
        private StreamReader sr;
        private StreamWriter sw;

        void loginandretr()
        {
            string response;
            string from = null;
            string subject = null;
            int totmessages;
            //thực hiện kết nối với server
            try
            {
                mailclient = new TcpClient(txtHost.Text, 110);
            }
            catch (SocketException)
            {
                txtSta.Text = "Unable to connect to server";
                return;
            }
            //sử dụng phương thức stream để trả về networkstream
            ns = mailclient.GetStream();
            //tạo đối tượng đẻ đọc các kí tự từ luồng
            sr = new StreamReader(ns);
            //tạo đối tượng để ghi các kí tự từ luồng
            sw = new StreamWriter(ns);
            //đọc kí tự từ luồng hiện tại và trả về dữ liệu dưới dạng một chuỗi
            response = sr.ReadLine();
            //ghi chuỗi vào luồng, theo sau là dấu chấm
            sw.WriteLine("User " + txtUser.Text);
            //Xóa bộ đệm cho trình ghi hiện tại và làm cho mọi dữ liệu trong bộ đệm được ghi vào luồng bên dưới
            sw.Flush();
            response = sr.ReadLine();
            //nếu bắt đầu = -ER, báo lỗi
            if (response.Substring(0, 3) == "-ER")
            {
                txtSta.Text = "Unable to log into server";
                return;
            }
            //tương tự ở trên
            sw.WriteLine("Pass " + txtPass.Text);
            sw.Flush();
            try
            {
                response = sr.ReadLine();
            }
            catch (IOException)
            {
                txtSta.Text = "Unable to log into server";
                return;
            }
            if (response.Substring(0, 4) == "-ERR")
            {
                txtSta.Text = "Unable to log into server";
                return;
            }
            sw.WriteLine("stat");
            sw.Flush();
            //tách một chuỗi thành các chuỗi con dựa trên kí tụ khoảng trống
            response = sr.ReadLine();
            string[] nummess = response.Split(' ');
            //chuyển giá trị thành một số nguyên có dấu 16bit
            //đếm số tin nhắn
            totmessages = Convert.ToInt16(nummess[1]);
            if (totmessages > 0)
            {
                txtSta.Text = "you have " + totmessages + " messages";
            }
            else
            {
                txtSta.Text = "You have no messages";
            }
            for (int i = 1; i <= totmessages; i++)
            {
                sw.WriteLine("top " + i + " 0");
                sw.Flush();
                response = sr.ReadLine();
                while (true)
                {
                    response = sr.ReadLine();
                    //kết thúc nếu gặp .
                    if (response == ".")
                        break;
                    //format chuỗi được in ra bảng
                    if (response.Length > 4)
                    {
                        if (response.Substring(0, 5) == "From:")
                            from = response;
                        if (response.Substring(0, 8) == "Subject:")
                            subject = response;
                    }
                }
                //in kết quả ra bảng
                listBox1.Items.Add(i + " " + from + " " + subject);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //bắt đầu luồng sử dụng luồng tĩnh
            txtSta.Text = "Checking for messages...";
            Thread startlogin = new Thread(new ThreadStart(loginandretr));
            startlogin.IsBackground = true;
            startlogin.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //kết thúc làm việc
            if (ns != null)
            {
                sw.Close();
                sr.Close();
                ns.Close();
                mailclient.Close();
            }
            Close();
        }
    }
}
