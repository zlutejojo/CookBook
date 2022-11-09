
using System;
using System.Collections.Generic;


namespace CookBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // recept kure
            Procedure kurePriprava = new Procedure(150,1,"Dej celé kuře do pekáče a peč ho 2 hodiny na 160 stupňů.");
            List<Ingredients> kureSeznamIngredienci = new List<Ingredients>();
            Meat kureCele = new Meat("celé kuře","1 ks",new DateTime(2022, 11, 15),0,22,4);
            kureSeznamIngredienci.Add(kureCele);
            VegetablesAndFruits brambory = new VegetablesAndFruits("brambory", "4 ks", new DateTime(2023, 3, 31), 1, "hořčík, draslík, vitamíny: A, B, C", 2);
            kureSeznamIngredienci.Add(brambory);
            MyRecipe kure = new MyRecipe("Kuře", 0, kurePriprava,kureSeznamIngredienci);
            MyRecipe.MyRecipes.Add(kure);

            //recept pizza
            Procedure pizzaPriprava = new Procedure(45, 0, "Na listové těsto naskládej hermelín a potři brusinkovým džemem.");
            List<Ingredients> pizzaSeznamIngredienci = new List<Ingredients>();
            Others listoveTesto = new Others("listové těsto", "1 ks", new DateTime(2022, 11, 17), 2, "kupované z obchodu");
            pizzaSeznamIngredienci.Add(listoveTesto);
            MilkProduct hermelin = new MilkProduct("hermelín", "1 ks", new DateTime(2022, 11, 25), 2, 21, 23, 2);
            pizzaSeznamIngredienci.Add(hermelin);
            Others brusinkovyDzem = new Others("brusinkový džem", "1 ks", new DateTime(2023, 6, 30),3, "kupovaný džem z obchodu, pozor obsahuje hodně sacharidů cca 45 g(sacharidy: 50 g)");
            pizzaSeznamIngredienci.Add(brusinkovyDzem);
            MyRecipe pizza = new MyRecipe("Hermelínová pizza", 3, pizzaPriprava, pizzaSeznamIngredienci);
            MyRecipe.MyRecipes.Add(pizza);

            //recept ovesna kase
            Procedure ovesnaKasePriprava = new Procedure(15, 0, "Ovesné vločky zalij vařící vodou, zakryj na 15 minut a přidej nakrájené jablko.");
            List<Ingredients> ovesnáKašeSeznamIngredienci = new List<Ingredients>();
            Others ovesnéVločky = new Others("ovesné vločky", "50 g", new DateTime(2023, 9, 15), 2, "sacharidy: 50 g, bílkoviny: 15 g, vláknina: 16 g");
            ovesnáKašeSeznamIngredienci.Add(ovesnéVločky);
            VegetablesAndFruits jablko = new VegetablesAndFruits("jablko", "2 ks", new DateTime(2023, 12, 31), 1, "vitamíny: B, C, E", 3);
            ovesnáKašeSeznamIngredienci.Add(jablko);
            MyRecipe ovesnaKase = new MyRecipe("Ovesná kaše", 0, ovesnaKasePriprava, ovesnáKašeSeznamIngredienci);
            MyRecipe.MyRecipes.Add(ovesnaKase);

            //MyRecipe.findRecipeByPartOfName("Kuř");
            //MyRecipe.findRecipeByPartOfName("kuř");
            //MyRecipe.findRecipeByPartOfName("kur");
            //MyRecipe.findRecipeWithGivenIngredient("her");

            UserIOConsole userIOConsole = new UserIOConsole();
            userIOConsole.WriteLine("Ahoj, jsem aplikace na zapisování receptů. Kdykoliv mě budeš chtít ukončit, zadej x.");
            MyRecipe.RunRecipeApp();
        }
    }
}
