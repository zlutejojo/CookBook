using CookBook.UserIO;
using System;
using System.Collections.Generic;

namespace CookBook.Recipe.Content
{
    public class IngredientsManager
    {

        public IngredientsManager()
        {

        }

        //public int i;
        //public List<Ingredients> ingredientsLst;

        
        
        public Others FillGeneralPropertyForIngredientInConsole(int ingredientCategory, IUserIO userIO)
        {
            userIO.WriteLine("Zadejte název suroviny.");
            string name = userIO.GetUserInputString();

            string amount = GetAmountFromUser(userIO);

            DateTime expiration = DateTime.Now;
            bool isExistingDate = false;
            while (!isExistingDate)
            {
                try
                {
                    userIO.WriteLine("Nyní postupně vyplníme expiraci zboží.");
                    userIO.WriteLine("Nejprve zadejte rok expirace.");

                    //snad zadna potravina nema trvanlivost delsi nez cca 10 let
                    int year = userIO.GetUserInputIntegerInGivenRange(DateTime.Now.Year, DateTime.Now.Year + 10);
                    userIO.WriteLine("Nyní zadejte měsíc expirace.");
                    int month = userIO.GetUserInputIntegerInGivenRange(1, 12);
                    userIO.WriteLine("Nyní zadejte den expirace.");
                    int day = userIO.GetUserInputIntegerInGivenRange(1, 31);

                    expiration = new DateTime(year, month, day);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    userIO.WriteLine($"Zadal jsi neexistující datum, pojďme to zkusit znovu.");
                    continue;
                }
                isExistingDate = true;
            }

            Others generalIngredients = new Others(name, amount, expiration, ingredientCategory, "Nenastaveno.");

            return generalIngredients;
        }

        public Meat FillMeatPropertyForIngredientInConsole(int ingredientCategory, IUserIO userIO)
        {
            Others generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory, userIO);

            userIO.WriteLine("Zadejte množství bílkovin v gramech na 100 g produktu.");
            int proteinGram = userIO.GetUserInputInteger();
            userIO.WriteLine("Zadejte množství tuků v gramech na 100 g produktu.");
            int fatGram = userIO.GetUserInputInteger();

            Meat meat = new Meat(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, proteinGram, fatGram);
            userIO.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}.");
            //meat.GetIngredientsInfo();
            return meat;
        }



        public MilkProduct FillMilkProductPropertyForIngredientInConsole(int ingredientCategory, IUserIO userIO)
        {
            Others generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory, userIO);

            userIO.WriteLine("Zadejte množství bílkovin v gramech na 100 g produktu.");
            int proteinGram = userIO.GetUserInputInteger();
            userIO.WriteLine("Zadejte množství tuků v gramech na 100 g produktu.");
            int fatGram = userIO.GetUserInputInteger();
            userIO.WriteLine("Zadejte množství cukru v gramech na 100 g produktu.");
            int sugarGram = userIO.GetUserInputInteger();

            MilkProduct milkProduct = new MilkProduct(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, proteinGram, fatGram, sugarGram);
            userIO.WriteLine($"Můj mléčný výrobek {milkProduct.Name} {milkProduct.Expiration} {milkProduct.IngredientCategory} {milkProduct.ProteionGram} {milkProduct.FatGram} {milkProduct.SugarGram}.");
            //userIO.WriteLine(milkProduct.GetIngredientsInfo());
            return milkProduct;
        }

        public VegetablesAndFruits FillVegetablesAndFruitsPropertyForIngredientInConsole(int ingredientCategory, IUserIO userIO)
        {
            Others generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory, userIO);

            userIO.WriteLine("Zadejte vitamíny obsažené v přísadě.");
            string vitamin = userIO.GetUserInputString();
            userIO.WriteLine("Zadejte množství vlákniny v gramech ve 100 g produktu.");
            int fiberGram = userIO.GetUserInputInteger();

            VegetablesAndFruits vegetablesAndFruits = new VegetablesAndFruits(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, vitamin, fiberGram);
            //myConsole.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}");
            //vegetablesAndFruits.GetIngredientsInfo();
            return vegetablesAndFruits;
        }

        public Others FillOthersPropertyForIngredientInConsole(int ingredientCategory, IUserIO userIO)
        {
            Others generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory, userIO);

            userIO.WriteLine("Zadejte popis přísady.");
            string description = userIO.GetUserInputString();

            Others others = new Others(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, description);
            return others;
        }

        

        public static string GetAmountFromUser(IUserIO userIO)
        {
            userIO.WriteLine("Nyní vyplníme množství suroviny. Vyber, zda budeš zadávat surovinu v gramech, mililitrech nebo v kusech. Pro gramy zadej 1, pro mililitry 2, pro kusy 3.");
            int amountUnit = userIO.GetUserInputIntegerInGivenRange(1, 3);
            userIO.WriteLine("Vyplň množství suroviny.");
            int amount = userIO.GetUserInputInteger();
            string amountStr = "";
            switch (amountUnit)
            {
                case 1:
                    amountStr = amount + " g";
                    break;
                case 2:
                    amountStr = amount + " ml";
                    break;
                case 3:
                    amountStr = amount + " ks";
                    break;
            }
            return amountStr;
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
