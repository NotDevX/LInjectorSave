using System;
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
        public const string currentVersion = "v01.07.2023a";
        // Put "f81fb0e34f313b6cf0d0fc345890a33f" for skipping isOutdated MessageBox. 
        // The versions are in format dd/MM/yyy. (adding the v), if it's December 31, 1969, the version is "v31.12.1969"


        [STAThread]
        public static void Main(string[] args)
        {

            if (GitHubVersionChecker.IsOutdatedVersion(currentVersion) == true)
            {
                DialogResult outDatedResult = MessageBox.Show("LInjector is outdated, please, re-run LInjector Updating System or download the latest release via GitHub.\n" +
                    "Go to LInjector GitHub?",
                    "LInjector | Outdated", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (outDatedResult == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start("https://github.com/ItzzExcel/LInjector/releases");
                    cwDt.CwDt("LInjector is outdated.");
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            tempLog.CreateVersionFile(currentVersion, "version");
            rbxversion.dlRbxVersion();
            CreateShortcuts.Create();
            localRbxVersion.CheckLocalRbx();
            ArgumentHandler.AnalyzeArgument(args);
            ConsoleManager.Initialize();
            DiscordRPCManager.InitRPC();
            SingleInstanceChecker.CheckInstance();
        }
    }
}
