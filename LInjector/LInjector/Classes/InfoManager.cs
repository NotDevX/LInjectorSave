using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public static class NotificationManager
    {
        private static bool isBusy;

        public static async Task FireNotification<T>(string message, T targetControl) where T : Control
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

            foreach (var character in message)
            {
                targetControl.Text += character;
                await Task.Delay(10);
            }

            await Task.Delay(3000);

            targetControl.Text = "";
            foreach (var character in ". . .")
            {
                targetControl.Text += character;
                await Task.Delay(10);
            }

            isBusy = false;
        }
    }
}
