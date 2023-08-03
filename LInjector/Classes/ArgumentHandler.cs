using System;

namespace LInjector.Classes
{
    public static class ArgumentHandler
    {
        public static bool SizableBool;
        public static bool splashEnabled = true;

        public static void AnalyzeArgument(string[] argumentProvided)
        {
            CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, "Called argument analyzer.", "DEBUG");

            if (argumentProvided.Length > 0)
            {
                foreach (var argument in argumentProvided)
                    if (argument.Contains("--metalpipe"))
                    {
                        DoPipe.doMetalPipeAsync();
                        CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, "--metalpipe called", "DEBUG");
                    }
                    else if (argument.Contains("--bamboopipe"))
                    {
                        DoPipe.doBambooPipeAsync();
                        CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, "--bamboopipe called", "DEBUG");
                    }
                    else if (argument.Contains("--debug"))
                    {
                        ConsoleManager.Initialize();
                        ConsoleManager.ShowConsole();
                        Console.Title = "LInjector | Debug";
                        CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, "--debug called.", "DEBUG");
                    }
                    else if (argument.Contains("--no-splash"))
                    {
                        splashEnabled = false;
                        CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, "--no-splash called", "DEBUG");
                    }
                    else if (argument.Contains("--topmost"))
                    {
                        application app = new application();
                        app.TopMost = true;
                    }
                    else
                    {
                        CustomCw.Cw(ConsoleColor.Red, ConsoleColor.DarkRed, $"Invalid argument: {argument}", "ERROR");
                    }
            }
            else
            {
                CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, "No arguments were provided.", "DEBUG");
            }
        }
    }
}
