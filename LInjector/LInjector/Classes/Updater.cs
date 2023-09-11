using IWshRuntimeLibrary;
using Octokit;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using File = System.IO.File;

namespace LInjector.Classes
{
    public static class Files
    {
        public static readonly string localAppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public static readonly string RobloxACFolder = Path.Combine(localAppDataFolder, "Packages", "ROBLOXCORPORATION.ROBLOX_55nm5eh3cm0pr", "AC");
        public static readonly string workspaceFolder = Path.Combine(RobloxACFolder, "workspace");
        public static readonly string autoexecFolder = Path.Combine(RobloxACFolder, "autoexec");
        public static readonly string exeLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
        public static readonly string exeDirectory = Path.GetDirectoryName(exeLocation);
        public static readonly string desiredDirectoryName = "LInjector";
        public static readonly string ModulePath = ".\\Resources\\libs\\Module.dll";
        public static readonly string GitHubHash = "https://api.github.com/repos/ItzzExcel/LInjector/commits?path=Redistributables/DLLs/Module.dll&page=1&per_page=1";
        public static readonly string currentVersion = "v10.09.2023";
    }

    public static class CreateFiles
    {
        private static readonly WebClient webClient = new WebClient();
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly WshShell wsh = new WshShell();

        public static void Create()
        {
            if (!Files.exeDirectory.Contains(Files.desiredDirectoryName))
            {
                try
                {
                    string newDirectory = Path.GetDirectoryName(Files.exeDirectory);
                    Directory.SetCurrentDirectory(newDirectory);

                    Console.WriteLine($"Set current directory to: {newDirectory}");
                }
                catch { ThreadBox.MsgThread($"Looks like you ran LInjector from another location that is not the LInjector folder. Try opening it from {Files.desiredDirectoryName}", "LInjector | ERROR", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error); }
            }

            if (!File.Exists(".\\workspace.lnk"))
            {
                var shortcut = (IWshShortcut)wsh.CreateShortcut(".\\workspace.lnk");
                shortcut.TargetPath = Files.workspaceFolder;
                shortcut.Save();
            }

            if (!File.Exists(".\\autoexec.lnk"))
            {
                var shortcut = (IWshShortcut)wsh.CreateShortcut(".\\autoexec.lnk");
                shortcut.TargetPath = Files.autoexecFolder;
                shortcut.Save();
            }

            if (!Directory.Exists(".\\Resources\\libs"))
            {
                Directory.CreateDirectory(".\\Resources\\libs");
            }

            if (!Directory.Exists(".\\scripts"))
            {
                Directory.CreateDirectory(".\\scripts");
            }

            if (!Directory.Exists(Files.workspaceFolder))
            {
                Directory.CreateDirectory(Files.workspaceFolder);
            }

            if (!Directory.Exists(Files.autoexecFolder))
            {
                Directory.CreateDirectory(Files.autoexecFolder);
            }

            if (!File.Exists(".\\Resources\\libs\\Module.dll"))
            {
                DownloadModule();
            }

            if (!File.Exists(".\\Resources\\libs\\FluxteamAPI.dll"))
            {
                DownloadInterfacer();
            }
        }

        public static void RedownloadModules()
        {
            var Interfacer = new Uri("https://raw.githubusercontent.com/ItzzExcel/LInjector/master/Redistributables/DLLs/FluxteamAPI.dll");
            var Module = new Uri("https://raw.githubusercontent.com/ItzzExcel/LInjector/master/Redistributables/DLLs/Module.dll");

            if (Directory.Exists("Resources\\libs"))
            {
                DeleteFilesAndFoldersRecursively("Resources\\libs");
                Directory.CreateDirectory("Resources\\libs");
            }

            webClient.DownloadFile(Interfacer, "Resources\\libs\\FluxteamAPI.dll");
            webClient.DownloadFile(Module, "Resources\\libs\\Module.dll");
        }

        public static void DownloadInterfacer()
        {
            var Interfacer = new Uri("https://raw.githubusercontent.com/ItzzExcel/LInjector/master/Redistributables/DLLs/FluxteamAPI.dll");
            webClient.DownloadFile(Interfacer, "Resources\\libs\\FluxteamAPI.dll");
        }

        public static void DownloadModule()
        {
            var Module = new Uri("https://raw.githubusercontent.com/ItzzExcel/LInjector/master/Redistributables/DLLs/Module.dll");
            webClient.DownloadFile(Module, "Resources\\libs\\Module.dll");
        }

