using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.Core
{
   public class ExportToTable
   {
      public delegate void CreateTableDelegate( SqlConnection conn, string tableName );
      public delegate void PopulateTableDelegate( SqlConnection conn, string tableName );

        /// <summary>
        /// Copies a the contents of a ListView to a table
        /// </summary>
        public static void
           Export(
              CreateTableDelegate    createTableDelegate,
              PopulateTableDelegate  populateTableDelegate
           )
        {
           string tableName = "";
           
           Form_ExportToTable frm = new Form_ExportToTable();
           DialogResult choice = frm.ShowDialog();
           if ( choice == DialogResult.Cancel )
           {
              return;
           }
                     
            tableName = String.Format( "[{0}].[{1}]",
                                       frm.Schema,
                                       frm.Table );

            string action = "Export to table failed - An error occurred creating the table.";
            SqlConnection conn = null;
            
            try
            {
               conn = Connection.OpenConnection( frm.Server, frm.Database, frm.Credentials );
               
               createTableDelegate( conn, tableName );
               
               action = "Export to table failed - An error occurred writing the data to the table.";
               populateTableDelegate( conn, tableName );
            }
            catch (Exception ex)
            {
               Messaging.ShowException( action, ex );
            }
            finally
            {
               Connection.CloseConnection(conn);
            }
        }
    }
}
