using CookBook.Recipe.Ingredients;
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
            if (!(ingredientCategory < 0 || ingredientCategory > myEnumMemberCount))
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
            Console.WriteLine($"Základní informace o ingredienci: {this.Name} z kategorie {this.IngredientCategory} expiruje {this.Expiration}.");
        }
        
        public static Ingredients FillGeneralPropertyForIngredientInConsole(int ingredientCategory)
        {
            UserIOConsole myConsole = new UserIOConsole();
            
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

            Ingredients generalIngredients = new Others(name, expiration, ingredientCategory, "Nenastaveno.");

            return generalIngredients;
        }

        public static Meat FillMeatPropertyForIngredientInConsole(int ingredientCategory)
        {
            UserIOConsole myConsole = new UserIOConsole();
            Ingredients generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            myConsole.WriteLine("Zadejte bílkoviny v gramech.");
            int proteinGram = myConsole.GetUserInputInteger();
            myConsole.WriteLine("Zadejte tuky v gramech.");
            int fatGram = myConsole.GetUserInputInteger();

            Meat meat = new Meat(generalIngredient.Name, generalIngredient.Expiration, ingredientCategory, proteinGram, fatGram);
            myConsole.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}");
            meat.GetIngredientsInfo();
            return meat;
        }

        public static VegetablesAndFruits FillVegetablesAndFruitsPropertyForIngredientInConsole(int ingredientCategory)
        {
            UserIOConsole myConsole = new UserIOConsole();
            Ingredients generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            myConsole.WriteLine("Zadejte vitamíny obsažené v přísadě.");
            string vitamin = myConsole.GetUserInputString();
            myConsole.WriteLine("Zadejte vlákninu v gramech.");
            int fiberGram = myConsole.GetUserInputInteger();

            VegetablesAndFruits vegetablesAndFruits = new VegetablesAndFruits(generalIngredient.Name, generalIngredient.Expiration, ingredientCategory, vitamin, fiberGram);
            //myConsole.WriteLine($"Moje maso {meat.Name} {meat.Expiration} {meat.IngredientCategory} {meat.ProteionGram} {meat.FatGram}");
            vegetablesAndFruits.GetIngredientsInfo();
            return vegetablesAndFruits;
        }

        public static CookBook.Recipe.Ingredients.Others FillOthersPropertyForIngredientInConsole(int ingredientCategory)
        {
            UserIOConsole myConsole = new UserIOConsole();
            Ingredients generalIngredient = FillGeneralPropertyForIngredientInConsole(ingredientCategory);

            myConsole.WriteLine("Zadejte popis přísady.");
            string description = myConsole.GetUserInputString();


            CookBook.Recipe.Ingredients.Others others = new Others(generalIngredient.Name, generalIngredient.Expiration, ingredientCategory, description);
            return others;
        }
    }
}
