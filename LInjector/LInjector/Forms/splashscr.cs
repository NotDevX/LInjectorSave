using LInjector.Classes;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LInjector
{
    public partial class splashscr : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        private readonly application mainForm = new application();

        public splashscr()
        {
            InitializeComponent();
        }

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AnimateSplash().ConfigureAwait(false);
        }

        public async Task AnimateSplash()
        {
            await Task.Delay(1700);

            var startFadeOutTime = DateTime.Now;
            double fadeOutDuration = 500;

            while (DateTime.Now - startFadeOutTime < TimeSpan.FromMilliseconds(fadeOutDuration))
            {
                var elapsedMilliseconds = (DateTime.Now - startFadeOutTime).TotalMilliseconds;
                var opacity = 1 - elapsedMilliseconds / fadeOutDuration;
                if (opacity < 0)
                    opacity = 0;

                Opacity = opacity;
                await Task.Delay(10);
            }

            mainForm.Show();
            mainForm.BringToFront();

            try
            {
                Hide();
            }
            catch (Exception)
            {
                ThreadBox.MsgThread("Couldn't hide splash screen form.", "LInjector");
            }

            DoPipe.PlayPipeSound(DoPipe.selectedArg);
        }

        private void DragWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
