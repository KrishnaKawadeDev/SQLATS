using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.Core
{
   public partial class Form_ServersOrGroup : Form
   {
      #region Properties
      
      public bool ShowClearAll
      {
         get { return checkClearAll.Visible; }
         set { checkClearAll.Visible = value; } 
         
      }
      
      public bool clearAll
      {
         get
         {
            return checkClearAll.Checked;
         }
         set { checkClearAll.Checked = value; }
      }

      #endregion

      #region Ctor

      public Form_ServersOrGroup()
      {
         InitializeComponent();
      }

      #endregion

      private void ServerSelection_TextChanged( object sender, EventArgs e )
      {
         btnOK.Enabled = (ServerSelection.Text != "");
      }
   }
}
