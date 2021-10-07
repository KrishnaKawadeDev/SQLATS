using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Idera.SqlAdminToolset.Core
{
    public partial class Form_MultipleErrorHandler : Office2007Form 
    {        
        private DataTable dataTable;
        private Dictionary<string, string> _errors;

        public Form_MultipleErrorHandler()
        {
            InitializeComponent();

            dataTable = new DataTable();
            dataTable.Columns.Add("Error", typeof(string));
            dataTable.Columns.Add("Details", typeof(string));
        }

        public string Title
        {
            set { this.Text = value; }
        }

        public Dictionary<string, string> Errors
        {
            set { _errors = value; }
        }

        private void Form_MultipleErrorHandler_Load(object sender, EventArgs e)
        {
            if (_errors != null)
            {
                
                foreach (KeyValuePair<string, string> kvp in _errors)
                {
                    dataTable.Rows.Add(new object[] {kvp.Key, kvp.Value});
                }
                dataGridViewX1.DataSource = dataTable;
                dataGridViewX1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewX1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridViewX1.AllowUserToAddRows = false;
                dataGridViewX1.ClearSelection();
            }
        }

       private void buttonClipboard_Click( object sender, EventArgs e )
       {
          StringBuilder sb = new StringBuilder(2048);
         
          sb.AppendFormat( "{0} Errors\r\n\r\n", CoreGlobals.productName  );
          //sb.AppendFormat( "Server, Error Message\r\n" );
          //sb.AppendFormat( "------, -------------\r\n" );
          foreach( DataGridViewRow row in dataGridViewX1.Rows )
          {
             string msg= "";
             
             foreach ( DataGridViewCell cell in row.Cells )
             {
                if ( cell.Value != null )
                {
                   if ( msg != "" ) msg = ", ";
                   msg +=cell.Value.ToString();
                }
             }
             if ( msg != "" ) sb.AppendFormat( "{0}\r\n", msg );
          }
         
          Clipboard.SetText( sb.ToString() );
       }


    }
}