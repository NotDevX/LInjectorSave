using System;

namespace LInjector.Classes
{
    public static class ArgumentHandler
    {
        public static bool SizableBool;
        public static bool splashEnabled = true;

        public static void AnalyzeArgument(string[] argumentProvided)
        {
            CwDt.Cw("Called argument analyzer.");

            if (argumentProvided.Length > 0)
            {
                foreach (var argument in argumentProvided)
                    if (argument.Contains("--metalpipe"))
                    {
                        DoPipe.doMetalPipeAsync();
                        CwDt.Cw("--metalpipe called");
                    }
                    else if (argument.Contains("--bamboopipe"))
                    {
                        DoPipe.doBambooPipeAsync();
                        CwDt.Cw("--bamboopipe called");
                    }
                    else if (argument.Contains("--debug"))
                    {
                        ConsoleManager.Initialize();
                        ConsoleManager.ShowConsole();
                        Console.Title = "LInjector | Debug";
                        CwDt.Cw("--debug called.");
                    }
                    else if (argument.Contains("--sizable"))
                    {
                        SizableBool = true;
                        CwDt.Cw("--sizable called");
                    }
                    else if (argument.Contains("--no-splash"))
                    {
                        splashEnabled = false;
                        CwDt.Cw("--no-splash called");
                    }
                    else if (argument.Contains("--topmost"))
                    {
                        application app = new application();
                        app.TopMost = true;
                    }
                    else
                    {
                        CwDt.Cw($"Invalid argument: {argument}");
                    }
            }
            else
            {
                CwDt.Cw("No arguments were provided.");
            }
        }
    }
}
