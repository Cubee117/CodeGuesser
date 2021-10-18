using System;
using System.Collections.Generic;
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
            return string.IsNullOrEmpty(fileLocation) ? new List<string>(){"No file path given"} : File.ReadAllLines(fileLocation).ToList();
        }
    }
}