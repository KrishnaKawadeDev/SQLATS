using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobEditor
{
   public partial class UpdateJobs : Form
   {
      #region fields

      private JobData.UpdateJobsInfo m_jobsInfo;

      #endregion

      #region constructors

      public UpdateJobs(JobData.UpdateJobsInfo jobsInfo)
      {
         InitializeComponent();

         m_jobsInfo = jobsInfo;

         // default to clearing selections after updating
         checkBoxClearSelections.Checked = true;

         // fill the list of jobs to update
         LoadJobs();
      }

      #endregion

      #region properties

      public JobUpdateValues Updates;

      #endregion

      #region helpers

      #region Column Sorting

      private int sortColumn = -1;
      private System.Windows.Forms.SortOrder sortOrder = System.Windows.Forms.SortOrder.Ascending;

      private void ResetSort()
      {
         sortColumn = -1;
         listViewJobs.Sorting = sortOrder;
      }

      // Implements the manual sorting of items by column.
      private class ListViewItemComparer : IComparer
      {
         private int col;
         private System.Windows.Forms.SortOrder order;

         public ListViewItemComparer()
         {
            col = 0;
            order = System.Windows.Forms.SortOrder.Ascending;
         }

         public ListViewItemComparer(int column, System.Windows.Forms.SortOrder order)
         {
            switch (column)
            {
               case 0:  // Server
                  col = 1;
                  break;
               case 1:  // Name
                  col = 2;
                  break;
               case 2:  // Enabled
                  col = 3;
                  break;
               case 3:  // Category
                  col = 4;
                  break;
               case 4:  // Owner
                  col = 5;
                  break;
               default:  // All Notify columns
                  col = column + 4;
                  break;
            }
            this.order = order;
         }

         public int Compare(object x, object y)
         {
            int returnVal = -1;
            DataRow dr1 = (DataRow)(((ListViewItem)x).Tag);
            DataRow dr2 = (DataRow)(((ListViewItem)y).Tag);

            if (dr1.Table.Columns[col].DataType == typeof(DateTime))
            {
               returnVal = DateTime.Compare((DateTime)dr1[col], (DateTime)dr2[col]);
            }
            else if (dr1.Table.Columns[col].DataType == typeof(int) ||
               dr1.Table.Columns[col].DataType == typeof(byte) ||
               dr1.Table.Columns[col].DataType == typeof(Int32) ||
               dr1.Table.Columns[col].DataType.BaseType == typeof(Enum) )
            {
               if ((int)dr1[col] < (int)dr2[col])
               {
                  returnVal = -1;
               }
               else if ((int)dr1[col] > (int)dr2[col])
               {
                  returnVal = 1;
               }
               else
               {
                  returnVal = 0;
               }
            }
            else if (dr1.Table.Columns[col].DataType == typeof(bool))
            {
               if ((bool)dr1[col] == false && (bool)dr2[col] == true)
               {
                  returnVal = -1;
               }
               else if ((bool)dr1[col] == true && (bool)dr2[col] == false)
               {
                  returnVal = 1;
               }
               else
               {
                  returnVal = 0;
               }
            }
            else
            {
               returnVal = String.Compare((string)dr1[col], (string)dr2[col]);
            }

            if (order == System.Windows.Forms.SortOrder.Descending) returnVal *= -1;

            return returnVal;
         }
      }

      #endregion

      private void LoadJobs()
      {
         ResetSort();

         foreach (DataRow row in m_jobsInfo.SelectedJobList.Rows)
         {
            ListViewItem item = new ListViewItem(SQLHelpers.NormalizeInstanceName((string)row[JobData.JobList.ColServer]));

            item.SubItems.Add((string)row[JobData.JobList.ColJobName]);
            item.SubItems.Add((JobData.GetEnumDescription((JobData.JobEnabled)row[JobData.JobList.ColEnabled])));
            item.SubItems.Add((string)row[JobData.JobList.ColCategory]);
            item.SubItems.Add((string)row[JobData.JobList.ColOwner]);
            item.SubItems.Add(Enum.GetName(typeof(JobData.NotifyLevel), (int)row[JobData.JobList.ColNotifyLevelEventLog]));
            item.SubItems.Add(Enum.GetName(typeof(JobData.NotifyLevel), (int)row[JobData.JobList.ColNotifyLevelEmail]));
            item.SubItems.Add((string)row[JobData.JobList.ColNotifyOperatorEmail]);
            item.SubItems.Add(Enum.GetName(typeof(JobData.NotifyLevel), (int)row[JobData.JobList.ColNotifyLevelNetSend]));
            item.SubItems.Add((string)row[JobData.JobList.ColNotifyOperatorNetSend]);
            item.SubItems.Add(Enum.GetName(typeof(JobData.NotifyLevel), (int)row[JobData.JobList.ColNotifyLevelPage]));
            item.SubItems.Add((string)row[JobData.JobList.ColNotifyOperatorPage]);

            item.Tag = row;

            listViewJobs.Items.Add(item);
         }

         labelCount.Text = string.Format(ProductConstants.displayToUpdate, listViewJobs.Items.Count);
      }

      private void CheckSelections()
      {
         buttonOk.Enabled =
            (comboBoxEnabled.Text.Length > 0)
            || (comboBoxCategory.Text.Length > 0)
            || (comboBoxOwner.Text.Length > 0)
            || (comboBoxEventLogLevel.Text.Length > 0)
            || (comboBoxEmailLevel.Text.Length > 0)
            || (comboBoxNetSendLevel.Text.Length > 0)
            || (comboBoxPageLevel.Text.Length > 0)
            || (comboBoxEmailOperator.Text.Length > 0)
            || (comboBoxNetSendOperator.Text.Length > 0)
            || (comboBoxPageOperator.Text.Length > 0);
      }

      private JobUpdateValues GetUpdateValues()
      {
         JobUpdateValues updates = new JobUpdateValues(
            ((ComboItem)comboBoxEnabled.SelectedItem == null) ? null :
               (JobData.JobEnabled?)(int)((ComboItem)comboBoxEnabled.SelectedItem).Tag,
            comboBoxCategory.Text,
            comboBoxOwner.Text,
            ((ComboItem)comboBoxEventLogLevel.SelectedItem == null) ? null :
               (JobData.NotifyLevel?)(int)((ComboItem)comboBoxEventLogLevel.SelectedItem).Tag,
            ((ComboItem)comboBoxEmailLevel.SelectedItem == null) ? null :
               (JobData.NotifyLevel?)(int)((ComboItem)comboBoxEmailLevel.SelectedItem).Tag,
            ((ComboItem)comboBoxNetSendLevel.SelectedItem == null) ? null :
               (JobData.NotifyLevel?)(int)((ComboItem)comboBoxNetSendLevel.SelectedItem).Tag,
            ((ComboItem)comboBoxPageLevel.SelectedItem == null) ? null :
               (JobData.NotifyLevel?)(int)((ComboItem)comboBoxPageLevel.SelectedItem).Tag,
            comboBoxEmailOperator.Text,
            comboBoxNetSendOperator.Text,
            comboBoxPageOperator.Text,
            checkBoxCreateCategory.Checked,
            checkBoxClearSelections.Checked
         );

         return updates;
      }

      #endregion

      #region event handlers

      #region button actions

      private void buttonOk_Click(object sender, EventArgs e)
      {
         Updates = GetUpdateValues();
      }

      #endregion

      #region combo box events

      private void comboBoxEnabled_DropDown(object sender, EventArgs e)
      {
         JobRoutines.FillComboBoxFromEnum((ComboBoxEx)sender, typeof(JobData.JobEnabled), false);
      }

      private void comboBoxCategory_DropDown(object sender, EventArgs e)
      {
         JobRoutines.FillComboBoxFromNameList((ComboBoxEx)sender, m_jobsInfo.CommonCategoryList);
      }

      private void comboBoxOwner_DropDown(object sender, EventArgs e)
      {
         JobRoutines.FillComboBoxFromNameList((ComboBoxEx)sender, m_jobsInfo.CommonOwnersList);
      }

      private void comboBoxNotifyLevel_DropDown(object sender, EventArgs e)
      {
         // This event handler is common to all notify level comboboxes
         JobRoutines.FillComboBoxFromEnum((ComboBoxEx)sender, typeof(JobData.NotifyLevel), true);
      }

      private void comboBoxNotifyOperator_DropDown(object sender, EventArgs e)
      {
         // This event handler is common to all notify operator comboboxes
         JobRoutines.FillComboBoxFromNameList((ComboBoxEx)sender, m_jobsInfo.CommonOperatorsList);
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

      #region listview

      private void listViewJobs_ColumnClick(object sender, ColumnClickEventArgs e)
      {
         // Determine whether the column is the same as the last column clicked.
         if (e.Column != sortColumn)
         {
            // Set the sort column to the new column.
            sortColumn = e.Column;

            // Set the sort order to ascending by default.
            listViewJobs.Sorting = sortOrder;
         }
         else
         {
            // Determine what the last sort order was and change it.
            if (listViewJobs.Sorting == System.Windows.Forms.SortOrder.Ascending)
               listViewJobs.Sorting = System.Windows.Forms.SortOrder.Descending;
            else
               listViewJobs.Sorting = System.Windows.Forms.SortOrder.Ascending;
         }

         listViewJobs.ListViewItemSorter = new ListViewItemComparer(e.Column, listViewJobs.Sorting);
         listViewJobs.Sort();
      }

      #endregion

      #endregion

      #region process form

      /// <summary>
      /// Get values to update for all selected jobs
      /// </summary>
      /// <param name="jobsInfo">A list of job info to prepopulate lists</param>
      /// <param name="updatesOut">a JobUpdates that contains the update values</param>
      /// <returns></returns>
      public static bool ProcessUpdates(JobData.UpdateJobsInfo jobsInfo, out JobUpdateValues updatesOut)
      {
         UpdateJobs form = new UpdateJobs(jobsInfo);

         if (DialogResult.OK == form.ShowDialog())
         {
            updatesOut = form.Updates;
            return true;
         }

         updatesOut = null;
         return false;
      }

      #endregion
   }
}