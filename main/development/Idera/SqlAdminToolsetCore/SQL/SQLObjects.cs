using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Diagnostics;

namespace Idera.SqlAdminToolset.Core
{
    public class DatabaseObject
    {
        public DatabaseObject() { }
        public string name;
        public int    dbid;
        public int    status;
        public byte[] sid;
        public byte   compatabilityLevel = 0;

        public string DisplayMember { get { return name; } }
        override public string ToString() { return name; }
        
        public bool isOffline
        {
           get
           {
              bool offline = (status & 512) == 1;
              return offline;
           }
        }

        public bool isSystem
        {
           get { return SQLHelpers.IsSystemDatabase(name); } //BySid(sid); }
        }
    }

    public class RoleObject
    {
        public RoleObject() { }
        public string name;
        public int roleid;
        public string fullName;

        public string DisplayMember { get { return String.Format("{0} ({1})", fullName, name); } }
        override public string ToString() { return String.Format("{0} ({1})", fullName, name); }

    }

    public class LoginObject
    {
        public LoginObject() { }
        public string name;
        public byte[] sid;

        public int denylogin;
        public int isntname;
        public int isntuser;
        public int isntgroup;
        public int hasaccess;

        public int sysadmin;
        public int securityadmin;
        public int serveradmin;
        public int setupadmin;
        public int processadmin;
        public int diskadmin;
        public int dbcreator;

        public int bulkadmin;

        public string DisplayMember { get { return name; } }
        override public string ToString() { return name; }

    }

    public class TableObject
    {
        public TableObject() { }
        public string name;
        public int id;
        public string xtype;

        public string DisplayMember { get { return name; } }
        override public string ToString() { return name; }

    }

    public class ColumnObject
    {
       public ColumnObject() { }
       public string name;
       public string dataType;
       public short length;

       public string DisplayMember { get { return name; } }
       override public string ToString() { return name; }

    }

   public class ViewObject
   {
      public ViewObject() { }
      public string name;
      public int id;

      public string DisplayMember { get { return name; } }
      override public string ToString() { return name; }

   }

    public class StoredProcObject
    {
        public StoredProcObject() { }
        public string name;
        public int id;
        public int uid;

        public string DisplayMember { get { return name; } }
        override public string ToString() { return name; }
    }

    public class SchemaObject
    {
        public SchemaObject() { }
        public string name;
        public int id;

        public string DisplayMember { get { return name; } }
        override public string ToString() { return name; }
    }

    public class FunctionObject
    {
       public FunctionObject() { }
       public string name;
       public int id;
       public string xtype;

       public string DisplayMember { get { return name; } }
       override public string ToString() { return name; }

    }


    /// <summary>
    /// Summary description for SQLObjects
    /// </summary>
    public class SQLObjects
    {
        public SQLObjects()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Database Logic
        //-----------------------------------------------------------------------------
        // GetUserDatabases - Gets list of databases from SQL Server instance
        //-----------------------------------------------------------------------------
        static public IList
           GetUserDatabases(
              SqlConnection conn
           )
        {
           return GetDatabases( conn, true );
        }
        
