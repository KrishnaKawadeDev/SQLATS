using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;
using System.Net;


namespace Idera.SqlAdminToolset.Core
{
    /// <summary>
    /// Summary description for SQLHelpers.
    /// </summary>
    public class SQLHelpers
    {
        public SQLHelpers()
        {
        }

        #region Safe SqlReader readers

        static public byte[] GetBinary(SqlDataReader rdr, int index)
        {
            byte[] retval = null;
            if (!rdr.IsDBNull(index))
            {
                System.Data.SqlTypes.SqlBinary field = rdr.GetSqlBinary(index);
                retval = field.Value;
            }
            return retval;
        }

        static public bool GetBool(SqlDataReader rdr, int index)
        {
            bool retval = false;

            if (!rdr.IsDBNull(index))
            {
                retval = (bool)rdr.GetBoolean(index);
            }

            return retval;
        }

        static public int ByteToInt(SqlDataReader rdr, int index)
        {
            int retval = -1;

            if (!rdr.IsDBNull(index))
            {
                retval = (int)rdr.GetByte(index);
            }

            return retval;
        }

        static public bool ByteToBool(SqlDataReader rdr, int index)
        {
            bool retval = false;

            if (!rdr.IsDBNull(index))
            {
                if (rdr.GetByte(index) != 0)
                    retval = true;
                else
                    retval = false;
            }

            return retval;
        }

        static public bool IntToBool(SqlDataReader rdr, int index)
        {
            bool retval = false;

            if (!rdr.IsDBNull(index))
            {
                if (rdr.GetInt32(index) != 0)
                    retval = true;
                else
                    retval = false;
            }

            return retval;
        }



        static public string GetString(SqlDataReader rdr, int index)
        {
            string retval;

            if (!rdr.IsDBNull(index))
            {
                retval = rdr.GetString(index);
            }
            else
            {
                retval = "";
            }

            return retval;
        }

        static public string GetSafeString(SqlDataReader rdr, int index)
        {
            string retval;

            retval = GetString(rdr, index);
            return CreateSafeString(rdr.GetString(index));
        }

        static public DateTime GetDateTime(SqlDataReader rdr, int index)
        {
            DateTime retval;

            if (!rdr.IsDBNull(index))
            {
                retval = rdr.GetDateTime(index);
            }
            else
            {
                retval = DateTime.MinValue;
            }

            return retval;
        }

        static public double GetDouble(SqlDataReader rdr, int index)
        {
            double retval;

            if (!rdr.IsDBNull(index))
            {
                retval = rdr.GetDouble(index);
            }
            else
            {
                retval = 0.0;
            }

            return retval;
        }

        static public long GetInt64(SqlDataReader rdr, int index)
        {
            long retval;

            if (!rdr.IsDBNull(index))
            {
                retval = rdr.GetInt64(index);
            }
            else
            {
                retval = 0;
            }

            return retval;
        }

        static public int GetInt32(SqlDataReader rdr, int index)
        {
            int retval;

            if (!rdr.IsDBNull(index))
            {
                retval = rdr.GetInt32(index);
            }
            else
            {
                retval = 0;
            }

            return retval;
        }

        static public int GetInt16(SqlDataReader rdr, int index)
        {
            int retval;

            if (!rdr.IsDBNull(index))
            {
                retval = rdr.GetInt16(index);
            }
            else
            {
                retval = 0;
            }

            return retval;
        }

        #endregion

        #region Safe DataRow readers

        #region Get Cell by column index

        static public string
           GetRowString(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return "";
            else
                return (string)row[colNdx];
        }

        static public bool
           GetRowBoolFromInt(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return false;
            else
                return ((int)row[colNdx] == 1);
        }

        static public bool
           GetRowBool(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return false;
            else
                return ((bool)row[colNdx]);
        }

        static public byte
           GetRowByte(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return 0;
            else
                return (byte)row[colNdx];
        }

        static public Guid
           GetRowGuid(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return new Guid();
            else
                return (Guid)row[colNdx];
        }

        static public Int16
           GetRowInt16(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return 0;
            else
                return (Int16)row[colNdx];
        }

        static public int
           GetRowInt32(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return 0;
            else
                return (int)row[colNdx];
        }

