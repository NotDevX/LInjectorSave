using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public static class TypeWriteManager
    {
        private static bool isBusy;

        public static async Task DoTypeWrite<T>(string message, T targetControl) where T : Control
        {
            if (isBusy)
            {
                while (isBusy)
                {
                    await Task.Delay(100);
                }
            }

            isBusy = true;

            string originalText = targetControl.Text;

            targetControl.Invoke((MethodInvoker)(() =>
            {
                targetControl.Text = "";

                foreach (char character in message)
                {
                    targetControl.Text += character;
                    targetControl.Refresh();
                    Task.Delay(30).Wait();
                }
            }));

            isBusy = false;
        }
    }
}