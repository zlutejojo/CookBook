using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook
{
    internal class UserIO : IUserIO
    {
        public override void CheckIfUserTerminateApplication()
        {
            throw new NotImplementedException();
        }

        public override int GetUserInputInteger(string userInput)
        {
            throw new NotImplementedException();
        }

        public override string GetUserInputString()
        {
            throw new NotImplementedException();
        }
    }
}
