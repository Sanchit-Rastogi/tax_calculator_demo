using System;
using System.Collections.Generic;

namespace TaxCalculator.Model.Constants
{
    public class Constants
    {
        public const string Yes = "Y";
        public const string No = "N";

        public enum ExcemptionType {
            Transport = 1,
            Hostel = 2
        }

        public static List<Excemption> ExcemptionsList = new List<Excemption>()
        {
            new Excemption(){Type = ExcemptionType.Hostel, Amount  = 15000 },
            new Excemption(){Type = ExcemptionType.Transport, Amount  = 10000 },
        };

    }
}
