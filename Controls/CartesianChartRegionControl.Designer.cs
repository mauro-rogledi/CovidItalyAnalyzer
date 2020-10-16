namespace CovidItalyAnalyzer.Controls
{
    partial class CartesianChartRegionControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartesianChartRegionControl));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.cbbChart = new MetroFramework.Controls.MetroComboBox();
            this.lblRegionChartUp = new MetroFramework.Controls.MetroLabel();
            this.cbbRegion = new MetroFramework.Controls.MetroComboBox();
            this.lblRegionRegion = new MetroFramework.Controls.MetroLabel();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChart = new LiveCharts.Wpf.CartesianChart();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            resources.ApplyResources(this.metroPanel1, "metroPanel1");
            this.metroPanel1.Controls.Add(this.cbbChart);
            this.metroPanel1.Controls.Add(this.lblRegionChartUp);
            this.metroPanel1.Controls.Add(this.cbbRegion);
            this.metroPanel1.Controls.Add(this.lblRegionRegion);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // cbbChart
            // 
            resources.ApplyResources(this.cbbChart, "cbbChart");
            this.cbbChart.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbbChart.FormattingEnabled = true;
            this.cbbChart.Name = "cbbChart";
            this.cbbChart.UseCustomBackColor = true;
            this.cbbChart.UseCustomForeColor = true;
            this.cbbChart.UseSelectable = true;
            this.cbbChart.UseStyleColors = true;
            this.cbbChart.SelectedIndexChanged += new System.EventHandler(this.cbbRegion_SelectedIndexChanged);
            // 
            // lblRegionChartUp
            // 
            resources.ApplyResources(this.lblRegionChartUp, "lblRegionChartUp");
            this.lblRegionChartUp.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblRegionChartUp.Name = "lblRegionChartUp";
            this.lblRegionChartUp.UseCustomBackColor = true;
            this.lblRegionChartUp.UseCustomForeColor = true;
            this.lblRegionChartUp.UseStyleColors = true;
            // 
            // cbbRegion
            // 
            resources.ApplyResources(this.cbbRegion, "cbbRegion");
            this.cbbRegion.DisplayMember = "display";
            this.cbbRegion.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbbRegion.FormattingEnabled = true;
            this.cbbRegion.Name = "cbbRegion";
            this.cbbRegion.UseCustomBackColor = true;
            this.cbbRegion.UseCustomForeColor = true;
            this.cbbRegion.UseSelectable = true;
            this.cbbRegion.UseStyleColors = true;
            this.cbbRegion.ValueMember = "value";
            this.cbbRegion.SelectedIndexChanged += new System.EventHandler(this.cbbRegion_SelectedIndexChanged);
            // 
            // lblRegionRegion
            // 
            resources.ApplyResources(this.lblRegionRegion, "lblRegionRegion");
            this.lblRegionRegion.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblRegionRegion.Name = "lblRegionRegion";
            this.lblRegionRegion.UseCustomBackColor = true;
            this.lblRegionRegion.UseCustomForeColor = true;
            this.lblRegionRegion.UseStyleColors = true;
            // 
            // elementHost1
            // 
            resources.ApplyResources(this.elementHost1, "elementHost1");
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Child = this.cartesianChart;
            // 
            // CartesianChartRegionControl
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.metroPanel1);
            this.Name = "CartesianChartRegionControl";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroComboBox cbbChart;
        private MetroFramework.Controls.MetroLabel lblRegionChartUp;
        private MetroFramework.Controls.MetroComboBox cbbRegion;
        private MetroFramework.Controls.MetroLabel lblRegionRegion;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart cartesianChart;
    }
}
