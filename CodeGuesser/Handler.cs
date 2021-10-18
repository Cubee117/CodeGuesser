using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGuesser
{
    public static class Handler
    {
        public static void Process(string cmd)
        {
            var commands = new Dictionary<string, Action<string[]>>()
            {
                ["loadfile"] = delegate(string[] strings)
                {
                    if (strings.Length < 2) { Console.WriteLine("Not enough arguments!"); return; }
                    foreach (var character in Helper.LoadFile(strings[1]).SelectMany(code => code))
                    {
                        Helper.SendInput(Helper.GetWindow("RustClient"), Convert.ToByte(character), 700);
                    }
                }
            };
            var args = cmd.Split(' ');
            if (commands.TryGetValue(args[0], out var command))
            {
                command(args);
            }
            else
            {
                // command not found...
            }
        }
    }
}