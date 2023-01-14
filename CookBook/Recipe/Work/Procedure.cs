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
        
        public void GetProcedureInfo()
        {
            Console.WriteLine($"Vypisuju informace pro postup přípravy receptu: délka: {this.PreparationTimeInMinutes}, obtížnost: {(Difficulty)this.Difficulty}, postup: {this.Description}.");
        }
    }
}
