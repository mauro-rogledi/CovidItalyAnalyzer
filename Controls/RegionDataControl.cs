using CovidItalyAnalyzer.Library;

using MetroFramework.Controls;

using System;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace CovidItalyAnalyzer.Controls
{
    public partial class RegionDataControl : MetroUserControl
    {
        public RegionDataControl()
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
            if (cbbRegion.SelectedItem is ComboData selected)
                dgwRegionData.DataSource = DataReaderRegion.ReadRegionData(selected.value).ToList();
        }

        private void cbbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChart();
        }
    }
}