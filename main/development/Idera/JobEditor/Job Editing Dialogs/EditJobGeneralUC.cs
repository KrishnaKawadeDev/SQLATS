using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Agent;

using Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs;
using Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Generic_SQL_Dialogs;
using Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Misc_Dialogs;
using Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Utility;

namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs
{
  public partial class EditJobGeneralUC : UserControlWithLoadAndSave
  {
    Job m_job;
    string m_jobName;
    public EditJobGeneralUC(Job job)
    {
      m_job = job;
      InitializeComponent();
      m_jobName = "";
    }

    public override string ToString()
    {
      return "General";
    }

    public override void LoadSettings() 
    {
      if (m_jobName.Length == 0)
        m_jobName = m_job.Name;

      uteName.Text = m_jobName;
      uteDescription.Text = m_job.Description;
      uteOwner.Text = m_job.OwnerLoginName;

      comboCategory.Items.Clear();
      foreach (JobCategory jc in m_job.Parent.JobCategories)
        comboCategory.Items.Add(jc.Name);
      comboCategory.SelectedIndex = comboCategory.FindString(m_job.Category);

      uteSource.Text = m_job.OriginatingServer;
      uteCreated.Text = m_job.DateCreated.ToString();
      uteLastModified.Text = m_job.DateLastModified.ToString();
      if (m_job.LastRunDate < new DateTime(1980, 01,01))
        uteLastExecuted.Text = "";
      else
        uteLastExecuted.Text = m_job.LastRunDate.ToString();
    }

    public override void OnOK()
    {
      base.OnOK();
      try
      {
        m_job.Rename(m_jobName);
      }
      catch (Exception e)
      {
        SQLjmLog.Log.Error(e);
        throw new Exception("A job named " + m_jobName + " already exists.\nPlease try a different name.");
        
//        throw new Exception("Unable to rename job " + m_job.Name + " to " + m_jobName);
      }
    }

    public override void SaveSettings() 
    {
      try
      {
        m_jobName = uteName.Text.Trim();
        m_job.Description = uteDescription.Text.Trim();
        m_job.OwnerLoginName = uteOwner.Text.Trim();
        m_job.Category = comboCategory.Text.Trim();
      }
      catch (Exception e)
      {
        SQLjmLog.Log.Error(e);
      }
    }

    private void bnShowOtherJobsInCategory_Click(object sender, EventArgs e)
    {
      List<string> otherJobs = new List<string>();
      foreach (Job j in m_job.Parent.Jobs)
        if (j.Category == comboCategory.Text)
          otherJobs.Add(j.Name);
      string title = "View Job Category Properties - " + m_job.Parent.Parent.Name + "\\" + m_job.Name;
      ViewListWithNameDlg dlg = new ViewListWithNameDlg(title, comboCategory.Text, "&Jobs in this category", otherJobs);
      dlg.ShowDialog();
    }

    private void bnBrowseOwners_Click(object sender, EventArgs e)
    {
      List<string> logins = new List<string>();
      foreach (Login l in m_job.Parent.Parent.Logins)
        if (l.LoginType != LoginType.WindowsGroup)
          logins.Add(l.Name);
      SelectItemDlg dlg = new SelectItemDlg("Select Login", "Select owner login", logins, m_job.OwnerLoginName);
      if (dlg.ShowDialog() == DialogResult.OK)
        uteOwner.Text = dlg.m_selectedItem;
    }

    private void llViewJobHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      //JobHistory jh = new JobHistory(m_job);
      //ViewHistoryDlg dlg = new ViewHistoryDlg(jh);
      //dlg.ShowDialog();

    }
  }
}
