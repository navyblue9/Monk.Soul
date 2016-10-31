using MailKit.Net.Smtp;
using MimeKit;

namespace Monk.Utils
{
    public class MailHelper
    {
        public static void SendTextEmail(string fromName, string fromEMail, string toName, string toEMail, string subject, string text)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromName, fromEMail));
            message.To.Add(new MailboxAddress(toName, toEMail));
            message.Subject = subject;
            message.Body = new TextPart("plain")
            {
                Text = text
            };
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect("smtp.exmail.qq.com", 465, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("tech@baisoft.org", "wln1314*_Q");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}