        static public ulong
           GetRowUlong(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return 0;
            else
                return (ulong)row[colNdx];
        }

        static public long
           GetRowLong(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return 0;
            else
                return (long)row[colNdx];
        }

        static public DateTime
           GetRowDateTime(
              DataRow row,
              int colNdx
           )
        {
            if (row.IsNull(colNdx))
                return DateTime.MinValue;
            else
                return (DateTime)row[colNdx];
        }

        #endregion

        #region Get Cell By column name

        static public string
           GetRowString(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return "";
            else
                return (string)row[colName];
        }

        static public bool
           GetRowBoolFromInt(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return false;
            else
                return ((int)row[colName] == 1);
        }

        static public bool
           GetRowBool(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return false;
            else
                return ((bool)row[colName]);
        }

        static public byte
           GetRowByte(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return 0;
            else
                return (byte)row[colName];
        }

        static public Guid
           GetRowGuid(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return new Guid();
            else
                return (Guid)row[colName];
        }

        static public Int16
           GetRowInt16(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return 0;
            else
                return (Int16)row[colName];
        }

        static public int
           GetRowInt32(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return 0;
            else
                return (int)row[colName];
        }

        static public ulong
           GetRowUlong(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return 0;
            else
                return (ulong)row[colName];
        }

        static public long
           GetRowLong(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return 0;
            else
                return (long)row[colName];
        }

        static public DateTime
           GetRowDateTime(
              DataRow row,
              string colName
           )
        {
            if (row.IsNull(colName))
                return DateTime.MinValue;
            else
                return (DateTime)row[colName];
        }

        #endregion

        #endregion

        #region Get SQL Server Version Routines

