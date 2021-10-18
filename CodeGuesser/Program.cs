using System;
using System.Collections.Generic;

namespace CodeGuesser
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Helper.Startup();
            while (true)
            { 
                Console.Write("{0}@codeguesser:~$ ", Environment.UserName);
                var input = Console.ReadLine();
                var data = Helper.LoadFile(input);
                foreach (var code in data)
                {
                    foreach (var character in code)
                    {
                        Helper.SendInput(Helper.GetWindow("RustClient"), Convert.ToByte(character), 700);
                    }
                }
            }
        }
    }
}