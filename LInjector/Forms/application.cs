using LInjector.Classes;
using LInjector.Forms.Menus;
using LInjector.WPF;
using LInjector.WPF.Classes;
using MaterialSkin;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Vip.Notification;
namespace LInjector
{
    public partial class application : Form
    {
        TabSystem tabSystem = new TabSystem();
        monaco_api monaco_api = null;
        public static bool SettingsShown = false;
        settings GetSettings = new settings();

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private const int cGrip = 16;
        private const int cCaption = 32;

        public application()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);

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

        public void application_Load(object sender, EventArgs e)
        {
            _ = NotificationManager.FireNotification("Welcome to LInjector " + Program.currentVersion, infSettings);

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

            if (ConfigHandler.topmost)
            { TopMost = true; }

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
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

        private async void CloseButton_Click(object sender, EventArgs e)
        {
            settings GetSettings = new settings();
            GetSettings.Hide();

            var startFadeOutTime = DateTime.Now;
            double fadeOutDuration = 150;

            while (DateTime.Now - startFadeOutTime < TimeSpan.FromMilliseconds(fadeOutDuration))
            {
                var elapsedMilliseconds = (DateTime.Now - startFadeOutTime).TotalMilliseconds;
                var opacity = 1 - elapsedMilliseconds / fadeOutDuration;
                if (opacity < 0)
                    opacity = 0;

                Opacity = opacity;
                await Task.Delay(10);
            }

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
                CwDt.Cw("Cleared current TextBox");
                _ = FileManager.DoTypeWrite("", fileNameString);
                tabSystem.ChangeCurrentTabTitle($"Script {tabSystem.maintabs.Items.Count.ToString()}");
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
            FileStrip.Show(Cursor.Position);
        }

        private void EditButton_Click(object sender, MouseEventArgs e)
        {
            EditStrip.Show(Cursor.Position);
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
                        CwDt.Cw($"Added Script {openFileDialog.SafeFileName}");
                    }
                    else
                    {
                        tabSystem.current_monaco().SetText(fileContent);
                        tabSystem.ChangeCurrentTabTitle(openFileDialog.SafeFileName);
                        CwDt.Cw($"Opened Script {openFileDialog.SafeFileName}");
                    }

                    fileNameString.Refresh();
                    fileNameString.Size = new Size(150, 28);
                    fileNameString.Visible = true;
                    // _ = FileManager.DoTypeWrite(tabSystem.GetCurrentTabTitle(), fileNameString);
                }

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
                    string savedFileName = Path.GetFileName(saveFileDialog.FileName);
                    _ = NotificationManager.FireNotification(savedFileName + " saved", infSettings);
                    CwDt.Cw($"Saved file {savedFileName} to {saveFileDialog.FileName}");
                }
                catch (Exception)
                {
                    _ = NotificationManager.FireNotification("Error saving the file", infSettings);
                }
            }

            previousFocus.Focus();
        }

        private async void copyTextbox_Click(object sender, EventArgs e)
        {
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

        private void ToggleMinimap_Click(object sender, EventArgs e)
        {
            if (!tabSystem.current_monaco().isMinimapEnabled == true) 
            {
                tabSystem.current_monaco().enable_minimap();
            }
            else
            {
                tabSystem.current_monaco().disable_minimap();
            }
        }

        private void infSettings_Click(object sender, EventArgs e)
        {
            if (SettingsShown == false)
            {
                this.AddOwnedForm(GetSettings);
                GetSettings.Show();
                GetSettings.BringToFront();
            } else
            {
                GetSettings.Hide();
            }
        }

        private void SettingsButton_MouseEnter(object sender, EventArgs e)
        {
            SettingsPanel.BackColor = ColorTranslator.FromHtml("#2e2e2e");
        }

        private void SettingsButton_MouseLeave(object sender, EventArgs e)
        {
            SettingsPanel.BackColor = ColorTranslator.FromHtml("#191919");
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            infSettings_Click(sender, e);
        }
    }
}