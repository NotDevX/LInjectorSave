using System;

namespace LInjector.Classes
{
    public static class ArgumentHandler
    {
        public static bool SizableBool;
        public static bool splashEnabled = true;

        public static void AnalyzeArgument(string[] argumentProvided)
        {
            cwDt.CwDt("Called argument analyzer.");

            if (argumentProvided.Length > 0)
            {
                foreach (var argument in argumentProvided)
                    if (argument.Contains("--metalpipe"))
                    {
                        DoPipe.doMetalPipeAsync();
                        cwDt.CwDt("--metalpipe called.");
                    }
                    else if (argument.Contains("--bamboopipe"))
                    {
                        DoPipe.doBambooPipeAsync();
                        cwDt.CwDt("--bamboopipe called.");
                    }
                    else if (argument.Contains("--debug"))
                    {
                        ConsoleManager.Initialize();
                        ConsoleManager.ShowConsole();
                        Console.Title = "LInjector | Debug";
                        cwDt.CwDt("--debug called.");
                    }
                    else if (argument.Contains("--sizable"))
                    {
                        SizableBool = true;
                        cwDt.CwDt("--sizable called");
                    }
                    else if (argument.Contains("--no-splash"))
                    {
                        splashEnabled = false;
                        cwDt.CwDt("--no-splash called");
                    }
                    else
                    {
                        cwDt.CwDt($"Invalid argument: {argument}");
                    }
            }
            else
            {
                cwDt.CwDt("No arguments were provided.");
            }
        }
    }
}