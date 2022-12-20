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

namespace MailAttachTest2
{
    class MailAttachTest2
    {
        static void Main(string[] args)
        {
            // Chỉ định tệp sẽ được đính kèm và gửi đi
            string file1 = "test1.jpg";
            string file2 = "test2.doc";

            /*
             * Lớp SmtpClient cho phép ứng dụng gửi email
             * bằng cách sử dụng SMTP
             */
            SmtpClient SmtpMail = new SmtpClient();

            // Tạo đối tượng f1, f2 từ lớp Attachment
            Attachment f1 = new Attachment(file1);
            Attachment f2 = new Attachment(file2);

            // Dùng hàm khởi tạo MailMessage(String, String, String, String)
            MailMessage newmessage = new MailMessage("test1@test.com","test2@test.com",
                                                        "A test mail attachment message",
                                                        "TEST MAIL");

            // Thuộc tính Priority chỉ định độ quan trọng, ưu tiên của thư
            newmessage.Priority = MailPriority.High;

            // Thuộc tính Headers chứa tiêu đề thư
            newmessage.Headers.Add("Comments",
                                    "This message attempts to send a picture, a text document attachments");

            // Thuộc tính Attachments đính tệp tin vào thư
            newmessage.Attachments.Add(f1);
            newmessage.Attachments.Add(f2);

            try
            {
                // Thuộc tính Host chỉ định tên hoặc địa chỉ IP của máy chủ
                SmtpMail.Host = "192.168.81.100";

                /*
                 * Gửi thư bằng cách truyền đối tượng newmessage
                 * vào phương thức Send()
                 */
                SmtpMail.Send(newmessage);
            }
            catch (System.Net.HttpListenerException)
            {
                Console.WriteLine("This device cannot send Internet messages");
            }
        }
    }
}
