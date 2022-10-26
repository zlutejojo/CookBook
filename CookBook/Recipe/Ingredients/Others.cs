using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Recipe.Ingredients;

namespace CookBook.Recipe.Ingredients
{
    public class Others : CookBook.Ingredients
    {
        string Description;
        public Others(string name, DateTime expiration, int categoryNumber, string description) : base(name, expiration, categoryNumber)
        {
            
            if (!(String.IsNullOrWhiteSpace(description)))
            {
                this.Description = description;
            }
            else
            {
                Console.WriteLine("Popis ingredience není nastaven správně.");
            }
        }

        public override void GetIngredientsInfo()
        {
            Console.WriteLine($"Vypisuju informace pro ingredienci: {this.Name} z kategorie {this.IngredientCategory} expiruje {this.Expiration}. Popis: {this.Description}.");
        }
    }
}
