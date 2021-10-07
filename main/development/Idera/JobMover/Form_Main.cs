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
using System.Linq;

using DevComponents.DotNetBar;

using BBS.TracerX;
using Idera.SqlAdminToolset.Core;
using Idera.SqlAdminToolset.JobMover.DataObjects;
using IderaTrialExperienceCommon.Common;

namespace Idera.SqlAdminToolset.JobMover
{
    public partial class Form_Main : Form
    {
        #region fields

        private Logger logger;

        // JobPool processing
        private JobPool<JobPoolResults> _JobPool;
        private static Dictionary<string, string> _ErrorReports = new Dictionary<string, string>();
        private JobMoverOptions _JobOptions;

        // Selection
        SQLCredentials _SourceServerSqlCredentials = null;
        SQLCredentials _DestinationServerSqlCredentials = null;
        private ServerInformation _SourceServer = null;
        private ServerInformation _DestinationServer = null;
        private GetInfoType _GetInfoType;
        private List<Job> _Jobs = new List<Job>();
        private List<Job> _SelectedJobs = new List<Job>();
        private List<Job> _SelectedDisableJobs = new List<Job>();
        private List<Job> SelectedJobs = new List<Job>();
        private TaskToPerform _Task = TaskToPerform.CopyJobsToDifferentServer;
        List<Job> _JobsToMove = new List<Job>();
        string _SourceServerCachedValue = string.Empty;
        string _DestinationServerCachedValue = string.Empty;

        // Tasks
        private List<GetTaskResults> _GetTaskResults;
        private List<JobTaskResults> _JobTaskResults;
        List<TaskStep> _LoadedSteps = new List<TaskStep>();
        TaskStep _CurrentStep = TaskStep.Initialize;

        #endregion

        #region Constructor

        public Form_Main()
        {
            InitializeComponent();
            this.Text = ideraTitleBar1.IderaProductNameText;
            this.logger = CoreGlobals.traceLog;

            this.textTaskLog.ContextMenu = new ContextMenu();
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

        #region Methods

        #endregion

        #region Helpers

        private void ResetValues()
        {
            _SourceServerSqlCredentials = null;
            _DestinationServerSqlCredentials = null;
            _SourceServer = null;
            _DestinationServer = null;
            _JobsToMove.Clear();

            _Task = TaskToPerform.CopyJobsToDifferentServer;
            optionCopyJobs.Checked = true;

            textSourceServer.Text = ProductConstants.ServersLocal;
            textDestinationServer.Text = ProductConstants.ServersLocal;

            checkboxIncludeSchedule.Checked = true;
            checkBoxCreateCategory.Checked = true;
            checkBoxCreateOperators.Checked = true;
            checkBoxCreateSchedule.Checked = true;       // false should be selected whenever this feature is written
            checkBoxIncludeNotifications.Checked = true;
            checkBoxOverwrite.Checked = false;
            checkBoxOverwrite.Enabled = true;

            ResetDynamicValues();
        }

        private void ResetDynamicValues()
        {
            _SelectedJobs.Clear();
            //_TaskCompleteResults = null;

            ListJobs.Items.Clear();
            textTaskLog.Text = "";
            linkClearAllJobs.Visible =
               linkSelectAllJobs.Visible = true;

            _LoadedSteps.Clear();
            ProgressList.NumberOfSteps = 0;
            for (int i = 1; i <= 6; i++)
            {
                ProgressList.SetStepText(i, string.Empty);
            }
            WizardJobMove.CancelButtonText = ProductConstants.CancelButtonExit;

            pageSummary.BackButtonEnabled =
               pageSummary.CancelButtonEnabled =
               pageSummary.NextButtonEnabled =
               pageSummary.FinishButtonEnabled =
               DevComponents.DotNetBar.eWizardButtonState.True;
        }

        #region Servers

        private string BrowseServer()
        {
            Form_SQLServerBrowse browseDlg = new Form_SQLServerBrowse();

            Cursor = Cursors.WaitCursor;
            bool loaded = browseDlg.LoadServers();
            Cursor = Cursors.Default;

            if (loaded)
            {
                DialogResult choice = browseDlg.ShowDialog();
                if (choice == DialogResult.OK)
                {
                    return browseDlg.SelectedServer;
                }
            }
            return string.Empty;
        }

        private void InitializeServers()
        {
            if (textSourceServer.Text.Trim().Length > 0 && _SourceServer == null)
            {
                InitializeServer(ref _SourceServer, textSourceServer.Text, _SourceServerSqlCredentials);
            }

            if (textDestinationServer.Text.Trim().Length > 0 && _DestinationServer == null)
            {
                InitializeServer(ref _DestinationServer, textDestinationServer.Text, _DestinationServerSqlCredentials);
            }
        }

        private void InitializeServer(ref ServerInformation server, string name, SQLCredentials credentials)
        {
            if (credentials == null || (credentials.useWindowsAuthentication&& string.IsNullOrEmpty(credentials.password)))
            {
                server = new ServerInformation(name);
            }
            else
            {
                server = new ServerInformation(name, credentials);
            }
        }

        #endregion

        #region Job Pool Task Processing

        /// <summary>
        /// Start Job Pool Source Retrieval Tasks
        /// </summary>
        private void DoGetSourceInfo(GetInfoType infoType)
        {
            _GetInfoType = infoType;

            try
            {
                if (_SourceServer != null)
                {
                    List<ServerInformation> _ServerList = new List<ServerInformation>();
                    _ServerList.Add(_SourceServer);

                    _JobOptions = new JobMoverOptions();
                    _JobOptions.SourceServer = _SourceServer;
                    _JobOptions.DestinationServer = _DestinationServer;

                    _ErrorReports.Clear();
                    _GetTaskResults = new List<GetTaskResults>();

                    if (infoType == GetInfoType.Copy)
                    {
                        ProgressList.Initialize();
                        labelStatus.Visible = false;
                        buttonDoAnotherScan.Visible = false;
                        buttonBack.Visible = false;
                        buttonClose.Enabled = false;

                        textTaskLog.Text = string.Empty;
                        _JobTaskResults = new List<JobTaskResults>();

                        List<TaskStep> _Steps = new List<TaskStep>();
                        _Steps.Add(TaskStep.ProcessJobs);
                        _Steps.Add(TaskStep.ProcessCategories);
                        _Steps.Add(TaskStep.ProcessOwners);
                        if (checkBoxIncludeNotifications.Checked)
                        {
                            _Steps.Add(TaskStep.ProcessOperators);
                        }
                        _Steps.Add(TaskStep.ProcessSteps);
                        _Steps.Add(TaskStep.CreateJobs);
                        //_Steps.Add(TaskStep.DeleteSource);
                        Application.DoEvents();

                        LoadSteps(_Steps);
                        Application.DoEvents();

                        // selected jobs
                        //  _JobOptions.Jobs.AddRange(_SelectedJobs.ToArray()); 

                        _JobOptions.Jobs.AddRange(SelectedJobs.ToArray());

                        // source options
                        _JobOptions.IncludeNotifications = checkBoxIncludeNotifications.Checked;
                        _JobOptions.IncludeSchedules = checkboxIncludeSchedule.Checked;
                        _JobOptions.DeleteSourceJobs = (_Task == TaskToPerform.MoveJobsToDifferentServer);

                        // destination options
                        _JobOptions.CreateCategories = checkBoxCreateCategory.Checked;
                        _JobOptions.CreateOperators = checkBoxCreateOperators.Checked;
                        _JobOptions.CreateSchedules = checkBoxCreateSchedule.Checked;
                        _JobOptions.Overwrite = checkBoxOverwrite.Checked;
                        _JobOptions.AssignNewOwner = checkBoxAlwaysUseOwner.Checked;
                        _JobOptions.OwnerName = comboBoxOwners.Text;
                        _JobOptions.AssignNewDatabase = (comboBoxDatabases.Text.Length > 0);
                        _JobOptions.DatabaseName = comboBoxDatabases.Text;

                        // event for status updates
                        _JobOptions.TaskStatus += new EventHandler<TaskStatusEventArgs>(UpdateTaskStatus);
                    }

                    Cursor = Cursors.WaitCursor;

                    _JobPool = new JobPool<JobPoolResults>(10);
                    _JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolGetSourceInfoTaskComplete);
                    _JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(JobPoolAllGetSourceInfoTasksComplete);
                    _JobPool.Enqueue(JobMoverRoutines.LoadSourceInfo, _ServerList, ToolsetOptions.commandTimeout, _JobOptions);

                    _JobPool.StartAsync();
                }
            }
            catch (Exception ex)
            {
                logger.Error("Form_Main.DoGetSourceInfo()", Helpers.GetCombinedExceptionText(ex));
                DoFinish(JobTaskResults.Status.Failed);
            }
        }

        private void JobPoolGetSourceInfoTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Failed)
            {
                _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
            }
            else if (e.Status == TaskStatus.Success)
            {
                if (e.Resultset is GetTaskResults)
                {
                    _GetTaskResults.Add((GetTaskResults)e.Resultset);
                }
                else
                {
                    _ErrorReports.Add(e.Server.Name, string.Format(ProductConstants.ErrorUnknownType, e.Resultset.GetType().ToString()));
                }
            }
        }

        private void JobPoolAllGetSourceInfoTasksComplete(object sender, JobExecutionEventArgs e)
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
                    DoFinish(JobTaskResults.Status.Failed);
                }
                else
                {

                    if (_GetInfoType == GetInfoType.Select)
                    {
                        foreach (GetTaskResults results in _GetTaskResults)
                        {
                            if (results.Jobs.Count > 0)
                            {
                                foreach (Job job in results.Jobs.Values)
                                {
                                    _Jobs.Add(job);
                                }

                                _Jobs.ForEach(delegate (Job job)
                                     {
                                         ListJobs.Items.Add(job, false);
                                     });
                            }
                        }
                        if (_Jobs.Count == 0)
                        {
                            labelJobListMessage.Visible = true;
                            labelJobListMessage.Text = ProductConstants.PromptNoJobs;
                            linkClearAllJobs.Visible =
                               linkSelectAllJobs.Visible = false;
                        }
                        else
                        {
                            ListJobs.Visible = true;
                            labelJobListMessage.Visible = false;
                            linkClearAllJobs.Visible =
                               linkSelectAllJobs.Visible = true;
                        }

                        this.Cursor = Cursors.Default;
                    }
                    else if (_GetInfoType == GetInfoType.Copy)
                    {
                        // store the latest job info for the selected jobs in the options before calling validate
                        _JobOptions.Jobs.Clear();
                        foreach (GetTaskResults results in _GetTaskResults)
                        {
                            foreach (Job job in results.Jobs.Values)
                            {
                                _JobOptions.Jobs.Add(job);
                            }
                        }

                        // store the latest operators for the selected jobs in the options before calling validate
                        foreach (GetTaskResults results in _GetTaskResults)
                        {
                            foreach (KeyValuePair<string, Operator> oper in results.Operators)
                            {
                                _JobOptions.SourceOperators.Add(oper.Key, oper.Value);
                            }
                        }

                        DoValidate();
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Form_Main.JobPoolAllGetSourceInfoTasksComplete() Error: ", Helpers.GetCombinedExceptionText(ex));
                DoFinish(JobTaskResults.Status.Failed);
            }
        }

        /// <summary>
        /// Start Job Pool Validation Tasks
        /// </summary>
        private void DoValidate()
        {
            try
            {
                List<ServerInformation> _ServerList = new List<ServerInformation>();
                _ServerList.Add(_DestinationServer);

                _JobPool = new JobPool<JobPoolResults>(10);
                _JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolValidateTaskComplete);
                _JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(JobPoolAllValidateTasksComplete);
                _JobPool.Enqueue(JobMoverRoutines.ValidateJobs, _ServerList, ToolsetOptions.commandTimeout, _JobOptions);
                _JobPool.StartAsync();
            }
            catch (Exception ex)
            {
                logger.Error("Form_Main.DoValidate()", Helpers.GetCombinedExceptionText(ex));
                DoFinish(JobTaskResults.Status.Failed);
            }
        }

        private void JobPoolValidateTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Failed)
            {
                _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
            }
            else if (e.Status == TaskStatus.Success)
            {
                if (e.Resultset is JobTaskResults)
                {
                    _JobTaskResults.Add((JobTaskResults)e.Resultset);
                }
                else
                {
                    _ErrorReports.Add(e.Server.Name, string.Format(ProductConstants.ErrorUnknownType, e.Resultset.GetType().ToString()));
                }
            }
        }

        private void JobPoolAllValidateTasksComplete(object sender, JobExecutionEventArgs e)
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
                    DoFinish(JobTaskResults.Status.Failed);
                }
                else
                {
                    bool doCopy = true;

                    Form_Results frm = new Form_Results(Form_Results.ResultsType.Validation);
                    foreach (JobTaskResults results in _JobTaskResults)
                    {
                        foreach (DataRow row in results.Results.Rows)
                        {
                            frm.AddResult((string)row[JobTaskResults.ColObjectName],
                                           (JobTaskResults.Status)row[JobTaskResults.ColStatus],
                                           (string)row[JobTaskResults.ColResultsText]);
                            if ((JobTaskResults.Status)row[JobTaskResults.ColStatus] == JobTaskResults.Status.Failed)
                            {
                                doCopy = false;
                            }
                        }
                    }
                    if (!doCopy)
                    {
                        if (DialogResult.OK == frm.ShowDialog())
                        {
                            doCopy = true;
                        }
                        else
                        {
                            buttonBack.Visible = true;
                            buttonDoAnotherScan.Visible = false;
                        }
                    }

                    if (doCopy)
                    {
                        DoCopy(_JobOptions);
                    }
                    else
                    {
                        DoFinish(JobTaskResults.Status.Failed);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Form_Main.JobPoolAllValidateTasksComplete() Error: ", Helpers.GetCombinedExceptionText(ex));
                DoFinish(JobTaskResults.Status.Failed);
            }
        }

        /// <summary>
        /// Start Job Pool Copy Tasks
        /// </summary>
        private void DoCopy(JobMoverOptions jobMoverOptions)
        {
            try
            {
                List<ServerInformation> _ServerList = new List<ServerInformation>();
                _ServerList.Add(jobMoverOptions.DestinationServer);

                // Get the jobs to create from the validation process
                jobMoverOptions.Jobs.Clear();
                foreach (JobTaskResults results in _JobTaskResults)
                {
                    jobMoverOptions.Jobs.AddRange(results.JobsToProcess);
                }

                // Clear the validation results before continuing
                _JobTaskResults.Clear();

                _JobPool = new JobPool<JobPoolResults>(10);
                _JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolCopyTaskComplete);
                _JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(JobPoolAllCopyTasksComplete);
                _JobPool.Enqueue(JobMoverRoutines.CreateJobs, _ServerList, ToolsetOptions.commandTimeout, _JobOptions);
                _JobPool.StartAsync();
            }
            catch (Exception ex)
            {
                logger.Error("Form_Main.DoCopy()", Helpers.GetCombinedExceptionText(ex));
                DoFinish(JobTaskResults.Status.Failed);
            }
        }

        private void JobPoolCopyTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Failed)
            {
                _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
            }
            else if (e.Status == TaskStatus.Success)
            {
                if (e.Resultset is JobTaskResults)
                {
                    JobTaskResults results = (JobTaskResults)e.Resultset;
                    _JobTaskResults.Add(results);
                }
                else
                {
                    _ErrorReports.Add(e.Server.Name, string.Format(ProductConstants.ErrorUnknownType, e.Resultset.GetType().ToString()));
                }
            }
        }

        private void JobPoolAllCopyTasksComplete(object sender, JobExecutionEventArgs e)
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

                    DoFinish(JobTaskResults.Status.Success);
                }
                else
                {
                    if (_JobOptions.DeleteSourceJobs)
                    {
                        DoDelete(_JobOptions);
                    }
                    else
                    {
                        Form_Results frm = new Form_Results(Form_Results.ResultsType.Copy);
                        foreach (JobTaskResults results in _JobTaskResults)
                        {
                            foreach (DataRow row in results.Results.Rows)
                            {
                                logger.Info(string.Format(ProductConstants.LogResults, (string)row[JobTaskResults.ColObjectName],
                                               JobData.GetEnumDescription((JobTaskResults.Status)row[JobTaskResults.ColStatus]),
                                               (string)row[JobTaskResults.ColResultsText]));
                                frm.AddResult((string)row[JobTaskResults.ColObjectName],
                                               (JobTaskResults.Status)row[JobTaskResults.ColStatus],
                                               (string)row[JobTaskResults.ColResultsText]);
                            }
                        }

                        BeginInvoke((MethodInvoker)delegate () { frm.ShowDialog(); });

                        DoFinish(JobTaskResults.Status.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("Form_Main.JobPoolAllCopyTasksComplete()", Helpers.GetCombinedExceptionText(ex));
                DoFinish(JobTaskResults.Status.Failed);
            }
        }

        /// <summary>
        /// Start Job Pool Delete Tasks
        /// </summary>
        private void DoDelete(JobMoverOptions jobMoverOptions)
        {
            try
            {
                List<ServerInformation> _ServerList = new List<ServerInformation>();
                _ServerList.Add(jobMoverOptions.SourceServer);

                // Get the jobs to create from the validation process
                _JobOptions.Jobs.Clear();
                foreach (JobTaskResults results in _JobTaskResults)
                {
                    foreach (Job job in results.JobsToProcess)
                        _JobOptions.Jobs.AddRange(results.JobsToProcess);
                }

                // Do NOT clear the copy results before continuing

                _JobPool = new JobPool<JobPoolResults>(10);
                _JobPool.ServerTaskComplete += new EventHandler<JobExecutionResultsEventArgs>(JobPoolDeleteTaskComplete);
                _JobPool.TaskComplete += new EventHandler<JobExecutionEventArgs>(JobPoolAllDeleteTasksComplete);
                _JobPool.Enqueue(JobMoverRoutines.DeleteJobs, _ServerList, ToolsetOptions.commandTimeout, _JobOptions);
                _JobPool.StartAsync();
            }
            catch (Exception ex)
            {
                logger.Error("Form_Main.DoDelete()", Helpers.GetCombinedExceptionText(ex));
                DoFinish(JobTaskResults.Status.Failed);
            }
        }

        private void JobPoolDeleteTaskComplete(object sender, JobExecutionResultsEventArgs e)
        {
            if (e.Status == TaskStatus.Failed)
            {
                _ErrorReports.Add(e.Server.Name, e.ErrorMessage);
            }
            else if (e.Status == TaskStatus.Success)
            {
                if (e.Resultset is JobTaskResults)
                {
                    JobTaskResults results = (JobTaskResults)e.Resultset;
                    _JobTaskResults.Add(results);
                }
                else
                {
                    _ErrorReports.Add(e.Server.Name, string.Format(ProductConstants.ErrorUnknownType, e.Resultset.GetType().ToString()));
                }
            }
        }

        private void JobPoolAllDeleteTasksComplete(object sender, JobExecutionEventArgs e)
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
                else
                {
                    Form_Results frm = new Form_Results(Form_Results.ResultsType.Copy);
                    foreach (JobTaskResults results in _JobTaskResults)
                    {
                        foreach (DataRow row in results.Results.Rows)
                        {
                            logger.Info(ProductConstants.LogResults, (string)row[JobTaskResults.ColObjectName],
                                           (JobTaskResults.Status)row[JobTaskResults.ColStatus],
                                           (string)row[JobTaskResults.ColResultsText]);
                            frm.AddResult((string)row[JobTaskResults.ColObjectName],
                                           (JobTaskResults.Status)row[JobTaskResults.ColStatus],
                                           (string)row[JobTaskResults.ColResultsText]);
                        }
                    }

                    BeginInvoke((MethodInvoker)delegate () { frm.ShowDialog(); });
                }

                DoFinish(JobTaskResults.Status.Success);
            }
            catch (Exception ex)
            {
                logger.Error("Form_Main.JobPoolAllCopyTasksComplete()", Helpers.GetCombinedExceptionText(ex));
                DoFinish(JobTaskResults.Status.Failed);
            }
        }

        private void DoFinish(JobTaskResults.Status status)
        {
            // Clean up after finished processing
            if (status == JobTaskResults.Status.Success)
            {
                SetStepStatus(TaskStep.CompleteSuccess, ToolProgressListMini.StepStatus.OK);
                buttonBack.Visible = false;
            }
            else
            {
                SetStepStatus(TaskStep.CompleteFailed, ToolProgressListMini.StepStatus.Error);
                buttonBack.Visible = true;
            }

            buttonDoAnotherScan.Visible = !buttonBack.Visible;
            buttonClose.Enabled = true;

            Cursor = Cursors.Default;
        }

        #endregion

        #region Status display

        private void LoadSteps(List<TaskStep> steps)
        {
            for (int i = 0; i < steps.Count; i++)
            {
                _LoadedSteps.Add(steps[i]);
                ProgressList.SetStepText(i + 1, JobData.GetEnumDescription(steps[i]));
            }

            ProgressList.NumberOfSteps = steps.Count;

            if (steps.Count < 6)
            {
                for (int i = steps.Count + 1; i <= 6; i++)
                {
                    ProgressList.SetStepText(i, string.Empty);
                }
            }

            ProgressList.SetStepStatus(1, ToolProgressListMini.StepStatus.Working);
        }

        private bool SetStepStatus(TaskStep step, ToolProgressListMini.StepStatus status)
        {
            if (_LoadedSteps.Exists(delegate (TaskStep moverStep) { return moverStep == step; }))
            {
                int _Index = _LoadedSteps.FindIndex(delegate (TaskStep moverStep) { return moverStep == step; });
                ProgressList.SetStepStatus(_Index + 1, status);
                return true;
            }
            return false;
        }

        private void UpdateTaskStatus(object sender, TaskStatusEventArgs e)
        {
            UpdateTaskLog(e.Description);
            if (e.Step == TaskStep.CompleteFailed)
            {
                SetStepStatus(_CurrentStep, ToolProgressListMini.StepStatus.Error);
            }
            else if (e.Step != _CurrentStep || e.Step == TaskStep.CompleteSuccess)
            {
                SetStepStatus(_CurrentStep, ToolProgressListMini.StepStatus.OK);
                _CurrentStep = e.Step;
                SetStepStatus(e.Step, ToolProgressListMini.StepStatus.Working);
            }
        }

        delegate void TaskLogUpdateDelegate(string value);

        private void UpdateTaskLog(string value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new TaskLogUpdateDelegate(UpdateTaskLog), new object[] { value });
                return;
            }
            textTaskLog.Text += DateTime.Now.ToLongTimeString() + ": " + value + Environment.NewLine;
        }

        #endregion

        private void ChangeWizardPage(WizardPage newPage)
        {
            WizardJobMove.SelectedPage = newPage;
        }

        #endregion

        #region Events

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

            // Program Specific Logic
            ResetValues();

            WizardJobMove.BringToFront();
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

        #region SQL Server & Credentials Field Handling

        private void buttonBrowseSourceServer_Click(object sender, EventArgs e)
        {
            string selectedServer = BrowseServer();
            if (textSourceServer.Text != selectedServer && selectedServer != string.Empty)
            {
                textSourceServer.Text = selectedServer;
                _SourceServer = null;
                _JobsToMove.Clear();
            }
        }

        private void buttonBrowseDestinationServer_Click(object sender, EventArgs e)
        {
            string selectedServer = BrowseServer();
            if (textDestinationServer.Text != selectedServer && selectedServer != string.Empty)
            {
                textDestinationServer.Text = selectedServer;
                _DestinationServer = null;
            }
        }

        private void buttonSourceCredentials_Click(object sender, EventArgs e)
        {
            bool _WindowsAuthentication = (_SourceServerSqlCredentials == null) ? true : _SourceServerSqlCredentials.useWindowsAuthentication;
            string _LoginName = (_SourceServerSqlCredentials == null) ? null : _SourceServerSqlCredentials.loginName;
            string _Password = (_SourceServerSqlCredentials == null) ? null : _SourceServerSqlCredentials.password;

            Form_Credentials credentialsForm = new Form_Credentials(textSourceServer.Text, _SourceServerSqlCredentials);
            DialogResult choice = credentialsForm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                if (_SourceServerSqlCredentials != credentialsForm.sqlCredentials ||
                     _WindowsAuthentication != credentialsForm.sqlCredentials.useWindowsAuthentication ||
                     _LoginName != credentialsForm.sqlCredentials.loginName ||
                     _Password != credentialsForm.sqlCredentials.password)
                {
                    _SourceServerSqlCredentials = credentialsForm.sqlCredentials;
                    _SourceServer = null;
                    _JobsToMove.Clear();
                }
            }
        }

        private void buttonDestinationCredentials_Click(object sender, EventArgs e)
        {
            bool _WindowsAuthentication = (_DestinationServerSqlCredentials == null) ? true : _DestinationServerSqlCredentials.useWindowsAuthentication;
            string _LoginName = (_DestinationServerSqlCredentials == null) ? null : _DestinationServerSqlCredentials.loginName;
            string _Password = (_DestinationServerSqlCredentials == null) ? null : _DestinationServerSqlCredentials.password;

            Form_Credentials credentialsForm = new Form_Credentials(textDestinationServer.Text, _DestinationServerSqlCredentials);
            DialogResult choice = credentialsForm.ShowDialog();
            if (choice == DialogResult.OK)
            {
                if (_DestinationServerSqlCredentials != credentialsForm.sqlCredentials ||
                     _WindowsAuthentication != credentialsForm.sqlCredentials.useWindowsAuthentication ||
                     _LoginName != credentialsForm.sqlCredentials.loginName ||
                     _Password != credentialsForm.sqlCredentials.password)
                {
                    _DestinationServerSqlCredentials = credentialsForm.sqlCredentials;
                    _DestinationServer = null;
                }
            }

           
        }

       

        private void textSourceServer_Leave(object sender, EventArgs e)
        {
            if (WizardJobMove.SelectedPage == pageServerInformation)
            {
                if (_SourceServerCachedValue != textSourceServer.Text)
                {
                    _SourceServer = null;
                    _JobsToMove.Clear();
                }
            }
        }

        private void textDestinationServer_Leave(object sender, EventArgs e)
        {
            //if (WizardJobMove.SelectedPage == pageServerInformation)
            //{
            //   if (_DestinationServerCachedValue != textDestinationServer.Text)
            //   {
            //      _DestinationServer = null;
            //      _JobsToMove.Clear();
            //      if (comboBoxOwners.Items.Count > 0)
            //      {
            //         comboBoxOwners.Items.Clear();
            //      }
            //      if (comboBoxDatabases.Items.Count > 0)
            //      {
            //         comboBoxDatabases.Items.Clear();
            //      }
            //   }
            //}
        }

        #endregion

        #region Wizard functionality

        #region Navigation

        private void WizardJobMove_CancelButtonClick(object sender, CancelEventArgs e)
        {
            Wizard wiz = (Wizard)sender;

            if (Messaging.ShowConfirmation(string.Format(ProductConstants.PromptExitApplication, CoreGlobals.productName)) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void WizardJobMove_FinishButtonClick(object sender, CancelEventArgs e)
        {
            panelResults.BringToFront();

            pageSummary.BackButtonEnabled =
               pageSummary.CancelButtonEnabled =
               pageSummary.NextButtonEnabled =
               pageSummary.FinishButtonEnabled =
               DevComponents.DotNetBar.eWizardButtonState.False;
            Application.DoEvents();

            //JobMetaInfo.CheckJobInput(checkBoxEnable.Checked, checkBoxDisable.Checked);

            DoGetSourceInfo(GetInfoType.Copy);
        }

        private void WizardJobMove_WizardPageChanged(object sender, WizardPageChangeEventArgs e)
        {
            if (e.NewPage == pageWelcome || e.NewPage == pageSelectTask)
            {
                WizardJobMove.CancelButtonText = ProductConstants.CancelButtonExit;
            }
            else
            {
                WizardJobMove.CancelButtonText = ProductConstants.CancelButtonCancel;

                if (e.NewPage == pageServerInformation)
                {
                    textSourceServer.Select();
                }
            }
            if (e.NewPage == pageWelcome)
            {
                labelSelectOperation.Size = new System.Drawing.Size(138, 20);
                labelSelectOperation.ForeColor = System.Drawing.Color.SteelBlue;
                labelSelectOperation.Font = new Font(labelSelectOperation.Font.Name, 11);
                labelSourceDes.ForeColor = System.Drawing.Color.SteelBlue;
                labelSourceDes.Font = new Font(labelSourceDes.Font.Name, 11);
                labelJobOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelJobOptions.Font = new Font(labelJobOptions.Font.Name, 11);
                labelDesOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelDesOptions.Font = new Font(labelDesOptions.Font.Name, 11);
                labelSummary.ForeColor = System.Drawing.Color.SteelBlue;
                labelSummary.Font = new Font(labelSummary.Font.Name, 11);
            }
            if (e.NewPage == pageSelectTask)
            {
                labelSelectOperation.Size = new System.Drawing.Size(138, 20);
                labelSelectOperation.ForeColor = System.Drawing.Color.Black;
                //labelSelectOperation.Font = new Font(labelSelectOperation.Font.Name, 11, FontStyle.Bold | FontStyle.Underline);
                labelSelectOperation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold | FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelSourceDes.ForeColor = System.Drawing.Color.SteelBlue;
                labelSourceDes.Font = new Font(labelSourceDes.Font.Name, 11);
                labelJobOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelJobOptions.Font = new Font(labelJobOptions.Font.Name, 11);
                labelDesOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelDesOptions.Font = new Font(labelDesOptions.Font.Name, 11);
                labelSummary.ForeColor = System.Drawing.Color.SteelBlue;
                labelSummary.Font = new Font(labelSummary.Font.Name, 11);
            }
            else if (e.NewPage == pageServerInformation)
            {
                labelSourceDes.ForeColor = System.Drawing.Color.Black;
                // labelSourceDes.Font = new Font(labelSourceDes.Font.Name, 11, FontStyle.Bold | FontStyle.Underline);
                labelSourceDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold | FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelSelectOperation.ForeColor = System.Drawing.Color.SteelBlue;
                labelSelectOperation.Font = new Font(labelSelectOperation.Font.Name, 11);
                labelJobOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelJobOptions.Font = new Font(labelJobOptions.Font.Name, 11);
                labelDesOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelDesOptions.Font = new Font(labelDesOptions.Font.Name, 11);
                labelSummary.ForeColor = System.Drawing.Color.SteelBlue;
                labelSummary.Font = new Font(labelSummary.Font.Name, 11);
            }
            else if (e.NewPage == pageSelectJobs)
            {
                labelJobOptions.ForeColor = System.Drawing.Color.Black;
                //labelJobOptions.Font = new Font(labelJobOptions.Font.Name, 11, FontStyle.Bold | FontStyle.Underline);
                labelJobOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold | FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelSelectOperation.ForeColor = System.Drawing.Color.SteelBlue;
                labelSelectOperation.Font = new Font(labelSelectOperation.Font.Name, 11);
                labelSourceDes.ForeColor = System.Drawing.Color.SteelBlue;
                labelSourceDes.Font = new Font(labelSourceDes.Font.Name, 11);
                labelDesOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelDesOptions.Font = new Font(labelDesOptions.Font.Name, 11);
                labelSummary.ForeColor = System.Drawing.Color.SteelBlue;
                labelSummary.Font = new Font(labelSummary.Font.Name, 11);
            }
            else if (e.NewPage == pageTargetOptions)
            {
                labelDesOptions.ForeColor = System.Drawing.Color.Black;
                //labelDesOptions.Font = new Font(labelDesOptions.Font.Name, 11, FontStyle.Bold | FontStyle.Underline);
                labelDesOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold | FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelSelectOperation.ForeColor = System.Drawing.Color.SteelBlue;
                labelSelectOperation.Font = new Font(labelSelectOperation.Font.Name, 11);
                labelJobOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelJobOptions.Font = new Font(labelJobOptions.Font.Name, 11);
                labelSourceDes.ForeColor = System.Drawing.Color.SteelBlue;
                labelSourceDes.Font = new Font(labelSourceDes.Font.Name, 11);
                labelSummary.ForeColor = System.Drawing.Color.SteelBlue;
                labelSummary.Font = new Font(labelSummary.Font.Name, 11);
            }
            else if (e.NewPage == pageSummary)
            {
                labelSummary.ForeColor = System.Drawing.Color.Black;
                // labelSummary.Font = new Font(labelSummary.Font.Name, 10, FontStyle.Bold | FontStyle.Underline);
                labelSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Bold | FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                labelSelectOperation.ForeColor = System.Drawing.Color.SteelBlue;
                labelSelectOperation.Font = new Font(labelSelectOperation.Font.Name, 11);
                labelJobOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelJobOptions.Font = new Font(labelJobOptions.Font.Name, 11);
                labelDesOptions.ForeColor = System.Drawing.Color.SteelBlue;
                labelDesOptions.Font = new Font(labelDesOptions.Font.Name, 11);
                labelSourceDes.ForeColor = System.Drawing.Color.SteelBlue;
                labelSourceDes.Font = new Font(labelSourceDes.Font.Name, 11);
            }

        }

        private void WizardJobMove_WizardPageChanging(object sender, WizardCancelPageChangeEventArgs e)
        {
            if (e.PageChangeSource == DevComponents.DotNetBar.eWizardPageChangeSource.NextButton)
            {
                if (e.OldPage == pageSelectTask)
                {
                    e.NewPage = pageServerInformation;
                    if (optionCopyJobs.Checked)
                    {
                        _Task = TaskToPerform.CopyJobsToDifferentServer;
                        checkBoxOverwrite.Enabled = true;
                    }
                    else if (OptionMoveJobs.Checked)
                    {
                        _Task = TaskToPerform.MoveJobsToDifferentServer;
                        checkBoxOverwrite.Enabled = true;
                    }
                    else if (OptionCopyJobsLocal.Checked)
                    {
                        _Task = TaskToPerform.CopyJobsToSameServer;
                        checkBoxOverwrite.Enabled =
                           checkBoxOverwrite.Checked = false;
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                else if (e.OldPage == pageServerInformation)
                {
                    //if ((_Task == TaskToPerform.CopyJobsToDifferentServer) && (_SourceServer.Name == _DestinationServer.Name))  //same server instance
                    //{
                    //   _Task = TaskToPerform.CopyJobsToSameServer;
                    //}
                }
            }
        }

        #endregion

        #region Select Task

        private void pageSelectTask_BeforePageDisplayed(object sender, WizardCancelPageChangeEventArgs e)
        {
            if (e.PageChangeSource == eWizardPageChangeSource.Code && e.OldPage == pageSummary)
            {
                e.NewPage.BackButtonVisible = eWizardButtonState.False;
            }
        }

        #endregion

        #region Servers

        private void pageServerInformation_BeforePageDisplayed(object sender, WizardCancelPageChangeEventArgs e)
        {
            if (_Task == TaskToPerform.CopyJobsToSameServer)
            {
                labelDestinationServer.Visible = false;
                textDestinationServer.Visible = false;
                buttonBrowseDestinationServer.Visible = false;
                buttonDestinationCredentials.Visible = false;

                labelSourceServer.Text = ProductConstants.SourceServerLabel;

                pageServerInformation.PageTitle = ProductConstants.ServerPageTitleSame;
                pageServerInformation.PageDescription = ProductConstants.ServerPageDescrSame;
            }
            else
            {
                labelDestinationServer.Visible = true;
                textDestinationServer.Visible = true;
                buttonBrowseDestinationServer.Visible = true;
                buttonDestinationCredentials.Visible = true;

                labelSourceServer.Text = string.Format(ProductConstants.DifferentSourceFmt, ProductConstants.SourceServerLabel);

                pageServerInformation.PageTitle = ProductConstants.ServerPageTitle;
                pageServerInformation.PageDescription = ProductConstants.ServerPageDescr;
            }
        }

        private void pageServerInformation_NextButtonClick(object sender, CancelEventArgs e)
        {
            try
            {
                if (textSourceServer.Text.Trim().Length == 0)
                {
                    Messaging.ShowError(ProductConstants.PromptMustSpecifySourceServer);
                    e.Cancel = true;
                    return;
                }

                // Fix problem with hitting enter when in Source Server field and not resetting server correctly
                if (_SourceServerCachedValue != textSourceServer.Text)
                {
                    _SourceServer = null;
                }

                // Fix problem with hitting enter when in Destination Server field and not resetting server correctly
                if (_DestinationServerCachedValue != textDestinationServer.Text)
                {
                    _DestinationServer = null;
                }

                if (_Task == TaskToPerform.CopyJobsToSameServer)
                {
                    if (textSourceServer.Text.Trim().Length > 0 && _SourceServer == null)
                    {
                        InitializeServer(ref _SourceServer, textSourceServer.Text, _SourceServerSqlCredentials);
                    }
                    InitializeServer(ref _DestinationServer, _SourceServer.Name, _SourceServerSqlCredentials);

                }
                else
                {
                    if (textDestinationServer.Text.Trim().Length == 0)
                    {
                        Messaging.ShowError(ProductConstants.PromptMustSpecifyDestinationServer);
                        e.Cancel = true;
                        return;
                    }

                    if (_SourceServer == null || _DestinationServer == null)
                    {
                        InitializeServers();
                    }

                    if (!JobMoverRoutines.IsValidOperation(_SourceServer, _DestinationServer))
                    {
                        Messaging.ShowError(ProductConstants.ErrorNotSupportedSqlCombination);
                        e.Cancel = true;
                        return;
                    }

                    if (_SourceServer.Name == _DestinationServer.Name)
                    {
                        Messaging.ShowError(ProductConstants.PromptSqlInstancesMustBeDifferent);
                        e.Cancel = true;
                        return;
                    }
                }
                JobSteps.ServerName = textDestinationServer.Text;
            }
            catch (Exception ex)
            {
                Messaging.ShowException(ProductConstants.ActionServer, ex);
                e.Cancel = true;
            }
        }

        #endregion

        #region Select Jobs

        private void pageSelectJobs_BeforePageDisplayed(object sender, WizardCancelPageChangeEventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                if (e.PageChangeSource == eWizardPageChangeSource.NextButton)
                {
                    _Jobs.Clear();
                    _SelectedJobs.Clear();
                    ListJobs.Items.Clear();
                    _SourceServerCachedValue = _SourceServer.Name;

                    // cant show loading until we figure out how to stop it from flashing when tab first appears
                    //if ( labelJobListMessage.Visible != true )
                    //{
                    //   labelJobListMessage.Visible = true;
                    //}
                    //labelJobListMessage.Text = ProductConstants.PromptLoading;
                    //Application.DoEvents();

                    DoGetSourceInfo(GetInfoType.Select);
                }

                if (ListJobs.CheckedItems.Count > 0)
                {
                    pageSelectJobs.NextButtonEnabled = eWizardButtonState.True;
                }
                else
                {
                    pageSelectJobs.NextButtonEnabled = eWizardButtonState.False;
                }
            }
            catch (Exception ex)
            {
                logger.Error("pageSelectJobs_BeforePageDisplayed:", Helpers.GetCombinedExceptionText(ex));
                Messaging.ShowException("Get source server information", ex);

                Cursor = Cursors.Default;      // fix the cursor if something goes wrong. Otherwise it is fixed after job pool finishes
            }
        }

        private void pageSelectJobs_NextButtonClick(object sender, CancelEventArgs e)
        {
            SelectedJobs.Clear();
            ListDisableJobs.Items.Clear();
            _SelectedJobs.Clear();
            int count=0;
            foreach (Object _Item in ListJobs.CheckedItems)
            {
                _SelectedJobs.Add((Job)_Item);
                Job job = (Job)_Item;
                
                if (job.MetaInfo.Enabled == false)
                {
                    ListDisableJobs.Items.Add((Job)_Item);
                    ListDisableJobs.SetItemCheckState(count, CheckState.Checked);
                }
                else
                {
                    //ListDisableJobs.SetItemCheckState(count++, CheckState.Unchecked);
                    ListDisableJobs.Items.Add((Job)_Item);
                }
               
                count++;
            }
        }
        #endregion

        #region Source Options

        private void pageSourceOptions_BeforePageDisplayed(object sender, WizardCancelPageChangeEventArgs e)
        {

        }

        #endregion

        #region Target Options

        private void pageTargetOptions_BeforePageDisplayed(object sender, WizardCancelPageChangeEventArgs e)
        {
            //if (_Task == TaskToPerform.CopyJobsToSameServer)
            //{
            //   checkBoxCreateSchedule.Enabled = true;
            //}
            //else
            //{
            //   checkBoxCreateSchedule.Checked = true;
            //   checkBoxCreateSchedule.Enabled = false;
            //}

            checkBoxCreateSchedule.Checked = true;

            JobPoolOptions options = new JobPoolOptions();
            DataTable dtOwners = JobMoverRoutines.LoadJobOwners(_DestinationServer, ToolsetOptions.commandTimeout, options);
            dtOwners.DefaultView.Sort = JobData.NameList.ColName;

            string selected = comboBoxOwners.Text;
            bool found = false;

            comboBoxOwners.Items.Clear();
            comboBoxOwners.Text = string.Empty;
            foreach (DataRowView row in dtOwners.DefaultView)
            {
                string jobName = (string)row[JobData.NameList.ColName];
                comboBoxOwners.Items.Add(jobName);
                if (jobName == selected)
                {
                    found = true;
                }
            }
            if (!found)
            {
                selected = string.Empty;
            }

            if (selected.Length == 0)
            {
                comboBoxOwners.Text = JobMoverRoutines.LoadAdminName(_DestinationServer, ToolsetOptions.commandTimeout, options);
            }
            else
            {
                comboBoxOwners.SelectedIndex = comboBoxOwners.FindStringExact(selected);
            }

            DataTable dtDatabases = JobMoverRoutines.LoadDatabases(_DestinationServer, ToolsetOptions.commandTimeout, options);
            dtDatabases.DefaultView.Sort = JobData.NameList.ColName;

            selected = comboBoxDatabases.Text;
            found = false;

            comboBoxDatabases.Items.Clear();
            comboBoxDatabases.Text = string.Empty;
            foreach (DataRowView row in dtDatabases.DefaultView)
            {
                string dbName = (string)row[JobData.NameList.ColName];
                comboBoxDatabases.Items.Add(dbName);
                if (dbName == selected)
                {
                    found = true;
                }
            }
            if (!found)
            {
                selected = string.Empty;
            }

            if (selected.Length > 0)
            {
                comboBoxDatabases.SelectedIndex = comboBoxDatabases.FindStringExact(selected);
            }

            _DestinationServerCachedValue = _DestinationServer.Name;
        }

        private void pageTargetOptions_NextButtonClick(object sender, CancelEventArgs e)
        {
            List<Job> Jobs = new List<Job>();

            foreach (var _Item in ListDisableJobs.CheckedItems)
            {
                Job job = (Job)_Item;
                job.MetaInfo.Enabled = false;
                Jobs.Add(job);

            }
            foreach (var _Item in ListDisableJobs.Items)
            {
                Job job = (Job)_Item;
                if (!Jobs.ToList().Any(x => x.JobId == job.JobId))
                {
                    job.MetaInfo.Enabled = true;
                    Jobs.Add(job);
                }
            }
            SelectedJobs.AddRange(Jobs);

            //if (checkBoxEnable.Checked == false && checkBoxDisable.Checked == false)
            //{
            //    if (Messaging.ShowConfirmation(string.Format("Please choose to enable or disable copied jobs on the target server", CoreGlobals.productName)) == DialogResult.No)
            //    {
            //        e.Cancel = true;
            //    }
            //}

            if (checkBoxAlwaysUseOwner.Checked && comboBoxOwners.Text.Length == 0)
            {
                Messaging.ShowError(ProductConstants.ErrorMissingDefaultOwner);
                e.Cancel = true;
            }
        }

        #endregion

        #region Summary

        private void pageSummary_BeforePageDisplayed(object sender, WizardCancelPageChangeEventArgs e)
        {
            switch (_Task)
            {
                case TaskToPerform.CopyJobsToDifferentServer:
                    LabelSummaryOperationTypeValue.Text = string.Format(ProductConstants.SummaryTaskCopyJobsToDifferentServer, _SelectedJobs.Count, _SelectedJobs.Count == 1 ? string.Empty : "s");
                    break;
                case TaskToPerform.CopyJobsToSameServer:
                    LabelSummaryOperationTypeValue.Text = string.Format(ProductConstants.SummaryTaskCopyJobsToSameServer, _SelectedJobs.Count, _SelectedJobs.Count == 1 ? string.Empty : "s");
                    break;
                case TaskToPerform.MoveJobsToDifferentServer:
                    LabelSummaryOperationTypeValue.Text = string.Format(ProductConstants.SummaryTaskMoveJobsToDifferentServer, _SelectedJobs.Count, _SelectedJobs.Count == 1 ? string.Empty : "s");
                    break;
            }

            LabelSummarySourceServerValue.Text = textSourceServer.Text;
            LabelSummaryDestinationServerValue.Text = textDestinationServer.Text;

            StringBuilder optionText = new StringBuilder();

            if (checkboxIncludeSchedule.Checked)
            {
                optionText.Append("Include schedules");
            }
            if (checkBoxIncludeNotifications.Checked)
            {
                if (optionText.Length > 0)
                {
                    optionText.Append(Environment.NewLine);
                }
                optionText.Append("Include notifications");
            }
            if (_Task == TaskToPerform.MoveJobsToDifferentServer)
            {
                if (optionText.Length > 0)
                {
                    optionText.Append(Environment.NewLine);
                }
                optionText.Append("Delete jobs after copy");
            }
            LabelSummarySourceOptionsValue.Text = optionText.ToString();

            optionText.Length = 0;
            if (checkBoxCreateCategory.Checked)
            {
                optionText.Append("Create categories");
            }
            if (checkBoxCreateSchedule.Checked)
            {
                optionText.Append(optionText.Length == 0 ? "Create" : (checkBoxCreateOperators.Checked ? ", " : " and "));
                optionText.Append(" schedules");
            }
            if (checkBoxCreateOperators.Checked)
            {
                optionText.Append(optionText.Length == 0 ? "Create" : " and ");
                optionText.Append(" operators");
            }
            if (checkBoxOverwrite.Checked)
            {
                if (optionText.Length > 0)
                {
                    optionText.Append(Environment.NewLine);
                }
                optionText.Append(checkBoxOverwrite.Text);
            }
            if (comboBoxOwners.Text.Length > 0)
            {
                if (optionText.Length > 0)
                {
                    optionText.Append(Environment.NewLine);
                }
                optionText.Append("Set job owner to '");
                optionText.Append(comboBoxOwners.Text);
                optionText.Append("'");
                if (!checkBoxAlwaysUseOwner.Checked)
                {
                    optionText.Append(" if owner not found");
                }
            }
            if (comboBoxDatabases.Text.Length > 0)
            {
                if (optionText.Length > 0)
                {
                    optionText.Append(Environment.NewLine);
                }
                optionText.Append("Set job steps to use database '");
                optionText.Append(comboBoxDatabases.Text);
                optionText.Append("'");
            }

            LabelSummaryTargetOptionsValue.Text = optionText.ToString();
        }

        #endregion

        #endregion

        private void linkSelectAllJobs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < ListJobs.Items.Count; i++)
            {
                ListJobs.SetItemCheckState(i, CheckState.Checked);
            }
        }
        private void linkSelectAllDisableJobs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < ListDisableJobs.Items.Count; i++)
            {
                ListDisableJobs.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void linkClearAllJobs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < ListJobs.Items.Count; i++)
            {
                ListJobs.SetItemCheckState(i, CheckState.Unchecked);
            }
            pageSelectJobs.NextButtonEnabled = eWizardButtonState.False;
        }
        private void linkClearAllDisableJobs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for (int i = 0; i < ListDisableJobs.Items.Count; i++)
            {
                ListDisableJobs.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private void ListJobs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (ListJobs.SelectedItems.Count > 0)
            {
                pageSelectJobs.NextButtonEnabled = eWizardButtonState.True;
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    pageSelectJobs.NextButtonEnabled = eWizardButtonState.True;
                }
                else
                {
                    pageSelectJobs.NextButtonEnabled = eWizardButtonState.False;
                }
            }
        }

        #region Results Panel

        private void buttonBack_Click(object sender, EventArgs e)
        {
            ChangeWizardPage(pageSummary);

            pageSummary.BackButtonEnabled =
               pageSummary.CancelButtonEnabled =
               pageSummary.NextButtonEnabled =
               pageSummary.FinishButtonEnabled =
               DevComponents.DotNetBar.eWizardButtonState.True;

            WizardJobMove.BringToFront();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (Messaging.ShowConfirmation(string.Format(ProductConstants.PromptExitApplication, CoreGlobals.productName)) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void buttonDoAnotherScan_Click(object sender, EventArgs e)
        {
            if (Messaging.ShowConfirmation(ProductConstants.PromptResetWizardValues) == DialogResult.Yes)
            {
                ResetValues();
            }
            else
            {
                buttonDoAnotherScan.Enabled = false;
                Cursor = Cursors.WaitCursor;
                Application.DoEvents();
                buttonDoAnotherScan.Enabled = true;
                ResetDynamicValues();
                Cursor = Cursors.Default;
            }

            ChangeWizardPage(pageSelectTask);
            WizardJobMove.BringToFront();
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
    }
}

