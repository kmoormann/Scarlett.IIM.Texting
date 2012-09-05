using System;
using System.Collections.Generic;
using System.Linq;
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
            response.Say("this is my response");
            response.Sms("this is my SMS response");
            return new TwiMLResult(response);
        }
    }
}
