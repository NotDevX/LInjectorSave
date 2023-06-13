using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Win32Interop.Enums;

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
                    DialogResult dialogResult = MessageBox.Show(msgBoxContent, msgBoxTitle, boxButtons, boxIcon, boxDefaultButton, boxOptions);
                }
            );
            msgBoxThread.Start();
        }
    }
}
