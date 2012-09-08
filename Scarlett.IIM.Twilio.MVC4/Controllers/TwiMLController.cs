using Scarlett.IIM.Twilio.MVC4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scarlett.IIM.Twilio.MVC4.Controllers
{
    public class TwiMLController : Controller
    {
        public SmsModel smsModel;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
            smsModel = SmsTwilioModel.InitializeModel(filterContext);

            base.OnActionExecuting(filterContext);
        }
    }

}

