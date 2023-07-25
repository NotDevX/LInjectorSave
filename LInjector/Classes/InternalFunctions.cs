using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Threading;

/*
 * ░▒█░░░░▀█▀░█▀▀▄░░░▀░█▀▀░█▀▄░▀█▀░▄▀▀▄░█▀▀▄░░░▀█▀░█▀▀▄░▀█▀░█▀▀░█▀▀▄░█▀▀▄░█▀▀▄░█░░░░▒█▀▀▀░█░▒█░█▀▀▄░█▀▄░▀█▀░░▀░░▄▀▀▄░█▀▀▄░█▀▀
 * ░▒█░░░░▒█░░█░▒█░░░█░█▀▀░█░░░░█░░█░░█░█▄▄▀░░░▒█░░█░▒█░░█░░█▀▀░█▄▄▀░█░▒█░█▄▄█░█░░░░▒█▀▀░░█░▒█░█░▒█░█░░░░█░░░█▀░█░░█░█░▒█░▀▀▄
 * ░▒█▄▄█░▄█▄░▀░░▀░█▄█░▀▀▀░▀▀▀░░▀░░░▀▀░░▀░▀▀░░░▄█▄░▀░░▀░░▀░░▀▀▀░▀░▀▀░▀░░▀░▀░░▀░▀▀░░░▒█░░░░░▀▀▀░▀░░▀░▀▀▀░░▀░░▀▀▀░░▀▀░░▀░░▀░▀▀▀
 * 
 * Created by depthso/depso (https://github.com/depthso/)
 * 
 */

namespace LInjector.Classes
{
    public static class InternalFunctions
    {
        private static DirectoryInfo ScriptsFolder = new DirectoryInfo("Resources\\InternalScripts");
        private static FileInfo[] Scripts = ScriptsFolder.GetFiles();

        static DispatcherTimer timer = new DispatcherTimer();

        public static void Load(object sender, EventArgs e)
        {
            foreach (FileInfo file in Scripts)
            {
                var flag = Fluxus.is_injected(Fluxus.pid);

                if (flag)
                {
                    string Script_Content = File.ReadAllText(file.FullName);
                    FluxusAPI.run_script(Fluxus.pid, Script_Content);
                }
                else {
                    break;
                }

                Task.Delay(200);
            }
        }

        public static void RunInternalFunctions()
        {
            timer.Tick += InternalFunctions.Load;
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Start();
        }
    }
}
