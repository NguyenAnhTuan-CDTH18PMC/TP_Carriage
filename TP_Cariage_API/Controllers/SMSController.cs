using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace TP_Cariage_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        [HttpGet]
        public ActionResult SendSMS()
        {
            string accountSid = Environment.GetEnvironmentVariable("ACa5fd520ae12ffcc02055cd22dc6b88ac");
            string authToken = Environment.GetEnvironmentVariable("d08f428de88b1e1aa899d7f6618b5956");
            TwilioClient.Init(accountSid, authToken);
            var message = MessageResource.Create(
           body: "Phu oi tuan met qua",
           from: new Twilio.Types.PhoneNumber("+14692840145"),
           to: new Twilio.Types.PhoneNumber("+84372889114")
       );
            return Content(message.Sid);
        }
    }
}
