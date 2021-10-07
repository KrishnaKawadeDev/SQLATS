using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using System.Collections.Specialized;

namespace Idera.SqlAdminToolset.PartitionGenerator
{
   internal class PartitionHelper
   {

      private const string _TableInfoSql = "SELECT " +
                       "tbl.name AS [Name], " +
                       "SCHEMA_NAME(tbl.schema_id) [SchemaName], " +
                       "CAST(CASE idx.index_id WHEN 1 THEN 1 ELSE 0 END AS bit) AS [HasClusteredIndex], " +
                       "ISNULL(idx.name, N'') AS [ClusteredIndexName], " +
                       "ISNULL( ( select sum (spart.rows) from sys.partitions spart where spart.object_id = tbl.object_id and spart.index_id < 2), 0) AS [RowCount], " +
                       "CASE WHEN 'PS'=dsidx.type THEN dsidx.name ELSE N'' END AS [PartitionScheme], " +
                       "CAST(CASE WHEN 'PS'=dsidx.type THEN 1 ELSE 0 END AS bit) AS [IsPartitioned] " +
                       "FROM " +
                       "sys.tables AS tbl " +
                       "INNER JOIN sys.indexes AS idx ON idx.object_id = tbl.object_id and idx.index_id < 2 " +
                       "LEFT OUTER JOIN sys.data_spaces AS dsidx ON dsidx.data_space_id = idx.data_space_id ";

