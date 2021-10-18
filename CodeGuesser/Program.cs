using System;
using System.Collections.Generic;

namespace CodeGuesser
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Console.WriteLine("Loaded file: {0}", args[0]);
                Helper.SetForegroundWindow(Helper.GetWindow("RustClient"));
                foreach (var code in Helper.LoadFile(args[0]))
                {
                    foreach (var character in code)
                    {
                        Helper.SendInput(Helper.GetWindow("RustClient"), Convert.ToByte(character), 700);
                    }
                }
                return;
            }
            
            Helper.Startup();
            while (true)
            { 
                Console.Write("{0}@codeguesser:~$ ", Environment.UserName);
                var input = Console.ReadLine();
                var data = Helper.LoadFile(input);
                Helper.SetForegroundWindow(Helper.GetWindow("RustClient"));
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