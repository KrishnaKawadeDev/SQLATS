using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Collections;

namespace Idera.SqlAdminToolset.WhoHasAccess
{
   internal class PermissionsHelper
   {
        private static object threadLock = new object();

        /// <summary>
        /// Retrieves all data elements for a server.
        /// </summary>
        public static AccessData HarvestData(ServerInformation serverInformation, int commandTimeout, JobPoolOptions options)
      {
         AccessData _ServerData = new AccessData(serverInformation, serverInformation.Name, ObjectType.Server);
            lock (threadLock)
            {
                try
                {
                    using (SqlConnection _Connection = Connection.OpenConnection(serverInformation.Name, serverInformation.SqlCredentials))
                    {
                        #region Database
                        AccessDataGroup _DatabaseGroup = new AccessDataGroup("Databases", ObjectType.Database);
                        foreach (DatabaseObject _Database in SQLObjects.GetUserDatabases(_Connection))
                        {
                            AccessData _DatabaseData = new AccessData(_ServerData, _Database.name, ObjectType.Database);

                            #region Tables
                            AccessDataGroup _TableGroup = new AccessDataGroup("Tables", ObjectType.Table);
                            foreach (TableObject _Table in SQLObjects.GetTables(_Connection, _Database.name))
                            {
                                AccessData _TableData = new AccessData(_DatabaseData, _Table.name, ObjectType.Table);

                                AccessDataGroup _ColumnsGroup = new AccessDataGroup("Columns", ObjectType.Column);
                                foreach (ColumnObject _Column in SQLObjects.GetTableColumns(_Connection, _Database.name, _Table.name))
                                {
                                    _ColumnsGroup.Items.Add(new AccessData(_TableData, _Column.name, ObjectType.Column));
                                }
                                _TableData.ChildData.Add(_ColumnsGroup);

                                _TableGroup.Items.Add(_TableData);
                            }
                            _DatabaseData.ChildData.Add(_TableGroup);
                            #endregion

                            #region Views
                            AccessDataGroup _ViewGroup = new AccessDataGroup("Views", ObjectType.View);
                            foreach (ViewObject _View in SQLObjects.GetViews(_Connection, _Database.name))
                            {
                                AccessData _ViewData = new AccessData(_DatabaseData, _View.name, ObjectType.View);

                                AccessDataGroup _ColumnsGroup = new AccessDataGroup("Columns", ObjectType.Column);
                                foreach (ColumnObject _Column in SQLObjects.GetViewColumns(_Connection, _Database.name, _View.name))
                                {
                                    _ColumnsGroup.Items.Add(new AccessData(_ViewData, _Column.name, ObjectType.Column));
                                }
                                _ViewData.ChildData.Add(_ColumnsGroup);

                                _ViewGroup.Items.Add(_ViewData);
                            }
                            _DatabaseData.ChildData.Add(_ViewGroup);
                            #endregion

                            #region Stored Procs
                            AccessDataGroup _StoredProcGroup = new AccessDataGroup("Stored Procedures", ObjectType.StoredProcedure);
                            foreach (StoredProcObject _StoredProc in SQLObjects.GetStoredProcs(_Connection, _Database.name))
                            {
                                _StoredProcGroup.Items.Add(new AccessData(_DatabaseData, _StoredProc.name, ObjectType.StoredProcedure));
                            }
                            _DatabaseData.ChildData.Add(_StoredProcGroup);
                            #endregion

                            #region Functions
                            AccessDataGroup _FunctionGroup = new AccessDataGroup("Functions", ObjectType.Function);
                            AccessDataGroup _TableValuedFunctionGroup = new AccessDataGroup("Table-valued Functions", ObjectType.Function);
                            AccessDataGroup _ScalarValuedFunctionGroup = new AccessDataGroup("Scalar-valued Functions", ObjectType.Function);
                            AccessDataGroup _AggregateFunctionGroup = new AccessDataGroup("Aggregate Functions", ObjectType.Function);
                            foreach (FunctionObject _Function in SQLObjects.GetFunctions(_Connection, _Database.name))
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
                                FillDatabaseGroupFromTable(_AssembliesGroup, _DatabaseData, "sys.assemblies", _Connection);
                                _DatabaseData.ChildData.Add(_AssembliesGroup);
                                #endregion

                                #region XML Schema Collections
                                AccessDataGroup _XmlSchemaCollectionGroup = new AccessDataGroup("XML Schema Collections", ObjectType.XmlSchemaCollection);
                                FillDatabaseGroupFromTable(_XmlSchemaCollectionGroup, _DatabaseData, "sys.xml_schema_collections", _Connection);
                                _DatabaseData.ChildData.Add(_XmlSchemaCollectionGroup);
                                #endregion

                                #region Full-text catalog
                                AccessDataGroup _FullTextGroup = new AccessDataGroup("Full Text Catalogs", ObjectType.FullTextCatalog);
                                FillDatabaseGroupFromTable(_FullTextGroup, _DatabaseData, "dbo.sysfulltextcatalogs", _Connection);
                                _DatabaseData.ChildData.Add(_FullTextGroup);
                                #endregion

                                #region Synonyms
                                AccessDataGroup _SynonymGroup = new AccessDataGroup("Synonyms", ObjectType.Synonym);
                                FillDatabaseGroupFromTable(_SynonymGroup, _DatabaseData, "sys.synonyms", _Connection);
                                _DatabaseData.ChildData.Add(_SynonymGroup);
                                #endregion

                                #region Security
                                AccessDataGroup _SecurityGroup = new AccessDataGroup("Security", ObjectType.None);
                                #region Users
                                AccessDataGroup _UsersGroup = new AccessDataGroup("Users", ObjectType.DatabaseUser);
                                FillDataGroupWithReader(_UsersGroup, _DatabaseData,
                                            string.Format("SELECT name FROM {0}.dbo.sysusers WHERE isntuser = 1 OR issqluser = 1 ORDER BY name", SQLHelpers.CreateSafeDatabaseName(_Database.name)),
                                            _Connection);
                                _SecurityGroup.Groups.Add(_UsersGroup);
                                #endregion

                                #region Database Roles
                                AccessDataGroup _DatabaseRolesGroup = new AccessDataGroup("Database Roles", ObjectType.DatabaseRole);
                                FillDataGroupWithReader(_DatabaseRolesGroup, _DatabaseData,
                                         string.Format("SELECT name FROM {0}.dbo.sysusers WHERE issqlrole = 1 ORDER BY name", SQLHelpers.CreateSafeDatabaseName(_Database.name)),
                                         _Connection);
                                _SecurityGroup.Groups.Add(_DatabaseRolesGroup);
                                #endregion

                                #region Application Roles
                                AccessDataGroup _ApplicationRolesGroup = new AccessDataGroup("Application Roles", ObjectType.DatabaseRole);
                                FillDataGroupWithReader(_ApplicationRolesGroup, _DatabaseData,
                                         string.Format("SELECT name FROM {0}.dbo.sysusers WHERE isapprole = 1 ORDER BY name", SQLHelpers.CreateSafeDatabaseName(_Database.name)),
                                         _Connection);
                                _SecurityGroup.Groups.Add(_ApplicationRolesGroup);
                                #endregion

                                #region Schemas
                                AccessDataGroup _SchemaGroup = new AccessDataGroup("Schemas", ObjectType.Schema);
                                FillDataGroupWithReader(_SchemaGroup, _DatabaseData,
                                      string.Format("SELECT name FROM {0}.sys.schemas ORDER BY name", SQLHelpers.CreateSafeDatabaseName(_Database.name)),
                                      _Connection);
                                _SecurityGroup.Groups.Add(_SchemaGroup);
                                #endregion

                                #region Asymmetric Keys
                                AccessDataGroup _AsymmetricKeyGroup = new AccessDataGroup("Asymmetric Keys", ObjectType.AsymmetricKey);
                                FillDatabaseGroupFromTable(_AsymmetricKeyGroup, _DatabaseData, "sys.asymmetric_keys", _Connection);
                                _SecurityGroup.Groups.Add(_AsymmetricKeyGroup);
                                #endregion

                                #region Symmetric Keys
                                AccessDataGroup _SymmetricKeyGroup = new AccessDataGroup("Symmetric Keys", ObjectType.SymmetricKey);
                                FillDatabaseGroupFromTable(_SymmetricKeyGroup, _DatabaseData, "sys.symmetric_keys", _Connection);
                                _SecurityGroup.Groups.Add(_SymmetricKeyGroup);
                                #endregion

                                #region Certificates
                                AccessDataGroup _CertificatesGroup = new AccessDataGroup("Certificates", ObjectType.Certificates);
                                FillDatabaseGroupFromTable(_CertificatesGroup, _DatabaseData, "sys.certificates", _Connection);
                                _SecurityGroup.Groups.Add(_CertificatesGroup);
                                #endregion
                                _DatabaseData.ChildData.Add(_SecurityGroup);
                                #endregion
                            }
                            _DatabaseGroup.Items.Add(_DatabaseData);
                        }
                        _ServerData.ChildData.Add(_DatabaseGroup);
                        #endregion

                        if (SQLHelpers.Is2005orGreater(_Connection))
                        {
                            #region Server Permissions
                            AccessDataGroup _ServerPermissionGroup = new AccessDataGroup("Server Permissions", ObjectType.ServerSecurable);
                            using (SqlCommand _PermissionsCommand = new SqlCommand("SELECT permission_name FROM sys.fn_builtin_permissions(DEFAULT) WHERE class_desc = N'SERVER' ORDER BY permission_name", _Connection))
                            {
                                _PermissionsCommand.CommandTimeout = ToolsetOptions.commandTimeout;
                                using (SqlDataReader _Reader = _PermissionsCommand.ExecuteReader())
                                {
                                    while (_Reader.Read())
                                    {
                                        _ServerPermissionGroup.Items.Add(new AccessData(_ServerData, _Reader.GetString(0), ObjectType.ServerSecurable));
                                    }
                                }
                            }
                            _ServerData.ChildData.Add(_ServerPermissionGroup);
                            #endregion

                            #region Endpoints
                            AccessDataGroup _ServerEndPointsGroup = new AccessDataGroup("Server Endpoints", ObjectType.ServerEndPoint);
                            using (SqlCommand _EndPointsCommand = new SqlCommand("SELECT name FROM sys.endpoints ORDER BY name", _Connection))
                            {
                                _EndPointsCommand.CommandTimeout = ToolsetOptions.commandTimeout;
                                using (SqlDataReader _Reader = _EndPointsCommand.ExecuteReader())
                                {
                                    while (_Reader.Read())
                                    {
                                        _ServerEndPointsGroup.Items.Add(new AccessData(_ServerData, _Reader.GetString(0), ObjectType.ServerEndPoint));
                                    }
                                }
                            }
                            _ServerData.ChildData.Add(_ServerEndPointsGroup);
                            #endregion

                            #region Logins
                            AccessDataGroup _ServerLoginGroup = new AccessDataGroup("Server Logins", ObjectType.ServerLogin);
                            foreach (LoginObject _Login in SQLObjects.GetServerLogins(_Connection))
                            {
                                _ServerLoginGroup.Items.Add(new AccessData(_ServerData, _Login.name, ObjectType.ServerLogin));
                            }
                            _ServerData.ChildData.Add(_ServerLoginGroup);
                            #endregion
                        }

                        #region Server Roles
                        AccessDataGroup _RolesGroup = new AccessDataGroup("Server Roles", ObjectType.ServerRole);
                        foreach (RoleObject _Role in SQLObjects.GetServerRoles(_Connection))
                        {
                            _RolesGroup.Items.Add(new AccessData(_ServerData, _Role.name, ObjectType.ServerRole));
                        }
                        _ServerData.ChildData.Add(_RolesGroup);
                        #endregion
                    }
                }
                catch (Exception exc)
                {
                    _ServerData.DataException = exc;
                }
            }
         return _ServerData;
      }

