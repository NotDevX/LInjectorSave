using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Threading;

/*
 * ░▒█░░░░▀█▀░█▀▀▄░░░▀░█▀▀░█▀▄░▀█▀░▄▀▀▄░█▀▀▄░░░▀█▀░█▀▀▄░▀█▀░█▀▀░█▀▀▄░█▀▀▄░█▀▀▄░█░░░░▒█▀▀▀░█░▒█░█▀▀▄░█▀▄░▀█▀░░▀░░▄▀▀▄░█▀▀▄░█▀▀
 * ░▒█░░░░▒█░░█░▒█░░░█░█▀▀░█░░░░█░░█░░█░█▄▄▀░░░▒█░░█░▒█░░█░░█▀▀░█▄▄▀░█░▒█░█▄▄█░█░░░░▒█▀▀░░█░▒█░█░▒█░█░░░░█░░░█▀░█░░█░█░▒█░▀▀▄
 * ░▒█▄▄█░▄█▄░▀░░▀░█▄█░▀▀▀░▀▀▀░░▀░░░▀▀░░▀░▀▀░░░▄█▄░▀░░▀░░▀░░▀▀▀░▀░▀▀░▀░░▀░▀░░▀░▀▀░░░▒█░░░░░▀▀▀░▀░░▀░▀▀▀░░▀░░▀▀▀░░▀▀░░▀░░▀░▀▀▀
 * 
 * Created by depthso/depso (https://github.com/depthso)
 * 
 */

namespace LInjector.Classes
{
    public static class InternalFunctions
    {
        private static DirectoryInfo ScriptsFolder = new DirectoryInfo("Resources\\Internal\\");
        private static FileInfo[] Scripts = ScriptsFolder.GetFiles();

        static DispatcherTimer timer = new DispatcherTimer();

        public static void Load(object sender, EventArgs e)
        {

            foreach (FileInfo file in Scripts)
            {
                var flag = FluxInterfacing.is_injected(FluxInterfacing.pid);

                if (flag)
                {
                    string Script_Content = File.ReadAllText(file.FullName);
                    FluxInterfacing.run_script(FluxInterfacing.pid, Script_Content);
                }
                else
                {
                    break;
                }

                Task.Delay(200);
            }
        }

        public static void RunInternalFunctions()
        {
            timer.Tick += InternalFunctions.Load;
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Start();
        }
    }
}
