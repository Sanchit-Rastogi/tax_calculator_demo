using System;
using TaxCalculator.Model.Constants;
using TaxCalculator.Service;
using TaxCalculator.Service.Utility;

namespace TaxCalculator
{
    public class TaxCalculator
    {
        CalculateService CalculateService;
        Utility UtilityService;

        public TaxCalculator()
        {
            Initialize();
        }

        public void Initialize()
        {
            this.CalculateService = new CalculateService();
            this.UtilityService = new Utility();
            MainMenu();
        }

        public void MainMenu()
        {
            Console.WriteLine("Tax Calculator \n");
            int salary = this.UtilityService.GetIntegerInput("Enter your monthly salary for current FY");
            int additionalIncome = this.UtilityService.GetIntegerInput("Enter any additional income for current FY");
            bool isCalculated = this.CalculateService.CalculateTaxAmount(salary, additionalIncome);
            if (isCalculated)
            {
                ShowTaxes();
                ExcemptionsMenu();
            }
        }

        public void ExcemptionsMenu()
        {
            string option = this.UtilityService.GetStringInput("Do you want to submit any tax excemptions ? (Y/N)");
            switch (option.ToUpper())
            {
                case Constants.Yes:
                    Excemptions();

                    break;
                case Constants.No:
                    ShowTaxes();

                    break;
                default:
                    Console.WriteLine("Please select a valid option !");
                    ExcemptionsMenu();

                    break;
            }
        }

        public void Excemptions() {
            Console.WriteLine("Excemptions : - \n" +
                "1. Section 1 - Hostel fees \n" +
                "2. Section 2 - Transportation fees");
            Constants.ExcemptionType option = (Constants.ExcemptionType)this.UtilityService.GetIntegerInput("Please select the excemption type : - \n ");
            int excemptionAmount = this.UtilityService.GetIntegerInput("Enter excemption amount : - ");
            bool isApplied = false;
            switch (option)
            {
                case Constants.ExcemptionType.Hostel:
                    if (excemptionAmount > Constants.ExcemptionsList[0].Amount || excemptionAmount < 1)
                    {
                        Console.WriteLine("Invalid excemption amount");
                        break;
                    }
                    isApplied = this.CalculateService.TaxAfterExcemption(Constants.ExcemptionType.Hostel, excemptionAmount);

                    break;
                case Constants.ExcemptionType.Transport:
                    if(excemptionAmount > Constants.ExcemptionsList[1].Amount || excemptionAmount < 1)
                    {
                        Console.WriteLine("Invalid excemption amount");
                        break;
                    }
                    isApplied = this.CalculateService.TaxAfterExcemption(Constants.ExcemptionType.Transport, excemptionAmount);

                    break;
                default:
                    Console.WriteLine("Enter a valid input : -");
                    Excemptions();

                    break;
            }
            if (isApplied)
                ExcemptionsMenu();
            else
            {
                Console.WriteLine("Excemption not applied");
                ShowTaxes();
            }
            
        }

        public void ShowTaxes()
        {
            Console.WriteLine("\n Your taxes for current FY are :- " +
                "\n Your total income for current FY - Rs " + this.CalculateService.Tax.TotalIncome.ToString() +
                "\n Tax amount - Rs " + this.CalculateService.Tax.Amount.ToString() +
                "\n Tax percentage - " + this.CalculateService.Tax.Percentage.ToString() + "% \n");
        }
    }
}
