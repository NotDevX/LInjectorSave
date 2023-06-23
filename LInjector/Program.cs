using System;
using System.Text;
using System.Windows.Forms;
using LInjector.Classes;
/*
 * ░▒█░░░░▀█▀░█▀▀▄░░░▀░█▀▀░█▀▄░▀█▀░▄▀▀▄░█▀▀▄
 * ░▒█░░░░▒█░░█░▒█░░░█░█▀▀░█░░░░█░░█░░█░█▄▄▀
 * ░▒█▄▄█░▄█▄░▀░░▀░█▄█░▀▀▀░▀▀▀░░▀░░░▀▀░░▀░▀▀ 
 * 
 * A project by ItzzExcel. Started at May 5, 2023. (v3.5)
 */

/* Krnl API is down, (maybe it will not come back with the API).
 * If you designed your own injector, chenge every single related to Krnl with your DLL.
 * Don't ask for support to the Discord Server for this.
 * The Monaco is hosted in my website (https://lexploits.netlify.app/extra/monaco)
 * Monaco open and saving file functions haves some issues with string.
 * The Monaco highlighting it's in (https://github.com/ItzzExcel/luau-monaco).
 *  You can also ask me for it by Discord (itzzexcel), but it's harder to get a response.
 *  
 *  The main form is located at Forms/application
 *  You can also remove the Forms/splashscreen
 *  
 *  The start of the application is SingleInstanceChecker.CheckInstance(), it's a function that uses Mutex. (Check line 33 to change startup)
 *  
 */

namespace LInjector
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private static string[] convertToArray(string normalizedString)
        {
            return new[] { normalizedString };
        }

        public const string currentVersion = "v22.06.2023";
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
            tempLog.CreateVersionFile(currentVersion);
            cwDt.CwDt("Called argument analyzer.");
            argumentHandler.analyzeArgument(args);
            ConsoleManager.Initialize();
            DiscordRPCManager.InitRPC();
            SingleInstanceChecker.CheckInstance();
        }
    }
}
