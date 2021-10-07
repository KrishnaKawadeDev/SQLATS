using System.Data;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Idera.SqlAdminToolset.PatchAnalyzer
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
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Idera_SqlAdminToolset_PatchAnalyzer_PatchAnalyzer_ReportData", m_dataSet.Tables[0]));
            
            //set the parameters
            ReportParameter[] reportParams = new ReportParameter[19];
            reportParams[0] = new ReportParameter("Total", Form_Main.Total);
            reportParams[1] = new ReportParameter("Supported", Form_Main.Supported);
            reportParams[2] = new ReportParameter("Unsupported", Form_Main.Unsupported);
            
            reportParams[3] = new ReportParameter("SQL1", Form_Main.SQL1);
            reportParams[4] = new ReportParameter("Sql2", Form_Main.Sql2);
            reportParams[5] = new ReportParameter("Sql3", Form_Main.Sql3);
            reportParams[6] = new ReportParameter("Sql4", Form_Main.Sql4);
            reportParams[7] = new ReportParameter("Sql5", Form_Main.Sql5);
            reportParams[8] = new ReportParameter("Sql6", Form_Main.Sql6);
            reportParams[9] = new ReportParameter("Sql7", Form_Main.Sql7);
            reportParams[10] = new ReportParameter("Sql8", Form_Main.Sql8);
            reportParams[11] = new ReportParameter("Sql1lbl", Form_Main.sql1labl);
            reportParams[12] = new ReportParameter("Sql2lbl", Form_Main.sql2labl);
            reportParams[13] = new ReportParameter("Sql3lbl", Form_Main.sql3labl);
            reportParams[14] = new ReportParameter("Sql4lbl", Form_Main.sql4labl);
            reportParams[15] = new ReportParameter("Sql5lbl", Form_Main.sql5labl);
            reportParams[16] = new ReportParameter("Sql6lbl", Form_Main.sql6labl);
            reportParams[17] = new ReportParameter("Sql7lbl", Form_Main.sql7labl);
            reportParams[18] = new ReportParameter("Sql8lbl", Form_Main.sql8labl);
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