using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using LInjector;
using DiscordRPC;
using KrnlAPI;
using System.Runtime.CompilerServices;

namespace LInjector
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        public const string currentVersion = "26.05.2023";

        [STAThread]
        static void Main()
        {
            if (GitHubVersionChecker.IsOutdatedVersion(currentVersion))
            {
                MessageBox.Show("LInjector is outdated, please, check https://github.com/ItzzExcel/LInjector and download the latest release.",
                    "LInjector | Outdated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start("https://github.com/ItzzExcel/LInjector/releases");
            }

            DiscordRPCManager discordRPCManager = new DiscordRPCManager();
            discordRPCManager.InitRPC();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleInstanceChecker.CheckInstance();

        }
    }
}
