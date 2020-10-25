using CovidItalyAnalyzer.Library;

using MetroFramework.Forms;

using System;
using System.IO;
using System.Linq;

namespace CovidItalyAnalyzer.Forms
{
    public partial class mainForm : MetroForm
    {
        public mainForm()
        {
            SettingManager.ReadData();
            if (SettingManager.FolderData != "")
            {
                DataReaderRegion.ReadData(SettingManager.FolderData);
                DataReaderCounty.ReadData(SettingManager.FolderData);

            }
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var setForm = new settingsForm();
            setForm.ShowDialog(this);
        }

        private async void bntRefresh_Click(object sender, EventArgs e)
        {
            if (SettingManager.FolderData == "")
                return;

            btnRefresh.Enabled = false;

            (bool result, string message) gitResult;

            lblStatus.Text = Properties.Resources.DownloadingData;
            if (Directory.Exists(Path.Combine(SettingManager.FolderData, "dati-json")))
                gitResult = await GitManager.GitPull();
            else
                gitResult = await GitManager.GitClone();

            lblStatus.Text.Clear();

            if (gitResult.result)
            {
                DataReaderRegion.ReadData(SettingManager.FolderData);
                DataReaderCounty.ReadData(SettingManager.FolderData);

                pieControl1.RefreshData();
                pieControl2.RefreshData();
                pieControl3.RefreshData();
                pieControl4.RefreshData();
                cartesianChartRegionControl1.RefreshData();
                cartesianChartRegionControl2.RefreshData();
                cartesianChartCountyControl1.RefreshData();
                cartesianChartCountyControl2.RefreshData();

                regionDataControl1.RefreshData();
                
                lblStatus.Text.Clear();
            }
            else
                lblStatus.Text = gitResult.message;

            btnRefresh.Enabled = true;
        }
    }
}