      /// <summary>
      /// Fills data for an individual element.
      /// </summary>
      /// <param name="data"></param>
      /// <param name="commandTimeout"></param>
      public static void FillData(AccessData data)
      {
         try
         {
            switch (data.Type)
            {
               case ObjectType.Server:
                  FillServerPermissions(data);
                  break;
               case ObjectType.Database:
                  FillDatabasePermissions(data);
                  break;
               case ObjectType.Table:
               case ObjectType.View:
               case ObjectType.StoredProcedure:
               case ObjectType.Function:
               case ObjectType.Synonym:
                  FillDatabaseObjectPermissions(data);
                  break;
               case ObjectType.Column:
                  FillColumnPermissions(data);
                  break;
               case ObjectType.ServerSecurable:
                  FillServerSecurablesPermissions(data);
                  break;
               case ObjectType.ServerEndPoint:
                  FillEndPointPermissions(data);
                  break;
               case ObjectType.ServerLogin:
                  FillServerLoginPermissions(data);
                  break;
               case ObjectType.ServerRole:
                  FillServerRoleMembers(data);
                  break;
               default:
                  FillAdvancedDatabaseObjectPermissions(data);
                  break;
            }
         
            data.PermissionsLoaded = true;
         }
         catch (Exception exc)
         {
            data.DataException = exc;
            Messaging.ShowException("fill", exc);
         }
      }

