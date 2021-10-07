using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using System.Data.SqlClient;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;

using Idera.SqlAdminToolset.Core;
using Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs;

using BBS.TracerX;
using IderaTrialExperienceCommon.Common;
using System.Xml;
using DevComponents.DotNetBar.Controls;

namespace Idera.SqlAdminToolset.JobEditor
{
    public partial class Form_Main : Form
    {
        #region fields

        Logger logger;

        // JobPool processing
        private JobPool<JobPoolResults> _JobPool;
        private ToolProgressBarDialog _ProgressDialog;
        private static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();

        // retrieval
        private JobCounts m_AllJobCounts;
        private Dictionary<string, JobInfoResults> m_AllJobResults;
        private DataTable m_JobList;

        // selection
        private DataTable m_jobSelectedList;
        private JobSelections m_jobSelections = new JobSelections();

        // updating
        private DataTable m_jobUpdateList;
        private JobUpdateValues m_jobUpdateValues;
        private List<JobUpdateResults> m_jobUpdateResults;

        //// local processing
        private bool m_init = false;
        private DataRow m_currentItem = null;
        private string folder = string.Empty;

        #endregion

        #region constructors

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            logger = CoreGlobals.traceLog;

            numericUpDown1.Value = 14;

            comboBoxjobdayhour.Text = "day(s)";


            m_AllJobCounts = new JobCounts();
            m_AllJobResults = new Dictionary<string, JobInfoResults>();
            m_JobList = JobData.JobList.CreateTable();