        //------------------------------------------------------------------
        // GetSqlVersionString - Retrieve instance's version string
        //------------------------------------------------------------------
        static public string
           GetSqlVersionString(
              SqlConnection conn
           )
        {
            string versionString = null;

            try
            {
                using (SqlCommand myCommand = new SqlCommand("SELECT @@VERSION", conn))
                {
                    myCommand.CommandTimeout = ToolsetOptions.commandTimeout;

                    versionString = (string)myCommand.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.VerboseFormat("GetSqlVersionString - {0}", Helpers.GetCombinedExceptionText(ex));
            }

            return versionString;
        }


        static public void
           updateSetting(string DatabaseName,
              SqlConnection conn
           )
        {

            try
            {
                using (SqlCommand myCommand = new SqlCommand("ALTER DATABASE " + DatabaseName + " SET ENABLE_BROKER", conn))

                {
                    myCommand.CommandTimeout = ToolsetOptions.commandTimeout;
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.Debug(ex);
            }


        }

        static public void
          updateHonorBrker(string DatabaseName,
             SqlConnection conn
          )
        {

            try
            {
                using (SqlCommand myCommand = new SqlCommand("ALTER DATABASE " + DatabaseName + " SET HONOR_BROKER_PRIORITY ON;", conn))

                {
                    myCommand.CommandTimeout = ToolsetOptions.commandTimeout;
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }


        }

        static public void
          updateTrustworthy(string DatabaseName,
             SqlConnection conn
          )
        {

            try
            {
                using (SqlCommand myCommand = new SqlCommand("ALTER DATABASE " + DatabaseName + " SET TRUSTWORTHY ON;", conn))

                {
                    myCommand.CommandTimeout = ToolsetOptions.commandTimeout;
                    myCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }


        }

        //------------------------------------------------------------------
        // GetSqlServicePackName - Retrieve SQL Server Service Pack Name
        //------------------------------------------------------------------
        static public string
           GetSqlServicePackName(
              SqlConnection conn
           )
        {
            string ServicePackName = null;

            try
            {
                using (SqlCommand myCommand = new SqlCommand("SELECT SERVERPROPERTY('productlevel')", conn))
                {
                    myCommand.CommandTimeout = ToolsetOptions.commandTimeout;

                    ServicePackName = (string)myCommand.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.VerboseFormat("GetSqlServicePackName - {0}", Helpers.GetCombinedExceptionText(ex));
            }

            return ServicePackName;
        }

        //------------------------------------------------------------------
        // GetSqlVersion - return integer representation of major version
        //                 8 = 2000, 9 = 2005
        //
        //  Two versions
        //  (1) Read from SQL Server and parse
        //  (2) Just parse a string for version
        //
        //   Note: Any badness in string results in us returning 0 for version
        //------------------------------------------------------------------
        // GetSqlVersion - read from SQL Server
        //------------------------------------------------------------------
        static public int
           GetSqlVersion(
              SqlConnection conn
           )
        {
            string sqlVersionString = GetSqlVersionString(conn);

            if (sqlVersionString == null) return 0;

            return GetSqlVersion(sqlVersionString);
        }

        //------------------------------------------------------------------
        // GetSqlVersion - parse version string
        //------------------------------------------------------------------
        static public int
           GetSqlVersion(
              string versionString
           )
        {
            int sqlVersion = 0;
            string sqlVersionMajor;
            int iStart, iEnd;
            try
            {
                sqlVersion = 0;
                iStart = versionString.IndexOf("- ");
                if (iStart == -1) return 0;
                iStart += 2;
                iEnd = versionString.IndexOf(".", iStart);
                if (iEnd == -1) return 0;
                sqlVersionMajor = versionString.Substring(iStart, iEnd - iStart);
                sqlVersion = int.Parse(sqlVersionMajor);
            }
            catch
            {
                sqlVersion = 0;
            }
            return sqlVersion;
        }

        //-----------------------------------------------------------------------
        // Explicit Version Check Functions
        //-----------------------------------------------------------------------
        static public bool Is2000(SqlConnection conn) { return Is2000(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2005(SqlConnection conn) { return Is2005(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2008(SqlConnection conn) { return Is2008(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2012(SqlConnection conn) { return Is2012(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2014(SqlConnection conn) { return Is2014(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2016(SqlConnection conn) { return Is2016(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2017(SqlConnection conn) { return Is2017(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2019(SqlConnection conn) { return Is2019(SQLHelpers.GetSqlVersion(conn)); }

        static public bool Is2000orGreater(SqlConnection conn) { return Is2000orGreater(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2005orGreater(SqlConnection conn) { return Is2005orGreater(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2008orGreater(SqlConnection conn) { return Is2008orGreater(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2012orGreater(SqlConnection conn) { return Is2012orGreater(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2014orGreater(SqlConnection conn) { return Is2014orGreater(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2016orGreater(SqlConnection conn) { return Is2016orGreater(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2017orGreater(SqlConnection conn) { return Is2017orGreater(SQLHelpers.GetSqlVersion(conn)); }
        static public bool Is2019orGreater(SqlConnection conn) { return Is2019orGreater(SQLHelpers.GetSqlVersion(conn)); }

        static public bool Is2000(int majorVersion) { return (majorVersion == 8); }
        static public bool Is2005(int majorVersion) { return (majorVersion == 9); }
        static public bool Is2008(int majorVersion) { return (majorVersion == 10); }
        static public bool Is2012(int majorVersion) { return (majorVersion == 11); }
        static public bool Is2014(int majorVersion) { return (majorVersion == 12); }
        static public bool Is2016(int majorVersion) { return (majorVersion == 13); }
        static public bool Is2017(int majorVersion) { return (majorVersion == 14); }
        static public bool Is2019(int majorVersion) { return (majorVersion == 15); }

        static public bool Is2000orGreater(int majorVersion) { return (majorVersion >= 8); }
        static public bool Is2005orGreater(int majorVersion) { return (majorVersion >= 9); }
        static public bool Is2008orGreater(int majorVersion) { return (majorVersion >= 10); }
        static public bool Is2012orGreater(int majorVersion) { return (majorVersion >= 11); }
        static public bool Is2014orGreater(int majorVersion) { return (majorVersion >= 12); }
        static public bool Is2016orGreater(int majorVersion) { return (majorVersion >= 13); }
        static public bool Is2017orGreater(int majorVersion) { return (majorVersion >= 14); }
        static public bool Is2019orGreater(int majorVersion) { return (majorVersion >= 15); }
        #endregion

        #region Create Escaped Strings

        //----------------------------------------------------------------------------------------
        // CreateTinyIntString - creates safe string parameter for tinyint representation of bool
        //----------------------------------------------------------------------------------------
        static public string
         CreateTinyIntString(
            bool flag
         )
        {
            string safeString;
            if (flag == false)
                safeString = "0";
            else
                safeString = "1";

            return safeString;
        }



        //-----------------------------------------------------------------------
        // CreateSafeString - creates safe string that includes
        //                    single quotes and brackets for use in RowFilters
        //-----------------------------------------------------------------------
        static public string CreateSafeSearchString(string searchtext)
        {
            // brackets have to be escaped in RowFilter search strings by surrounding them with brackets
            // divide at close brackets so they don't get confused with the inserted ones
            string[] subs = searchtext.Split(new char[] { ']' });
            StringBuilder sb = new StringBuilder(subs[0].Replace("[", "[[]"));
            int i = 1;
            while (i <= subs.Length - 1)
            {
                sb.Append("[]]");    // put the escaped close bracket back
                sb.Append(subs[i].Replace("[", "[[]"));
                i++;
            }
            sb.Replace("'", "''");
            // escape wildcard chars that are not at the beginning or end
            sb.Replace("*", "[*]", 1, sb.Length - 2);
            sb.Replace("%", "[%]", 1, sb.Length - 2);

            return sb.ToString();
        }

        //-----------------------------------------------------------------------
        // CreateSafeString - creates safe string parameter includes
        //                    single quotes; used to create sql parameters
        //-----------------------------------------------------------------------
        static public string CreateSafeString(string propName)
        {
            return CreateSafeString(propName, int.MaxValue);
        }

        //-----------------------------------------------------------------------
        // CreateSafeString - creates safe string parameter includes
        //                    single quotes; used to create sql parameters with
        //                    length limit
        //-----------------------------------------------------------------------
        static public string CreateSafeString(string propName, int limit)
        {
            StringBuilder newName;
            string tmpValue;

            if (propName == null)
            {
                newName = new StringBuilder("null");
            }
            else
            {
                newName = new StringBuilder("'");
                tmpValue = propName.Replace("'", "''");
                if (tmpValue.Length > limit)
                {
                    if (tmpValue[limit - 1] == '\'')
                    {
                        limit--;
                        if (tmpValue[limit - 1] == '\'')
                            limit--;
                    }
                    tmpValue = tmpValue.Remove(limit, tmpValue.Length - limit);
                }
                newName.Append(tmpValue);
                newName.Append("'");
            }

            return newName.ToString();
        }

        //-----------------------------------------------------------------------
        // CreateDoubleQuotedString - creates safe double quoted string parameter
        //                      e.g ALTER LOGIN loginname 
        //-----------------------------------------------------------------------
        static public string CreateDoubleQuotedString(string propName)
        {
            StringBuilder newName;
            string tmpValue;

            if (propName == null)
            {
                newName = new StringBuilder("null");
            }
            else
            {
                newName = new StringBuilder("\"");
                tmpValue = propName.Replace("\"", "\"\"");
                newName.Append(tmpValue);
                newName.Append("\"");
            }

            return newName.ToString();
        }


        //-----------------------------------------------------------------------
        // CreateSafeDateTimeString - creates safe string parameter
        //                            includes single quotes
        //                            used to create sql parameters
        //-----------------------------------------------------------------------
        static public string
           CreateSafeDateTimeString(
              DateTime timestamp
           )
        {
            return CreateSafeDateTimeString(timestamp, true);
        }

        //-----------------------------------------------------------------------
        // CreateSafeDateTimeString - creates safe string parameter
        //                            includes single quotes
        //                            used to create sql parameters
        //-----------------------------------------------------------------------
        static public string
           CreateSafeDateTimeString(
              DateTime timestamp,
              bool includeQuotes
           )
        {
            /* The problem with CultureInfo.CurrentCulture.DateTimeFormat is it doesn't work
             * on UK platforms.  SQL Server complains that the datetime values cannot be converted.
             * So use the SQL Server CONVERT function to explicitly convert the value from ODBC format */
            /*
            StringBuilder newName = new StringBuilder("");

            if ( timestamp == DateTime.MinValue )
            {
               newName.Append("null");
            }
            else
            {
                  if ( includeQuotes) newName = new StringBuilder("'");
               //newName.Append( timestamp.ToString( "yyyy-MM-dd HH:mm:ss.fff",
               //                                    DateTimeFormatInfo.InvariantInfo ) );
               newName.AppendFormat( timestamp.ToString( CultureInfo.CurrentCulture.DateTimeFormat ) );
                 if ( includeQuotes) newName.Append("'");
              }

               //builder.Append(String.Format("{0}-{1}-{2} {3}:{4}:{5}", filterDateTime.Year, filterDateTime.Month,
               //filterDateTime.Day, filterDateTime.Hour, filterDateTime.Minute, filterDateTime.Second)) ;
            //ErrorLog.Instance.Write( ErrorLog.Level.UltraDebug, "CreateSafeDateTimeString() returning " + newName.ToString());


            //return newName.ToString();
            */
            return CreateSafeDateTime(timestamp);
        }

        //-----------------------------------------------------------------------
        // CreateSafeDateTime - creates a SQL Server CONVERT function call for 
        //                      DateTime Value
        //-----------------------------------------------------------------------
        static public string
           CreateSafeDateTime(
              DateTime timestamp
           )
        {
            string newString;

            if (timestamp == DateTime.MinValue)
            {
                newString = "null";
            }
            else
            {
                newString = String.Format("CONVERT(DATETIME, '{0}-{1}-{2} {3}:{4}:{5}.{6:000}',121)", timestamp.Year,
                    timestamp.Month, timestamp.Day, timestamp.Hour, timestamp.Minute, timestamp.Second, timestamp.Millisecond);
                /*
                newString = String.Format( "CONVERT( DATETIME, '{0}', 20 ) ", 
                                           timestamp.ToString( "yyyy-MM-dd HH:mm:ss.fff",
                                                                            DateTimeFormatInfo.InvariantInfo ));
                                                                            */
            }
            //ErrorLog.Instance.Write( ErrorLog.Level.UltraDebug, "CreateSafeDateTime() returning " + newString);

            return newString;
        }
        //-----------------------------------------------------------------------
        // CreateSafeDatabaseName - creates safe db name for SQL
        //-----------------------------------------------------------------------
        static public string CreateSafeDatabaseName(string dbName)
        {
            StringBuilder newName;

            newName = new StringBuilder("[");
            newName.Append(dbName.Replace("]", "]]"));
            newName.Append("]");

            return newName.ToString();
        }

        //-----------------------------------------------------------------------
        // CreateSafeDatabaseNameForConnectionString
        //
        // (1) If database begins or ends with blanks, wrap in quotes
        // (2) If contains one of ;'" then you need to espace with ' or ". Use "
        //     unless first character is single quote then use double quote
        // (3) If string contains any escaped chars enclose in quotes
        //-----------------------------------------------------------------------
        static public string
           CreateSafeDatabaseNameForConnectionString(
              string dbName
           )
        {
            if (dbName == null || dbName.Length == 0) return dbName;

            // Use double quote as escape character unless first character is double
            // quote; then use single quote
            string doubleQuote = "\"";

            bool encloseInQuotes = false;

            // Do we need to enclose in quotes? (contains semicolon or leading or trailing spaces)
            if ((-1 != dbName.IndexOf(";")) ||
                 (dbName[0] == ' ' || dbName[dbName.Length - 1] == ' '))
            {
                encloseInQuotes = true;
            }

            if (encloseInQuotes)
            {
                // escape any double quotes
                dbName = dbName.Replace(doubleQuote, "\"\"");
                dbName = doubleQuote + dbName + doubleQuote;
            }

            return dbName;
        }

        #endregion

        #region General Helpers 

        //--------------------------------------------------------------------
        // NormalizeInstanceName - Converts local aliases to actual instance
        //                         name; capitalizes others
        //
        //
        // add support for special case where users type in form
        //   np:\\machine\asd\asd\asd - basically if it comes in this form
        //                              we leave as is for the instance name
        //--------------------------------------------------------------------
        static public string
           NormalizeInstanceName(
              string instanceName
           )
        {
            string host = "";
            string instance = "";
            string port = "";
            string normalizedName = "";

            if (String.IsNullOrEmpty(instanceName)) return instanceName;


            if (instance.Contains(@":\\"))
            {
                // handle special case of np:\\asd\asd\asd\asd <-- just leave as is - allows customer special override of namedpipes etc
                normalizedName = instance;
            }
            else
            {
                instance = instanceName.Trim().ToUpper();

                // strip off port
                int pos = instance.IndexOf(",");
                if (pos == 0)
                {
                    port = instance.Substring(1);
                    instance = "";
                }
                else if (pos > 0)
                {
                    port = instance.Substring(pos + 1);
                    instance = instance.Substring(0, pos);
                }

                // separate at backslash
                pos = instance.IndexOf('\\');
                if (pos == -1)
                {
                    host = instance;
                    instance = "";
                }
                else
                {
                    host = instance.Substring(0, pos);
                    instance = instance.Substring(pos);
                }

                if (host == "" ||
                     host == "." ||
                     host == "(LOCAL)" ||
                     host == "LOCALHOST")
                {
                    host = Dns.GetHostName().ToUpper();
                }

                normalizedName = host + instance;
                if (port != "") normalizedName += "," + port;
            }

            return (normalizedName);
        }

        //--------------------------------------------------------------------
        // NormalizeRecoveryMode
        //--------------------------------------------------------------------
        static public string
           NormalizeRecoveryMode(
              string recoveryMode
           )
        {
            if (recoveryMode == "FULL") return "Full";
            else if (recoveryMode == "SIMPLE") return "Simple";
            else if (String.IsNullOrEmpty(recoveryMode)) return "";
            else return recoveryMode;
        }



        //--------------------------------------------------------------------
        // GetInstanceHost
        //--------------------------------------------------------------------
        static public string
           GetInstanceHost(
              string instance
           )
        {
            string host = "";


            // strip off any network library prefix
            //   form  prefix:\\servername or prefix:servername
            //   the key is the colon since it is not a legal character in a server
            int pos = instance.IndexOf(@":");
            if (pos > 0)
            {
                if (instance.Substring(pos).StartsWith(@":\\"))
                    instance = instance.Substring(pos + 3);
                else
                    instance = instance.Substring(pos + 1);
            }

            pos = instance.IndexOf(@"\");
            if (pos > 0)
            {
                host = instance.Substring(0, pos);
            }
            else
            {
                host = instance;
            }

            // strip off port
            pos = host.IndexOf(",");
            if (pos == 0)
            {
                host = "";
            }
            else if (pos > 0)
            {
                host = host.Substring(0, pos);
            }

            // expand local reference
            if (host == "" ||
                host == "." ||
                host.ToUpper() == "(LOCAL)" ||
                host.ToUpper() == "LOCALHOST")
            {
                host = System.Net.Dns.GetHostName().ToUpper();
            }

            return host;
        }

        //--------------------------------------------------------------------
        // GetInstance
        //
        // if path starts with xxx:\\casdasd then we have to search for 
        //      form MSSQL$xxxx in the string
        //--------------------------------------------------------------------
        static public string
           GetInstance(
              string serverPath
           )
        {
            string instance = "";

            // strip off port
            int pos = serverPath.IndexOf(",");
            if (pos != -1)
            {
                instance = serverPath.Substring(0, pos);
            }
            else
            {
                instance = serverPath;
            }

            if (instance.Contains(@":\\"))
            {
                // look for MSSQL$xxx (like used in pipes!)
                pos = instance.IndexOf(@"\MSSQL$");
                if (pos == -1)
                {
                    if (instance.Contains(@"\MSSQLSERVER"))
                    {
                        instance = GetInstanceHost(serverPath);
                    }
                    else
                    {
                        instance = "";
                    }
                }
                else
                {
                    int pos2 = instance.IndexOf(@"\", pos + 1); // find trailing backslash for form MSSQL$xxx\
                    if (pos2 == -1)
                        instance = instance.Substring(pos + 7);
                    else
                        instance = instance.Substring(pos + 7, pos2 - pos - 7);
                }
            }
            else
            {
                // skip any protocol prefix (e.g. tcp:host\instance)
                pos = instance.IndexOf(":");
                if (pos != -1)
                {
                    instance = instance.Substring(pos + 1);
                }

                pos = instance.IndexOf(@"\");
                if (pos >= 0)
                {
                    instance = instance.Substring(pos + 1);
                }

                // expand local reference
                if (instance == "" ||
                    instance == "." ||
                    instance.ToUpper() == "(LOCAL)" ||
                    instance.ToUpper() == "LOCALHOST")
                {
                    instance = System.Net.Dns.GetHostName().ToUpper();
                }
            }

            return instance;
        }


        //--------------------------------------------------------------------
        // GetPort
        //--------------------------------------------------------------------
        static public string
           GetPort(
              string serverPath
           )
        {
            string port = "";

            int pos = serverPath.IndexOf(",");
            if (pos != -1)
            {
                port = serverPath.Substring(pos + 1);
            }

            return port;
        }

        //--------------------------------------------------------------------
        // IsSystemDatabase
        //--------------------------------------------------------------------
        static public bool
           IsSystemDatabase(
              string database
           )
        {
            string[] systemDatabases = new string[]
            {
             "master",
             "tempdb",
             "model",
             "msdb",
             "mssqlsystemresource"
            };

            // see if this is one of those commands
            bool found = false;
            foreach (string d in systemDatabases)
            {
                if (database == d)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public static bool
           IsSystemDatabaseBySid(
              byte[] sid
           )
        {
            bool systemDb = false;

            if (sid != null && sid.Length == 1 && sid[0] == 1)
            {
                systemDb = true;
            }

            return systemDb;
        }


        /// <summary>
        /// Retrieves the login name used for SA in case it has been renamed.
        /// </summary>
        public static string
           GetSaLogin(
              string server,
              SQLCredentials sqlCredentials)
        {
            string _SaLogin = null;
            using (SqlConnection _Connection = Connection.OpenConnection(server, sqlCredentials))
            {
                _SaLogin = GetSaLogin(_Connection);
            }
            return _SaLogin;
        }

        /// <summary>
        /// Retrieves the login name used for SA in case it has been renamed.
        /// </summary>
        public static string
           GetSaLogin(
              SqlConnection conn)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            string _SaLogin = null;

            string _Sql = Is2005orGreater(conn) ? "SELECT name FROM sys.sql_logins WHERE sid = 0x01" :
                                                         "SELECT name FROM syslogins WHERE sid = 0x01";
            using (SqlCommand _Command = new SqlCommand(_Sql, conn))
            {
                _SaLogin = (string)_Command.ExecuteScalar();
            }
            return _SaLogin;
        }

        /// <summary>
        /// Retrieves when the SQL Server was started last.
        /// </summary>
        public static DateTime GetServerStartDate(SqlConnection conn)
        {
            try
            {
                string _Sql = Is2008orGreater(conn) ? "SELECT sqlserver_start_time FROM sys.dm_os_sys_info" :
                                                      "SELECT login_time FROM master..sysprocesses WHERE spid = 1";

                using (SqlCommand _Command = new SqlCommand(_Sql, conn))
                {
                    return (DateTime)_Command.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error Getting Server Start Date: {0}", Helpers.GetCombinedExceptionText(ex)));
            }
        }
        #endregion

        //-------------------------------------------------------------------------
        // ConvertSqlWildcardToRegEx
        //
        // strings to convert
        //
        // SQL    REGEX
        // ---    -----
        //  %       *
        //  _       ?
        //
        //
        // Since * and ? are not wildcards in SQL, we need to escape on the way out
        //--------------------------------------------------------------------------
        static public string
           ConvertSqlWildcardToRegEx(
              string sqlPattern
           )
        {
            bool inBracket = false; // bracket used for esc so ignore characters to convert in brackets
            string bracketContents = "";
            string regEx = "";

            for (int i = 0; i < sqlPattern.Length; i++)
            {
                if (inBracket)
                {
                    if (sqlPattern[i] == ']')
                    {
                        // process bracket contents
                        if (bracketContents == "%")
                        {
                            regEx += "%";
                        }
                        else if (bracketContents == "_")
                        {
                            regEx += "_";
                        }
                        else
                        {
                            regEx += "[" + bracketContents + "]";
                        }
                        inBracket = false;
                    }
                    else
                    {
                        bracketContents += sqlPattern[i];
                    }
                }
                else
                {
                    //----------------------------------
                    // convert SQL wildcard characters
                    //----------------------------------
                    if (sqlPattern[i] == '%')
                    {
                        regEx += "*";
                    }
                    else if (sqlPattern[i] == '_')
                    {
                        regEx += ".";
                    }
                    //-----------------------------------------------------------------------
                    // Escape characters unrecognized by SQL that would cause regex behavior
                    //-----------------------------------------------------------------------
                    else if (sqlPattern[i] == '*' ||
                              sqlPattern[i] == '?' ||
                              sqlPattern[i] == '\\' ||
                              sqlPattern[i] == '(' ||
                              sqlPattern[i] == '{' ||
                              sqlPattern[i] == '^' ||
                              sqlPattern[i] == '.')
                    {
                        regEx += @"\" + sqlPattern[i];
                    }
                    else if (sqlPattern[i] == '[')
                    {
                        inBracket = true;
                        bracketContents = "";
                    }
                    else
                    {
                        regEx += sqlPattern[i];
                    }
                }
            }

            if (inBracket)
            {
                // no closing bracket - dump everything on regex
                regEx = regEx + "[" + bracketContents;
            }
            return regEx;
        }

        public static string
           EscapeWildcards(
              string sqlString
           )
        {
            string newSqlString = "";

            for (int i = 0; i < sqlString.Length; i++)
            {
                if (sqlString[i] == '%')
                {
                    newSqlString += "[%]";
                }
                else if (sqlString[i] == '_')
                {
                    newSqlString += "[_]";
                }
                else if (sqlString[i] == '[')
                {
                    newSqlString += "[[]";
                }
                //else if ( sqlString[i] == ']' )
                //{
                //   newSqlString += "[]]";
                //}
                else
                {
                    newSqlString += sqlString[i];
                }
            }

            return newSqlString;
        }

        static public string GetServiceName(string instance)
        {
            string serviceName = "";

            string host = SQLHelpers.GetInstanceHost(instance);
            string inst = SQLHelpers.GetInstance(instance);

            if (inst == host)
            {
                serviceName = "MSSQLSERVER";
            }
            else if (inst != "")
            {
                serviceName = String.Format("MSSQL${0}", inst);
            }

            return serviceName;
        }




        #region Get User Database Creation Date

        private static SqlInfoMessageEventHandler sqlInfoMessageHandlerDelegate;

        private static void SqlInfoMessageHandler(Object sender, SqlInfoMessageEventArgs e)
        {
            try
            {
                string result = e.Message;
                int i = result.IndexOf("dbi_crdate = ");
                i = i + 13;
                string year = result.Substring(i, 4);
                i = i + 5;
                string month = result.Substring(i, 2);
                i = i + 3;
                string day = result.Substring(i, 2);
                i = i + 3;
                string hour = result.Substring(i, 2);
                i = i + 3;
                string minute = result.Substring(i, 2);
                i = i + 3;
                string second = result.Substring(i, 2);

                staticCreationDate = new DateTime(Convert.ToInt32(year),
                                                  Convert.ToInt32(month),
                                                  Convert.ToInt32(day),
                                                  Convert.ToInt32(hour),
                                                  Convert.ToInt32(minute),
                                                  Convert.ToInt32(second));
            }
            catch { }
        }

        public static DateTime staticCreationDate = DateTime.MinValue;

        /// <summary>
        /// Retrieves the login name used for SA in case it has been renamed.
        /// </summary>
        public static DateTime
         GetCreationDateForUserDatabase(
            string server,
            SQLCredentials sqlCredentials,
            string dbName)
        {
            DateTime creationDate = DateTime.MinValue;
            using (SqlConnection _Connection = Connection.OpenConnection(server, sqlCredentials))
            {
                creationDate = GetCreationDateForUserDatabase(_Connection, dbName);
            }
            return creationDate;
        }

        static public DateTime GetCreationDateForUserDatabase(SqlConnection conn, string dbName)
        {
            staticCreationDate = DateTime.MinValue;
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                     conn.Open();
                }
                sqlInfoMessageHandlerDelegate = SqlInfoMessageHandler;
                string query = string.Format("DBCC TRACEON(3604) DBCC DBINFO({0})", CreateSafeDatabaseName(dbName));
                conn.InfoMessage += sqlInfoMessageHandlerDelegate;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                conn.InfoMessage -= sqlInfoMessageHandlerDelegate;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error Getting Database Creation Date: {0}", Helpers.GetCombinedExceptionText(ex)));
            }

            return staticCreationDate;
        }
        #endregion
    }
}

