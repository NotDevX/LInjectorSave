using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using LInjector.Classes;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using Vip.Notification;
using LInjector.WPF;
using System.Windows.Forms.Integration;
using LInjector.WPF.Classes;

namespace LInjector
{
    public partial class application : Form
    {
        TabSystem tabSystem = new TabSystem();
        monaco_api monaco_api = null;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private const int cGrip = 16;
        private const int cCaption = 32;

        private readonly bool isDevelopment;


        public application()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);

            #pragma warning disable CS0162 // Unreachable code detected
            if (Program.currentVersion == "f81fb0e34f313b6cf0d0fc345890a33f") { isDevelopment = true; }
            #pragma warning restore CS0162 // Unreachable code detected

            if (ArgumentHandler.SizableBool)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                Text = "LInjector";
            }
        }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public async Task<string> GetMonacoContent()
        {
            string result = await tabSystem.current_monaco().GetText();
            string text = JsonConvert.DeserializeObject<string>(result);
            return text;
        }


        private void webView2_CoreWebView2InitializationCompleted(object sender,
            CoreWebView2InitializationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                _ = NotificationManager.FireNotification("Failed to load WebView2", infSettings);

                var result = MessageBox.Show("CoreWebView2 Failed to load, try relaunching LInjector?",
                    "[ERROR] LInjector",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Error);

                if (result == DialogResult.OK) Application.Restart();
            }
            else
            {
                monaco_api.CoreWebView2.Settings.AreDevToolsEnabled = false;
                monaco_api.CoreWebView2.Settings.AreBrowserAcceleratorKeysEnabled = false;
                monaco_api.CoreWebView2.Settings.IsPasswordAutosaveEnabled = false;
            }

            if (ConfigHandler.monaco_minimap)
            {
                monaco_api.enable_minimap();
            }
        }

        public void application_Load(object sender, EventArgs e)
        {
            if (isDevelopment)
            { _ = NotificationManager.FireNotification("Welcome to LInjector Development Version", infSettings); }
            else
            { _ = NotificationManager.FireNotification("Welcome to LInjector " + Program.currentVersion, infSettings); }

            try
            {
                FluxusAPI.create_files(Path.GetFullPath("Resources\\libs\\Module.dll"));
            }
            catch (Exception ex)
            {
                ThreadBox.MsgThread("Couldn't initialize Fluxus API\nException:\n"
                                                   + ex.Message
                                                   + "\nPlease, share it on Discord.",
                    "[ERROR] LInjector", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                _ = NotificationManager.FireNotification("Couldn't initialize Fluxus API.", infSettings);
            }

            ElementHost host = new ElementHost();
            host.Parent = TabsPanel;
            host.Dock = DockStyle.Fill;
            host.Child = tabSystem;


            // rbxversion.checkVersions();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                var pos = new Point(m.LParam.ToInt32());
                pos = PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }

                if (pos.X >= ClientSize.Width - cGrip && pos.Y >= ClientSize.Height - cGrip)
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
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
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
            Inject();
        }

        private void ClearTB_Click(object sender, EventArgs e)
        {
            try
            {
                var cm = tabSystem.current_monaco();
                cm.SetText("");
                _ = FileManager.DoTypeWrite("", fileNameString);
                fileNameString.Refresh();
                fileNameString.Size = new Size(150, 28);
            }
            catch (Exception)
            {
                _ = NotificationManager.FireNotification("Error", infSettings);
            }

            RPCManager.SetBaseRichPresence();
        }

        private async void Execute_Click(object sender, EventArgs e)
        {
            var cm = tabSystem.current_monaco();
            string scriptString = await cm.GetText();
            Execute.Focus();

            try
            {
                var flag = FluxusAPI.is_injected(FluxusAPI.pid);
                if (flag)
                {
                    FluxusAPI.run_script(FluxusAPI.pid, scriptString);
                    CwDt.Cw("Script executed");
                }
                else
                {
                    _ = NotificationManager.FireNotification("Inject before running script", infSettings);
                }

                Execute.Focus();
            }
            catch (Exception ex)
            {
                ThreadBox.MsgThread("Fluxus couldn't run the script.", "LInjector | Fluxus API",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                CwDt.Cw("Exception from Fluxus:\n"
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

        private void openFile_Click(object sender, EventArgs e)
        {
            try
            {
                fileNameString.Refresh();
                fileNameString.ResetText();
                fileNameString.Size = new Size(150, 28);
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Open Script Files | LInjector";
                openFileDialog.Filter = "Script Files (*.txt;*.lua;*.luau)|*.txt;*.lua;*.luau|All files (*.*)|*.*";
                openFileDialog.Multiselect = false;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileContent = File.ReadAllText(openFileDialog.FileName);

                    var dialogResult = MessageBox.Show(
                        "Open file in new tab?",
                        "LInjector",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (dialogResult == DialogResult.Yes)
                    {
                        tabSystem.add_tab_with_text(fileContent, openFileDialog.SafeFileName);
                    }
                    else
                    {
                        tabSystem.current_monaco().SetText(fileContent);
                        tabSystem.ChangeCurrentTabTitle(openFileDialog.SafeFileName);
                    }

                    filesub.Visible = false;
                    fileNameString.Refresh();
                    fileNameString.Size = new Size(150, 28);
                    fileNameString.Visible = true;
                    // _ = FileManager.DoTypeWrite(tabSystem.GetCurrentTabTitle(), fileNameString);
                }

                filesub.Visible = false;
            }
            catch (Exception ex)
            {
                var result = MessageBox.Show(
                    "Exception while opening file." + "\nException:\n" + ex.Message + "\nTry restarting?",
                    "[WARNING] LInjector", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    CwDt.Cw("Resarting LInjector");
                    Application.Restart();
                }
            }
        }

        private async void saveFile_Click(object sender, EventArgs e)
        {
            var previousFocus = ActiveForm.ActiveControl;

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = await tabSystem.GetCurrentTabTitle();
            saveFileDialog.Title = "Save to File | LInjector";
            saveFileDialog.Filter = "Script Files (*.txt;*.lua;*.luau)|*.txt;*.lua;*.luau|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    var cm = tabSystem.current_monaco();
                    string text = await cm.GetText();
                    string result = text;

                    if (string.IsNullOrEmpty(result))
                    {
                        _ = NotificationManager.FireNotification("No content detected", infSettings);
                    }

                    File.WriteAllText(filePath, result);
                    filesub.Visible = false;
                    string savedFileName = Path.GetFileName(saveFileDialog.FileName);
                    _ = NotificationManager.FireNotification(savedFileName + " saved", infSettings);
                    // _ = FileManager.DoTypeWrite(tabSystem.latestTabName, fileNameString);
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
                var cm = tabSystem.current_monaco();
                string text = await cm.GetText();
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
            var result = MessageBox.Show("This will clear the TextBox Content, are you sure to restart?",
                "[WARNING] LInjector",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (result == DialogResult.OK) { Application.Restart(); }

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
            Process.Start("https://discord.gg/NQY28YSVAb");
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ItzzExcel/LInjector");
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
            if (ConsoleManager.isConsoleVisible)
                ConsoleManager.HideConsole();
            else
                ConsoleManager.ShowConsole();
        }

        private void webView2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            if (e.ToString() != "https://itzzexcel.github.io/luau-monaco" ||
                e.ToString() != "https://lexploits.netlify.app/extra/monaco") 
            {
                monaco_api.Source = new Uri("https://itzzexcel.github.io/luau-monaco");
            }
        }

        public void Inject()
        {
            FluxusAPI.create_files(Path.GetFullPath("Resources\\libs\\Module.dll"));
            var flag = !FluxusAPI.is_injected(FluxusAPI.pid);
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
                        ThreadBox.MsgThread("LInjector encountered a unrecoverable error" +
                                                           "\nDue to Hyperion Byfron, LInjector only supports Roblox from Microsoft Store." +
                                                           "\nException:\n"
                                                           + ex.Message
                                                           + "\nStack Trace:\n"
                                                           + ex.StackTrace,
                            "LInjector | Exception",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                    _ = NotificationManager.FireNotification("Called Injection API (Powered by Fluxteam)", infSettings);
                    SendToast.send("Powered by Fluxus! (https://fluxteam.net)", 3, AlertType.Custom);
                }
                catch (Exception ex)
                {
                    ThreadBox.MsgThread("Error on inject:\n" + ex.Message
                                                                            + "\nStack Trace:\n" + ex.StackTrace,
                        "LInjector | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ThreadBox.MsgThread("Already injected", "LInjector | Fluxus API",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}