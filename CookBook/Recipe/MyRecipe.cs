using System;
using System.Collections.Generic;
using System.Linq;
using CookBook.Recipe.Content;
using CookBook.Recipe.Work;
using CookBook.UserIO;

namespace CookBook.Recipe
{
    public class MyRecipe
    {
        public string Name { get; private set; }
        public RecipeCategory RecipeCategory { get; private set; }
        public Procedure Procedure { get; private set; }
        public List<Ingredients> Ingredients { get; private set; } 
        
        public bool IsRecipeSetCorrectly { get; private set; } = false;

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
                throw new ArgumentNullException("Jméno není správně nastavené.");
            }

            var myEnumMemberCount = Enum.GetNames(typeof(RecipeCategory)).Length;
            if (!(recipeCategory < 0 | recipeCategory > myEnumMemberCount))
            {
                this.RecipeCategory = (RecipeCategory)recipeCategory;
                IsRecipeSetCorrectly = true;
            }
            else
            {
                throw new ArgumentNullException("Kategorie není správně nastavená.");
            }

            if (!(ingredients is null))
            {
                this.Ingredients = ingredients;
                IsRecipeSetCorrectly = true;
            }
            else
            {

                throw new ArgumentNullException("Ingredience není správně nastavená.");
            }

            if (!(procedure is null))
            {

                this.Procedure = procedure;
                IsRecipeSetCorrectly = true;
            }
            else
            {
                throw new ArgumentNullException("Postup není správně nastavený.");
            }
        }
    }
}
