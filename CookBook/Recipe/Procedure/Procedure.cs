using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    internal class Procedure
    {
        internal int PreparationTimeInMinutes { get; private set; }
        internal Difficulty Difficulty { get; private set; }
        internal string Description { get; private set; }
    }
}
