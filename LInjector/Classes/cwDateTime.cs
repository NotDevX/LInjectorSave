using System;
using System.IO;

namespace LInjector.Classes
{
    public static class cwDt
    {
        public static void CwDt(string cwMsg)
        {
            var writer = new StreamWriter(Console.OpenStandardOutput());
            writer.AutoFlush = true;
            Console.SetOut(writer);
            Console.WriteLine("[ " + DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss") + " ] " + cwMsg);
        }
    }
}