        public static void DeleteFilesAndFoldersRecursively(string target_dir)
        {
            foreach (string file in Directory.GetFiles(target_dir))
            {
                try { File.Delete(file); } catch { }
            }

            foreach (string subDir in Directory.GetDirectories(target_dir))
            {
                DeleteFilesAndFoldersRecursively(subDir);
            }

            Task.Delay(1000);
            try { Directory.Delete(target_dir, true); } catch { }
        }
    }

    public static class TempLog
    {
        public static void CreateVersionFile(string content, string fileName)
        {
            var tempPath = Path.GetTempPath();
            var linjectorFolderPath = Path.Combine(tempPath, "LInjector");
            var versionFilePath = Path.Combine(linjectorFolderPath, fileName);

            if (!Directory.Exists(linjectorFolderPath))
            {
                Directory.CreateDirectory(linjectorFolderPath);
            }

            if (File.Exists(versionFilePath) || !File.Exists(versionFilePath))
            {
                File.WriteAllText(versionFilePath, content);
            }
        }
    }

    public static class VersionChecker
    {
        public static string Version { get; set; }
        static string appName = "ROBLOXCORPORATION.ROBLOX";
        static string outputDirectory = Path.Combine(Path.GetTempPath(), "LInjector");
        static string versionFilePath = Path.Combine(outputDirectory, "uwpversion");

        // This PowerShell scripts saves the current installed Roblox Version in Temp/LInjector/uwpversion
        // If it's not installed, It will return a message saying "The app is not installed".

        public static string script = @"
            $appxPackage = Get-AppxPackage | Where-Object { $_.Name -eq '" + appName + @"' }
            if ($appxPackage) {
                $appVersion = $appxPackage.Version
            } else {
                $appVersion = 'The application " + appName + @" it''s not installed.'
            }
            $appVersion | Out-File -FilePath '" + versionFilePath + @"'
        ";


        // This is for Hyperion Roblox (x64 Client)

        public static async Task DlRbxVersion()
        {
            var rbxverurl = "http://setup.roblox.com/version";

            using (var client = new HttpClient())
            {
                try
                {
                    var content = await client.GetStringAsync(rbxverurl);
                    CustomCw.Cw($"Saving Roblox Game Client (Hyperion Release) version: {content}", false, "debug");
                    Version = content;
                    TempLog.CreateVersionFile(content, "latestrbx");
                }
                catch (HttpRequestException ex)
                {
                    CustomCw.Cw($"Exception:\n{ex.Message}\nStack Trace:\n{ex.StackTrace}");
                }
            }
        }

        public static string Extract(this string input, int len)
        {
            if (string.IsNullOrEmpty(input) || input.Length < len)
            {
                return input;
            };

            return input.Substring(0, len);
        }

        public static void ExecutePowerShellScript(string script)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "powershell.exe";
                process.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"{script}\"";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;

                process.Start();
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
            }
        }

        public static async Task CheckVersionUWP()
        {
            var rbxverurl = "https://lexploits.netlify.app/version";
            var client = new HttpClient();
            var asyncedstring = await client.GetStringAsync(rbxverurl);
            string content = asyncedstring.ToString().Extract(5);

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            ExecutePowerShellScript(script);

            if (File.Exists(versionFilePath))
            {
                Version = File.ReadAllText(versionFilePath).Extract(5);
            }

            if (Directory.Exists(outputDirectory))
            {
                if (!Version.Contains(content))
                {
                    ThreadBox.MsgThread($"Your Roblox UWP version mismatched. LInjector is only working for version {asyncedstring}, you have {Version}. update or downgrade Roblox. Previous version may be operational.", "LInjector | Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CreateFiles.RedownloadModules();
                }
            }
        }
    }

    public class CheckLatest
    {
        private const string owner = "ItzzExcel";
        private const string repo = "LInjector";

        public static bool IsOutdatedVersion(string currentVersion)
        {
            var client = new GitHubClient(new ProductHeaderValue("CheckGitHubRelease"));

            var releases = client.Repository.Release.GetAll(owner, repo).Result;

            var latestRelease = releases
                .Where(r => r.TagName.StartsWith("v"))
                .OrderByDescending(r => r.PublishedAt)
                .FirstOrDefault();

            if (latestRelease != null)
            {
                var latestVersion = latestRelease.TagName.TrimStart('v');

                Version current = null;
                if (Version.TryParse(currentVersion.TrimStart('v'), out current))
                {
                    Version latest;
                    if (Version.TryParse(latestVersion, out latest))
                    {
                        return current < latest;
                    }
                }
            }

            return false;
        }
    }
}