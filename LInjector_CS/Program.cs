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

namespace LInjector_CS
{
    internal static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {

            var presence = new RichPresence()
            {
                Details = "Using LInjector.",
                State = "Exploiting.",
                Assets = new Assets()
                {
                    LargeImageKey = "https://lexploits.netlify.app/extra/cdn/LInjector%20ico.png",
                    LargeImageText = "by LExploits.",
                }
            };

            DiscordRpcClient client;

            client = new DiscordRpcClient("1104489169314660363");
            client.Initialize();

            client.SetPresence(presence);

            String thisprocessname = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
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
                if (fileContent.Trim() == LInjKey) {
                    Application.Run(new Form2());
                    krnlApi.Initialize();
                } else {
                    Application.Run(new Form1());
                }
            } else {Application.Run(new Form1());}
        }
    }
}
