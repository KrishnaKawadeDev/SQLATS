using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.JobMover
{
   public partial class Form_Results : Form
   {
      public enum ResultsType
      {
         Validation,
         Copy
      }

      private SortedDictionary<string, List<string>> _results = new SortedDictionary<string,List<string>>();

      private DataTable _resultList;
      private ResultsType _resultType = ResultsType.Validation;

      public Form_Results(ResultsType resultsType)
      {
         InitializeComponent();

         this.Text = CoreGlobals.productName + " - Job " + resultsType.ToString() + " Results";

         _resultList = new DataTable();
         _resultList.Columns.Add(@"Object", typeof(string));
         _resultList.Columns.Add(@"Status", typeof(TaskStatus));
         _resultList.Columns.Add(@"Results", typeof(string));

         _resultList.PrimaryKey = new DataColumn[] { _resultList.Columns[@"Object"] };

         _resultType = resultsType;
         if (_resultType == ResultsType.Copy)
         {
            buttonOk.Visible = false;
            buttonCancel.Text = ProductConstants.CancelButtonExit;
            labelResults.Text = ProductConstants.resultsCopyOk;
            dataGridViewResults.Columns[0].HeaderText = @"Job";
         }
         else
         {
            buttonOk.Visible = true;
            buttonCancel.Text = ProductConstants.CancelButtonCancel;
            labelResults.Text = ProductConstants.resultsValidate;
         }
      }

      public void AddResult(string ItemName, JobTaskResults.Status Status, string Result)
      {
         List<string> result;

         if (_results.TryGetValue(ItemName, out result))
         {
            result.Add(Result);
         }
         else
         {
            _results.Add(ItemName, new List<string>(new string[] { Result }));
         }

         if (_resultType == ResultsType.Copy && Status == JobTaskResults.Status.Failed)
         {
            labelResults.Text = ProductConstants.resultsCopyFailed;
         }
         else if (_resultType == ResultsType.Validation)
         {
            buttonOk.Enabled = true;
         }
      }

      private void Form_Results_Shown(object sender, EventArgs e)
      {
         foreach (KeyValuePair<string, List<string>> result in _results)
         {
            dataGridViewResults.Rows.Add(result.Key, string.Join(Environment.NewLine, result.Value.ToArray()));
         }
      }
   }
}