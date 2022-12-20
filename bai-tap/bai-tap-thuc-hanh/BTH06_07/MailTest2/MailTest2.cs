using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Sockets;
using System.Web;
using System.Threading;
using System.IO;

namespace MailTest2
{
    class MailTest2
    {
        static void Main(string[] args)
        {
            /*
             * Lớp SmtpClient cho phép ứng dụng gửi email
             * bằng cách sử dụng SMTP
             */
            SmtpClient SmtpMail = new SmtpClient();

            // Chuỗi chứa thông tin địa chỉ của người gửi thư
            string from = "test1@test.com";

            // Chuỗi chứa thông tin địa chỉ của người nhận thư
            string to = "test2@test.com";

            // Chuỗi chứa tiêu đề thư
            string subject = "This is a test mail message";

            // Chuỗi chứa nội dung thư
            string body = "Hi test2";

            // Thuộc tính Host chỉ định tên hoặc địa chỉ IP của máy chủ
            SmtpMail.Host = "192.168.81.100";

            /*
             * Thuộc tính Port chỉ định port của máy chủ
             * trong giao thức SMTP
             */
            SmtpMail.Port = 23;

            /*
             * Gửi thư bằng phương thức Send(),
             * truyền các đối số là các chuỗi đã được truyền vào ở trên
             */
            SmtpMail.Send(from, to, subject, body);
        }
    }
}
