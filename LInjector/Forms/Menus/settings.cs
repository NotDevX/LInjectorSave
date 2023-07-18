using LInjector.Classes;
using MaterialSkin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector.Forms.Menus
{
    public partial class settings : Form
    {
        public settings()
        {
            InitializeComponent();
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void settings_Load(object sender, EventArgs e)
        {
            MaterialSkinManager SkinManager = MaterialSkinManager.Instance;
            SkinManager.Theme = MaterialSkinManager.Themes.DARK;
            SkinManager.ColorScheme = new ColorScheme(Primary.Indigo800, Primary.Indigo900, Primary.Indigo500, Accent.Indigo700, TextShade.WHITE);
        }

        private void AttachHandler_CheckedChanged(object sender, EventArgs e)
        {
            if (AttachHandler.Checked)
            {
                ConfigHandler.StartListening();
                ConfigHandler.SetConfigValue("autoattach", true);
                ConfigHandler.autoattach = true;
            } else {
                ConfigHandler.StopListening();
                ConfigHandler.SetConfigValue("autoattach", false);
                ConfigHandler.autoattach = false;
            }
        }

        private void SplashHandler_CheckedChanged(object sender, EventArgs e)
        {
            if (SplashHandler.Checked)
            {
                ConfigHandler.SetConfigValue("nosplash", false);
                ConfigHandler.nosplash = false;
            }
            else
            {
                ConfigHandler.SetConfigValue("nosplash", true);
                ConfigHandler.nosplash = true;
            }
        }

        private void SizableHandler_CheckedChanged(object sender, EventArgs e)
        {
            if (SizableHandler.Checked)
            {
                ConfigHandler.SetConfigValue("sizable", true);
                ConfigHandler.sizable = true;
            }
            else
            {
                ConfigHandler.SetConfigValue("sizable", false);
                ConfigHandler.sizable = false;
            }
        }

        private void ConsoleHandler_CheckedChanged(object sender, EventArgs e)
        {
            if (ConsoleHandler.Checked)
            {
                ConfigHandler.SetConfigValue("debug", true);
                ConfigHandler.debug = true;
            } else
            {
                ConfigHandler.SetConfigValue("debug", false);
                ConfigHandler.debug = false;
            }
        }

        private void RPCHandler_CheckedChanged(object sender, EventArgs e)
        {
            if (RPCHandler.Checked)
            {
                ConfigHandler.SetConfigValue("discord_rpc", true);
                ConfigHandler.discord_rpc = true;
                RPCManager.isEnabled = true;

                if (!RPCManager.client.IsInitialized)
                    RPCManager.InitRPC();

            } else
            {
                ConfigHandler.SetConfigValue("discord_rpc", false);
                ConfigHandler.discord_rpc = false;
                RPCManager.isEnabled = false;

                if (RPCManager.client.IsInitialized)
                    RPCManager.client.Dispose();
            }
        }

        private void TopMostHandler_CheckedChanged(object sender, EventArgs e)
        {
            ThreadBox.MsgThread("This may need resart application to take effect.",
                                "LInjector | Settings",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);

            if (TopMostHandler.Checked)
            {
                ConfigHandler.SetConfigValue("topmost", true);
                this.TopMost = true;
                ConfigHandler.topmost = true;
            }
            else
            {
                ConfigHandler.SetConfigValue("topmost", false);
                this.TopMost = false;
                ConfigHandler.topmost = false;
            }
        }

        private void DragWindow (object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void settings_Shown(object sender, EventArgs e)
        {
            if (ConfigHandler.autoattach == true)
            { AttachHandler.Checked = true; } else { AttachHandler.Checked = false; }

            if (ConfigHandler.nosplash == true)
            { SplashHandler.Checked = false; } else { SplashHandler.Checked = true; }

            if (ConfigHandler.sizable == true)
            { SizableHandler.Checked = true;  } else { SizableHandler.Checked = false; }

            if (ConfigHandler.debug == true) 
            { ConsoleHandler.Checked = true; } else { ConsoleHandler.Checked = false; }

            if (ConfigHandler.discord_rpc == true)
            { RPCHandler.Checked = true; } else { RPCHandler.Checked = false; }

            if (ConfigHandler.topmost == true)
            { TopMostHandler.Checked = true; } else { TopMostHandler.Checked = false; }
        }
    }
}
