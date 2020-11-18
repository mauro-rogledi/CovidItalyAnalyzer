using CovidItalyAnalyzer.Library;

using MetroFramework.Controls;

using System;
using System.ComponentModel;
using System.Linq;

namespace CovidItalyAnalyzer.Controls
{
    public partial class PieChartControl : MetroUserControl
    {
        private PieChartItalyManager chartManager;

        public PieChartControl()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;
        }

        public void InitializeControl()
        {
            int numRegion = DataReaderRegion.ReadRegions().Count();
            cbbTop.DataSource = new ComboData[]
                {
                new ComboData() { display="5", value=5},
                new ComboData() { display="10", value=10},
                new ComboData() { display="15", value=15},
                new ComboData() { display="all", value=numRegion}
            }; ;

            chartManager = new PieChartItalyManager(pieChart)
            {
                FromDate = () => dttFrom.Value,
                ToDate = () => dttTo.Value,
                Top = () => cbbTop.SelectedItem as ComboData
            };

            var charts = chartManager.GetChartAvailable();
            cbbChart.Items.AddRange(charts);
        }

        private void dttFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dttTo.Value < dttFrom.Value)
                dttTo.Value = dttFrom.Value;

            RefreshChart();
        }
        private void dttTo_ValueChanged(object sender, EventArgs e)
        {
            if (dttFrom.Value > dttTo.Value)
                dttFrom.Value = dttTo.Value;

            RefreshChart();
        }

        internal void RefreshData()
        {
            RefreshChart();
        }

        private void RefreshChart()
        {
            chartManager?.SetChart(cbbChart.Text);
            mtlTitle.Text = chartManager?.Title;
        }

        private void cbbChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }

        private void cbbTop_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }


    }
}