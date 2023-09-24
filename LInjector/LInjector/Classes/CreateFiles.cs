using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using File = System.IO.File;

namespace LInjector.Classes
{
    public static class CreateFiles
    {
        private static readonly WebClient webClient = new WebClient();
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly WshShell wsh = new WshShell();

        public static void Create()
        {
            if (!File.Exists(".\\workspace.lnk"))
            {
                var shortcut = (IWshShortcut)wsh.CreateShortcut(".\\workspace.lnk");
                shortcut.TargetPath = FileManager.workspaceFolder;
                shortcut.Save();
            }

            if (!File.Exists(".\\autoexec.lnk"))
            {
                var shortcut = (IWshShortcut)wsh.CreateShortcut(".\\autoexec.lnk");
                shortcut.TargetPath = FileManager.autoexecFolder;
                shortcut.Save();
            }

            if (!Directory.Exists(".\\Resources\\libs"))
            {
                Directory.CreateDirectory(".\\Resources\\libs");
            }
        }

        public static void RedownloadModules()
        {
            var Interfacer = new Uri("https://raw.githubusercontent.com/NotExcelz/LInjector/master/Redistributables/DLLs/FluxteamAPI.dll");
            var Module = new Uri("https://raw.githubusercontent.com/NotExcelz/LInjector/master/Redistributables/DLLs/Module.dll");

            if (Directory.Exists("Resources\\libs"))
            {
                DeleteFilesAndFoldersRecursively("Resources\\libs");
                Directory.CreateDirectory("Resources\\libs");
            }

            webClient.DownloadFile(Interfacer, "Resources\\libs\\FluxteamAPI.dll");
            webClient.DownloadFile(Module, "Resources\\libs\\Module.dll");
        }
        public static void DeleteFilesAndFoldersRecursively(string target_dir)
        {
            foreach (string file in Directory.GetFiles(target_dir))
            {
                File.Delete(file);
            }

            foreach (string subDir in Directory.GetDirectories(target_dir))
            {
                DeleteFilesAndFoldersRecursively(subDir);
            }

            Thread.Sleep(1);
            Directory.Delete(target_dir);
        }
    }
}
