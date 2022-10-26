using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    public class VegetablesAndFruits : Ingredients
    {
        public string Vitamin;
        public int FiberGram;
        public VegetablesAndFruits(string name, DateTime expiration, int categoryNumber, string vitamin, int fiberGram) : base(name, expiration, categoryNumber)
        {
            if (!(String.IsNullOrEmpty(vitamin)))
            {
                this.Vitamin = vitamin;
            }
            else
            {
                Console.WriteLine("Popis vitamínů není nastaven správně.");
            }

            if (fiberGram < 0)
            {
                Console.WriteLine("Nenastavil jsi správně množství vlákniny. Nastavuji hodnotu -1");
                this.FiberGram = -1;
            }
            else
            {
                this.FiberGram = fiberGram;
            }
        }

        public override void GetIngredientsInfo()
        {
            Console.WriteLine($"Vypisuju informace pro ingredienci: {this.Name} z kategorie {this.IngredientCategory} expiruje {this.Expiration}. Výživové hodnoty: vitamíny: {this.Vitamin}, vláknina: {this.FiberGram} g.");
        }
    }
}
