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

        private void bntRefresh_Click(object sender, EventArgs e)
        {
            if (SettingManager.FolderData == "")
                return;

            var hasToRefresh = false;

            if (Directory.GetDirectories(SettingManager.FolderData).Count() == 0)
                hasToRefresh = GitManager.GitClone();
            else
                hasToRefresh = GitManager.GitPull();

            if (hasToRefresh)
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
            }
        }
    }
}