using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInjector.Classes
{
    public static class argumentHandler
    {
        public static void analyzeArgument (string[] argumentProvided)
        {
            if (argumentProvided.Length > 0 && argumentProvided[0] == "--metalpipe")
            {
                doPipe.doMetalPipeAsync();
                Console.WriteLine("--metalpipe called.");
            } 
            if (argumentProvided.Length > 0 && argumentProvided[0] == "--bamboopipe")
            {
                doPipe.doBambooPipeAsync();
                Console.WriteLine("--bamboopipe called.");
            }
        }
    }
}
