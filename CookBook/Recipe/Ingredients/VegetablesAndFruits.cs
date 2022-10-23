using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    internal class VegetablesAndFruits : Ingredients
    {
        public string Vitamin;
        public int FiberGram;
        public VegetablesAndFruits(string name, DateTime expiration, int categoryNumber, string vitamin, int fiberGram) : base(name, expiration, categoryNumber)
        {
            Vitamin = vitamin;
            FiberGram = fiberGram;
        }


    }
}