            //labelSubtitle.Text = ProductConstants.productDescription;
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                var parms = base.CreateParams;
                parms.Style &= ~0x00C00000; // remove WS_CAPTION
                parms.Style |= 0x00040000;  // include WS_SIZEBOX
                return parms;
            }
        }

        #endregion

        #region properties

        #endregion

        #region methods

        #region Progress Bar

        public void ProgressBar_Show()
        {
            if (_ProgressDialog != null)
            {
                _ProgressDialog.ShowDialog(this);
            }
        }

        public void ProgressBar_Close()
        {
            if (_ProgressDialog != null)
            {
                _ProgressDialog.TopLevel = false;
                _ProgressDialog.Visible = false;
                _ProgressDialog.Close();
                _ProgressDialog = null;
            }
        }

        public void ProgressBar_Initialize(string text)
        {
            _ProgressDialog = new ToolProgressBarDialog();
            _ProgressDialog.OperationText = text;
            _ProgressDialog.CancelEnabled = true;
            _ProgressDialog.ProgressCancelEvent += new EventHandler<EventArgs>(ProgressBar_CancelHandler);
        }

        public void ProgressBar_CancelHandler(object sender, EventArgs e)
        {
            _ProgressDialog.OperationText = ProductConstants.displayCancelling;
            _ProgressDialog.CancelEnabled = false;
            _JobPool.Cancel(true);
        }

        #endregion

        #endregion

        #region helpers

        #region menu actions

        private void CopyToClipboard(bool selectedOnly)
        {
            ExportToClipboard.CopyDataGridViewToTabbedFormat(dataGridViewJobs, true, true);
        }

        private void SelectAll(bool selected)
        {
            if (selected)
            {
                dataGridViewJobs.SelectAll();
            }
            else
            {
                dataGridViewJobs.ClearSelection();
            }
        }

        private void CheckAll(bool check, bool selectedOnly)
        {
            dataGridViewJobs.SuspendLayout();

            CurrencyManager cm = (CurrencyManager)dataGridViewJobs.BindingContext[dataGridViewJobs.DataSource, dataGridViewJobs.DataMember];
            DataView dv = (DataView)cm.List;

            foreach (DataGridViewRow viewRow in dataGridViewJobs.Rows)
            {
                if (!selectedOnly || (selectedOnly && viewRow.Selected))
                {
                    dv[viewRow.Index].Row[JobData.JobList.ColSelect] = check;
                }
            }

            dataGridViewJobs.ResumeLayout();

            int cnt = GetCheckedCount();
            buttonUpdateJobs.Enabled = (cnt > 0);
            labelStatus.Text = string.Format(ProductConstants.displaySelected, m_JobList.Rows.Count, cnt);
        }

        #endregion

        #region process data

        private void MarkSelections()
        {
            StringBuilder filter = new StringBuilder();

            string FILTER_LIKE = @" like ";
            string FILTER_IN = @" in ";
            string FILTER_EQUAL = @" = ";
            string FILTER_NOT_EQUAL = @" <> ";
            string FILTER_GREATER = @" > ";
            string FILTER_LESSTHAN = @" <= ";
            string FILTER_AND = @" and ";
            string FILTER_OR = @" or ";
            string FILTER_PAREN_OPEN = @"(";
            string FILTER_PAREN_CLOSE = @")";
            string FILTER_COMMA = @",";
            string FILTER_QUOTE = "'";
            string FILTER_DATETIME_FMT = @"yyyy-MM-dd HH:mm";
            string FILTER_NULL = @" is null";

            if (m_jobSelections.JobNames.Length > 0)
            {
                filter.Append(FILTER_PAREN_OPEN);
                foreach (string name in m_jobSelections.JobNames)
                {
                    if (filter.ToString().EndsWith(FILTER_QUOTE))
                    {
                        filter.Append(FILTER_OR);
                    }
                    filter.Append(JobData.JobList.ColJobName);
                    filter.Append(FILTER_LIKE);
                    filter.Append(FILTER_QUOTE);
                    filter.Append(SQLHelpers.CreateSafeSearchString(name));
                    filter.Append(FILTER_QUOTE);
                }
                filter.Append(FILTER_PAREN_CLOSE);
            }

            if (m_jobSelections.Enabled.HasValue)
            {
                if (filter.Length > 0)
                {
                    filter.Append(FILTER_AND);
                }
                filter.Append(JobData.JobList.ColEnabled);
                filter.Append(FILTER_EQUAL);
                filter.Append((int)m_jobSelections.Enabled.Value);
            }

            if (m_jobSelections.Categories.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter.Append(FILTER_AND);
                }
                filter.Append(FILTER_PAREN_OPEN);
                foreach (string cat in m_jobSelections.Categories)
                {
                    if (filter.ToString().EndsWith(FILTER_QUOTE))
                    {
                        filter.Append(FILTER_OR);
                    }
                    filter.Append(JobData.JobList.ColCategory);
                    filter.Append(FILTER_LIKE);
                    filter.Append(FILTER_QUOTE);
                    filter.Append(SQLHelpers.CreateSafeSearchString(cat));
                    filter.Append(FILTER_QUOTE);
                }
                filter.Append(FILTER_PAREN_CLOSE);
            }

            if (m_jobSelections.Owners.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter.Append(FILTER_AND);
                }
                filter.Append(FILTER_PAREN_OPEN);
                foreach (string owner in m_jobSelections.Owners)
                {
                    if (filter.ToString().EndsWith(FILTER_QUOTE))
                    {
                        filter.Append(FILTER_OR);
                    }
                    filter.Append(JobData.JobList.ColOwner);
                    filter.Append(FILTER_LIKE);
                    filter.Append(FILTER_QUOTE);
                    filter.Append(owner);
                    filter.Append(FILTER_QUOTE);
                }
                filter.Append(FILTER_PAREN_CLOSE);
            }

            if (m_jobSelections.Outcomes.Length > 0)
            {
                if (filter.Length > 0)
                {
                    filter.Append(FILTER_AND);
                }
                filter.Append(JobData.JobList.ColStatus);
                filter.Append(FILTER_IN);
                filter.Append(FILTER_PAREN_OPEN);
                foreach (JobData.JobOutcome status in m_jobSelections.Outcomes)
                {
                    if (!filter.ToString().EndsWith(FILTER_PAREN_OPEN))
                    {
                        filter.Append(FILTER_COMMA);
                    }
                    filter.Append(((int)status).ToString());
                }
                filter.Append(FILTER_PAREN_CLOSE);
            }

            if (m_jobSelections.Timeframe.HasValue)
            {
                if (filter.Length > 0)
                {
                    filter.Append(FILTER_AND);
                }
                filter.Append(JobData.JobList.ColLastRun);
                switch (m_jobSelections.Timeframe.Value)
                {
                    case JobData.JobTimeframe.InTheLastDay:
                        filter.Append(FILTER_GREATER);
                        filter.Append(FILTER_QUOTE);
                        filter.Append(DateTime.Now.Date.AddDays(-2).ToString(FILTER_DATETIME_FMT));
                        filter.Append(FILTER_QUOTE);
                        break;
                    case JobData.JobTimeframe.InTheLastHour:
                        filter.Append(FILTER_GREATER);
                        filter.Append(FILTER_QUOTE);
                        filter.Append(DateTime.Now.AddHours(-2).ToString(FILTER_DATETIME_FMT));
                        filter.Append(FILTER_QUOTE);
                        break;
                    case JobData.JobTimeframe.InTheLastMonth:
                        filter.Append(FILTER_GREATER);
                        filter.Append(FILTER_QUOTE);
                        filter.Append(DateTime.Now.Date.AddMonths(-2).ToString(FILTER_DATETIME_FMT));
                        filter.Append(FILTER_QUOTE);
                        break;
                    case JobData.JobTimeframe.InTheLastWeek:
                        filter.Append(FILTER_GREATER);
                        filter.Append(FILTER_QUOTE);
                        filter.Append(DateTime.Now.Date.AddDays(-8).ToString(FILTER_DATETIME_FMT));
                        filter.Append(FILTER_QUOTE);
                        break;
                    case JobData.JobTimeframe.Never:
                        filter.Append(FILTER_NULL);
                        break;
                }
            }

            if (m_jobSelections.JobstatusText.HasValue)
            {
                if (filter.Length > 0)
                {
                    filter.Append(FILTER_AND);
                }
                filter.Append(JobData.JobList.ColLastRun);
                switch (m_jobSelections.JobstatusText.Value)
                {
                    case JobData.JobLastRun.days:
                        filter.Append(FILTER_LESSTHAN);
                        filter.Append(FILTER_QUOTE);
                        filter.Append(DateTime.Now.AddDays(-m_jobSelections.Jobstatusvalue).ToString(FILTER_DATETIME_FMT));
                        filter.Append(FILTER_QUOTE);
                        filter.Append(FILTER_OR);
                        filter.Append(JobData.JobList.ColLastRun);
                        filter.Append(FILTER_EQUAL);
                        filter.Append(FILTER_QUOTE);
                        filter.Append("1/1/0001 12:00:00 AM");
                        filter.Append(FILTER_QUOTE);
                        break;
                    case JobData.JobLastRun.hours:
                        filter.Append(FILTER_LESSTHAN);
                        filter.Append(FILTER_QUOTE);
                        filter.Append(DateTime.Now.AddHours(-m_jobSelections.Jobstatusvalue).ToString(FILTER_DATETIME_FMT));
                        filter.Append(FILTER_QUOTE);
                        filter.Append(FILTER_OR);
                        filter.Append(JobData.JobList.ColLastRun);
                        filter.Append(FILTER_EQUAL);
                        filter.Append(FILTER_QUOTE);
                        filter.Append("1/1/0001 12:00:00 AM");
                        filter.Append(FILTER_QUOTE);
                        break;
                    case JobData.JobLastRun.minutes:
                        filter.Append(FILTER_LESSTHAN);
                        filter.Append(FILTER_QUOTE);
                        filter.Append(DateTime.Now.AddMinutes(-m_jobSelections.Jobstatusvalue).ToString(FILTER_DATETIME_FMT));
                        filter.Append(FILTER_QUOTE);
                        filter.Append(FILTER_OR);
                        filter.Append(JobData.JobList.ColLastRun);
                        filter.Append(FILTER_EQUAL);
                        filter.Append(FILTER_QUOTE);
                        filter.Append("1/1/0001 12:00:00 AM");
                        filter.Append(FILTER_QUOTE);
                        break;
                }
            }

            if (m_jobSelections.Notification.HasValue)
            {
                if (filter.Length > 0)
                {
                    filter.Append(FILTER_AND);
                }
                switch (m_jobSelections.Notification.Value)
                {
                    case JobData.NotifyType.Any:
                        filter.Append(FILTER_PAREN_OPEN);
                        filter.Append(JobData.JobList.ColNotifyLevelEventLog);
                        filter.Append(FILTER_NOT_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        filter.Append(FILTER_OR);
                        filter.Append(JobData.JobList.ColNotifyLevelEmail);
                        filter.Append(FILTER_NOT_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        filter.Append(FILTER_OR);
                        filter.Append(JobData.JobList.ColNotifyLevelNetSend);
                        filter.Append(FILTER_NOT_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        filter.Append(FILTER_OR);
                        filter.Append(JobData.JobList.ColNotifyLevelPage);
                        filter.Append(FILTER_NOT_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        filter.Append(FILTER_PAREN_CLOSE);
                        break;
                    case JobData.NotifyType.EventLog:
                        filter.Append(JobData.JobList.ColNotifyLevelEventLog);
                        filter.Append(FILTER_NOT_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        break;
                    case JobData.NotifyType.Email:
                        filter.Append(JobData.JobList.ColNotifyLevelEmail);
                        filter.Append(FILTER_NOT_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        break;
                    case JobData.NotifyType.NetSend:
                        filter.Append(JobData.JobList.ColNotifyLevelNetSend);
                        filter.Append(FILTER_NOT_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        break;
                    case JobData.NotifyType.Page:
                        filter.Append(JobData.JobList.ColNotifyLevelPage);
                        filter.Append(FILTER_NOT_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        break;
                    case JobData.NotifyType.None:
                        filter.Append(FILTER_PAREN_OPEN);
                        filter.Append(JobData.JobList.ColNotifyLevelEventLog);
                        filter.Append(FILTER_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        filter.Append(FILTER_AND);
                        filter.Append(JobData.JobList.ColNotifyLevelEmail);
                        filter.Append(FILTER_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        filter.Append(FILTER_AND);
                        filter.Append(JobData.JobList.ColNotifyLevelNetSend);
                        filter.Append(FILTER_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        filter.Append(FILTER_AND);
                        filter.Append(JobData.JobList.ColNotifyLevelPage);
                        filter.Append(FILTER_EQUAL);
                        filter.Append((int)JobData.NotifyLevel.Never);
                        filter.Append(FILTER_PAREN_CLOSE);
                        break;
                }
            }

            //Clear selections if requested before selecting new ones
            if (m_jobSelections.ClearPreviousSelections)
            {
                CheckAll(false, false);
            }

            DataView dv = new DataView(m_JobList);
            m_JobList.CaseSensitive = m_jobSelections.CaseSensitive;
            dv.RowFilter = filter.ToString();


            foreach (DataRowView drv in dv)
            {
                if (Convert.ToDateTime(drv.Row[JobData.JobList.ColLastRun]) == DateTime.MinValue && comboBoxjobdayhour.Text != "")
                {
                    drv.Row[JobData.JobList.ColSelect] = true;
                }
                else
                {
                    drv.Row[JobData.JobList.ColSelect] = true;
                }
            }

            // update the selection count
            int cnt = GetCheckedCount();
            buttonUpdateJobs.Enabled = (cnt > 0);

            labelStatus.Text = string.Format(ProductConstants.displaySelected, m_JobList.Rows.Count, cnt);
        }

        private void AddResultToJobList(DataTable result)
        {
            foreach (DataRow row in result.Rows)
            {
                DataRow newRow = m_JobList.Rows.Add(row.ItemArray);

                //recheck any previously checked items
                foreach (DataRow selrow in m_jobSelectedList.Rows)
                {
                    if ((string)row[JobData.JobList.ColServer] == (string)selrow[JobData.JobList.ColServer] &&
                          (string)row[JobData.JobList.ColJobName] == (string)selrow[JobData.JobList.ColJobName])
                    {
                        newRow[JobData.JobList.ColSelect] = true;
                        break;
                    }
                }

            }
        }

        private bool GetUpdates()
        {
            try
            {
                //Create a list of jobs to update
                JobData.UpdateJobsInfo jobsInfo = new JobData.UpdateJobsInfo();

                foreach (DataRow row in m_JobList.Rows)
                {
                    if ((bool)row[JobData.JobList.ColSelect])
                    {
                        // add the row to the list of jobs
                        jobsInfo.SelectedJobList.Rows.Add(row.ItemArray);

                        // add the server to the jobsInfo list
                        string server = SQLHelpers.NormalizeInstanceName((string)row[JobData.JobList.ColServer]);
                        if (!jobsInfo.ServerList.ContainsKey(server))
                        {
                            JobInfoResults results;
                            if (m_AllJobResults.TryGetValue(server, out results))
                            {
                                jobsInfo.AddServerInfo(results);
                            }
                        }
                    }
                }
                m_jobUpdateList = jobsInfo.SelectedJobList;

                JobUpdateValues updates;
                if (UpdateJobs.ProcessUpdates(jobsInfo, out updates))
                {
                    m_jobUpdateValues = updates;
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ProductConstants.msgErrorGettingUpdateJobs, ex);
                Messaging.ShowException(ProductConstants.msgErrorGettingUpdateJobs, ex);
            }

            return false;
        }

        #endregion

        private int GetCheckedCount()
        {
            int rowsChecked = 0;
            foreach (DataRow row in m_JobList.Rows)
            {
                if ((bool)row[JobData.JobList.ColSelect])
                {
                    rowsChecked++;
                }
            }

            return rowsChecked;
        }

        private void SetResultsLabel()
        {
            if (ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server)
            {
                if (ServerSelection.ServerList.Count == 0)
                {
                    groupResults.Text = ProductConstants.displayGroupHeader;
                    labelJobList.Text = string.Format(ProductConstants.displayGroupLabel, ProductConstants.displayGroupLabelGenericValue);
                    return;
                }
                else if (ServerSelection.ServerList.Count > 1)
                {
                    groupResults.Text = ProductConstants.displayGroupHeaderMultiServer;
                }
                else
                {
                    groupResults.Text = String.Format(ProductConstants.displayGroupLabel, SQLHelpers.NormalizeInstanceName(ServerSelection.Text));
                }
            }
            else
            {
                groupResults.Text = ProductConstants.displayGroupHeaderGroup;
            }
        }

        private void UpdateDashboard()
        {
            if (m_AllJobCounts.ServersScanned != 0)
            {
                if (m_JobList.Rows.Count != 0)
                {
                    dataGridViewJobs.Rows[0].Selected = true;
                    dataGridViewJobs.Select();

                    menuSelectAll.Enabled =
                       contextMenuSelectAll.Enabled =
                       menuClearAll.Enabled =
                       contextMenuClearAll.Enabled =
                       menuCheckAll.Enabled =
                       contextMenuCheckAll.Enabled =
                       menuClearAllChecked.Enabled =
                       contextMenuClearAllChecked.Enabled =
                       menuExport.Enabled =
                       contextMenuExport.Enabled = true;

                    buttonSelectJobs.Enabled =
                       buttonCopyToClipboard.Enabled = true;

                    // update the selection count
                    int cnt = GetCheckedCount();
                    buttonUpdateJobs.Enabled = (cnt > 0);

                    if (dataGridViewJobs.SelectedRows.Count == 1)
                    {
                        CurrencyManager cm = (CurrencyManager)dataGridViewJobs.BindingContext[dataGridViewJobs.DataSource, dataGridViewJobs.DataMember];
                        m_currentItem = ((DataRowView)cm.Current).Row;
                    }

                    labelStatus.Text = string.Format(ProductConstants.displaySelected, m_JobList.Rows.Count, cnt);
                }
                else
                {
                    menuSelectAll.Enabled =
                       contextMenuSelectAll.Enabled =
                       menuClearAll.Enabled =
                       contextMenuClearAll.Enabled =
                       menuCheckAllSelected.Enabled =
                       contextMenuCheckAllSelected.Enabled =
                       menuCheckAll.Enabled =
                       contextMenuCheckAll.Enabled =
                       menuClearAllChecked.Enabled =
                       contextMenuClearAllChecked.Enabled =
                       menuExport.Enabled =
                       contextMenuExport.Enabled = false;

                    buttonSelectJobs.Enabled =
                       buttonUpdateJobs.Enabled =
                       buttonCopyToClipboard.Enabled = false;

                    labelStatus.Text = String.Format(ProductConstants.displayTotal, m_JobList.Rows.Count);
                }

                labelServersScanned.Text = String.Format(ProductConstants.displayServers, m_AllJobCounts.ServersScanned);
                labelFailed.Text = String.Format(ProductConstants.displayFailed, m_AllJobCounts.FailedJobs);
                // labelNotRecent.Text = String.Format(ProductConstants.displayNotRecent, m_AllJobCounts.JobsNeverRun + m_AllJobCounts.JobsNotRecent);
                if (comboBoxjobdayhour.Text == "day(s)")
                {
                    labelNotRecent.Text = String.Format("{0} jobs not run in last " + numericUpDown1.Value + " days", (m_AllJobCounts.JobsNeverRun + m_AllJobCounts.JobsNotRecentDay));
                }
                else if (comboBoxjobdayhour.Text == "hour(s)")
                {
                    labelNotRecent.Text = String.Format("{0} jobs not run in last " + numericUpDown1.Value + " hours", (m_AllJobCounts.JobsNeverRun + m_AllJobCounts.JobsNotRecentHour));
                }
                else if (comboBoxjobdayhour.Text == "minute(s)")
                {
                    labelNotRecent.Text = String.Format("{0} jobs not run in last " + numericUpDown1.Value + " minutes", (m_AllJobCounts.JobsNeverRun + m_AllJobCounts.JobsNotRecentMinute));
                }
                labelNotNotifying.Text = String.Format(ProductConstants.displayNotNotifying, m_AllJobCounts.JobsNotNotifying);
                labelNewJobs.Text = String.Format(ProductConstants.displayNew, m_AllJobCounts.NewJobs);
            }
            else
            {
                labelServersScanned.Text = String.Format(ProductConstants.displayServers, ProductConstants.displayNone);
                labelFailed.Text = String.Format(ProductConstants.displayFailed, ProductConstants.displayUnknown);
                labelNotRecent.Text = String.Format(ProductConstants.displayNotRecent, ProductConstants.displayUnknown);
                labelNotNotifying.Text = String.Format(ProductConstants.displayNotNotifying, ProductConstants.displayUnknown);
                labelNewJobs.Text = String.Format(ProductConstants.displayNew, ProductConstants.displayUnknown);

                labelStatus.Text = String.Format(ProductConstants.displayTotal, ProductConstants.displayNone);
            }
        }

        #region Job Pool Task Processing

        /// <summary>
        /// Start Job Pool Get Tasks
        /// </summary>
        private void LoadData()
        {
            bool failed = false;

            try
            {
                List<ServerInformation> _ServerList = ServerSelection.ServerList;

                if (_ServerList.Count == 0)
                {
                    string msg;
                    if (ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server)
                        msg = ProductConstants.msgServerNeeded;
                    else
                        msg = ProductConstants.msgServerGroupEmpty;

                    Messaging.ShowError(msg);

                    return;
                }

                // initialize results area
                ProgressBar_Initialize(ProductConstants.displayLoading);

                SetResultsLabel();

                m_jobSelectedList = JobData.JobList.CreateTable();
                foreach (DataRow row in m_JobList.Rows)
                {
                    // add the row to the list of jobs
                    if ((bool)row[JobData.JobList.ColSelect])
                    {
                        m_jobSelectedList.Rows.Add(row.ItemArray);
                    }
                }


                // initialize the job list data and counts
                m_AllJobCounts.ResetCounts();
                m_AllJobResults.Clear();
                m_JobList.Clear();

                labelEmptyResultSet.Visible = false;

                labelStatus.Text = ProductConstants.displayLoading;
                labelStatus.Visible = true;

                Application.DoEvents();

                // set up server threads
                _ErrorReports.Clear();

                Application.DoEvents();

                _JobPool = new JobPool<JobPoolResults>(10);
                _JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolGetTaskComplete);
                _JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(JobPoolAllGetTasksComplete);
                _JobPool.Enqueue(JobRoutines.LoadJobInfo, _ServerList, ToolsetOptions.commandTimeout);
                _JobPool.StartAsync();

                ProgressBar_Show();
            }
            catch (Exception exc)
            {
                failed = true;
                Messaging.ShowException(ProductConstants.msgActionGetJobs, exc);
            }
            finally
            {
                if (failed)
                {
                    ProgressBar_Close();
                    UpdateDashboard();
                }
            }
        }

        private void JobPoolGetTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Failed && !_ErrorReports.ContainsKey(e.Server.ActualName))
            {
                _ErrorReports.Add(e.Server.ActualName, e.ErrorMessage);
            }
            else if (e.Status == TaskStatus.Success)
            {
                JobInfoResults results = (JobInfoResults)e.Resultset;
                m_AllJobCounts.AddCounts(results.JobList.Counts);
                // Fix the server name to match the results in case they are different
                string server = results.Server;
                if (results.JobList.Jobs.Rows.Count > 0)
                {
                    server = SQLHelpers.NormalizeInstanceName((string)results.JobList.Jobs.Rows[0][JobData.JobList.ColServer]);
                }

                if (!m_AllJobResults.ContainsKey(server))
                {
                    m_AllJobResults.Add(server, results);

                    AddResultToJobList(results.JobList.Jobs);

                    labelStatus.Text = string.Format(ProductConstants.displaySelected, m_JobList.Rows.Count, GetCheckedCount());
                }
            }
        }

        private void JobPoolAllGetTasksComplete(object sender, JobExecutionEventArgs e)
        {
            try
            {
                if (_ErrorReports.Count > 0)
                {
                    Form_MultipleServerError frm = new Form_MultipleServerError();
                    foreach (KeyValuePair<string, string> _Error in _ErrorReports)
                    {
                        frm.AddError(_Error.Key, _Error.Value);
                    }
                    BeginInvoke((MethodInvoker)delegate () { frm.ShowDialog(); });
                }
            }
            finally
            {
                if (!m_init)
                {
                    dataGridViewJobs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    folder = Helpers.GetProductDirectory(true);
                    string fileName = folder + "\\LastOutcomeSettings.xml";
                    if (File.Exists(fileName))
                    {
                        if (dataGridViewJobs.Columns[JobData.JobList.ColStatus].HeaderText == "Last Outcome")
                        {
                            ReadDataGridViewSetting(dataGridViewJobs);
                        }
                    }
                    m_init = true;
                }

                UpdateDashboard();

                ProgressBar_Close();
            }
        }

        /// <summary>
        /// Start Job Pool Update Tasks
        /// </summary>
        private void UpdateJobProperties()
        {
            bool failed = false;
            m_jobUpdateResults = new List<JobUpdateResults>();

            try
            {
                if (GetCheckedCount() == 0)
                {
                    Messaging.ShowError(ProductConstants.msgJobNeeded);

                    return;
                }

                // Create a list of servers with jobs to update
                List<ServerInformation> _ServerList = new List<ServerInformation>();
                foreach (DataRow row in m_jobUpdateList.Rows)
                {
                    // add the server to the list of servers
                    string server = (string)row[JobData.JobList.ColServer];
                    bool found = false;
                    foreach (ServerInformation svr in _ServerList)
                    {
                        if (svr.ActualName.Equals(server, StringComparison.CurrentCultureIgnoreCase))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        foreach (ServerInformation svr in ServerSelection.ServerList)
                        {
                            if (svr.ActualName.Equals(server, StringComparison.CurrentCultureIgnoreCase))
                            {
                                _ServerList.Add(svr);
                                break;
                            }
                        }
                    }
                }

                // initialize results area
                ProgressBar_Initialize(ProductConstants.displayUpdating);

                labelStatus.Text = ProductConstants.displayUpdating;
                labelStatus.Visible = true;

                Application.DoEvents();

                // set up server threads
                _ErrorReports.Clear();


                Application.DoEvents();

                JobUpdateOptions updateOptions = new JobUpdateOptions();
                updateOptions.JobList = m_jobUpdateList;
                updateOptions.UpdateValues = m_jobUpdateValues;

                _JobPool = new JobPool<JobPoolResults>(10);
                _JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolUpdateTaskComplete);
                _JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(JobPoolAllUpdateTasksComplete);
                _JobPool.Enqueue(JobRoutines.UpdateJobs, _ServerList, ToolsetOptions.commandTimeout, updateOptions);
                _JobPool.StartAsync();

                ProgressBar_Show();
            }
            catch (Exception exc)
            {
                failed = true;
                Messaging.ShowException(ProductConstants.msgActionUpdateJobs, exc);
            }
            finally
            {
                if (failed)
                {
                    ProgressBar_Close();
                }
            }
        }

        private void JobPoolUpdateTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Failed)
            {
                _ErrorReports.Add(e.Server.ActualName, e.ErrorMessage);
            }
            else if (e.Status == TaskStatus.Success)
            {
                if (e.Resultset is JobUpdateResults)
                {
                    JobUpdateResults results = (JobUpdateResults)e.Resultset;
                    m_jobUpdateResults.Add(results);
                    if (results.FailedCount > 0)
                    {
                        foreach (DataRow row in results.Results.Rows)
                        {
                            _ErrorReports.Add(e.Server.ActualName, (string)row[JobUpdateResults.ColErrorText]);
                        }
                    }
                    if (results.SuccessfulCount > 0 && ((JobUpdateOptions)results.Options).UpdateValues.ClearSelections)
                    {
                        dataGridViewJobs.SuspendLayout();

                        foreach (DataRow row in results.Results.Rows)
                        {
                            if ((JobUpdateResults.UpdateStatus)row[JobUpdateResults.ColUpdateStatus] == JobUpdateResults.UpdateStatus.Success)
                            {
                                foreach (DataRow checkedRow in m_JobList.Rows)
                                {
                                    if (((string)checkedRow[JobData.JobList.ColServer]).Equals((string)row[JobData.JobList.ColServer], StringComparison.CurrentCultureIgnoreCase) &&
                                          ((string)checkedRow[JobData.JobList.ColJobName]).Equals((string)row[JobData.JobList.ColJobName]))
                                    {
                                        checkedRow[JobData.JobList.ColSelect] = false;
                                    }
                                }
                            }

                            dataGridViewJobs.ResumeLayout();
                        }
                    }
                }
                else
                {
                    _ErrorReports.Add(e.Server.ActualName, string.Format(ProductConstants.msgErrorUnknownType, e.Resultset.GetType().ToString()));
                }
            }
        }

        private void JobPoolAllUpdateTasksComplete(object sender, JobExecutionEventArgs e)
        {
            try
            {
                if (_ErrorReports.Count > 0)
                {
                    Form_MultipleServerError frm = new Form_MultipleServerError();
                    foreach (KeyValuePair<string, string> _Error in _ErrorReports)
                    {
                        frm.AddError(_Error.Key, _Error.Value);
                    }
                    BeginInvoke((MethodInvoker)delegate () { frm.ShowDialog(); });
                }
            }
            finally
            {
                ProgressBar_Close();

                int successCount = 0;
                foreach (JobUpdateResults results in m_jobUpdateResults)
                {
                    successCount += results.SuccessfulCount;
                }
                string msg = string.Format(ProductConstants.msgJobsUpdated, successCount, m_jobUpdateResults.Count);
                Messaging.ShowInformation(msg, ProductConstants.msgActionUpdateJobs);

                LoadData();
            }
        }

        #endregion

        /// <summary>
        /// Show a limited Job Properties window for updating with code from Job Manager. Requires SQL Agent to be running on the server.
        /// </summary>
        private void ShowJobProperties()
        {
            if (m_currentItem != null)
            {
                try
                {
                    DataRow row = m_currentItem;

                    ServerInformation serverInformation = null;
                    foreach (ServerInformation server in ServerSelection.ServerList)
                    {
                        if (server.Name.Equals((string)row[JobData.JobList.ColServerInfo], StringComparison.CurrentCultureIgnoreCase))
                        {
                            serverInformation = server;
                            break;
                        }
                    }

                    if (serverInformation == null)
                    {
                        throw new Exception(string.Format("Server {0} not found in server list", (string)row[JobData.JobList.ColServer]));
                    }
                    else
                    {
                        SqlConnection conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials);
                        Microsoft.SqlServer.Management.Common.ServerConnection serverConnection = new Microsoft.SqlServer.Management.Common.ServerConnection(conn);
                        Server server = new Server(serverConnection);
                        Job job = server.JobServer.Jobs[(string)row[JobData.JobList.ColJobName]];
                        EditJobDlg dlg = new EditJobDlg(job);
                        if (DialogResult.OK == dlg.ShowDialog())
                        {
                            LoadData();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Messaging.ShowException(ProductConstants.msgActionJobProperties, ex);
                }
            }
        }

        #endregion

        #region event handlers

        #region OnLoad (Common)

        protected override void OnLoad(EventArgs e)
        {
            #region Common Onload code

            base.OnLoad(e);
            if (!Startup.GuiStartup(this, menuTools, menuAbout, ideraTitleBar1))
            {
                Close();
                return;
            }

            #endregion

            dataGridViewJobs.DataSource = m_JobList;
        }

        #endregion

        #region Common Code

        #region File Menu Event Handlers (Common)

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuExitToLaunchpad_Click(object sender, EventArgs e)
        {
            Launchpad.RunAndClose(this);
        }

        #endregion

        #region Help Menu Event Handlers (Common)

        private void menuShowHelp_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowHelp();
        }

        private void menuDeactivateLicense_Click(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }



        private void menuAbout_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowAboutForm();
        }

        private void menuSearchIderaKnowledgeBase_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_SearchIderaKnowledgeBase(this);
        }

        private void menuAboutIderaProducts_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_AboutIderaProducts(this);
        }

        private void menuContactTechnicalSupport_Click(object sender, EventArgs e)
        {
            HelpMenu.ShowURL_ContactTechnicalSupport(this);
        }

        private void menuCheckForUpdates_Click(object sender, EventArgs e)
        {
            HelpMenu.CheckForUpdates(this);
        }

        #endregion

        #region Tools Menu (Common )

        private void menuManageServerGroups_Click(object sender, EventArgs e)
        {
            ToolsMenu.ManageServerGroups();
        }

        private void menuToolsetOptions_Click(object sender, EventArgs e)
        {
            ToolsMenu.ShowToolsetOptions();
        }

        private void menuLaunchpad_Click(object sender, EventArgs e)
        {
            ToolsMenu.RunLaunchpad(this);
        }

        #endregion

        #endregion

        #region server selection

        private void ServerSelection_TextChanged(object sender, EventArgs e)
        {
            buttonGetResults.Enabled = (ServerSelection.Text.Trim() != string.Empty);
        }

        #endregion

        #region datagrid

        private void dataGridViewJobs_DataSourceChanged(object sender, EventArgs e)
        {
            dataGridViewJobs.Columns[JobData.JobList.ColSelect].HeaderText = "";
            dataGridViewJobs.Columns[JobData.JobList.ColSelect].Width = 26;
            dataGridViewJobs.Columns[JobData.JobList.ColSelect].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridViewJobs.Columns[JobData.JobList.ColSelect].ReadOnly = false;

            dataGridViewJobs.Columns[JobData.JobList.ColServerInfo].Visible = false;

            dataGridViewJobs.Columns[JobData.JobList.ColServer].HeaderText = "Server";
            dataGridViewJobs.Columns[JobData.JobList.ColServer].Width = 120;

            dataGridViewJobs.Columns[JobData.JobList.ColJobName].HeaderText = "Job Name";
            dataGridViewJobs.Columns[JobData.JobList.ColJobName].Width = 160;

            dataGridViewJobs.Columns[JobData.JobList.ColEnabled].HeaderText = "Enabled";
            dataGridViewJobs.Columns[JobData.JobList.ColEnabled].Width = 58;

            dataGridViewJobs.Columns[JobData.JobList.ColCategory].HeaderText = "Category";
            dataGridViewJobs.Columns[JobData.JobList.ColCategory].Width = 150;

            dataGridViewJobs.Columns[JobData.JobList.ColOwner].HeaderText = "Owner";
            dataGridViewJobs.Columns[JobData.JobList.ColOwner].Width = 120;

            dataGridViewJobs.Columns[JobData.JobList.ColStatus].HeaderText = "Last Outcome";
            folder = Helpers.GetProductDirectory(true);
            string fileName = folder + "\\LastOutcomeSettings.xml";
            if (File.Exists(fileName))
            {
                if (dataGridViewJobs.Columns[JobData.JobList.ColStatus].HeaderText == "Last Outcome")
                {
                    ReadDataGridViewSetting(dataGridViewJobs);
                }
            }
            else
                dataGridViewJobs.Columns[JobData.JobList.ColStatus].Width = 100;


            dataGridViewJobs.Columns[JobData.JobList.ColLastRun].HeaderText = "Last Run";
            dataGridViewJobs.Columns[JobData.JobList.ColLastRun].Width = 120;

            dataGridViewJobs.Columns[JobData.JobList.ColNextRun].HeaderText = "Next Scheduled";
            dataGridViewJobs.Columns[JobData.JobList.ColNextRun].Width = 120;

            dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelEventLog].HeaderText = "Notify Event Log";
            dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelEventLog].Width = 100;

            dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelEmail].HeaderText = "Notify Email";
            dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelEmail].Width = 76;

            dataGridViewJobs.Columns[JobData.JobList.ColNotifyOperatorEmail].HeaderText = "Email Operator";
            dataGridViewJobs.Columns[JobData.JobList.ColNotifyOperatorEmail].Width = 90;

            dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelNetSend].HeaderText = "Notify Net Send";
            dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelNetSend].Width = 94;

            dataGridViewJobs.Columns[JobData.JobList.ColNotifyOperatorNetSend].HeaderText = "Net Send Operator";
            dataGridViewJobs.Columns[JobData.JobList.ColNotifyOperatorNetSend].Width = 110;

            dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelPage].HeaderText = "Notify Page";
            dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelPage].Width = 76;

            dataGridViewJobs.Columns[JobData.JobList.ColNotifyOperatorPage].HeaderText = "Page Operator";
            dataGridViewJobs.Columns[JobData.JobList.ColNotifyOperatorPage].Width = 90;

            dataGridViewJobs.Columns[JobData.JobList.ColDateCreated].HeaderText = "Date Created";
            dataGridViewJobs.Columns[JobData.JobList.ColDateCreated].Width = 90;

            dataGridViewJobs.Columns[JobData.JobList.ColLastModified].HeaderText = "Last Modified";
            dataGridViewJobs.Columns[JobData.JobList.ColLastModified].Width = 90;

            dataGridViewJobs.Columns[JobData.JobList.ColDescription].HeaderText = "Description";
            dataGridViewJobs.Columns[JobData.JobList.ColDescription].Width = 190;

            //set everything to readonly except the select column
            foreach (DataGridViewColumn col in dataGridViewJobs.Columns)
            {
                if (col.Name != JobData.JobList.ColSelect)
                {
                    col.ReadOnly = true;
                }
            }
        }

        private void dataGridViewJobs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColEnabled].Index)
            {
                e.Value = JobData.GetEnumDescription((JobData.JobEnabled)e.Value);
                e.FormattingApplied = true;
            }
            else if (e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColStatus].Index)
            {
                e.Value = JobData.GetEnumDescription((JobData.JobOutcome)e.Value);
                e.FormattingApplied = true;
            }
            else if (e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelEventLog].Index ||
                     e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelEmail].Index ||
                     e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelNetSend].Index ||
                     e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelPage].Index)
            {
                e.Value = JobData.GetEnumDescription((JobData.NotifyLevel)e.Value);
                e.FormattingApplied = true;
            }
        }

        private void dataGridViewJobs_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // process data rows
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColStatus].Index)
                {
                    if ((JobData.JobOutcome)e.Value == JobData.JobOutcome.Failed)
                    {
                        e.CellStyle.BackColor =
                           e.CellStyle.SelectionBackColor = Color.Red;
                        e.CellStyle.ForeColor =
                           e.CellStyle.SelectionForeColor = Color.White;
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Handled = true;
                    }
                }
                else if (e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColLastRun].Index)
                {
                    if (!JobData.JobList.IsDateRecent((DateTime)e.Value, ProductConstants.compareRecentDays))
                    {
                        e.CellStyle.BackColor =
                           e.CellStyle.SelectionBackColor = Color.Yellow;
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Handled = true;
                    }
                }
                else if (e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColNotifyLevelEventLog].Index)
                {
                    if ((JobData.NotifyLevel)e.Value == JobData.NotifyLevel.Never)
                    {
                        e.CellStyle.BackColor =
                           e.CellStyle.SelectionBackColor = Color.Yellow;
                        e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                        e.Handled = true;
                    }
                }
            }
        }

        private void dataGridViewJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewJobs.Columns[JobData.JobList.ColSelect].Index)
            {
                if (e.RowIndex >= 0)
                {
                    m_currentItem[JobData.JobList.ColSelect] = !(bool)m_currentItem[JobData.JobList.ColSelect];

                    int cnt = GetCheckedCount();
                    buttonUpdateJobs.Enabled = (cnt > 0);

                    labelStatus.Text = string.Format(ProductConstants.displaySelected, m_JobList.Rows.Count, cnt);
                }
            }
        }

        private void dataGridViewJobs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            if (m_currentItem != null)
            {
                ShowJobProperties();
            }

            Cursor = Cursors.Default;
        }

        private void dataGridViewJobs_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CurrencyManager cm = (CurrencyManager)dataGridViewJobs.BindingContext[dataGridViewJobs.DataSource, dataGridViewJobs.DataMember];
                DataView dv = (DataView)cm.List;
                m_currentItem = dv[e.RowIndex].Row;
            }
            else
            {
                m_currentItem = null;
            }
        }

        private void dataGridViewJobs_SelectionChanged(object sender, EventArgs e)
        {
            menuCopy.Enabled =
               contextMenuCopy.Enabled =
               menuCheckAllSelected.Enabled =
               contextMenuCheckAllSelected.Enabled = (dataGridViewJobs.SelectedRows.Count > 0);
            menuEditJob.Enabled =
               contextMenuEditJob.Enabled = (dataGridViewJobs.SelectedRows.Count == 1);
        }

        #endregion

        #region button actions

        private void buttonGetResults_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            JobRoutines.joblastrunstatusinfo(comboBoxjobdayhour.Text, Convert.ToInt32(numericUpDown1.Value));
            // save item to persisted MRU list
            MRU.AddServerOrGroup(ServerSelection.SelectionType == Idera.SqlAdminToolset.Core.Controls.ServerSelectionType.Server,
                                  ServerSelection.Text,
                                  ServerSelection.SqlCredentials);

            LoadData();

            Cursor = Cursors.Default;
        }

        private void buttonSelectJobs_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            JobSelections selections;
            if (SelectJobs.ProcessSelections(m_JobList, m_jobSelections, out selections))
            {
                m_jobSelections = selections;
                MarkSelections();
            }

            Cursor = Cursors.Default;
        }

        private void buttonUpdateJobs_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            if (GetUpdates())
            {
                UpdateJobProperties();
            }

            Cursor = Cursors.Default;
        }

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            CopyToClipboard(false);

            Cursor = Cursors.Default;
        }

        #endregion

        #region menu / context menu

        private void menuEditJob_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            ShowJobProperties();

            Cursor = Cursors.Default;
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            CopyToClipboard(true);

            Cursor = Cursors.Default;
        }

        private void menuSelectAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            SelectAll(true);

            Cursor = Cursors.Default;
        }

        private void menuClearAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            SelectAll(false);

            Cursor = Cursors.Default;
        }

        private void menuCheckAllSelected_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            CheckAll(true, true);

            Cursor = Cursors.Default;
        }

        private void menuCheckAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            CheckAll(true, false);

            Cursor = Cursors.Default;
        }

        private void menuClearAllChecked_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            CheckAll(false, false);

            Cursor = Cursors.Default;
        }

        private void menuCSV_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            ExportToCSV.CopyDataGridView(dataGridViewJobs, true);

            Cursor = Cursors.Default;
        }

        private void menuXML_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            ExportToXML.CopyDataGridView(dataGridViewJobs, ProductConstants.displayGroupHeader, true);

            Cursor = Cursors.Default;
        }

        private void contextMenuStripJobList_Opening(object sender, CancelEventArgs e)
        {
            bool isJob = m_currentItem != null;
            bool isSelected = dataGridViewJobs.SelectedRows.Count > 0;

            contextMenuEditJob.Enabled = isJob;
            contextMenuCheckAllSelected.Enabled = isSelected;
        }

        private void contextMenuEditJob_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            menuEditJob_Click(sender, e);

            Cursor = Cursors.Default;
        }

        private void contextMenuCopyToClipboard_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            menuCopy_Click(sender, e);

            Cursor = Cursors.Default;
        }

        private void contextMenuSelectAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            menuSelectAll_Click(sender, e);

            Cursor = Cursors.Default;
        }

        private void contextMenuClearAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            menuClearAll_Click(sender, e);

            Cursor = Cursors.Default;
        }

        private void contextMenuCheckAllSelected_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            menuCheckAllSelected_Click(sender, e);

            Cursor = Cursors.Default;
        }

        private void contextMenuCheckAll_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            menuCheckAll_Click(sender, e);

            Cursor = Cursors.Default;
        }

        private void contextMenuClearAllChecked_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            menuClearAllChecked_Click(sender, e);

            Cursor = Cursors.Default;
        }

        private void contextMenuCSV_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            menuCSV_Click(sender, e);

            Cursor = Cursors.Default;
        }

        private void contextMenuXML_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            menuXML_Click(sender, e);

            Cursor = Cursors.Default;
        }

        #endregion

        #endregion

        private void ShowF1Help(object sender, HelpEventArgs hlpevent)
        {
            HelpMenu.ShowHelp();
        }

        private void menuHelp_Click(object sender, EventArgs e)
        {

            base.OnClick(e);
        }

        private void ideraTitleBar1_LicenseInfoButtonClick(object sender, EventArgs e)
        {
            LicenseUI.ShowLicenseManagementForm();
            ideraTitleBar1.LicenseInformation = LicenseUI.GetLicenseInfo();
        }

        public void ReadDataGridViewSetting(DataGridView dgv)
        {
            folder = Helpers.GetProductDirectory(true);
            string fileName = folder + "\\LastOutcomeSettings.xml";
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            //declare the filestream for reading and accessing the xml file  
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            xmldoc.Load(fs);

            xmlnode = xmldoc.GetElementsByTagName("column");
            for (int i = 0; i <= xmlnode.Count - 1; i++)
            {

                string columnName = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                int width = int.Parse(xmlnode[i].ChildNodes.Item(1).InnerText.Trim());
                string headertext = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                int displayindex = int.Parse(xmlnode[i].ChildNodes.Item(3).InnerText.Trim());
                dgv.Columns[columnName].Width = width;
                dgv.Columns[columnName].HeaderText = headertext;
                dgv.Columns[columnName].DisplayIndex = displayindex;
            }
            fs.Close();
        }

        public void WriteGrideViewSetting(DataGridView dgv)
        {
            folder = Helpers.GetProductDirectory(true);
            string fileName = folder + "\\LastOutcomeSettings.xml";
            XmlTextWriter settingwriter = new XmlTextWriter(fileName, null);

            settingwriter.WriteStartDocument();
            settingwriter.WriteStartElement(dgv.Name);
            int count = dgv.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                if (dgv.Columns[i].Name.ToString() == "Status")
                {
                    settingwriter.WriteStartElement("column");
                    settingwriter.WriteStartElement("Name");
                    settingwriter.WriteString(dgv.Columns[i].Name);
                    settingwriter.WriteEndElement();
                    settingwriter.WriteStartElement("width");
                    settingwriter.WriteString(dgv.Columns[i].Width.ToString());
                    settingwriter.WriteEndElement();
                    settingwriter.WriteStartElement("headertext");
                    settingwriter.WriteString(dgv.Columns[i].HeaderText);
                    settingwriter.WriteEndElement();
                    settingwriter.WriteStartElement("displayindex");
                    settingwriter.WriteString(dgv.Columns[i].DisplayIndex.ToString());
                    settingwriter.WriteEndElement();
                    settingwriter.WriteEndElement();
                }
            }
            settingwriter.WriteEndElement();
            settingwriter.WriteEndDocument();
            settingwriter.Close();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteGrideViewSetting(dataGridViewJobs);
        }
        private void comboBoxjobdayhour_DropDown(object sender, EventArgs e)
        {
            JobRoutines.FillComboBoxFromEnum((ComboBoxEx)sender, typeof(JobData.JobLastRun), true);
        }
    }
}
