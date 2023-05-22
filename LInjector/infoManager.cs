using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector
{
    public class NotificationManager
    {
        private bool isBusy;

        public async Task FireNotification(string message, Button targetLabel)
        {
            if (isBusy)
            {
                while (isBusy)
                {
                    await Task.Delay(100);
                }
            }

            isBusy = true;

            targetLabel.Text = "";

            foreach (char character in message)
            {
                targetLabel.Text += character;
                await Task.Delay(30);
            }

            await Task.Delay(2500);

            targetLabel.Text = "";
            foreach (char character in ". . .")
            {
                targetLabel.Text += character;
                await Task.Delay(30);
            }

            isBusy = false;
        }
    }
}