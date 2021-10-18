using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CodeGuesser
{
    public class Helper
    {
        public static void Startup()
        {
            const string banner = @"
   ___         _                                    
  / __|___  __| |___   __ _ _  _ ___ ______ ___ _ _ 
 | (__/ _ \/ _` / -_) / _` | || / -_|_-<_-</ -_) '_|
  \___\___/\__,_\___| \__, |\_,_\___/__/__/\___|_|  
                      |___/";
            Console.Title = "Rust code guesser - Cube#9709";
            Console.WriteLine(banner);
        }

        public static List<string> LoadFile(string fileLocation)
        {
            // False:True
            return string.IsNullOrEmpty(fileLocation) ? throw new Exception("Could not find file") : File.ReadAllLines(fileLocation).ToList();
        }

        public static IntPtr GetWindow(string procName)
        {
            var proc = Process.GetProcessesByName("procName");
            return proc.Length == 0 ? throw new Exception("Couldn't find window") : proc[0].MainWindowHandle;
        }
    }
}