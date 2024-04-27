using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace back.Services.Notifications
{
    public class EmailSender : IEmailSender
    {
        const string EMAIL = "tango-app@hotmail.com";
        const string PASSWORD = "$TangoEmailSender*123";

        SmtpClient GetSmtpClient()
        {
            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(EMAIL, PASSWORD)
            };

            return client;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage) 
            => GetSmtpClient().SendMailAsync(
                from: EMAIL, 
                recipients: email, 
                subject: subject, 
                body: htmlMessage);
    }
}
