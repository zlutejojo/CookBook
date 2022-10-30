using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    //TODO zmenit na interface (asi)
    public abstract class IUserIO
    {
        public abstract string GetUserInputString();
        public abstract int GetUserInputInteger();
        public abstract void WriteLine(string text);
        public abstract bool CheckIfUserTerminateApplication ();

        public void ExitApplication()
        {
            System.Environment.Exit(0);
        }
    }
}
