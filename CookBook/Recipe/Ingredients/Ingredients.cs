
using System;
using System.Collections.Generic;

namespace CookBook
{
    public abstract class Ingredients
    {
        public string Name { get; private set; }
        public string Amount { get; private set; }
        public DateTime Expiration { get; private set; }
        public IngredientCategory IngredientCategory { get; private set; }
        private static readonly UserIOConsole userIOConsole = new UserIOConsole();

        public Ingredients(string name, string amount, DateTime expiration, int ingredientCategory)
        {
            if (!(String.IsNullOrEmpty(name)))
            {
                this.Name = name;
            }
            else
            {
                userIOConsole.WriteLine("Jméno ingredience není spravně nastavené.");
            }

            if (!(String.IsNullOrEmpty(name)))
            {
                this.Amount = amount;
            }
            else
            {
                userIOConsole.WriteLine("Množství ingredience není spravně nastavené.");
            }
            

            this.Expiration = expiration;

            var ingredinetCategoryEnumEnumCount = Enum.GetNames(typeof(IngredientCategory)).Length;
            if (!(ingredientCategory < 0 || ingredientCategory > ingredinetCategoryEnumEnumCount))
            {
                this.IngredientCategory = (IngredientCategory)ingredientCategory;
            }
            else
            {
                userIOConsole.WriteLine("Kategorie není spravně nastavená.");
            }

        }
        public virtual void GetIngredientsInfo()
        {
            userIOConsole.WriteLine($"Základní informace o ingredienci: {this.Name}, kategorie: {this.IngredientCategory}, množství: {this.Amount}, expiruje: {this.Expiration}.");
        }

        public static Ingredients FillGeneralPropertyForIngredientInConsole(int ingredientCategory)
        {
            userIOConsole.WriteLine("Zadejte název suroviny.");
            string name = userIOConsole.GetUserInputString();

            string amount = Ingredients.GetAmountFromUser();

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

            Ingredients generalIngredients = new Others(name, amount, expiration, ingredientCategory, "Nenastaveno.");

            return generalIngredients;
        }

        public static Meat FillMeatPropertyForIngredientInConsole(int ingredientCategory)
        {
            Ingredients generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            userIOConsole.WriteLine("Zadejte množství bílkovin v gramech na 100 g produktu.");
            int proteinGram = userIOConsole.GetUserInputInteger();
            userIOConsole.WriteLine("Zadejte množství tuků v gramech na 100 g produktu.");
            int fatGram = userIOConsole.GetUserInputInteger();

            Meat meat = new Meat(generalIngredient.Name, generalIngredient.Amount,generalIngredient.Expiration, ingredientCategory, proteinGram, fatGram);
            userIOConsole.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}");
            //meat.GetIngredientsInfo();
            return meat;
        }

        public static VegetablesAndFruits FillVegetablesAndFruitsPropertyForIngredientInConsole(int ingredientCategory)
        {
            Ingredients generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            userIOConsole.WriteLine("Zadejte vitamíny obsažené v přísadě.");
            string vitamin = userIOConsole.GetUserInputString();
            userIOConsole.WriteLine("Zadejte množství vlákniny v gramech ve 100 g produktu.");
            int fiberGram = userIOConsole.GetUserInputInteger();

            VegetablesAndFruits vegetablesAndFruits = new VegetablesAndFruits(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, vitamin, fiberGram);
            //myConsole.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}");
            //vegetablesAndFruits.GetIngredientsInfo();
            return vegetablesAndFruits;
        }

        public static Others FillOthersPropertyForIngredientInConsole(int ingredientCategory)
        {
            Ingredients generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            userIOConsole.WriteLine("Zadejte popis přísady.");
            string description = userIOConsole.GetUserInputString();

            Others others = new Others(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, description);
            return others;
        }

        public static List<Ingredients> GetIngredientsListFromUser()
        {
            userIOConsole.WriteLine("Nyní se pustíme do vyplňování ingrediencí.");
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
                userIOConsole.WriteLine("Skončili jsme s vyplňováním jedné ingredience.");
            }
            return ingredientsList;
        }



        public static string GetAmountFromUser()
        {
            userIOConsole.WriteLine("Nyní vyplníme množství suroviny. Vyber, zda budeš zadávat surovinu v gramech nebo v kusech. Pro gramy zadej 1, pro kusy 2.");
            int amountUnit = userIOConsole.GetUserInputIntegerInGivenRange(1, 2);
            userIOConsole.WriteLine("Vyplň množství suroviny.");
            int amount = userIOConsole.GetUserInputInteger();
            string amountStr = "";
            switch (amountUnit)
            {
                case 1:
                    amountStr = amount + " g";
                    break;
                case 2:
                    amountStr = amount + " ks";
                    break;
            }
            return amountStr;
        }
    }
}
