using CookBook.UserIO;
using System;

namespace CookBook.Recipe.Content
{
    public class VegetablesAndFruits : Ingredients
    {
        public string Vitamin;
        public int FiberGram;
        public VegetablesAndFruits(string name, string amount, DateTime expiration, int categoryNumber, string vitamin, int fiberGram) : base(name, amount, expiration, categoryNumber)
        {

            //TODO change myConsole to logging
            MyConsole myConsole = new MyConsole();
            if (!(String.IsNullOrEmpty(vitamin)))
            {
                this.Vitamin = vitamin;
            }
            else
            {
                myConsole.WriteLine("Popis vitamínů není nastaven správně.");
            }

            if (fiberGram < 0)
            {
                myConsole.WriteLine("Nenastavil jsi správně množství vlákniny. Nastavuji hodnotu -1");
                this.FiberGram = -1;
            }
            else
            {
                this.FiberGram = fiberGram;
            }
        }

        public override string GetIngredientsInfo()
        {
            return $"Vypisuju informace pro ingredienci: {this.Name}, kategorie: {this.IngredientCategory}, množství: {this.Amount}, expiruje: {this.Expiration}. Výživové hodnoty: vitamíny: {this.Vitamin}, vláknina: {this.FiberGram} g.";
        }
    }
}
