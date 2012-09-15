using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scarlett.IIM.Domain.Tests
{
    [TestClass]
    public class DosageMessageCreatorTests
    {
        [TestMethod]
        public void DosageMessageTest()
        {
            var message = DosageMessageCreator.Create(
                new Scarlett.IIM.Twilio.SmsModel()
                {
                   Body = "50 150",
                   DateSent = new DateTime(2012,9,15,7,30,0)
                });
            //Arrange
            //var bloodSugar = 0;
            //var carbs = 0;

            double[] expectedDosages = { 0, 0 };

            //Broadcaster broadcaster = new Broadcaster();

            ////Act
            //double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            ////Assert
            //Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            //Assert.AreEqual(expectedDosages[1], actualDosages[1]);

        }
    }

    [TestClass]
    public class InslinCalculatorFactorsRepositoryTests
    {
        [TestMethod]
        public void HourlyIndexTest()
        {
            //Arrange

            //Act

            //Assert
            //Assert.A
        }


        [TestMethod]
        public void CarbEqualToRatioDosageCheck()
        {
            //Arrange
            var bloodSugar = 0;
            var carbs = 50;

            double[] expectedDosages = { 1, 1 };

            //Broadcaster broadcaster = new Broadcaster();

            ////Act
            //double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            ////Assert
            //Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            //Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        }

        [TestMethod]
        public void CarbHigherThanToRatioDosageCheck()
        {
            //Arrange
            var bloodSugar = 0;
            var carbs = 75;

            //double[] expectedDosages = { 1.5, 1.5 };

            //Broadcaster broadcaster = new Broadcaster();

            ////Act
            //double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            ////Assert
            //Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            //Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        }

        [TestMethod]
        public void RoundDownCheck()
        {
            //Arrange
            var bloodSugar = 0;
            var carbs = 60;

            double[] expectedDosages = { 1.2, 1.0 };

            //Broadcaster broadcaster = new Broadcaster();

            ////Act
            //double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            ////Assert
            //Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            //Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        }

        [TestMethod]
        public void RoundUpCheck()
        {
            //Arrange
            var bloodSugar = 0;
            var carbs = 95;

            //double[] expectedDosages = { 1.9, 2.0 };

            //Broadcaster broadcaster = new Broadcaster();

            ////Act
            //double[] actualDosages = broadcaster.CaculateDosage(bloodSugar, carbs);

            ////Assert
            //Assert.AreEqual(expectedDosages[0], actualDosages[0]);
            //Assert.AreEqual(expectedDosages[1], actualDosages[1]);
        }
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}

