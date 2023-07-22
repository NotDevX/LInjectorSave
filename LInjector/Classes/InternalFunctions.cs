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
 * 
 * 
 */

namespace LInjector.Classes
{
    public static class InternalFunctions
    {
        private static readonly string ScriptPath = ".\\Resources\\scripts\\functions.lua";
        private static readonly string ScriptContent = File.ReadAllText(ScriptPath);
        private static application GetApplication = new application();
        public static void Load(object sender, EventArgs e)
        {
            if (!File.Exists(ScriptPath))
            {
                ThreadBox.MsgThread($"Couldn't find the path of {ScriptPath}, retry downloading LInjector.",
                                    "LInjector | Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
            }
            else
            {
                var flag = FluxusAPI.is_injected(FluxusAPI.pid);
                if (flag)
                {
                    FluxusAPI.run_script(FluxusAPI.pid, ScriptContent);
                }
                else
                {
                    _ = NotificationManager.FireNotification("Not injected", GetApplication.infSettings);
                }
            }
        }

        public static void RunInternalFunctions()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += InternalFunctions.Load;
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Start();
        }
    }
}
