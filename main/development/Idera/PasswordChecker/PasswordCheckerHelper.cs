namespace Idera.SqlAdminToolset.PasswordChecker
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Data.SqlClient;
    using System.Security.Cryptography;
    using System.Text;
    using Core;
    using Microsoft.SqlServer.Management.Common;
    using Microsoft.SqlServer.Management.Smo;
    using System.Threading;
    using System.Security.Principal;
    using System.Security;

    /// <summary>
    /// Password checker helper functions.
    /// </summary>
    internal class PasswordCheckerHelper
    {
        private TestResults _TestResults;
        private JobPoolOptions _JobPoolOptions;
        private static object threadLock = new object();

        public static TestResults ExecutePasswordCheck(ServerInformation server, int commandTimeout, JobPoolOptions options)
        {
            lock (threadLock)
            {
                using (CoreGlobals.traceLog.DebugCall(string.Format("ExecutePasswordCheck - {0}", server.Name)))
                {
                    PasswordCheckerOptions _PasswordCheckerOptions = options as PasswordCheckerOptions;
                    if (_PasswordCheckerOptions == null)
                    {
                        throw new ArgumentException("Options are not valid", "options");
                    }

                    //Do a test connection before starting
                    SqlConnection conn = null;
                    try
                    {
                        if (server.SqlCredentials != null)
                        {
                            conn = Connection.OpenConnection(server.Name, server.SqlCredentials);
                        }
                        else
                        {
                            conn = Connection.OpenConnection(server.Name);
                        }

                        if (!SQLHelpers.Is2000orGreater(conn))
                        {
                            throw new Exception("Cannot check passwords on this server. Password Check requires SQL Server 2000 or newer.");
                        }

                        if (_PasswordCheckerOptions.UserType == UsersToTest.Sa)
                        {
                            _PasswordCheckerOptions.Users = new string[] { SQLHelpers.GetSaLogin(conn) };
                        }

                        switch (_PasswordCheckerOptions.UserType)
                        {
                            case UsersToTest.All:
                                return new PasswordCheckerHelper(options).PasswordTestAllUsers(server, _PasswordCheckerOptions.PasswordList, conn);
                            case UsersToTest.ServerRole:
                                return new PasswordCheckerHelper(options).PasswordTestByServerRole(server, _PasswordCheckerOptions.ServerRoles, _PasswordCheckerOptions.PasswordList, conn);
                            case UsersToTest.DatabaseRole:
                                return new PasswordCheckerHelper(options).PasswordTestByDatabaseRole(server, _PasswordCheckerOptions.DatabaseRoles, _PasswordCheckerOptions.PasswordList, conn);
                            case UsersToTest.SpecifiedUser:
                            case UsersToTest.Sa:
                                return new PasswordCheckerHelper(options).PasswordTestByUsers(server, _PasswordCheckerOptions.Users, _PasswordCheckerOptions.PasswordList, conn);
                            default:
                                throw new NotImplementedException("The requested operation is not yet implemented");
                        }
                    }
                    finally
                    {
                        if (conn != null) conn.Close();
                    }
                }
            }
        }

        public PasswordCheckerHelper(JobPoolOptions options)
        {
            _JobPoolOptions = options;
        }

        #region Public
        /// <summary>
        /// Performs a dictionary attack against a server using the specified dictionary file.
        /// </summary>
        public TestResults PasswordTestByUsers(ServerInformation server, string[] users, List<string> passwordList, SqlConnection conn)
        {
            using (CoreGlobals.traceLog.DebugCall("PasswordTestByUsers"))
            {
                List<string> _TestList = new List<string>();
                _TestList.InsertRange(0, passwordList);

                _TestResults = new TestResults(server.Name);

                // create an SqlLogin object for each user passed in
                Dictionary<string, SqlLogin> logins = new Dictionary<string, SqlLogin>();
                foreach (string user in users)
                {
                    if (!logins.ContainsKey(user.ToUpperInvariant()))
                    {
                        logins.Add(user.ToUpperInvariant(), new SqlLogin(user));
                    }
                }
                if (_JobPoolOptions.CancelRequested)
                {
                    return _TestResults;
                }

                bool _AllPasswordsAreNull = true;  //if all password hashes come back null, the logged on user has no rights

                // retrieve all the sql logins from the server and update the matching SqlLogin object
                using (SqlConnection connection = Connection.OpenConnection(server.Name, "master", server.SqlCredentials))
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = (SQLHelpers.Is2005orGreater(connection))
                                                  ? @"select [name],[is_disabled],[password_hash] from sys.sql_logins"
                                                  : @"select [name],cast(0 as bit),cast([password] as varbinary) from syslogins where hasaccess = 1 and isntname = 0";
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            SqlLogin login;
                            while (dataReader.Read())
                            {
                                string name = dataReader.GetString(0).ToUpperInvariant();
                                CoreGlobals.traceLog.DebugFormat("SqlUser is '{0}'", name);
                                if (logins.TryGetValue(name.ToUpperInvariant(), out login))
                                {
                                    login.name = dataReader.GetString(0); //Reset in case user typed in the name in a different case.
                                    login.isDisabled = SQLHelpers.GetBool(dataReader, 1);
                                    login.SetPasswordHash(SQLHelpers.GetBinary(dataReader, 2));
                                    login.loginExists = true;
                                }
                                if (!dataReader.IsDBNull(2))
                                {
                                    _AllPasswordsAreNull = false;
                                }
                            }
                        }
                    }
                    connection.Close();
                }

                if (_AllPasswordsAreNull)
                {
                    throw new ConnectionFailureException(ProductConstants.ErrorMustBeSysAdmin);
                }

                if (((PasswordCheckerOptions)_JobPoolOptions).TestCommonVariations)
                {
                    string[] _Passwords = _TestList.ToArray();
                    foreach (string _Password in _Passwords)
                    {
                        if (_Passwords.Length > 0)
                        {
                            int _MaxWordPlusNumberRange = ProductConstants.MaximumWordPlusNumberTotal / _Passwords.Length;
                            for (int i = 0; i <= _MaxWordPlusNumberRange; i++)
                            {
                                if (!_TestList.Contains(_Password + i.ToString()))
                                {
                                    _TestList.Add(_Password + i.ToString());
                                }
                            }
                        }

                        char[] _Chars = _Password.ToCharArray();
                        Array.Reverse(_Chars);
                        string _Reverse = new string(_Chars);

                        if (!_TestList.Contains(_Reverse))
                        {
                            _TestList.Add(_Reverse);
                        }
                        if (!_TestList.Contains(_Password + _Password))
                        {
                            _TestList.Add(_Password + _Password);
                        }
                        if (!_TestList.Contains(_Password + _Reverse))
                        {
                            _TestList.Add(_Password + _Reverse);
                        }
                    }
                }


                // Analyze all the SqlLogin objects and create a LoginResults object
                SHA1 hashAlgorithm = SHA1CryptoServiceProvider.Create();
                SHA512 hashAlgorithmSQL2012 = new SHA512Managed();

                foreach (SqlLogin login in logins.Values)
                {
                    LoginResults result = new LoginResults(login.name);
                    if (!login.loginExists)
                    {
                        result.SetSkipped(LoginSkippedType.LoginDoesntExist);
                    }
                    else
                    {
                        if (login.mixedCasePasswordHash.Length == 20)
                            CheckPassword(result, hashAlgorithm, _TestList, login.passwordSalt, login.mixedCasePasswordHash, login.name);
                        else if (login.mixedCasePasswordHash.Length == 64)
                            CheckPassword(result, hashAlgorithmSQL2012, _TestList, login.passwordSalt, login.mixedCasePasswordHash, login.name);
                    }
                    _TestResults.LoginResultsList.Add(result);
                    if (_JobPoolOptions.CancelRequested)
                    {
                        break;
                    }
                }
                hashAlgorithm.Clear();

                return _TestResults;
            }
        }

        private void
           CheckPassword(
              LoginResults testResults,
              HashAlgorithm hashAlgorithm,
              List<string> words,
              byte[] salt,
              byte[] mixedPasswordHash,
              string loginName)
        {
            using (CoreGlobals.traceLog.DebugCall("CheckPassword"))
            {
                if (mixedPasswordHash == null)
                {
                    if (salt == null)
                    {
                        // null password are treated like blank passwords
                        testResults.PasswordAttempts = 1;
                        testResults.SuccessfulPassword = String.Empty;
                        return;
                    }
                    else //6.5 or 7.0 password uses different algorithm
                    {
                        testResults.SetSkipped(LoginSkippedType.NotSupportedEncryption);
                        return;
                    }
                }

                int passwordAttempts = 0;
                for (int i = 0; i < words.Count; i++)
                {
                    string word = words[i];
                    if (word.Contains(ProductConstants.PasswordSameAsLoginName))
                    {
                        word = word.Replace(ProductConstants.PasswordSameAsLoginName, loginName);
                    }
                    if (word.Contains(ProductConstants.PasswordSameAsLoginNameReverse))
                    {
                        char[] _Chars = loginName.ToCharArray();
                        Array.Reverse(_Chars);
                        string _LoginReverse = new string(_Chars);

                        word = word.Replace(ProductConstants.PasswordSameAsLoginNameReverse, _LoginReverse);
                    }

                    byte[] wordBytes = UnicodeEncoding.Unicode.GetBytes(word);
                    byte[] saltedBytes = new byte[wordBytes.Length + salt.Length];
                    wordBytes.CopyTo(saltedBytes, 0);
                    salt.CopyTo(saltedBytes, wordBytes.Length);

                    byte[] wordHash = hashAlgorithm.ComputeHash(saltedBytes);

                    passwordAttempts++;
                    if (Match(wordHash, mixedPasswordHash))
                    {
                        testResults.SuccessfulPassword = word;
                        break;
                    }
                }
                testResults.PasswordAttempts = passwordAttempts;
            }
        }

        private static bool Match(byte[] left, byte[] right)
        {
            if (left != null)
            {
                if (right == null)
                    return false;

                int length = left.Length;
                for (int i = 0; i < length; i++)
                {
                    if (left[i] != right[i])
                        return false;
                }
                return true;
            }

            return right == null;
        }

        /// <summary>
        /// Runs a dictionary attack test for all users in a SQL Server using a specified dictionary file.
        /// </summary>
        public TestResults PasswordTestAllUsers(ServerInformation server, List<string> passwordList, SqlConnection conn)
        {
            using (CoreGlobals.traceLog.DebugCall("PasswordTestAllUsers"))
            {
                StringCollection _Users = new StringCollection();

                string _Sql = "select name from master..syslogins where isntname = 0 and isntgroup = 0 and isntuser = 0";
                if (SQLHelpers.Is2005orGreater(conn))
                {
                    _Sql = "select name from sys.sql_logins";
                }

                using (SqlCommand _Command = new SqlCommand(_Sql, conn))
                using (SqlDataReader _Reader = _Command.ExecuteReader())
                {
                    while (_Reader.Read())
                    {
                        if (!_Users.Contains(_Reader.GetString(0)))
                            _Users.Add(_Reader.GetString(0));
                    }
                }

                string[] _UserArray = new string[_Users.Count];
                _Users.CopyTo(_UserArray, 0);
                return PasswordTestByUsers(server, _UserArray, passwordList, conn);
            }
        }

        /// <summary>
        /// Performs a dictionary attach agains users belonging to the specified server roles.
        /// </summary>
        public TestResults PasswordTestByServerRole(ServerInformation server, string[] serverRoles, List<string> passwordList, SqlConnection conn)
        {
            using (CoreGlobals.traceLog.DebugCall("PasswordTestByServerRole"))
            {
                string _Sql = "select name, sysadmin, securityadmin, serveradmin, setupadmin, processadmin, diskadmin, dbcreator, bulkadmin " +
                              "from master..syslogins where isntname = 0 and isntgroup = 0 and isntuser = 0";
                if (SQLHelpers.Is2005orGreater(conn))
                {
                    _Sql = "select s.name, sysadmin, securityadmin, serveradmin, setupadmin, processadmin, diskadmin, dbcreator, bulkadmin "+
                           "from sys.sql_logins s inner join master..syslogins sl on s.name = sl.name";
                }

                StringCollection _Users = new StringCollection();
                using (SqlCommand _Command = new SqlCommand(_Sql, conn))
                using (SqlDataReader _Reader = _Command.ExecuteReader())
                {
                    while (_Reader.Read())
                    {
                        foreach (string role in serverRoles)
                        {
                            if (_Reader.GetInt32(_Reader.GetOrdinal(role)) == 1)
                            {
                                if(!_Users.Contains(_Reader.GetString(0)))
                                {
                                    _Users.Add(_Reader.GetString(0));
                                }
                            }

                        }
                    }
                }

                string[] _UserArray = new string[_Users.Count];
                _Users.CopyTo(_UserArray, 0);
                return PasswordTestByUsers(server, _UserArray, passwordList, conn);
            }
        }

        /// <summary>
        /// Performs a dictionary attach agains users belonging to the specified database roles.
        /// </summary>
        public TestResults PasswordTestByDatabaseRole(ServerInformation server, string[] databaseRoles, List<string> passwordList, SqlConnection conn)
        {
            using (CoreGlobals.traceLog.DebugCall("PasswordTestByServerRole"))
            {
                string _Sql = "SELECT r.name RoleName, u.name UserName, m.groupuid, l.loginName " +
                              "FROM sysmembers m INNER JOIN sysusers r " +
                              "ON m.groupuid = r.uid INNER JOIN sysusers u " +
                              "ON m.memberuid = u.uid INNER JOIN master..syslogins l " +
                              "ON u.sid = l.sid " +
                              "WHERE r.issqlrole = 1 " +
                              "AND l.isntname = 0 and l.isntgroup = 0 and l.isntuser = 0 " +
                              "ORDER BY RoleName";

                StringCollection _Users = new StringCollection();
                foreach (DatabaseObject _Database in SQLObjects.GetDatabases(conn, false))
                {
                    conn.ChangeDatabase(_Database.name);
                    using (SqlCommand _Command = new SqlCommand(_Sql, conn))
                    using (SqlDataReader _Reader = _Command.ExecuteReader())
                    {
                        while (_Reader.Read())
                        {
                            bool _RoleFound = false;
                            foreach (string role in databaseRoles)
                            {
                                if (role.ToUpperInvariant() == _Reader.GetString(_Reader.GetOrdinal("RoleName")).ToUpperInvariant())
                                {
                                    _RoleFound = true;
                                }
                            }
                            if (_RoleFound && !_Users.Contains(_Reader.GetString(_Reader.GetOrdinal("loginName"))))
                            {
                                _Users.Add(_Reader.GetString(_Reader.GetOrdinal("loginName")));                                
                            }
                        }
                    }
                }
                
                string[] _UserArray = new string[_Users.Count];
                _Users.CopyTo(_UserArray, 0);
                return PasswordTestByUsers(server, _UserArray, passwordList, conn);
            }
        }

        #endregion
    }



    internal class SqlLogin
    {
        public string name;
        public bool isDisabled;
        public bool loginExists;

        public byte[] mixedCasePasswordHash;
        public byte[] upperCasePasswordHash;
        public byte[] passwordSalt;

        public SqlLogin(string name)
        {
            this.name = name;
        }

        public SqlLogin(string name, bool isDisabled, byte[] passwordHash)
        {
            this.name = name;
            this.isDisabled = isDisabled;
            SetPasswordHash(passwordHash);
        }

        public void SetPasswordHash(byte[] passwordHash)
        {
            using (CoreGlobals.traceLog.DebugCall("SetPasswordHash"))
            {

                if (passwordHash != null)
                {
                    if (passwordHash.Length >= 6)
                    {
                        passwordSalt = new byte[4];
                        Array.ConstrainedCopy(passwordHash, 2, passwordSalt, 0, 4);
                    }
                    if (passwordHash.Length >= 70)          // check for SQL 2012 hash first
                    {
                        mixedCasePasswordHash = new byte[64];
                        Array.ConstrainedCopy(passwordHash, 6, mixedCasePasswordHash, 0, 64);
                    }
                    else if (passwordHash.Length >= 26)     // check for SQL 2000 - 2008 hash
                    {
                        mixedCasePasswordHash = new byte[20];
                        Array.ConstrainedCopy(passwordHash, 6, mixedCasePasswordHash, 0, 20);
                    }
                }
                else
                {
                    passwordSalt = mixedCasePasswordHash = upperCasePasswordHash = null;
                }
            }
        }
    }
}