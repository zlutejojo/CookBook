using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    public class MyRecipe
    {
        public string Name { get; private set; }
        public Procedure Procedure { get; private set; }
        public List<Ingredients> Ingredients { get; private set; }
        public RecipeCategory RecipeCategory { get; private set; }
        public bool IsRecipeSetCorrectly { get; private set; } = false;

        //todo zmenit nastaveni IsRecipeSetCorrectly, ted se mi nastavi na true, pokud jedna z podminek je spravne
        public MyRecipe(string name, Procedure procedure, List<Ingredients> ingredients, int recipeCategory)
        {
            if (!(String.IsNullOrEmpty(name)))
            {
                this.Name = name;
                IsRecipeSetCorrectly = true;
            }
            else 
            {
                Console.WriteLine("Jmeno neni spravne nastaveno.");
            }

            if (!(ingredients is null))
            {
                this.Ingredients = ingredients;
                IsRecipeSetCorrectly = true;
            }
            else
            {
                Console.WriteLine("Ingredience neni spravne nastavena.");
            }

            if (!(procedure is null))
            {

                this.Procedure = procedure;
                IsRecipeSetCorrectly = true;
            }
            else
            {
                Console.WriteLine("Postup neni spravne nastaveny.");
            }

            var myEnumMemberCount = Enum.GetNames(typeof(RecipeCategory)).Length;
            if (!(recipeCategory < 0 | recipeCategory > myEnumMemberCount))
            {
                this.RecipeCategory = (RecipeCategory)recipeCategory; 
                IsRecipeSetCorrectly = true;
            }
            else
            {
                Console.WriteLine("Kategorie neni spravne nastavena.");
            }
        }
    }
}
