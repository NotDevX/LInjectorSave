using KrnlAPI;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LInjector;

namespace LInjector
{
    public partial class application : Form {

        KrnlApi krnlApi = new KrnlApi();
        NotificationManager notificationManager = new NotificationManager();

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        public application()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private const int cGrip = 16;
        private const int cCaption = 32;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }

                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private async void application_Load(object sender, EventArgs e)
        {
            await notificationManager.FireNotification("LInjector Developing System Loaded", infSettings);
        }

        private bool isMaximized = false;

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            if (isMaximized)
            {
                WindowState = FormWindowState.Normal;
                isMaximized = false;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                isMaximized = true;
            }
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void titleDialog_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LInjectorIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void menuSettings_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void infSettings_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private async void Attach_Click(object sender, EventArgs e)
        {
            krnlApi.Inject();
            await notificationManager.FireNotification("Injected Krnl API", infSettings);
        }

        private async void ClearTB_Click(object sender, EventArgs e)
        {
            try {
                await webView2.ExecuteScriptAsync("editor.setValue('');");
                await notificationManager.FireNotification("TextBox Cleared", infSettings);
            } catch (Exception) {
                await notificationManager.FireNotification("Error", infSettings);
            }
        }

        private async void Execute_Click(object sender, EventArgs e)
        {
            dynamic editor = webView2.CoreWebView2.ExecuteScriptAsync("monaco.editor.getModels()[0].editor").GetAwaiter().GetResult();
            string scriptString = editor.getValue();
            krnlApi.Execute(scriptString);
            await notificationManager.FireNotification("Executed Script", infSettings);

        }

        private void FileButton_MouseClick(object sender, MouseEventArgs e)
        {
            filesub.Visible = !filesub.Visible;
            editSubmenu.Visible = false;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            editSubmenu.Visible = !editSubmenu.Visible;
            filesub.Visible = false;
        }

        private async void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Script Files | LInjector";
            openFileDialog.Filter = "Script Files (*.txt;*.lua;*.luau)|*.txt;*.lua;*.luau|All files (*.*)|*.*";
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileContent = File.ReadAllText(openFileDialog.FileName);
                await webView2.ExecuteScriptAsync("editor.setValue('');");
                await webView2.ExecuteScriptAsync($"editor.setValue(`{fileContent.Replace("`", "\\`")}`)");
            }
            filesub.Visible =! filesub.Visible;
            await notificationManager.FireNotification("Content Loaded", infSettings);
        }

        private async void saveFile_Click(object sender, EventArgs e)
        {
            Control previousFocus = ActiveForm.ActiveControl;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save to File | LInjector";
            saveFileDialog.Filter = "Script Files (*.txt;*.lua;*.luau)|*.txt;*.lua;*.luau|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    dynamic editor = await webView2.CoreWebView2.ExecuteScriptAsync("monaco.editor.getModels()[0].getValue()");
                    string scriptString = editor.ToString().Trim('"');

                    if (string.IsNullOrEmpty(scriptString))
                    {
                        await notificationManager.FireNotification("No Content Detected", infSettings);
                        return;
                    }

                    File.WriteAllText(filePath, scriptString);
                    await notificationManager.FireNotification("File Saved", infSettings);
                }
                catch (Exception)
                {
                    await notificationManager.FireNotification("Error Saving the File", infSettings);
                }
            }
            previousFocus.Focus();
            filesub.Visible = !filesub.Visible;
        }

        private async void copyTextbox_Click(object sender, EventArgs e)
        {
            editSubmenu.Visible = false;
            filesub.Visible = false;
            try
            {
                dynamic editor = await webView2.CoreWebView2.ExecuteScriptAsync("monaco.editor.getModels()[0].getValue()");
                string scriptString = editor.ToString().Trim('"');


                Clipboard.SetText(scriptString);
                await notificationManager.FireNotification("Content Copied to Clipboard", infSettings);
            }
            catch (Exception)
            {
                await notificationManager.FireNotification("Error Copying to Clipboard", infSettings);
            }
        }
    }
}
