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
            var message = Broadcast(this.smsModel.Body, this.smsModel.From);
            response.Sms(message);
            return new TwiMLResult(response);
        }

        public string Broadcast(string recieved, string fromPhone)
        {
            var twilio = new TwilioRestClient("AC654fe8d243f96cb77397f0f280ab504f"
                                            , "f86acec80f8bea5ff10db08837804f80");
            var myMsg = OutboundMessage(recieved);

            foreach(var outboundNumber in phoneNumbers)
            {
                if (!outboundNumber.Equals(fromPhone))
                    twilio.SendSmsMessage(twilioNumber
                                            , outboundNumber
                                            , myMsg);
            }

            return myMsg;

        }

        public string OutboundMessage(string receivedBody)
        {
            return string.Format("Recieved {0}. Recommendations {1}"
                , receivedBody, (new Broadcaster()).DosageMessage(receivedBody));
        }

        private string twilioNumber = "+18324314732";
        private List<string> phoneNumbers = new List<string>() { "+17134691427", "+18322761115", "+12812299434" };




    }
}
