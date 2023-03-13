using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Recipe.Content
{
    internal interface HasProtein
    {
        // vzdycky vsechno v rozhrani je public
        int ProteionGram { get; }
    }
}
