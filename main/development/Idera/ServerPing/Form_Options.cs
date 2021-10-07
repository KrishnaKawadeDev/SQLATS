using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.ServerPing
{
   public partial class Form_Options : Form
   {
      public bool   m_useWmi;
      public bool   m_runQuery;
      public string m_query;
      public bool   m_warnOnExit;

      public Form_Options(
            bool   useWmi,
            bool   runQuery,
            string query,
            bool   warnOnExit
         )
      {
         InitializeComponent();
         
         if ( useWmi )
            radioWmi.Checked = true;
         else
            radioSQL.Checked = true;
            
         checkQuery.Checked = runQuery;
         textQuery.Text     = query;   
         
         checkBoxWarnOnExit.Checked = warnOnExit;
         
         // save for dirty check
         m_useWmi     = useWmi;
         m_runQuery   = runQuery;
         m_query      = query;
         m_warnOnExit = warnOnExit;
      }

      private void radioWindows_CheckedChanged( object sender, EventArgs e )
      {
         checkQuery.Enabled = 
         textQuery.Enabled  = radioSQL.Checked;
      }

      private void checkQuery_CheckedChanged( object sender, EventArgs e )
      {
         textQuery.Enabled  = checkQuery.Checked;
      }

      private void btnOK_Click( object sender, EventArgs e )
      {
         // dirty check
         bool dirty = false;

         if ( radioWmi.Checked )
         {
            if ( ! m_useWmi ) dirty = true;
            
            m_useWmi = true;
         }
         else
         {
            if ( m_useWmi ||
                checkQuery.Checked != m_runQuery ||
                (checkQuery.Checked && (textQuery.Text!= m_query)) )
            {
               dirty = true; 
               
                m_useWmi   = false;
                m_runQuery = checkQuery.Checked;
                if ( checkQuery.Checked )
                {
                   m_query    = textQuery.Text;
                }
            }
         }
         
         if ( m_warnOnExit != checkBoxWarnOnExit.Checked )
         {
            m_warnOnExit = checkBoxWarnOnExit.Checked;
            dirty = true;
         }
         
         if ( ! dirty )
         {
            DialogResult = DialogResult.Cancel;
         }
         else
         {
            DialogResult = DialogResult.OK;
         }
      }
   }
}
