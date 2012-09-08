using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Scarlett.IIM.Twilio.MVC4.Controllers;

namespace Scarlett.IIM.Twilio.MVC4.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMessage()
        {
            var controller = new HomeController(); 

            var message =  (new HomeController()).Broadcast("50 150");
            //Console.WriteLine(message);
        }

    }
}