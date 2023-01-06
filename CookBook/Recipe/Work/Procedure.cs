using CookBook.UserIO;
using System;

namespace CookBook.Recipe.Work
{
    public class Procedure
    {
        public int PreparationTimeInMinutes { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public string Description { get; private set; }

        public Procedure(int preparationTimeInMinutes, int difficulty, string description)
        {
            if (preparationTimeInMinutes > 0)
            {
                this.PreparationTimeInMinutes = preparationTimeInMinutes;
            }
            else
            {
                Console.WriteLine("Čas musí být alespoň 1 minuta.");
            }

            var descritionEnumCount = Enum.GetNames(typeof(Difficulty)).Length;
            if (!(difficulty < 0 || difficulty > descritionEnumCount))
            {
                this.Difficulty = (Difficulty)difficulty;
            }
            else
            {
                Console.WriteLine("Stupeň obtížnosti není spravně nastavený.");
            }

            if (!(String.IsNullOrEmpty(description)))
            {
                this.Description = description;
            }
            else
            {
                Console.WriteLine("Popis procedury není spravně nastavený.");
            }
        }
        public static Procedure GetProcedureFromUser(IUserIO userIO)
        {
            userIO.WriteLine("Vyplňte celkovou délku přípravy pokrmu v minutách.");
            int preparationTimeInMinutes = userIO.GetUserInputInteger();
            userIO.WriteLine("Vyplňte obtížnost receptu podle následující tabulky.");
            int enumRecipeCategoryCount = Enum.GetNames(typeof(Difficulty)).Length;
            for (int i = 0; i < enumRecipeCategoryCount; i++)
            {
                userIO.WriteLine($"{i} je {(Difficulty)i}");
            }
            int difficulty = userIO.GetUserInputIntegerInGivenRange(0, enumRecipeCategoryCount);
            userIO.WriteLine("Vyplňte postup přípravy.");
            string description = userIO.GetUserInputString();

            Procedure newProcedure = new Procedure(preparationTimeInMinutes, difficulty, description);
            return newProcedure;
        }
        public void GetProcedureInfo()
        {
            Console.WriteLine($"Vypisuju informace pro postup přípravy receptu: délka: {this.PreparationTimeInMinutes}, obtížnost: {(Difficulty)this.Difficulty}, postup: {this.Description}.");
        }
    }
}
