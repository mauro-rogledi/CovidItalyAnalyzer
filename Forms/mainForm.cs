using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CovidItalyAnalyzer.Library;
using CovidItalyAnalyzer.ModelData;

using MetroFramework.Forms;

using Newtonsoft.Json;

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

            var swab = DataExtractorRegion.FillDailySwabs(7);
            var cases = DataExtractorRegion.FillDailyCases(7);

            var result = cases.Zip(swab, (c, s) => new { caso = c.value, tamp = s.value, c.data });
            dataGridView1.DataSource = result.ToList();
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
                cartesianChartRegionControl1.RefreshData();
                cartesianChartRegionControl2.RefreshData();
                cartesianChartCountyControl1.RefreshData();
                cartesianChartCountyControl2.RefreshData();
            }
        }
    }
}
