
using System;
using System.Collections.Generic;


namespace CookBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserIOConsole userIOConsole = new UserIOConsole();
            userIOConsole.WriteLine("Ahoj, jsem aplikace na zapisování receptů. Kdykoliv mě budeš chtít ukončit, zadej x.");
            while (true)
            {
                userIOConsole.WriteLine($"Vyber, co budeš dělat, a zadej číslo daného výběru: 1. Přidávat nový recept, 2. Editovat recept, 3. Mazat recept");
                int choosedAction = userIOConsole.GetUserInputIntegerInGivenRange(1,3);
                switch (choosedAction)
                {
                    case 1:
                        MyRecipe.AddNewRecipe();
                        MyRecipe.GetAllRecipeInfo();
                        Console.WriteLine("Skončili jsme s vyplňováním jednoho receptu. Stiskni enter pro pokračování.");
                        Console.ReadLine();
                        break;
                    case 2:
                        userIOConsole.WriteLine("Ještě nic neumím, zkus to později.");
                        break;
                    case 3:
                        userIOConsole.WriteLine("Ještě nic neumím, zkus to později.");
                        break;
                }
            }
        }
    }
}
