using System;
using System.IO;

namespace LInjector.Classes
{
    public static class localRbxVersion
    {
        public static string Version { get; set; }

        public static void CheckLocalRbx()
        {
            string localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string versionsFolderPath = Path.Combine(localAppDataFolder, "Roblox", "Versions");
            string[] versionFolders = Directory.GetDirectories(versionsFolderPath, "version-*");

            foreach (string versionFolder in versionFolders)
            {
                string[] playerExecutables = { "RobloxPlayerBeta.exe", "RobloxPlayerLauncher.exe" };

                foreach (string executable in playerExecutables)
                {
                    string filePath = Path.Combine(versionFolder, executable);

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