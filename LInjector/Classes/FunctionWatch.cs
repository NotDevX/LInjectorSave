using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using Vip.Notification;
using LInjector.Classes;

namespace LInjector.Classes
{
    internal class FunctionWatch
    {
        private static FileSystemWatcher watcher = new FileSystemWatcher();
        private static String WatchFolder = Path.Combine(FileManager.workspaceFolder, "LINJECTOR");
        public static void runFuncWatch()
        {
            if (!Directory.Exists(WatchFolder))
            {
                Directory.CreateDirectory(WatchFolder);
                Task.Delay(200);
            }

            watcher.Path = WatchFolder;
            watcher.NotifyFilter = NotifyFilters.LastWrite;

            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.EnableRaisingEvents = true;
        }

        public static bool IsFileReady(string filename)
        {
            try
            {
                using (FileStream inputStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    return inputStream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void CreateLog(string String) {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[ROBLOX] {String}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed || watcher.EnableRaisingEvents == false)
            {
                return;
            }
            try
            {
                watcher.EnableRaisingEvents = false;
                
                string functioncallfile = Path.Combine(WatchFolder, "LINJECTOR.li");

                while (!IsFileReady(functioncallfile)) { }

                Task.Delay(60);

                string function = File.ReadAllText(functioncallfile);
                string[] arguments = function.Split(new[] { "|||" }, StringSplitOptions.None).Select(value => value.Trim()).ToArray();

                Console.WriteLine(arguments[0]);

                if (arguments[0] == "showmsg")
                {
                    MessageBox.Show(arguments[1], arguments[2]);
                    return;
                }
                if (arguments[0] == "welcome")
                {
                    RPCManager.SetRPCDetails($"Playing {arguments[2]}");

                    CreateLog($"Hello, { arguments[1]}!\nSuccessfully loaded at {arguments[2]}");
                
                    return;
                }
            }

            finally
            {
                watcher.EnableRaisingEvents = true;
            }
        }
    }
}
