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
            if (CheckLatest.IsOutdatedVersion(Program.currentVersion))
            {
                DialogResult outDatedResult = MessageBox.Show(
                    "LInjector is outdated, please, re-run LInjector Updating System or download the latest release via LExploits Website.\n" +
                    "Go to LInjector Download Page?",
                    "LInjector | Outdated", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (outDatedResult == DialogResult.Yes)
                {
                    Process.Start("https://lexploits.netlify.app/extra/linjector/download/");
                    CustomCw.Cw("LInjector is outdated", false, "warning");
                }
            }

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
