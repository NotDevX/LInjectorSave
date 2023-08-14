using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public static class FileManager
    {
        public static readonly string localAppDataFolder =
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public static readonly string RobloxACFolder = Path.Combine(localAppDataFolder, "Packages",
            "ROBLOXCORPORATION.ROBLOX_55nm5eh3cm0pr", "AC");

        public static readonly string workspaceFolder = Path.Combine(RobloxACFolder, "workspace");
        public static readonly string autoexecFolder = Path.Combine(RobloxACFolder, "autoexec");

        private static bool isBusy;

        public static async Task DoTypeWrite<T>(string message, T targetControl) where T : Control
        {
            if (isBusy)
                while (isBusy)
                    await Task.Delay(100);

            isBusy = true;

            var originalText = targetControl.Text;

            targetControl.Invoke((MethodInvoker)(async () =>
            {
                targetControl.Text = "";

                if (message.Length < 50)
                {
                    foreach (var character in message)
                    {
                        targetControl.Text += character;
                        targetControl.Refresh();
                        await Task.Delay(30);
                        RPCManager.SetRpcFile(message);
                    }
                }
                else
                {
                    var cutMessage = message.Substring(0, Math.Min(50, message.Length));
                    foreach (var character in cutMessage)
                    {
                        targetControl.Text += character;
                        targetControl.Refresh();
                        await Task.Delay(30);
                        RPCManager.SetRpcFile(message);
                    }
                }
            }));

            isBusy = false;
        }
    }
}
