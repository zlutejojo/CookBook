namespace CookBook.UserIO
{
    public interface IUserIO
    {
        string GetUserInputString();
        int GetUserInputInteger();
        int GetUserInputIntegerInGivenRange(int lowerLimit, int upperLimit);
        void WriteLine(string text);
        string ReadLine();
        bool CheckIfUserTerminateApplication ();
        void ExitApplication();
    }
}
