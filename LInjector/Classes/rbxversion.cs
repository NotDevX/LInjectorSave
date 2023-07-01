using System;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;

namespace LInjector.Classes
{
    public static class rbxversion
    {
        public static string Version { get; set; }

        public static async Task dlRbxVersion ()
        {
            string rbxverurl = "http://setup.roblox.com/version";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string content = await client.GetStringAsync(rbxverurl);
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

        public static void checkVersions ()
        {
            string getLatestRbx = Version;
            string localRbxVersion = LInjector.Classes.localRbxVersion.Version;

            try
            {
                if (getLatestRbx != localRbxVersion)
                {
                    createThreadMsgBox.createMsgThread("Roblox Versions mismatched.\n\n"
                        + "Your Roblox Version       : " + localRbxVersion
                        + "\n"
                        + "Latest Roblox Version    : " + Version,
                        "LInjector | Roblox Version Checker",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                } else if (getLatestRbx == localRbxVersion)
                {
                    cwDt.CwDt("Your local Roblox Game Client Version is up-to-date. They doesn't mistmatch.");
                }
            }
            catch (Exception ex)
            {
                createThreadMsgBox.createMsgThread("Couldn't check if versions mistmatched"
                    + "Exception   : \n" + ex.Message 
                    + "Stack Trace : \n" + ex.StackTrace);
            }
        }
    }
}
