using System;
using System.Collections.Generic;

namespace CodeGuesser
{
    internal static class Program
    {
        // last digit = number
        private static readonly List<byte> Numbers = new List<byte>() { 0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39 };
        public static void Main(string[] args)
        {
            Helper.Startup();
            Helper.SendInput(Helper.GetWindow("notepad"), Numbers[0]);
            while (true)
            { 
                Console.Write("{0}@codeguesser:~$ ", Environment.UserName);
                var input = Console.ReadLine();
                var data = Helper.LoadFile(input);
                foreach (var code in data)
                {
                    Console.WriteLine(code);
                }
            }
        }
    }
}