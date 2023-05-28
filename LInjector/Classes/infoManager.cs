using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector
{
    public class NotificationManager
    {
        private bool isBusy;

        public async Task FireNotification<T>(string message, T targetControl) where T : Control
        {
            if (isBusy)
            {
                while (isBusy)
                {
                    await Task.Delay(100);
                }
            }

            isBusy = true;

            targetControl.Text = "";

            foreach (char character in message)
            {
                targetControl.Text += character;
                await Task.Delay(30);
            }

            await Task.Delay(2500);

            targetControl.Text = "";
            foreach (char character in ". . .")
            {
                targetControl.Text += character;
                await Task.Delay(30);
            }

            isBusy = false;
        }
    }
}
