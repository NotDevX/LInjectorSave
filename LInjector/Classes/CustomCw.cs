using System;
using System.IO;

namespace LInjector.Classes
{
    public static class CustomCw
    {
        public static void Cw(ConsoleColor contentColor, ConsoleColor titleColor, string content, string title = "")
        {
            var writer = new StreamWriter(Console.OpenStandardOutput());
            writer.AutoFlush = true;
            Console.SetOut(writer);


            ConsoleColor originalContentColor = Console.ForegroundColor;
            ConsoleColor originalTitleColor = Console.BackgroundColor;

            Console.ForegroundColor = contentColor;

            Console.Write("[ " + DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss") + " ] ");
            if (!string.IsNullOrEmpty(title))
            {
                Console.Write("[ " + title + " ] ");
            }

            Console.WriteLine(content);

            Console.ForegroundColor = originalContentColor;
            Console.BackgroundColor = originalTitleColor;
        }
    }
}
