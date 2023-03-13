using CookBook.UserIO;
using System;

namespace CookBook.Recipe.Content
{
    public class Others : Ingredients, HasProtein

    {
        public int ProteionGram { get; private set; }
        string Description;
        public Others(string name, string amount, DateTime expiration, int categoryNumber, int proteinGram, string description) : base(name, amount, expiration, categoryNumber)
        {

            //TODO change myConsole to logging
            MyConsole myConsole = new MyConsole(); 
            if (!(String.IsNullOrWhiteSpace(description)))
            {
                this.Description = description;
            }
            else
            {
                myConsole.WriteLine("Popis ingredience není nastaven správně.");
            }

            if (ProteionGram < 0)
            {
                myConsole.WriteLine("Nenastavil jsi správně množství bílkovin. Nastavuji hodnotu -1");
                this.ProteionGram = -1;
            }
            else
            {
                this.ProteionGram = proteinGram;
            }
        }

        public override string GetIngredientsInfo()
        {
            return $"Vypisuju informace pro ingredienci: {this.Name}, kategorie: {this.IngredientCategory}, množství: {this.Amount}, expiruje: {this.Expiration}. Obsažené živiny: bílkoviny: {this.ProteionGram} g. Popis: {this.Description}.";
        }
    }
}
