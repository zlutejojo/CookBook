using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CookBook
{
    public class Procedure
    {
        public int PreparationTimeInMinutes { get; private set; }
        public Difficulty Difficulty { get; private set; }
        public string Description { get; private set; }
        private static readonly UserIOConsole userIOConsole = new UserIOConsole();

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
                userIOConsole.WriteLine("Stupeň obtížnosti není spravně nastavený.");
            }

            if (!(String.IsNullOrEmpty(description)))
            {
                this.Description = description;
            }
            else
            {
                userIOConsole.WriteLine("Popis procedury není spravně nastavený.");
            }
        }
        public static Procedure GetProcedureFromUser()
        {
            userIOConsole.WriteLine("Vyplňte celkovou délku přípravy pokrmu v minutách.");
            int preparationTimeInMinutes = userIOConsole.GetUserInputInteger();
            userIOConsole.WriteLine("Vyplňte obtížnost receptu podle následující tabulky.");
            int enumRecipeCategoryCount = Enum.GetNames(typeof(Difficulty)).Length;
            for (int i = 0; i < enumRecipeCategoryCount; i++)
            {
                userIOConsole.WriteLine($"{i} je {(Difficulty)i}");
            }
            int difficulty = userIOConsole.GetUserInputIntegerInGivenRange(0, enumRecipeCategoryCount);
            userIOConsole.WriteLine("Vyplňte postup přípravy.");
            string description = userIOConsole.GetUserInputString();

            Procedure newProcedure = new Procedure(preparationTimeInMinutes, difficulty, description);
            return newProcedure;
        }
        public void GetProcedureInfo()
        {
            Console.WriteLine($"Vypisuju informace pro postup přípravy receptu: délka: {this.PreparationTimeInMinutes}, obtížnost: {(Difficulty)this.Difficulty}, postup: {this.Description}.");
        }
    }
}
