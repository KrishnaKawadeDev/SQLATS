using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
   public partial class Form_ConfigurationChangeResult : Form
   {
      public Form_ConfigurationChangeResult()
      {
         InitializeComponent();

         this.Text = CoreGlobals.productName + " - " + this.Text;
      }

      internal void AddResult(ConfigurationChangeResults results)
      {
         gridResults.Rows.Add(results.Server.Name, results.Database, results.Data.Name, results.Data.Value, results.IsSuccessful ? "Success" : "Failed", (results.ChangeException == null) ? "" : Helpers.GetCombinedExceptionText(results.ChangeException));
      }
   }
}