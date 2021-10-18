using System;
using System.Linq;

namespace CodeGuesser
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            // TODO: Make it detect once the player has died 
            if (args.Length > 0)
            {
                Console.WriteLine("Loaded file: {0}", args[0]);
                Helper.SetForegroundWindow(Helper.GetWindow("RustClient"));
                foreach (var character in Helper.LoadFile(args[0]).SelectMany(code => code))
                {
                    Helper.SendInput(Helper.GetWindow("RustClient"), Convert.ToByte(character), 700);
                }
                return;
            }
            
            Helper.Startup();
            while (true)
            { 
                Console.Write("{0}@codeguesser:~$ ", Environment.UserName);
                Handler.Process(Console.ReadLine());
            }
        }
        
        
    }
}