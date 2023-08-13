namespace LInjector
{
    partial class application
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
            System.Windows.Forms.Button EditButton;
            System.Windows.Forms.Button FileButton;
            System.Windows.Forms.Button LInjectorLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(application));
            this.EditStrip = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.CopyTool = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadTool = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimapTool = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearTextTool = new System.Windows.Forms.ToolStripMenuItem();
            this.FileStrip = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.OpenFileTool = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileTool = new System.Windows.Forms.ToolStripMenuItem();
            this.titlebar = new System.Windows.Forms.Panel();
            this.titleDialog = new System.Windows.Forms.Panel();
            this.menuSettings = new System.Windows.Forms.Panel();
            this.infSettings = new System.Windows.Forms.Button();
            this.controlmenu = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Maximize = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.Panel();
            this.LInjectorIcon = new System.Windows.Forms.PictureBox();
            this.execinjPanel = new System.Windows.Forms.Panel();
            this.OptionsMenu = new System.Windows.Forms.Panel();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.SettingsButton = new System.Windows.Forms.PictureBox();
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.InfoIcon = new System.Windows.Forms.PictureBox();
            this.terminalPanel = new System.Windows.Forms.Panel();
            this.terminalButton = new System.Windows.Forms.PictureBox();
            this.githubPanel = new System.Windows.Forms.Panel();
            this.githubButton = new System.Windows.Forms.PictureBox();
            this.dscPanel = new System.Windows.Forms.Panel();
            this.dscButton = new System.Windows.Forms.PictureBox();
            this.expandMenu = new System.Windows.Forms.Panel();
            this.expandButton = new System.Windows.Forms.PictureBox();
            this.Attach = new System.Windows.Forms.Button();
            this.Execute = new System.Windows.Forms.Button();
            this.OpenTool = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTool = new System.Windows.Forms.ToolStripMenuItem();
            this.holder = new System.Windows.Forms.Panel();
            this.SplitCont = new System.Windows.Forms.SplitContainer();
            this.TabsPanel = new System.Windows.Forms.Panel();
            this.ScriptsList = new LInjector.Classes.Objects.CustomListBox();
            EditButton = new System.Windows.Forms.Button();
            FileButton = new System.Windows.Forms.Button();
            LInjectorLabel = new System.Windows.Forms.Button();
            this.EditStrip.SuspendLayout();
            this.FileStrip.SuspendLayout();
            this.titlebar.SuspendLayout();
            this.titleDialog.SuspendLayout();
            this.menuSettings.SuspendLayout();
            this.controlmenu.SuspendLayout();
            this.icon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LInjectorIcon)).BeginInit();
            this.execinjPanel.SuspendLayout();
            this.OptionsMenu.SuspendLayout();
            this.SettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).BeginInit();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoIcon)).BeginInit();
            this.terminalPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terminalButton)).BeginInit();
            this.githubPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.githubButton)).BeginInit();
            this.dscPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dscButton)).BeginInit();
            this.expandMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expandButton)).BeginInit();
            this.holder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitCont)).BeginInit();
            this.SplitCont.Panel1.SuspendLayout();
            this.SplitCont.Panel2.SuspendLayout();
            this.SplitCont.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditButton
            // 
            EditButton.AutoEllipsis = true;
            EditButton.BackColor = System.Drawing.Color.Transparent;
            EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            EditButton.ContextMenuStrip = this.EditStrip;
            EditButton.Dock = System.Windows.Forms.DockStyle.Left;
            EditButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            EditButton.FlatAppearance.BorderSize = 0;
            EditButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            EditButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            EditButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            EditButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            EditButton.ForeColor = System.Drawing.Color.White;
            EditButton.Location = new System.Drawing.Point(137, 0);
            EditButton.Name = "EditButton";
            EditButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            EditButton.Size = new System.Drawing.Size(53, 29);
            EditButton.TabIndex = 7;
            EditButton.Text = "Edit";
            EditButton.UseMnemonic = false;
            EditButton.UseVisualStyleBackColor = false;
            EditButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.EditButton_Click);
            // 
            // EditStrip
            // 
            this.EditStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.EditStrip.Depth = 0;
            this.EditStrip.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.EditStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyTool,
            this.ReloadTool,
            this.MinimapTool,
            this.ClearTextTool});
            this.EditStrip.MouseState = MaterialSkin.MouseState.HOVER;
            this.EditStrip.Name = "FileStrip";
            this.EditStrip.ShowCheckMargin = true;
            this.EditStrip.ShowImageMargin = false;
            this.EditStrip.Size = new System.Drawing.Size(218, 100);
            // 
            // CopyTool
            // 
            this.CopyTool.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.CopyTool.Name = "CopyTool";
            this.CopyTool.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.CopyTool.ShowShortcutKeys = false;
            this.CopyTool.Size = new System.Drawing.Size(217, 24);
            this.CopyTool.Text = "Copy TextBox";
            this.CopyTool.ToolTipText = "Copy the current tab editor text.";
            this.CopyTool.Click += new System.EventHandler(this.copyTextbox_Click);
            // 
            // ReloadTool
            // 
            this.ReloadTool.Name = "ReloadTool";
            this.ReloadTool.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.ReloadTool.ShowShortcutKeys = false;
            this.ReloadTool.Size = new System.Drawing.Size(217, 24);
            this.ReloadTool.Text = "Reload LInjector";
            this.ReloadTool.ToolTipText = "Reload LInjector Application";
            this.ReloadTool.Click += new System.EventHandler(this.reloadApp_Click);
            // 
            // MinimapTool
            // 
            this.MinimapTool.Name = "MinimapTool";
            this.MinimapTool.Size = new System.Drawing.Size(217, 24);
            this.MinimapTool.Text = "Toggle Editor Minimap";
            this.MinimapTool.Click += new System.EventHandler(this.ToggleMinimap_Click);
            // 
            // ClearTextTool
            // 
            this.ClearTextTool.Name = "ClearTextTool";
            this.ClearTextTool.Size = new System.Drawing.Size(217, 24);
            this.ClearTextTool.Text = "Clear TextBox";
            this.ClearTextTool.ToolTipText = "Clears the content of the textbox of the current tab.";
            this.ClearTextTool.Click += new System.EventHandler(this.ClearTB_Click);
            // 
            // FileButton
            // 
            FileButton.AutoEllipsis = true;
            FileButton.BackColor = System.Drawing.Color.Transparent;
            FileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            FileButton.ContextMenuStrip = this.FileStrip;
            FileButton.Dock = System.Windows.Forms.DockStyle.Left;
            FileButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            FileButton.FlatAppearance.BorderSize = 0;
            FileButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            FileButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            FileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            FileButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            FileButton.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            FileButton.ForeColor = System.Drawing.Color.White;
            FileButton.Location = new System.Drawing.Point(84, 0);
            FileButton.Name = "FileButton";
            FileButton.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            FileButton.Size = new System.Drawing.Size(53, 29);
            FileButton.TabIndex = 6;
            FileButton.Text = "File";
            FileButton.UseMnemonic = false;
            FileButton.UseVisualStyleBackColor = false;
            FileButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FileButton_MouseClick);
            // 
            // FileStrip
            // 
            this.FileStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FileStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.FileStrip.Depth = 0;
            this.FileStrip.Font = new System.Drawing.Font("Microsoft YaHei", 9.75F);
            this.FileStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFileTool,
            this.SaveFileTool});
            this.FileStrip.MouseState = MaterialSkin.MouseState.HOVER;
            this.FileStrip.Name = "FileStrip";
            this.FileStrip.ShowCheckMargin = true;
            this.FileStrip.ShowImageMargin = false;
            this.FileStrip.Size = new System.Drawing.Size(138, 52);
            // 
            // OpenFileTool
            // 
            this.OpenFileTool.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.OpenFileTool.Name = "OpenFileTool";
            this.OpenFileTool.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.OpenFileTool.ShowShortcutKeys = false;
            this.OpenFileTool.Size = new System.Drawing.Size(137, 24);
            this.OpenFileTool.Text = "Open file";
            this.OpenFileTool.ToolTipText = "Open file and load it into editor.";
            this.OpenFileTool.Click += new System.EventHandler(this.openFile_Click);
            // 
            // SaveFileTool
            // 
            this.SaveFileTool.Name = "SaveFileTool";
            this.SaveFileTool.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFileTool.ShowShortcutKeys = false;
            this.SaveFileTool.Size = new System.Drawing.Size(137, 24);
            this.SaveFileTool.Text = "Save to file";
            this.SaveFileTool.ToolTipText = "Save the editor content into a script file.";
            this.SaveFileTool.Click += new System.EventHandler(this.saveFile_Click);
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
            LInjectorLabel.Location = new System.Drawing.Point(0, 0);
            LInjectorLabel.Name = "LInjectorLabel";
            LInjectorLabel.Size = new System.Drawing.Size(84, 29);
            LInjectorLabel.TabIndex = 6;
            LInjectorLabel.Text = "LInjector";
            LInjectorLabel.UseMnemonic = false;
            LInjectorLabel.UseVisualStyleBackColor = false;
            LInjectorLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // titlebar
            // 
            this.titlebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.titlebar.Controls.Add(this.titleDialog);
            this.titlebar.Controls.Add(this.controlmenu);
            this.titlebar.Controls.Add(this.icon);
            this.titlebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlebar.Location = new System.Drawing.Point(5, 5);
            this.titlebar.Margin = new System.Windows.Forms.Padding(10);
            this.titlebar.Name = "titlebar";
            this.titlebar.Padding = new System.Windows.Forms.Padding(3);
            this.titlebar.Size = new System.Drawing.Size(990, 35);
            this.titlebar.TabIndex = 4;
            // 
            // titleDialog
            // 
            this.titleDialog.BackColor = System.Drawing.Color.Transparent;
            this.titleDialog.Controls.Add(this.menuSettings);
            this.titleDialog.Controls.Add(EditButton);
            this.titleDialog.Controls.Add(FileButton);
            this.titleDialog.Controls.Add(LInjectorLabel);
            this.titleDialog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleDialog.Location = new System.Drawing.Point(32, 3);
            this.titleDialog.Name = "titleDialog";
            this.titleDialog.Size = new System.Drawing.Size(865, 29);
            this.titleDialog.TabIndex = 6;
            this.titleDialog.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // menuSettings
            // 
            this.menuSettings.Controls.Add(this.infSettings);
            this.menuSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuSettings.Location = new System.Drawing.Point(190, 0);
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Padding = new System.Windows.Forms.Padding(10, 1, 10, 1);
            this.menuSettings.Size = new System.Drawing.Size(675, 29);
            this.menuSettings.TabIndex = 9;
            this.menuSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // infSettings
            // 
            this.infSettings.BackColor = System.Drawing.Color.Transparent;
            this.infSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.infSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.infSettings.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.infSettings.FlatAppearance.BorderSize = 0;
            this.infSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.infSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.infSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.infSettings.Location = new System.Drawing.Point(10, 1);
            this.infSettings.Name = "infSettings";
            this.infSettings.Size = new System.Drawing.Size(655, 27);
            this.infSettings.TabIndex = 100;
            this.infSettings.Text = ". . .";
            this.infSettings.UseVisualStyleBackColor = false;
            this.infSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // controlmenu
            // 
            this.controlmenu.Controls.Add(this.CloseButton);
            this.controlmenu.Controls.Add(this.Maximize);
            this.controlmenu.Controls.Add(this.Minimize);
            this.controlmenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.controlmenu.Location = new System.Drawing.Point(897, 3);
            this.controlmenu.Name = "controlmenu";
            this.controlmenu.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.controlmenu.Size = new System.Drawing.Size(90, 29);
            this.controlmenu.TabIndex = 3;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CloseButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.Transparent;
            this.CloseButton.Location = new System.Drawing.Point(58, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(29, 29);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "❌";
            this.CloseButton.UseMnemonic = false;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Maximize
            // 
            this.Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Maximize.BackColor = System.Drawing.Color.Transparent;
            this.Maximize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Maximize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Maximize.FlatAppearance.BorderSize = 0;
            this.Maximize.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Maximize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Maximize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Maximize.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Maximize.ForeColor = System.Drawing.Color.Transparent;
            this.Maximize.Location = new System.Drawing.Point(29, 2);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(29, 29);
            this.Maximize.TabIndex = 1;
            this.Maximize.Text = "▢";
            this.Maximize.UseMnemonic = false;
            this.Maximize.UseVisualStyleBackColor = false;
            this.Maximize.Click += new System.EventHandler(this.Maximize_Click);
            // 
            // Minimize
            // 
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize.BackColor = System.Drawing.Color.Transparent;
            this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Minimize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Minimize.FlatAppearance.BorderSize = 0;
            this.Minimize.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Minimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Minimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minimize.ForeColor = System.Drawing.Color.Transparent;
            this.Minimize.Location = new System.Drawing.Point(0, 2);
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
            this.LInjectorIcon.Image = global::LInjector.Properties.Resources.linj_shadow;
            this.LInjectorIcon.ImageLocation = "";
            this.LInjectorIcon.InitialImage = null;
            this.LInjectorIcon.Location = new System.Drawing.Point(0, 0);
            this.LInjectorIcon.Name = "LInjectorIcon";
            this.LInjectorIcon.Size = new System.Drawing.Size(29, 29);
            this.LInjectorIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LInjectorIcon.TabIndex = 0;
            this.LInjectorIcon.TabStop = false;
            this.LInjectorIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // execinjPanel
            // 
            this.execinjPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.execinjPanel.Controls.Add(this.OptionsMenu);
            this.execinjPanel.Controls.Add(this.Attach);
            this.execinjPanel.Controls.Add(this.Execute);
            this.execinjPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.execinjPanel.Location = new System.Drawing.Point(5, 40);
            this.execinjPanel.Name = "execinjPanel";
            this.execinjPanel.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.execinjPanel.Size = new System.Drawing.Size(990, 28);
            this.execinjPanel.TabIndex = 7;
            this.execinjPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            // 
            // OptionsMenu
            // 
            this.OptionsMenu.Controls.Add(this.SettingsPanel);
            this.OptionsMenu.Controls.Add(this.InfoPanel);
            this.OptionsMenu.Controls.Add(this.terminalPanel);
            this.OptionsMenu.Controls.Add(this.githubPanel);
            this.OptionsMenu.Controls.Add(this.dscPanel);
            this.OptionsMenu.Controls.Add(this.expandMenu);
            this.OptionsMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.OptionsMenu.Location = new System.Drawing.Point(819, 0);
            this.OptionsMenu.Name = "OptionsMenu";
            this.OptionsMenu.Size = new System.Drawing.Size(168, 28);
            this.OptionsMenu.TabIndex = 11;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Controls.Add(this.SettingsButton);
            this.SettingsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.SettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Padding = new System.Windows.Forms.Padding(5);
            this.SettingsPanel.Size = new System.Drawing.Size(28, 28);
            this.SettingsPanel.TabIndex = 38;
            this.SettingsPanel.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsButton.Image = global::LInjector.Properties.Resources.SettingIcon;
            this.SettingsButton.Location = new System.Drawing.Point(5, 5);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(18, 18);
            this.SettingsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SettingsButton.TabIndex = 0;
            this.SettingsButton.TabStop = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            this.SettingsButton.MouseEnter += new System.EventHandler(this.SettingsButton_MouseEnter);
            this.SettingsButton.MouseLeave += new System.EventHandler(this.SettingsButton_MouseLeave);
            // 
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.InfoIcon);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.InfoPanel.Location = new System.Drawing.Point(28, 0);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Padding = new System.Windows.Forms.Padding(5);
            this.InfoPanel.Size = new System.Drawing.Size(28, 28);
            this.InfoPanel.TabIndex = 37;
            this.InfoPanel.Click += new System.EventHandler(this.InfoIcon_Click);
            this.InfoPanel.MouseEnter += new System.EventHandler(this.Information_MouseEnter);
            this.InfoPanel.MouseLeave += new System.EventHandler(this.Information_MouseLeave);
            // 
            // InfoIcon
            // 
            this.InfoIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoIcon.Image = global::LInjector.Properties.Resources.InfoIcon;
            this.InfoIcon.Location = new System.Drawing.Point(5, 5);
            this.InfoIcon.Name = "InfoIcon";
            this.InfoIcon.Size = new System.Drawing.Size(18, 18);
            this.InfoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InfoIcon.TabIndex = 0;
            this.InfoIcon.TabStop = false;
            this.InfoIcon.Click += new System.EventHandler(this.InfoIcon_Click);
            this.InfoIcon.MouseEnter += new System.EventHandler(this.Information_MouseEnter);
            this.InfoIcon.MouseHover += new System.EventHandler(this.Information_MouseLeave);
            // 
            // terminalPanel
            // 
            this.terminalPanel.Controls.Add(this.terminalButton);
            this.terminalPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.terminalPanel.Location = new System.Drawing.Point(56, 0);
            this.terminalPanel.Name = "terminalPanel";
            this.terminalPanel.Padding = new System.Windows.Forms.Padding(5);
            this.terminalPanel.Size = new System.Drawing.Size(28, 28);
            this.terminalPanel.TabIndex = 35;
            // 
            // terminalButton
            // 
            this.terminalButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminalButton.Image = global::LInjector.Properties.Resources.terminal_icon;
            this.terminalButton.Location = new System.Drawing.Point(5, 5);
            this.terminalButton.Name = "terminalButton";
            this.terminalButton.Size = new System.Drawing.Size(18, 18);
            this.terminalButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.terminalButton.TabIndex = 0;
            this.terminalButton.TabStop = false;
            this.terminalButton.Click += new System.EventHandler(this.terminalButton_Click);
            this.terminalButton.MouseEnter += new System.EventHandler(this.terminalButton_MouseEnter);
            this.terminalButton.MouseLeave += new System.EventHandler(this.terminalButton_MouseLeave);
            // 
            // githubPanel
            // 
            this.githubPanel.Controls.Add(this.githubButton);
            this.githubPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.githubPanel.Location = new System.Drawing.Point(84, 0);
            this.githubPanel.Name = "githubPanel";
            this.githubPanel.Padding = new System.Windows.Forms.Padding(5);
            this.githubPanel.Size = new System.Drawing.Size(28, 28);
            this.githubPanel.TabIndex = 32;
            // 
            // githubButton
            // 
            this.githubButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.githubButton.Image = global::LInjector.Properties.Resources.github_mark_white;
            this.githubButton.Location = new System.Drawing.Point(5, 5);
            this.githubButton.Name = "githubButton";
            this.githubButton.Size = new System.Drawing.Size(18, 18);
            this.githubButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.githubButton.TabIndex = 0;
            this.githubButton.TabStop = false;
            this.githubButton.Click += new System.EventHandler(this.githubButton_Click);
            this.githubButton.MouseEnter += new System.EventHandler(this.githubButton_MouseEnter);
            this.githubButton.MouseLeave += new System.EventHandler(this.githubButton_MouseLeave);
            // 
            // dscPanel
            // 
            this.dscPanel.Controls.Add(this.dscButton);
            this.dscPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.dscPanel.Location = new System.Drawing.Point(112, 0);
            this.dscPanel.Name = "dscPanel";
            this.dscPanel.Padding = new System.Windows.Forms.Padding(5);
            this.dscPanel.Size = new System.Drawing.Size(28, 28);
            this.dscPanel.TabIndex = 28;
            // 
            // dscButton
            // 
            this.dscButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dscButton.Image = global::LInjector.Properties.Resources.discord_icon;
            this.dscButton.Location = new System.Drawing.Point(5, 5);
            this.dscButton.Name = "dscButton";
            this.dscButton.Size = new System.Drawing.Size(18, 18);
            this.dscButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.dscButton.TabIndex = 0;
            this.dscButton.TabStop = false;
            this.dscButton.Click += new System.EventHandler(this.dscButton_Click);
            this.dscButton.MouseEnter += new System.EventHandler(this.dscButton_MouseEnter);
            this.dscButton.MouseLeave += new System.EventHandler(this.dscButton_MouseLeave);
            // 
            // expandMenu
            // 
            this.expandMenu.Controls.Add(this.expandButton);
            this.expandMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.expandMenu.Location = new System.Drawing.Point(140, 0);
            this.expandMenu.Name = "expandMenu";
            this.expandMenu.Padding = new System.Windows.Forms.Padding(5);
            this.expandMenu.Size = new System.Drawing.Size(28, 28);
            this.expandMenu.TabIndex = 27;
            this.expandMenu.Click += new System.EventHandler(this.expandButton_Click);
            // 
            // expandButton
            // 
            this.expandButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expandButton.Image = global::LInjector.Properties.Resources.expandcollapse;
            this.expandButton.Location = new System.Drawing.Point(5, 5);
            this.expandButton.Name = "expandButton";
            this.expandButton.Size = new System.Drawing.Size(18, 18);
            this.expandButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.expandButton.TabIndex = 0;
            this.expandButton.TabStop = false;
            this.expandButton.Click += new System.EventHandler(this.expandButton_Click);
            this.expandButton.MouseEnter += new System.EventHandler(this.expandButton_MouseEnter);
            this.expandButton.MouseLeave += new System.EventHandler(this.expandButton_MouseLeave);
            // 
            // Attach
            // 
            this.Attach.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Attach.Dock = System.Windows.Forms.DockStyle.Left;
            this.Attach.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Attach.FlatAppearance.BorderSize = 0;
            this.Attach.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Attach.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Attach.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Attach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Attach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attach.ForeColor = System.Drawing.Color.Transparent;
            this.Attach.Location = new System.Drawing.Point(32, 0);
            this.Attach.Name = "Attach";
            this.Attach.Size = new System.Drawing.Size(29, 28);
            this.Attach.TabIndex = 10;
            this.Attach.Text = "🧩";
            this.Attach.UseMnemonic = false;
            this.Attach.UseVisualStyleBackColor = true;
            this.Attach.Click += new System.EventHandler(this.Attach_Click);
            // 
            // Execute
            // 
            this.Execute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Execute.Dock = System.Windows.Forms.DockStyle.Left;
            this.Execute.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Execute.FlatAppearance.BorderSize = 0;
            this.Execute.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            this.Execute.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Execute.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.Execute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Execute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Execute.Location = new System.Drawing.Point(3, 0);
            this.Execute.Name = "Execute";
            this.Execute.Size = new System.Drawing.Size(29, 28);
            this.Execute.TabIndex = 10;
            this.Execute.Text = "▶";
            this.Execute.UseMnemonic = false;
            this.Execute.UseVisualStyleBackColor = true;
            this.Execute.Click += new System.EventHandler(this.Execute_Click);
            // 
            // OpenTool
            // 
            this.OpenTool.Name = "OpenTool";
            this.OpenTool.Size = new System.Drawing.Size(32, 19);
            // 
            // SaveTool
            // 
            this.SaveTool.Name = "SaveTool";
            this.SaveTool.Size = new System.Drawing.Size(32, 19);
            // 
            // holder
            // 
            this.holder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.holder.Controls.Add(this.SplitCont);
            this.holder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holder.Location = new System.Drawing.Point(5, 68);
            this.holder.Name = "holder";
            this.holder.Padding = new System.Windows.Forms.Padding(5);
            this.holder.Size = new System.Drawing.Size(990, 427);
            this.holder.TabIndex = 8;
            // 
            // SplitCont
            // 
            this.SplitCont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitCont.Location = new System.Drawing.Point(5, 5);
            this.SplitCont.Name = "SplitCont";
            // 
            // SplitCont.Panel1
            // 
            this.SplitCont.Panel1.Controls.Add(this.TabsPanel);
            this.SplitCont.Panel1.Padding = new System.Windows.Forms.Padding(1);
            // 
            // SplitCont.Panel2
            // 
            this.SplitCont.Panel2.Controls.Add(this.ScriptsList);
            this.SplitCont.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.SplitCont.Panel2MinSize = 0;
            this.SplitCont.Size = new System.Drawing.Size(980, 417);
            this.SplitCont.SplitterDistance = 757;
            this.SplitCont.TabIndex = 0;
            // 
            // TabsPanel
            // 
            this.TabsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabsPanel.Location = new System.Drawing.Point(1, 1);
            this.TabsPanel.Name = "TabsPanel";
            this.TabsPanel.Size = new System.Drawing.Size(755, 415);
            this.TabsPanel.TabIndex = 0;
            // 
            // ScriptsList
            // 
            this.ScriptsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ScriptsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScriptsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScriptsList.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScriptsList.ForeColor = System.Drawing.Color.White;
            this.ScriptsList.FormattingEnabled = true;
            this.ScriptsList.ItemHeight = 15;
            this.ScriptsList.Location = new System.Drawing.Point(3, 3);
            this.ScriptsList.Name = "ScriptsList";
            this.ScriptsList.ShowScrollbar = false;
            this.ScriptsList.Size = new System.Drawing.Size(213, 411);
            this.ScriptsList.TabIndex = 0;
            this.ScriptsList.DoubleClick += new System.EventHandler(this.ScriptsList_DoubleClick);
            // 
            // application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(15)))), ((int)(((byte)(15)))));
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.ControlBox = false;
            this.Controls.Add(this.holder);
            this.Controls.Add(this.execinjPanel);
            this.Controls.Add(this.titlebar);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "application";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Load += new System.EventHandler(this.application_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragWindow);
            this.EditStrip.ResumeLayout(false);
            this.FileStrip.ResumeLayout(false);
            this.titlebar.ResumeLayout(false);
            this.titleDialog.ResumeLayout(false);
            this.menuSettings.ResumeLayout(false);
            this.controlmenu.ResumeLayout(false);
            this.icon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LInjectorIcon)).EndInit();
            this.execinjPanel.ResumeLayout(false);
            this.OptionsMenu.ResumeLayout(false);
            this.SettingsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsButton)).EndInit();
            this.InfoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InfoIcon)).EndInit();
            this.terminalPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.terminalButton)).EndInit();
            this.githubPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.githubButton)).EndInit();
            this.dscPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dscButton)).EndInit();
            this.expandMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.expandButton)).EndInit();
            this.holder.ResumeLayout(false);
            this.SplitCont.Panel1.ResumeLayout(false);
            this.SplitCont.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitCont)).EndInit();
            this.SplitCont.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titlebar;
        private System.Windows.Forms.Panel icon;
        private System.Windows.Forms.PictureBox LInjectorIcon;
        private System.Windows.Forms.Panel controlmenu;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button Maximize;
        private System.Windows.Forms.Button Minimize;
        private System.Windows.Forms.Panel titleDialog;
        private System.Windows.Forms.Panel execinjPanel;
        private System.Windows.Forms.Button Attach;
        private System.Windows.Forms.Button Execute;
        private System.Windows.Forms.Panel menuSettings;
        private System.Windows.Forms.ToolStripMenuItem OpenTool;
        private System.Windows.Forms.ToolStripMenuItem SaveTool;
        private MaterialSkin.Controls.MaterialContextMenuStrip FileStrip;
        private System.Windows.Forms.ToolStripMenuItem OpenFileTool;
        private System.Windows.Forms.ToolStripMenuItem SaveFileTool;
        private MaterialSkin.Controls.MaterialContextMenuStrip EditStrip;
        private System.Windows.Forms.ToolStripMenuItem CopyTool;
        private System.Windows.Forms.ToolStripMenuItem ReloadTool;
        private System.Windows.Forms.ToolStripMenuItem MinimapTool;
        public System.Windows.Forms.Button infSettings;
        private System.Windows.Forms.ToolStripMenuItem ClearTextTool;
        private System.Windows.Forms.Panel holder;
        public System.Windows.Forms.Panel TabsPanel;
        private Classes.Objects.CustomListBox ScriptsList;
        private System.Windows.Forms.Panel expandMenu;
        private System.Windows.Forms.PictureBox expandButton;
        private System.Windows.Forms.Panel githubPanel;
        private System.Windows.Forms.PictureBox githubButton;
        private System.Windows.Forms.Panel dscPanel;
        private System.Windows.Forms.PictureBox dscButton;
        public System.Windows.Forms.Panel OptionsMenu;
        public System.Windows.Forms.SplitContainer SplitCont;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.PictureBox SettingsButton;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.PictureBox InfoIcon;
        private System.Windows.Forms.Panel terminalPanel;
        private System.Windows.Forms.PictureBox terminalButton;
    }
}
