using CovidItalyAnalyzer.Library;

using MetroFramework.Controls;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidItalyAnalyzer.Controls
{
    public partial class CartesianChartRegionControl : MetroUserControl
    {
        CartesianChartRegionManager chartManager;
        public CartesianChartRegionControl()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            InitializeChart();
        }

        private void InitializeChart()
        {
            var regions = DataReaderRegion.ReadRegions()
                .Select(r => new ComboData() { value = r.codice_regione, display = r.denominazione_regione }).ToArray();

            cbbRegion.Items.AddRange(regions);
            chartManager = new CartesianChartRegionManager(cartesianChart);
            cbbChart.Items.AddRange(chartManager.GetChartAvailable());
        }

        private void cbbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbbRegion.SelectedItem as ComboData;
            var chart = cbbChart.Text;
            if (selected != null && chart != "")
                chartManager.SetChart(chart, selected.value, selected.display);
        }
    }
}
