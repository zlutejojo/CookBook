using CookBook.UserIO;
using System;

namespace CookBook.Recipe.Content
{
    public class Meat : Ingredients
    {
        public int ProteionGram { get; private set; }
        public int FatGram { get; private set; }

        public Meat(string name, string amount, DateTime expiration, int categoryNumber, int proteinGram, int fatGram) : base(name, amount, expiration, categoryNumber)
        {
            //TODO change myConsole to logging
            MyConsole myConsole = new MyConsole();
            if(proteinGram < 0)
            {
                myConsole.WriteLine("Nenastavil jsi správně množství bílkovin. Nastavuji hodnotu -1");
                this.ProteionGram = -1;
            } 
            else 
            {
                this.ProteionGram = proteinGram;
            }

            if (fatGram < 0)
            {
                myConsole.WriteLine("Nenastavil jsi správně množství tuku. Nastavuji hodnotu -1");
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
