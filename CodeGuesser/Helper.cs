using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace CodeGuesser
{
    public static class Helper
    {
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);
        
        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        
        public enum LogType
        {
            Message,
            Error,
            Warning,
            Info
        }
        
        public static void Startup()
        {
            var banner = @"
   ___         _                                    
  / __|___  __| |___   __ _ _  _ ___ ______ ___ _ _ 
 | (__/ _ \/ _` / -_) / _` | || / -_|_-<_-</ -_) '_|
  \___\___/\__,_\___| \__, |\_,_\___/__/__/\___|_|  
                      |___/" + Environment.NewLine;
            Console.Title = "Rust code guesser - Cube#9709";
            Console.WriteLine(banner);
            Console.WriteLine("Type 'help' for a list of commands!\n");
        }

        public static IEnumerable<string> LoadFile(string fileLocation)
        {
            // False:True
            return string.IsNullOrEmpty(fileLocation) ? throw new Exception("Could not find file") : File.ReadAllLines(fileLocation).ToList();
        }

        public static IntPtr GetWindow(string procName)
        {
            var proc = Process.GetProcessesByName(procName);
            return proc.Length == 0 ? throw new Exception("Couldn't find window") : proc[0].MainWindowHandle;
        }
        
        public static void SendInput(IntPtr window, byte key, int timeout = 100)
        {
            Thread.Sleep(timeout);
            keybd_event(key, 0, 0, IntPtr.Zero);
            keybd_event(key, 0, 0x0002, IntPtr.Zero);
        }

        public static void Log(string text, LogType type = LogType.Message)
        {
            switch (type)
            {
                case LogType.Message:
                    Console.ResetColor();
                    Console.WriteLine(text);
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(text);
                    Console.ResetColor();
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(text);
                    Console.ResetColor();
                    break;
                case LogType.Info:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(text);
                    Console.ResetColor();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
    }
}