      /// <summary>
      /// Populate server permissions
      /// </summary>
      private static void FillServerPermissions(AccessData data)
      {
         using (SqlConnection _Connection = Connection.OpenConnection(data.ServerInfo.Name, data.ServerInfo.SqlCredentials))
         {
            foreach (LoginObject _Login in SQLObjects.GetServerLogins(_Connection))
            {
               AccessPermissions _LoginPermissions = new AccessPermissions(_Login.name);
               _LoginPermissions.DetailRelation = AccessDetailsRelation.MemberOf;
               _LoginPermissions.UserType = UserType.SqlUser;
               if(_Login.isntgroup == 1)
               {
                  _LoginPermissions.UserType = UserType.NtGroup;
               }
               if (_Login.isntuser == 1)
               {
                  _LoginPermissions.UserType = UserType.NtUser;
               }
               if(_Login.bulkadmin == 1)
               {
                  _LoginPermissions.Permissions.Add("bulkadmin");
               }
               if (_Login.dbcreator == 1)
               {
                  _LoginPermissions.Permissions.Add("dbcreator");
               }
               if (_Login.diskadmin == 1)
               {
                  _LoginPermissions.Permissions.Add("diskadmin");
               }
               if (_Login.processadmin == 1)
               {
                  _LoginPermissions.Permissions.Add("processadmin");
               }
               if (_Login.securityadmin == 1)
               {
                  _LoginPermissions.Permissions.Add("securityadmin");
               }
               if (_Login.serveradmin == 1)
               {
                  _LoginPermissions.Permissions.Add("serveradmin");
               }
               if (_Login.setupadmin == 1)
               {
                  _LoginPermissions.Permissions.Add("setupadmin");
               }
               if (_Login.sysadmin == 1)
               {
                  _LoginPermissions.Permissions.Add("sysadmin");
               }
               data.AccessList.Add(_LoginPermissions);
            }

         }
      }

