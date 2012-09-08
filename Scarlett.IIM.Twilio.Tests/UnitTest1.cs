using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scarlett.IIM.Twilio.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ZeroBloodSugar()
        {
            //Arrange
            var bloodSugar = 0;
            var carbs = 0;

            double[] expectedDosages = { 0, 0 };

            Broadcaster broadcaster = new Broadcaster();

            //Act
            double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            //Assert
            Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        }

        [TestMethod]
        public void CarbEqualToRatioDosageCheck()
        {
            //Arrange
            var bloodSugar = 0;
            var carbs = 50;

            double[] expectedDosages = { 1, 1 };

            Broadcaster broadcaster = new Broadcaster();

            //Act
            double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            //Assert
            Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        }

        [TestMethod]
        public void CarbHigherThanToRatioDosageCheck()
        {
            //Arrange
            var bloodSugar = 0;
            var carbs = 75;

            double[] expectedDosages = { 1.5, 1.5 };

            Broadcaster broadcaster = new Broadcaster();

            //Act
            double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            //Assert
            Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        }

        [TestMethod]
        public void RoundDownCheck()
        {
            //Arrange
            var bloodSugar = 0;
            var carbs = 60;

            double[] expectedDosages = { 1.2, 1.0 };

            Broadcaster broadcaster = new Broadcaster();

            //Act
            double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            //Assert
            Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        }

        [TestMethod]
        public void RoundUpCheck()
        {
            //Arrange
            var bloodSugar = 0;
            var carbs = 95;

            double[] expectedDosages = { 1.9, 2.0 };

            Broadcaster broadcaster = new Broadcaster();

            //Act
            double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            //Assert
            Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        }

        [TestMethod]
        public void TestFormat()
        {
            Console.Write(new Broadcaster().DosageMessage("165 36"));
        }

        //[TestMethod]
        //public void TestMessaging()
        //{
        //    //Arrange
        //    var bloodSugar = 0;
        //    var carbs = 235;

        //    double[] expectedDosages = { 1.9, 2.0 };

        //    Broadcaster broadcaster = new Broadcaster();

        //    //Act
        //    broadcaster.Broadcast(model: new SmsModel() { Body = "50 235" }); //CaculateDosage(bloodSugar, carbs);

        //    //Assert
        //    //Assert.AreEqual(expectedDosages[0], actualDosages[0]);
        //    //Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        //}
    }
}
