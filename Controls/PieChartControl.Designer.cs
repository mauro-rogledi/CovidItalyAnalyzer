namespace CovidItalyAnalyzer.Controls
{
    partial class PieChartControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PieChartControl));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.mtlTitle = new MetroFramework.Controls.MetroLabel();
            this.cbbTop = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.dttTo = new MetroFramework.Controls.MetroDateTime();
            this.dttFrom = new MetroFramework.Controls.MetroDateTime();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.cbbChart = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.emhChart = new System.Windows.Forms.Integration.ElementHost();
            this.pieChart = new LiveCharts.Wpf.PieChart();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            resources.ApplyResources(this.metroPanel1, "metroPanel1");
            this.metroPanel1.Controls.Add(this.mtlTitle);
            this.metroPanel1.Controls.Add(this.cbbTop);
            this.metroPanel1.Controls.Add(this.metroLabel10);
            this.metroPanel1.Controls.Add(this.metroLabel9);
            this.metroPanel1.Controls.Add(this.dttTo);
            this.metroPanel1.Controls.Add(this.dttFrom);
            this.metroPanel1.Controls.Add(this.metroLabel8);
            this.metroPanel1.Controls.Add(this.cbbChart);
            this.metroPanel1.Controls.Add(this.metroLabel7);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // mtlTitle
            // 
            resources.ApplyResources(this.mtlTitle, "mtlTitle");
            this.mtlTitle.FontSize = MetroFramework.MetroLabelSize.Small;
            this.mtlTitle.Name = "mtlTitle";
            // 
            // cbbTop
            // 
            resources.ApplyResources(this.cbbTop, "cbbTop");
            this.cbbTop.DisplayMember = "display";
            this.cbbTop.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbbTop.FormattingEnabled = true;
            this.cbbTop.Name = "cbbTop";
            this.cbbTop.UseCustomBackColor = true;
            this.cbbTop.UseCustomForeColor = true;
            this.cbbTop.UseSelectable = true;
            this.cbbTop.UseStyleColors = true;
            this.cbbTop.ValueMember = "value";
            this.cbbTop.SelectedIndexChanged += new System.EventHandler(this.cbbTop_SelectedIndexChanged);
            // 
            // metroLabel10
            // 
            resources.ApplyResources(this.metroLabel10, "metroLabel10");
            this.metroLabel10.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.UseCustomForeColor = true;
            this.metroLabel10.UseStyleColors = true;
            // 
            // metroLabel9
            // 
            resources.ApplyResources(this.metroLabel9, "metroLabel9");
            this.metroLabel9.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.UseCustomForeColor = true;
            this.metroLabel9.UseStyleColors = true;
            // 
            // dttTo
            // 
            resources.ApplyResources(this.dttTo, "dttTo");
            this.dttTo.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dttTo.Name = "dttTo";
            this.dttTo.UseCustomBackColor = true;
            this.dttTo.UseCustomForeColor = true;
            this.dttTo.UseStyleColors = true;
            this.dttTo.ValueChanged += new System.EventHandler(this.dttTo_ValueChanged);
            // 
            // dttFrom
            // 
            resources.ApplyResources(this.dttFrom, "dttFrom");
            this.dttFrom.FontSize = MetroFramework.MetroDateTimeSize.Small;
            this.dttFrom.Name = "dttFrom";
            this.dttFrom.UseCustomBackColor = true;
            this.dttFrom.UseCustomForeColor = true;
            this.dttFrom.UseStyleColors = true;
            this.dttFrom.ValueChanged += new System.EventHandler(this.dttFrom_ValueChanged);
            // 
            // metroLabel8
            // 
            resources.ApplyResources(this.metroLabel8, "metroLabel8");
            this.metroLabel8.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.UseCustomForeColor = true;
            this.metroLabel8.UseStyleColors = true;
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
            this.cbbChart.SelectedIndexChanged += new System.EventHandler(this.cbbChart_SelectedIndexChanged);
            // 
            // metroLabel7
            // 
            resources.ApplyResources(this.metroLabel7, "metroLabel7");
            this.metroLabel7.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.UseCustomForeColor = true;
            this.metroLabel7.UseStyleColors = true;
            // 
            // emhChart
            // 
            resources.ApplyResources(this.emhChart, "emhChart");
            this.emhChart.Name = "emhChart";
            this.emhChart.Child = this.pieChart;
            // 
            // PieChartControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.emhChart);
            this.Controls.Add(this.metroPanel1);
            this.Name = "PieChartControl";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Integration.ElementHost emhChart;
        private LiveCharts.Wpf.PieChart pieChart;
        private MetroFramework.Controls.MetroComboBox cbbTop;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroDateTime dttTo;
        private MetroFramework.Controls.MetroDateTime dttFrom;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroComboBox cbbChart;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel mtlTitle;
    }
}
