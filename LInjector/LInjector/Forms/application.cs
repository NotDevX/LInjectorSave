using LInjector.Classes;
using LInjector.Forms.Menus;
using LInjector.WPF;
using LInjector.WPF.Classes;
using MaterialSkin;
using Microsoft.Web.WebView2.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace LInjector
{
    public partial class application : Form
    {
        readonly TabSystem tabSystem = new TabSystem();
        readonly settings GetSettings = new settings();
        readonly about GetAbout = new about();
        readonly List<ScriptItem> ScriptsCache = new List<ScriptItem>();
        private readonly HttpClient client = new HttpClient();
        private readonly WebClient webCl = new WebClient();

        readonly monaco_api monaco_api = null;

        public static bool AboutShown = false;
        public bool IsOptionsCollapsed = false;
        public static bool SettingsShown = false;

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private const int cGrip = 16;
        private const int cCaption = 32;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public application()
        {
            InitializeComponent();
            (new LInjector.Classes.DropShadow()).ApplyShadows(this);
            SetStyle(ControlStyles.ResizeRedraw, true);
            DownloadScripts();

            if (ArgumentHandler.SizableBool)
            {
                FormBorderStyle = FormBorderStyle.Sizable;
                Text = "LInjector";
            }
        }

        public void application_Load(object sender, EventArgs e)
        {
            runAutoAttachTimer();
            if (Program.currentVersion.Contains("f81fb0e34f313b6cf0d0fc345890a33f"))
            { _ = NotificationManager.FireNotification("Welcome to LInjector Development Version", infSettings); }
            else
            { _ = NotificationManager.FireNotification($"Welcome to LInjector {Program.currentVersion}", infSettings); }

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

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            _ = new ElementHost
            {
                Parent = TabsPanel,
                Dock = DockStyle.Fill,
                Child = tabSystem
            };

            if (ConfigHandler.topmost)
            { TopMost = true; }

            if (ConfigHandler.options_collapsed)
            {
                expandButton_Click(sender, e);
            }

            if (ConfigHandler.script_list)
            {
                SplitCont.Panel2Collapsed = true;
            }
        }

        public async Task<string> GetMonacoContent()
        {
            string result = await tabSystem.current_monaco().GetText();
            string text = JsonConvert.DeserializeObject<string>(result);
            return text;
        }

        public void runAutoAttachTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += AttachedDetectorTick;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Start();
        }

        private void AttachedDetectorTick(object sender, EventArgs e)
        {
            if (ConfigHandler.autoattach == false)
            {
                return;
            }

            var processesByName = Process.GetProcessesByName("Windows10Universal");
            foreach (var Process in processesByName)
            {
                var FilePath = Process.MainModule.FileName;

                if (FilePath.Contains("ROBLOX"))
                {
                    try
                    {
                        var flag = FluxusAPI.is_injected(FluxusAPI.pid);
                        if (flag)
                        {
                            return;
                        }

                        InjectNoNotification();
                    }
                    catch { }
                }
            }
        }

        public void AddScripts(dynamic ScriptsJson)
        {
            foreach (var item in ScriptsJson)
            {
                if (item.mastahubdata.link != null)
                {
                    ScriptItem scriptItem = new ScriptItem
                    {
                        title = item.title,
                        script = item.mastahubdata.link,
                    };

                    ScriptsCache.Add(scriptItem);
                    ScriptsList.Items.Add(item.title);
                }
            }
        }
        public async void DownloadScripts()
        {
            try
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");

                dynamic BuiltinScripts = await client.GetStringAsync("https://github.com/ItzzExcel/LInjectorRedistributables/raw/main/extra/LSciprts.json");
                BuiltinScripts = JsonConvert.DeserializeObject(BuiltinScripts);

                AddScripts(BuiltinScripts);

                dynamic ScriptsJson = await client.GetStringAsync("https://www.mastersmzscripts.com/_functions-dev/forumposts?key=67E65DB1CFE1481DC956EFABF1D56&skip=0&max=60");
                ScriptsJson = JsonConvert.DeserializeObject(ScriptsJson);

                AddScripts(ScriptsJson);
            }
            catch
            {
                _ = NotificationManager.FireNotification("Could not download scripts", infSettings);
            }
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
            GetSettings.Hide();
            GetAbout.Hide();

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
        public void DragWindow(object sender, MouseEventArgs e)
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
                CustomCw.Cw("TextBox Cleared.", false, "debug");
                tabSystem.ChangeCurrentTabTitle($"Script {tabSystem.maintabs.Items.Count}");
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
                    CustomCw.Cw("Script executed", false, "debug");
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
                CustomCw.Cw($"(Module) Exception thrown\n{ex.Message}\nStack Trace:\n{ex.StackTrace}", false, "error");
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
                var openFileDialog = new OpenFileDialog
                {
                    Title = "Open Script Files | LInjector",
                    Filter = "Script Files (*.txt;*.lua;*.luau)|*.txt;*.lua;*.luau|All files (*.*)|*.*",
                    Multiselect = false
                };
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
                        CustomCw.Cw($"Added Script {openFileDialog.SafeFileName}", false, "debug");
                    }
                    else
                    {
                        tabSystem.current_monaco().SetText(fileContent);
                        tabSystem.ChangeCurrentTabTitle(openFileDialog.SafeFileName);
                        CustomCw.Cw($"Opened Script {openFileDialog.SafeFileName}", false, "debug");
                    }
                }

            }
            catch (Exception ex)
            {
                var result = MessageBox.Show(
                    "Exception while opening file." + "\nException:\n" + ex.Message + "\nTry restarting?",
                    "[WARNING] LInjector", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    CustomCw.Cw("Restarting LInjector", false, "debug");
                    Application.Restart();
                }
            }
        }

        private async void saveFile_Click(object sender, EventArgs e)
        {
            var previousFocus = ActiveForm.ActiveControl;

            var saveFileDialog = new SaveFileDialog
            {
                FileName = await tabSystem.GetCurrentTabTitle(),
                Title = "Save to File | LInjector",
                Filter = "Script Files (*.txt;*.lua;*.luau)|*.txt;*.lua;*.luau|All files (*.*)|*.*"
            };

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
                    else
                    {
                        try
                        {
                            File.WriteAllText(filePath, result);
                            string savedFileName = Path.GetFileName(saveFileDialog.FileName);
                            _ = NotificationManager.FireNotification(savedFileName + " saved", infSettings);
                            CustomCw.Cw($"Saved file {savedFileName} to {saveFileDialog.FileName}", false, "debug");
                            tabSystem.ChangeCurrentTabTitle(savedFileName);
                        }
                        catch (Exception)
                        {
                            _ = NotificationManager.FireNotification("Error saving the file", infSettings);
                        }
                    }


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

                        _ = NotificationManager.FireNotification("Called Injection API (Powered by Fluxteam)", infSettings);
                        FluxusAPI.inject();
                        InternalFunctions.RunInternalFunctions();
                        FunctionWatch.runFuncWatch();
                    }
                    catch (Exception)
                    {
                        _ = NotificationManager.FireNotification("Fluxus API failed to inject", infSettings);
                    }
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
                _ = NotificationManager.FireNotification("Already injected", infSettings);
            }
        }

        public void InjectNoNotification()
        {
            FluxusAPI.create_files(Path.GetFullPath("Resources\\libs\\Module.dll"));
            var flag = !FluxusAPI.is_injected(FluxusAPI.pid);
            if (flag)
            {
                try
                {
                    try
                    {

                        _ = NotificationManager.FireNotification("Called Injection API (Powered by Fluxteam)", infSettings);
                        FluxusAPI.inject();
                        InternalFunctions.RunInternalFunctions();
                        FunctionWatch.runFuncWatch();
                    }
                    catch (Exception)
                    {
                        _ = NotificationManager.FireNotification("Fluxus API failed to inject", infSettings);
                    }
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
                _ = NotificationManager.FireNotification("Already injected", infSettings);
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
                GetSettings.Location = Cursor.Position;
            }
            else
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

        private void Information_MouseEnter(object sender, EventArgs e)
        {
            InfoPanel.BackColor = ColorTranslator.FromHtml("#2e2e2e");
        }

        private void Information_MouseLeave(object sender, EventArgs e)
        {

            InfoPanel.BackColor = ColorTranslator.FromHtml("#191919");
        }

        private void InfoIcon_Click(object sender, EventArgs e)
        {
            if (AboutShown == false)
            {
                this.AddOwnedForm(GetAbout);
                GetAbout.Show();
                GetAbout.BringToFront();
                GetAbout.Location = Cursor.Position;
            }
            else
            {
                GetAbout.Hide();
            }
        }

        private async void ScriptsList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/114.0.0.0 Safari/537.36");

                foreach (var item in ScriptsCache)
                {
                    if (ScriptsList.SelectedItem.ToString() == item.title)
                    {
                        if (item.script == "")
                        {
                            break;
                        }

                        try
                        {
                            string ScriptBody = await client.GetStringAsync(item.script);
                            var cm = tabSystem.current_monaco();
                            tabSystem.ChangeCurrentTabTitle(item.title);
                            cm.SetText(ScriptBody);
                        }
                        catch
                        {
                            _ = NotificationManager.FireNotification("Could not fetch script", infSettings);
                        }

                        break;
                    }
                }
            }
            catch (Exception)
            {
                _ = NotificationManager.FireNotification("Couldn't retrieve data", infSettings);
            }
        }

        private void expandButton_MouseEnter(object sender, EventArgs e)
        {
            expandMenu.BackColor = ColorTranslator.FromHtml("#2e2e2e");
        }

        private void expandButton_MouseLeave(object sender, EventArgs e)
        {
            expandMenu.BackColor = ColorTranslator.FromHtml("#191919");
        }

        private void expandButton_Click(object sender, EventArgs e)
        {
            if (IsOptionsCollapsed == false)
            {
                IsOptionsCollapsed = true;
                OptionsMenu.Size = new Size(32, 28);
                ConfigHandler.SetConfigValue("options_collapsed", true);
            }
            else
            {
                IsOptionsCollapsed = false;
                OptionsMenu.Size = new Size(168, 28);
                ConfigHandler.SetConfigValue("options_collapsed", false);
            }
        }
    }

    public class ScriptItem
    {
        public string title { get; set; }
        public string script { get; set; }
    }
}