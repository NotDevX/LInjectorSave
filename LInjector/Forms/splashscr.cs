using LInjector.Classes;
using System;
using System.Drawing;
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
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

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

        private void spinningRGB_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void linjicon_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void splashscr_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
