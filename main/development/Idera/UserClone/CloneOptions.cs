using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.Management.Smo;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.UserClone
{
    internal class CloneOptions
    {
        private string _UserName;
        private string _Password;
        private bool _EnableLogin;
        private string _DefaultDatabase;
        private CloneType _Type;
        private ScriptVersion _Version;
        private bool _ApplyDatabasePermissions = true;
        private bool _ApplyObjectLevelPermissions = false;
        private ServerInformation _SourceServer = null;
        private ServerInformation _DestinationServer = null;
        private string _SourceUser = string.Empty;
        private List<string> _Databases = new List<string>();
        private bool _IncludeSchemaOwnership;

        /// <summary>
        /// User Name.
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        /// <summary>
        /// Password.  If null, then use the same as source.
        /// </summary>
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// Disable Login.
        /// </summary>
        public bool EnableLogin
        {
            get { return _EnableLogin; }
            set { _EnableLogin = value; }
        }

        /// <summary>
        /// Default database.
        /// </summary>
        public string DefaultDatabase
        {
            get { return _DefaultDatabase; }
            set { _DefaultDatabase = value.Trim(); }
        }

        /// <summary>
        /// True if database permissions should be applied, otherwise false.  Defaults to True.
        /// </summary>
        public bool ApplyDatabasePermissions
        {
            get { return _ApplyDatabasePermissions; }
            set { _ApplyDatabasePermissions = value; }
        }

        /// <summary>
        /// List of database permissions that should be included in clone operation.
        /// </summary>
        public List<string> Databases
        {
            get { return _Databases; }
        }

        /// <summary>
        /// True if object-level permissions granted to the source user should be applied, otherwise false.  Defautlts to True.
        /// </summary>
        public bool ApplyObjectLevelPermissions
        {
            get { return _ApplyObjectLevelPermissions; }
            set { _ApplyObjectLevelPermissions = value; }
        }

        /// <summary>
        /// Clone type.
        /// </summary>
        internal CloneType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// Script version.
        /// </summary>
        internal ScriptVersion Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        /// <summary>
        /// Source server.
        /// </summary>
        public ServerInformation SourceServer
        {
            get { return _SourceServer; }
            set { _SourceServer = value; }
        }

        /// <summary>
        /// Destination server.
        /// </summary>
        public ServerInformation DestinationServer
        {
            get { return _DestinationServer; }
            set { _DestinationServer = value; }
        }

        /// <summary>
        /// Source user.
        /// </summary>
        public string SourceUser
        {
            get { return _SourceUser; }
            set { _SourceUser = value; }
        }

        /// <summary>
        /// Include schema ownership for SQL 2005 and above.
        /// </summary>
        public bool IncludeSchemaOwnership
        {
            get { return _IncludeSchemaOwnership; }
            set { _IncludeSchemaOwnership = value; }
        }
    }

    /// <summary>
    /// The type of cloning that should be performed.
    /// </summary>
    internal enum CloneType
    {
        /// <summary>
        /// All of the user's options are copied, including server role membership, database role membership, default database, and all its database permissions.
        /// </summary>
        Full,
        /// <summary>
        /// User can select options to exclude or change certain items from the clone before it gets generated
        /// </summary>
        Partial
    }

    /// <summary>
    /// SQL Server version targetted by script.
    /// </summary>
    internal enum ScriptVersion
    {
        /// <summary>
        /// Not Supported
        /// </summary>
        NotSupported,
        /// <summary>
        /// SQL 2000
        /// </summary>
        Sql2000,
        /// <summary>
        /// SQL 2005
        /// </summary>
        Sql2005,
        /// <summary>
        /// SQL 2008
        /// </summary>
        Sql2008,
        /// <summary>
        /// SQL 2012
        /// </summary>
        Sql2012,
        /// <summary>
        /// SQL 2014
        /// </summary>
        Sql2014,
        /// <summary>
        /// SQL 2016
        /// </summary>
        Sql2016,
        /// <summary>
       /// SQL 2017
       /// </summary>
        Sql2017,
        /// <summary>
        /// SQL 2019
        /// </summary>
        Sql2019
    }

    /// <summary>
    /// Cloning progress.
    /// </summary>
    internal enum CloneProgress
    {
        Initialize = 0,
        GenerateScript = 1,
        VerifyVersionInformation = 2,
        LoginScript = 3,
        DefaultDatabase = 4,
        DatabasePermissions = 5,
        EnableLogin = 6,
        ExecutingScript = 7
    }
}
