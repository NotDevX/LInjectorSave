using System;
using System.Net.Http;

namespace LInjector.Classes
{
    public static class RbxVersion
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
                    CwDt.Cw("Saving Roblox Game Client (Hyperion Release) version: " + content);
                    Version = content;
                    TempLog.CreateVersionFile(content, "latestrbx");
                }
                catch (HttpRequestException ex)
                {
                    CwDt.Cw("Exception:\n" + ex.Message
                                             + "Stack Trace:\n" + ex.StackTrace);
                }
            }
        }

        public static void checkVersions()
        {
            var getLatestRbx = Version;
            var localRbxVersion = Classes.LocalRbx.Version;

            try
            {
                if (getLatestRbx != localRbxVersion)
                    CwDt.Cw("Roblox Versions Mismatched.\n\n"
                              + "Your Version     :" + localRbxVersion + '\n'
                              + "Latest Version   :" + getLatestRbx);
                else if (getLatestRbx == localRbxVersion)
                    CwDt.Cw("Your local Roblox Game Client Version is up-to-date. They doesn't mismatch.");
            }
            catch (Exception ex)
            {
                ThreadBox.MsgThread("Couldn't check if versions mismatched"
                                                   + "Exception   : \n" + ex.Message
                                                   + "Stack Trace : \n" + ex.StackTrace);
            }
        }
    }
}
