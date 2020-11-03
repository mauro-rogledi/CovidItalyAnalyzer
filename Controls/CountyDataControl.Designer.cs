namespace CovidItalyAnalyzer.Controls
{
    partial class CountyDataControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgwRegionData = new System.Windows.Forms.DataGridView();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.cbbRegion = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.cbbCounty = new MetroFramework.Controls.MetroComboBox();
            this.lblCountyRegion = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRegionData)).BeginInit();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgwRegionData
            // 
            this.dgwRegionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwRegionData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgwRegionData.Location = new System.Drawing.Point(0, 36);
            this.dgwRegionData.Name = "dgwRegionData";
            this.dgwRegionData.Size = new System.Drawing.Size(597, 363);
            this.dgwRegionData.TabIndex = 7;
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.cbbCounty);
            this.metroPanel2.Controls.Add(this.lblCountyRegion);
            this.metroPanel2.Controls.Add(this.cbbRegion);
            this.metroPanel2.Controls.Add(this.metroLabel2);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(597, 36);
            this.metroPanel2.TabIndex = 8;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // cbbRegion
            // 
            this.cbbRegion.DisplayMember = "display";
            this.cbbRegion.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbbRegion.FormattingEnabled = true;
            this.cbbRegion.ItemHeight = 19;
            this.cbbRegion.Location = new System.Drawing.Point(77, 5);
            this.cbbRegion.Name = "cbbRegion";
            this.cbbRegion.Size = new System.Drawing.Size(141, 25);
            this.cbbRegion.TabIndex = 7;
            this.cbbRegion.UseCustomBackColor = true;
            this.cbbRegion.UseCustomForeColor = true;
            this.cbbRegion.UseSelectable = true;
            this.cbbRegion.UseStyleColors = true;
            this.cbbRegion.ValueMember = "value";
            this.cbbRegion.SelectedIndexChanged += new System.EventHandler(this.cbbRegion_SelectedIndexChanged);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel2.Location = new System.Drawing.Point(3, 11);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 15);
            this.metroLabel2.TabIndex = 8;
            this.metroLabel2.Text = "Select Region";
            this.metroLabel2.UseCustomBackColor = true;
            this.metroLabel2.UseCustomForeColor = true;
            this.metroLabel2.UseStyleColors = true;
            // 
            // cbbCounty
            // 
            this.cbbCounty.DisplayMember = "display";
            this.cbbCounty.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.cbbCounty.FormattingEnabled = true;
            this.cbbCounty.ItemHeight = 19;
            this.cbbCounty.Location = new System.Drawing.Point(304, 6);
            this.cbbCounty.Name = "cbbCounty";
            this.cbbCounty.Size = new System.Drawing.Size(184, 25);
            this.cbbCounty.TabIndex = 40;
            this.cbbCounty.UseSelectable = true;
            this.cbbCounty.UseStyleColors = true;
            this.cbbCounty.ValueMember = "value";
            this.cbbCounty.SelectedIndexChanged += new System.EventHandler(this.cbbCounty_SelectedIndexChanged);
            // 
            // lblCountyRegion
            // 
            this.lblCountyRegion.AutoSize = true;
            this.lblCountyRegion.FontSize = MetroFramework.MetroLabelSize.Small;
            this.lblCountyRegion.Location = new System.Drawing.Point(224, 11);
            this.lblCountyRegion.Name = "lblCountyRegion";
            this.lblCountyRegion.Size = new System.Drawing.Size(74, 15);
            this.lblCountyRegion.TabIndex = 39;
            this.lblCountyRegion.Text = "Select County";
            this.lblCountyRegion.UseStyleColors = true;
            // 
            // CountyDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgwRegionData);
            this.Controls.Add(this.metroPanel2);
            this.Name = "CountyDataControl";
            this.Size = new System.Drawing.Size(597, 399);
            ((System.ComponentModel.ISupportInitialize)(this.dgwRegionData)).EndInit();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwRegionData;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroComboBox cbbRegion;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox cbbCounty;
        private MetroFramework.Controls.MetroLabel lblCountyRegion;
    }
}
