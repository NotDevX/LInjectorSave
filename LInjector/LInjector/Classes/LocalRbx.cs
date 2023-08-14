using System;
using System.IO;

namespace LInjector.Classes
{
    public static class LocalRbx
    {
        public static string Version { get; set; }

        public static void CheckLocalRbx()
        {
            var localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var versionsFolderPath = Path.Combine(localAppDataFolder, "Roblox", "Versions");
            var versionFolders = Directory.GetDirectories(versionsFolderPath, "version-*");

            foreach (var versionFolder in versionFolders)
            {
                string[] playerExecutables = { "RobloxPlayerBeta.exe", "RobloxPlayerLauncher.exe" };

                foreach (var executable in playerExecutables)
                {
                    var filePath = Path.Combine(versionFolder, executable);

                    if (File.Exists(filePath))
                    {
                        Version = Path.GetFileName(versionFolder);
                        Console.WriteLine("Roblox Game Client (Hyperion Release) folder found!: " + Version);
                        return;
                    }
                }
            }

            Console.WriteLine("Couldn't locate Roblox Game Client (Hyperion Release) folder in LocalApplicationData");
            Version = "N/A"; // This means that couldn't find Roblox Game Client
        }
    }
}