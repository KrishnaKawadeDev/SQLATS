namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
    partial class Form_Report
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
           Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
           this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
           this.SuspendLayout();
           // 
           // reportViewer1
           // 
           this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
           this.reportViewer1.DocumentMapCollapsed = true;
           reportDataSource1.Name = "Idera_SqlAdminToolset_DatabaseConfiguration_DatabaseConfiguration_ReportData";
           reportDataSource1.Value = null;
           this.reportViewer1.LocalReport.DataSources.Add( reportDataSource1 );
           this.reportViewer1.LocalReport.EnableHyperlinks = true;
           this.reportViewer1.LocalReport.ReportEmbeddedResource = "Idera.SqlAdminToolset.DatabaseConfiguration.DatabaseConfiguration_Report.rdlc";
           this.reportViewer1.Location = new System.Drawing.Point( 0, 0 );
           this.reportViewer1.Name = "reportViewer1";
           this.reportViewer1.ShowContextMenu = false;
           this.reportViewer1.ShowCredentialPrompts = false;
           this.reportViewer1.ShowDocumentMapButton = false;
           this.reportViewer1.ShowParameterPrompts = false;
           this.reportViewer1.ShowPromptAreaButton = false;
           this.reportViewer1.Size = new System.Drawing.Size( 859, 464 );
           this.reportViewer1.TabIndex = 14;
           this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler( this.reportViewer1_RenderingComplete );
           // 
           // Form_Report
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size( 859, 464 );
           this.Controls.Add( this.reportViewer1 );
           this.Name = "Form_Report";
           this.ShowIcon = false;
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Database Configuration Report";
           this.Load += new System.EventHandler( this.Form_Report_Load );
           this.FormClosed += new System.Windows.Forms.FormClosedEventHandler( this.Form_Report_FormClosed );
           this.ResumeLayout( false );

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}