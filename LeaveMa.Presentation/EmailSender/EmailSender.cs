using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace LeaveMa.Presentation.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            email = _configuration["testEmail"];
            var test = _configuration["Sender"];
            var smtpClient = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_configuration["Sender"], _configuration["Password"]),
                EnableSsl = true
            };

            var message = new MailMessage
            {
                From = new MailAddress(_configuration["Sender"]),
                Subject = subject,
                Body = htmlMessage
            };
            
                message.To.Add(new MailAddress(email));
                smtpClient.Send(message);

            return Task.CompletedTask;
        }
    }
}
