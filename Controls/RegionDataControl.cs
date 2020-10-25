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
    public partial class RegionDataControl : MetroUserControl
    {
        public RegionDataControl()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime || DesignMode)
                return;

            if (DataReaderRegion.HasReadData)
                InitializeControl();
        }

        private void InitializeControl()
        {
            var regions = DataReaderRegion.ReadRegions()
                .Select(r => new ComboData() { value = r.codice_regione, display = r.denominazione_regione }).ToArray();

            cbbRegion.Items.AddRange(regions);
        }

        internal void RefreshData()
        {
            RefreshChart();
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
