using System;
using static TaxCalculator.Model.Constants.Constants;

namespace TaxCalculator.Model
{
    public class Excemption
    {
        public ExcemptionType Type { get; set; }

        public decimal Amount { get; set; }
    }
}
