using SimpleMailSendingApp.Dtos;

namespace SimpleMailSendingApp.Services
{
    public interface IEmailService
    {
        void SendEmail(SendEmailDto request);
    }
}
