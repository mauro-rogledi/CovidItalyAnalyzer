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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tpgItaly = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tpgRegions = new System.Windows.Forms.TabPage();
            this.tpgCounty = new System.Windows.Forms.TabPage();
            this.spcCounty = new System.Windows.Forms.SplitContainer();
            this.btnRefresh = new MetroFramework.Controls.MetroLink();
            this.btnSettings = new MetroFramework.Controls.MetroLink();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pieControl1 = new CovidItalyAnalyzer.Controls.PieChartControl();
            this.pieControl3 = new CovidItalyAnalyzer.Controls.PieChartControl();
            this.pieControl2 = new CovidItalyAnalyzer.Controls.PieChartControl();
            this.spcRegion = new System.Windows.Forms.SplitContainer();
            this.cartesianChartRegionControl1 = new CovidItalyAnalyzer.Controls.CartesianChartRegionControl();
            this.cartesianChartRegionControl2 = new CovidItalyAnalyzer.Controls.CartesianChartRegionControl();
            this.cartesianChartCountyControl1 = new CovidItalyAnalyzer.Controls.CartesianChartCountyControl();
            this.cartesianChartCountyControl2 = new CovidItalyAnalyzer.Controls.CartesianChartCountyControl();
            this.metroTabControl1.SuspendLayout();
            this.tpgItaly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tpgRegions.SuspendLayout();
            this.tpgCounty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcCounty)).BeginInit();
            this.spcCounty.Panel1.SuspendLayout();
            this.spcCounty.Panel2.SuspendLayout();
            this.spcCounty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcRegion)).BeginInit();
            this.spcRegion.Panel1.SuspendLayout();
            this.spcRegion.Panel2.SuspendLayout();
            this.spcRegion.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            resources.ApplyResources(this.metroTabControl1, "metroTabControl1");
            this.metroTabControl1.Controls.Add(this.tpgItaly);
            this.metroTabControl1.Controls.Add(this.tpgRegions);
            this.metroTabControl1.Controls.Add(this.tpgCounty);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // tpgItaly
            // 
            resources.ApplyResources(this.tpgItaly, "tpgItaly");
            this.tpgItaly.Controls.Add(this.splitContainer1);
            this.tpgItaly.Name = "tpgItaly";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            resources.ApplyResources(this.splitContainer3.Panel1, "splitContainer3.Panel1");
            this.splitContainer3.Panel1.Controls.Add(this.pieControl2);
            // 
            // splitContainer3.Panel2
            // 
            resources.ApplyResources(this.splitContainer3.Panel2, "splitContainer3.Panel2");
            // 
            // tpgRegions
            // 
            resources.ApplyResources(this.tpgRegions, "tpgRegions");
            this.tpgRegions.Controls.Add(this.spcRegion);
            this.tpgRegions.Name = "tpgRegions";
            this.tpgRegions.UseVisualStyleBackColor = true;
            // 
            // tpgCounty
            // 
            resources.ApplyResources(this.tpgCounty, "tpgCounty");
            this.tpgCounty.Controls.Add(this.spcCounty);
            this.tpgCounty.Name = "tpgCounty";
            this.tpgCounty.UseVisualStyleBackColor = true;
            // 
            // spcCounty
            // 
            resources.ApplyResources(this.spcCounty, "spcCounty");
            this.spcCounty.Name = "spcCounty";
            // 
            // spcCounty.Panel1
            // 
            resources.ApplyResources(this.spcCounty.Panel1, "spcCounty.Panel1");
            this.spcCounty.Panel1.Controls.Add(this.cartesianChartCountyControl1);
            // 
            // spcCounty.Panel2
            // 
            resources.ApplyResources(this.spcCounty.Panel2, "spcCounty.Panel2");
            this.spcCounty.Panel2.Controls.Add(this.cartesianChartCountyControl2);
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
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this.pieControl1);
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.pieControl3);
            // 
            // pieControl1
            // 
            resources.ApplyResources(this.pieControl1, "pieControl1");
            this.pieControl1.Name = "pieControl1";
            this.pieControl1.UseSelectable = true;
            // 
            // pieControl3
            // 
            resources.ApplyResources(this.pieControl3, "pieControl3");
            this.pieControl3.Name = "pieControl3";
            this.pieControl3.UseSelectable = true;
            // 
            // pieControl2
            // 
            resources.ApplyResources(this.pieControl2, "pieControl2");
            this.pieControl2.Name = "pieControl2";
            this.pieControl2.UseSelectable = true;
            // 
            // spcRegion
            // 
            resources.ApplyResources(this.spcRegion, "spcRegion");
            this.spcRegion.Name = "spcRegion";
            // 
            // spcRegion.Panel1
            // 
            resources.ApplyResources(this.spcRegion.Panel1, "spcRegion.Panel1");
            this.spcRegion.Panel1.Controls.Add(this.cartesianChartRegionControl1);
            // 
            // spcRegion.Panel2
            // 
            resources.ApplyResources(this.spcRegion.Panel2, "spcRegion.Panel2");
            this.spcRegion.Panel2.Controls.Add(this.cartesianChartRegionControl2);
            // 
            // cartesianChartRegionControl1
            // 
            resources.ApplyResources(this.cartesianChartRegionControl1, "cartesianChartRegionControl1");
            this.cartesianChartRegionControl1.Name = "cartesianChartRegionControl1";
            this.cartesianChartRegionControl1.UseSelectable = true;
            // 
            // cartesianChartRegionControl2
            // 
            resources.ApplyResources(this.cartesianChartRegionControl2, "cartesianChartRegionControl2");
            this.cartesianChartRegionControl2.Name = "cartesianChartRegionControl2";
            this.cartesianChartRegionControl2.UseSelectable = true;
            // 
            // cartesianChartCountyControl1
            // 
            resources.ApplyResources(this.cartesianChartCountyControl1, "cartesianChartCountyControl1");
            this.cartesianChartCountyControl1.Name = "cartesianChartCountyControl1";
            this.cartesianChartCountyControl1.UseSelectable = true;
            // 
            // cartesianChartCountyControl2
            // 
            resources.ApplyResources(this.cartesianChartCountyControl2, "cartesianChartCountyControl2");
            this.cartesianChartCountyControl2.Name = "cartesianChartCountyControl2";
            this.cartesianChartCountyControl2.UseSelectable = true;
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
            this.tpgItaly.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tpgRegions.ResumeLayout(false);
            this.tpgCounty.ResumeLayout(false);
            this.spcCounty.Panel1.ResumeLayout(false);
            this.spcCounty.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcCounty)).EndInit();
            this.spcCounty.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.spcRegion.Panel1.ResumeLayout(false);
            this.spcRegion.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcRegion)).EndInit();
            this.spcRegion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLink btnSettings;
        private MetroFramework.Controls.MetroLink btnRefresh;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private System.Windows.Forms.TabPage tpgRegions;
        private System.Windows.Forms.TabPage tpgCounty;
        private System.Windows.Forms.TabPage tpgItaly;
        private System.Windows.Forms.SplitContainer spcRegion;
        private System.Windows.Forms.SplitContainer spcCounty;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Controls.PieChartControl pieControl1;
        private Controls.PieChartControl pieControl2;
        private Controls.PieChartControl pieControl3;
        private Controls.CartesianChartRegionControl cartesianChartRegionControl1;
        private Controls.CartesianChartCountyControl cartesianChartCountyControl1;
        private Controls.CartesianChartCountyControl cartesianChartCountyControl2;
        private Controls.CartesianChartRegionControl cartesianChartRegionControl2;
    }
}

