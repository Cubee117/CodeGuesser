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
            var proc = Process.GetProcessesByName(procName);
            return proc.Length == 0 ? throw new Exception("Couldn't find window") : proc[0].MainWindowHandle;
        }
        
        public static void SendInput(IntPtr window, byte key, int timeout = 100)
        {
            SetForegroundWindow(window);
            Thread.Sleep(timeout);
            keybd_event(key, 0, 0, IntPtr.Zero);
            keybd_event(key, 0, 0x0002, IntPtr.Zero);
        }
        
    }
}