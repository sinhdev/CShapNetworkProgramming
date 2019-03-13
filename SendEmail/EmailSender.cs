using System;
using System.Net;
using System.Net.Mail;

namespace SendEmail
{
    class EmailSender
    {
        public static bool SendEmail(string email, string emailPassword, string address, string subject, string message)
        {
            try
            {
                var loginInfo = new NetworkCredential(email, emailPassword);
                var msg = new MailMessage();
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);

                msg.From = new MailAddress(email);
                msg.To.Add(new MailAddress(address));
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = true;

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(msg);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}