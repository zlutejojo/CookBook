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
            
            myConsole.WriteLine("Zadej jmeno receptu");
            string name = myConsole.GetUserInputString();
            //TODO udelat vypis na konzoli rozsahu dynamicky
            myConsole.WriteLine("Vyber kategorii receptu. Od 0 do 4.");
            int enumCategoryCount = Enum.GetNames(typeof(RecipeCategory)).Length;
            int recipeCategory = myConsole.GetUserInputInteger();
            
            while (recipeCategory < 0 | recipeCategory > enumCategoryCount)
            {
                myConsole.WriteLine("Zadal jsi číslo v nesprávném rozsahu. Opakuj zadání.");
                recipeCategory = myConsole.GetUserInputInteger();
            }

            myConsole.WriteLine("Vypln udaje pro jednotlive ingredience. Kolik recept obsahuje ingredienci?");
            int ingredientsCount = myConsole.GetUserInputInteger();
            List<Ingredients> ingredients = new List<Ingredients>();

            int enumIngredientCategoryCount = Enum.GetNames(typeof(IngredientCategory)).Length;
            for (int j = 0; j < ingredientsCount; j++)
            {
                myConsole.WriteLine("jsem ve foru kategirie ingredience" + j);
                myConsole.WriteLine("zadej kategorii od 0 do " + (enumIngredientCategoryCount - 1));

                int ingredientCategory = myConsole.GetUserInputInteger();

                while (ingredientCategory < 0 | ingredientCategory > enumIngredientCategoryCount)
                {
                    myConsole.WriteLine("jsem ve while kategorie ingredience " + j);
                    myConsole.WriteLine("Zadal jsi číslo v nesprávném rozsahu. Opakuj zadání.");
                    ingredientCategory = myConsole.GetUserInputInteger();
                }

                switch (ingredientCategory)
                {
                    case 0:
                        Console.WriteLine("kategorie 0 maso");
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



            DateTime dt = new DateTime(2022,11,11);
            //Ingredients i = new Meat("recept", dt,10,10);
            //Recipe testRecipe = new Recipe(name, new Procedure(), i, recipeCategory);
            

            Console.WriteLine("jsem na konci programu");
            Console.ReadLine();
        }
    }
}
