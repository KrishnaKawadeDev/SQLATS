using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Reporting.WinForms;

namespace Idera.SqlAdminToolset.InventoryReport
{
    public partial class Form_Report : Form
    {
        //list for the inventory data
        private readonly List<InventoryData> m_list;

        #region Ctor

        public Form_Report(List<InventoryData> list)
        {
            InitializeComponent();

            m_list = list;

            reportViewer1.LocalReport.SubreportProcessing += SubreportProcessingEventHandler;
        
            //load the report
            RunReport();
        }

        #endregion

        /// <summary>
        /// Sets the data source at runtime.  Layout is handled in the rendering complete handler.
        /// </summary>
        private void RunReport()
        {
            //get the data and attach it to the main report
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("InventoryData_ReportData_Server", GetData(m_list).Tables[0]));

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
        /// Gets the data from the inventory data list by first converting it to XML, then 
        /// streaming the XML into a dataset.  This is mainly so that we don't have to handle 
        /// the data ourselves- we can just use the existing XML methods.
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static DataSet GetData(List<InventoryData> list)
        {
            //create the dataset from the xml
            XmlDocument xmldoc = InventoryHelper.ConvertInventoryDataToXml(list);

            //is it empty?
            if (xmldoc == null) return null;

            StringReader stream = new StringReader(xmldoc.InnerXml.Normalize());

            DataSet dataSet = new DataSet();
            dataSet.ReadXml(stream);

            return dataSet;
        }

        /// <summary>
        /// Links the data to the subreport at runtime.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            if (m_list.Count == 0) return;

            //get the data and attach it to the subreport
            e.DataSources.Add(new ReportDataSource("InventoryData_ReportData_InventoryItem", GetData(m_list).Tables[1]));
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