      /// <summary>
      /// Populate database permissions
      /// </summary>
      private static void FillDatabasePermissions(AccessData data)
      {
         string _Sql =  "SELECT su.name as UserName, sl.name as LoginName, su.sid, su.islogin, su.isntname, su.isntgroup, su.isntuser, su.issqluser, su.issqlrole, su.isapprole " +
                        "FROM {0}..sysusers su " +
                        "LEFT JOIN master..syslogins sl on su.sid = sl.sid " +
                        "ORDER BY su.name";

         using (SqlConnection _Connection = Connection.OpenConnection(data.ServerInfo.Name, data.ObjectName, data.ServerInfo.SqlCredentials))
         {
            using (SqlCommand _Command = new SqlCommand(string.Format(_Sql, SQLHelpers.CreateSafeDatabaseName(data.ObjectName)), _Connection))
            {
               _Command.CommandTimeout = ToolsetOptions.commandTimeout;

               using (SqlDataReader _Reader = _Command.ExecuteReader())
               {
                  while (_Reader.Read())
                  {
                     data.AccessList.Add(FillAccessPermissions(_Reader));
                  }
               }

               //Add permissions
               RetrieveAccessRestrictions(_Connection, null, data.AccessList, AccessDetailsRelation.AccessTo);

               //Populate Groups
               string _GroupMembersSql = "SELECT su1.name as UserName, sl.name as LoginName, su1.sid, su1.islogin, su1.isntname, su1.isntgroup, su1.isntuser, su1.issqluser, su1.issqlrole, su1.isapprole " +
                                         "FROM {0}..sysusers su1 " +
                                         "INNER JOIN {0}..sysmembers sm ON sm.memberuid = su1.uid " +
                                         "INNER JOIN {0}..sysusers su2 ON sm.groupuid = su2.uid " +
                                         "LEFT JOIN master..syslogins sl on su1.sid = sl.sid " +
                                         "WHERE su2.name = {1}";
               foreach (AccessPermissions _DatabasePermissions in data.AccessList)
               {
                  if (_DatabasePermissions.UserType == UserType.SqlRole)
                  {
                     _Command.CommandText = string.Format(_GroupMembersSql,
                                                SQLHelpers.CreateSafeDatabaseName(data.ObjectName),
                                                SQLHelpers.CreateSafeString(_DatabasePermissions.UserName));
                     using (SqlDataReader _Reader = _Command.ExecuteReader())
                     {
                        while (_Reader.Read())
                        {
                           _DatabasePermissions.GroupMembers.Add(FillAccessPermissions(_Reader));
                        }
                     }
                     RetrieveAccessRestrictions(_Connection, null, _DatabasePermissions.GroupMembers, AccessDetailsRelation.AccessTo);
                  }
                  else if (_DatabasePermissions.UserType == UserType.NtGroup)
                  {
                     _DatabasePermissions.GroupMembers.AddRange(GetNtGroupMembers(_DatabasePermissions.LoginName));
                  }
               }
            }
         }
      }

      /// <summary>
      /// Fills a new AccessPermissions object with data from the SqlDataReader.
      /// </summary>
      private static AccessPermissions FillAccessPermissions(SqlDataReader reader)
      {
         string _Login = null;
         if (reader.GetValue(reader.GetOrdinal("LoginName")) != DBNull.Value)
         {
            _Login = reader.GetString(reader.GetOrdinal("LoginName"));
         }
         AccessPermissions _Permissions = new AccessPermissions(_Login);
         _Permissions.UserName = reader.GetString(reader.GetOrdinal("UserName"));

         if (reader.GetInt32(reader.GetOrdinal("isntgroup")) == 1)
         {
            _Permissions.UserType = UserType.NtGroup;
         }
         if (reader.GetInt32(reader.GetOrdinal("isntuser")) == 1)
         {
            _Permissions.UserType = UserType.NtUser;
         }
         if (reader.GetInt32(reader.GetOrdinal("issqluser")) == 1)
         {
            _Permissions.UserType = UserType.SqlUser;
         }
         if (reader.GetInt32(reader.GetOrdinal("issqlrole")) == 1)
         {
            _Permissions.UserType = UserType.SqlRole;
         }
         if (reader.GetInt32(reader.GetOrdinal("isapprole")) == 1)
         {
            _Permissions.UserType = UserType.AppRole;
         }
         return _Permissions;
      }

      /// <summary>
      /// Populate table permissions
      /// </summary>
      private static void FillDatabaseObjectPermissions(AccessData data)
      {
         foreach (AccessPermissions _Permission in data.Parent.AccessList)
         {
            data.AccessList.Add(_Permission.Copy());
         }

         using (SqlConnection _Connection = Connection.OpenConnection(data.ServerInfo.Name, data.Parent.ObjectName, data.ServerInfo.SqlCredentials))
         {
            RetrieveAccessRestrictions(_Connection, data.ObjectName, data.AccessList, AccessDetailsRelation.AccessTo);
         }
      }

      /// <summary>
      /// Populate column permissions
      /// </summary>
      private static void FillColumnPermissions(AccessData data)
      {
         foreach (AccessPermissions _Permission in data.Parent.AccessList)
         {
            AccessPermissions _ColumnPermissions = _Permission.Copy();
            data.AccessList.Add(_ColumnPermissions);
            foreach (ObjectAccessDetails _AccessDetails in _Permission.Permissions)
            {
               if (_AccessDetails.Column.ToUpperInvariant() == data.ObjectName.ToUpperInvariant())
               {
                  _ColumnPermissions.Permissions.Add(_AccessDetails);
               }
            }
         }
      }

      /// <summary>
      /// Populates a datagroup with data from the name column specified table.
      /// </summary>
      private static void FillDatabaseGroupFromTable(AccessDataGroup group, AccessData databaseData, string table, SqlConnection connection)
      {
         FillDataGroupWithReader(group, databaseData,
                                 string.Format("SELECT name FROM {0}.{1} ORDER BY name", SQLHelpers.CreateSafeDatabaseName(databaseData.ObjectName), table),
                                 connection);
      }

      /// <summary>
      /// Populates a datagroup with data from the specified sql command.
      /// </summary>
      private static void FillDataGroupWithReader(AccessDataGroup group, AccessData parentData, string sqlCommand, SqlConnection connection)
      {
         using (SqlCommand _Command = new SqlCommand(sqlCommand, connection))
         using (SqlDataReader _Reader = _Command.ExecuteReader())
         {
            while (_Reader.Read())
            {
               group.Items.Add(new AccessData(parentData, _Reader.GetString(0), group.Type));
            }
         }
      }

