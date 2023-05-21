using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector
{
    public class NotificationManager
    {
        public async Task FireNotification(string message, Button targetButton)
        {
            targetButton.Text = "";

            foreach (char character in message)
            {
                targetButton.Text += character;
                await Task.Delay(30);
            }

            await Task.Delay(2500);

            targetButton.Text = "";
            foreach (char character in ". . .")
            {
                targetButton.Text += character;
                await Task.Delay(30);
            }
        }
    }
}
