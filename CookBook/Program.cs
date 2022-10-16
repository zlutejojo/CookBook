using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserIOConsole console = new UserIOConsole();
            
            console.WriteLine("Zadej jmeno receptu");
            string name = console.GetUserInputString();
            //TODO udelat vypis na konzoli rozsahu dynamicky
            console.WriteLine("Vyber kategorii receptu. Od 0 do 4.");
            int enumCategoryCount = Enum.GetNames(typeof(Category)).Length;
            int category = console.GetUserInputInteger();
            while (category < 0 | category > enumCategoryCount)
            {
                console.WriteLine("Zadal jsi číslo v nesprávném rozsahu. Opakuj zadání.");
                category = console.GetUserInputInteger();
            }
            Recipe testRecipe = new Recipe(name, new Procedure(), new Ingredients(), category);

            Console.WriteLine("jsem na konci programu");
            Console.ReadLine();
        }
    }
}
