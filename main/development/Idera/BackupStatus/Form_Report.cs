using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Idera.SqlAdminToolset.BackupStatus
{
    public partial class Form_Report : Form
    {
        //dataset for the data
        private readonly DataSet m_dataSet;

        #region Ctor

        public Form_Report(DataSet dataSet)
        {
            InitializeComponent();

            m_dataSet = dataSet;
        }

        #endregion

        /// <summary>
        /// Sets the data source at runtime.  Layout is handled in the rendering complete handler.
        /// </summary>
        private void Form_Report_Load(object sender, System.EventArgs e)
        {
            //get the data and attach it to the main report
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Idera_SqlAdminToolset_BackupStatus_BackupStatus_ReportData", m_dataSet.Tables[0]));
            
            //set the parameters
            ReportParameter[] reportParams = new ReportParameter[9];
            reportParams[0] = new ReportParameter("OverallStatus", Form_Main.OverallStatus);
            reportParams[1] = new ReportParameter("OverallStatusPic", Form_Main.OverallStatusPic.ToString());
            reportParams[2] = new ReportParameter("ServersNeedingBackup", Form_Main.ServersNeedingBackup);
            reportParams[3] = new ReportParameter("NeverBackedUp", Form_Main.NeverBackedUp);
            reportParams[4] = new ReportParameter("NoRecentBackup", Form_Main.NoRecentBackup);
            reportParams[5] = new ReportParameter("Total", Form_Main.Total);
            reportParams[6] = new ReportParameter("NewDatabases", Form_Main.NewDatabases);
            reportParams[7] = new ReportParameter("ServersScanned", Form_Main.ServersScanned);
            reportParams[8] = new ReportParameter("ShowOnlyFullBackups", Form_Main.ShowOnlyFullBackups);

            reportViewer1.LocalReport.SetParameters(reportParams);

            reportViewer1.RefreshReport();
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

        /// <summary>
        /// This is added to fix a possible threading exception if the user closes the form while the 
        /// report is rendering.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Report_FormClosed(object sender, FormClosedEventArgs e)
        {
            reportViewer1.Reset();
        }
    }
}