using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Misc_Dialogs
{
  public partial class SelectItemDlg : Form
  {
    public string m_selectedItem;
    public SelectItemDlg(string title, string listTitle, List<string> list, string selectedStr)
    {
      InitializeComponent();
      Text = title;
      lblListTitle.Text = listTitle;
      foreach (string s in list)
        lbList.Items.Add(s);
      lbList.SelectedItem = selectedStr;
      HandleGreyItems();
    }
    
    void HandleGreyItems()
    {
      ubnOK.Enabled = (lbList.SelectedItems.Count != 0);
    }

    private void OK_Click(object sender, EventArgs e)
    {
      m_selectedItem = (string) lbList.SelectedItem;
    }

    private void lbList_SelectedIndexChanged(object sender, EventArgs e)
    {
      HandleGreyItems();
    }

    private void lbList_MouseDoubleClick(object sender, MouseEventArgs e)
    {
      if (lbList.SelectedItems.Count > 0)
      {
        m_selectedItem = (string)lbList.SelectedItem;
        DialogResult = DialogResult.OK;
        Close();
      }
    }
  }
}