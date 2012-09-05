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
            double[] dosages = Dosages(smsModel.Body);
            builder.AppendFormat("dosage raw:  {0} dosage rounded: {1}", dosages[0], dosages[1]);
            return builder.ToString();
        }

        public double[] Dosages(string body)
        {
            var nums = null == body ? null : body.Split(' ').ToList();
            if (nums == null) return new double[] { 0, 0 };
            int bloodSugar = Int32.Parse(nums[0]);
            int carbs = Int32.Parse(nums[1]);
            int correctionFactor = 150;
            int targetBloodSugar = 150;
            int insulinToCarbRatio = 50;

            double dosage = ((double)carbs / insulinToCarbRatio) + ((bloodSugar - targetBloodSugar) / (double)correctionFactor);
            return new double[] { dosage, Math.Round(dosage, 1, MidpointRounding.ToEven) };

        }

        
    }
}
