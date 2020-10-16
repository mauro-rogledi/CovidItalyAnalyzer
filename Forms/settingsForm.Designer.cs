namespace CovidItalyAnalyzer.Forms
{
    partial class settingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtFolder = new MetroFramework.Controls.MetroTextBox();
            this.fbdFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.btnUndo = new MetroFramework.Controls.MetroLink();
            this.btnSave = new MetroFramework.Controls.MetroLink();
            this.cbbUseGitHub = new MetroFramework.Controls.MetroCheckBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtUsername = new MetroFramework.Controls.MetroTextBox();
            this.txtPassword = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtEmail = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.UseStyleColors = true;
            // 
            // txtFolder
            // 
            resources.ApplyResources(this.txtFolder, "txtFolder");
            // 
            // 
            // 
            this.txtFolder.CustomButton.Image = global::CovidItalyAnalyzer.Properties.Resources.icons8_folder_24;
            this.txtFolder.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode")));
            this.txtFolder.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.txtFolder.CustomButton.Name = "";
            this.txtFolder.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.txtFolder.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFolder.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.txtFolder.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFolder.CustomButton.UseSelectable = true;
            this.txtFolder.Icon = global::CovidItalyAnalyzer.Properties.Resources.icons8_folder_24;
            this.txtFolder.IconRight = true;
            this.txtFolder.Lines = new string[0];
            this.txtFolder.MaxLength = 32767;
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.PasswordChar = '\0';
            this.txtFolder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFolder.SelectedText = "";
            this.txtFolder.SelectionLength = 0;
            this.txtFolder.SelectionStart = 0;
            this.txtFolder.ShortcutsEnabled = true;
            this.txtFolder.ShowButton = true;
            this.txtFolder.ShowClearButton = true;
            this.txtFolder.UseSelectable = true;
            this.txtFolder.UseStyleColors = true;
            this.txtFolder.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFolder.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtFolder.ButtonClick += new MetroFramework.Controls.MetroTextBox.ButClick(this.btnFolder_Click);
            // 
            // btnUndo
            // 
            resources.ApplyResources(this.btnUndo, "btnUndo");
            this.btnUndo.Image = global::CovidItalyAnalyzer.Properties.Resources.icons8_undo_24;
            this.btnUndo.ImageSize = 24;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.UseSelectable = true;
            this.btnUndo.UseStyleColors = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Image = global::CovidItalyAnalyzer.Properties.Resources.icons8_save_24;
            this.btnSave.ImageSize = 24;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseSelectable = true;
            this.btnSave.UseStyleColors = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbbUseGitHub
            // 
            resources.ApplyResources(this.cbbUseGitHub, "cbbUseGitHub");
            this.cbbUseGitHub.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.cbbUseGitHub.Name = "cbbUseGitHub";
            this.cbbUseGitHub.UseSelectable = true;
            this.cbbUseGitHub.UseStyleColors = true;
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.UseStyleColors = true;
            // 
            // txtUsername
            // 
            resources.ApplyResources(this.txtUsername, "txtUsername");
            // 
            // 
            // 
            this.txtUsername.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.txtUsername.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode1")));
            this.txtUsername.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
            this.txtUsername.CustomButton.Name = "";
            this.txtUsername.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
            this.txtUsername.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsername.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
            this.txtUsername.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsername.CustomButton.UseSelectable = true;
            this.txtUsername.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.txtUsername.Lines = new string[0];
            this.txtUsername.MaxLength = 32767;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsername.SelectedText = "";
            this.txtUsername.SelectionLength = 0;
            this.txtUsername.SelectionStart = 0;
            this.txtUsername.ShortcutsEnabled = true;
            this.txtUsername.UseSelectable = true;
            this.txtUsername.UseStyleColors = true;
            this.txtUsername.WaterMark = "insert username";
            this.txtUsername.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsername.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            // 
            // 
            // 
            this.txtPassword.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.txtPassword.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode2")));
            this.txtPassword.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
            this.txtPassword.CustomButton.Name = "";
            this.txtPassword.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
            this.txtPassword.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPassword.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
            this.txtPassword.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPassword.CustomButton.UseSelectable = true;
            this.txtPassword.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
            this.txtPassword.Lines = new string[0];
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.UseSelectable = true;
            this.txtPassword.UseStyleColors = true;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.WaterMark = "insert password";
            this.txtPassword.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPassword.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            resources.ApplyResources(this.metroLabel4, "metroLabel4");
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.UseStyleColors = true;
            // 
            // txtEmail
            // 
            resources.ApplyResources(this.txtEmail, "txtEmail");
            // 
            // 
            // 
            this.txtEmail.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.txtEmail.CustomButton.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("resource.ImeMode3")));
            this.txtEmail.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location3")));
            this.txtEmail.CustomButton.Name = "";
            this.txtEmail.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size3")));
            this.txtEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEmail.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex3")));
            this.txtEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEmail.CustomButton.UseSelectable = true;
            this.txtEmail.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible2")));
            this.txtEmail.Lines = new string[0];
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.ShortcutsEnabled = true;
            this.txtEmail.UseSelectable = true;
            this.txtEmail.UseStyleColors = true;
            this.txtEmail.WaterMark = "insert email";
            this.txtEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // settingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cbbUseGitHub);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnSave);
            this.Name = "settingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLink btnUndo;
        private MetroFramework.Controls.MetroLink btnSave;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdFolder;
        private MetroFramework.Controls.MetroCheckBox cbbUseGitHub;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtUsername;
        private MetroFramework.Controls.MetroTextBox txtPassword;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtEmail;
    }
}