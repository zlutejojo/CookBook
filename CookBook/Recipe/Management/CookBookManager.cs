using CookBook.Recipe.Work;
using CookBook.UserIO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.Recipe.Content
{
    public class CookBookManager
    {
        public IUserIO UserIO { get; private set; }
        public CookBookManager(IUserIO userIO)
        {

            if (userIO == null)
            {
                throw new ArgumentNullException("Nezadali jste IUserIO.");
            }
            
            this.UserIO = userIO;
        }

        public void RunRecipeApp()
        {
            while (true)
            {
                UserIO.WriteLine($"Vyber, co budeš dělat, a zadej číslo daného výběru: 1. Přidávat nový recept, 2. Editovat recept, 3. Mazat recept, 4. Vypsat informace o receptu.");
                int choosedAction = UserIO.GetUserInputIntegerInGivenRange(1, 4);
                switch (choosedAction)
                {
                    case 1:
                        AddNewRecipe();
                        UserIO.WriteLine("Skončili jsme s vyplňováním jednoho receptu. Stiskni enter pro pokračování.");
                        UserIO.ReadLine();
                        break;
                    case 2:
                        UserIO.WriteLine("Ještě nic neumím, zkus to později.");
                        break;
                    case 3:
                        RemoveSpecificRecipe();
                        break;
                    case 4:
                        GetSpecificRecipeInfo();
                        break;
                }
            }
        }


        public Others FillGeneralPropertyForIngredientInConsole(int ingredientCategory)
        {
            UserIO.WriteLine("Zadejte název suroviny.");
            string name = UserIO.GetUserInputString();

            string amount = GetAmountFromUser();

            DateTime expiration = DateTime.Now;
            bool isExistingDate = false;
            while (!isExistingDate)
            {
                try
                {
                    UserIO.WriteLine("Nyní postupně vyplníme expiraci zboží.");
                    UserIO.WriteLine("Nejprve zadejte rok expirace.");

                    //snad zadna potravina nema trvanlivost delsi nez cca 10 let
                    int year = UserIO.GetUserInputIntegerInGivenRange(DateTime.Now.Year, DateTime.Now.Year + 10);
                    UserIO.WriteLine("Nyní zadejte měsíc expirace.");
                    int month = UserIO.GetUserInputIntegerInGivenRange(1, 12);
                    UserIO.WriteLine("Nyní zadejte den expirace.");
                    int day = UserIO.GetUserInputIntegerInGivenRange(1, 31);

                    expiration = new DateTime(year, month, day);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    UserIO.WriteLine($"Zadal jsi neexistující datum, pojďme to zkusit znovu.");
                    continue;
                }
                isExistingDate = true;
            }

            Others generalIngredients = new Others(name, amount, expiration, ingredientCategory, "Nenastaveno.");

            return generalIngredients;
        }
        public Meat FillMeatPropertyForIngredientInConsole(int ingredientCategory)
        {
            Others generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            UserIO.WriteLine("Zadejte množství bílkovin v gramech na 100 g produktu.");
            int proteinGram = UserIO.GetUserInputInteger();
            UserIO.WriteLine("Zadejte množství tuků v gramech na 100 g produktu.");
            int fatGram = UserIO.GetUserInputInteger();

            Meat meat = new Meat(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, proteinGram, fatGram);
            UserIO.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}.");
            //meat.GetIngredientsInfo();
            return meat;
        }

        public MilkProduct FillMilkProductPropertyForIngredientInConsole(int ingredientCategory)
        {
            Others generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            UserIO.WriteLine("Zadejte množství bílkovin v gramech na 100 g produktu.");
            int proteinGram = UserIO.GetUserInputInteger();
            UserIO.WriteLine("Zadejte množství tuků v gramech na 100 g produktu.");
            int fatGram = UserIO.GetUserInputInteger();
            UserIO.WriteLine("Zadejte množství cukru v gramech na 100 g produktu.");
            int sugarGram = UserIO.GetUserInputInteger();

            MilkProduct milkProduct = new MilkProduct(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, proteinGram, fatGram, sugarGram);
            UserIO.WriteLine($"Můj mléčný výrobek {milkProduct.Name} {milkProduct.Expiration} {milkProduct.IngredientCategory} {milkProduct.ProteionGram} {milkProduct.FatGram} {milkProduct.SugarGram}.");
            //userIO.WriteLine(milkProduct.GetIngredientsInfo());
            return milkProduct;
        }

        public VegetablesAndFruits FillVegetablesAndFruitsPropertyForIngredientInConsole(int ingredientCategory)
        {
            Others generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            UserIO.WriteLine("Zadejte vitamíny obsažené v přísadě.");
            string vitamin = UserIO.GetUserInputString();
            UserIO.WriteLine("Zadejte množství vlákniny v gramech ve 100 g produktu.");
            int fiberGram = UserIO.GetUserInputInteger();

            VegetablesAndFruits vegetablesAndFruits = new VegetablesAndFruits(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, vitamin, fiberGram);
            //myConsole.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}");
            //vegetablesAndFruits.GetIngredientsInfo();
            return vegetablesAndFruits;
        }

        public Others FillOthersPropertyForIngredientInConsole(int ingredientCategory)
        {
            Others generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            UserIO.WriteLine("Zadejte popis přísady.");
            string description = UserIO.GetUserInputString();

            Others others = new Others(generalIngredient.Name, generalIngredient.Amount, generalIngredient.Expiration, ingredientCategory, description);
            return others;
        }

        public string GetAmountFromUser()
        {
            UserIO.WriteLine("Nyní vyplníme množství suroviny. Vyber, zda budeš zadávat surovinu v gramech, mililitrech nebo v kusech. Pro gramy zadej 1, pro mililitry 2, pro kusy 3.");
            int amountUnit = UserIO.GetUserInputIntegerInGivenRange(1, 3);
            UserIO.WriteLine("Vyplň množství suroviny.");
            int amount = UserIO.GetUserInputInteger();
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

        public List<Ingredients> GetIngredientsListFromUser()
        {

            UserIO.WriteLine("Nyní se pustíme do vyplňování ingrediencí.");
            UserIO.WriteLine("Nejprve zadej, kolik celkově budeš vyplňovat ingrediencí.");

            List<Ingredients> ingredientsList = new List<Ingredients>();

            int ingredientsCount = UserIO.GetUserInputInteger();
            int enumIngredientCategoryCount = Enum.GetNames(typeof(IngredientCategory)).Length;

            for (int j = 0; j < ingredientsCount; j++)
            {
                UserIO.WriteLine("Zadej číslo kategorie ingredience podle této tabulky:");
                for (int i = 0; i < enumIngredientCategoryCount; i++)
                {
                    UserIO.WriteLine($"{i} je {(IngredientCategory)i}");
                }
                int ingredientCategory = UserIO.GetUserInputIntegerInGivenRange(0, enumIngredientCategoryCount);

                switch (ingredientCategory)
                {
                    case 0:
                        UserIO.WriteLine($"kategorie {ingredientCategory} maso");
                        //Meat newMeat = FillMeatPropertyForIngredientInConsole(ingredientCategory, userIO);
                        Meat newMeat = FillMeatPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(newMeat);
                        //newMeat.GetIngredientsInfo();
                        break;
                    case 1:
                        UserIO.WriteLine($"kategorie {ingredientCategory} zelenina");
                        VegetablesAndFruits newVegetablesAndFruits = FillVegetablesAndFruitsPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(newVegetablesAndFruits);
                        //newVegetablesAndFruits.GetIngredientsInfo();
                        break;
                    case 2:
                        UserIO.WriteLine($"kategorie {ingredientCategory} mlecny produkt");
                        MilkProduct milkProduct = FillMilkProductPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(milkProduct);
                        //milkProduct.GetIngredientsInfo();
                        break;
                    case 3:
                        UserIO.WriteLine($"kategorie {ingredientCategory} ostatni");
                        Others newOthers = FillOthersPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(newOthers);
                        //newOthers.GetIngredientsInfo();
                        break;
                }
                UserIO.WriteLine("Skončili jsme s vyplňováním jedné ingredience.");
            }
            return ingredientsList;
        }

        //methods for getting information about recipes
        public void GetRecipeInfo(MyRecipe recipe)
        {
            UserIO.WriteLine($"Můj recept {recipe.Name} z kategorie {recipe.RecipeCategory}.");
            recipe.Procedure.GetProcedureInfo();
            foreach (var ingredient in recipe.Ingredients)
            {
                //TODO nahradit string misto vypisu
                UserIO.WriteLine(ingredient.GetIngredientsInfo());
            }
        }

        public void GetAllRecipeInfo()
        {
            foreach (var recipe in MyRecipe.MyRecipes)
            {
                GetRecipeInfo(recipe);
            }
        }

        public void GetSpecificRecipeInfo()
        {
            GetTableWithRecipesOnConsole("Vyber podle této tabulky číslo receptu, který chceš zobrazit:");
            int indexOfRecipe = UserIO.GetUserInputIntegerInGivenRange(0, MyRecipe.MyRecipes.Count);
            MyRecipe specificRecipe = MyRecipe.MyRecipes[indexOfRecipe];
            GetRecipeInfo(specificRecipe);
        }

        public void GetTableWithRecipesOnConsole(string text)
        {
            int recipesCount = MyRecipe.MyRecipes.Count;
            UserIO.WriteLine(text);
            for (int i = 0; i < recipesCount; i++)
            {
                UserIO.WriteLine($"{i} pro recept {MyRecipe.MyRecipes[i].Name}.");
            }
        }

        public void RemoveSpecificRecipe()
        {
            GetTableWithRecipesOnConsole("Vyber podle této tabulky číslo receptu, který chceš smazat:");
            int indexOfRecipe = UserIO.GetUserInputIntegerInGivenRange(0, MyRecipe.MyRecipes.Count);
            MyRecipe.MyRecipes.RemoveAt(indexOfRecipe);
            UserIO.WriteLine($"Recept byl smazán.");
        }

        // methods for getting user inputs
        public int GetRecipeCategoryFromUser()
        {
            int enumRecipeCategoryCount = Enum.GetNames(typeof(RecipeCategory)).Length;
            UserIO.WriteLine("Zadej číslo kategorie receptu podle této tabulky:");
            for (int i = 0; i < enumRecipeCategoryCount; i++)
            {
                UserIO.WriteLine($"{i} je {(RecipeCategory)i}");
            }
            int recipeCategory = UserIO.GetUserInputIntegerInGivenRange(0, enumRecipeCategoryCount - 1);
            return recipeCategory;
        }

        public string GetRecipeNameFromUser()
        {
            UserIO.WriteLine("Zadej jméno receptu");
            string name = UserIO.GetUserInputString();
            return name;
        }

        public MyRecipe AddNewRecipe()
        {
            string recipeName = GetRecipeNameFromUser();
            int recipeCategory = GetRecipeCategoryFromUser();

            List<Ingredients> ingredientsList = GetIngredientsListFromUser();
            Procedure newProcedure = GetProcedureFromUser();
            MyRecipe myRecipe = new MyRecipe(recipeName, recipeCategory, newProcedure, ingredientsList);
            MyRecipe.MyRecipes.Add(myRecipe);
            return myRecipe;
        }

        //TODO da se pouzit neco jako StringComparer.CurrentCultureIgnoreCase
        public void FindRecipeByPartOfName(string recipeName)
        {
            UserIO.WriteLine("Na zadaný dotaz jsem našel tyto recepty: ");
            var results = MyRecipe.MyRecipes.Where(r => r.Name.ToLower().Contains(recipeName.ToLower()));
            foreach (var recipe in results)
            {
                GetRecipeInfo(recipe);
            }
        }

        public void FindRecipeWithGivenIngredient(string ingredientName)
        {
            UserIO.WriteLine("Na zadaný dotaz jsem našel tyto recepty: ");
            foreach (MyRecipe recipe in MyRecipe.MyRecipes)
            {
                var results = recipe.Ingredients.Where(i => i.Name.ToLower().Contains(ingredientName.ToLower()));
                if (results.Count() > 0)
                {
                    GetRecipeInfo(recipe);
                }
            }
        }

        public void FindRecipeWithTheFastestProcedure()
        {
            var orderedRecipesByTime = MyRecipe.MyRecipes.OrderBy(r => r.Procedure.PreparationTimeInMinutes);
            var groupedOrderedRecipes = orderedRecipesByTime.GroupBy(r => r.Procedure.PreparationTimeInMinutes, r => r.Name, (recipePreparationTimes, recipeNames) => new
            {
                GroupedTime = recipePreparationTimes,
                GroupedName = recipeNames,
            }).ToList();

            var lowestPreparationTimeGroup = groupedOrderedRecipes[0];
            UserIO.WriteLine($"Nejkratší čas pro přípravu receptu je {lowestPreparationTimeGroup.GroupedTime}.");

            foreach (var itemName in lowestPreparationTimeGroup.GroupedName)
            {
                UserIO.WriteLine($"Název receptu: {itemName}");
            }
        }

        public void FindRecipeWithTheNearestIngredientExpiration()
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
                    UserIO.WriteLine($"prochazim expirace {item.Expiration } {item.Name}");
                }*/

                expirationTheClosestList.Add(expirationTheClosest);
                nameIngredientWithTheCloesestExpirationList.Add(nameIngredientWithTheCloesestExpiration);
            }
            DateTime theClosestExpiration = expirationTheClosestList.Min();
            int indexOfRecipeWithTheClosestExpiration = expirationTheClosestList.IndexOf(theClosestExpiration);
            UserIO.WriteLine($"Na zadaný dotaz jsem našel tento recept {MyRecipe.MyRecipes[indexOfRecipeWithTheClosestExpiration].Name} obsahující tuto surovinu: {nameIngredientWithTheCloesestExpirationList[indexOfRecipeWithTheClosestExpiration]} s blížící se expirací: {theClosestExpiration}.");
        }

        public void FindRecipeWithTheHighestProteionContent()
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
            UserIO.WriteLine($"Na zadaný dotaz jsem našel tento recept s nejvyšším obsahem proteinů: {MyRecipe.MyRecipes[index].Name}.");
        }

        
        public Procedure GetProcedureFromUser()
        {
            UserIO.WriteLine("Vyplňte celkovou délku přípravy pokrmu v minutách.");
            int preparationTimeInMinutes = UserIO.GetUserInputInteger();
            UserIO.WriteLine("Vyplňte obtížnost receptu podle následující tabulky.");
            int enumRecipeCategoryCount = Enum.GetNames(typeof(Difficulty)).Length;
            for (int i = 0; i < enumRecipeCategoryCount; i++)
            {
                UserIO.WriteLine($"{i} je {(Difficulty)i}");
            }
            int difficulty = UserIO.GetUserInputIntegerInGivenRange(0, enumRecipeCategoryCount);
            UserIO.WriteLine("Vyplňte postup přípravy.");
            string description = UserIO.GetUserInputString();

            Procedure newProcedure = new Procedure(preparationTimeInMinutes, difficulty, description);
            return newProcedure;
        }
    }
}
