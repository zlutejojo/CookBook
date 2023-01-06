using CookBook.Recipe.Work;
using CookBook.UserIO;
using System;
using System.Collections.Generic;
using System.Linq;

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

        //methods for getting information about recipes
        public static void GetRecipeInfo(IUserIO userIO, MyRecipe recipe)
        {
            userIO.WriteLine($"Můj recept {recipe.Name} z kategorie {recipe.RecipeCategory}.");
            recipe.Procedure.GetProcedureInfo();
            foreach (var ingredient in recipe.Ingredients)
            {
                //TODO nahradit string misto vypisu
                Console.WriteLine(ingredient.GetIngredientsInfo());
                Console.WriteLine("jsem v metode getrecipeinfo");
            }
        }

        public static void GetAllRecipeInfo(IUserIO userIO)
        {
            foreach (var recipe in MyRecipe.MyRecipes)
            {
                IngredientsManager.GetRecipeInfo(userIO, recipe);
            }
        }

        public static void GetSpecificRecipeInfo(IUserIO userIO)
        {
            GetTableWithRecipesOnConsole("Vyber podle této tabulky číslo receptu, který chceš zobrazit:", userIO);
            int indexOfRecipe = userIO.GetUserInputIntegerInGivenRange(0, MyRecipe.MyRecipes.Count);
            MyRecipe specificRecipe = MyRecipe.MyRecipes[indexOfRecipe];
            GetRecipeInfo(userIO, specificRecipe);
        }

        public static void GetTableWithRecipesOnConsole(string text, IUserIO userIO)
        {
            int recipesCount = MyRecipe.MyRecipes.Count;
            userIO.WriteLine(text);
            for (int i = 0; i < recipesCount; i++)
            {
                userIO.WriteLine($"{i} pro recept {MyRecipe.MyRecipes[i].Name}.");
            }
        }

        public static void RemoveSpecificRecipe(IUserIO userIO)
        {
            GetTableWithRecipesOnConsole("Vyber podle této tabulky číslo receptu, který chceš smazat:", userIO);
            int indexOfRecipe = userIO.GetUserInputIntegerInGivenRange(0, MyRecipe.MyRecipes.Count);
            MyRecipe.MyRecipes.RemoveAt(indexOfRecipe);
            userIO.WriteLine($"Recept byl smazán.");
        }

        // methods for getting user inputs
        public static int GetRecipeCategoryFromUser(IUserIO userIO)
        {
            int enumRecipeCategoryCount = Enum.GetNames(typeof(RecipeCategory)).Length;
            userIO.WriteLine("Zadej číslo kategorie receptu podle této tabulky:");
            for (int i = 0; i < enumRecipeCategoryCount; i++)
            {
                userIO.WriteLine($"{i} je {(RecipeCategory)i}");
            }
            int recipeCategory = userIO.GetUserInputIntegerInGivenRange(0, enumRecipeCategoryCount - 1);
            return recipeCategory;
        }

        public static string GetRecipeNameFromUser(IUserIO userIO)
        {
            userIO.WriteLine("Zadej jméno receptu");
            string name = userIO.GetUserInputString();
            return name;
        }

        public static MyRecipe AddNewRecipe(IUserIO userIO)
        {
            string recipeName = IngredientsManager.GetRecipeNameFromUser(userIO);
            int recipeCategory = IngredientsManager.GetRecipeCategoryFromUser(userIO);

            List<Ingredients> ingredientsList = IngredientsManager.GetIngredientsListFromUser(userIO);
            Procedure newProcedure = Procedure.GetProcedureFromUser(userIO);
            MyRecipe myRecipe = new MyRecipe(recipeName, recipeCategory, newProcedure, ingredientsList);
            MyRecipe.MyRecipes.Add(myRecipe);
            return myRecipe;
        }

        //TODO da se pouzit neco jako StringComparer.CurrentCultureIgnoreCase
        public static void FindRecipeByPartOfName(string recipeName, IUserIO userIO)
        {
            userIO.WriteLine("Na zadaný dotaz jsem našel tyto recepty: ");
            var results = MyRecipe.MyRecipes.Where(r => r.Name.ToLower().Contains(recipeName.ToLower()));
            foreach (var recipe in results)
            {
                IngredientsManager.GetRecipeInfo(userIO, recipe);
            }
        }

        public static void FindRecipeWithGivenIngredient(string ingredientName, IUserIO userIO)
        {
            userIO.WriteLine("Na zadaný dotaz jsem našel tyto recepty: ");
            foreach (MyRecipe recipe in MyRecipe.MyRecipes)
            {
                var results = recipe.Ingredients.Where(i => i.Name.ToLower().Contains(ingredientName.ToLower()));
                if (results.Count() > 0)
                {
                    IngredientsManager.GetRecipeInfo(userIO, recipe);
                }
            }
        }

        public static void FindRecipeWithTheFastestProcedure(IUserIO userIO)
        {
            var orderedRecipesByTime = MyRecipe.MyRecipes.OrderBy(r => r.Procedure.PreparationTimeInMinutes);
            var groupedOrderedRecipes = orderedRecipesByTime.GroupBy(r => r.Procedure.PreparationTimeInMinutes, r => r.Name, (recipePreparationTimes, recipeNames) => new
            {
                GroupedTime = recipePreparationTimes,
                GroupedName = recipeNames,
            }).ToList();

            var lowestPreparationTimeGroup = groupedOrderedRecipes[0];
            userIO.WriteLine($"Nejkratší čas pro přípravu receptu je {lowestPreparationTimeGroup.GroupedTime}.");

            foreach (var itemName in lowestPreparationTimeGroup.GroupedName)
            {
                userIO.WriteLine($"Název receptu: {itemName}");
            }
        }

        public static void FindRecipeWithTheNearestIngredientExpiration(IUserIO userIO)
        {
            List<DateTime> expirationTheClosestList = new List<DateTime>();
            List<String> nameIngredientWithTheCloesestExpirationList = new List<String>();

            foreach (MyRecipe recipe in MyRecipe.MyRecipes)
            {
                DateTime expirationTheClosest = (recipe.Ingredients.OrderBy(e => e.Expiration).First()).Expiration;
                String nameIngredientWithTheCloesestExpiration = (recipe.Ingredients.OrderBy(e => e.Expiration).First()).Name;

                var items = (recipe.Ingredients.OrderBy(e => e.Expiration));
                /*foreach(var item in items)
                {
                    Console.WriteLine($"prochazim expirace {item.Expiration } {item.Name}");
                }*/

                expirationTheClosestList.Add(expirationTheClosest);
                nameIngredientWithTheCloesestExpirationList.Add(nameIngredientWithTheCloesestExpiration);
            }
            DateTime theClosestExpiration = expirationTheClosestList.Min();
            int indexOfRecipeWithTheClosestExpiration = expirationTheClosestList.IndexOf(theClosestExpiration);
            userIO.WriteLine($"Na zadaný dotaz jsem našel tento recept {MyRecipe.MyRecipes[indexOfRecipeWithTheClosestExpiration].Name} obsahující tuto surovinu: {nameIngredientWithTheCloesestExpirationList[indexOfRecipeWithTheClosestExpiration]} s blížící se expirací: {theClosestExpiration}.");
        }

        public static void FindRecipeWithTheHighestProteionContent(IUserIO userIO)
        {
            List<int> proteinSumList = new List<int>();

            foreach (MyRecipe recipe in MyRecipe.MyRecipes)
            {
                int proteinSumInRecipe = 0;

                foreach (var ingredient in recipe.Ingredients)
                {
                    if (ingredient.GetType() == typeof(Meat))
                    {
                        Meat meatIngredient = (Meat)ingredient;
                        proteinSumInRecipe += meatIngredient.ProteionGram;
                    }

                    if (ingredient.GetType() == typeof(MilkProduct))
                    {
                        MilkProduct milkProductIngredient = (MilkProduct)ingredient;
                        proteinSumInRecipe += milkProductIngredient.ProteionGram;
                    }
                }
                proteinSumList.Add(proteinSumInRecipe);
                proteinSumInRecipe = 0;
            }
            int index = proteinSumList.IndexOf(proteinSumList.Max());
            userIO.WriteLine($"Na zadaný dotaz jsem našel tento recept s nejvyšším obsahem proteinů: {MyRecipe.MyRecipes[index].Name}.");
        }

        public static void RunRecipeApp(IUserIO userIO)
        {

            while (true)
            {
                userIO.WriteLine($"Vyber, co budeš dělat, a zadej číslo daného výběru: 1. Přidávat nový recept, 2. Editovat recept, 3. Mazat recept, 4. Vypsat informace o receptu.");
                int choosedAction = userIO.GetUserInputIntegerInGivenRange(1, 4);
                switch (choosedAction)
                {
                    case 1:
                        IngredientsManager.AddNewRecipe(userIO);
                        IngredientsManager.GetAllRecipeInfo(userIO);
                        Console.WriteLine("Skončili jsme s vyplňováním jednoho receptu. Stiskni enter pro pokračování.");
                        Console.ReadLine();
                        break;
                    case 2:
                        userIO.WriteLine("Ještě nic neumím, zkus to později.");
                        break;
                    case 3:
                        IngredientsManager.RemoveSpecificRecipe(userIO);
                        break;
                    case 4:
                        userIO.WriteLine("jsem ve 4.");
                        IngredientsManager.GetSpecificRecipeInfo(userIO);
                        break;
                }
            }
        }
    }
}
