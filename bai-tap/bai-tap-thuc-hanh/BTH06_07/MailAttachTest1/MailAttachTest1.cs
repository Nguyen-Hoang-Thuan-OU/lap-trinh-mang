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

namespace MailAttachTest
{
    class MailAttachTest1
    {
        static void Main(string[] args)
        {
            /*
             * Lớp MailAttachment chỉ định tệp sẽ được đính kèm và gửi đi
             * 
             * Base64 là phương thức chuyển đổi dạng mã hóa 2 chiều
             * từ nhị phân sang chuỗi để có thể dễ dàng gửi đi
             */
            MailAttachment myattach = new MailAttachment("C:\\temp\\test.txt",
                                                            MailEncoding.Base64);

            // Tạo đối tượng newmessage từ lớp MailMessage
            MailMessage newmessage = new MailMessage();

            // Thuộc tính From chứa thông tin địa chỉ của người gửi thư
            newmessage.From = "test1@test.com";

            // Thuộc tính To chứa thông tin địa chỉ của người nhận thư
            newmessage.To = " test2@test.com ";

            // Thuộc tính Subject chứa tiêu đề thư
            newmessage.Subject = "A test mail attachment message";

            // Thuộc tính Priority chỉ định độ quan trọng, ưu tiên của thư
            newmessage.Priority = MailPriority.High;

            // Thuộc tính Headers chứa tiêu đề thư
            newmessage.Headers.Add("Comments",
                                    "This message attempts to send a binary attachment");

            // Thuộc tính Attachments đính tệp tin vào thư
            newmessage.Attachments.Add(myattach);

            // Thuộc tính Body chứa nội dung thư
            newmessage.Body = "Here's a test file for you to try";

            try
            {
                /*
                 * Thuộc tính SmtpServer
                 * chỉ ra địa chỉ hoặc tên của server chuyển tiếp thư
                 * được dùng để chuyển tiếp các thông điệp thư ra ngoài
                 */
                SmtpMail.SmtpServer = "192.168.81.100";

                /*
                 * Gửi thư bằng cách truyền đối tượng newmessage
                 * vào phương thức Send()
                 */
                SmtpMail.Send(newmessage);
            }
            catch (System.Web.HttpException)
            {
                Console.WriteLine("This device cannot send Internet messages");
            }

            Console.ReadKey();
        }
    }
}
