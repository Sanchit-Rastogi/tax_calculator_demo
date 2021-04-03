using System;

namespace TaxCalculator.Model
{
    public class Tax
    {
        public int Amount { get; set; }

        public decimal Percentage { get; set; }

        public int TotalIncome { get; set; }
    }
}
