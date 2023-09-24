using LInjector.Classes;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LInjector
{
    internal class Program
    {
        public const string currentVersion = "v22.09.2023";

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var application = new LInjectorApplication();
            application.Run(args);
        }
    }

    internal class LInjectorApplication
    {
        public void Run(string[] args)
        {
            CreateFiles.Create();
            ConfigHandler.DoConfig();
            TempLog.CreateVersionFile(Program.currentVersion, "version");
            ArgumentHandler.AnalyzeArgument(args);
            ConsoleManager.Initialize();
            RPCManager.InitRPC();

            SingleInstance.DoTheRun();
        }
    }
}
