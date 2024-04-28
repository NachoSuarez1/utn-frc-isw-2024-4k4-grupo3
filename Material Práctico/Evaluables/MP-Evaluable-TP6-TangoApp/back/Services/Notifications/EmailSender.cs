using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace back.Services.Notifications
{
    public class EmailSender : IEmailSender
    {
        const string EMAIL = "tango-app@hotmail.com";
        const string PASSWORD = "$TangoEmailSender*123";

        SmtpClient GetSmtpClient() => new SmtpClient("smtp-mail.outlook.com", 587) { EnableSsl = true, Credentials = new NetworkCredential(EMAIL, PASSWORD) };

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage();
            message.From = new MailAddress(EMAIL);
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.Body = htmlMessage;
            message.IsBodyHtml = true;

            return GetSmtpClient().SendMailAsync(message);
        }
    }
}
