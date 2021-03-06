﻿using System;
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
    public class DosageCalculatorTests
    {
        [TestMethod]
        public void FoodDosageCarbsEqualToRatioTest()
        {
            //Arrange
            var dosageVariables = new DosageVariables()
            {
                insulinToCarbRatio = 50
                ,bloodSugar = 150
                ,correctionFactor = 180
                ,targetBloodSugar = 150
                ,carbs = 50
            };
            var calc = new DosageCalulcator(dosageVariables);

            //Act
            var dosage = calc.Calculate();

            //Assert
            Assert.AreEqual(1, dosage);


        }

        [TestMethod]
        public void FoodDosageCarbsHigherThanRatioTest()
        {
            //Arrange
            var dosageVariables = new DosageVariables()
            {
                insulinToCarbRatio = 30,
                bloodSugar = 150,
                correctionFactor = 180,
                targetBloodSugar = 150,
                carbs = 40
            };
            var calc = new DosageCalulcator(dosageVariables);

            //Act
            var dosage = calc.Calculate();

            //Assert
            Assert.AreEqual((double)40/30, dosage);


        }

        [TestMethod]
        public void BloodGluscoseDosageCalcHigherThanTarget()
        {
            //Arrange
            var dosageVariables = new DosageVariables()
            {
                insulinToCarbRatio = 30,
                bloodSugar = 180,
                correctionFactor = 180,
                targetBloodSugar = 150,
                carbs = 0
            };
            var calc = new DosageCalulcator(dosageVariables);
            var expected = (dosageVariables.bloodSugar - dosageVariables.targetBloodSugar)/dosageVariables.correctionFactor;
            //Act
            var dosage = calc.Calculate();

            //Assert
            Assert.AreEqual(expected, dosage);


        }

        [TestMethod]
        public void BloodGluscoseDosageCalcLowerThanTarget()
        {
            //Arrange
            var dosageVariables = new DosageVariables()
            {
                insulinToCarbRatio = 30,
                bloodSugar = 90,
                correctionFactor = 180,
                targetBloodSugar = 150,
                carbs = 0
            };
            var calc = new DosageCalulcator(dosageVariables);
            var expected = (double)0;
            //Act
            var dosage = calc.Calculate();

            //Assert
            Assert.AreEqual(expected, dosage);


        }

        [TestMethod]
        public void RoundingUpTest()
        {
            //Arrange
            var carbs = 0.35 * 50;
            var dosageVariables = new DosageVariables()
            {
                insulinToCarbRatio = 50,
                bloodSugar = 90,
                correctionFactor = 180,
                targetBloodSugar = 150,
                carbs = carbs
            };
            var calc = new DosageCalulcator(dosageVariables);
            var expected = (double)0.5;
            //Act
            var dosage = calc.Calculate().Round(0.5);

            //Assert
            Assert.AreEqual(expected, dosage);


        }

        [TestMethod]
        public void RoundingUpTestHalfWay()
        {
            //Arrange
            var carbs = 0.25 * 50;
            var dosageVariables = new DosageVariables()
            {
                insulinToCarbRatio = 50,
                bloodSugar = 90,
                correctionFactor = 180,
                targetBloodSugar = 150,
                carbs = carbs
            };
            var calc = new DosageCalulcator(dosageVariables);
            var expected = (double)0.0;
            //Act
            var dosage = calc.Calculate().Round(0.5);

            //Assert
            Assert.AreEqual(expected, dosage);


        }

        [TestMethod]
        public void RoundingUpTestHalfWaywithWholeUnit()
        {
            //Arrange
            var carbs = 1.25 * 50;
            var dosageVariables = new DosageVariables()
            {
                insulinToCarbRatio = 50,
                bloodSugar = 90,
                correctionFactor = 180,
                targetBloodSugar = 150,
                carbs = carbs
            };
            var calc = new DosageCalulcator(dosageVariables);
            var expected = (double)1.0;
            //Act
            var dosage = calc.Calculate().Round(0.5);

            //Assert
            Assert.AreEqual(expected, dosage);


        }

        [TestMethod]
        public void RoundingUpTestWithWholeUnit()
        {
            //Arrange
            var carbs = 1.31 * 50;
            var dosageVariables = new DosageVariables()
            {
                insulinToCarbRatio = 50,
                bloodSugar = 90,
                correctionFactor = 180,
                targetBloodSugar = 150,
                carbs = carbs
            };
            var calc = new DosageCalulcator(dosageVariables);
            var expected = (double)1.5;
            //Act
            var dosage = calc.Calculate().Round(0.5);

            //Assert
            Assert.AreEqual(expected, dosage);


        }

        [TestMethod]
        public void RoundingDownTestWithWholeUnit()
        {
            //Arrange
            var carbs = 1.15 * 50;
            var dosageVariables = new DosageVariables()
            {
                insulinToCarbRatio = 50,
                bloodSugar = 90,
                correctionFactor = 180,
                targetBloodSugar = 150,
                carbs = carbs
            };
            var calc = new DosageCalulcator(dosageVariables);
            var expected = (double)1.0;
            //Act
            var dosage = calc.Calculate().Round(0.5);

            //Assert
            Assert.AreEqual(expected, dosage);


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

