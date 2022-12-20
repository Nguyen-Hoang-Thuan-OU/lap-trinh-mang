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

namespace MailTest
{
    class MailTest1
    {
        static void Main(string[] args)
        {
            // Chuỗi chứa thông tin địa chỉ của người gửi thư
            string from = "test1@test.com";

            // Chuỗi chứa thông tin địa chỉ của người nhận thư
            string to = " test2@test.com";

            // Chuỗi chứa tiêu đề thư
            string subject = "This is a test mail message";

            // Chuỗi chứa nội dung thư
            string body = "Hi test2";

            /*
             * Thuộc tính SmtpServer
             * chỉ ra địa chỉ hoặc tên của server chuyển tiếp thư
             * được dùng để chuyển tiếp các thông điệp thư ra ngoài
             */
            SmtpMail.SmtpServer = "192.168.81.100";

            /*
             * Gửi thư bằng phương thức Send(),
             * truyền các đối số là các chuỗi đã được truyền vào ở trên
             */
            SmtpMail.Send(from, to, subject, body);
        }
    }
}