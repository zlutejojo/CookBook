using System;

namespace CookBook.UserIO
{
    public class MyConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine().Trim();
        }
        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
