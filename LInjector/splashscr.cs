using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using LInjector;

namespace LInjector
{
    public partial class splashscr : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public splashscr()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AnimateSplash().ConfigureAwait(false);
        }

        private async Task AnimateSplash()
        {
            await Task.Delay(5000); // Esperar 5 segundos (duración de la animación)

            DateTime startFadeOutTime = DateTime.Now;
            double fadeOutDuration = 500; // Duración del fade-out en milisegundos

            while (DateTime.Now - startFadeOutTime < TimeSpan.FromMilliseconds(fadeOutDuration))
            {
                double elapsedMilliseconds = (DateTime.Now - startFadeOutTime).TotalMilliseconds;
                double opacity = 1 - (elapsedMilliseconds / fadeOutDuration);
                if (opacity < 0)
                    opacity = 0;

                Opacity = opacity;
                await Task.Delay(10); // Pequeña pausa para actualizar la opacidad gradualmente
            }

            application mainForm = new application();
            mainForm.Show();

            this.Hide();
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
