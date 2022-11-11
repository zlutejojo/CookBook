using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CookBook
{
    public class MyRecipe
    {
        public string Name { get; private set; }
        public RecipeCategory RecipeCategory { get; private set; }
        public Procedure Procedure { get; private set; }
        public List<Ingredients> Ingredients { get; private set; } 
        
        public bool IsRecipeSetCorrectly { get; private set; } = false;
        private static readonly UserIOConsole userIOConsole = new UserIOConsole();

        public static List<MyRecipe> MyRecipes { get; private set; } = new List<MyRecipe>();

        //todo zmenit nastaveni IsRecipeSetCorrectly, ted se mi nastavi na true, pokud jedna z podminek je spravne
        public MyRecipe(string name, int recipeCategory, Procedure procedure, List<Ingredients> ingredients)
        {
            if (!(String.IsNullOrEmpty(name)))
            {
                this.Name = name;
                IsRecipeSetCorrectly = true;
            }
            else 
            {
                Console.WriteLine("Jméno není správně nastavené.");
            }

            var myEnumMemberCount = Enum.GetNames(typeof(RecipeCategory)).Length;
            if (!(recipeCategory < 0 | recipeCategory > myEnumMemberCount))
            {
                this.RecipeCategory = (RecipeCategory)recipeCategory;
                IsRecipeSetCorrectly = true;
            }
            else
            {
                Console.WriteLine("Kategorie není správně nastavená.");
            }

            if (!(ingredients is null))
            {
                this.Ingredients = ingredients;
                IsRecipeSetCorrectly = true;
            }
            else
            {
                Console.WriteLine("Ingredience není správně nastavená.");
            }

            if (!(procedure is null))
            {

                this.Procedure = procedure;
                IsRecipeSetCorrectly = true;
            }
            else
            {
                Console.WriteLine("Postup není správně nastavený.");
            }
        }

        //methods for getting information about recipes
        public void GetRecipeInfo()
        {
            userIOConsole.WriteLine($"Můj recept {this.Name} z kategorie {this.RecipeCategory}.");
            this.Procedure.GetProcedureInfo();
            foreach (var ingredient in this.Ingredients)
            {
                ingredient.GetIngredientsInfo();
            }
        }

        public static void GetAllRecipeInfo()
        {
            foreach (var recipe in MyRecipe.MyRecipes)
            {
                recipe.GetRecipeInfo();
            }
        }

        public static void GetSpecificRecipeInfo()
        {
            GetTableWithRecipesOnConsole("Vyber podle této tabulky číslo receptu, který chceš zobrazit:");

            int indexOfRecipe = userIOConsole.GetUserInputIntegerInGivenRange(0, MyRecipes.Count);
            MyRecipe.MyRecipes[indexOfRecipe].GetRecipeInfo();
        }

        public static void GetTableWithRecipesOnConsole(string text)
        {
            int recipesCount = MyRecipe.MyRecipes.Count;
            userIOConsole.WriteLine(text);
            for (int i = 0; i < recipesCount; i++)
            {
                userIOConsole.WriteLine($"{i} pro recept {MyRecipe.MyRecipes[i].Name}.");
            }
        }

        public static void RemoveSpecificRecipe()
        {
            GetTableWithRecipesOnConsole("Vyber podle této tabulky číslo receptu, který chceš smazat:");
            int indexOfRecipe = userIOConsole.GetUserInputIntegerInGivenRange(0, MyRecipes.Count);
            MyRecipe.MyRecipes.RemoveAt(indexOfRecipe);
            userIOConsole.WriteLine($"Recept byl smazán.");
        }

        // methods for getting user inputs
        public static int GetRecipeCategoryFromUser()
        {
            int enumRecipeCategoryCount = Enum.GetNames(typeof(RecipeCategory)).Length;
            userIOConsole.WriteLine("Zadej číslo kategorie receptu podle této tabulky:");
            for (int i = 0; i < enumRecipeCategoryCount; i++)
            {
                userIOConsole.WriteLine($"{i} je {(RecipeCategory)i}");
            }
            int recipeCategory = userIOConsole.GetUserInputIntegerInGivenRange(0, enumRecipeCategoryCount - 1);
            return recipeCategory;
        }

        public static string GetRecipeNameFromUser()
        {
            userIOConsole.WriteLine("Zadej jméno receptu");
            string name = userIOConsole.GetUserInputString();
            return name;
        }

        public static MyRecipe AddNewRecipe()
        {
            string recipeName = MyRecipe.GetRecipeNameFromUser();
            int recipeCategory = MyRecipe.GetRecipeCategoryFromUser();
            
            List<Ingredients> ingredientsList = CookBook.Ingredients.GetIngredientsListFromUser();
            Procedure newProcedure = Procedure.GetProcedureFromUser();
            MyRecipe myRecipe = new MyRecipe(recipeName, recipeCategory, newProcedure, ingredientsList);
            MyRecipes.Add(myRecipe);
            return myRecipe;
        }

        //TODO da se pouzit neco jako StringComparer.CurrentCultureIgnoreCase
        public static void FindRecipeByPartOfName(string recipeName)
        {
            userIOConsole.WriteLine("Na zadaný dotaz jsem našel tyto recepty: ");
            var results = MyRecipe.MyRecipes.Where(r => r.Name.ToLower().Contains(recipeName.ToLower()));
            foreach (var recipe in results)
            {
                recipe.GetRecipeInfo();
            }
        }

        public static void FindRecipeWithGivenIngredient(string ingredientName)
        {
            userIOConsole.WriteLine("Na zadaný dotaz jsem našel tyto recepty: ");
            foreach (MyRecipe recipe in MyRecipes)
            {
                var results = recipe.Ingredients.Where(i => i.Name.ToLower().Contains(ingredientName.ToLower()));
                if (results.Count() > 0)
                {
                    recipe.GetRecipeInfo();
                }
            }
        }

        public static void FindRecipeWithTheFastestProcedure()
        {
            var orderedRecipesByTime = MyRecipes.OrderBy(r => r.Procedure.PreparationTimeInMinutes);
            var groupedOrderedRecipes = orderedRecipesByTime.GroupBy(r => r.Procedure.PreparationTimeInMinutes, r => r.Name,(recipePreparationTimes, recipeNames) => new 
            {
                GroupedTime = recipePreparationTimes,
                GroupedName = recipeNames,
            }).ToList();

            var lowestPreparationTimeGroup = groupedOrderedRecipes[0];
            userIOConsole.WriteLine($"Nejkratší čas pro přípravu receptu je {lowestPreparationTimeGroup.GroupedTime}.");

            foreach (var itemName in lowestPreparationTimeGroup.GroupedName)
            {
                userIOConsole.WriteLine($"Název receptu: {itemName}");
            }
        }

        public static void FindRecipeWithTheNearestIngredientExpiration()
        {
            List<DateTime> expirationTheClosestList = new List<DateTime>();
            List<String> nameIngredientWithTheCloesestExpirationList = new List<String>();

            foreach (MyRecipe recipe in MyRecipes)
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
            userIOConsole.WriteLine($"Na zadaný dotaz jsem našel tento recept {MyRecipes[indexOfRecipeWithTheClosestExpiration].Name} obsahující tuto surovinu: {nameIngredientWithTheCloesestExpirationList[indexOfRecipeWithTheClosestExpiration]} s blížící se expirací: {theClosestExpiration}.");
        }

        public static void FindRecipeWithTheHighestProteionContent()
        {
            List<int> proteinSumList = new List<int>();
            
            foreach (MyRecipe recipe in MyRecipes)
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
            userIOConsole.WriteLine($"Na zadaný dotaz jsem našel tento recept s nejvyšším obsahem proteinů: {MyRecipes[index].Name}.");
        }

        public static void RunRecipeApp() { 

        while (true)
            {
                userIOConsole.WriteLine($"Vyber, co budeš dělat, a zadej číslo daného výběru: 1. Přidávat nový recept, 2. Editovat recept, 3. Mazat recept, 4. Vypsat informace o receptu.");
                int choosedAction = userIOConsole.GetUserInputIntegerInGivenRange(1, 4);
                switch (choosedAction)
                {
                    case 1:
                        MyRecipe.AddNewRecipe();
                        MyRecipe.GetAllRecipeInfo();
                        Console.WriteLine("Skončili jsme s vyplňováním jednoho receptu. Stiskni enter pro pokračování.");
                        Console.ReadLine();
                        break;
                    case 2:
                        userIOConsole.WriteLine("Ještě nic neumím, zkus to později.");
                        break;
                    case 3:
                        MyRecipe.RemoveSpecificRecipe();
                        break;
                    case 4:
                        userIOConsole.WriteLine("jsem ve 4.");
                        MyRecipe.GetSpecificRecipeInfo();
                        break;
                }
            }
        }
    }
}
