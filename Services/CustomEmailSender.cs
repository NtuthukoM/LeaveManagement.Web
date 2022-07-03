using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagement.Web.Services
{
    public class CustomEmailSender : IEmailSender
    {
        private readonly string server;
        private readonly int port;
        private readonly string fromEmail;

        public CustomEmailSender(string server, int port, string fromEmail)
        {
            this.server = server;
            this.port = port;
            this.fromEmail = fromEmail;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage(fromEmail, email)
            {
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };
            using(var client = new SmtpClient(server, port))
            {
                await client.SendMailAsync(message);
            }
        }
    }
}
