using CookBook.Recipe.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserIOConsole myConsole = new UserIOConsole();

            //JMENO RECEPTU
            myConsole.WriteLine("Zadej jmeno receptu");
            string testName = myConsole.GetUserInputString();
            //JMENO RECEPTU

            //KATEGORIE RECEPTU
            int enumRecipeCategoryCount = Enum.GetNames(typeof(RecipeCategory)).Length;
            myConsole.WriteLine("Zadej číslo kategorie ingredience podle této tabulky:");
            for (int i = 0; i < enumRecipeCategoryCount; i++)
            {
                myConsole.WriteLine($"{i} je {(RecipeCategory)i}");
            }
            int testRecipeCategory = myConsole.GetUserInputIntegerInGivenRange(0,enumRecipeCategoryCount-1);
            myConsole.WriteLine($"kategorie receptu je {testRecipeCategory}");
            //KATEGORIE RECEPTU

            //LIST INGREDIENCI
            myConsole.WriteLine("Nyní se pustíme do vyplňování ingredinecí.");
            myConsole.WriteLine("Nejprve zadej, kolik celkově budeš vyplňovat ingrediencí.");

            List<Ingredients> ingredientsList = Ingredients.GetIngredientsListFromUser();

            /*List<Ingredients> ingredientsList = new List<Ingredients>();

            int ingredientsCount = myConsole.GetUserInputInteger();
            int enumIngredientCategoryCount = Enum.GetNames(typeof(IngredientCategory)).Length;

            for (int j = 0; j < ingredientsCount; j++)
            {
                myConsole.WriteLine("Zadej číslo kategorie ingredience podle této tabulky:");
                for (int i = 0; i < enumIngredientCategoryCount; i++)
                {
                    myConsole.WriteLine($"{i} je {(IngredientCategory)i}");
                }
                int ingredientCategory = myConsole.GetUserInputIntegerInGivenRange(0, enumIngredientCategoryCount);

                switch (ingredientCategory)
                {
                    case 0:
                        Console.WriteLine($"kategorie {ingredientCategory} maso");
                        Meat newMeat = Ingredients.FillMeatPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(newMeat);
                        //newMeat.GetIngredientsInfo();
                        break;
                    case 1:
                        Console.WriteLine("kategorie 1 zelenina");
                        VegetablesAndFruits newVegetablesAndFruits =  Ingredients.FillVegetablesAndFruitsPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(newVegetablesAndFruits);
                        //newVegetablesAndFruits.GetIngredientsInfo();
                        break;
                    case 2:
                        Console.WriteLine("kategorie 2 ostatni");
                        Others newOthers= Ingredients.FillOthersPropertyForIngredientInConsole(ingredientCategory);
                        ingredientsList.Add(newOthers);
                        //newOthers.GetIngredientsInfo();
                        break;
                }
                myConsole.WriteLine("Skončili jsme s vyplňováním jedné ingredience.");
            }*/
            //LIST INGREDIENCI
            myConsole.WriteLine("foreach.");

            foreach (var item in ingredientsList)
            {
                item.GetIngredientsInfo();
            }


            //POSTUP
            Procedure testProcedure = new Procedure();
            //POSTUP

            MyRecipe r = new MyRecipe(testName, testProcedure, ingredientsList, testRecipeCategory);

            Console.WriteLine("Jsem na konci programu. Loučím se s tebou :)");
            Console.ReadLine();
        }
    }
}
