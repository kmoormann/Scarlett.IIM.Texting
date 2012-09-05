using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scarlett.IIM.Twilio.MVC4.Models
{
    public class SmsTwilioModel
    {
        public string CallSid { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string AccountSid { get; set; }
        public string CallStatus { get; set; }
        public string FromCity { get; set; }
        public string FromState { get; set; }
        public string FromZip { get; set; }
        public string FromCountry { get; set; }
        public string ToCity { get; set; }
        public string ToState { get; set; }
        public string ToZip { get; set; }
        public string ToCountry { get; set; }
        public string Digits { get; set; }
        public string SmsSid { get; set; }
        public string Body { get; set; }

        public static SmsTwilioModel InitializeModel(ActionExecutingContext filterContext)
        {
            var model = new SmsTwilioModel();

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

            return model;
        }

    }
}