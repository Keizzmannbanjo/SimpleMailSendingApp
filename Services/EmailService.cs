using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SimpleMailSendingApp.Dtos;

namespace SimpleMailSendingApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration config;

        public EmailService(IConfiguration config)
        {
            this.config = config;
        }
        public void SendEmail(SendEmailDto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(config.GetSection("EmailConfig:Username").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(config.GetSection("EmailConfig:Host").Value, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(config.GetSection("EmailConfig:Username").Value, config.GetSection("EmailConfig:Password").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
