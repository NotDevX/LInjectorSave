using System.Threading;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public static class createThreadMsgBox
    {
        public static void createMsgThread(string msgBoxContent = "",
            string msgBoxTitle = "",
            MessageBoxButtons boxButtons = MessageBoxButtons.OK,
            MessageBoxIcon boxIcon = MessageBoxIcon.None,
            MessageBoxDefaultButton boxDefaultButton = MessageBoxDefaultButton.Button1,
            MessageBoxOptions boxOptions = MessageBoxOptions.DefaultDesktopOnly)
        {
            var msgBoxThread = new Thread(
                () =>
                {
                    var dialogResult = MessageBox.Show(msgBoxContent, msgBoxTitle, boxButtons, boxIcon,
                        boxDefaultButton, boxOptions);
                }
            );
            msgBoxThread.Start();
            cwDt.CwDt(msgBoxTitle + ", " + msgBoxContent);
        }
    }
}