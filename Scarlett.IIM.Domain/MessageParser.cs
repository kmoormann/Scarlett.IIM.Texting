using Scarlett.IIM.Twilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scarlett.IIM.Domain
{
    public static class MessageParser
    {
        public static DosageVariables Parse(this SmsModel message)
        {
            var factors = message.GetFactors();
            return new DosageVariables()
            {
                bloodSugar = message.GetBloodSugar(),
                carbs = message.GetCarbs(),
                correctionFactor = factors.correctionFactor,
                insulinToCarbRatio = factors.insulinToCarbRatio,
                targetBloodSugar = factors.targetBloodSugar
            };

        }

        private static InsulinCalculationFactors GetFactors(this SmsModel sms)
        {
            var repo = new InslinCacluationFactorsRepository();
            return repo[sms.DateSent];
        }

        public static int GetBloodSugar(this SmsModel sms)
        {
            return Int32.Parse(sms.Body.Split(' ')[0]);   
        }

        public static int GetCarbs(this SmsModel sms)
        {
            return Int32.Parse(sms.Body.Split(' ')[1]);   
        }

    }
}
