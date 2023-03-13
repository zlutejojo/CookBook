using CookBook.UserIO;
using System;

namespace CookBook.Recipe.Content
{
    public class MilkProduct : Ingredients, HasProtein, HasSugar
    {
        public int ProteionGram { get; private set; }
        public int FatGram { get; private set; }
        public int SugarGram { get; private set; }

        public MilkProduct(string name, string amount, DateTime expiration, int ingredientCategory, int proteinGram, int fatGram, int sugarGram) : base(name, amount, expiration, ingredientCategory)
        {
            //TODO change myConsole to logging
            MyConsole myConsole = new MyConsole();
            if (proteinGram < 0)
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

            if (sugarGram < 0)
            {
                myConsole.WriteLine("Nenastavil jsi správně množství tuku. Nastavuji hodnotu -1");
                this.SugarGram = -1;
            }
            else
            {
                this.SugarGram = sugarGram;
            }
        }

        public override string GetIngredientsInfo()
        {
            return $"Vypisuju informace pro ingredienci: {this.Name}, kategorie: {this.IngredientCategory}, množství: {this.Amount}, expiruje: {this.Expiration}. Obsažené živiny: tuky: {this.FatGram}g, bílkoviny:{this.ProteionGram} g, cukry: {this.SugarGram}.";
        }
    }
}
