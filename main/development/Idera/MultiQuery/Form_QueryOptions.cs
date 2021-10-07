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
   public partial class Form_QueryOptions : Form
   {
      public Form_QueryOptions()
      {
         InitializeComponent();
         
         textRowCount.Text       = ProductConstants.optionsRowCount.ToString();
         textTextSize.Text       = ProductConstants.optionsTextSize.ToString();
         textThreads.Text        = ProductConstants.optionsMaxThreads.ToString();
         textCommandTimeout.Text = ProductConstants.optionsCommandTimeout.ToString();

         if ( ProductConstants.optionsResultType == ProductConstants.OutputType.Grid )
            radioGrid.Checked = true; 
         else
            radioText.Checked = true;
            
         checkShowSummary.Checked           = ProductConstants.optionsShowSummary;
         checkShowCombinedResults.Checked   = ProductConstants.optionsShowCombinedResults;
         checkShowIndividualResults.Checked = ProductConstants.optionsShowIndividualResults;
            
         textRowCount.Select();
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
         long                        optionsRowCount       = ProductConstants.optionsRowCount ;
         long                        optionsTextSize       = ProductConstants.optionsTextSize;
         ProductConstants.OutputType optionsOutputType     = ProductConstants.optionsResultType;
         int                         optionsMaxThreads     = ProductConstants.optionsMaxThreads ;
         int                         optionsCommandTimeout = ProductConstants.optionsCommandTimeout ;
         
         
         try
         {
            if ( ! String.IsNullOrEmpty( textThreads.Text.Trim() ) )
            { 
               optionsMaxThreads = System.Convert.ToInt32( textThreads.Text );
            }
            else
            {
               optionsMaxThreads = 0;
            }
         }
         catch {}
         
         if ( optionsMaxThreads <= 0 || optionsMaxThreads > 25 )
         {
            Messaging.ShowError( "Specify a number between 1 and 25 for the maximum number of concurrent queries to run." );
            DialogResult = DialogResult.None;
            return;
         }
         
         if ( ! checkShowSummary.Checked &&
              ! checkShowCombinedResults.Checked &&
              ! checkShowIndividualResults.Checked )
         {
            Messaging.ShowError( "You must select at least one query output view." );
            DialogResult = DialogResult.None;
            return;
         }
         
         try
         {
            if ( ! String.IsNullOrEmpty( textRowCount.Text.Trim() ) )
            { 
               optionsRowCount = System.Convert.ToInt32( textRowCount.Text );
            }
         }
         catch {}

         try
         {
            if ( ! String.IsNullOrEmpty( textRowCount.Text.Trim() ) )
            { 
               optionsTextSize = System.Convert.ToInt32( textTextSize.Text );
            }
         }
         catch {}
         
         try
         {
            if ( ! String.IsNullOrEmpty( textCommandTimeout.Text.Trim() ) )
            { 
               optionsCommandTimeout = System.Convert.ToInt32( textCommandTimeout.Text );
            }
         }
         catch {}
         
         
         try
         {
            if ( radioGrid.Checked ) 
               optionsOutputType = ProductConstants.OutputType.Grid;
            else
               optionsOutputType = ProductConstants.OutputType.Text;
         }
         catch {}

         if ( ProductConstants.optionsRowCount                != optionsRowCount   ||
              ProductConstants.optionsTextSize                != optionsTextSize   ||
              ProductConstants.optionsShowSummary             != checkShowSummary.Checked   ||
              ProductConstants.optionsShowCombinedResults     != checkShowCombinedResults.Checked  ||
              ProductConstants.optionsShowIndividualResults   != checkShowIndividualResults.Checked   ||
              ProductConstants.optionsResultType              != optionsOutputType ||
              ProductConstants.optionsCommandTimeout          != optionsCommandTimeout ||
              ProductConstants.optionsMaxThreads              != optionsMaxThreads )
         {     
            ProductConstants.optionsRowCount              = optionsRowCount;
            ProductConstants.optionsTextSize              = optionsTextSize;
            ProductConstants.optionsResultType            = optionsOutputType;
            ProductConstants.optionsShowSummary           = checkShowSummary.Checked;
            ProductConstants.optionsShowCombinedResults   = checkShowCombinedResults.Checked;
            ProductConstants.optionsShowIndividualResults = checkShowIndividualResults.Checked;
            ProductConstants.optionsCommandTimeout        = optionsCommandTimeout;
            ProductConstants.optionsMaxThreads            = optionsMaxThreads;
            
            // write the options to disk
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