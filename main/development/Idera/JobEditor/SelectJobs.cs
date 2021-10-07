using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;

namespace Idera.SqlAdminToolset.JobEditor
{
    public partial class SelectJobs : Form
    {
        #region fields

        private DataTable jobList;

        #endregion

        #region constructors

        private SelectJobs(DataTable joblist, JobSelections jobselections)
        {
            InitializeComponent();

            jobList = joblist;

            // fill the previous selections
            comboBoxName.Text = jobselections.JobName;

            if (jobselections.Enabled.HasValue)
            {
                comboBoxEnabled.Text = JobData.GetEnumDescription(jobselections.Enabled.Value);
            }

            comboBoxCategory.Text = jobselections.Category;

            comboBoxOwner.Text = jobselections.Owner;

            comboBoxOutcome.Text = jobselections.Outcome;

            if (jobselections.Timeframe.HasValue)
            {
                try
                {
                    comboBoxjobdayhour.Text = JobData.GetEnumDescription(jobselections.JobstatusText.Value);
                }
                catch (Exception)
                {

                    comboBoxjobdayhour.Text = "";
                }
               
            }

            numericUpDown1.Value = jobselections.Jobstatusvalue;

            if (jobselections.Timeframe.HasValue)
            {
                comboBoxLastRun.Text = JobData.GetEnumDescription(jobselections.Timeframe.Value);
            }

            if (jobselections.Notification.HasValue)
            {
                comboBoxNotification.Text = JobData.GetEnumDescription(jobselections.Notification.Value);
            }

            checkBoxClearSelections.Checked = jobselections.ClearPreviousSelections;

            // set the buttons based on values
            CheckSelections();
        }

        #endregion

        #region properties

        public JobSelections Selections;

        #endregion

        #region helpers

        private void CheckSelections()
        {
            buttonOk.Enabled =
               (comboBoxName.Text.Length > 0)
               || (comboBoxEnabled.Text.Length > 0)
               || (comboBoxCategory.Text.Length > 0)
               || (comboBoxOwner.Text.Length > 0)
               || (comboBoxjobdayhour.Text.Length > 0)
               || (comboBoxOutcome.Text.Length > 0)
               || (comboBoxLastRun.Text.Length > 0)
               || (comboBoxNotification.Text.Length > 0);
        }

        private void ClearSelectionValues()
        {
            numericUpDown1.Value = 1;
            //Clears values for editable dropdowns
            comboBoxName.Text =
               comboBoxCategory.Text =
               comboBoxOwner.Text =
               comboBoxOutcome.Text = comboBoxjobdayhour.Text= string.Empty;

            //Clears values fom dropdownlists and resets watermarks
            comboBoxName.SelectedIndex =
              comboBoxCategory.SelectedIndex =
              comboBoxOwner.SelectedIndex =
              comboBoxOutcome.SelectedIndex =
              comboBoxEnabled.SelectedIndex =
              comboBoxLastRun.SelectedIndex =
              comboBoxNotification.SelectedIndex = comboBoxjobdayhour.SelectedIndex = -1;
        }

        private JobSelections GetSelectionValues()
        {
            //validate the selections before returning
            JobSelections selections = new JobSelections();

            selections.SetJobName(comboBoxName.Text);
            selections.SetEnabled(((ComboItem)comboBoxEnabled.SelectedItem == null) ? null :
               (int?)((ComboItem)comboBoxEnabled.SelectedItem).Tag);
            selections.SetCategory(comboBoxCategory.Text);
            selections.SetOwner(comboBoxOwner.Text);
            selections.SetOutcome(comboBoxOutcome.Text);
           selections.SetJobStatusValue(Convert.ToInt32(numericUpDown1.Value));
           selections.SetJobStatusText(((ComboItem)comboBoxjobdayhour.SelectedItem == null) ? null :
               (int?)((ComboItem)comboBoxjobdayhour.SelectedItem).Tag);
            selections.SetTimeframe(((ComboItem)comboBoxLastRun.SelectedItem == null) ? null :
               (int?)((ComboItem)comboBoxLastRun.SelectedItem).Tag);
            selections.SetNotification(((ComboItem)comboBoxNotification.SelectedItem == null) ? null :
               (int?)((ComboItem)comboBoxNotification.SelectedItem).Tag);

            selections.ClearPreviousSelections = checkBoxClearSelections.Checked;
            selections.CaseSensitive = checkBoxCaseSensitive.Checked;

            return selections;
        }

