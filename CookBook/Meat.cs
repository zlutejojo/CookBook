using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    internal class Meat : Ingredients
    {
        internal int ProteionGram { get; private set; }
        internal int FatGram { get; private set; }

        public Meat(string name, DateTime expiration, int categoryNumber, int proteinGram, int fatGram) : base(name, expiration, categoryNumber)
        {
            if(proteinGram < 0)
            {
                Console.WriteLine("Nenastavil jsi spravne mnozstvi bilkovin. Nastavuji hodnotu -1");
                this.ProteionGram = -1;
            } 
            else 
            {
                this.ProteionGram = proteinGram;
            }

            if (fatGram < 0)
            {
                Console.WriteLine("Nenastavil jsi spravne mnozstvi tuku. Nastavuji hodnotu -1");
                this.FatGram = -1;
            }
            else
            {
                this.FatGram = fatGram;
            }
        }
        

        public override void GetIngredientsInfo()
        {
            Console.WriteLine($"Vypisuju info pro maso: {this.FatGram} {this.ProteionGram} ");
            
        }

        
    }
}
