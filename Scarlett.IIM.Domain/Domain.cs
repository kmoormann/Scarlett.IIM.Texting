using Scarlett.IIM.Twilio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scarlett.IIM.Domain
{
    public class InsulinCalculationFactors
    {
        public double correctionFactor;
        public double targetBloodSugar;
        public double insulinToCarbRatio;

    }
    public static class DosageMessageCreator
    {
        public static string Create(SmsModel inputMessage)
        {
            DosageCalulcator dosageCaclulator = null;
            
            double rawDosage, roundedDosage = 0;
            var variables = inputMessage.Parse();
            dosageCaclulator = new DosageCalulcator(variables);
            rawDosage = dosageCaclulator.Calculate();
            roundedDosage = rawDosage.Round((double)0.5);
            return MessageFormater(rawDosage, roundedDosage, inputMessage.Body, variables) + string.Format("\r\n Date Recieved: {0}",inputMessage.DateSent.ToString("G"));
        }

        private static string MessageFormater(double rawDosage, double roundedDosage, string originalMessage, InsulinCalculationFactors factors)
        {

            StringBuilder output = new StringBuilder();
            output.AppendFormat("Recieved: {0}", originalMessage);
            output.AppendLine();
            output.AppendFormat("Calculated Dosages:  {0:0.##} rounded: {1:0.0}", rawDosage, roundedDosage);
            output.AppendLine();
            output.AppendFormat("Based on: ICHO {0} Target BS {1} CF {2}", factors.insulinToCarbRatio, factors.targetBloodSugar, factors.correctionFactor);
            return output.ToString();
        }
    }

    public interface IInslulinCalculationFactorsByHour
    {
        InsulinCalculationFactors this[DateTime hourIndex]
        {
            get;
            set;
        }
    }

    public enum MealsEnum
    {
        Breakfast = 0,
        Lunch = 1,
        Dinner = 2,
        Unknown = 999
    }

    public class InslinCacluationFactorsRepository : IInslulinCalculationFactorsByHour
    {
        public Dictionary<MealsEnum, InsulinCalculationFactors> factorsDictionary;

        public InslinCacluationFactorsRepository()
        {
            factorsDictionary = new Dictionary<MealsEnum, InsulinCalculationFactors>();
            factorsDictionary.Add(MealsEnum.Breakfast,
                                    new InsulinCalculationFactors()
                                    {
                                        targetBloodSugar = 150,
                                        insulinToCarbRatio = 30,
                                        correctionFactor = 180
                                    });
            factorsDictionary.Add(MealsEnum.Lunch,
                                    new InsulinCalculationFactors()
                                    {
                                        targetBloodSugar = 150,
                                        insulinToCarbRatio = 50,
                                        correctionFactor = 180
                                    });
            factorsDictionary.Add(MealsEnum.Dinner,
                                    new InsulinCalculationFactors()
                                    {
                                        targetBloodSugar = 150,
                                        insulinToCarbRatio = 50,
                                        correctionFactor = 180
                                    });
        }


        public InsulinCalculationFactors this[DateTime hourIndex]
        {
            get
            {
                var hour = hourIndex.Hour;
                InsulinCalculationFactors rtn = factorsDictionary[MealsEnum.Lunch];
                if (hour > 5 && hour < 10)
                    rtn = factorsDictionary[MealsEnum.Breakfast];
                //lunch and dinner are the same, only breakfast differs
                return rtn;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }

    public class DosageVariables : InsulinCalculationFactors
    {
        public double bloodSugar;
        public double carbs;
    }


    public class DosageCalulcator
    {
        private readonly DosageVariables _variables;

        public DosageCalulcator(DosageVariables variables)
        {
            _variables = variables;
        }

        public double Calculate()
        {
            return FoodDosage() + InsulinDosage();
        }

        private double FoodDosage()
        {
            return _variables.carbs / _variables.insulinToCarbRatio;
        }

        private double InsulinDosage()
        {
            if (_variables.bloodSugar < _variables.targetBloodSugar)
                return 0;
            else
                return ((_variables.bloodSugar - _variables.targetBloodSugar) / _variables.correctionFactor);
        }
    }

    public static class CalculationExtensions
    {
        public static double Round(this double input, double nearestPoint)
        {
            int numOfUnits = (int)(input / nearestPoint);
            double remainder = input % nearestPoint;
            double roundedAmount = remainder > nearestPoint / 2 ? nearestPoint : 0;
            return numOfUnits * nearestPoint + roundedAmount;
        }
    }

    public class DosageRounder
    {
        public double Round(double rawDosage)
        {
            return rawDosage.Round(0.5);
        }
    }
}


