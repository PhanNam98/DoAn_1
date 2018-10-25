namespace GalaxyMobile
{
    partial class frmInHoaDon
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportInHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InHoaDon_ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InHoaDon_ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportInHD
            // 
            this.reportInHD.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "PrintBill";
            reportDataSource1.Value = this.InHoaDon_ResultBindingSource;
            this.reportInHD.LocalReport.DataSources.Add(reportDataSource1);
            this.reportInHD.LocalReport.ReportEmbeddedResource = "GalaxyMobile.ReportInHoaDon.rdlc";
            this.reportInHD.Location = new System.Drawing.Point(0, 0);
            this.reportInHD.Name = "reportInHD";
            this.reportInHD.Size = new System.Drawing.Size(819, 633);
            this.reportInHD.TabIndex = 0;
            // 
            // InHoaDon_ResultBindingSource
            // 
            this.InHoaDon_ResultBindingSource.DataSource = typeof(Model.InHoaDon_Result);
            // 
            // frmInHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 633);
            this.Controls.Add(this.reportInHD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmInHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "In Hóa Đơn";
            this.Load += new System.EventHandler(this.frmInHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InHoaDon_ResultBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportInHD;
        private System.Windows.Forms.BindingSource InHoaDon_ResultBindingSource;
    }
}