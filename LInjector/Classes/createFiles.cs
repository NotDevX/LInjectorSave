using System;
using System.IO;
using System.Net;
using IWshRuntimeLibrary;
using File = System.IO.File;

namespace LInjector.Classes
{
    public static class CreateFiles
    {
        private static readonly string localAppDataFolder =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        private static readonly string RobloxACFolder = Path.Combine(localAppDataFolder, "Packages",
            "ROBLOXCORPORATION.ROBLOX_55nm5eh3cm0pr", "AC");

        private static readonly string workspaceFolder = Path.Combine(RobloxACFolder, "workspace");
        private static readonly string autoexecFolder = Path.Combine(RobloxACFolder, "autoexec");
        private static WebClient webClient = new WebClient();
        private static readonly WshShell wsh = new WshShell();

        public static void Create()
        {
            if (!File.Exists(".\\workspace.lnk"))
            {
                var shortcut = (IWshShortcut)wsh.CreateShortcut(".\\workspace.lnk");
                shortcut.TargetPath = workspaceFolder;
                shortcut.Save();
            }

            if (!File.Exists(".\\autoexec.lnk"))
            {
                var shortcut = (IWshShortcut)wsh.CreateShortcut(".\\autoexec.lnk");
                shortcut.TargetPath = autoexecFolder;
                shortcut.Save();
            }
        }
    }
}