using Microsoft.AspNetCore.Mvc;
using SimpleMailSendingApp.Dtos;
using SimpleMailSendingApp.Services;

namespace SimpleMailSendingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost]
        public ActionResult SendEmail(SendEmailDto request)
        {
            emailService.SendEmail(request);
            return Ok("Message Sent");
        }
    }
}
