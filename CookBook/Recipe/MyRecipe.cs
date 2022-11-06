using System;
using System.Collections.Generic;
using System.Linq;
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
            int recipesCount = MyRecipe.MyRecipes.Count;
            userIOConsole.WriteLine("Vyber podle této tabulky číslo receptu, který chceš zobrazit:");
            for (int i = 0; i < recipesCount; i++)
            {
                userIOConsole.WriteLine($"{i} pro recept {MyRecipe.MyRecipes[i].Name}.");
            }

            int indexOfRecipe = userIOConsole.GetUserInputIntegerInGivenRange(0, recipesCount);
            MyRecipe.MyRecipes[indexOfRecipe].GetRecipeInfo();
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
        public static void findRecipeByPartOfName(string recipeName)
        {
            userIOConsole.WriteLine("Na zadaný dotaz jsem našel tyto recepty: ");
            var results = MyRecipe.MyRecipes.Where(r => r.Name.ToLower().Contains(recipeName.ToLower()));
            foreach (var recipe in results)
            {
                recipe.GetRecipeInfo();
            }
        }

        public static void findRecipeWithGivenIngredient(string ingredientName)
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

        public void findRecipeWithTheFastestProcedure()
        {

        }

        public void findRecipeWithTheNearestIngredientExpiration()
        {

        }

        public void findRecipeWithTheHighestProteionContent()
        {

        }


    }
}