        #endregion

        #region event handlers

        #region button actions

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearSelectionValues();
            CheckSelections();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Selections = GetSelectionValues();
        }

        #endregion

        #region combo box events

        private void comboBoxName_DropDown(object sender, EventArgs e)
        {
            JobRoutines.FillComboBoxFromJobList((ComboBoxEx)sender, jobList, JobData.JobList.ColJobName);
        }

        private void comboBoxEnabled_DropDown(object sender, EventArgs e)
        {
            JobRoutines.FillComboBoxFromEnum((ComboBoxEx)sender, typeof(JobData.JobEnabled), false);
        }

        private void comboBoxCategory_DropDown(object sender, EventArgs e)
        {
            JobRoutines.FillComboBoxFromJobList((ComboBoxEx)sender, jobList, JobData.JobList.ColCategory);
        }

        private void comboBoxOwner_DropDown(object sender, EventArgs e)
        {
            JobRoutines.FillComboBoxFromJobList((ComboBoxEx)sender, jobList, JobData.JobList.ColOwner);
        }

        private void comboBoxOutcome_DropDown(object sender, EventArgs e)
        {
            JobRoutines.FillComboBoxFromEnum((ComboBoxEx)sender, typeof(JobData.JobOutcome), false);
        }

        private void comboBoxjobdayhour_DropDown(object sender, EventArgs e)
        {
            JobRoutines.FillComboBoxFromEnum((ComboBoxEx)sender, typeof(JobData.JobLastRun), true);
        }

        private void comboBoxLastRun_DropDown(object sender, EventArgs e)
        {
            JobRoutines.FillComboBoxFromEnum((ComboBoxEx)sender, typeof(JobData.JobTimeframe), true);
        }

        private void comboBoxNotification_DropDown(object sender, EventArgs e)
        {
            JobRoutines.FillComboBoxFromEnum((ComboBoxEx)sender, typeof(JobData.NotifyType), true);
        }

        private void comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            // This event handler is common to all comboboxes
            ComboBox comboBox = ((ComboBox)sender);

            // Allow removing the selected value with the Delete Key or, also the Backspace Key if it is a forced selection list
            if (e.KeyCode == Keys.Delete || (comboBox.DropDownStyle == ComboBoxStyle.DropDownList && e.KeyCode == Keys.Back))
            {
                comboBox.Text = null;
            }
        }

        private void comboBox_TextChanged(object sender, EventArgs e)
        {
            // This event handler is common to all comboboxes
            CheckSelections();
        }

        #endregion

        #endregion

        #region process form

        /// <summary>
        /// Get selection filters from the user and return them for filtering the job list
        /// </summary>
        /// <param name="joblist">The current list of jobs used to populate value lists</param>
        /// <param name="selectionsIn">A JobSelections that is the starting selections to be shown when the dialog is loaded</param>
        /// <param name="selectionsOut">A JobSelections that contains the selections made by the user</param>
        /// <returns>true if selections are made, otherwise false</returns>
        public static bool ProcessSelections(DataTable joblist, JobSelections selectionsIn, out JobSelections selectionsOut)
        {
            SelectJobs dlg = new SelectJobs(joblist, selectionsIn);

            if (DialogResult.OK == dlg.ShowDialog())
            {
                selectionsOut = dlg.Selections;
                return true;
            }

            selectionsOut = new JobSelections();
            return false;
        }

        #endregion
    }
}