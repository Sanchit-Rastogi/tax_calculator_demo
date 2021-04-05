using System;
using TaxCalculator.Model.Constants;

namespace TaxCalculator.Interface
{
    public interface ICalculator
    {
        public bool CalculateTaxAmount(int salary, int additionalIncome);

        public bool TaxAfterExcemption(Constants.ExcemptionType type, int excemptionAmount);
    }
}
