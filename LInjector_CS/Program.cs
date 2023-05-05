using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using KrnlAPI;

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
