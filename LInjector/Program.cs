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

        public const string currentVersion = "f81fb0e34f313b6cf0d0fc345890a33f"; // Put "f81fb0e34f313b6cf0d0fc345890a33f" for skipping TextBox.

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
