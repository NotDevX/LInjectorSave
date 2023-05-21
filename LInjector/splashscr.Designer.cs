namespace LInjector
{
    partial class splashscr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(splashscr));
            this.gradientpanel = new System.Windows.Forms.Panel();
            this.spinningRGB = new LInjector.SpinningRGBPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gradientpanel.SuspendLayout();
            this.spinningRGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gradientpanel
            // 
            this.gradientpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.gradientpanel.Controls.Add(this.spinningRGB);
            this.gradientpanel.Location = new System.Drawing.Point(5, 5);
            this.gradientpanel.Name = "gradientpanel";
            this.gradientpanel.Size = new System.Drawing.Size(780, 405);
            this.gradientpanel.TabIndex = 0;
            // 
            // spinningRGB
            // 
            this.spinningRGB.BackColor = System.Drawing.Color.Transparent;
            this.spinningRGB.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(11)))), ((int)(((byte)(128)))));
            this.spinningRGB.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.spinningRGB.Controls.Add(this.pictureBox1);
            this.spinningRGB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spinningRGB.Location = new System.Drawing.Point(0, 0);
            this.spinningRGB.MaximumSize = new System.Drawing.Size(780, 405);
            this.spinningRGB.Name = "spinningRGB";
            this.spinningRGB.Size = new System.Drawing.Size(780, 405);
            this.spinningRGB.TabIndex = 0;
            this.spinningRGB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spinningRGB_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LInjector.Properties.Resources.LInjector;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(340, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // splashscr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(790, 415);
            this.Controls.Add(this.gradientpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "splashscr";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.gradientpanel.ResumeLayout(false);
            this.spinningRGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gradientpanel;
        private LInjector.SpinningRGBPanel spinningRGB;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

