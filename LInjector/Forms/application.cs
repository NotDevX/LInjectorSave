using LInjector.Classes;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LInjector
{
    public partial class application : Form
    {

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
            { this.FormBorderStyle = FormBorderStyle.Sizable; Text = "LInjector"; }
        }

        public async System.Threading.Tasks.Task<string> GetMonacoContent()
        {
            string script = "monaco.editor.getModels()[0].getValue()";
            var result = await webView2.CoreWebView2.ExecuteScriptAsync(script);
            string text = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(result);
            return text;
        }


        private void webView2_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                _ = NotificationManager.FireNotification("Failed to load WebView2", infSettings);

                DialogResult result = MessageBox.Show("CoreWebView2 Failed to load, try relaunching LInjector?",
                    "[ERROR] LInjector",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.OK)
                {
                    Application.Restart();
                }
            } else
            {
                webView2.CoreWebView2.Settings.AreDevToolsEnabled = false;
                webView2.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
                webView2.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
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
                FluxusAPI.create_files(Path.GetFullPath("Resources\\Module.dll"));
            }
            catch (Exception ex)
            {
                createThreadMsgBox.createMsgThread("Couldn't initialize Fluxus API\nException:\n"
                    + ex.Message.ToString()
                    + "\nPlease, share it on Discord.",
                    "[ERROR] LInjector", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _ = NotificationManager.FireNotification("Couldn't initialize Fluxus API.", infSettings);
            }

            rbxversion.checkVersions();
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
            FluxusAPI.create_files(Path.GetFullPath("Resources\\Module.dll"));
            bool flag = !FluxusAPI.is_injected(FluxusAPI.pid);
            if (flag)
            {
                try
                {
                    try
                    {
                        FluxusAPI.inject();
                    }
                    catch (Exception ex)
                    {
                        _ = NotificationManager.FireNotification("Fluxus API failed to inject", infSettings);
                        createThreadMsgBox.createMsgThread("LInjector encountered a unrecoverable error\nException:\n"
                                                           + ex.Message
                                                           + "\nStack Trace:\n"
                                                           + ex.StackTrace,
                                                           "LInjector | Exception",
                                                           MessageBoxButtons.OK,
                                                           MessageBoxIcon.Error);
                        Console.Beep();
                    }
                    _ = NotificationManager.FireNotification("Called Injection API (Powered by Fluxteam)", infSettings);
                    SendToast.send("Powered by Fluxus! (https://fluxteam.net)", 3, Vip.Notification.AlertType.Custom);
                }
                catch (Exception ex)
                {
                    createThreadMsgBox.createMsgThread("Error on inject:\n" + ex.Message
                        + "\nStack Trace:\n" + ex.StackTrace,
                        "LInjector | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                createThreadMsgBox.createMsgThread("Already injected", "LInjector | Fluxus API",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private async void ClearTB_Click(object sender, EventArgs e)
        {
            try
            {
                await webView2.ExecuteScriptAsync("editor.setValue('');");
                _ = TypeWriteManager.DoTypeWrite("", fileNameString);
                fileNameString.Refresh();
                fileNameString.Size = new Size(150, 28);
            }
            catch (Exception)
            {
                _ = NotificationManager.FireNotification("Error", infSettings);
            }
            DiscordRPCManager.SetBaseRichPresence();
        }

        private async void Execute_Click(object sender, EventArgs e)
        {
            string script = "monaco.editor.getModels()[0].getValue()";
            var result = await webView2.CoreWebView2.ExecuteScriptAsync(script);
            string scriptString = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(result);
            Execute.Focus();

            try
            {
                bool flag = FluxusAPI.is_injected(FluxusAPI.pid);
                if (flag)
                {
                    FluxusAPI.run_script(FluxusAPI.pid, scriptString);
                    cwDt.CwDt("Script executed");
                }
                else
                {
                    _ = NotificationManager.FireNotification("Inject before running script", infSettings);
                }
                Execute.Focus();
            }
            catch (Exception ex)
            {
                createThreadMsgBox.createMsgThread("Fluxus couldn't run the script.", "LInjector | Fluxus API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cwDt.CwDt("Exception from Fluxus:\n"
                    + ex.Message
                    + "\nStack Trace:\n"
                    + ex.StackTrace);
            }
            Execute.Focus();
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

            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.FileName = fileNameString.Text;
            saveFileDialog.Title = "Save to File | LInjector";
            saveFileDialog.Filter = "Script Files (*.txt;*.lua;*.luau)|*.txt;*.lua;*.luau|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    string script = "monaco.editor.getModels()[0].getValue()";
                    var result = await webView2.CoreWebView2.ExecuteScriptAsync(script);
                    string scriptString = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(result);

                    if (string.IsNullOrEmpty(scriptString))
                    {
                        _ = NotificationManager.FireNotification("No content detected", infSettings);
                    }

                    File.WriteAllText(filePath, scriptString);
                    filesub.Visible = false;
                    string savedFileName = System.IO.Path.GetFileName(saveFileDialog.FileName);
                    _ = NotificationManager.FireNotification(savedFileName + " saved", infSettings);
                    _ = TypeWriteManager.DoTypeWrite(savedFileName, fileNameString);
                }
                catch (Exception)
                {
                    filesub.Visible = false;
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
                string script = "monaco.editor.getModels()[0].getValue()";
                var result = await webView2.CoreWebView2.ExecuteScriptAsync(script);
                string text = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(result);
                Clipboard.SetText(text);
                _ = NotificationManager.FireNotification("Content copied to clipboard", infSettings);
            }
            catch (Exception)
            {
                _ = NotificationManager.FireNotification("Error on copy to clipboard", infSettings);
            }
        }

        private void reloadApp_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("This will clear the TextBox Content, are you sure to restart?",
                "[WARNING] LInjector",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

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

        private void webView2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            if (e.ToString() != "https://itzzexcel.github.io/luau-monaco" || e.ToString() != "https://lexploits.netlify.app/extra/monaco")
            {
                webView2.Source = new Uri("https://itzzexcel.github.io/luau-monaco");
            }
        }
    }
}