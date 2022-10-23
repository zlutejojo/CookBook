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
            //TODO udelat vypis, ktere kategorie jsou pro jake cislo
            myConsole.WriteLine($"Vyber kategorii receptu. Od 0 do {enumRecipeCategoryCount-1}.");
            int testRecipeCategory = myConsole.GetUserInputIntegerInGivenRange(0,enumRecipeCategoryCount-1);
            myConsole.WriteLine($"kategorie receptu je {testRecipeCategory}");
            //KATEGORIE RECEPTU

            //LIST INGREDIENCI
            myConsole.WriteLine("Nyní se pustíme do vyplňování ingredinecí.");
            myConsole.WriteLine("Nejprve zadej, kolik celkově budeš vyplňovat ingrediencí.");
            
            int ingredientsCount = myConsole.GetUserInputInteger();
            List<Ingredients> testIngredients = new List<Ingredients>();
            int enumIngredientCategoryCount = Enum.GetNames(typeof(IngredientCategory)).Length;
            
            for (int j = 0; j < ingredientsCount; j++)
            {
                myConsole.WriteLine("jsem ve foru kategorie ingredience" + j);
                myConsole.WriteLine($"zadej kategorii od 0 do {enumIngredientCategoryCount - 1}");

                int ingredientCategory = myConsole.GetUserInputIntegerInGivenRange(0, enumIngredientCategoryCount);
                /*
                while (ingredientCategory < 0 | ingredientCategory > enumIngredientCategoryCount)
                {
                    myConsole.WriteLine("jsem ve while kategorie ingredience " + j);
                    myConsole.WriteLine("Zadal jsi číslo v nesprávném rozsahu. Opakuj zadání.");
                    ingredientCategory = myConsole.GetUserInputInteger();
                }*/

                switch (ingredientCategory)
                {
                    case 0:
                        Console.WriteLine($"kategorie {ingredientCategory} maso");

                        myConsole.WriteLine("Zadejte název suroviny.");
                        string name = myConsole.GetUserInputString();
                        myConsole.WriteLine("Nyní postupně vyplníme expiraci zboží.");
                        myConsole.WriteLine("Nejprve zadejte rok expirace.");

                        //snad zadna potravina nema trvanlivost delsi nez cca 10 let
                        int year = myConsole.GetUserInputIntegerInGivenRange(DateTime.Now.Year, DateTime.Now.Year + 10);
                        myConsole.WriteLine("Nyní zadejte měsíc expirace.");
                        int month = myConsole.GetUserInputIntegerInGivenRange(1, 12);
                        myConsole.WriteLine("Nyní zadejte den expirace.");
                        int day = myConsole.GetUserInputIntegerInGivenRange(1, 31);
                        DateTime expiration = new DateTime(year, month, day);

                        myConsole.WriteLine("datum je " + expiration);

                        myConsole.WriteLine("Zadejte bilkoviny v gramech.");
                        int proteinGram = myConsole.GetUserInputInteger();
                        myConsole.WriteLine("Zadejte tuky v gramech.");
                        int fatGram = myConsole.GetUserInputInteger();

                        Meat meat = new Meat(name, expiration, ingredientCategory, proteinGram, fatGram);
                        myConsole.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}");

                        break;
                    case 1:
                        Console.WriteLine("kategorie 1 zelenina");
                        break;
                    case 2:
                        Console.WriteLine("kategorie 2 ostatni");
                        break;
                }

                //Ingredients newIngredient = new Ingredients();
            }
            //LIST INGREDIENCI


            //POSTUP
            Procedure testProcedure = new Procedure();

            //POSTUP


            DateTime dt = new DateTime(2022,11,11);
            //Ingredients i = new Meat("recept", dt,10,10);
            //Recipe testRecipe = new Recipe(testName, new Procedure(), , testRecipeCategory);
            Recipe r = new Recipe(testName, testProcedure, testIngredients, testRecipeCategory);

                 
            

            Console.WriteLine("jsem na konci programu");
            Console.ReadLine();
        }
    }
}
