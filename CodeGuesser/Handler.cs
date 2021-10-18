using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGuesser
{
    public static class Handler
    {
        public static void Process(string cmd)
        {
            const string helpMessage = "help - shows this message" +
                                       "\nstart - starts guessing code" +
                                       "\nstop - stops guessing code" +
                                       "\nsetting <string setting, string[] args> - changes <setting> to value <args>";
            
            //TODO: Add command aliases 
            var commands = new Dictionary<string, Action<string[]>>()
            {
                ["help"] = delegate(string[] strings) { Helper.Log(helpMessage, Helper.LogType.Info); },
                ["start"] = delegate(string[] strings) { Helper.StartProcess.Start(); },
                ["stop"] = delegate(string[] strings) { Helper.StartProcess.Abort(); },
                ["setting"] = delegate(string[] strings)
                {
                    //TODO: provide a list of available arguments
                    if (strings.Length < 2) { Helper.Log("Not enough arguments!", Helper.LogType.Error); return; }
                    var setting = strings[1];
                    switch (setting)
                    {
                        case "path":
                            Helper.FileLocation = strings[2];
                            return;
                        case "timeout":
                            Helper.Timeout = int.Parse(strings[2]);
                            return;
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
                Console.WriteLine("Command not found!");
            }
        }
    }
}