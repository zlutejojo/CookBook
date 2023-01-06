

using System;
using System.Collections.Generic;

namespace CookBook
{
    public class Ingredients
    {
        public string Name { get; private set; }
        public string Amount { get; private set; }
        public DateTime Expiration { get; private set; }
        public IngredientCategory IngredientCategory { get; private set; }
        public List<Ingredients> IngredientsLst{ get; private set; }

        //TODO pridat message k vyjimkam a odstranit vypis na konzoli
        public Ingredients(string name, string amount, DateTime expiration, int ingredientCategory)
        {
            if (!(String.IsNullOrEmpty(name)))
            {
                this.Name = name;
            }
            else
            {
                // zavola se jenom v debug, ne v releasu, bude se vypisovat do output okna ve VS
                // System.Diagnostics.Debug.WriteLine nebo logger vlastni (v .NET log4net)
                //throw new NullReferenceException();
                // proc k ni doslo a co s ni
                throw new ArgumentNullException("Není zadané jméno ingredience.");
                

            }

            if (!(String.IsNullOrEmpty(amount)))
            {
                this.Amount = amount;
            }
            else
            {
                throw new ArgumentNullException("Není zadané množství ingredience.");
            }
            
            this.Expiration = expiration;

            var ingredinetCategoryEnumEnumCount = Enum.GetNames(typeof(IngredientCategory)).Length;
            if (!(ingredientCategory < 0 || ingredientCategory > ingredinetCategoryEnumEnumCount))
            {
                this.IngredientCategory = (IngredientCategory)ingredientCategory;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Není zadaný správný rozsah kategorie ingredience.");
            }
            /*
             * ArgumentException, ArgumentNullException, ArgumentOutOfRangeException()
             * kdyz mi toto nestaci, tak z exception vytvorit vlastni vyjimku 
             * NullReferenceException() - toto nepouzivat, to vyhazuje sam net
             * pouzivat message pro exception vzdy 
             */

        }
        public virtual string GetIngredientsInfo()
        {
            return $"Základní informace o ingredienci: {this.Name}, kategorie: {this.IngredientCategory}, množství: {this.Amount}, expiruje: {this.Expiration}.";
        }
    }
}
