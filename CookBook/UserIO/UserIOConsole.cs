using System;

namespace CookBook.UserIO
{
    public class UserIOConsole : IUserIO
    {
        MyConsole myConsole = new MyConsole();
        public void WriteLine(string text)
        {
            myConsole.WriteLine(text);
        }

        public string ReadLine()
        {
            return myConsole.ReadLine();
        }
        public int GetUserInputInteger()
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

        public string GetUserInputString()
        {
            string input = myConsole.ReadLine().Trim();
            if (this.CheckIfInputIsX(input))
            {
                this.ExitApplication();
            }
            while (String.IsNullOrEmpty(input))
            {
                myConsole.WriteLine("Zadal jsi neplatný vstup. Opakuj zadání.");
                input = myConsole.ReadLine().Trim();
                if (this.CheckIfInputIsX(input))
                {
                    this.ExitApplication();
                }
            }
            return input;
        }
        
        public int GetUserInputIntegerInGivenRange(int lowerLimit, int upperLimit)
        {
            int numberToCheck = this.GetUserInputInteger();

            while (numberToCheck < lowerLimit | numberToCheck > upperLimit)
            {
                myConsole.WriteLine("Zadal jsi číslo v nesprávném rozsahu. Opakuj zadání.");
                numberToCheck = this.GetUserInputInteger();
            }
            return numberToCheck;
        }
        //TODO zkusit pouzit readkey
        public bool CheckIfUserTerminateApplication()
        {
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                myConsole.WriteLine("Zmackl jsem esc");
                return true;
            }
            return false;
        }

        public bool CheckIfInputIsX(string text)
        {
            return text == "X" || text == "x";
        }

        public void ExitApplication()
        {
            System.Environment.Exit(0);
        }
    }
}
