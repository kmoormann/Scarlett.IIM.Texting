using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace Scarlett.IIM.Twilio
{
    public class TextMessageSender
    {
        private readonly string _twilioNumber = "+18324314732";

        public void Send(string message, IEnumerable<string> phoneNumbers)
        {
            foreach (var outboundNumber in phoneNumbers)
            {
                Send(message, outboundNumber);
            }

            
        }

        public void Send(string message, string phoneNumber)
        {
            var twilio = new TwilioRestClient("AC654fe8d243f96cb77397f0f280ab504f"
                                               , "f86acec80f8bea5ff10db08837804f80");

            twilio.SendSmsMessage(_twilioNumber
                                    , phoneNumber
                                    , message);
        }


    }
}
