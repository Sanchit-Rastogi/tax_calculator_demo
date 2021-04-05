using System;
using TaxCalculator.Model;
using TaxCalculator.Model.Constants;

namespace TaxCalculator.Service
{
    public class CalculateService
    {
        public Tax CalculateTaxAmount(int salary, int additionalIncome)
        {
            int TotalIncome = (salary * 12) + additionalIncome;
            decimal taxPercentage;
            int taxAmount;
            if (TotalIncome <= 250000)
            {
                taxAmount = 0;
                taxPercentage = 0;
            }
            else if (TotalIncome > 250000 && TotalIncome <= 500000)
            {
                taxAmount = Convert.ToInt32(TotalIncome * 0.05);
                taxPercentage = 5;
            }
            else if (TotalIncome > 500000 && TotalIncome <= 1000000)
            {
                taxAmount = Convert.ToInt32(TotalIncome * 0.2);
                taxPercentage = 20;
            }
            else
            {
                taxAmount = Convert.ToInt32(TotalIncome * 0.3);
                taxPercentage = 30;
            }
            Tax calculatedTax = new Tax() {
                Amount = taxAmount,
                Percentage = taxPercentage,
                TotalIncome = TotalIncome
            };
            return calculatedTax;
        }

        public Tax TaxAfterExcemption(Tax calculatedTax, Constants.Excemption type, int excemptionAmount)
        {

            calculatedTax.Amount -= excemptionAmount;
            calculatedTax.Percentage = decimal.Round(decimal.Divide(calculatedTax.Amount * 100 ,calculatedTax.TotalIncome),2);

            return calculatedTax;
        } 
    
    }
}
