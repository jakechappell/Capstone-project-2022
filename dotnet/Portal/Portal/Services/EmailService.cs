using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Portal.Classes;
using Portal.ViewModels;
using System;
using System.Threading.Tasks;

namespace Portal.Services
{
    public class EmailService : IEmailService
    {
        public readonly IConfiguration Config;
        public EmailService(IConfiguration configuration)
        {
            Config = configuration;
        }
        public async Task SendEmailAsync(EmailFormViewModel vm)
        {
            var settings = new MailSettings(Config);
            if (settings.Enabled)
            {
                var email = new MimeMessage();

                email.Sender = MailboxAddress.Parse(settings.FromEmail);
                email.To.Add(MailboxAddress.Parse(settings.ToEmail));
                email.Subject = "Access to developer portal requested!";
                var builder = new BodyBuilder();
                var body = $"Access has been requested from {vm.EmailAddress}.";
                body += Environment.NewLine;
                body += $"First Name: {vm.FirstName}";
                body += Environment.NewLine;
                body += $"Last Name: {vm.LastName}";
                body += Environment.NewLine;
                body += $"Company: {vm.CompanyName}";
                body += Environment.NewLine;
                body += $"Occupation: {vm.Occupation}";
                body += Environment.NewLine;
                body += $"Reason: {vm.Reason}";
                builder.TextBody = body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(settings.Host, settings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(settings.FromEmail, settings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }
    }
}
