using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scarlett.IIM.Twilio.MVC4.Models
{
    public class SmsTwilioModel : SmsModel
    {
        public static SmsModel InitializeModel(ActionExecutingContext filterContext)
        {
            var model = new SmsModel();

            model.CallSid = filterContext.HttpContext.Request.Params["CallSid"];
            model.To = filterContext.HttpContext.Request.Params["To"];
            model.From = filterContext.HttpContext.Request.Params["From"];
            model.AccountSid = filterContext.HttpContext.Request.Params["AccountSid"];
            model.CallStatus = filterContext.HttpContext.Request.Params["CallStatus"];
            model.FromCity = filterContext.HttpContext.Request.Params["FromCity"];
            model.FromState = filterContext.HttpContext.Request.Params["FromState"];
            model.FromZip = filterContext.HttpContext.Request.Params["FromZip"];
            model.FromCountry = filterContext.HttpContext.Request.Params["FromCountry"];
            model.ToCity = filterContext.HttpContext.Request.Params["ToCity"];
            model.ToState = filterContext.HttpContext.Request.Params["ToState"];
            model.ToZip = filterContext.HttpContext.Request.Params["ToZip"];
            model.ToCountry = filterContext.HttpContext.Request.Params["ToCountry"];
            model.Digits = filterContext.HttpContext.Request.Params["Digits"];
            model.SmsSid = filterContext.HttpContext.Request.Params["SmsSid"];
            model.Body = filterContext.HttpContext.Request.Params["Body"];
            //model.DateCreated = DateTime.Parse(filterContext.HttpContext.Request.Params["DateCreated"]);
            model.DateSent = DateTime.Now;
            DateTime tmpDate = model.DateSent;
            if (DateTime.TryParse(filterContext.HttpContext.Request.Params["DateSent"], out tmpDate))
            {
                model.DateSent = tmpDate;
            };

            return model;
        }

    }
}