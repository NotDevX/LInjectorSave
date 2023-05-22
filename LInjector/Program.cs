using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using LInjector;
using DiscordRPC;
using KrnlAPI;

namespace LInjector
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private const string currentVersion = "v21.05.2023";

        [STAThread]
        static void Main()
        {
            if (GitHubVersionChecker.IsOutdatedVersion(currentVersion))
            {
                MessageBox.Show("LInjector is outdated, please, check github.com/ItzzExcel/LInjector and download the latest release.",
                    "LInjector | Outdated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DiscordRPCManager discordRPCManager = new DiscordRPCManager();
            discordRPCManager.InitRPC();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SingleInstanceChecker.CheckInstance();

        }
    }
}
