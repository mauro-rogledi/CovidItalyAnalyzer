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
            this.btnUndo = new MetroFramework.Controls.MetroLink();
            this.btnSave = new MetroFramework.Controls.MetroLink();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtFolder = new MetroFramework.Controls.MetroTextBox();
            this.btnFolder = new MetroFramework.Controls.MetroLink();
            this.fbdFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
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
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // txtFolder
            // 
            resources.ApplyResources(this.txtFolder, "txtFolder");
            // 
            // 
            // 
            this.txtFolder.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.txtFolder.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
            this.txtFolder.CustomButton.Name = "";
            this.txtFolder.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
            this.txtFolder.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFolder.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
            this.txtFolder.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFolder.CustomButton.UseSelectable = true;
            this.txtFolder.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
            this.txtFolder.Lines = new string[0];
            this.txtFolder.MaxLength = 32767;
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.PasswordChar = '\0';
            this.txtFolder.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtFolder.SelectedText = "";
            this.txtFolder.SelectionLength = 0;
            this.txtFolder.SelectionStart = 0;
            this.txtFolder.ShortcutsEnabled = true;
            this.txtFolder.UseSelectable = true;
            this.txtFolder.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFolder.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnFolder
            // 
            resources.ApplyResources(this.btnFolder, "btnFolder");
            this.btnFolder.Image = global::CovidItalyAnalyzer.Properties.Resources.icons8_folder_24;
            this.btnFolder.ImageSize = 24;
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.UseSelectable = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // settingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFolder);
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
        private MetroFramework.Controls.MetroLink btnFolder;
        private System.Windows.Forms.FolderBrowserDialog fbdFolder;
    }
}