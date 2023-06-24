using System;
using System.Drawing;
using System.IO;
using LInjector.Classes;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KrnlAPI;
using Newtonsoft.Json;
using Microsoft.Web.WebView2.Core;
using System.Text.RegularExpressions;

namespace LInjector
{
    public partial class application : Form {

        KrnlApi krnlApi = new KrnlApi();

        private bool isDevelopment = false;

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

            #pragma warning disable CS0162 // Unreachable code detected
            if (Program.currentVersion == "f81fb0e34f313b6cf0d0fc345890a33f") { isDevelopment = true; }
            #pragma warning restore CS0162 // Unreachable code detected

            if (ArgumentHandler.SizableBool == true)
            { this.FormBorderStyle = FormBorderStyle.Sizable; this.Name = "LInjector"; }
        }


        private void webView2_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                _ = NotificationManager.FireNotification("Failed to load webView2", infSettings);

                DialogResult result = MessageBox.Show("CoreWebView2 Failed to load, try relaunching LInjector?", "[ERROR] LInjector", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (result == DialogResult.OK)
                {
                    Application.Restart();
                }
            }
        }

        private void application_Load(object sender, EventArgs e)
        {
            if (isDevelopment)
            { _ = NotificationManager.FireNotification("Welcome to LInjector Development Version", infSettings); }
            else
            { _ = NotificationManager.FireNotification("Welcome to LInjector " + Program.currentVersion, infSettings); }

            try
            {
                krnlApi.Initialize();
            }
            catch (Exception ex)
            {
                createThreadMsgBox.createMsgThread("Couldn't initialize Krnl API\nException:\n" + ex.Message.ToString() + "\nPlease, share it on Discord.", "[ERROR] LInjector", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _ = NotificationManager.FireNotification("Couldn't initialize Krnl API.", infSettings);
            }
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

        private void CloseButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Application.Exit();
        }

        private void Maximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            { WindowState = FormWindowState.Normal; }
            else { WindowState = FormWindowState.Maximized; }
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

        private void application_MouseDown(object sender, MouseEventArgs e)
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

        private void fileNameString_MouseDown(object sender, MouseEventArgs e)
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

        private void execinjPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LInjectorLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Attach_Click(object sender, EventArgs e)
        {
            if (!krnlApi.IsInjected())
            {
                try
                {
                    krnlApi.Inject();
                    _ = NotificationManager.FireNotification("Injected Krnl API", infSettings);
                }
                catch (Exception ex)
                {
                    createThreadMsgBox.createMsgThread("Couldn't inject.\nDue to Hyperion Byfron, Roblox Anticheat, Krnl is down, and maybe it will not came back with the API.\nIf you have your own injector, you can edit my UI and make it usable as an executor."
                              + "\n"
                              + "Exception:\n"
                              + ex.Message
                              + "\nPlease, don't share it on Discord.", "[ERROR] LInjector", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    _ =  NotificationManager.FireNotification("Couldn't inject Krnl API", infSettings);
                }
            } else {
                _ = NotificationManager.FireNotification("Krnl is already injected", infSettings);
            }    
        }

        private async void ClearTB_Click(object sender, EventArgs e)
        {
            try {
                await webView2.ExecuteScriptAsync("editor.setValue('');");
                _ = NotificationManager.FireNotification("TextBox cleared", infSettings);
                _ = TypeWriteManager.DoTypeWrite("", fileNameString);
                fileNameString.Refresh();
                fileNameString.Size = new Size(150, 28);
            } catch (Exception) {
                _ = NotificationManager.FireNotification("Error", infSettings);
            }
            DiscordRPCManager.SetBaseRichPresence();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            dynamic editor = webView2.CoreWebView2.ExecuteScriptAsync("monaco.editor.getModels()[0].editor").GetAwaiter().GetResult();
            string scriptString = editor.getValue();
            scriptString = scriptString.Replace("\\n", ";");

            try
            {
                krnlApi.Execute(scriptString);
                _ = NotificationManager.FireNotification("Script executed", infSettings);

            }
            catch (Exception ex)
            {
                createThreadMsgBox.createMsgThread("Couldn't execute with Krnl API\nException:\n" + ex.Message.ToString() + "\nPlease, share it on Discord.", "[ERROR] LInjector", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            try
            {
                fileNameString.Refresh();
                fileNameString.ResetText();
                fileNameString.Size = new Size(150, 28);
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Open Script Files | LInjector";
                openFileDialog.Filter = "Script Files (*.txt;*.lua;*.luau)|*.txt;*.lua;*.luau|All files (*.*)|*.*";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);
                    fileContent = fileContent.Replace("\\", "\\\\");
                    await webView2.ExecuteScriptAsync("editor.setValue('');");
                    await webView2.ExecuteScriptAsync($"editor.setValue(`{fileContent.Replace("`", "\\`")}`)");
                    filesub.Visible = false;
                    fileNameString.Refresh();
                    fileNameString.Size = new Size(150, 28);
                    fileNameString.Visible = true;
                    _ = TypeWriteManager.DoTypeWrite(openFileDialog.SafeFileName, fileNameString);
                }
                filesub.Visible = false;
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Exception while opening file." + "\nException:\n" + ex.Message.ToString() + "\nTry restarting?",
                    "[WARNING] LInjector", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    cwDt.CwDt("Resarting LInjector");
                    Application.Restart();
                }
            }
        }

        private async void saveFile_Click(object sender, EventArgs e)
        {
            Control previousFocus = ActiveForm.ActiveControl;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileNameString.Text;
            saveFileDialog.Title = "Save to File | LInjector";
            saveFileDialog.Filter = "Script Files (*.txt;*.lua;*.luau)|*.txt;*.lua;*.luau|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    dynamic editor = await webView2.CoreWebView2.ExecuteScriptAsync("monaco.editor.getModels()[0].getValue()");
                    string scriptString = editor.ToString();

                    scriptString = scriptString.Replace("\\n", "\n");
                    scriptString = scriptString.Replace("\\t", "\t");

                    if (string.IsNullOrEmpty(scriptString))
                    {
                        _ = NotificationManager.FireNotification("No content detected", infSettings);
                    }

                    File.WriteAllText(filePath, scriptString);
                    filesub.Visible = false;
                    string savedFileName = System.IO.Path.GetFileName(saveFileDialog.FileName);
                    _ = NotificationManager.FireNotification(savedFileName + " saved", infSettings);
                    _ = TypeWriteManager.DoTypeWrite(savedFileName, fileNameString);
                    createThreadMsgBox.createMsgThread("This feature might be not fully developed."
                        + "\nTo prevent errors on saving, please copy the content inside Monaco (CTRL + A) + (CTRL + C)."
                        + "\nI know this is annoying but I don't know how to fix this string issue.", 
                        "LInjector | Monaco Text Editor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    filesub.Visible = filesub.Visible;
                    _ = NotificationManager.FireNotification("Error saving the file", infSettings);
                }
            }

            previousFocus.Focus();
            filesub.Visible = false;
        }

        private async void copyTextbox_Click(object sender, EventArgs e)
        {
            editSubmenu.Visible = false;
            filesub.Visible = false;
            try
            {
                dynamic editor = await webView2.CoreWebView2.ExecuteScriptAsync("monaco.editor.getModels()[0].getValue()");
                string scriptString = editor.ToString();

                scriptString = scriptString.Replace("\\n", "\n");
                scriptString = scriptString.Replace("\\t", "\t");

                Clipboard.SetText(scriptString);
                _ = NotificationManager.FireNotification("Content copied to clipboard", infSettings);
                createThreadMsgBox.createMsgThread("This feature might be not fully developed."
                        + "\nTo prevent errors on copying, please copy the content inside Monaco (CTRL + A) + (CTRL + C)."
                        + "\nI know this is annoying but I don't know how to fix this string issue.",
                        "LInjector | Monaco Text Editor",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                _ = NotificationManager.FireNotification("Error on copy to clipboard", infSettings);
            }
        }

        private void reloadApp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will clear the TextBox Content, are you sure to restart?", "[WARNING] LInjector", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                Application.Restart();
            }

            editSubmenu.Visible = false;
        }

        private void dscButton_MouseEnter(object sender, EventArgs e)
        {
            dscPanel.BackColor = ColorTranslator.FromHtml("#2e2e2e");
        }

        private void dscButton_MouseLeave(object sender, EventArgs e)
        {
            dscPanel.BackColor = ColorTranslator.FromHtml("#191919");
        }

        private void dscButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/NQY28YSVAb");
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ItzzExcel/LInjector");
        }

        private void githubButton_MouseEnter(object sender, EventArgs e)
        {
            githubPanel.BackColor = ColorTranslator.FromHtml("#2e2e2e");
        }

        private void githubButton_MouseLeave(object sender, EventArgs e)
        {
            githubPanel.BackColor = ColorTranslator.FromHtml("#191919");
        }

        private void terminalButton_MouseEnter(object sender, EventArgs e)
        {
            terminalPanel.BackColor = ColorTranslator.FromHtml("#2e2e2e");
        }

        private void terminalButton_MouseLeave(object sender, EventArgs e)
        {
            terminalPanel.BackColor = ColorTranslator.FromHtml("#191919");
        }

        private void terminalButton_Click(object sender, EventArgs e)
        {
            if (ConsoleManager.isConsoleVisible == true)
            { ConsoleManager.HideConsole(); } 
            else { ConsoleManager.ShowConsole(); }
        }
    }
}