        //-----------------------------------------------------------------------------
        // GetDatabases - Gets list of user and system databases from SQL Server instance
        //-----------------------------------------------------------------------------
        static public IList
           GetDatabases(
              SqlConnection conn,
              bool          excludeSytemDatabases
           )
        {
            IList dbList = null;

            try
            {
                // Load Databases			   
                string cmdstr = "SELECT name, dbid, cmptlevel, status, sid" +
                                  " FROM master..sysdatabases " +
                                " WHERE has_dbaccess(name) = 1 " +
                                  " ORDER by name ASC";

                using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        dbList = new ArrayList();

                        while (reader.Read())
                        {
                            DatabaseObject db =  new DatabaseObject();
                            db.name = reader.GetString(0);
                            db.dbid = reader.GetInt16(1);
                            db.compatabilityLevel = reader.GetByte(2);
                            db.status = reader.GetInt32(3);
                            
                            // get database sid - if == 0x1 its a system database
                             int len = (int)reader.GetBytes(4, 0, null, 0, 0);
                             if (len > 0)
                             {
                                 db.sid = new byte[len];
                                 reader.GetBytes(4, 0, db.sid, 0, len);
                             }
                             
                            // exclude system databases
                            if ( ! excludeSytemDatabases || 
                                 ! SQLHelpers.IsSystemDatabase(db.name) ) //BySid(db.sid) )
                            {
                                dbList.Add(db);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dbList;
        }

        //-----------------------------------------------------------------------------
        // GetSystemDatabases - Gets list of databases from SQLServer instance
        //-----------------------------------------------------------------------------
        static public IList
           GetSystemDatabases(
              SqlConnection conn
           )
        {
            IList dbList = null;

            dbList = new ArrayList();

            DatabaseObject db = new DatabaseObject();
            db.name = "master";
            db.dbid = 1;
            dbList.Add(db);

            db = new DatabaseObject();
            db.name = "tempdb";
            db.dbid = 2;
            dbList.Add(db);

            db = new DatabaseObject();
            db.name = "model";
            db.dbid = 3;
            dbList.Add(db);

            db = new DatabaseObject();
            db.name = "msdb";
            db.dbid = 4;
            dbList.Add(db);

            if (SQLHelpers.GetSqlVersion(conn) >= 9)
            {
                db = new DatabaseObject();
                db.name = "mssqlsystemresource";
                db.dbid = 32767;
                dbList.Add(db);
            }

            return dbList;
        }

        //-----------------------------------------------------------------------------
        // GetSchemas
        //-----------------------------------------------------------------------------
        static public IList
           GetSchemas(
              SqlConnection conn,
              string dbName
           )
        {
            IList schemaList = null;

            try
            {
                // Load Tables			   
                string cmdfmt = "SELECT name,schema_id " +
                                "FROM {0}.sys.schemas " +
                                "WHERE principal_id=1 " +
                                "ORDER by name ASC";
                string cmdstr = String.Format(cmdfmt,
                                              SQLHelpers.CreateSafeDatabaseName(dbName));

                using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        schemaList = new ArrayList();

                        while (reader.Read())
                        {
                            SchemaObject raw = new SchemaObject();
                            raw.name = reader.GetString(0);
                            raw.id   = reader.GetInt32(1);
                            schemaList.Add(raw);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                schemaList = new ArrayList();  // return an empty array
                throw ex;
            }

            return schemaList;
        }

        //-----------------------------------------------------------------------------
        // GetTables
        //-----------------------------------------------------------------------------
        static public IList
           GetTables(
              SqlConnection conn,
              string dbName
           )
        {
            IList tableList = null;

            try
            {
                // Load Tables			   
                string cmdfmt = "SELECT name,id,xtype" +
                              " FROM {0}..sysobjects " +
                                  " WHERE xtype='U'" +
                                  " ORDER by name ASC";
                string cmdstr = String.Format(cmdfmt,
                                               SQLHelpers.CreateSafeDatabaseName(dbName));

                using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        tableList = new ArrayList();

                        while (reader.Read())
                        {
                            TableObject raw = new TableObject();
                            raw.name = reader.GetString(0);
                            raw.id = reader.GetInt32(1);
                            tableList.Add(raw);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                tableList = new ArrayList();  // return an empty array
                throw ex;
            }

            return tableList;
        }

        //-----------------------------------------------------------------------------
        // GetTables
        //-----------------------------------------------------------------------------
        static public IList
           GetTables(
              SqlConnection conn,
              string        dbName,
              string        schemaName
           )
        {
            IList tableList = null;

            try
            {
                // Load Databases			   
                string cmdfmt = "SELECT o.name,o.object_id " +
                                "FROM {0}.sys.objects o,{0}.sys.schemas s " +
                                "WHERE type='U' AND s.schema_id=o.schema_id AND s.name={1} " +
                                "ORDER by o.name ASC";
                string cmdstr = String.Format(cmdfmt,
                                              SQLHelpers.CreateSafeDatabaseName(dbName),
                                              SQLHelpers.CreateSafeString(schemaName));

                using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        tableList = new ArrayList();

                        while (reader.Read())
                        {
                            TableObject raw = new TableObject();
                            raw.name = reader.GetString(0);
                            raw.id = reader.GetInt32(1);
                            tableList.Add(raw);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                tableList = new ArrayList();  // return an empty array
                throw ex;
            }

            return tableList;
        }

        //-----------------------------------------------------------------------------
        // Get Columns
        //-----------------------------------------------------------------------------
       static public IList
          GetTableColumns(
             SqlConnection conn,
             string dbName,
             string tableName
          )
       {
          return GetColumns(conn, dbName, tableName, "U");
       }

        //-----------------------------------------------------------------------------
        // Get Columns
        //-----------------------------------------------------------------------------
        static private IList
           GetColumns(
              SqlConnection conn,
              string dbName,
              string tableName,
              string xtype
           )
        {
           IList columnList = null;

           try
           {
              // Load Columns			   
              string cmdfmt = "SELECT sc.name, st.name as DataType, sc.length " +
                              "FROM {0}..sysobjects so " +
                              "INNER JOIN {0}..syscolumns sc ON so.id = sc.id " +
                              "INNER JOIN {0}..systypes st ON sc.xtype=st.xtype " +
                              "WHERE so.xtype='{2}' " +
                              "AND   so.name = {1} " +
                              "AND   SUBSTRING(sc.name, 1, 1) <> '@' " +
                              "AND   st.xusertype <> 256 " +
                              "ORDER BY sc.colid";
              string cmdstr = String.Format(cmdfmt,
                                            SQLHelpers.CreateSafeDatabaseName(dbName),
                                            SQLHelpers.CreateSafeString(tableName),
                                            xtype);

              using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
              {
                 cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                 using (SqlDataReader reader = cmd.ExecuteReader())
                 {
                    columnList = new ArrayList();

                    while (reader.Read())
                    {
                       ColumnObject raw = new ColumnObject();
                       raw.name = reader.GetString(0);
                       raw.dataType = reader.GetString(1);
                       raw.length = reader.GetInt16(2);
                       columnList.Add(raw);
                    }
                 }
              }
           }
           catch (Exception ex)
           {
              columnList = new ArrayList();  // return an empty array
              throw ex;
           }

           return columnList;
        }

        #endregion
        
        #region Stored Procedures

        //-----------------------------------------------------------------------------
        // GetStoredProcs
        //-----------------------------------------------------------------------------
        static public IList
           GetStoredProcs(
              SqlConnection conn,
              string dbName
           )
        {
            IList spList = null;

            try
            {
                string cmdfmt = "SELECT name,id,uid" +
                              " FROM {0}..sysobjects " +
                                  " WHERE xtype='P'" +
                                  " ORDER by name ASC";
                string cmdstr = String.Format(cmdfmt,
                                               SQLHelpers.CreateSafeDatabaseName(dbName));

                using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        spList = new ArrayList();

                        while (reader.Read())
                        {
                            StoredProcObject raw = new StoredProcObject();
                            raw.name = reader.GetString(0);
                            raw.id = reader.GetInt32(1);
                            raw.uid = reader.GetInt16(2);
                            spList.Add(raw);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                spList = new ArrayList();  // return an empty array
                throw ex;
            }

            return spList;
        }
        
        #endregion

        #region Views
        //-----------------------------------------------------------------------------
        // GetViews
        //-----------------------------------------------------------------------------
        static public IList
           GetViews(
              SqlConnection conn,
              string dbName
           )
        {
           IList viewList = null;

           try
           {
              // Load Tables			   
              string cmdfmt = "SELECT name,id,xtype" +
                            " FROM {0}..sysobjects " +
                                " WHERE xtype='V'" +
                                " ORDER by name ASC";
              string cmdstr = String.Format(cmdfmt,
                                             SQLHelpers.CreateSafeDatabaseName(dbName));

              using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
              {
                 cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                 using (SqlDataReader reader = cmd.ExecuteReader())
                 {
                    viewList = new ArrayList();

                    while (reader.Read())
                    {
                       ViewObject raw = new ViewObject();
                       raw.name = reader.GetString(0);
                       raw.id = reader.GetInt32(1);
                       viewList.Add(raw);
                    }
                 }
              }
           }
           catch (Exception ex)
           {
              viewList = new ArrayList();  // return an empty array
              throw ex;
           }

           return viewList;
        }

        //-----------------------------------------------------------------------------
        // Get View Columns
        //-----------------------------------------------------------------------------
        static public IList
           GetViewColumns(
              SqlConnection conn,
              string dbName,
              string viewName
           )
        {
           return GetColumns(conn, dbName, viewName, "V");
        }
        #endregion

        #region Functions
        //-----------------------------------------------------------------------------
        // GetFunctions
        //-----------------------------------------------------------------------------
        static public IList
           GetFunctions(
              SqlConnection conn,
              string dbName
           )
        {
           IList functionList = null;

           try
           {
              // Load Tables			   
              string cmdfmt = "SELECT name,id,xtype " +
                              "FROM {0}..sysobjects " +
                              "WHERE xtype IN ('FN', " + // Function 
                                              "'IF', " + //Inline Function
                                              "'AF', " + //Aggregate Function
                                              "'TF') " + //Table-valued function
                              "ORDER by name ASC";
              
              string cmdstr = String.Format(cmdfmt,
                                             SQLHelpers.CreateSafeDatabaseName(dbName));

              using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
              {
                 cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                 using (SqlDataReader reader = cmd.ExecuteReader())
                 {
                    functionList = new ArrayList();

                    while (reader.Read())
                    {
                       FunctionObject raw = new FunctionObject();
                       raw.name = reader.GetString(0);
                       raw.id = reader.GetInt32(1);
                       raw.xtype = reader.GetString(2);
                       functionList.Add(raw);
                    }
                 }
              }
           }
           catch (Exception ex)
           {
              functionList = new ArrayList();  // return an empty array
              throw ex;
           }

           return functionList;
        }
        #endregion

        #region Privileged User Lists

        //-----------------------------------------------------------------------------
        // GetServerRoles - Gets list of server roles from SQLServer instance
        //-----------------------------------------------------------------------------
        static public IList
           GetServerRoles(
              SqlConnection conn
           )
        {
            IList roleList = null;

            try
            {
                // Load Server Roles			   
                string cmdstr = "select v1.name, v1.number, v2.name " +
                                "  from master..spt_values v1, master..spt_values v2 " +
                                "  where v1.low = 0 and " +
                                 "     v1.type = 'SRV' and " +
                                 "     v2.low = -1 and " +
                                 "     v2.type = 'SRV' and " +
                                 "     v1.number = v2.number ";

                using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        roleList = new ArrayList();

                        while (reader.Read())
                        {
                            RoleObject raw = new RoleObject();
                            raw.name = SQLHelpers.GetString(reader, 0);
                            raw.roleid = SQLHelpers.GetInt32(reader, 1);
                            raw.fullName = SQLHelpers.GetString(reader, 2);
                            roleList.Add(raw);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                roleList = new ArrayList();  // return an empty array
                throw ex;
            }

            return roleList;
        }

        //-----------------------------------------------------------------------------
        // GetServerLogins
        //-----------------------------------------------------------------------------
        static public IList
           GetServerLogins(
              SqlConnection conn
           )
        {
            IList loginList = null;
            string cmdstr;
            int sqlVersion;

            try
            {
                sqlVersion = SQLHelpers.GetSqlVersion(conn);
                // server logins

                if (sqlVersion < 9)
                {
                    cmdstr = "SELECT name, sid, " +
                                " isntname, isntuser, isntgroup, " +
                                " denylogin,hasaccess, " +
                                " sysadmin, securityadmin, serveradmin, setupadmin, processadmin, diskadmin, dbcreator " +
                             "FROM master..syslogins " +
                             "WHERE sid <> 0";
                }
                else
                {
                    // SQL 2005 has new server role: bulkadmin
                    cmdstr = "SELECT name, sid, " +
                                " isntname, isntuser, isntgroup, " +
                                " denylogin,hasaccess, " +
                                " sysadmin, securityadmin, serveradmin, setupadmin, processadmin, diskadmin, dbcreator, bulkadmin " +
                             "FROM master..syslogins " +
                             "WHERE sid <> 0";
                }
                using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        loginList = new ArrayList();

                        while (reader.Read())
                        {
                            LoginObject raw = new LoginObject();
                            raw.name = SQLHelpers.GetString(reader, 0);

                            if (!reader.IsDBNull(1))
                            {
                                int len = (int)reader.GetBytes(1, 0, null, 0, 0);
                                if (len > 0)
                                {
                                    raw.sid = new byte[len];
                                    reader.GetBytes(1, 0, raw.sid, 0, len);
                                }

                                int col = 2;

                                raw.isntname = SQLHelpers.GetInt32(reader, col++);
                                raw.isntuser = SQLHelpers.GetInt32(reader, col++);
                                raw.isntgroup = SQLHelpers.GetInt32(reader, col++);

                                raw.denylogin = SQLHelpers.GetInt32(reader, col++);
                                raw.hasaccess = SQLHelpers.GetInt32(reader, col++);

                                raw.sysadmin = SQLHelpers.GetInt32(reader, col++);
                                raw.securityadmin = SQLHelpers.GetInt32(reader, col++);
                                raw.serveradmin = SQLHelpers.GetInt32(reader, col++);
                                raw.setupadmin = SQLHelpers.GetInt32(reader, col++);
                                raw.processadmin = SQLHelpers.GetInt32(reader, col++);
                                raw.diskadmin = SQLHelpers.GetInt32(reader, col++);
                                raw.dbcreator = SQLHelpers.GetInt32(reader, col++);
                                if (sqlVersion < 9)
                                    raw.bulkadmin = 0;
                                else
                                    raw.bulkadmin = SQLHelpers.GetInt32(reader, col++);
                            }
                            loginList.Add(raw);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                loginList = new ArrayList();  // return an empty array
                throw ex;
            }

            return loginList;
        }

        //-----------------------------------------------------------------------------
        // IsCurrentUserSysadmin
        //-----------------------------------------------------------------------------
        static public bool
           IsCurrentUserSysadmin(
              SqlConnection conn
           )
        {
            bool isSysadmin = false;

            try
            {
                string cmdStr = "SELECT IS_SRVROLEMEMBER ('sysadmin')";
                using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   int sysadmin;
                    object obj = cmd.ExecuteScalar();
                    if (obj is System.DBNull)
                    {
                        sysadmin = 0;
                    }
                    else
                    {
                        sysadmin = (int)obj;
                    }

                    if (sysadmin == 1)
                    {
                        isSysadmin = true;
                    }
                }
            }
            catch
            {
               // you are not a sysadmin if you cant check if you are not
                isSysadmin = false;
            }

            return isSysadmin;
        }



        //-----------------------------------------------------------------------------
        // GetLogins
        //-----------------------------------------------------------------------------
        static public IList
           GetLogins(
              SqlConnection conn,
              string databaseName
           )
        {
            IList loginList = null;
            string cmdstr;

            try
            {
                if (databaseName == "")
                {
                    int sqlVersion = SQLHelpers.GetSqlVersion(conn);

                    if (sqlVersion < 9)
                        // server logins
                        cmdstr = "select name,sid from master..sysxlogins where sid <>0";
                    else
                        cmdstr = "SELECT name, sid from master..syslogins where sid <> 0";
                }
                else
                {
                    // database logins
                    cmdstr = String.Format("select name,sid from {0}..sysusers where sid <> 0",
                                            SQLHelpers.CreateSafeDatabaseName(databaseName));
                }

                using (SqlCommand cmd = new SqlCommand(cmdstr, conn))
                {
                   cmd.CommandTimeout = ToolsetOptions.commandTimeout;

                   using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        loginList = new ArrayList();

                        while (reader.Read())
                        {
                            LoginObject raw = new LoginObject();
                            raw.name = SQLHelpers.GetString(reader, 0);

                            if (!reader.IsDBNull(1))
                            {
                                int len = (int)reader.GetBytes(1, 0, null, 0, 0);
                                if (len > 0)
                                {
                                    raw.sid = new byte[len];
                                    reader.GetBytes(1, 0, raw.sid, 0, len);
                                }
                            }
                            loginList.Add(raw);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                loginList = new ArrayList();  // return an empty array
                throw ex;
            }

            return loginList;
        }

        #endregion
    }
}
