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
            string name = "k";
            
            

            
            //while (true)
            //{
                Console.WriteLine("Zadej jmeno receptu");
                Console.ReadLine();
            if (Console.ReadKey().Key == ConsoleKey.Escape)
            {
                Console.WriteLine("zmackl jsem esc");
            }
            
            //}

            Recipe testRecipe = new Recipe(name, new Procedure(), new Ingredients(), 0);
            
            
            Console.WriteLine("kategorie" + testRecipe.Category);
            Console.ReadLine();

        }
    }
}
