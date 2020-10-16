using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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

            if (Directory.GetDirectories(SettingManager.FolderData).Count() == 0)
                GitManager.GitClone();
            else
                GitManager.GitPull();
        }
    }


}
