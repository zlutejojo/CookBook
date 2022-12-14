using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CookBook
{
    public class Meat : Ingredients
    {
        public int ProteionGram { get; private set; }
        public int FatGram { get; private set; }

        public Meat(string name, string amount, DateTime expiration, int categoryNumber, int proteinGram, int fatGram) : base(name, amount, expiration, categoryNumber)
        {
            if(proteinGram < 0)
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
        }
        
        public override string GetIngredientsInfo()
        {
            return $"Vypisuju informace pro ingredienci: {this.Name}, kategorie: {this.IngredientCategory}, množství: {this.Amount}, expiruje: {this.Expiration}. Obsažené živiny: tuky: {this.FatGram}g, bílkoviny:{this.ProteionGram} g.";
        }
    }
}
