using System;

namespace LInjector.Classes
{
    public static class ArgumentHandler
    {
        public static bool SizableBool;
        public static bool splashEnabled = true;

        public static void AnalyzeArgument(string[] argumentProvided)
        {
            CustomCw.Cw("Called argument analyzer.", false, "debug");

            if (argumentProvided.Length > 0)
            {
                foreach (var argument in argumentProvided)
                    if (argument.Contains("--metalpipe"))
                    {
                        DoPipe.doMetalPipeAsync();
                        CustomCw.Cw("--metalpipe called", false, "debug");
                    }
                    else if (argument.Contains("--bamboopipe"))
                    {
                        DoPipe.doBambooPipeAsync();
                        CustomCw.Cw("--bamboopipe called", false, "debug");
                    }
                    else if (argument.Contains("--debug"))
                    {
                        ConsoleManager.Initialize();
                        ConsoleManager.ShowConsole();
                        Console.Title = "LInjector | Debug";
                        CustomCw.Cw("--debug called.", false, "debug");
                    }
                    else if (argument.Contains("--no-splash"))
                    {
                        splashEnabled = false;
                        CustomCw.Cw("--no-splash called", false, "debug");
                    }
                    else if (argument.Contains("--topmost"))
                    {
                        application app = new application();
                        app.TopMost = true;
                    }
                    else
                    {
                        CustomCw.Cw($"Invalid argument: {argument}", false, "error");
                    }
            }
            else
            {
                CustomCw.Cw("No arguments were provided.", false, "debug");
            }
        }
    }
}
