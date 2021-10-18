using System;

namespace CodeGuesser
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("{0}@codeguesser:~$ ", Environment.UserName);
            var fileLocation = Console.ReadLine();
        }
    }
}