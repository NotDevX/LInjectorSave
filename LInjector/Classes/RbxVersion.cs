using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public static class RbxVersion
    {
        public static string Version { get; set; }
        static string appName = "ROBLOXCORPORATION.ROBLOX";
        static string outputDirectory = Path.Combine(Path.GetTempPath(), "LInjector");
        static string versionFilePath = Path.Combine(outputDirectory, "uwpversion");

        public static string script = @"
            $appxPackage = Get-AppxPackage | Where-Object { $_.Name -eq '" + appName + @"' }
            if ($appxPackage) {
                $appVersion = $appxPackage.Version
            } else {
                $appVersion = 'The application " + appName + @" it''s not installed.'
            }
            $appVersion | Out-File -FilePath '" + versionFilePath + @"'
        ";


        public static async Task DlRbxVersion()
        {
            var rbxverurl = "http://setup.roblox.com/version";

            using (var client = new HttpClient())
            {
                try
                {
                    var content = await client.GetStringAsync(rbxverurl);
                    CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, "Saving Roblox Game Client (Hyperion Release) version: " + content, "DEBUG");
                    Version = content;
                    TempLog.CreateVersionFile(content, "latestrbx");
                }
                catch (HttpRequestException ex)
                {
                    CustomCw.Cw(ConsoleColor.DarkRed, ConsoleColor.Red, "Exception:\n" + ex.Message
                                             + "Stack Trace:\n" + ex.StackTrace, "ERROR");
                }
            }
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
                CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, output, "DEBUG");
            }
        }

        public static void checkVersions()
        {
            var getLatestRbx = Version;
            var localRbxVersion = Classes.LocalRbx.Version;

            try
            {
                if (getLatestRbx != localRbxVersion)
                    CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, "Roblox Versions Mismatched.\n\n"
                              + "Your Version     :" + localRbxVersion + '\n'
                              + "Latest Version   :" + getLatestRbx, "DEBUG");
                else if (getLatestRbx == localRbxVersion)
                    CustomCw.Cw(ConsoleColor.DarkGray, ConsoleColor.DarkGray, "Your local Roblox Game Client Version is up-to-date. They doesn't mismatch.", "DEBUG");
            }
            catch (Exception ex)
            {
                ThreadBox.MsgThread("Couldn't check if versions mismatched"
                                                   + "Exception   : \n" + ex.Message
                                                   + "Stack Trace : \n" + ex.StackTrace);
            }
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async Task GetRobloxVersionUWP()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            ExecutePowerShellScript(script);

            if (File.Exists(versionFilePath))
            {
                Version = File.ReadAllText(versionFilePath);
            }

            if (Directory.Exists(outputDirectory))
            {
                if (!Version.Contains("2.586.0.0"))
                {
                    ThreadBox.MsgThread("Your Roblox UWP version mismatched. LInjector is only working for version 2.586.0.0, update or downgrade Roblox.", "LInjector | Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
