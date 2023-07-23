using System;
using System.IO;
using System.Windows.Forms;
using System.Windows.Threading;

/*
 * ░▒█░░░░▀█▀░█▀▀▄░░░▀░█▀▀░█▀▄░▀█▀░▄▀▀▄░█▀▀▄░░░▀█▀░█▀▀▄░▀█▀░█▀▀░█▀▀▄░█▀▀▄░█▀▀▄░█░░░░▒█▀▀▀░█░▒█░█▀▀▄░█▀▄░▀█▀░░▀░░▄▀▀▄░█▀▀▄░█▀▀
 * ░▒█░░░░▒█░░█░▒█░░░█░█▀▀░█░░░░█░░█░░█░█▄▄▀░░░▒█░░█░▒█░░█░░█▀▀░█▄▄▀░█░▒█░█▄▄█░█░░░░▒█▀▀░░█░▒█░█░▒█░█░░░░█░░░█▀░█░░█░█░▒█░▀▀▄
 * ░▒█▄▄█░▄█▄░▀░░▀░█▄█░▀▀▀░▀▀▀░░▀░░░▀▀░░▀░▀▀░░░▄█▄░▀░░▀░░▀░░▀▀▀░▀░▀▀░▀░░▀░▀░░▀░▀▀░░░▒█░░░░░▀▀▀░▀░░▀░▀▀▀░░▀░░▀▀▀░░▀▀░░▀░░▀░▀▀▀
 * 
 * Created with help of depthso/depso (https://github.com/depthso/)
 * Modified by ItzzExcel the File.ReadAllText()
 * 
 */

namespace LInjector.Classes
{
    public static class InternalFunctions
    {
        private static readonly string ScriptPath = "Resources\\scripts\\functions.lua";


        static DispatcherTimer timer = new DispatcherTimer();

        public static void Load(object sender, EventArgs e)
        {
            if (File.Exists(ScriptPath))
            {
                var flag = FluxusAPI.is_injected(FluxusAPI.pid);
                if (flag)
                {
                    try
                    {
                        string scriptContent = File.ReadAllText(ScriptPath);
                        FluxusAPI.run_script(FluxusAPI.pid, scriptContent);
                    }
                    catch (Exception ex)
                    {
                        ThreadBox.MsgThread($"Error reading the content of {ScriptPath}: {ex.Message}",
                                            "LInjector | Error",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                ThreadBox.MsgThread($"Couldn't find the path of {ScriptPath}, retry downloading LInjector.",
                                    "LInjector | Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
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
