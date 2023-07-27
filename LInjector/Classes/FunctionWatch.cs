using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private static void CreateLog(string String)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"[ROBLOX] {String}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected static void clipboardSetText(string inTextToCopy)
        {
            var clipboardThread = new Thread(() => clipBoardThreadWorker(inTextToCopy));
            clipboardThread.SetApartmentState(ApartmentState.STA);
            clipboardThread.IsBackground = false;
            clipboardThread.Start();
        }
        private static void clipBoardThreadWorker(string inTextToCopy)
        {
            System.Windows.Clipboard.SetText(inTextToCopy);
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

                string function = "";

                try
                {
                    function = File.ReadAllText(functioncallfile);
                }
                catch {
                    Console.WriteLine("Failed to capture data!");
                    return;
                }
                
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

                    CreateLog($"Hello, {arguments[1]}!\nSuccessfully loaded at {arguments[2]}");

                    return;
                }
                if (arguments[0] == "welcome")
                {
                    RPCManager.SetRPCDetails($"Playing {arguments[2]}");

                    CreateLog($"Hello, {arguments[1]}!\nSuccessfully loaded at {arguments[2]}");

                    return;
                }
                if (arguments[0] == "toClipboard")
                {
                    clipboardSetText(arguments[1].ToString());
                    return;
                }
                if (arguments[0] == "closeconsole")
                {
                    ConsoleManager.HideConsole();
                    return;
                }
                if (arguments[0] == "showconsole")
                {
                    ConsoleManager.ShowConsole();
                    return;
                }
                if (arguments[0] == "rprintconsole")
                {
                    ConsoleManager.ShowConsole();
                    Console.WriteLine(arguments[1]);

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