      /// <summary>
      /// Fills permissions to server securables.
      /// </summary>
      private static void FillServerSecurablesPermissions(AccessData data)
      {
         foreach (AccessPermissions _Permission in data.Parent.AccessList)
         {
            data.AccessList.Add(_Permission.Copy());
         }

         string _Sql = "SELECT perm.[type], perm.[state] "+
                       "FROM sys.server_permissions perm INNER JOIN " +
                       "     sys.server_principals prin ON perm.grantee_principal_id = prin.principal_id " +
                       "WHERE permission_name = N'{0}' " +
                       "AND prin.name = N'{1}'";


         using (SqlConnection _Connection = Connection.OpenConnection(data.ServerInfo.Name, data.ServerInfo.SqlCredentials))
         using(SqlCommand _Command = new SqlCommand())
         {
            _Command.Connection = _Connection;
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            foreach (AccessPermissions _PermissionItem in data.AccessList)
            {
               _PermissionItem.DetailRelation = AccessDetailsRelation.AccessTo;
               string _UserName = string.IsNullOrEmpty(_PermissionItem.LoginName) ? _PermissionItem.UserName : _PermissionItem.LoginName;
               _Command.CommandText = string.Format(_Sql, data.ObjectName, _UserName);
               using (SqlDataReader _Reader = _Command.ExecuteReader())
               {
                  while (_Reader.Read())
                  {
                     ObjectAccessDetails _AccessDetails = new ObjectAccessDetails();
                     _AccessDetails.Owner = string.Empty;
                     _AccessDetails.Name = data.ObjectName;
                     _AccessDetails.Type = TranslatePermissionState(_Reader.GetString(_Reader.GetOrdinal("state")));
                     _AccessDetails.Action = TranslatePermissionAction(_Reader.GetString(_Reader.GetOrdinal("type")));
                     _AccessDetails.Column = string.Empty;
                     _PermissionItem.Permissions.Add(_AccessDetails);
                  }
               }
            }
         }  
      }

      /// <summary>
      /// Fills permissions to endpoints
      /// </summary>
      private static void FillEndPointPermissions(AccessData data)
      {
         string _Sql = "SELECT perm.[type], perm.[state] " +
                        "FROM sys.endpoints AS ep " +
                        "INNER JOIN sys.server_permissions AS perm ON perm.major_id=ep.endpoint_id AND perm.class=105 " +
                        "INNER JOIN sys.server_principals AS grantee_principal ON grantee_principal.principal_id = perm.grantee_principal_id " +
                        "WHERE ep.name=N'{0}' " +
                        "AND grantee_principal.name=N'{1}'";

         FillServerObjectPermission(data, _Sql);
      }

      private static void FillServerLoginPermissions(AccessData data)
      {
         string _Sql = "SELECT perm.[type], perm.[state] " +
                       "FROM sys.server_principals AS sp " +
                       "INNER JOIN sys.server_permissions AS perm ON perm.major_id=sp.principal_id AND perm.class=101 " +
                       "INNER JOIN sys.server_principals AS grantee_principal ON grantee_principal.principal_id = perm.grantee_principal_id " +
                       "WHERE sp.name=N'{0}' " +
                       "AND grantee_principal.name=N'{1}' " +
                       "AND sp.principal_id not between 101 and 255";

         FillServerObjectPermission(data, _Sql);
      }

      private static void FillServerRoleMembers(AccessData data)
      {
         string _Sql = string.Format("SELECT name, isntuser, isntgroup FROM master..syslogins WHERE sid <> 0 AND {0} = 1", data.ObjectName);

         using (SqlConnection _Connection = Connection.OpenConnection(data.ServerInfo.Name, data.ServerInfo.SqlCredentials))
         using (SqlCommand _Command = new SqlCommand(_Sql, _Connection))
         {
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            using (SqlDataReader _Reader = _Command.ExecuteReader())
            {
               while (_Reader.Read())
               {
                  AccessPermissions _User = new AccessPermissions(_Reader.GetString(_Reader.GetOrdinal("name")));
                  _User.DetailRelation = AccessDetailsRelation.MemberOf;
                  _User.UserType = UserType.SqlUser;
                  if (_Reader.GetInt32(_Reader.GetOrdinal("isntgroup")) == 1)
                  {
                     _User.UserType = UserType.NtGroup;
                  }
                  if (_Reader.GetInt32(_Reader.GetOrdinal("isntuser")) == 1)
                  {
                     _User.UserType = UserType.NtUser;
                  }
                  data.AccessList.Add(_User);
               }
            }
         }
      }

      private static void FillServerObjectPermission(AccessData data, string sql)
      {
         foreach (AccessPermissions _Permission in data.Parent.AccessList)
         {
            data.AccessList.Add(_Permission.Copy());
         }

         using (SqlConnection _Connection = Connection.OpenConnection(data.ServerInfo.Name, data.ServerInfo.SqlCredentials))
         using (SqlCommand _Command = new SqlCommand())
         {
            _Command.Connection = _Connection;
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            foreach (AccessPermissions _PermissionItem in data.AccessList)
            {
               _PermissionItem.DetailRelation = AccessDetailsRelation.AccessTo;
               string _UserName = string.IsNullOrEmpty(_PermissionItem.LoginName) ? _PermissionItem.UserName : _PermissionItem.LoginName;
               _Command.CommandText = string.Format(sql, data.ObjectName, _UserName);
               using (SqlDataReader _Reader = _Command.ExecuteReader())
               {
                  while (_Reader.Read())
                  {
                     ObjectAccessDetails _AccessDetails = new ObjectAccessDetails();
                     _AccessDetails.Owner = string.Empty;
                     _AccessDetails.Name = data.ObjectName;
                     _AccessDetails.Type = TranslatePermissionState(_Reader.GetString(_Reader.GetOrdinal("state")));
                     _AccessDetails.Action = TranslatePermissionAction(_Reader.GetString(_Reader.GetOrdinal("type")));
                     _AccessDetails.Column = string.Empty;
                     _PermissionItem.Permissions.Add(_AccessDetails);
                  }
               }
            }
         }
      }

