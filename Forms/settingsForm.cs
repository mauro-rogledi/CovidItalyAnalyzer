using CovidItalyAnalyzer.Library;

using MetroFramework.Forms;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CovidItalyAnalyzer.Forms
{
    public partial class SettingsForm : MetroForm
    {
        public SettingsForm()
        {
            InitializeComponent();
            ReadDataFromSettings();
            EnableControls();
        }

        private void EnableControls()
        {
            txtUsername.Enabled = cbbUseGitHub.Checked;
            txtPassword.Enabled = cbbUseGitHub.Checked;
            txtEmail.Enabled = cbbUseGitHub.Checked;
        }

        private void ReadDataFromSettings()
        {
            txtFolder.Text = SettingManager.FolderData;
            cbbUseGitHub.Checked = SettingManager.UseGitHub;
            txtUsername.Text = SettingManager.UserName;
            txtPassword.Text = SettingManager.Password;
            txtEmail.Text = SettingManager.Email;
        }


        private void btnFolder_Click(object sender, EventArgs e)
        {
            if (fbdFolder.ShowDialog() == DialogResult.OK)
                txtFolder.Text = fbdFolder.SelectedPath;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SettingManager.FolderData = txtFolder.Text;
            SettingManager.UseGitHub = cbbUseGitHub.Checked;
            SettingManager.UserName = txtUsername.Text;
            SettingManager.Password = txtPassword.Text;
            SettingManager.Email = txtEmail.Text;

            SettingManager.SaveData();
            this.Close();
        }

        private void cbbUseGitHub_CheckedChanged(object sender, EventArgs e)
        {
            EnableControls();
        }
    }
}
