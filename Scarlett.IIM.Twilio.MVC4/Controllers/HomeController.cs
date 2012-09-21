using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace Scarlett.IIM.Twilio.MVC4.Controllers
{
    public class HomeController : TwiMLController
    {

        //
        // GET: /Response/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SmsResponse()
        {
            var response = new TwilioResponse();
            try
            {

                var message = GetResponseMessage();
                Broadcast(message);
                response.Sms(message);
            }
            catch (Exception e)
            {
                var message = string.Format("There was an error processing your message: {0}", smsModel.Body);
                response.Sms(message);
            }
            return new TwiMLResult(response);
        }

        private string GetResponseMessage()
        {
            return Domain.DosageMessageCreator.Create(this.smsModel);
        }

        public void Broadcast(string message)
        {
            var phoneNums = phoneNumbers.Where(x => !x.Equals(this.smsModel.From));
            var sender = new TextMessageSender();
            sender.Send(message, phoneNums);
        }
        
        private List<string> phoneNumbers = new List<string>() { "+17134691427", "+18322761115", "+12812299434" };


    }
}
