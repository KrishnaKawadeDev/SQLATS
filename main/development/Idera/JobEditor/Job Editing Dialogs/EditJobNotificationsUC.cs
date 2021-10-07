using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using Microsoft.SqlServer.Management.Smo.Agent;

using Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Utility;

namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs
{
  public partial class EditJobNotificationsUC : UserControlWithLoadAndSave
  {
    Job m_job;
    public EditJobNotificationsUC(Job job)
    {
      m_job = job;
      InitializeComponent();
    }

    public override string ToString()
    {
      return "Notifications";
    }

    public override void LoadSettings() 
    {
      cbEmail.Checked = (m_job.EmailLevel != CompletionAction.Never);
      if (cbEmail.Checked)
      {
        WinFormFunctions.SelectStringObject(comboEmailOperator, m_job.OperatorToEmail);
        WinFormFunctions.SelectIntString(comboEmailJobCondition, (Int32) m_job.EmailLevel);
      }

      cbNetSend.Checked = (m_job.NetSendLevel != CompletionAction.Never);
      if (cbNetSend.Checked)
      {
        WinFormFunctions.SelectStringObject(comboNetSendOperator, m_job.OperatorToNetSend);
        WinFormFunctions.SelectIntString(comboNetSendJobCondition, (Int32) m_job.NetSendLevel);
      }

      cbPage.Checked = (m_job.PageLevel != CompletionAction.Never);
      if (cbPage.Checked)
      {
        WinFormFunctions.SelectStringObject(comboPageOperator, m_job.OperatorToPage);
        WinFormFunctions.SelectIntString(comboPageJobCondition, (Int32) m_job.PageLevel);
      }

      cbEventLog.Checked = (m_job.EventLogLevel != CompletionAction.Never);
      if (cbEventLog.Checked)
        WinFormFunctions.SelectIntString(comboEventLogJobCondition, (Int32) m_job.EventLogLevel);

      cbDeleteJob.Checked = (m_job.DeleteLevel != CompletionAction.Never);
      if (cbDeleteJob.Checked)
        WinFormFunctions.SelectIntString(comboDeleteJobJobCondition, (Int32) m_job.DeleteLevel);
      HandleGreyItems();
    }

    public override void SaveSettings() 
    {
      try
      {
        if (cbEmail.Checked)
        {
          m_job.OperatorToEmail = WinFormFunctions.SelectedStringObject(comboEmailOperator).m_sValue;
          m_job.EmailLevel = (CompletionAction)(WinFormFunctions.SelectedIntString(comboEmailJobCondition).m_iValue);
        }
        else
          m_job.EmailLevel = CompletionAction.Never;


        if (cbNetSend.Checked)
        {
          m_job.OperatorToNetSend = WinFormFunctions.SelectedStringObject(comboNetSendOperator).m_sValue;
          m_job.NetSendLevel= (CompletionAction)(WinFormFunctions.SelectedIntString(comboNetSendJobCondition).m_iValue);
        }
        else
          m_job.NetSendLevel= CompletionAction.Never;
       
        if (cbPage.Checked)
        {
          m_job.OperatorToPage = WinFormFunctions.SelectedStringObject(comboPageOperator).m_sValue;
          m_job.PageLevel= (CompletionAction)(WinFormFunctions.SelectedIntString(comboPageJobCondition).m_iValue);
        }
        else
          m_job.PageLevel = CompletionAction.Never;

        if (cbEventLog.Checked)
          m_job.EventLogLevel = (CompletionAction)(WinFormFunctions.SelectedIntString(comboEventLogJobCondition).m_iValue);
        else
          m_job.EventLogLevel = CompletionAction.Never;

        if (cbDeleteJob.Checked)
          m_job.DeleteLevel = (CompletionAction)(WinFormFunctions.SelectedIntString(comboDeleteJobJobCondition).m_iValue);
        else
          m_job.DeleteLevel = CompletionAction.Never;

      }
      catch (Exception e)
      {
        SQLjmLog.Log.Error(e);
      }
    }

    private void LoadCompleteActionCombo(ComboBox combo)
    {
      combo.Items.Clear();
      combo.Items.Add(new IntString((Int32) CompletionAction.OnFailure, "When the job fails"));
      combo.Items.Add(new IntString((Int32) CompletionAction.OnSuccess, "When the job succeeds"));
      combo.Items.Add(new IntString((Int32) CompletionAction.Always, "When the job completes"));
    }
    
    private void LoadOperatorCombo(ComboBox combo)
    {
      combo.Items.Clear();
      foreach (Operator o in m_job.Parent.Operators)
      {
//         string operatorName = o.ToString().Replace('[', ' ');
//         operatorName = operatorName.Replace(']', ' ').Trim();
        combo.Items.Add(new StringObject(SQLJmSupport.DropBrackets(o.ToString()), o));
      }
    }

    private void EditJobNotificationsUC_Load(object sender, EventArgs e)
    {

      LoadOperatorCombo(comboEmailOperator);
      LoadCompleteActionCombo(comboEmailJobCondition);

      LoadOperatorCombo(comboPageOperator);
      LoadCompleteActionCombo(comboPageJobCondition);

      LoadOperatorCombo(comboNetSendOperator);
      LoadCompleteActionCombo(comboNetSendJobCondition);

      LoadCompleteActionCombo(comboEventLogJobCondition);
      LoadCompleteActionCombo(comboDeleteJobJobCondition);

      HandleGreyItems();
    }

    public override void HandleGreyItems()
    {
      comboEmailOperator.Enabled = cbEmail.Checked;
      comboEmailJobCondition.Enabled = cbEmail.Checked;
      comboPageOperator.Enabled = cbPage.Checked;
      comboPageJobCondition.Enabled = cbPage.Checked;
      comboNetSendOperator.Enabled = cbNetSend.Checked;
      comboNetSendJobCondition.Enabled = cbNetSend.Checked;
      comboEventLogJobCondition.Enabled = cbEventLog.Checked;
      comboDeleteJobJobCondition.Enabled = cbDeleteJob.Checked;
    }

    private void cbEmail_CheckedChanged(object sender, EventArgs e)
    {
      HandleGreyItems();
    }

    private void cbPage_CheckedChanged(object sender, EventArgs e)
    {
      HandleGreyItems();
    }

    private void cbNetSend_CheckedChanged(object sender, EventArgs e)
    {
      HandleGreyItems();
    }

    private void cbEventLog_CheckedChanged(object sender, EventArgs e)
    {
      HandleGreyItems();
    }

    private void cbDeleteJob_CheckedChanged(object sender, EventArgs e)
    {
      HandleGreyItems();
    }
  }
}