      /// <summary>
      /// Retrieves list of access restrictions on objects not available through sp_helprotect
      /// </summary>
      private static void FillAdvancedDatabaseObjectPermissions(AccessData data)
      {
         string _SystemTable = string.Empty;
         string _IdColumn = string.Empty;
         int _ObjectClassId = int.MinValue;
         switch (data.Type)
         {
            case ObjectType.Assembly:
               _SystemTable = "sys.assemblies";
               _ObjectClassId = 5;
               _IdColumn = "assembly_id";
               break;
            case ObjectType.XmlSchemaCollection:
               _SystemTable = "sys.xml_schema_collections";
               _IdColumn = "xml_collection_id";
               _ObjectClassId = 10;
               break;
            case ObjectType.FullTextCatalog:
               _SystemTable = "sys.fulltext_catalogs";
               _IdColumn = "fulltext_catalog_id";
               _ObjectClassId = 23;
               break;
            case ObjectType.DatabaseUser:
            case ObjectType.DatabaseRole:
               _SystemTable = "sys.database_principals";
               _IdColumn = "principal_id";
               _ObjectClassId = 4;
               break;
            case ObjectType.Schema:
               _SystemTable = "sys.schemas";
               _IdColumn = "schema_id";
               _ObjectClassId = 3;
               break;
            case ObjectType.AsymmetricKey:
               _SystemTable = "sys.asymmetric_keys";
               _IdColumn = "asymmetric_key_id";
               _ObjectClassId = 26;
               break;
            case ObjectType.SymmetricKey:
               _SystemTable = "sys.symmetric_keys";
               _IdColumn = "symmetric_key_id";
               _ObjectClassId = 24;
               break;
            case ObjectType.Certificates:
               _SystemTable = "sys.certificates";
               _IdColumn = "certificate_id";
               _ObjectClassId = 25;
               break;
            default:
               throw new Exception("Object permissions not implemented for this type");
         }

         foreach (AccessPermissions _Permission in data.Parent.AccessList)
         {
            data.AccessList.Add(_Permission.Copy());
         }

         using (SqlConnection _Connection = Connection.OpenConnection(data.ServerInfo.Name, data.Parent.ObjectName, data.ServerInfo.SqlCredentials))
         {
            RetrieveAdvancedDatabaseAccessRestrictions(_Connection, data.ObjectName, _SystemTable, _ObjectClassId, _IdColumn, data.AccessList, AccessDetailsRelation.AccessTo);
         }

      }

      private static void RetrieveAdvancedDatabaseAccessRestrictions(SqlConnection connection, string objectName, 
                                                                     string systemTable, int objectClassId, string idColumn,
                                                                     List<AccessPermissions> accessList, AccessDetailsRelation dataRelation)
      {
         string _Sql = "SELECT prmssn.state, prmssn.type " +
                       "FROM {0} AS systable " +
                       "INNER JOIN sys.database_permissions AS prmssn ON prmssn.major_id=systable.{1} AND prmssn.minor_id=0 AND prmssn.class={2} " +
                       "INNER JOIN sys.database_principals AS grantee_principal ON grantee_principal.principal_id = prmssn.grantee_principal_id " +
                       "WHERE grantee_principal.name=N'{3}' " +
                       "AND systable.name=N'{4}'";
         using(SqlCommand _Command = new SqlCommand())
         {
            _Command.Connection = connection;
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            foreach (AccessPermissions permissionItem in accessList)
            {
               permissionItem.DetailRelation = dataRelation;
               try
               {
                  _Command.CommandText = string.Format(_Sql, systemTable, idColumn, objectClassId, permissionItem.UserName, objectName);

                  using (SqlDataReader _Reader = _Command.ExecuteReader())
                  {
                     while (_Reader.Read())
                     {
                        ObjectAccessDetails _AccessDetails = new ObjectAccessDetails();
                        _AccessDetails.Owner = string.Empty;
                        _AccessDetails.Name = objectName;
                        _AccessDetails.Type = TranslatePermissionState(_Reader.GetString(_Reader.GetOrdinal("state")));
                        _AccessDetails.Action = TranslatePermissionAction(_Reader.GetString(_Reader.GetOrdinal("type")));
                        _AccessDetails.Column = string.Empty;
                        if (!(_AccessDetails.Name == "." &&
                           _AccessDetails.Action.ToUpperInvariant() == "CONNECT" &&
                           _AccessDetails.Type.ToUpperInvariant() == "GRANT" &&
                           _AccessDetails.Column == "."))
                        {
                           permissionItem.Permissions.Add(_AccessDetails);
                        }
                     }
                  }
               }
               catch (SqlException exc)
               {
                  if (exc.Number != 15330)
                  {
                     throw;
                  }
               }
               if (permissionItem.IsGroup)
               {
                  RetrieveAdvancedDatabaseAccessRestrictions(connection, objectName, systemTable, objectClassId, idColumn,
                                                               permissionItem.GroupMembers, permissionItem.DetailRelation);
               }
            }
         }
      }

