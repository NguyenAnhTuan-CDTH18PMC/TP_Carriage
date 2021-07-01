using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP_Cariage_API.SendMail;
using System.Net.Mail;
using System.Net.Http;
using System.Web.Http;

namespace TP_Cariage_API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        public IActionResult SendMail(EmailRequest emailRequest)
        {
            string subject = emailRequest.Subject;
            string body = emailRequest.Body;
            string to = emailRequest.To;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("TP.Carriage.CaoThang@gmail.com");
            mailMessage.To.Add(to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = true;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("TP.Carriage.CaoThang@gmail.com", "AnhTuan0403");
            smtp.Send(mailMessage);
            return Ok();
        }
    }
}
