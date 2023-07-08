using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public static class FileManager
    {
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

                    CwDt.Cw(message);
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