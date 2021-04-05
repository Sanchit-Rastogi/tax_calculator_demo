using System;
using TaxCalculator.Model;
using TaxCalculator.Model.Constants;
using TaxCalculator.Service;
using TaxCalculator.Service.Utility;

namespace TaxCalculator
{
    public class TaxCalculator
    {
        CalculateService CalculateService;
        Tax CalculatedTax;
        Tax TaxAfterExcemption;
        Utilities Utilities;

        public TaxCalculator()
        {
            Initialize();
        }

        public void Initialize()
        {
            CalculateService = new CalculateService();
            CalculatedTax = new Tax();
            TaxAfterExcemption = new Tax();
            Utilities = new Utilities();
            MainMenu();
        }

        public void MainMenu()
        {
            int salary = Utilities.GetIntegerInput("Tax Calculator \n Enter your monthly salary for current FY");
            int additionalIncome = Utilities.GetIntegerInput("Enter any additional income for current FY");
            CalculatedTax = CalculateService.CalculateTaxAmount(salary, additionalIncome);
            ShowTaxes(CalculatedTax);
            ExcemptionsMenu();
        }

        public void ExcemptionsMenu()
        {
            string option = Utilities.GetStringInput("Do you want to submit any tax excemptions ? (Y/N)");
            switch (option.ToUpper())
            {
                case "Y":
                    Excemptions();
                    break;
                case "N":
                    ShowTaxes(CalculatedTax);
                    break;
                default:
                    Console.WriteLine("Please select a valid option !");
                    ExcemptionsMenu();
                    break;
            }
        }

        public void Excemptions() {
            Constants.Excemption option = (Constants.Excemption)Utilities.GetIntegerInput("Please select the excemption type : - \n " +
                "1.Section 1 - Hostel fees \n " +
                "2. Section 2 - Transportation fees");
            int excemptionAmount = Utilities.GetIntegerInput("Enter excemption amount : - ");
            switch (option)
            {
                case Constants.Excemption.Hostel:
                    if (excemptionAmount > 15000 || excemptionAmount < 1)
                    {
                        Console.WriteLine("Invalid excemption amount");
                        TaxAfterExcemption = CalculatedTax;
                        break;
                    }
                    TaxAfterExcemption = CalculateService.TaxAfterExcemption(CalculatedTax, Constants.Excemption.Hostel, excemptionAmount);
                    break;
                case Constants.Excemption.Transport:
                    if(excemptionAmount > 10000 || excemptionAmount < 1)
                    {
                        Console.WriteLine("Invalid excemption amount");
                        TaxAfterExcemption = CalculatedTax;
                        break;
                    }
                    TaxAfterExcemption = CalculateService.TaxAfterExcemption(CalculatedTax, Constants.Excemption.Transport, excemptionAmount);
                    break;
                default:
                    Console.WriteLine("Enter a valid input : -");
                    Excemptions();
                    break;
            }
            ShowTaxes(TaxAfterExcemption);
        }

        public void ShowTaxes(Tax tax)
        {
            Console.WriteLine("\n Your taxes for current FY are :- " +
                "\n Your total income for current FY - Rs " + tax.TotalIncome.ToString() +
                "\n Tax amount - Rs " + tax.Amount.ToString() +
                "\n Tax percentage - " + tax.Percentage.ToString() + "% \n");
        }
    }
}
