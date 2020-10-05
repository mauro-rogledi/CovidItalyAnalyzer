namespace CovidItalyAnalyzer.Forms
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.btnSettings = new MetroFramework.Controls.MetroLink();
            this.btnRefresh = new MetroFramework.Controls.MetroLink();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tpgRegions = new System.Windows.Forms.TabPage();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.cbbRegionRegion = new MetroFramework.Controls.MetroComboBox();
            this.tpgCounty = new System.Windows.Forms.TabPage();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cbbCountyRegion = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cbbCountyCounty = new MetroFramework.Controls.MetroComboBox();
            this.tpgCharts = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart1 = new LiveCharts.Wpf.CartesianChart();
            this.metroTabControl1.SuspendLayout();
            this.tpgRegions.SuspendLayout();
            this.tpgCounty.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            resources.ApplyResources(this.btnSettings, "btnSettings");
            this.btnSettings.Image = global::CovidItalyAnalyzer.Properties.Resources.icons8_settings_24;
            this.btnSettings.ImageSize = 24;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.UseSelectable = true;
            this.btnSettings.UseStyleColors = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Image = global::CovidItalyAnalyzer.Properties.Resources.icons8_refresh_24;
            this.btnRefresh.ImageSize = 24;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseSelectable = true;
            this.btnRefresh.UseStyleColors = true;
            this.btnRefresh.Click += new System.EventHandler(this.bntRefresh_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tpgRegions);
            this.metroTabControl1.Controls.Add(this.tpgCounty);
            this.metroTabControl1.Controls.Add(this.tpgCharts);
            resources.ApplyResources(this.metroTabControl1, "metroTabControl1");
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tpgRegions
            // 
            this.tpgRegions.Controls.Add(this.panel2);
            this.tpgRegions.Controls.Add(this.panel1);
            resources.ApplyResources(this.tpgRegions, "tpgRegions");
            this.tpgRegions.Name = "tpgRegions";
            this.tpgRegions.UseVisualStyleBackColor = true;
            // 
            // metroLabel1
            // 
            resources.ApplyResources(this.metroLabel1, "metroLabel1");
            this.metroLabel1.Name = "metroLabel1";
            // 
            // cbbRegionRegion
            // 
            this.cbbRegionRegion.DisplayMember = "denominazione_regione";
            this.cbbRegionRegion.FormattingEnabled = true;
            resources.ApplyResources(this.cbbRegionRegion, "cbbRegionRegion");
            this.cbbRegionRegion.Name = "cbbRegionRegion";
            this.cbbRegionRegion.UseSelectable = true;
            this.cbbRegionRegion.ValueMember = "codice_regione";
            // 
            // tpgCounty
            // 
            this.tpgCounty.Controls.Add(this.cbbCountyCounty);
            this.tpgCounty.Controls.Add(this.metroLabel3);
            this.tpgCounty.Controls.Add(this.metroLabel2);
            this.tpgCounty.Controls.Add(this.cbbCountyRegion);
            resources.ApplyResources(this.tpgCounty, "tpgCounty");
            this.tpgCounty.Name = "tpgCounty";
            this.tpgCounty.UseVisualStyleBackColor = true;
            // 
            // metroLabel2
            // 
            resources.ApplyResources(this.metroLabel2, "metroLabel2");
            this.metroLabel2.Name = "metroLabel2";
            // 
            // cbbCountyRegion
            // 
            this.cbbCountyRegion.DisplayMember = "denominazione_regione";
            this.cbbCountyRegion.FormattingEnabled = true;
            resources.ApplyResources(this.cbbCountyRegion, "cbbCountyRegion");
            this.cbbCountyRegion.Name = "cbbCountyRegion";
            this.cbbCountyRegion.UseSelectable = true;
            this.cbbCountyRegion.ValueMember = "codice_regione";
            this.cbbCountyRegion.SelectedIndexChanged += new System.EventHandler(this.cbbCountyRegion_SelectedIndexChanged);
            // 
            // metroLabel3
            // 
            resources.ApplyResources(this.metroLabel3, "metroLabel3");
            this.metroLabel3.Name = "metroLabel3";
            // 
            // cbbCountyCounty
            // 
            this.cbbCountyCounty.DisplayMember = "denominazione_provincia";
            this.cbbCountyCounty.FormattingEnabled = true;
            resources.ApplyResources(this.cbbCountyCounty, "cbbCountyCounty");
            this.cbbCountyCounty.Name = "cbbCountyCounty";
            this.cbbCountyCounty.UseSelectable = true;
            this.cbbCountyCounty.ValueMember = "codice_provincia";
            // 
            // tpgCharts
            // 
            resources.ApplyResources(this.tpgCharts, "tpgCharts");
            this.tpgCharts.Name = "tpgCharts";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbbRegionRegion);
            this.panel1.Controls.Add(this.metroLabel1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.elementHost1);
            // 
            // elementHost1
            // 
            resources.ApplyResources(this.elementHost1, "elementHost1");
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Child = this.cartesianChart1;
            // 
            // mainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSettings);
            this.Name = "mainForm";
            this.metroTabControl1.ResumeLayout(false);
            this.tpgRegions.ResumeLayout(false);
            this.tpgCounty.ResumeLayout(false);
            this.tpgCounty.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLink btnSettings;
        private MetroFramework.Controls.MetroLink btnRefresh;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tpgRegions;
        private System.Windows.Forms.TabPage tpgCounty;
        private MetroFramework.Controls.MetroComboBox cbbRegionRegion;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox cbbCountyRegion;
        private MetroFramework.Controls.MetroComboBox cbbCountyCounty;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tpgCharts;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart cartesianChart1;
    }
}

