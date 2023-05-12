using CookBook.Recipe;
using CookBook.Recipe.Content;
using CookBook.Recipe.Management;
using CookBook.Recipe.Work;
using CookBook.UserIO;
using System;
using System.Collections.Generic;


namespace CookBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeFactory recipeFactory = new RecipeFactory();
            recipeFactory.createDefaultRecipes();
            MyConsole myConsole = new MyConsole();
            myConsole.WriteLine("Ahoj, jsem aplikace na zapisování receptů. Kdykoliv mě budeš chtít ukončit, zadej x.");
            CookBookManager cookBookManager = new CookBookManager(new UserIOConsole());

            //cookBookManager.FindRecipeByPartOfName("kur");
            //cookBookManager.FindRecipeWithGivenIngredient("herm");
            //cookBookManager.FindRecipeWithTheFastestProcedure();
            //cookBookManager.FindRecipeWithTheNearestIngredientExpiration();
            //cookBookManager.FindRecipeWithTheHighestProteionContent();
            //cookBookManager.FindRecipeWithTheHighestProteionContentBetter();
            cookBookManager.FindRecipeWithTheNearestIngredientExpiration();
            cookBookManager.RunRecipeApp();
            myConsole.ReadLine();
        }
    }
}
