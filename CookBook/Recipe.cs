using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    internal class Recipe
    {
        public string Name { get; private set; }
        public Procedure Procedure { get; private set; }
        public Ingredients Ingredients { get; private set; }
        public Category Category { get; private set; }
        public bool IsRecipeSetCorrectly { get; private set; } = false;

        public Recipe(string name, Procedure procedure, Ingredients ingredients, int categoryNumber)
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

            var myEnumMemberCount = Enum.GetNames(typeof(Category)).Length;
            //TODO vyzkouset podminku!!!!!
            if (!(categoryNumber < 0 | categoryNumber > myEnumMemberCount))
            {
                this.Category = (Category)categoryNumber; 
                IsRecipeSetCorrectly = true;
            }
            else
            {
                Console.WriteLine("Kategorie neni spravne nastavena.");
            }
        }
    }
}
