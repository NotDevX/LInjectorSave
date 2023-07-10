using System;
using System.Diagnostics;
using System.Windows.Forms;
using LInjector.Classes;

/*
 * 
 * ░▒█░░░░▀█▀░█▀▀▄░░░▀░█▀▀░█▀▄░▀█▀░▄▀▀▄░█▀▀▄
 * ░▒█░░░░▒█░░█░▒█░░░█░█▀▀░█░░░░█░░█░░█░█▄▄▀
 * ░▒█▄▄█░▄█▄░▀░░▀░█▄█░▀▀▀░▀▀▀░░▀░░░▀▀░░▀░▀▀ 
 * 
 * A project by ItzzExcel. Started on May 5, 2023. 
 * LInjector UI Version: v3.5
 *
 * Since Release v01.07.2023a, I added the "Fluxus API," and it should be working.
 * If you have a DLL, you can edit the source code. This is open-source.
 * Monaco is hosted on my website (https://lexploits.netlify.app/extra/monaco).
 * The Monaco Lua syntax highlighting can be found at (https://github.com/ItzzExcel/luau-monaco).
 * You can also ask me about it on Discord (itzzexcel).
 *  
 * The main form is located at Forms/application.
 * You can also remove the Forms/splashscreen.
 *  
 * The application starts with SingleInstanceChecker.CheckInstance(). It's a function that uses Mutex. (Check line 33 to change the startup)
 *  
 */

namespace LInjector
{
    internal static class Program
    {
        public const string currentVersion = "v08.07.2023";
        // Put "f81fb0e34f313b6cf0d0fc345890a33f" for skipping isOutdated MessageBox. 
        // The versions are in format dd/MM/yyy. (adding the v), if it's December 31, 1969, the version is "v31.12.1969"


        [STAThread]
        public static void Main(string[] args)
        {
            if (CheckLatest.IsOutdatedVersion(currentVersion))
            {
                var outDatedResult = MessageBox.Show(
                    "LInjector is outdated, please, re-run LInjector Updating System or download the latest release via GitHub.\n" +
                    "Go to LInjector GitHub?",
                    "LInjector | Outdated", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (outDatedResult == DialogResult.Yes)
                {
                    Process.Start("https://github.com/ItzzExcel/LInjector/releases");
                    CwDt.Cw("LInjector is outdated.");
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TempLog.CreateVersionFile(currentVersion, "version");
            /* rbxversion.DlRbxVersion();
            LocalRbxVersion.CheckLocalRbx(); Uncomment if Hyperion Release */
            CreateFiles.Create();
            ArgumentHandler.AnalyzeArgument(args);
            ConsoleManager.Initialize();
            RPCManager.InitRPC();
            SingleInstance.CheckInstance();
        }
    }
}