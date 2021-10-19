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
                    if (strings.Length < 2)
                    {
                        Helper.Log("Not enough arguments!", Helper.LogType.Error); 
                        Helper.Log("List of settings: " +
                                   "\npath <string> - changes the file path that is loaded" +
                                   "\ntimeout <int> - changes how long to wait before typing a character" +
                                   "\nstartdelay <int> - changes the delay before starting", Helper.LogType.Info); 
                        return;
                    }
                    var setting = strings[1];
                    switch (setting)
                    {
                        case "path":
                            Helper.FileLocation = strings[2];
                            Helper.Log($"Successfully changed file path to: {strings[2]}", Helper.LogType.Success);
                            return;
                        case "timeout":
                            Helper.Timeout = int.Parse(strings[2]);
                            Helper.Log($"Successfully changed timeout to: {strings[2]} milliseconds", Helper.LogType.Success);
                            return;
                        case "startdelay":
                            Helper.StartDelay = int.Parse(strings[2]);
                            Helper.Log($"Successfully changed start delay to: {strings[2]} milliseconds", Helper.LogType.Success);
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