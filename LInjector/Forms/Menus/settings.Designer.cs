namespace LInjector.Forms.Menus
{
    partial class settings
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
            System.Windows.Forms.Button LInjectorLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settings));
            this.titlebar = new System.Windows.Forms.Panel();
            this.controlmenu = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.Panel();
            this.LInjectorIcon = new System.Windows.Forms.PictureBox();
            this.holder = new System.Windows.Forms.Panel();
            this.TopMostHandler = new MaterialSkin.Controls.MaterialSwitch();
            this.RPCHandler = new MaterialSkin.Controls.MaterialSwitch();
            this.ConsoleHandler = new MaterialSkin.Controls.MaterialSwitch();
            this.SplashHandler = new MaterialSkin.Controls.MaterialSwitch();
            this.AttachHandler = new MaterialSkin.Controls.MaterialSwitch();
            LInjectorLabel = new System.Windows.Forms.Button();
            this.titlebar.SuspendLayout();
            this.controlmenu.SuspendLayout();
            this.icon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LInjectorIcon)).BeginInit();
            this.holder.SuspendLayout();
            this.SuspendLayout();
            // 
            // LInjectorLabel
            // 
            LInjectorLabel.BackColor = System.Drawing.Color.Transparent;
            LInjectorLabel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            LInjectorLabel.Dock = System.Windows.Forms.DockStyle.Left;
            LInjectorLabel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            LInjectorLabel.FlatAppearance.BorderSize = 0;
            LInjectorLabel.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            LInjectorLabel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            LInjectorLabel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            LInjectorLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            LInjectorLabel.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            LInjectorLabel.ForeColor = System.Drawing.Color.White;
            LInjectorLabel.Location = new System.Drawing.Point(32, 3);
            LInjectorLabel.Name = "LInjectorLabel";
            LInjectorLabel.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            LInjectorLabel.Size = new System.Drawing.Size(84, 29);
            LInjectorLabel.TabIndex = 7;
            LInjectorLabel.Text = "Settings";
            LInjectorLabel.UseMnemonic = false;
            LInjectorLabel.UseVisualStyleBackColor = false;
            LInjectorLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // titlebar
            // 
            this.titlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.titlebar.Controls.Add(LInjectorLabel);
            this.titlebar.Controls.Add(this.controlmenu);
            this.titlebar.Controls.Add(this.icon);
            this.titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlebar.Location = new System.Drawing.Point(5, 5);
            this.titlebar.Margin = new System.Windows.Forms.Padding(10);
            this.titlebar.Name = "titlebar";
            this.titlebar.Padding = new System.Windows.Forms.Padding(3);
            this.titlebar.Size = new System.Drawing.Size(274, 35);
            this.titlebar.TabIndex = 5;
            this.titlebar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // controlmenu
            // 
            this.controlmenu.Controls.Add(this.CloseButton);
            this.controlmenu.Controls.Add(this.Minimize);
            this.controlmenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlmenu.Location = new System.Drawing.Point(213, 3);
            this.controlmenu.Name = "controlmenu";
            this.controlmenu.Size = new System.Drawing.Size(58, 29);
            this.controlmenu.TabIndex = 3;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.Transparent;
            this.CloseButton.Location = new System.Drawing.Point(0, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(29, 29);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "❌";
            this.CloseButton.UseMnemonic = false;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Minimize
            // 
            this.Minimize.BackColor = System.Drawing.Color.Transparent;
            this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Minimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.Minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Minimize.FlatAppearance.BorderSize = 0;
            this.Minimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minimize.ForeColor = System.Drawing.Color.Transparent;
            this.Minimize.Location = new System.Drawing.Point(29, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(29, 29);
            this.Minimize.TabIndex = 0;
            this.Minimize.Text = "—";
            this.Minimize.UseMnemonic = false;
            this.Minimize.UseVisualStyleBackColor = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // icon
            // 
            this.icon.Controls.Add(this.LInjectorIcon);
            this.icon.Dock = System.Windows.Forms.DockStyle.Left;
            this.icon.Location = new System.Drawing.Point(3, 3);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(29, 29);
            this.icon.TabIndex = 0;
            // 
            // LInjectorIcon
            // 
            this.LInjectorIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.LInjectorIcon.Image = global::LInjector.Properties.Resources.LInjector;
            this.LInjectorIcon.Location = new System.Drawing.Point(0, 0);
            this.LInjectorIcon.Name = "LInjectorIcon";
            this.LInjectorIcon.Size = new System.Drawing.Size(29, 29);
            this.LInjectorIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LInjectorIcon.TabIndex = 0;
            this.LInjectorIcon.TabStop = false;
            this.LInjectorIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // holder
            // 
            this.holder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.holder.Controls.Add(this.TopMostHandler);
            this.holder.Controls.Add(this.RPCHandler);
            this.holder.Controls.Add(this.ConsoleHandler);
            this.holder.Controls.Add(this.SplashHandler);
            this.holder.Controls.Add(this.AttachHandler);
            this.holder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holder.Location = new System.Drawing.Point(5, 40);
            this.holder.Name = "holder";
            this.holder.Padding = new System.Windows.Forms.Padding(5);
            this.holder.Size = new System.Drawing.Size(274, 416);
            this.holder.TabIndex = 6;
            // 
            // TopMostHandler
            // 
            this.TopMostHandler.AutoSize = true;
            this.TopMostHandler.Depth = 0;
            this.TopMostHandler.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMostHandler.ForeColor = System.Drawing.Color.White;
            this.TopMostHandler.Location = new System.Drawing.Point(5, 153);
            this.TopMostHandler.Margin = new System.Windows.Forms.Padding(0);
            this.TopMostHandler.MaximumSize = new System.Drawing.Size(275, 40);
            this.TopMostHandler.MinimumSize = new System.Drawing.Size(275, 40);
            this.TopMostHandler.MouseLocation = new System.Drawing.Point(-1, -1);
            this.TopMostHandler.MouseState = MaterialSkin.MouseState.HOVER;
            this.TopMostHandler.Name = "TopMostHandler";
            this.TopMostHandler.Ripple = true;
            this.TopMostHandler.Size = new System.Drawing.Size(275, 40);
            this.TopMostHandler.TabIndex = 5;
            this.TopMostHandler.Text = "Top Most";
            this.TopMostHandler.UseVisualStyleBackColor = true;
            this.TopMostHandler.CheckedChanged += new System.EventHandler(this.TopMostHandler_CheckedChanged);
            // 
            // RPCHandler
            // 
            this.RPCHandler.AutoSize = true;
            this.RPCHandler.Depth = 0;
            this.RPCHandler.Dock = System.Windows.Forms.DockStyle.Top;
            this.RPCHandler.ForeColor = System.Drawing.Color.White;
            this.RPCHandler.Location = new System.Drawing.Point(5, 116);
            this.RPCHandler.Margin = new System.Windows.Forms.Padding(0);
            this.RPCHandler.MouseLocation = new System.Drawing.Point(-1, -1);
            this.RPCHandler.MouseState = MaterialSkin.MouseState.HOVER;
            this.RPCHandler.Name = "RPCHandler";
            this.RPCHandler.Ripple = true;
            this.RPCHandler.Size = new System.Drawing.Size(264, 37);
            this.RPCHandler.TabIndex = 4;
            this.RPCHandler.Text = "RPC Status";
            this.RPCHandler.UseVisualStyleBackColor = true;
            this.RPCHandler.CheckedChanged += new System.EventHandler(this.RPCHandler_CheckedChanged);
            // 
            // ConsoleHandler
            // 
            this.ConsoleHandler.AutoSize = true;
            this.ConsoleHandler.Depth = 0;
            this.ConsoleHandler.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConsoleHandler.ForeColor = System.Drawing.Color.White;
            this.ConsoleHandler.Location = new System.Drawing.Point(5, 79);
            this.ConsoleHandler.Margin = new System.Windows.Forms.Padding(0);
            this.ConsoleHandler.MouseLocation = new System.Drawing.Point(-1, -1);
            this.ConsoleHandler.MouseState = MaterialSkin.MouseState.HOVER;
            this.ConsoleHandler.Name = "ConsoleHandler";
            this.ConsoleHandler.Ripple = true;
            this.ConsoleHandler.Size = new System.Drawing.Size(264, 37);
            this.ConsoleHandler.TabIndex = 3;
            this.ConsoleHandler.Text = "Show Console";
            this.ConsoleHandler.UseVisualStyleBackColor = true;
            this.ConsoleHandler.CheckedChanged += new System.EventHandler(this.ConsoleHandler_CheckedChanged);
            // 
            // SplashHandler
            // 
            this.SplashHandler.AutoSize = true;
            this.SplashHandler.Depth = 0;
            this.SplashHandler.Dock = System.Windows.Forms.DockStyle.Top;
            this.SplashHandler.ForeColor = System.Drawing.Color.White;
            this.SplashHandler.Location = new System.Drawing.Point(5, 42);
            this.SplashHandler.Margin = new System.Windows.Forms.Padding(0);
            this.SplashHandler.MouseLocation = new System.Drawing.Point(-1, -1);
            this.SplashHandler.MouseState = MaterialSkin.MouseState.HOVER;
            this.SplashHandler.Name = "SplashHandler";
            this.SplashHandler.Ripple = true;
            this.SplashHandler.Size = new System.Drawing.Size(264, 37);
            this.SplashHandler.TabIndex = 1;
            this.SplashHandler.Text = "Splash Screen";
            this.SplashHandler.UseVisualStyleBackColor = true;
            this.SplashHandler.CheckedChanged += new System.EventHandler(this.SplashHandler_CheckedChanged);
            // 
            // AttachHandler
            // 
            this.AttachHandler.AutoSize = true;
            this.AttachHandler.Depth = 0;
            this.AttachHandler.Dock = System.Windows.Forms.DockStyle.Top;
            this.AttachHandler.ForeColor = System.Drawing.Color.White;
            this.AttachHandler.Location = new System.Drawing.Point(5, 5);
            this.AttachHandler.Margin = new System.Windows.Forms.Padding(0);
            this.AttachHandler.MouseLocation = new System.Drawing.Point(-1, -1);
            this.AttachHandler.MouseState = MaterialSkin.MouseState.HOVER;
            this.AttachHandler.Name = "AttachHandler";
            this.AttachHandler.Ripple = true;
            this.AttachHandler.Size = new System.Drawing.Size(264, 37);
            this.AttachHandler.TabIndex = 0;
            this.AttachHandler.Text = "Auto Attach";
            this.AttachHandler.UseVisualStyleBackColor = true;
            this.AttachHandler.CheckedChanged += new System.EventHandler(this.AttachHandler_CheckedChanged);
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.holder);
            this.Controls.Add(this.titlebar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settings";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.settings_Load);
            this.Shown += new System.EventHandler(this.settings_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            this.titlebar.ResumeLayout(false);
            this.controlmenu.ResumeLayout(false);
            this.icon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LInjectorIcon)).EndInit();
            this.holder.ResumeLayout(false);
            this.holder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titlebar;
        private System.Windows.Forms.Panel controlmenu;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button Minimize;
        private System.Windows.Forms.Panel icon;
        private System.Windows.Forms.PictureBox LInjectorIcon;
        private System.Windows.Forms.Panel holder;
        public MaterialSkin.Controls.MaterialSwitch AttachHandler;
        public MaterialSkin.Controls.MaterialSwitch SplashHandler;
        public MaterialSkin.Controls.MaterialSwitch ConsoleHandler;
        public MaterialSkin.Controls.MaterialSwitch RPCHandler;
        public MaterialSkin.Controls.MaterialSwitch TopMostHandler;
    }
}