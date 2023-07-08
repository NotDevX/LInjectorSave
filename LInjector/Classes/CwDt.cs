using System;
using System.IO;

namespace LInjector.Classes
{
    public static class CwDt
    {
        public static void Cw(string cwMsg)
        {
            var writer = new StreamWriter(Console.OpenStandardOutput());
            writer.AutoFlush = true;
            Console.SetOut(writer);
            Console.WriteLine("[ " + DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss") + " ] " + cwMsg);
        }
    }
}