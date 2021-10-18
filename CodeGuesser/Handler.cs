using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGuesser
{
    public static class Handler
    {
        public static void Process(string cmd)
        {
            const string helpMessage = "help - Shows this message\nloadfile <string filePath> - Loads file <filePath>";
            
            //TODO: Add command aliases 
            var commands = new Dictionary<string, Action<string[]>>()
            {
                ["loadfile"] = delegate(string[] strings)
                {
                    if (strings.Length < 2) { Helper.Log("Not enough arguments!", Helper.LogType.Error); return; }
                    foreach (var character in Helper.LoadFile(strings[1]).SelectMany(code => code))
                    {
                        Helper.SendInput(Helper.GetWindow("RustClient"), Convert.ToByte(character), 700);
                    }
                },
                ["help"] = delegate(string[] strings)
                {
                    Helper.Log(helpMessage, Helper.LogType.Info);
                }
            };
            var args = cmd.Split(' ');
            if (commands.TryGetValue(args[0], out var command))
            {
                command(args);
            }
            else
            {
                Console.WriteLine("Command not found!");
            }
        }
    }
}