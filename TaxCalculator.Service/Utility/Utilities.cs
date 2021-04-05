using System;
using System.Text.RegularExpressions;

namespace TaxCalculator.Service.Utility
{
    public class Utilities
    {
        public string GetStringInput(string displayText)
        {
            Console.WriteLine(displayText);
            string userInput = Console.ReadLine();

            if (Regex.IsMatch(userInput, "[a-z]|[A-Z]")) return userInput;
            else
            {
                Console.WriteLine("Please enter a valid input !");
                return this.GetStringInput(displayText);
            }
        }

        public int GetIntegerInput(string displayText)
        {
            Console.WriteLine(displayText);
            string userInput = Console.ReadLine();

            if (Regex.IsMatch(userInput, "[0-9]")) return Convert.ToInt32(userInput);
            else
            {
                Console.WriteLine("Please enter a valid input !");
                return this.GetIntegerInput(displayText);
            }
        }
    }
}
