using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CovidItalyAnalyzer.Library;
using CovidItalyAnalyzer.ModelData;

using MetroFramework.Forms;

namespace CovidItalyAnalyzer.Forms
{
    public partial class mainForm : MetroForm
    {
        public mainForm()
        {
            InitializeComponent();

            SettingManager.ReadData();
            DataReader.ReadData(SettingManager.FolderData);

            cbbRegionRegion.Items.AddRange(DataReader.italyRegions.Select(r => new { r.codice_regione, r.denominazione_regione }).ToArray());
            cbbCountyRegion.Items.AddRange(DataReader.italyRegions.Select(r => new { r.codice_regione, r.denominazione_regione }).ToArray());

            // Configure color schema
            //materialSkinManager.ColorScheme = new ColorScheme(
            //    Primary.Blue400, Primary.Blue500,
            //    Primary.Blue500, Accent.LightBlue200,
            //    TextShade.WHITE
            //);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            var setForm = new settingsForm();
            setForm.ShowDialog(this);
        }

        private void bntRefresh_Click(object sender, EventArgs e)
        {
            DataReader.RefreshDatas();
        }

        private void cbbCountyRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var a = cbbCountyRegion.SelectedItem;
            var b = (int)a.GetType().GetProperty("codice_regione").GetValue(a, null);

            cbbCountyCounty.Items.Clear();
            cbbCountyCounty.Items.AddRange(DataReader.italyCounties
                                            .Where(c => c.codice_regione == b && c.sigla_provincia != null)
                                            .Select(r => new { r.codice_provincia, r.denominazione_provincia }).ToArray());
        }
    }


}
