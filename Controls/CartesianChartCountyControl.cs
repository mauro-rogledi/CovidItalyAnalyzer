using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using CovidItalyAnalyzer.Library;

namespace CovidItalyAnalyzer.Controls
{
    public partial class CartesianChartCountyControl : MetroUserControl
    {
        CartesianChartCountyManager chartManager;
        public CartesianChartCountyControl()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            if (DataReaderRegion.HasReadData)
                InitializeChart();
        }

        private void InitializeChart()
        {
            var regions = DataReaderRegion.ReadRegions()
                .Select(r => new ComboData() { value = r.codice_regione, display = r.denominazione_regione }).ToArray();

            cbbRegion.Items.AddRange(regions);
            chartManager = new CartesianChartCountyManager(cartesianChart);
            cbbChart.Items.AddRange(chartManager.GetChartAvailable());
        }

        private void cbbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbCounty.Items.Clear();
            var selected = cbbRegion.SelectedItem as ComboData;
            var county = DataReaderCounty.ReadCounties(selected?.value ?? 0)
                .Select(r => new ComboData() { value = r.codice_provincia, display = r.denominazione_provincia }).ToArray();
            cbbCounty.Items.AddRange(county);

            RefreshChart();
        }

        private void cbbChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }

        void RefreshChart()
        {
            var regionSelected = cbbRegion.SelectedItem as ComboData;
            var countySelected = cbbCounty.SelectedItem as ComboData;
            var chart = cbbChart.Text;
            if (regionSelected != null && countySelected != null && chart != "")
                chartManager.SetChart(chart, regionSelected.value, countySelected.value, countySelected.display);
        }
    }
}
