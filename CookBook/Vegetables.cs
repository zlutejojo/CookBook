using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    internal class Vegetables : Ingredients
    {
        public string Vitamin;
        public int FiberGram;
        public Vegetables(string name, DateTime expiration, int categoryNumber, string vitamin, int fiberGram) : base(name, expiration, categoryNumber)
        {
            Vitamin = vitamin;
            FiberGram = fiberGram;
        }


    }
}
