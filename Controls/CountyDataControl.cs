using CovidItalyAnalyzer.Library;

using MetroFramework.Controls;

using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace CovidItalyAnalyzer.Controls
{
    public partial class CountyDataControl : MetroUserControl
    {
        public CountyDataControl()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;
        }

        internal void InitializeControls()
        {
            InitializeCombo();
        }

        internal void InitializeCombo()
        {
            var regions = DataReaderRegion.ReadRegions()
                .Select(r => new ComboData() { value = r.codice_regione, display = r.denominazione_regione }).ToArray();

            cbbRegion.Items.AddRange(regions);
        }

        private void RefreshChart()
        {
            var regionSelected = cbbRegion.SelectedItem as ComboData;
            var countySelected = cbbCounty.SelectedItem as ComboData;
            if (regionSelected != null && countySelected != null )
                dgwRegionData.DataSource = DataReaderCounty.ReadCountyData(regionSelected.value, countySelected.value).ToList();
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

        private void cbbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }
    }
}