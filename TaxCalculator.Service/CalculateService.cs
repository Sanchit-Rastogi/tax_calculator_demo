using System;
using TaxCalculator.Interface;
using TaxCalculator.Model;
using TaxCalculator.Model.Constants;

namespace TaxCalculator.Service
{
    public class CalculateService : ICalculator
    {
        public Tax Tax = new Tax();

        public bool CalculateTaxAmount(int salary, int additionalIncome)
        {
            this.Tax.TotalIncome = (salary * 12) + additionalIncome;

            if (this.Tax.TotalIncome <= 250000)
            {
                this.Tax.Amount = 0;
                this.Tax.Percentage = 0;
            }
            else if (this.Tax.TotalIncome > 250000 && this.Tax.TotalIncome <= 500000)
            {
                this.Tax.Amount = Convert.ToInt32(this.Tax.TotalIncome * 0.05);
                this.Tax.Percentage = 5;
            }
            else if (this.Tax.TotalIncome > 500000 && this.Tax.TotalIncome <= 1000000)
            {
                this.Tax.Amount = Convert.ToInt32(this.Tax.TotalIncome * 0.2);
                this.Tax.Percentage = 20;
            }
            else
            {
                this.Tax.Amount = Convert.ToInt32(this.Tax.TotalIncome * 0.3);
                this.Tax.Percentage = 30;
            }
            
            return true;
        }

        public bool TaxAfterExcemption(Constants.ExcemptionType type, int excemptionAmount)
        {

            Excemption excemption = Tax.Excemptions.Find(ex => ex.Type == type);
            if (excemption != null)
            {
                return false;
            }

            this.Tax.Amount -= excemptionAmount;
            this.Tax.Percentage = decimal.Round(decimal.Divide(Tax.Amount * 100 ,Tax.TotalIncome),2);
            this.Tax.Excemptions.Add(new Excemption() {
                Amount = excemptionAmount,
                Type = type
            });

            return true;
        } 
    
    }
}
