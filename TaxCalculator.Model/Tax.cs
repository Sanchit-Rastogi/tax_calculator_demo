using System;
using System.Collections.Generic;

namespace TaxCalculator.Model
{
    public class Tax
    {
        public int Amount { get; set; }

        public decimal Percentage { get; set; }

        public int TotalIncome { get; set; }

        public List<Excemption> Excemptions { get; set; }

        public Tax()
        {
            Excemptions = new List<Excemption>();
        }
    }
}
