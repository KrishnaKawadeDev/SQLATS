using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.QuickReindex
{
   public partial class Form_ReindexWarning : Form
   {
      public int MaxDOP
      {
         get { return integerInput_MAXDOP.Value; }
         set { integerInput_MAXDOP.Value = value; }
      }

      public bool OnlineRebuild
      {
         get { return checkBoxX_Online.Checked; }
         set { checkBoxX_Online.Checked = value; }
      }
      public Form_ReindexWarning()
      {
         InitializeComponent();
      }

      private void buttonX_Yes_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
      }

      private void buttonX_Cancel_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.Cancel;
      }

      public void HideOnline()
      {
         checkBoxX_Online.Visible = false;
      }

      public void DisableOnline()
      {
         checkBoxX_Online.Enabled = false;
      }

	  public bool SortInTempdbON  //CGVAK -Created SortInTempdbON variable
		{
		get { return radioButtonOn.Checked; }
		set { radioButtonOn.Checked = value; }
	  }
	}
}