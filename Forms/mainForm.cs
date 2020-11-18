using CovidItalyAnalyzer.Library;

using MetroFramework.Forms;

using System;
using System.IO;
using System.Linq;

namespace CovidItalyAnalyzer.Forms
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            SettingManager.ReadData();
            InitializeComponent();

            if (DataReader.ReadData())
                InitializeControls();

            btnRefresh.Enabled = true; // SettingManager.UseGitHub;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            new SettingsForm()
                .ShowDialog();

            btnRefresh.Enabled = !SettingManager.FolderData.IsEmpty();
        }

        private async void bntRefresh_Click(object sender, EventArgs e)
        {
            btnRefresh.Enabled = false;
            lblStatus.Text = Properties.Resources.DownloadingData;

            var (fromClone, message) = await DataReader.RefreshData();

            lblStatus.Text = message;
            btnRefresh.Enabled = true;

            if (fromClone)
                InitializeControls();

            RefreshCharts();
        }

        private void RefreshCharts()
        {
            pieControl1.RefreshData();
            pieControl2.RefreshData();
            pieControl3.RefreshData();
            pieControl4.RefreshData();
            cartesianChartRegionControl1.RefreshData();
            cartesianChartRegionControl2.RefreshData();
            cartesianChartCountyControl1.RefreshData();
            cartesianChartCountyControl2.RefreshData();

            regionDataControl1.InitializeCombo();
            countyDataControl1.InitializeCombo();
        }

        private void InitializeControls()
        {
            pieControl1.InitializeControl();
            pieControl2.InitializeControl();
            pieControl3.InitializeControl();
            pieControl4.InitializeControl();
            cartesianChartRegionControl1.InitializeControls();
            cartesianChartRegionControl2.InitializeControls();
            cartesianChartCountyControl1.InitializeControls();
            cartesianChartCountyControl2.InitializeControls();

            regionDataControl1.InitializeControls();
            countyDataControl1.InitializeControls();
        }
    }
}