      /// <summary>
      /// Retrieves the list of access restrictions on an object.
      /// </summary>
      private static void RetrieveAccessRestrictions(SqlConnection connection, string objectName, List<AccessPermissions> accessList, AccessDetailsRelation dataRelation)
      {
         string _Sql = "sp_helprotect {0}, '{1}'";
         using (SqlCommand _Command = new SqlCommand())
         {
            _Command.Connection = connection;
            _Command.CommandTimeout = ToolsetOptions.commandTimeout;
            foreach (AccessPermissions permissionItem in accessList)
            {
               permissionItem.DetailRelation = dataRelation;
               try
               {
                  string _AccountName = permissionItem.UserName;
                  if (string.IsNullOrEmpty(_AccountName))
                  {
                     _AccountName = permissionItem.LoginName;
                  }

                  _Command.CommandText = string.Format(_Sql, string.IsNullOrEmpty(objectName) ? "null" : SQLHelpers.CreateSafeString(objectName), _AccountName);
                  using (SqlDataReader _Reader = _Command.ExecuteReader())
                  {
                     while (_Reader.Read())
                     {
                        ObjectAccessDetails _AccessDetails = new ObjectAccessDetails();
                        _AccessDetails.Owner = _Reader.GetString(_Reader.GetOrdinal("Owner")).Trim();
                        _AccessDetails.Name = _Reader.GetString(_Reader.GetOrdinal("Object")).Trim();
                        _AccessDetails.Type = _Reader.GetString(_Reader.GetOrdinal("ProtectType")).Trim();
                        _AccessDetails.Action = _Reader.GetString(_Reader.GetOrdinal("Action")).Trim();
                        _AccessDetails.Column = _Reader.GetString(_Reader.GetOrdinal("Column")).Trim();
                        if (!(_AccessDetails.Name == "." &&
                           _AccessDetails.Action.ToUpperInvariant() == "CONNECT" &&
                           _AccessDetails.Type.ToUpperInvariant() == "GRANT" &&
                           _AccessDetails.Column == "."))
                        {
                           permissionItem.Permissions.Add(_AccessDetails);
                        }

                        if (_AccessDetails.Type.ToUpperInvariant() == "GRANT_WGO")
                        {
                           _AccessDetails.Type = "Grant with Grant Option";
                        }
                     }
                  }
               }
               catch (SqlException exc)
               {
                  if (exc.Number != 15330)
                  {
                     throw;
                  }
               }
               if (permissionItem.IsGroup)
               {
                  RetrieveAccessRestrictions(connection, objectName, permissionItem.GroupMembers, permissionItem.DetailRelation);
               }
            }
         }
      }


      private static string TranslatePermissionState(string state)
      {
         switch(state.Trim())
         {
            case "D":
               return "Deny";
            case "R":
               return "Revoke";
            case "G":
               return "Grant";
            case "W":
               return "Grant with Grant Option";
            default:
               return state;
         }
      }

