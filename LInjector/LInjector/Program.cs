using LInjector.Classes;
using System;
using System.Diagnostics;
using System.Windows.Forms;

/*
 * 
 * ░▒█░░░░▀█▀░█▀▀▄░░░▀░█▀▀░█▀▄░▀█▀░▄▀▀▄░█▀▀▄
 * ░▒█░░░░▒█░░█░▒█░░░█░█▀▀░█░░░░█░░█░░█░█▄▄▀
 * ░▒█▄▄█░▄█▄░▀░░▀░█▄█░▀▀▀░▀▀▀░░▀░░░▀▀░░▀░▀▀ 
 * 
 * A project by ItzzExcel. Started on May 5, 2023. 
 * LInjector UI Version: v3.5
 *
 * Since Release v01.07.2023a, I added the "WRD/Fluxteam Module" and it should be working.
 * If you have a DLL, you can edit the source code. This is open-source.
 * The Monaco Luau syntax highlighting can be found at (https://github.com/ItzzExcel/LInjector/tree/Monaco).
 *  
 * The main form is located at Forms/application.
 * You can also remove the Forms/splashscreen.
 * Special Thanks to depso (https://github.com/depthso) for contribuiting a lot on this project.
 * 
 * The application starts with SingleInstanceChecker.DoTheRun().
 *  
 */

namespace LInjector
{
    internal static class Program
    {
        public const string currentVersion = "v13.08.2023";
        // Put "f81fb0e34f313b6cf0d0fc345890a33f" for skipping isOutdated MessageBox. 
        // The versions are in format dd/MM/yyy. (adding the v), if it's December 31, 1969, the version is "v31.12.1969"


        [STAThread]
        public static void Main(string[] args)
        {
            if (CheckLatest.IsOutdatedVersion(currentVersion))
            {
                var outDatedResult = MessageBox.Show(
                    "LInjector is outdated, please, re-run LInjector Updating System or download the latest release via LExploits Website.\n" +
                    "Go to LInjector Download Page?",
                    "LInjector | Outdated", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (outDatedResult == DialogResult.Yes)
                {
                    Process.Start("https://lexploits.netlify.app/extra/linjector/download/");
                    CustomCw.Cw("LInjector is outdated", false, "warning");
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            CreateFiles.Create();
            ConfigHandler.DoConfig();
            TempLog.CreateVersionFile(currentVersion, "version");
            ArgumentHandler.AnalyzeArgument(args);
            ConsoleManager.Initialize();
            RPCManager.InitRPC();
            _ = RbxVersion.GetRobloxVersionUWP();
            SingleInstance.DoTheRun();
        }
    }
}
