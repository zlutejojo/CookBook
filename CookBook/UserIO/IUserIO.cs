using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    public interface IUserIO
    {
        string GetUserInputString();
        int GetUserInputInteger();
        int GetUserInputIntegerInGivenRange(int lowerLimit, int upperLimit);
        void WriteLine(string text);
        bool CheckIfUserTerminateApplication ();
        void ExitApplication();
    }
}
