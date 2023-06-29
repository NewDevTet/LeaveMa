using Microsoft.AspNetCore.Identity.UI.Services;

namespace LeaveMa.Presentation.EmailSender
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}
