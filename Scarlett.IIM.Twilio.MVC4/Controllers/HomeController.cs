using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace Scarlett.IIM.Twilio.MVC4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Response/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Test()
        {
            var response = new TwilioResponse();
            response.Say("this is my response");
            return new TwiMLResult(response);
        }


        [HttpPost]
        public ActionResult SmsResponse()
        {
            var response = new TwilioResponse();
            response.Say("this is my response");
            return new TwiMLResult(response);
        }
    }
}
