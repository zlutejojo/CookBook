using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    public class MilkProduct : Ingredients
    {
        public int ProteionGram { get; private set; }
        public int FatGram { get; private set; }
        public int SugarGram { get; private set; }

        public MilkProduct(string name, string amount, DateTime expiration, int ingredientCategory, int proteinGram, int fatGram, int sugarGram) : base(name, amount, expiration, ingredientCategory)
        {
            if (proteinGram < 0)
            {
                Console.WriteLine("Nenastavil jsi správně množství bílkovin. Nastavuji hodnotu -1");
                this.ProteionGram = -1;
            }
            else
            {
                this.ProteionGram = proteinGram;
            }

            if (fatGram < 0)
            {
                Console.WriteLine("Nenastavil jsi správně množství tuku. Nastavuji hodnotu -1");
                this.FatGram = -1;
            }
            else
            {
                this.FatGram = fatGram;
            }

            if (sugarGram < 0)
            {
                Console.WriteLine("Nenastavil jsi správně množství tuku. Nastavuji hodnotu -1");
                this.SugarGram = -1;
            }
            else
            {
                this.SugarGram = sugarGram;
            }
        }

        public override void GetIngredientsInfo()
        {
            Console.WriteLine($"Vypisuju informace pro ingredienci: {this.Name}, kategorie: {this.IngredientCategory}, množství: {this.Amount}, expiruje: {this.Expiration}. Obsažené živiny: tuky: {this.FatGram}g, bílkoviny:{this.ProteionGram} g, cukry: {this.SugarGram}.");
        }
    }
}
