using CovidItalyAnalyzer.Library;

using MetroFramework.Controls;

using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace CovidItalyAnalyzer.Controls
{
    public partial class CartesianChartRegionControl : MetroUserControl
    {
        private CartesianChartRegionManager chartManager;

        public CartesianChartRegionControl()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;
        }

        private void cbbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }

        internal void InitializeControls()
        {
            InitializeCombo();

            chartManager = new CartesianChartRegionManager(cartesianChart)
            {
                Region = () => cbbChart.SelectedItem as ComboData
            };
            cbbChart.Items.AddRange(chartManager.GetChartAvailable());
        }

        public void InitializeCombo()
        {
            cbbRegion.Items.AddRange(
                    DataReaderRegion.ReadRegions()
                        .Select(r => new ComboData() { value = r.codice_regione, display = r.denominazione_regione })
                        .ToArray()
                    );
        }

        private void RefreshChart()
        {
            if (cbbRegion.SelectedItem is ComboData selected && !cbbChart.Text.IsEmpty())
                chartManager.SetChart(cbbChart.Text, selected.value, selected.display);
        }

        internal void RefreshData()
        {
            RefreshChart();
        }
    }
}