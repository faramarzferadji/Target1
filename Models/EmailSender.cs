using Microsoft.AspNetCore.Identity.UI.Services;

namespace Target1.Models
{
    public class EmailSender : IEmailSender
    {
        Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic for send email .noe it is fake just for result problem.
            return Task.CompletedTask;
        }
    }
}
