using CookBook.Recipe.Ingredients;
using System;
using System.Collections.Generic;

namespace CookBook
{
    public abstract class Ingredients
    {
        public string Name { get; private set; }
        public DateTime Expiration { get; private set; }
        public IngredientCategory IngredientCategory { get; private set; }
        private static readonly UserIOConsole userIOConsole = new UserIOConsole();

        public Ingredients(string name, DateTime expiration, int ingredientCategory)
        {
            if (!(String.IsNullOrEmpty(name)))
            {
                this.Name = name;
            }
            else
            {
                userIOConsole.WriteLine("Jmeno ingredience neni spravne nastaveno.");
            }
            this.Expiration = expiration;

            var ingredinetCategoryEnumEnumCount = Enum.GetNames(typeof(IngredientCategory)).Length;
            if (!(ingredientCategory < 0 || ingredientCategory > ingredinetCategoryEnumEnumCount))
            {
                this.IngredientCategory = (IngredientCategory)ingredientCategory;
            }
            else
            {
                userIOConsole.WriteLine("Kategorie neni spravne nastavena.");
            }

        }
        public virtual void GetIngredientsInfo()
        {
            userIOConsole.WriteLine($"Základní informace o ingredienci: {this.Name} z kategorie {this.IngredientCategory} expiruje {this.Expiration}.");
        }

        public static Ingredients FillGeneralPropertyForIngredientInConsole(int ingredientCategory)
        {
            userIOConsole.WriteLine("Zadejte název suroviny.");
            string name = userIOConsole.GetUserInputString();
            userIOConsole.WriteLine("Nyní postupně vyplníme expiraci zboží.");
            userIOConsole.WriteLine("Nejprve zadejte rok expirace.");

            //snad zadna potravina nema trvanlivost delsi nez cca 10 let
            int year = userIOConsole.GetUserInputIntegerInGivenRange(DateTime.Now.Year, DateTime.Now.Year + 10);
            userIOConsole.WriteLine("Nyní zadejte měsíc expirace.");
            int month = userIOConsole.GetUserInputIntegerInGivenRange(1, 12);
            userIOConsole.WriteLine("Nyní zadejte den expirace.");
            int day = userIOConsole.GetUserInputIntegerInGivenRange(1, 31);
            DateTime expiration = new DateTime(year, month, day);

            userIOConsole.WriteLine("datum je " + expiration);

            Ingredients generalIngredients = new Others(name, expiration, ingredientCategory, "Nenastaveno.");

            return generalIngredients;
        }

        public static Meat FillMeatPropertyForIngredientInConsole(int ingredientCategory)
        {
            Ingredients generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            userIOConsole.WriteLine("Zadejte bílkoviny v gramech.");
            int proteinGram = userIOConsole.GetUserInputInteger();
            userIOConsole.WriteLine("Zadejte tuky v gramech.");
            int fatGram = userIOConsole.GetUserInputInteger();

            Meat meat = new Meat(generalIngredient.Name, generalIngredient.Expiration, ingredientCategory, proteinGram, fatGram);
            userIOConsole.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}");
            //meat.GetIngredientsInfo();
            return meat;
        }

        public static VegetablesAndFruits FillVegetablesAndFruitsPropertyForIngredientInConsole(int ingredientCategory)
        {
            Ingredients generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            userIOConsole.WriteLine("Zadejte vitamíny obsažené v přísadě.");
            string vitamin = userIOConsole.GetUserInputString();
            userIOConsole.WriteLine("Zadejte vlákninu v gramech.");
            int fiberGram = userIOConsole.GetUserInputInteger();

            VegetablesAndFruits vegetablesAndFruits = new VegetablesAndFruits(generalIngredient.Name, generalIngredient.Expiration, ingredientCategory, vitamin, fiberGram);
            //myConsole.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}");
            //vegetablesAndFruits.GetIngredientsInfo();
            return vegetablesAndFruits;
        }

        public static CookBook.Recipe.Ingredients.Others FillOthersPropertyForIngredientInConsole(int ingredientCategory)
        {
            Ingredients generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            userIOConsole.WriteLine("Zadejte popis přísady.");
            string description = userIOConsole.GetUserInputString();

            CookBook.Recipe.Ingredients.Others others = new Others(generalIngredient.Name, generalIngredient.Expiration, ingredientCategory, description);
            return others;
        }

        public static List<Ingredients> GetIngredientsListFromUser()
        {
            userIOConsole.WriteLine("Nyní se pustíme do vyplňování ingredinecí.");
            userIOConsole.WriteLine("Nejprve zadej, kolik celkově budeš vyplňovat ingrediencí.");

            List<Ingredients> ingredientsList = new List<Ingredients>();

            int ingredientsCount = userIOConsole.GetUserInputInteger();
            int enumIngredientCategoryCount = Enum.GetNames(typeof(IngredientCategory)).Length;

            for (int j = 0; j < ingredientsCount; j++)
            {
                userIOConsole.WriteLine("Zadej číslo kategorie ingredience podle této tabulky:");
                for (int i = 0; i < enumIngredientCategoryCount; i++)
                {
                    userIOConsole.WriteLine($"{i} je {(IngredientCategory)i}");
                }
                int ingredientCategory = userIOConsole.GetUserInputIntegerInGivenRange(0, enumIngredientCategoryCount);

                switch (ingredientCategory)
                {
                    case 0:
                        userIOConsole.WriteLine($"kategorie {ingredientCategory} maso");
                        Meat newMeat = FillMeatPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(newMeat);
                        //newMeat.GetIngredientsInfo();
                        break;
                    case 1:
                        userIOConsole.WriteLine("kategorie 1 zelenina");
                        VegetablesAndFruits newVegetablesAndFruits = Ingredients.FillVegetablesAndFruitsPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(newVegetablesAndFruits);
                        //newVegetablesAndFruits.GetIngredientsInfo();
                        break;
                    case 2:
                        userIOConsole.WriteLine("kategorie 2 ostatni");
                        Others newOthers = Ingredients.FillOthersPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(newOthers);
                        //newOthers.GetIngredientsInfo();
                        break;
                }
                //TODO vyresit proc se mi vypisuje nekde tady info o ingrediencich
                userIOConsole.WriteLine("Skončili jsme s vyplňováním jedné ingredience.");
            }
            return ingredientsList;
        }
    }
}
