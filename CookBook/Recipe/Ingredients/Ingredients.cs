using System;


namespace CookBook
{
    public abstract class Ingredients
    {
        public string Name { get; private set; }
        public DateTime Expiration { get; private set; }
        public IngredientCategory IngredientCategory { get; private set; }

        public Ingredients(string name, DateTime expiration, int ingredientCategory)
        {
            if (!(String.IsNullOrEmpty(name)))
            {
                this.Name = name;
            }
            else
            {
                Console.WriteLine("Jmeno ingredience neni spravne nastaveno.");
            }
            this.Expiration = expiration;


            var myEnumMemberCount = Enum.GetNames(typeof(IngredientCategory)).Length;
            if (!(ingredientCategory < 0 | ingredientCategory > myEnumMemberCount))
            {
                this.IngredientCategory = (IngredientCategory)ingredientCategory;
            }
            else
            {
                Console.WriteLine("Kategorie neni spravne nastavena.");
            }

        }
        public virtual void GetIngredientsInfo()
        {
            Console.WriteLine($"Zatim jenom vypisu info v main tride: {this.Name} expiruje {this.Expiration}");
        }
    }
}
