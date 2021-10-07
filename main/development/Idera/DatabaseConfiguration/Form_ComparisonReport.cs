using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
    public partial class Form_ComparisonReport : Form
    {
        List<DatabaseConfiguration_ReportData> _ReportData;
        public Form_ComparisonReport(List<DatabaseConfiguration_ReportData> data)
        {
            _ReportData = data;
            InitializeComponent();
        }

        private void Form_ComparisonReport_Load(object sender, EventArgs e)
        {
            this.DatabaseConfiguration_ReportDataBindingSource.DataSource = _ReportData;
            this.reportViewer1.RefreshReport();
        }

        /// <summary>
        /// Event to layout the report after the rendering is complete in print mode since this app 
        /// triggers viewing the report for the purpose of printing it.  We do it after the rendering is 
        /// complete to address any pagination issues.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            reportViewer1.SuspendLayout();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;

            reportViewer1.ResumeLayout();
        }
    }
}