using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    //TODO zmenit na interface (asi)
    public interface IUserIO
    {
        string GetUserInputString();
        int GetUserInputInteger();
        void WriteLine(string text);
        bool CheckIfUserTerminateApplication ();
        void ExitApplication();
    }
}
