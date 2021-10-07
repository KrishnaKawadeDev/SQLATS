using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Idera.SqlAdminToolset.PasswordChecker
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
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Idera_SqlAdminToolset_PasswordChecker_PasswordChecker_ReportData", m_dataSet.Tables[0]));

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