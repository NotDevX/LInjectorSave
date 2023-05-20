using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using KrnlAPI;
using DiscordRPC;
using System.Threading;
using LInjector;
using CheckGitHubRelease;

namespace LInjector
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        private const string currentVersion = "v18.05.2023"; // Current LInjector Version

        [STAThread]

        static void Main()
        {

            if (GitHubVersionChecker.IsOutdatedVersion(currentVersion))
            {
                MessageBox.Show("LInjector is outdated, please, check github.com/ItzzExcel/LInjector and download the latest release.",
                    "LInjector | Outadted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            var inmainpresence = new RichPresence()
            {
                Details = "Using LInjector by LExploits",
                State = "Exploiting",
                Assets = new Assets()
                {
                    LargeImageKey = "https://lexploits.netlify.app/extra/cdn/LInjector%20ico.png",
                    LargeImageText = "by The LExploits Project.",
                }
            };

            DiscordRpcClient client;

            client = new DiscordRpcClient("1104489169314660363");
            client.Initialize();
            client.SetPresence(inmainpresence);

            String LInjInstance = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(p => p.ProcessName == LInjInstance) > 1)
            {
                MessageBox.Show("A LInjector Instance is already running.");
                Application.Exit(); return;
            }

            KrnlApi krnlApi = new KrnlApi();
            WebClient WebClient = new WebClient();

            string LInjKey = WebClient.DownloadString("https://lexploits.netlify.app/extra/key");
            string keyPath = Path.Combine(Path.GetTempPath(), "LInjector", "key");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists(keyPath))
            {
                string fileContent = File.ReadAllText(keyPath);
                if (fileContent.Trim() == LInjKey)
                {
                    Application.Run(new Form2());
                    krnlApi.Initialize();
                    client.SetPresence(inmainpresence);
                }
                else
                {
                    Application.Run(new Form1());
                }
            }
            else { Application.Run(new Form1()); }
        }
    }
}
