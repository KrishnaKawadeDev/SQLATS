using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PatchEditor
{
   public class PatchData
   {
      public string   server  = "";
      public Version  version = null;
      public string   edition = "";
      
      public PatchData() {}
      
     /// <summary>
     /// Converts contents into a DataTable.
     /// </summary>
     public DataTable ToDataTable()
     {
         DataTable _DataTable = new DataTable(server);

         _DataTable.Columns.Add(new DataColumn("Server",  typeof(string)));
         _DataTable.Columns.Add(new DataColumn("Version", typeof(Version)));
         _DataTable.Columns.Add(new DataColumn("Edition", typeof(string)));

          DataRow _DataRow = _DataTable.NewRow();
          
         _DataRow["Server"]  = server;
         _DataRow["Version"] = version;
         _DataRow["Edition"] = edition;
         
         _DataTable.Rows.Add(_DataRow);
         return _DataTable;

     }
     
     public string GetVersionString()
     {
        if ( version == null ) 
           return "";
        else
        {
           return version.ToString();
        }
     }     
     

     /// <summary>
     /// Loads data into the instance of InventoryData from a DataTable.
     /// </summary>
     /// <param name="dataTable"></param>
     public static PatchData LoadFromDataTable(DataTable dataTable)
     {
         if (dataTable == null)
         {
             throw new ArgumentNullException("dataTable", "The DataTable is null");
         }

         if (dataTable.Rows == null || dataTable.Rows.Count != 1)
         {
             throw new ArgumentException("The DataTable does not contain the expected values.", "dataTable");
         }

         DataRow _PatchRow = dataTable.Rows[0];

         try
         {
             PatchData patchData = new PatchData();

             patchData.server = SQLHelpers.GetRowString(_PatchRow, 0);

            if ( _PatchRow.IsNull(1) )
               patchData.version = null;
            else
               patchData.version = (Version)_PatchRow[1];
               
             patchData.edition = SQLHelpers.GetRowString(_PatchRow, 2);
             
             return patchData;

         }
         catch (InvalidOperationException exc)
         {
             throw new ArgumentException("Error reading datatable", "LoadFromDataTable", exc);
         }
      }
   }
   
   public class VersionHelper
   {
      public static DataTable
         Harvest(
            ServerInformation serverInformation,
            int               commandTimeout,
            JobPoolOptions    options)
      {
          PatchData patchData = new PatchData();
          
          patchData.server  = serverInformation.Name;
          
          using ( SqlConnection conn = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials ) )
          {
             string outVersion = SQLHelpers.GetSqlVersionString(conn);
             SQLVersion sqlVersion = null;
             
             try
             {
                if ( SQLVersion.TryParse( outVersion, out sqlVersion ) )
                {
                   patchData.version = sqlVersion.InnerVersion;
                }
                else
                {
                   patchData.version = new Version(0,0,0);   
                }
             }
             catch ( Exception ex )
             {
                // error parsing - dump error to trace log and set to 0,0,0
                CoreGlobals.traceLog.VerboseFormat( "Server {0}\r\nVersion {1}\r\nError: {2}", serverInformation.Name, outVersion.ToString(), ex.Message );
                patchData.version = new Version(0,0,0);   
             }
             
             patchData.server  = serverInformation.Name;
             
             if ( sqlVersion != null )
                patchData.edition = sqlVersion.Edition;
             else
                patchData.edition = "Unknown";

             conn.Close();
          }
          return patchData.ToDataTable();
      }          
   }
}
