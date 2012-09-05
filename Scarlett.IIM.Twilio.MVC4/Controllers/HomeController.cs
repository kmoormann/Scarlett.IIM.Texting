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
        [HttpGet]
        [HttpPost]
        public ActionResult Index()
        {
            ActionResult result = null;
            switch (HttpContext.Request.HttpMethod)
            {
                case "GET":
                    result = IndexGet();
                    break;
                case "POST":
                    result = IndexPost();
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }

        private ActionResult IndexPost()
        {
            var response = new TwilioResponse();
            response.Say("this is my response");
            return new TwiMLResult(response);
        }

        private ActionResult IndexGet()
        {
            return View("Index");
        }
    }
}
