using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Scarlett.IIM.Twilio
{
    public class Broadcaster
    {
        public void Broadcast(SmsModel model)
        {
            var twilio = new TwilioRestClient("AC654fe8d243f96cb77397f0f280ab504f"
                                            , "f86acec80f8bea5ff10db08837804f80");
            var myMsg = OutboundMessage(model.Body);
            var msg = twilio.SendSmsMessage(twilioNumber
                ,phoneNumbers[0]
                ,myMsg);

            var msg2 = twilio.SendSmsMessage(twilioNumber
    , phoneNumbers[1]
    , myMsg);

        }

        public string OutboundMessage(string receivedBody)
        {
            return string.Format("Recieved {0}. Recommendations {1}"
                , receivedBody, DosageMessage(receivedBody));
        }

        private string twilioNumber = "8324314732";
        private List<string> phoneNumbers = new List<string>(){ "713461427", "8322761115" };

        public string DosageMessage(string body)
        {
            var dosages = DosagesFromTextMessage(body);
            return string.Format("dosage raw:  {0:0.##} dosage rounded: {1:0.0}", dosages[0], dosages[1]);
            
        }

        public double[] DosagesFromTextMessage(string body)
        {
            var nums = null == body ? null : body.Split(' ').ToList();
            if (nums == null) return new double[] { 0, 0 };
            int bloodSugar = Int32.Parse(nums[0]);
            int carbs = Int32.Parse(nums[1]);


            return CaculateDosage(bloodSugar, carbs);
        }

        private int correctionFactor = 150;
        private int targetBloodSugar = 150;
        private int insulinToCarbRatio = 50;

        public double[] CaculateDosage(int bloodSugar, int carbs)
        {

            double foodDosage = ((double)carbs / insulinToCarbRatio);
            double insulinDosage = bloodSugar < targetBloodSugar
                                    ? 0
                                    : ((bloodSugar - targetBloodSugar) / (double)correctionFactor);
            double dosage = foodDosage + insulinDosage;

            int numOfHalfUnits = (int)(dosage / 0.5);
            double remainder = (double)(dosage % 0.5);
            double roundedAmount = remainder > 0.25 ? 0.5 : 0;
            double roundedDosage = numOfHalfUnits * 0.5 + roundedAmount; //* dosage

            return new double[] { dosage, roundedDosage };
        }
    }
}
