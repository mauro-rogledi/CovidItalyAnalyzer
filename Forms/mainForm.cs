using CovidItalyAnalyzer.Library;

using MetroFramework.Forms;

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidItalyAnalyzer.Forms
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            SettingManager.ReadData();
            InitializeComponent();


        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await DataReader.ReadData();
            InitializeControls();
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

            await DataReader.RefreshData();

            btnRefresh.Enabled = true;


            await Task.Factory.StartNew(() =>
                {
                    lblStatus.BeginInvoke((Action)(() => 
                    { 
                        lblStatus.Text = Properties.Resources.DownloadedData; ;
                        Application.DoEvents();
                        Thread.Sleep(3000); 
                        lblStatus.Text = ""; }));
                 }
            );
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