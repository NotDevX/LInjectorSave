using System;
using System.Net.Http;

namespace LInjector.Classes
{
    public static class rbxversion
    {
        public static string Version { get; set; }

        public static async void dlRbxVersion()
        {
            var rbxverurl = "http://setup.roblox.com/version";

            using (var client = new HttpClient())
            {
                try
                {
                    var content = await client.GetStringAsync(rbxverurl);
                    cwDt.CwDt("Saving Roblox Game Client (Hyperion Release) version: " + content);
                    Version = content;
                    tempLog.CreateVersionFile(content, "latestrbx");
                }
                catch (HttpRequestException ex)
                {
                    cwDt.CwDt("Exception:\n" + ex.Message
                                             + "Stack Trace:\n" + ex.StackTrace);
                }
            }
        }

        public static void checkVersions()
        {
            var getLatestRbx = Version;
            var localRbxVersion = Classes.localRbxVersion.Version;

            try
            {
                if (getLatestRbx != localRbxVersion)
                    cwDt.CwDt("Roblox Versions Mismatched.\n\n"
                              + "Your Version     :" + localRbxVersion + '\n'
                              + "Latest Version   :" + getLatestRbx);
                else if (getLatestRbx == localRbxVersion)
                    cwDt.CwDt("Your local Roblox Game Client Version is up-to-date. They doesn't mismatch.");
            }
            catch (Exception ex)
            {
                createThreadMsgBox.createMsgThread("Couldn't check if versions mismatched"
                                                   + "Exception   : \n" + ex.Message
                                                   + "Stack Trace : \n" + ex.StackTrace);
            }
        }
    }
}