      private static string TranslatePermissionAction(string actionType)
      {
         switch (actionType.Trim())
         {
            case "AL":
               return "ALTER";
            case "ALAK":
               return "ALTER ANY ASYMMETRIC KEY";
            case "ALAR":
               return "ALTER ANY APPLICATION ROLE";
            case "ALAS":
               return "ALTER ANY ASSEMBLY";
            case "ALCF":
               return "ALTER ANY CERTIFICATE";
            case "ALDS":
               return "ALTER ANY DATASPACE";
            case "ALED":
               return "ALTER ANY DATABASE EVENT NOTIFICATION";
            case "ALFT":
               return "ALTER ANY FULLTEXT CATALOG";
            case "ALMT":
               return "ALTER ANY MESSAGE TYPE";
            case "ALRL":
               return "ALTER ANY ROLE";
            case "ALRT":
               return "ALTER ANY ROUTE";
            case "ALSB":
               return "ALTER ANY REMOTE SERVICE BINDING";
            case "ALSC":
               return "ALTER ANY CONTRACT";
            case "ALSK":
               return "ALTER ANY SYMMETRIC KEY";
            case "ALSM":
               return "ALTER ANY SCHEMA";
            case "ALSV":
               return "ALTER ANY SERVICE";
            case "ALTG":
               return "ALTER ANY DATABASE DDL TRIGGER";
            case "ALUS":
               return "ALTER ANY USER";
            case "AUTH":
               return "AUTHENTICATE";
            case "BADB":
               return "BACKUP DATABASE";
            case "BALO":
               return "BACKUP LOG";
            case "CL":
               return "CONTROL";
            case "CO":
               return "CONNECT";
            case "CORP":
               return "CONNECT REPLICATION";
            case "CP":
               return "CHECKPOINT";
            case "CRAG":
               return "CREATE AGGREGATE";
            case "CRAK":
               return "CREATE ASYMMETRIC KEY";
            case "CRAS":
               return "CREATE ASSEMBLY";
            case "CRCF":
               return "CREATE CERTIFICATE";
            case "CRDB":
               return "CREATE DATABASE";
            case "CRDF":
               return "CREATE DEFAULT";
            case "CRED":
               return "CREATE DATABASE DDL EVENT NOTIFICATION";
            case "CRFN":
               return "CREATE FUNCTION";
            case "CRFT":
               return "CREATE FULLTEXT CATALOG";
            case "CRMT":
               return "CREATE MESSAGE TYPE";
            case "CRPR":
               return "CREATE PROCEDURE";
            case "CRQU":
               return "CREATE QUEUE";
            case "CRRL":
               return "CREATE ROLE";
            case "CRRT":
               return "CREATE ROUTE";
            case "CRRU":
               return "CREATE RULE";
            case "CRSB":
               return "CREATE REMOTE SERVICE BINDING";
            case "CRSC":
               return "CREATE CONTRACT";
            case "CRSK":
               return "CREATE SYMMETRIC KEY";
            case "CRSM":
               return "CREATE SCHEMA";
            case "CRSN":
               return "CREATE SYNONYM";
            case "CRSV":
               return "CREATE SERVICE";
            case "CRTB":
               return "CREATE TABLE";
            case "CRTY":
               return "CREATE TYPE";
            case "CRVW":
               return "CREATE VIEW";
            case "CRXS":
               return "CREATE XML SCHEMA COLLECTION";
            case "DL":
               return "DELETE";
            case "EX":
               return "EXECUTE";
            case "IM":
               return "IMPERSONATE";
            case "IN":
               return "INSERT";
            case "RC":
               return "RECEIVE";
            case "RF":
               return "REFERENCES";
            case "SL":
               return "SELECT";
            case "SN":
               return "SEND";
            case "SPLN":
               return "SHOWPLAN";
            case "SUQN":
               return "SUBSCRIBE QUERY NOTIFICATIONS";
            case "TO":
               return "TAKE OWNERSHIP";
            case "UP":
               return "UPDATE";
            case "VW":
               return "VIEW DEFINITION";
            case "VWCT":
               return "VIEW CHANGE TRACKING";
            case "VWDS":
               return "VIEW DATABASE STATE";
            case "ADBO":
               return "ADMINISTER BULK OPERATIONS";
            case "ALCD":
               return "ALTER ANY CREDENTIAL";
            case "ALCO":
               return "ALTER ANY CONNECTION";
            case "ALDB":
               return "ALTER ANY DATABASE";
            case "ALES":
               return "ALTER ANY EVENT NOTIFICATION";
            case "ALHE":
               return "ALTER ANY ENDPOINT";
            case "ALLG":
               return "ALTER ANY LOGIN";
            case "ALLS":
               return "ALTER ANY LINKED SERVER";
            case "ALRS":
               return "ALTER RESOURCES";
            case "ALSS":
               return "ALTER SERVER STATE";
            case "ALST":
               return "ALTER SETTINGS";
            case "ALTR":
               return "ALTER TRACE";
            case "COSQ":
               return "CONNECT SQL";
            case "CRDE":
               return "CREATE DDL EVENT NOTIFICATION";
            case "CRHE":
               return "CREATE ENDPOINT";
            case "CRTE":
               return "CREATE TRACE EVENT NOTIFICATION";
            case "SHDN":
               return "SHUTDOWN";
            case "VWAD":
               return "VIEW ANY DEFINITION";
            case "VWDB":
               return "VIEW ANY DATABASE";
            case "VWSS":
               return "VIEW SERVER STATE";
            case "XA":
               return "EXTERNAL ACCESS ASSEMBLY";
            case "XU":
               return "UNSAFE ASSEMBLY";
            default:
               return actionType;
         }
      }


      #region Native code - get group membership
      /// <summary>
      /// The NetLocalGroupGetMembers function retrieves a list of the members of a particular local group in
      /// the security database, which is the security accounts manager (SAM) database or, in the case
      /// of domain controllers, the Active Directory. Local group members can be users or global groups.
      /// </summary>
      [DllImport("NetAPI32.dll", CharSet = CharSet.Unicode)]
      public extern static int NetLocalGroupGetMembers(
          [MarshalAs(UnmanagedType.LPWStr)] string servername,
          [MarshalAs(UnmanagedType.LPWStr)] string localgroupname,
          int level,
          out IntPtr bufptr,
          int prefmaxlen,
          out int entriesread,
          out int totalentries,
          ref int resume_handle);

      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
      public struct LOCALGROUP_MEMBERS_INFO_2
      {
         public int lgrmi2_sid;
         public int lgrmi2_sidusage;
         public string lgrmi2_domainandname;
      } 

      private static List<AccessPermissions> GetNtGroupMembers(string group)
      {
         List<AccessPermissions> _UserList = new List<AccessPermissions>();
         try
         {
            int _GroupSeparatorIndex = group.IndexOf('\\');
            string ServerName = group.Substring(0, _GroupSeparatorIndex);
            string GroupName = group.Substring(_GroupSeparatorIndex + 1);

            int EntriesRead;
            int TotalEntries;
            int Resume = 0;
            IntPtr bufPtr;
            NetLocalGroupGetMembers(ServerName, GroupName, 2, out bufPtr, -1, out EntriesRead, out TotalEntries, ref Resume);
            if (EntriesRead > 0)
            {
               LOCALGROUP_MEMBERS_INFO_2[] Members = new LOCALGROUP_MEMBERS_INFO_2[EntriesRead];
               IntPtr iter = bufPtr;
               for (int i = 0; i < EntriesRead; i++)
               {
                  Members[i] = (LOCALGROUP_MEMBERS_INFO_2)Marshal.PtrToStructure(iter, typeof(LOCALGROUP_MEMBERS_INFO_2));
                  iter = (IntPtr)((int)iter + Marshal.SizeOf(typeof(LOCALGROUP_MEMBERS_INFO_2)));
                  _UserList.Add(new AccessPermissions(Members[i].lgrmi2_domainandname, UserType.NtUser));
               }
            }
         }
         catch { }
         return _UserList;
      }
      #endregion
   }
}