      /// <summary>
      /// Gets a list of all tables in a database and their partitioning information.
      /// </summary>
      public static List<TableInfo> GetTableList(ServerInformation server, string database)
      {
         List<TableInfo> _TableList = new List<TableInfo>();
         
         using (SqlConnection _Connection = Connection.OpenConnection(server.Name, database, server.SqlCredentials))
         using (SqlCommand _Command = new SqlCommand(_TableInfoSql, _Connection))
         {
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            using (SqlDataReader _Reader = _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
            {
               while (_Reader.Read())
               {
                  _TableList.Add(FillTable(_Reader));
               }
            }
         }
         return _TableList;

      }

      /// <summary>
      /// Retrieves information about a table and its partition information.
      /// </summary>
      public static TableInfo GetTable(ServerInformation server, string database, string schema, string tableName)
      {
         TableInfo _Table = null;

         string _Sql = _TableInfoSql + string.Format("WHERE (tbl.name=N'{0}' and SCHEMA_NAME(tbl.schema_id)=N'{1}')", tableName, schema);

         using (SqlConnection _Connection = Connection.OpenConnection(server.Name, database, server.SqlCredentials))
         using (SqlCommand _Command = new SqlCommand(_Sql, _Connection))
         {
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            using (SqlDataReader _Reader = _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
            {
               if (_Reader.Read())
               {
                  _Table = FillTable(_Reader);
               }
            }
         }
         return _Table;
      }

      /// <summary>
      /// Retrieves values from a datareader and popullates a TableInfo object.
      /// </summary>
      private static TableInfo FillTable(SqlDataReader reader)
      {
         TableInfo _Table = new TableInfo(reader.GetString(reader.GetOrdinal("Name")));
         _Table.Schema = reader.GetString(reader.GetOrdinal("SchemaName"));
         _Table.HasClusteredIndex = reader.GetBoolean(reader.GetOrdinal("HasClusteredIndex"));
         _Table.ClusteredIndex = reader.GetString(reader.GetOrdinal("ClusteredIndexName"));
         _Table.RowCount = reader.GetInt64(reader.GetOrdinal("RowCount"));
         _Table.IsPartitioned = reader.GetBoolean(reader.GetOrdinal("IsPartitioned"));
         _Table.PartitionScheme = reader.GetString(reader.GetOrdinal("PartitionScheme"));
         return _Table;
      }

      /// <summary>
      /// Retrieves partition scheme information.
      /// </summary>
      public static PartitionScheme GetPartitionScheme(ServerInformation server, string database, TableInfo table)
      {
         if (string.IsNullOrEmpty(table.PartitionScheme))
         {
            throw new ArgumentException(ProductConstants.ErrorPartitionSchemeNotProided);
         }

         PartitionScheme _Scheme = null;
         string _Sql = "--Partition Scheme Information " + Environment.NewLine +
                       "SELECT t.name AS 'TableName',  c.name AS 'ColumnName', ps.Name AS 'SchemeName', pf.Name AS 'FunctionName', pf.fanout AS 'PartitionCount', pf.boundary_value_on_right AS 'IsRightPartition' " +
                       "FROM sys.partition_functions AS pf " +
                       "INNER JOIN sys.partition_schemes AS ps On pf.function_id = ps.function_id " +
                       "INNER JOIN sys.indexes AS i ON ps.data_space_id = i.data_space_Id " +
                       "INNER JOIN sys.index_columns AS ic ON i.object_Id = ic.object_Id " +
                       "                     AND i.index_id = ic.index_id " +
                       "                     AND ic.partition_ordinal = 1 " +
                       "INNER JOIN sys.columns AS c ON c.object_id = i.object_id " +
                       "                     AND c.column_id = ic.column_id " +
                       "INNER JOIN sys.tables t ON i.object_id = t.object_id " +
                       string.Format("WHERE ps.name = '{0}' ", table.PartitionScheme) + Environment.NewLine +
                       "--file locations " + Environment.NewLine +
                       "SELECT dds.destination_id, fg.Name AS 'FileGroupName'  " +
                       "FROM sys.partition_schemes ps INNER JOIN " +
                       "sys.destination_data_spaces dds ON dds.partition_scheme_id = ps.data_space_id INNER JOIN " +
                       "sys.filegroups fg on fg.data_space_id = dds.data_space_id INNER JOIN " +
                       "sys.partition_functions pf ON  pf.function_id = ps.function_id AND dds.destination_id <= pf.fanout " +
                       string.Format("WHERE ps.name = '{0}' ", table.PartitionScheme) +
                       "ORDER BY dds.destination_id ASC " + Environment.NewLine +
                       "--boundaries " + Environment.NewLine +
                       "SELECT prv.value " +
                       "FROM sys.partition_range_values prv INNER JOIN " +
                       "sys.partition_schemes ps ON prv.function_id = ps.function_id " +
                       string.Format("WHERE ps.name = '{0}' ", table.PartitionScheme) +
                       "ORDER BY prv.boundary_id ASC";

         using (SqlConnection _Connection = Connection.OpenConnection(server.Name, database, server.SqlCredentials))
         using (SqlCommand _Command = new SqlCommand(_Sql, _Connection))
         {
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            using (SqlDataReader _Reader = _Command.ExecuteReader())
            {
               if (_Reader.Read())
               {
                  _Scheme = new PartitionScheme(table.PartitionScheme, _Reader.GetInt32(_Reader.GetOrdinal("PartitionCount")));
                  _Scheme.Table = table;
                  _Scheme.Column = _Reader.GetString(_Reader.GetOrdinal("ColumnName"));
                  _Scheme.Function = _Reader.GetString(_Reader.GetOrdinal("FunctionName"));
                  _Scheme.IsRightPartition = _Reader.GetBoolean(_Reader.GetOrdinal("IsRightPartition"));
               }
               else
               {
                  throw new ApplicationException(ProductConstants.ErrorSchemeInformationNotFound);
               }
               if (_Reader.NextResult())
               {
                  int _RangeIndex = 0;
                  while (_Reader.Read())
                  {
                     PartitionRange _Range = new PartitionRange();
                     _Range.FileGroup = _Reader.GetString(_Reader.GetOrdinal("FileGroupName"));
                     _Scheme.RangeValues[_RangeIndex] = _Range;
                     _RangeIndex++;
                  }
               }
               else
               {
                  throw new ApplicationException(ProductConstants.ErrorSchemeRangeInformationNotFound);
               }
               if (_Reader.NextResult())
               {
                  int _RangeIndex = 0;
                  while (_Reader.Read())
                  {
                     string _Value = _Reader.GetValue(_Reader.GetOrdinal("value")).ToString();
                     if (_RangeIndex + 1 < _Scheme.RangeValues.Length)
                     {
                        _Scheme.RangeValues[_RangeIndex].MaximumValue = _Value;
                        _Scheme.RangeValues[_RangeIndex + 1].MinimumValue = _Value;
                     }
                     else
                     {
                        _Scheme.RangeValues[_RangeIndex].MinimumValue = _Value;
                     }
                     _RangeIndex++;
                  }
               }
               else
               {
                  throw new ApplicationException(ProductConstants.ErrorSchemeRangeInformationNotFound);
               }
            }
            //Ger record count per partition
            _Command.CommandText = string.Format("SELECT $partition.[{0}](t.{1}) AS [PartitionNumber], COUNT(1) AS [RowCount] " +
                                                   "FROM [{2}].[{3}] AS t " +
                                                   "GROUP BY $partition.[{0}](t.{1}) " +
                                                   "ORDER BY [PartitionNumber] ",
                                                   _Scheme.Function, _Scheme.Column, _Scheme.Table.Schema, _Scheme.Table.Name);
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            using (SqlDataReader _RecordCountReader = _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
            {
               while (_RecordCountReader.Read())
               {
                  _Scheme.RangeValues[_RecordCountReader.GetInt32(_RecordCountReader.GetOrdinal("PartitionNumber")) - 1].RowCount =
                     _RecordCountReader.GetInt32(_RecordCountReader.GetOrdinal("RowCount"));
               }
            }
         }


         return _Scheme;
      }

      /// <summary>
      /// Retrieves the list of filegroups available to a database.
      /// </summary>
      public static List<string> GetFileGroups(ServerInformation server, string database)
      {
         List<string> _FileGroups = new List<string>();

         using (SqlConnection _Connection = Connection.OpenConnection(server.Name, database, server.SqlCredentials))
         using (SqlCommand _Command = new SqlCommand("SELECT name FROM sys.filegroups", _Connection))
         {
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            using (SqlDataReader _Reader = _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
            {
               while (_Reader.Read())
               {
                  _FileGroups.Add(_Reader.GetString(_Reader.GetOrdinal("name")));
               }
            }
         }
         return _FileGroups;
      }

      /// <summary>
      /// Gets a list of columns and their type.
      /// </summary>
      public static Dictionary<string, string> GetTableColumns(ServerInformation server, string database, TableInfo table)
      {
         Dictionary<string, string> _Columns = new Dictionary<string, string>();
         string _Sql = string.Format("SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH FROM INFORMATION_SCHEMA.COLUMNS WHERE table_schema = {0} AND table_name = {1} ORDER BY column_name", 
            SQLHelpers.CreateSafeString(table.Schema), SQLHelpers.CreateSafeString(table.Name));

         using (SqlConnection _Connection = Connection.OpenConnection(server.Name, database, server.SqlCredentials))
         using (SqlCommand _Command = new SqlCommand(_Sql, _Connection))
         {
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            SqlDataReader _Reader = _Command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (_Reader.Read())
            {
               string _DataType = _Reader.GetString(_Reader.GetOrdinal("DATA_TYPE")).ToUpperInvariant();
               if (!_Reader.IsDBNull(_Reader.GetOrdinal("CHARACTER_MAXIMUM_LENGTH")))
               {
                  int _MaximumLength = _Reader.GetInt32(_Reader.GetOrdinal("CHARACTER_MAXIMUM_LENGTH"));
                  if (_MaximumLength == -1)
                  {
                     _DataType += "(MAX)";
                  }
                  else
                  {
                     _DataType += string.Format("({0})", _MaximumLength);
                  }
               }
               _Columns.Add(_Reader.GetString(_Reader.GetOrdinal("COLUMN_NAME")), _DataType);
            }
         }
         return _Columns;
      }

      /// <summary>
      /// Creates a table partition in the database.
      /// </summary>
      /// <param name="scheme"></param>
      public static void CreatePartition(ServerInformation server, string database, PartitionScheme scheme)
      {
         using (SqlConnection _Connection = Connection.OpenConnection(server.Name, database, server.SqlCredentials))
         {
            StringBuilder _Sql = new StringBuilder();
            _Sql.Append("BEGIN TRANSACTION");
            _Sql.Append(Environment.NewLine);
            _Sql.Append("CREATE PARTITION FUNCTION [{0}]({1}) AS RANGE {2} FOR VALUES (");
            for (int i = 0; i < scheme.RangeValues.Length - 1; i++)
            {
               if (i > 0)
               {
                  _Sql.Append(", ");
               }
               _Sql.AppendFormat("N'{0}'", scheme.RangeValues[i].MaximumValue);
            }
            _Sql.Append(")");
            _Sql.Append(Environment.NewLine);
            _Sql.Append("CREATE PARTITION SCHEME [{3}] AS PARTITION [{0}] TO (");
            for (int i = 0; i < scheme.RangeValues.Length; i++)
            {
               if (i > 0)
               {
                  _Sql.Append(", ");
               }
               _Sql.AppendFormat("[{0}]", scheme.RangeValues[i].FileGroup);
            }
            _Sql.Append(")");
            _Sql.Append(Environment.NewLine);

            if (!scheme.Table.HasClusteredIndex && scheme.Table.ClusteredIndex.Trim().Length > 0)  //Create clustered index (aligned)
            {
               _Sql.AppendFormat("CREATE CLUSTERED INDEX [{0}] ON {1} ([{2}])WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [{3}]([{2}])",
                                          scheme.Table.ClusteredIndex.Trim(),
                                          string.Format("[{0}].[{1}]", scheme.Table.Schema, scheme.Table.Name),
                                          scheme.Column,
                                          scheme.Name);
            }
            else if (scheme.Table.HasClusteredIndex)  //Deal with existing index
            {
               string _IndexGetSql = string.Format("SELECT [name], is_unique, " +
                                    "is_padded, fill_factor, [allow_row_locks], [allow_page_locks]  " +
                                    "FROM sys.indexes  " +
                                    "WHERE name = '{0}' " +
                                    Environment.NewLine +
                                    "SELECT c.Name, ic.is_descending_key, ic.is_included_column " +
                                    "FROM sys.indexes i INNER JOIN " +
                                    "sys.index_columns As ic ON i.object_Id = ic.object_Id AND i.index_id = ic.index_id INNER JOIN " +
                                    "sys.columns As c ON c.object_id = i.object_id " +
                                    "AND c.column_id = ic.column_id " +
                                    "WHERE i.name = '{0}'", scheme.Table.ClusteredIndex.Trim());

               using (SqlCommand _IndexCommand = new SqlCommand(_IndexGetSql, _Connection))
               using (SqlDataReader _Reader = _IndexCommand.ExecuteReader())
               {
                  if (_Reader.Read())
                  {
                     bool _IsUnique = _Reader.GetBoolean(_Reader.GetOrdinal("is_unique"));
                     bool _IsPadded = _Reader.GetBoolean(_Reader.GetOrdinal("is_padded"));
                     byte _FillFactor = _Reader.GetByte(_Reader.GetOrdinal("fill_factor"));
                     bool _AllowRowLocks = _Reader.GetBoolean(_Reader.GetOrdinal("allow_row_locks"));
                     bool _AllowPageLocks = _Reader.GetBoolean(_Reader.GetOrdinal("allow_page_locks"));
                     Dictionary<string, bool> _IndexColumns = new Dictionary<string, bool>(); //name, isdescending
                     List<string> _IncludedColumns = new List<string>();
                     
                     _Reader.NextResult();

                     while (_Reader.Read())
                     {
                        string _ColumnName = _Reader.GetString(_Reader.GetOrdinal("Name"));
                        bool _IsDescending = _Reader.GetBoolean(_Reader.GetOrdinal("is_descending_key"));
                        bool _IsIncluded = _Reader.GetBoolean(_Reader.GetOrdinal("is_included_column"));
                        if(_IsIncluded)
                        {
                           _IncludedColumns.Add(_ColumnName);
                        }
                        else
                        {
                           _IndexColumns.Add(_ColumnName, _IsDescending);
                        }
                     }

                     if(_IndexColumns.ContainsKey(scheme.Column))
                     {
                        StringBuilder _CreateIndexSql =  new StringBuilder();
                        _CreateIndexSql.AppendFormat("CREATE {0} CLUSTERED INDEX [{1}] ON {2} ", _IsUnique ? "UNIQUE" : string.Empty, scheme.Table.ClusteredIndex.Trim(), string.Format("[{0}].[{1}]", scheme.Table.Schema, scheme.Table.Name));
                        _CreateIndexSql.Append(Environment.NewLine);
                        _CreateIndexSql.Append("(");

                        int _ColumnCount = 0;
                        foreach(KeyValuePair<string, bool> _Column in _IndexColumns)
                        {
                           if (_ColumnCount > 0)
                           {
                              _CreateIndexSql.Append(", ");
                           }
                           _CreateIndexSql.AppendFormat("[{0}] {1}", _Column.Key, _Column.Value ? "DESC" : "ASC");
                           _ColumnCount++;
                        }
                        _CreateIndexSql.Append(")");
                        _CreateIndexSql.Append(Environment.NewLine);

                        if (_IncludedColumns.Count > 0)
                        {
                           _CreateIndexSql.Append("INCLUDE (");
                           _ColumnCount = 0;
                           foreach (string _IncludedColumn in _IncludedColumns)
                           {
                              if (_ColumnCount > 0)
                              {
                                 _CreateIndexSql.Append(", ");
                              }
                              _CreateIndexSql.Append(_IncludedColumn);
                              _ColumnCount++;
                           }
                           _CreateIndexSql.Append(")");
                           _CreateIndexSql.Append(Environment.NewLine);
                        }

                        _CreateIndexSql.AppendFormat("WITH (PAD_INDEX = {0},{1} SORT_IN_TEMPDB = OFF, DROP_EXISTING = ON, ALLOW_ROW_LOCKS = {2}, ALLOW_PAGE_LOCKS = {3})",
                           _IsPadded ? "ON" : "OFF", _FillFactor > 0 ? string.Format(" FILLFACTOR = {0},", _FillFactor) : string.Empty, _AllowRowLocks ? "ON" : "OFF", _AllowPageLocks ? "ON" : "OFF");

                        _CreateIndexSql.Append(Environment.NewLine);
                        _CreateIndexSql.AppendFormat("ON [{0}]([{1}])", scheme.Name, scheme.Column);

                        _Sql.Append(_CreateIndexSql.ToString());
                     }
                     else
                     {
                        throw new NotSupportedException("Partitioned column must be part of the clustered index in order to partitioned an indexed table");
                     }
                  }
               }
            }
            else  //Create temporary index
            {
               string _CreateTempIndexScript = "CREATE CLUSTERED INDEX [{0}] ON {1} ([{2}])WITH (SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [{3}]([{2}])" +
                                    Environment.NewLine + "DROP INDEX [{0}] ON {1} WITH ( ONLINE = OFF )";
               _Sql.AppendFormat(_CreateTempIndexScript,
                                          string.Format("clus_index{0}", Guid.NewGuid().ToString().Replace("-", "")),
                                          string.Format("[{0}].[{1}]", scheme.Table.Schema, scheme.Table.Name),
                                          scheme.Column,
                                          scheme.Name);

               //0 = clustered index name
               //1 = table ([schema].[table])
               //2 = column name
               //3 = scheme
            }

            _Sql.Append(Environment.NewLine);
            _Sql.Append("COMMIT TRANSACTION");
            string _FormattedSql = string.Format(_Sql.ToString(), scheme.Function, scheme.DataType, scheme.IsRightPartition ? "RIGHT" : "LEFT",
                                                 scheme.Name);
            //0 = function
            //1 = type
            //2 = RIGHT/LEFT
            //3 = scheme

            using (SqlCommand _Command = new SqlCommand(_FormattedSql, _Connection))
            {
               _Command.CommandTimeout = ToolsetOptions.commandTimeout;
               _Command.ExecuteNonQuery();
            }
         }
      }

      public static void AlterPartition(ServerInformation server, string database, PartitionScheme scheme,
                                        List<PartitionRange> splits, List<PartitionRange> merges)
      {
         if (splits.Count == 0 && merges.Count == 0)
         {
            return;
         }

         string _SplitScript = "ALTER PARTITION SCHEME [{0}] NEXT USED [{1}]" + Environment.NewLine +
                               "ALTER PARTITION FUNCTION [{2}]() SPLIT RANGE (N'{3}')";
         //0 = scheme name
         //1 = file group name
         //2 = function
         //3 = range minimum value


         string _MergeScript = "ALTER PARTITION FUNCTION [{0}]() MERGE RANGE (N'{1}')";
         //0 = function name
         //1 = boundary value

         StringBuilder _AlterScript = new StringBuilder();
         _AlterScript.Append("BEGIN TRANSACTION");
         _AlterScript.Append(Environment.NewLine);
         foreach (PartitionRange _Range in splits)
         {
            _AlterScript.AppendFormat(_SplitScript, scheme.Name, _Range.FileGroup, scheme.Function, scheme.IsRightPartition ? _Range.MinimumValue : _Range.MaximumValue);
            _AlterScript.Append(Environment.NewLine);
         }

         foreach (PartitionRange _Range in merges)
         {
            _AlterScript.AppendFormat(_MergeScript, scheme.Function, _Range.MinimumValue);
            _AlterScript.Append(Environment.NewLine);
         }

         _AlterScript.Append("COMMIT TRANSACTION");

         using (SqlConnection _Connection = Connection.OpenConnection(server.Name, database, server.SqlCredentials))
         using (SqlCommand _Command = new SqlCommand(_AlterScript.ToString(), _Connection))
         {
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            _Command.ExecuteNonQuery();
         }
      }

      /// <summary>
      /// Returns a list of databases with their compatibility level, excluding system databases.
      /// </summary>
      public static Dictionary<string, byte> GetDatabaseList(SqlConnection connection)
      {
         Dictionary<string, byte> _DatabaseList = new Dictionary<string, byte>();
         using (SqlCommand _Command = new SqlCommand("SELECT [name], compatibility_level FROM sys.databases ORDER BY name", connection))
         {
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            using (SqlDataReader _Reader = _Command.ExecuteReader())
            {
               while (_Reader.Read())
               {
                  string _DatabaseName = _Reader.GetString(_Reader.GetOrdinal("name"));
                  if (!SQLHelpers.IsSystemDatabase(_DatabaseName))
                  {
                     _DatabaseList.Add(_DatabaseName, _Reader.GetByte(_Reader.GetOrdinal("compatibility_level")));
                  }
               }
            }
         }
         return _DatabaseList;
      }
   }
}
