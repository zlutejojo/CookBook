
using System;
using System.Collections.Generic;


namespace CookBook
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ahoj, jsem aplikace na zapisování receptů. Kdykoliv mě budeš chtít ukončit, stiskni x.");

            MyRecipe newRecipe = MyRecipe.AddNewRecipe();
            newRecipe.GetRecipeInfo();
            /*
            string recipeName = MyRecipe.GetRecipeNameFromUser();
            int recipeCategory = MyRecipe.GetRecipeCategoryFromUser();
            List<Ingredients> ingredientsList = Ingredients.GetIngredientsListFromUser();
            Procedure newProcedure = Procedure.GetProcedureFromUser();
            //MyRecipe myRecipe = new MyRecipe(recipeName, recipeCategory, newProcedure, ingredientsList);
            //myRecipe.GetRecipeInfo();*/
            
            Console.WriteLine("Jsem na konci programu. Loučím se s tebou :)");
            Console.ReadLine();
        }
    }
}
