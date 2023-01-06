using System;

namespace CookBook.Recipe.Content
{
    public class Others : Ingredients
    {
        string Description;
        public Others(string name, string amount, DateTime expiration, int categoryNumber, string description) : base(name, amount, expiration, categoryNumber)
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

        public override string GetIngredientsInfo()
        {
            return $"Vypisuju informace pro ingredienci: {this.Name}, kategorie: {this.IngredientCategory}, množství: {this.Amount}, expiruje: {this.Expiration}. Popis: {this.Description}.";
        }
    }
}
