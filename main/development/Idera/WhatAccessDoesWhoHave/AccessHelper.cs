using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.WhatAccessDoesWhoHave
{
   internal class AccessHelper
   {
      /// <summary>
      /// Retrieves all data elements for a server.
      /// </summary>
      public static AccessData HarvestData(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
      {
         AccessOptions _AccessOptions = (AccessOptions)options;

         AccessData _ServerData = new AccessData(serverInformation, serverInformation.Name, ObjectType.Server);

         try
         {
            using (SqlConnection _Connection = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
            {
               bool _IsSql2000 = SQLHelpers.Is2000(_Connection);

               bool _IsSysAdmin = false;
               bool _HasAccess = false;
               using (SqlCommand _ServerAccessCommand = new SqlCommand(string.Format("select sysadmin, hasaccess from master..syslogins where [name] = {0}", SQLHelpers.CreateSafeString(_AccessOptions.LoginName)),
                                                                       _Connection))
               using (SqlDataReader _Reader = _ServerAccessCommand.ExecuteReader())
               {
                  if (_Reader.Read())
                  {
                     _IsSysAdmin = _Reader.GetInt32(_Reader.GetOrdinal("sysadmin")) == 1;
                     _HasAccess = _Reader.GetInt32(_Reader.GetOrdinal("hasaccess")) == 1;
                  }
               }

               #region Database
               AccessDataGroup _DatabaseGroup = new AccessDataGroup("Databases", ObjectType.Database);
               foreach (DatabaseObject _Database in SQLObjects.GetDatabases(_Connection, false))
               {
                  AccessData _DatabaseData = new AccessData(_ServerData, _Database.name, ObjectType.Database);
                  if (_IsSysAdmin)
                  {
                     _DatabaseGroup.Items.Add(_DatabaseData);
                  }
                  else
                  {
                     string _HasDbAccessSql = "SELECT 1 " +
                                              "FROM {0}..sysusers su  " +
                                              "INNER JOIN master..syslogins sl on su.sid = sl.sid " +
                                              "WHERE sl.name = {1} " +
                                              "ORDER BY su.name";
                     using (SqlCommand _HasDbAccessCommand = new SqlCommand(string.Format(_HasDbAccessSql, SQLHelpers.CreateSafeDatabaseName(_Database.name), SQLHelpers.CreateSafeString(_AccessOptions.LoginName)),
                                                                     _Connection))
                     using (SqlDataReader _Reader = _HasDbAccessCommand.ExecuteReader())
                     {
                        if (_Reader.Read())
                        {
                           _DatabaseGroup.Items.Add(_DatabaseData);
                        }
                     }
                  }

               }
               _ServerData.ChildData.Add(_DatabaseGroup);

               foreach(AccessData _DatabaseData in _DatabaseGroup.Items)
               {
                  if (_IsSql2000)
                  {
                     GetSql2000Permissions(_Connection, _AccessOptions.LoginName, _DatabaseData);
                  }
                  else
                  {
                     GetDatabaseObjectPermissions(_Connection, _DatabaseData, _DatabaseData.ObjectName, _AccessOptions.LoginName);
                  }

                  #region Tables
                  AccessDataGroup _TableGroup = new AccessDataGroup("Tables", ObjectType.Table);
                  foreach (TableObject _Table in SQLObjects.GetTables(_Connection, _DatabaseData.ObjectName))
                  {
                     AccessData _TableData = new AccessData(_DatabaseData, _Table.name, ObjectType.Table);

                     AccessDataGroup _ColumnsGroup = new AccessDataGroup("Columns", ObjectType.Column);
                     foreach (ColumnObject _Column in SQLObjects.GetTableColumns(_Connection, _DatabaseData.ObjectName, _Table.name))
                     {
                        _ColumnsGroup.Items.Add(new AccessData(_TableData, _Column.name, ObjectType.Column));
                     }
                     _TableData.ChildData.Add(_ColumnsGroup);

                     if (_IsSql2000)
                     {
                        GetSql2000Permissions(_Connection, _AccessOptions.LoginName, _TableData);
                        foreach (AccessData _ColumnData in _ColumnsGroup.Items)
                        {
                           GetSql2000Permissions(_Connection, _AccessOptions.LoginName, _ColumnData);
                        }
                     }
                     else
                     {
                        GetDatabaseObjectPermissions(_Connection, _TableData, _DatabaseData.ObjectName, _AccessOptions.LoginName);
                     }

                     _TableGroup.Items.Add(_TableData);
                  }
                  _DatabaseData.ChildData.Add(_TableGroup);
                  #endregion

                  #region Views
                  AccessDataGroup _ViewGroup = new AccessDataGroup("Views", ObjectType.View);
                  foreach (ViewObject _View in SQLObjects.GetViews(_Connection, _DatabaseData.ObjectName))
                  {
                     AccessData _ViewData = new AccessData(_DatabaseData, _View.name, ObjectType.View);

                     AccessDataGroup _ColumnsGroup = new AccessDataGroup("Columns", ObjectType.Column);
                     foreach (ColumnObject _Column in SQLObjects.GetViewColumns(_Connection, _DatabaseData.ObjectName, _View.name))
                     {
                        _ColumnsGroup.Items.Add(new AccessData(_ViewData, _Column.name, ObjectType.Column));
                     }
                     _ViewData.ChildData.Add(_ColumnsGroup);

                     if (_IsSql2000)
                     {
                        GetSql2000Permissions(_Connection, _AccessOptions.LoginName, _ViewData);
                        foreach (AccessData _ColumnData in _ColumnsGroup.Items)
                        {
                           GetSql2000Permissions(_Connection, _AccessOptions.LoginName, _ColumnData);
                        }
                     }
                     GetDatabaseObjectPermissions(_Connection, _ViewData, _DatabaseData.ObjectName, _AccessOptions.LoginName);

                     _ViewGroup.Items.Add(_ViewData);
                  }
                  _DatabaseData.ChildData.Add(_ViewGroup);
                  #endregion

                  #region Stored Procs
                  AccessDataGroup _StoredProcGroup = new AccessDataGroup("Stored Procedures", ObjectType.StoredProcedure);
                  foreach (StoredProcObject _StoredProc in SQLObjects.GetStoredProcs(_Connection, _DatabaseData.ObjectName))
                  {
                     AccessData _StoredProcData = new AccessData(_DatabaseData, _StoredProc.name, ObjectType.StoredProcedure);
                     _StoredProcGroup.Items.Add(_StoredProcData);
                     if (_IsSql2000)
                     {
                        GetSql2000Permissions(_Connection, _AccessOptions.LoginName, _StoredProcData);
                     }
                     GetDatabaseObjectPermissions(_Connection, _StoredProcData, _DatabaseData.ObjectName, _AccessOptions.LoginName);
                  }
                  _DatabaseData.ChildData.Add(_StoredProcGroup);
                  #endregion

                  #region Functions
                  AccessDataGroup _FunctionGroup = new AccessDataGroup("Functions", ObjectType.Function);
                  AccessDataGroup _TableValuedFunctionGroup = new AccessDataGroup("Table-valued Functions", ObjectType.Function);
                  AccessDataGroup _ScalarValuedFunctionGroup = new AccessDataGroup("Scalar-valued Functions", ObjectType.Function);
                  AccessDataGroup _AggregateFunctionGroup = new AccessDataGroup("Aggregate Functions", ObjectType.Function);
                  foreach (FunctionObject _Function in SQLObjects.GetFunctions(_Connection, _DatabaseData.ObjectName))
                  {
                     AccessData _FunctionData = new AccessData(_DatabaseData, _Function.name, ObjectType.Function);
                     switch (_Function.xtype)
                     {
                        case "IF":
                        case "TF":
                           _TableValuedFunctionGroup.Items.Add(_FunctionData);
                           break;
                        case "FN":
                           _ScalarValuedFunctionGroup.Items.Add(_FunctionData);
                           break;
                        case "AF":
                           _AggregateFunctionGroup.Items.Add(_FunctionData);
                           break;
                     }

                     if (_IsSql2000)
                     {
                        GetSql2000Permissions(_Connection, _AccessOptions.LoginName, _FunctionData);
                     }
                     GetDatabaseObjectPermissions(_Connection, _FunctionData, _DatabaseData.ObjectName, _AccessOptions.LoginName);
                  }

                  _FunctionGroup.Groups.Add(_TableValuedFunctionGroup);
                  _FunctionGroup.Groups.Add(_ScalarValuedFunctionGroup);
                  _FunctionGroup.Groups.Add(_AggregateFunctionGroup);

                  _DatabaseData.ChildData.Add(_FunctionGroup);
                  #endregion

                  if (SQLHelpers.Is2005orGreater(_Connection))
                  {
                     #region Assemblies
                     AccessDataGroup _AssembliesGroup = new AccessDataGroup("Assemblies", ObjectType.Assembly);
                     FillDatabaseGroupFromTable(_AssembliesGroup, _DatabaseData, "sys.assemblies", _Connection, _AccessOptions.LoginName);
                     _DatabaseData.ChildData.Add(_AssembliesGroup);
                     #endregion

                     #region XML Schema Collections
                     AccessDataGroup _XmlSchemaCollectionGroup = new AccessDataGroup("XML Schema Collections", ObjectType.XmlSchemaCollection);
                     FillDatabaseGroupFromTable(_XmlSchemaCollectionGroup, _DatabaseData, "sys.xml_schema_collections", _Connection, _AccessOptions.LoginName);
                     _DatabaseData.ChildData.Add(_XmlSchemaCollectionGroup);
                     #endregion

                     #region Full-text catalog
                     AccessDataGroup _FullTextGroup = new AccessDataGroup("Full Text Catalogs", ObjectType.FullTextCatalog);
                     FillDatabaseGroupFromTable(_FullTextGroup, _DatabaseData, "dbo.sysfulltextcatalogs", _Connection, _AccessOptions.LoginName);
                     _DatabaseData.ChildData.Add(_FullTextGroup);
                     #endregion

                     #region Synonyms
                     AccessDataGroup _SynonymGroup = new AccessDataGroup("Synonyms", ObjectType.Synonym);
                     FillDatabaseGroupFromTable(_SynonymGroup, _DatabaseData, "sys.synonyms", _Connection, _AccessOptions.LoginName);
                     _DatabaseData.ChildData.Add(_SynonymGroup);
                     #endregion

                     #region Security
                     AccessDataGroup _SecurityGroup = new AccessDataGroup("Security", ObjectType.None);
                     #region Users
                     AccessDataGroup _UsersGroup = new AccessDataGroup("Users", ObjectType.DatabaseUser);
                     FillDataGroupWithReader(_UsersGroup, _DatabaseData,
                                 string.Format("SELECT name FROM {0}.dbo.sysusers WHERE isntuser = 1 OR issqluser = 1 ORDER BY name", SQLHelpers.CreateSafeDatabaseName(_DatabaseData.ObjectName)),
                                 _Connection, _AccessOptions.LoginName);
                     _SecurityGroup.Groups.Add(_UsersGroup);
                     #endregion

                     #region Database Roles
                     AccessDataGroup _DatabaseRolesGroup = new AccessDataGroup("Database Roles", ObjectType.DatabaseRole);
                     FillDataGroupWithReader(_DatabaseRolesGroup, _DatabaseData,
                              string.Format("SELECT name FROM {0}.dbo.sysusers WHERE issqlrole = 1 ORDER BY name", SQLHelpers.CreateSafeDatabaseName(_DatabaseData.ObjectName)),
                              _Connection, _AccessOptions.LoginName);
                     _SecurityGroup.Groups.Add(_DatabaseRolesGroup);
                     #endregion

                     #region Application Roles
                     AccessDataGroup _ApplicationRolesGroup = new AccessDataGroup("Application Roles", ObjectType.DatabaseRole);
                     FillDataGroupWithReader(_ApplicationRolesGroup, _DatabaseData,
                              string.Format("SELECT name FROM {0}.dbo.sysusers WHERE isapprole = 1 ORDER BY name", SQLHelpers.CreateSafeDatabaseName(_DatabaseData.ObjectName)),
                              _Connection, _AccessOptions.LoginName);
                     _SecurityGroup.Groups.Add(_ApplicationRolesGroup);
                     #endregion

                     #region Schemas
                     AccessDataGroup _SchemaGroup = new AccessDataGroup("Schemas", ObjectType.Schema);
                     FillDataGroupWithReader(_SchemaGroup, _DatabaseData,
                           string.Format("SELECT name FROM {0}.sys.schemas ORDER BY name", SQLHelpers.CreateSafeDatabaseName(_DatabaseData.ObjectName)),
                           _Connection, _AccessOptions.LoginName);
                     _SecurityGroup.Groups.Add(_SchemaGroup);
                     #endregion

                     #region Asymmetric Keys
                     AccessDataGroup _AsymmetricKeyGroup = new AccessDataGroup("Asymmetric Keys", ObjectType.AsymmetricKey);
                     FillDatabaseGroupFromTable(_AsymmetricKeyGroup, _DatabaseData, "sys.asymmetric_keys", _Connection, _AccessOptions.LoginName);
                     _SecurityGroup.Groups.Add(_AsymmetricKeyGroup);
                     #endregion

                     #region Symmetric Keys
                     AccessDataGroup _SymmetricKeyGroup = new AccessDataGroup("Symmetric Keys", ObjectType.SymmetricKey);
                     FillDatabaseGroupFromTable(_SymmetricKeyGroup, _DatabaseData, "sys.symmetric_keys", _Connection, _AccessOptions.LoginName);
                     _SecurityGroup.Groups.Add(_SymmetricKeyGroup);
                     #endregion

                     #region Certificates
                     AccessDataGroup _CertificatesGroup = new AccessDataGroup("Certificates", ObjectType.Certificates);
                     FillDatabaseGroupFromTable(_CertificatesGroup, _DatabaseData, "sys.certificates", _Connection, _AccessOptions.LoginName);
                     _SecurityGroup.Groups.Add(_CertificatesGroup);
                     #endregion
                     _DatabaseData.ChildData.Add(_SecurityGroup);
                     #endregion
                  }
               }
               #endregion

               if (_IsSql2000)
               {
                  GetSql2000Permissions(_Connection, _AccessOptions.LoginName, _ServerData);
               }
               else
               {
                  #region Server Permissions
                  string _ServerSecurableSql = "SELECT bp.permission_name " +
                                               "FROM sys.server_permissions AS perm " +
                                               "INNER JOIN sys.server_principals AS grantee_principal ON grantee_principal.principal_id = perm.grantee_principal_id " +
                                               "INNER JOIN sys.fn_builtin_permissions(DEFAULT) bp ON perm.type = bp.type " +
                                               "WHERE grantee_principal.name = {0} " +
                                               "AND bp.class_desc = N'SERVER' " +
                                               "AND perm.state IN ('G', 'W')";

                  using (SqlCommand _PermissionsCommand = new SqlCommand(string.Format(_ServerSecurableSql, SQLHelpers.CreateSafeString(_AccessOptions.LoginName)), _Connection))
                  {
                     _PermissionsCommand.CommandTimeout = ToolsetOptions.commandTimeout;
                     using (SqlDataReader _Reader = _PermissionsCommand.ExecuteReader())
                     {
                        while (_Reader.Read())
                        {
                           _ServerData.AccessList.Add(_Reader.GetString(_Reader.GetOrdinal("permission_name")));
                        }
                     }
                  }
                  #endregion
               
                  #region Endpoints
                  AccessDataGroup _ServerEndPointsGroup = new AccessDataGroup("Server Endpoints", ObjectType.ServerEndPoint);
                  string _EndPointSql = "SELECT ep.name, perm.permission_name " +
                                        "FROM sys.endpoints AS ep " +
                                        "INNER JOIN sys.server_permissions AS perm ON perm.major_id=ep.endpoint_id AND perm.class=105 " +
                                        "INNER JOIN sys.server_principals AS grantee_principal ON grantee_principal.principal_id = perm.grantee_principal_id " +
                                        "WHERE grantee_principal.name={0} " +
                                        "AND perm.state IN ('G', 'W') " +
                                        "ORDER BY 1, 2";

                  PopulateServerSecurableGroup(_ServerData,_ServerEndPointsGroup, _Connection, _EndPointSql, _AccessOptions.LoginName);                  
                  _ServerData.ChildData.Add(_ServerEndPointsGroup);
                  #endregion

                  #region Logins
                  AccessDataGroup _ServerLoginGroup = new AccessDataGroup("Server Logins", ObjectType.ServerLogin);
                  string _ServerLoginSql = "SELECT sp.name, perm.permission_name " +
                       "FROM sys.server_principals AS sp " +
                       "INNER JOIN sys.server_permissions AS perm ON perm.major_id=sp.principal_id AND perm.class=101 " +
                       "INNER JOIN sys.server_principals AS grantee_principal ON grantee_principal.principal_id = perm.grantee_principal_id " +
                       "WHERE grantee_principal.name= {0} " +
                       "AND sp.principal_id not between 101 and 255 " +
                       "AND sp.name <> N'##MS_AgentSigningCertificate##' " +
                       "AND perm.state IN ('G', 'W') " +
                       "ORDER BY 1, 2";

                  PopulateServerSecurableGroup(_ServerData, _ServerLoginGroup, _Connection, _ServerLoginSql, _AccessOptions.LoginName);
                  _ServerData.ChildData.Add(_ServerLoginGroup);
                  #endregion
               }
            }
         }
         catch (Exception exc)
         {
            _ServerData.DataException = exc;
         }
         return _ServerData;
      }

      private static void PopulateServerSecurableGroup(AccessData serverData, AccessDataGroup dataGroup, SqlConnection conn, string sql, string login)
      {
         using (SqlCommand _Command = new SqlCommand(string.Format(sql, SQLHelpers.CreateSafeString(login)), conn))
         {
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            using (SqlDataReader _Reader = _Command.ExecuteReader())
            {
               AccessData _AccessData = null;
               while (_Reader.Read())
               {
                  string _ObjectName = _Reader.GetString(_Reader.GetOrdinal("name"));
                  if (_AccessData == null || _AccessData.ObjectName != _ObjectName)
                  {
                     _AccessData = new AccessData(serverData, _ObjectName, dataGroup.Type);
                     dataGroup.Items.Add(_AccessData);
                  }
                  _AccessData.AccessList.Add(_Reader.GetString(_Reader.GetOrdinal("permission_name")));
               }
            }
         }
      }

      /// <summary>
      /// Populates a datagroup with data from the name column specified table.
      /// </summary>
      private static void FillDatabaseGroupFromTable(AccessDataGroup group, AccessData databaseData, string table, SqlConnection connection, string loginName)
      {
         FillDataGroupWithReader(group, databaseData,
                                 string.Format("SELECT name FROM {0}.{1} ORDER BY name", SQLHelpers.CreateSafeDatabaseName(databaseData.ObjectName), table),
                                 connection, true, loginName);
      }

      /// <summary>
      /// Populates a datagroup with data from the specified sql command.
      /// </summary>
      private static void FillDataGroupWithReader(AccessDataGroup group, AccessData parentData, string sqlCommand, SqlConnection connection)
      {
         FillDataGroupWithReader(group, parentData, sqlCommand, connection, false, null);
      }

      /// <summary>
      /// Populates a datagroup with data from the specified sql command.
      /// </summary>
      private static void FillDataGroupWithReader(AccessDataGroup group, AccessData parentData, string sqlCommand, SqlConnection connection, string loginName)
      {
         FillDataGroupWithReader(group, parentData, sqlCommand, connection, true, loginName);
      }

      /// <summary>
      /// Populates a datagroup with data from the specified sql command.
      /// </summary>
      private static void FillDataGroupWithReader(AccessDataGroup group, AccessData parentData, string sqlCommand, SqlConnection connection, bool populateSecurablePermissions, string loginName)
      {
         using (SqlCommand _Command = new SqlCommand(sqlCommand, connection))
         using (SqlDataReader _Reader = _Command.ExecuteReader())
         {
            while (_Reader.Read())
            {
               group.Items.Add(new AccessData(parentData, _Reader.GetString(0), group.Type));
            }
         }

         if (populateSecurablePermissions)
         {
            foreach (AccessData _Data in group.Items)
            {
               GetDatabaseObjectPermissions(connection, _Data, parentData.ObjectName, loginName);
            }
         }
      }

      private static void GetDatabaseObjectPermissions(SqlConnection connection, AccessData data, string databaseName, string loginName)
      {
         string _SecurableClass = string.Empty;
         switch (data.Type)
         {
            case ObjectType.Database:
               _SecurableClass = "DATABASE";
               break;
            case ObjectType.Table:
            case ObjectType.View:
            case ObjectType.StoredProcedure:
            case ObjectType.Function:
            case ObjectType.Synonym:
               _SecurableClass = "OBJECT";
               break;
            case ObjectType.Assembly:
               _SecurableClass = "ASSEMBLY";
               break;
            case ObjectType.XmlSchemaCollection:
               _SecurableClass = "XML SCHEMA COLLECTION";
               break;
            case ObjectType.FullTextCatalog:
               _SecurableClass = "FULLTEXT CATALOG";
               break;
            case ObjectType.DatabaseUser:
               _SecurableClass = "USER";
               break;
            case ObjectType.DatabaseRole:
               _SecurableClass = "ROLE";
               break;
            case ObjectType.Schema:
               _SecurableClass = "SCHEMA";
               break;
            case ObjectType.AsymmetricKey:
               _SecurableClass = "ASYMMETRIC KEY";
               break;
            case ObjectType.SymmetricKey:
               _SecurableClass = "SYMMETRIC KEY";
               break;
               
         }

         string _InitialDatabase = connection.Database;
         connection.ChangeDatabase(databaseName);

         string _SecurablePermissionsSql = string.Format("EXECUTE AS login = {0} \n" +
                                         "SELECT permission_name, subentity_name \n" +
                                         "FROM fn_my_permissions({1}, '{2}') \n" +
                                         "ORDER BY 1, 2 \n" +
                                         "REVERT;", SQLHelpers.CreateSafeString(loginName), 
                                         SQLHelpers.CreateSafeString(data.ObjectName),
                                         _SecurableClass);

         using (SqlCommand _Command = new SqlCommand(_SecurablePermissionsSql, connection))
         using (SqlDataReader _Reader = _Command.ExecuteReader())
         {
            while (_Reader.Read())
            {
               string _SubEntity = _Reader.GetString(_Reader.GetOrdinal("subentity_name")).Trim();
               if (_SubEntity.Length == 0)
               {
                  data.AccessList.Add(_Reader.GetString(_Reader.GetOrdinal("permission_name")));
               }
               else
               {
                  if (data.Type == ObjectType.Table || data.Type == ObjectType.View)
                  {
                     foreach (AccessDataGroup _Group in data.ChildData)
                     {
                        if (_Group.Type == ObjectType.Column)
                        {
                           AccessData _ColumnData = _Group.Items.Find(delegate(AccessData internalData) { return internalData.ObjectName.ToUpperInvariant() == _SubEntity.ToUpperInvariant(); });
                           if (_ColumnData != null)
                           {
                              _ColumnData.AccessList.Add(_Reader.GetString(_Reader.GetOrdinal("permission_name")));
                           }
                           break;
                        }
                     }
                  }
               }
            }
         }
      
         connection.ChangeDatabase(_InitialDatabase);
      }

      /// <summary>
      /// Retrieves permissions on a SQL 2000 server, applying the PERMISSIONS() function.
      /// </summary>
      private static void GetSql2000Permissions(SqlConnection connection, string loginName, AccessData data)
      {
         string _InitialDatabase = connection.Database;

         string _PermissionsSql = string.Format("EXECUTE AS login = {0} \n", SQLHelpers.CreateSafeString(loginName));

         switch (data.Type)
         {
            case ObjectType.Server:
               if (connection.Database.ToUpperInvariant() != "MASTER")
               {
                  connection.ChangeDatabase("master");
               }
               _PermissionsSql += "SELECT PERMISSIONS() \n";
               break;
            case ObjectType.Database:
               connection.ChangeDatabase(data.ObjectName);
               _PermissionsSql += "SELECT PERMISSIONS() \n";
               break;
            case ObjectType.Column:
               connection.ChangeDatabase(data.Parent.Parent.ObjectName);
               _PermissionsSql += string.Format("SELECT PERMISSIONS(OBJECT_ID({0}), {1}) \n", SQLHelpers.CreateSafeString(data.Parent.ObjectName),
                                                                                                SQLHelpers.CreateSafeString(data.ObjectName));
               break;
            default:
               connection.ChangeDatabase(data.Parent.ObjectName);
               _PermissionsSql += string.Format("SELECT PERMISSIONS(OBJECT_ID({0})) \n", SQLHelpers.CreateSafeString(data.ObjectName));
               break;
         }
         _PermissionsSql += "REVERT;";

         int _PermissionBitmap = int.MinValue;
         try
         {
            using (SqlCommand _Command = new SqlCommand(_PermissionsSql, connection))
            {
               _PermissionBitmap = (int)_Command.ExecuteScalar();
            }
         }
         catch (SqlException exc)
         {
            if (exc.Number != 916)  //ignore database not accessible exception
            {
               throw;
            }
         }

         switch (data.Type)
         {
            case ObjectType.Server:
               if ((_PermissionBitmap & 1) == 1)
               {
                  data.AccessList.Add("CREATE DATABASE");
               }
               break;
            case ObjectType.Database:
               if ((_PermissionBitmap & 2) == 2)
               {
                  data.AccessList.Add("CREATE TABLE");
               }
               if ((_PermissionBitmap & 4) == 4)
               {
                  data.AccessList.Add("CREATE PROCEDURE");
               }
               if ((_PermissionBitmap & 8) == 8)
               {
                  data.AccessList.Add("CREATE VIEW");
               }
               if((_PermissionBitmap & 16) == 16)
               {
                  data.AccessList.Add("CREATE RULE");
               }
               if((_PermissionBitmap & 32) == 32)
               {
                  data.AccessList.Add("CREATE DEFAULT");
               }
               if((_PermissionBitmap & 64) == 64)
               {
                  data.AccessList.Add("BACKUP DATABASE");
               }
               if ((_PermissionBitmap & 128) == 128)
               {
                  data.AccessList.Add("BACKUP LOG");
               }
               break;
            case ObjectType.Column:
               if((_PermissionBitmap & 1) == 1)
               {
                  data.AccessList.Add("SELECT");
               }
               if((_PermissionBitmap & 2) == 2)
               {
                  data.AccessList.Add("UPDATE");
               }
               if ((_PermissionBitmap & 4) == 4)
               {
                  data.AccessList.Add("REFERENCES");
               }
               break;
            default:
               if((_PermissionBitmap & 1) == 1)
               {
                  data.AccessList.Add("SELECT ALL");
               }
               if((_PermissionBitmap & 2) == 2)
               {
                  data.AccessList.Add("UPDATE ALL");
               }
               if((_PermissionBitmap & 4) == 4)
               {
                  data.AccessList.Add("REFERENCES ALL");
               }
               if((_PermissionBitmap & 8) == 8)
               {
                  data.AccessList.Add("INSERT");
               }
               if((_PermissionBitmap & 16) == 16)
               {
                  data.AccessList.Add("DELETE");
               }
               if((_PermissionBitmap & 32) == 32)
               {
                  data.AccessList.Add("EXECUTE");
               }
               if((_PermissionBitmap & 4096) == 4096)
               {
                  data.AccessList.Add("SELECT ANY");
               }
               if((_PermissionBitmap & 8192) == 8192)
               {
                  data.AccessList.Add("UPDATE ANY");
               }
               if((_PermissionBitmap & 16384) == 16384)
               {
                  data.AccessList.Add("REFERENCES ANY");
               }
               break;
         }

         if (connection.Database != _InitialDatabase)
         {
            connection.ChangeDatabase(_InitialDatabase);
         }
      }
   }
}
