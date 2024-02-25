using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using Shop.Applicationn.IServices;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;

namespace Shop.Applicationn.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly IConfiguration _configuration;

        public EmailService(IOptions<SmtpSettings> smtpSettings, IConfiguration configuration)
        {
            _smtpSettings = smtpSettings.Value;
            _configuration = configuration;
        }

        public void SendEmail(string userEmail, string subject, string htmlMessage)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["SmtpSettings:FromEmail"]));
            email.To.Add(MailboxAddress.Parse(userEmail));
            email.Subject = subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;

            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();

            if (int.TryParse(_configuration["SmtpSettings:Port"], out int port))
            {
                smtp.Connect(_configuration["SmtpSettings:Server"], port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration["SmtpSettings:Username"], _configuration["SmtpSettings:Password"]);
                smtp.Send(email);
                smtp.Disconnect(true);
            }

        }
    }
}
