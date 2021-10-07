using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.MultiQuery
{
   public partial class Form_EditOptions : Form
   {
      public Form_EditOptions()
      {
         InitializeComponent();
         
         checkShowLineNumbers.Checked   = ProductConstants.optionsShowLineNumbers;
         checkShowModifiedLines.Checked = ProductConstants.optionsShowModifiedLines;
         checkShowSyntaxErrors.Checked  = ProductConstants.optionsShowSyntaxErrors;
         checkShowSyntaxColors.Checked  = ProductConstants.optionsShowSyntaxColor;
         checkShowWordWrap.Checked      = ProductConstants.optionsShowWordWrap;
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
         if ( ProductConstants.optionsShowLineNumbers   != checkShowLineNumbers.Checked   ||
              ProductConstants.optionsShowModifiedLines != checkShowModifiedLines.Checked ||
              ProductConstants.optionsShowSyntaxErrors  != checkShowSyntaxErrors.Checked  ||
              ProductConstants.optionsShowSyntaxColor   != checkShowSyntaxColors.Checked  ||
              ProductConstants.optionsShowWordWrap      != checkShowWordWrap.Checked   )
         {     
            ProductConstants.optionsShowLineNumbers   = checkShowLineNumbers.Checked;
            ProductConstants.optionsShowModifiedLines = checkShowModifiedLines.Checked;
            ProductConstants.optionsShowSyntaxErrors  = checkShowSyntaxErrors.Checked;
            ProductConstants.optionsShowSyntaxColor   = checkShowSyntaxColors.Checked;
            ProductConstants.optionsShowWordWrap      = checkShowWordWrap.Checked;

            ProductConstants.WriteOptions();
            
            DialogResult = DialogResult.OK;
         }
         else
         {
            DialogResult = DialogResult.Cancel;
         }
      }
   }
}
