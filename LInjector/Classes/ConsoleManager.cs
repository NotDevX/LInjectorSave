using System;
using System.IO;
using System.Runtime.InteropServices;

namespace LInjector.Classes
{
    public static class ConsoleManager
    {
        public static bool isConsoleVisible;

        [DllImport("kernel32.dll")]
        private static extern bool SetConsoleCtrlHandler(ConsoleCtrlHandlerDelegate handlerRoutine, bool add);

        private static bool ConsoleCtrlHandler(int eventType)
        {
            if (eventType == 2)
            {
                HideConsole();
                return true;
            }

            return false;
        }

        public static void ShowConsole()
        {
            if (!isConsoleVisible)
            {
                AllocConsole();
                Console.Title = "LInjector";
                isConsoleVisible = true;
                var writer = new StreamWriter(Console.OpenStandardOutput());
                Console.SetOut(writer);
            }
        }

        public static void HideConsole()
        {
            if (isConsoleVisible)
            {
                FreeConsole();
                isConsoleVisible = false;
            }
        }

        public static void Initialize()
        {
            SetConsoleCtrlHandler(ConsoleCtrlHandler, true);
        }

        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll")]
        private static extern bool FreeConsole();

        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        private delegate bool ConsoleCtrlHandlerDelegate(int eventType);
    }
}