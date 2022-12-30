
using CookBook.Recipe.Ingredients;
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

        public static List<Ingredients> GetIngredientsListFromUser(IUserIO userIO)
        {
            IngredientsManager manager = new IngredientsManager();
            
            
            userIO.WriteLine("Nyní se pustíme do vyplňování ingrediencí.");
            userIO.WriteLine("Nejprve zadej, kolik celkově budeš vyplňovat ingrediencí.");

            List<Ingredients> ingredientsList = new List<Ingredients>();

            int ingredientsCount = userIO.GetUserInputInteger();
            int enumIngredientCategoryCount = Enum.GetNames(typeof(IngredientCategory)).Length;

            for (int j = 0; j < ingredientsCount; j++)
            {
                userIO.WriteLine("Zadej číslo kategorie ingredience podle této tabulky:");
                for (int i = 0; i < enumIngredientCategoryCount; i++)
                {
                    userIO.WriteLine($"{i} je {(IngredientCategory)i}");
                }
                int ingredientCategory = userIO.GetUserInputIntegerInGivenRange(0, enumIngredientCategoryCount);

                switch (ingredientCategory)
                {
                    case 0:
                        userIO.WriteLine($"kategorie {ingredientCategory} maso");
                        //Meat newMeat = FillMeatPropertyForIngredientInConsole(ingredientCategory, userIO);
                        Meat newMeat = manager.FillMeatPropertyForIngredientInConsole(ingredientCategory, userIO);
                        ingredientsList.Add(newMeat);
                        //newMeat.GetIngredientsInfo();
                        break;
                    case 1:
                        userIO.WriteLine($"kategorie {ingredientCategory} zelenina");
                        VegetablesAndFruits newVegetablesAndFruits = manager.FillVegetablesAndFruitsPropertyForIngredientInConsole(ingredientCategory, userIO);
                        ingredientsList.Add(newVegetablesAndFruits);
                        //newVegetablesAndFruits.GetIngredientsInfo();
                        break;
                    case 2:
                        userIO.WriteLine($"kategorie {ingredientCategory} mlecny produkt");
                        MilkProduct milkProduct = manager.FillMilkProductPropertyForIngredientInConsole(ingredientCategory, userIO);
                        ingredientsList.Add(milkProduct);
                        //milkProduct.GetIngredientsInfo();
                        break;
                    case 3:
                        userIO.WriteLine($"kategorie {ingredientCategory} ostatni");
                        Others newOthers = manager.FillOthersPropertyForIngredientInConsole(ingredientCategory, userIO);
                        ingredientsList.Add(newOthers);
                        //newOthers.GetIngredientsInfo();
                        break;
                }
                userIO.WriteLine("Skončili jsme s vyplňováním jedné ingredience.");
            }
            return ingredientsList;
        }
    }
}
