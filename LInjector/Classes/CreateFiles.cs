using IWshRuntimeLibrary;
using System;
using System.IO;
using System.Net;
using File = System.IO.File;

namespace LInjector.Classes
{
    public static class CreateFiles
    {


        private static WebClient webClient = new WebClient();
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
        }
    }
}
