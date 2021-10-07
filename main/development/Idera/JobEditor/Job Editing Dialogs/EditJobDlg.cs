using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.SqlServer.Management.Smo.Agent;

using Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Utility;

namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs
{
  public partial class EditJobDlg : Form
  {
    EditJobGeneralUC  m_generalUC;
    //EditJobStepsUC m_stepsUC;
    //EditJobAlertsUC m_alertsUC;
    EditJobNotificationsUC m_notificationsUC;
    //EditJobSchedulesUC m_schedulesUC;
    //EditJobTargetsUC m_targetsUC;
    Job m_job;
    
    public EditJobDlg(Job j)
    {
      m_job = j;
      InitializeComponent();
      Text = "Job Properties - " + m_job.Name;
      m_generalUC = new EditJobGeneralUC(m_job);
      //m_stepsUC = new EditJobStepsUC(m_job);
      //m_schedulesUC = new EditJobSchedulesUC(m_job);
      //m_alertsUC = new EditJobAlertsUC(m_job);
      m_notificationsUC = new EditJobNotificationsUC(m_job);
      //m_targetsUC = new EditJobTargetsUC(m_job);
    }

    private void EditJobDlg_Load(object sender, EventArgs e)
    {
      listBoxPages.Items.Clear();
      listBoxPages.Items.Add(new ListBoxItem(m_generalUC));
      //listBoxPages.Items.Add(new ListBoxItem(m_stepsUC));
      //listBoxPages.Items.Add(new ListBoxItem(m_schedulesUC));
      //listBoxPages.Items.Add(new ListBoxItem(m_alertsUC));
      listBoxPages.Items.Add(new ListBoxItem(m_notificationsUC));
// dropped support for multiple targets.
//      listBoxPages.Items.Add(new ListBoxItem(m_targetsUC));
      listBoxPages.SetSelected(0, true); // start off on the generalUC

      ulbServerName.Text = m_job.Parent.Parent.ConnectionContext.TrueName;
      ulbUsername.Text = m_job.Parent.Parent.ConnectionContext.TrueLogin;
    }
    
    UserControlWithLoadAndSave m_currentUC;
    private void SwitchView(UserControlWithLoadAndSave newUC)
    {
      if (m_currentUC == newUC)  // it's already set to the right one
      {
        m_currentUC.RefreshView(m_currentUC);  // so just refresh the view.
        return;
      }

      if (UCPanel.Controls.Count > 0)
      {
        m_currentUC.SaveSettings();
        UCPanel.Controls.Remove(m_currentUC);
      }

      UCPanel.Controls.Add(newUC);
      m_currentUC = newUC;
      m_currentUC.Size = new Size(UCPanel.Size.Width, UCPanel.Size.Height);
      m_currentUC.RefreshView(m_currentUC);
      m_currentUC.LoadSettings();
    }

    private void listBoxPages_SelectedIndexChanged(object sender, EventArgs e)
    {
      ListBoxItem item = (ListBoxItem) listBoxPages.SelectedItem;
      UserControlWithLoadAndSave newPage = (UserControlWithLoadAndSave)item.m_obj;
      if (newPage != null)
        SwitchView(newPage);
    }

    private void UCPanel_SizeChanged(object sender, EventArgs e)
    {
      if (m_currentUC == null) return;
      try
      {
        m_currentUC.Size = new Size(UCPanel.Size.Width, UCPanel.Size.Height);
      }
      catch (Exception ae)
      {
        Console.WriteLine(ae.Message);
      }
    }

    // at this point, any new job steps, schedules or alerts have already been added to the job
    // we doing an Alter on the job will pick them up.
    // we need to drop anything that needs to be removed from the job before we do that alter though.
    // if a cancel was clicked, we need to drop all the steps, schedules or alerts that where created and added to the job.
    // on the ok, we need to do Alter on any change objects to apply those changes.
    private void bnOK_Click(object sender, EventArgs e)
    {
      try
      {
        m_currentUC.SaveSettings();
        m_generalUC.OnOK();
        //m_stepsUC.OnOK();
        //m_alertsUC.OnOK();
        m_notificationsUC.OnOK();
        //m_schedulesUC.OnOK();
        m_job.Alter();
      }
      catch (Exception ex)
      {
        MessageBox.Show(SQLJmSupport.InnerMost(ex).Message, "Problem Saving Job");
        DialogResult = DialogResult.None;
        return;
      }
      DialogResult = DialogResult.OK;
      Close();
    }

    private void bnCancel_Click(object sender, EventArgs e)
    {
      m_generalUC.OnCancel();
//      m_stepsUC.OnCancel();
//      m_alertsUC.OnCancel();
      m_notificationsUC.OnCancel();
//      m_schedulesUC.OnCancel();
////      m_targetsUC.OnCancel();
    }
  }
}