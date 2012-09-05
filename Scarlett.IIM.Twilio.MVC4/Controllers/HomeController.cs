using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
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
            response.Sms(DosageMessage());
            return new TwiMLResult(response);
        }

        private string DosageMessage()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("this is my SMS response in reply to \r\n{0}", Body);
            return builder.ToString();
        }

        public int BlooodSugarFromBody()
        {
            return 0;
        }

        
    }
}
