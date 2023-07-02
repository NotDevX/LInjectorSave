using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LInjector.Classes
{
    public class SpinningRGBPanel : Panel
    {
        private const double RotationSpeed = 1; // Velocidad de rotación del degradado
        private const int AnimationDuration = 2500; // Duración de la animación en milisegundos

        private Timer timer;
        private double angle;
        private Color color1;
        private Color color2;
        private Bitmap buffer;
        private DateTime startTime;

        public Color Color1
        {
            get { return color1; }
            set
            {
                color1 = value;
                Refresh();
            }
        }

        public Color Color2
        {
            get { return color2; }
            set
            {
                color2 = value;
                Refresh();
            }
        }

        public SpinningRGBPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            InitializePanel();
        }

        private void InitializePanel()
        {
            Dock = DockStyle.Fill;

            if (!DesignMode)
            {
                timer = new Timer();
                timer.Interval = 10;
                timer.Tick += Timer_Tick;

                angle = 90;
                startTime = DateTime.Now;

                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                double elapsedMilliseconds = (DateTime.Now - startTime).TotalMilliseconds;
                if (elapsedMilliseconds >= AnimationDuration)
                {
                    timer.Stop();
                    return;
                }
                angle += RotationSpeed;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (buffer == null || buffer.Size != ClientSize)
            {
                buffer?.Dispose();
                buffer = new Bitmap(ClientSize.Width, ClientSize.Height);
            }

            using (Graphics bufferGraphics = Graphics.FromImage(buffer))
            {
                bufferGraphics.Clear(BackColor);

                using (GraphicsPath path = CreateRoundRectanglePath(ClientRectangle, 10))
                using (Region region = new Region(path))
                {
                    bufferGraphics.SetClip(region, CombineMode.Replace);

                    using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, color1, color2, (float)angle))
                    {
                        bufferGraphics.FillPath(brush, path);
                    }
                }
            }

            e.Graphics.DrawImage(buffer, 0, 0);
        }

        private GraphicsPath CreateRoundRectanglePath(Rectangle rectangle, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            Rectangle arcRect = new Rectangle(rectangle.Location, new Size(diameter, diameter));

            path.AddArc(arcRect, 180, 90);

            arcRect.X = rectangle.Right - diameter;
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rectangle.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rectangle.Left;
            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();

            return path;
        }
    }
}
