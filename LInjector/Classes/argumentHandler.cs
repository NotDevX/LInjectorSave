using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInjector.Classes
{
    public static class argumentHandler
    {
        public static void analyzeArgument(string[] argumentProvided)
        {
            if (argumentProvided.Length > 0 && argumentProvided[0] == "--metalpipe")
            {
                doPipe.doMetalPipeAsync();
                cwDt.CwDt("--metalpipe called.");
            }
            if (argumentProvided.Length > 0 && argumentProvided[0] == "--bamboopipe")
            {
                doPipe.doBambooPipeAsync();
                cwDt.CwDt("--bamboopipe called.");
            }
            if (argumentProvided.Length > 0 && argumentProvided[0] == "--show-console")
            {
                ConsoleManager.Initialize();
                ConsoleManager.ShowConsole();
                Console.Title = "LInjector";
                cwDt.CwDt("--show-console called.");
            }
            if (argumentProvided.Length <= 0)
            {
                cwDt.CwDt("No argument were provided.");
            }
        }
    }
}
