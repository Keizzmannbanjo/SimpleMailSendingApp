using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace SimpleMailSendingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public ActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("deangelo.sanford68@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("deangelo.sanford68@ethereal.email"));
            email.Subject = "Test Email";
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("deangelo.sanford68@ethereal.email", "gducAqXFdEJj5FB4RP");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok("Message Sent");
        }
    }
}
