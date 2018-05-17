using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.AspNet.Core;
using Twilio.Rest.Api.V2010.Account;
using UserSecrets.Web.Models.Configuration;

namespace UserSecrets.Web.Controllers
{
    [Route("api/[controller]")]
    public class MessageController : TwilioController
    {
        private readonly TwilioAccountDetails _twilioAccountDetails;
        public MessageController(IOptions<TwilioAccountDetails> twilioAccountDetails)
        {
            _twilioAccountDetails = twilioAccountDetails.Value ?? throw new ArgumentException(nameof(twilioAccountDetails));

        }


        // GET api/message
        [HttpGet]
        public IActionResult Get()
        {
            return Content("Hello World");
        }


        // POST api/message
        [HttpPost]
        public void Post(string from)
        {
            TwilioClient.Init(_twilioAccountDetails.AccountSid, _twilioAccountDetails.AuthToken);
            
            var message = MessageResource.Create(
                to: from,
                @from: "+447400337582",
                body: "Three may keep a secret, if two of them are dead!");

            Console.WriteLine(message.Sid);
        }


    }
}
