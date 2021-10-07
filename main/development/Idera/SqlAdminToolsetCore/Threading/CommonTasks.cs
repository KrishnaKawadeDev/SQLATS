using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Management;

namespace Idera.SqlAdminToolset.Core.Threading
{
    /// <summary>
    /// Static methods used to execute common functionality.
    /// </summary>
    public static class CommonTasks
    {
        /// <summary>
        /// Executes a SQL statement and returns the results.
        /// </summary>
        public static DataTable[] ExecuteSql(ServerInformation   server, int commandTimeout, params object[] args)
        {
            DataTable _Results = new DataTable();
            string _Sql;
            if (args == null || args.Length != 1)
            {
                throw new ArgumentOutOfRangeException("args", "SQL statement was not provided");
            }
            _Sql = (string)args[0];
            using (SqlConnection _Connection = Connection.OpenConnection( server.Name, "master" )) //, server.SqlCredentials))
            {
               using (SqlDataAdapter _Adapter = new SqlDataAdapter (_Sql, _Connection))
               {
                   _Adapter.SelectCommand.CommandTimeout = ToolsetOptions.commandTimeout;
                   _Adapter.Fill(_Results);
               }
               _Connection.Close();
            }
            return new DataTable[] { _Results };
        }

        /// <summary>
        /// Executes a WMI query and returns the results.
        /// </summary>
        public static DataTable[] ExecuteWmi(ServerInformation server, int commandTimeout, params object[] args)
        {
            DataTable _Results = null;
            string _WmiQuery;
            if (args == null || args.Length != 1)
            {
                throw new ArgumentOutOfRangeException("args", "WMI query was not provided");
            }
            _WmiQuery = (string)args[0];
            ManagementScope _WMI = new ManagementScope(@"\\" + server.Name);
            
            using (ManagementObjectSearcher _WmiSearcher = new ManagementObjectSearcher(_WMI, new ObjectQuery(_WmiQuery)))
            using (ManagementObjectCollection _WmiObjectCollection = _WmiSearcher.Get())
            {
                foreach (ManagementObject oReturn in _WmiObjectCollection)
                {
                    _Results = new DataTable();
                    _Results.Rows.Add(_Results.NewRow());

                    foreach (PropertyData _Data in oReturn.Properties)
                    {
                        _Results.Columns.Add(new DataColumn(_Data.Name));
                        _Results.Rows[0][_Data.Name] = _Data.Value;  
                    }
                }
            }
            return new DataTable[] { _Results };
        }
    }
}
