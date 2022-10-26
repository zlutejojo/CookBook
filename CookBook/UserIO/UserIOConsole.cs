using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    internal class UserIOConsole : IUserIO
    {
        public override void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
        public override int GetUserInputInteger()
        {
            int number;
            string userInput = this.GetUserInputString();
            while (!int.TryParse(userInput, out number))
            {
                this.WriteLine("Zadal jsi číslo v nesprávném formátu, prosím zadej ho znovu.");
                userInput = this.GetUserInputString();
            }
            return number;
        }

        public override string GetUserInputString()
        {
            string input = Console.ReadLine().Trim(); ;
            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Zadal jsi neplatný vstup. Opakuj zadání.");
                input = Console.ReadLine().Trim();
            }
            return input;
        }
        
        public int GetUserInputIntegerInGivenRange(int lowerLimit, int upperLimit)
        {
            int numberToCheck = this.GetUserInputInteger();
            
            while (numberToCheck < lowerLimit | numberToCheck > upperLimit)
            {
                Console.WriteLine("Zadal jsi číslo v nesprávném rozsahu. Opakuj zadání.");
                numberToCheck = this.GetUserInputInteger();
            }
            return numberToCheck;
        }
        //TODO zapojit kontrolu, jestli uzivatel chce ukoncit program
        public override bool CheckIfUserTerminateApplication()
        {
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Zmackl jsem esc");
                return true;
            }
            return false;
        }

    }
}
