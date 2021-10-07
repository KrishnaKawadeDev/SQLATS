using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Generic_SQL_Dialogs
{
  public partial class ViewListWithNameDlg : Form
  {
    public ViewListWithNameDlg(string windowTitle, string name, string listName, List<string> items)
    {
      InitializeComponent();
      Text = windowTitle;
      uteName.Text = name;
      lblListName.Text = listName;
      foreach (string str in items)
        lbList.Items.Add(str);
    }
  }
}