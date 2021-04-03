using System;
using TaxCalculator.Model;
using TaxCalculator.Model.Constants;
using TaxCalculator.Service;

namespace TaxCalculator
{
    public class TaxCalculator
    {

        CalculateService CalculateService = new CalculateService();
        Tax CalculatedTax = new Tax();
        Tax TaxAfterExcemption = new Tax();

        public TaxCalculator()
        {
            Initialize();
        }

        public void Initialize()
        {
            MainMenu();
        }

        public void MainMenu()
        {
            Console.WriteLine("Tax Calculator \n ");
            Console.WriteLine("Enter your monthly salary for current FY");
            int salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter any additional income for current FY");
            int additionalIncome = Convert.ToInt32(Console.ReadLine());
            CalculatedTax = CalculateService.CalculateTaxAmount(salary, additionalIncome);
            ShowTaxes(CalculatedTax);
            ExcemptionsMenu();
        }

        public void ExcemptionsMenu()
        {
            Console.WriteLine("Do you want to submit any tax excemptions ? (Y/N)");
            string option = Console.ReadLine();
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
            Console.WriteLine("Please select the excemption type : -");
            Console.WriteLine("1. Section 1 - Hostel fees");
            Console.WriteLine("2. Section 2 - Transportation fees");
            Constants.Excemption option = (Constants.Excemption)Convert.ToInt32(Console.ReadLine());
            int excemptionAmount = 0;
            switch (option)
            {
                case Constants.Excemption.Hostel:
                    Console.WriteLine("Enter excemption amount : - ");
                    excemptionAmount = Convert.ToInt32(Console.ReadLine());
                    if (excemptionAmount > 15000 && excemptionAmount < 1)
                    {
                        Console.WriteLine("Invalid excemption amount");
                        TaxAfterExcemption = CalculatedTax;
                        break;
                    }
                    TaxAfterExcemption = CalculateService.TaxAfterExcemption(CalculatedTax, Constants.Excemption.Hostel, excemptionAmount);
                    break;
                case Constants.Excemption.Transport:
                    Console.WriteLine("Enter excemption amount : - ");
                    excemptionAmount = Convert.ToInt32(Console.ReadLine());
                    if(excemptionAmount > 10000 && excemptionAmount < 1)
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
            Console.WriteLine("\n Your taxes for current FY are :- \n");
            Console.WriteLine("Your total income for current FY - Rs " + tax.TotalIncome.ToString());
            Console.WriteLine("Tax amount - Rs " + tax.Amount.ToString());
            Console.WriteLine("Tax percentage - " + tax.Percentage.ToString() + "%");
        }
    }
}
