using System.Text.RegularExpressions;

namespace Idera.SqlAdminToolset.Core
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Data.SqlClient;
	using System.IO;

	public enum SqlServerEditionType
	{
		Unknown		= 0,
		Desktop		= 1,
		Server		= 2
	}

	/// <summary>
	/// Represents a specific version of Microsoft SQL Server.
	/// </summary>
	[Serializable]
	public sealed class SQLVersion
	{
		private readonly Version version;
		private readonly string name;
		private readonly string servicelevel;
		private readonly SqlServerEditionType editionType;
		private readonly string edition;
		private readonly string platform;
		private readonly string processor;

		#region Static "Known Version" Constants (ADD HERE AS NEW RELEASES ARE AVAILABLE)

		public static readonly SQLVersion Unknown = new SQLVersion(0, 0, 0, 0, SqlServerEditionType.Unknown);

		/// <summary>
		/// SQL Server Version 6.5 RTM (6.5.201)
		/// </summary>
		public static readonly SQLVersion v6p5_Rtm = new SQLVersion(6, 5, 201, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 6.5 Service Pack 1 (6.5.213)
		/// </summary>
		public static readonly SQLVersion v6p5_Sp1 = new SQLVersion(6, 5, 213, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 6.5 Service Pack 2 (6.5.240)
		/// </summary>
		public static readonly SQLVersion v6p5_Sp2 = new SQLVersion(6, 5, 240, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 6.5 Service Pack 3 (6.5.258)
		/// </summary>
		public static readonly SQLVersion v6p5_Sp3 = new SQLVersion(6, 5, 258, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 6.5 Service Pack 4 (6.5.281)
		/// </summary>
		public static readonly SQLVersion v6p5_Sp4 = new SQLVersion(6, 5, 281, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 6.5 Service Pack 5 (6.5.415)
		/// </summary>
		public static readonly SQLVersion v6p5_Sp5 = new SQLVersion(6, 5, 415, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 6.5 Service Pack 5a (6.5.416)
		/// </summary>
		public static readonly SQLVersion v6p5_Sp5a = new SQLVersion(6, 5, 416, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 6.5 Service Pack 5a Update (6.5.479)
		/// </summary>
		public static readonly SQLVersion v6p5_Sp5a_Update = new SQLVersion(6, 5, 479, 0, SqlServerEditionType.Unknown);

		/// <summary>
		/// SQL Server 7.0 RTM (7.0.623)
		/// </summary>
		public static readonly SQLVersion v7p0_Rtm = new SQLVersion(7, 0, 623, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 7.0 Service Pack 1 (7.0.699)
		/// </summary>
		public static readonly SQLVersion v7p0_Sp1 = new SQLVersion(7, 0, 699, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 7.0 Service Pack 2 (7.0.842)
		/// </summary>
		public static readonly SQLVersion v7p0_Sp2 = new SQLVersion(7, 0, 842, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 7.0 Service Pack 3 (7.0.961)
		/// </summary>
		public static readonly SQLVersion v7p0_Sp3 = new SQLVersion(7, 0, 961, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 7.0 Service Pack 4 (7.0.1063)
		/// </summary>
		public static readonly SQLVersion v7p0_Sp4 = new SQLVersion(7, 0, 1063, 0, SqlServerEditionType.Unknown);

		/// <summary>
		/// SQL Server 2000 RTM (8.0.194)
		/// </summary>
		public static readonly SQLVersion v8p0_Rtm = new SQLVersion(8, 0, 194, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 2000 Service Pack 1 (8.0.384)
		/// </summary>
		public static readonly SQLVersion v8p0_Sp1 = new SQLVersion(8, 0, 384, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 2000 Service Pack 2 (8.0.534)
		/// </summary>
		public static readonly SQLVersion v8p0_Sp2 = new SQLVersion(8, 0, 534, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 2000 Service Pack 3 (8.0.760)
		/// </summary>
		public static readonly SQLVersion v8p0_Sp3 = new SQLVersion(8, 0, 760, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 2000 Service Pack 4 (8.0.2039)
		/// </summary>
		public static readonly SQLVersion v8p0_Sp4 = new SQLVersion(8, 0, 2039, 0, SqlServerEditionType.Unknown);

		/// <summary>
		/// SQL Server 2005 RTM (9.0.1399)
		/// </summary>
		public static readonly SQLVersion v9p0_Rtm = new SQLVersion(9, 0, 1399, 6, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 2005 Service Pack 1 (9.0.2047)
		/// </summary>
		public static readonly SQLVersion v9p0_Sp1 = new SQLVersion(9, 0, 2047, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 2005 Service Pack 2 (9.0.3042)
		/// </summary>
		public static readonly SQLVersion v9p0_Sp2 = new SQLVersion(9, 0, 3042, 0, SqlServerEditionType.Unknown);
		/// <summary>
		/// SQL Server 2005 Service Pack 3 (9.0.3042)
		/// </summary>
		public static readonly SQLVersion v9p0_Sp3 = new SQLVersion(9, 0, 4035, 0, SqlServerEditionType.Unknown);
        /// <summary>
        /// SQL Server 2005 Service Pack 4 (9.0.5000)
        /// </summary>
        public static readonly SQLVersion v9p0_Sp4 = new SQLVersion(9, 0, 5000, 0, SqlServerEditionType.Unknown);

        /// <summary>
        /// SQL Server 2008 RTM (10.0.1600)
        /// </summary>
        public static readonly SQLVersion v10p0_Rtm = new SQLVersion(10, 0, 1600, 22, SqlServerEditionType.Unknown);
        /// <summary>
        /// SQL Server 2008 SP1 (10.0.2531)
        /// </summary>
        public static readonly SQLVersion v10p0_Sp1 = new SQLVersion(10, 0, 2531, 0, SqlServerEditionType.Unknown);
        /// <summary>
        /// SQL Server 2008 SP1 (10.0.4000)
        /// </summary>
        public static readonly SQLVersion v10p0_Sp2 = new SQLVersion(10, 0, 4000, 0, SqlServerEditionType.Unknown);
        /// <summary>
        /// SQL Server 2008 SP1 (10.0.5500)
        /// </summary>
        public static readonly SQLVersion v10p0_Sp3 = new SQLVersion(10, 0, 5500, 0, SqlServerEditionType.Unknown);

        /// <summary>
        /// SQL Server 2008R2 RTM (10.50.1600)
        /// </summary>
        public static readonly SQLVersion v10p5_Rtm = new SQLVersion(10, 50, 1600, 1, SqlServerEditionType.Unknown);
        /// <summary>
        /// SQL Server 2008 SP1 (10.50.2500)
        /// </summary>
        public static readonly SQLVersion v10p5_Sp1 = new SQLVersion(10, 50, 2500, 0, SqlServerEditionType.Unknown);

        /// <summary>
        /// SQL Server 2012 RTM (11.0.2100)
        /// </summary>
        public static readonly SQLVersion v11p0_Rtm = new SQLVersion(11, 0, 2100, 60, SqlServerEditionType.Unknown);

		#endregion

		private SQLVersion(int major, int minor, int build, int revision, SqlServerEditionType editionType)
			: this(major, minor, build, revision, editionType, string.Empty, string.Empty, string.Empty)
		{
		}

		private SQLVersion(int major, int minor, int build, int revision, SqlServerEditionType editionType, string edition, string platform, string processor)
		{
			this.version = new Version(major, minor, build, revision);
			this.editionType = editionType;
			this.name = GetProductName();
			this.servicelevel = GetServiceLevel();
			//this.name = string.Format("{0} {1}", GetProductName(), GetServiceLevel());
			this.edition = edition;
			this.platform = platform;
			this.processor = processor;
		}

		#region Properties

		/// <summary>
		/// Gets the edition for this Microsoft SQL server version.
		/// </summary>
		public Version InnerVersion
		{
			get
			{
				return version;
			}
		}

		/// <summary>
		/// Gets the value of the major component of the version number for this Microsoft SQL server version.
		/// </summary>
		public int Major
		{
			get
			{
				return version.Major;
			}
		}

		/// <summary>
		/// Gets the value of the minor component of the version number for this Microsoft SQL server version.
		/// </summary>
		public int Minor
		{
			get
			{
				return version.Minor;
			}
		}

		/// <summary>
		/// Gets the value of the build component of the version number for this Microsoft SQL server version.
		/// </summary>
		public int Build
		{
			get
			{
				return version.Build;
			}
		}

		/// <summary>
		/// Gets the value of the revision component of the version number for this Microsoft SQL server version.
		/// </summary>
		public int Revision
		{
			get
			{
				return version.Revision;
			}
		}

		/// <summary>
		/// Gets a product name for this Microsoft SQL server version.
		/// </summary>
		public string Name
		{
			get
			{
				return name;
			}
		}

		/// <summary>
		/// Gets the service level for this Microsoft SQL server version.
		/// </summary>
		public string ServiceLevel
		{
			get
			{
				return servicelevel;
			}
		}

		/// <summary>
		/// Gets the edition for this Microsoft SQL server version.
		/// </summary>
		public string Edition
		{
			get
			{
				return edition;
			}
		}

		/// <summary>
		/// Gets a value that indicates the edition type (Server, Desktop, etc) of the SQL server version.
		/// </summary>
		public SqlServerEditionType EditionType
		{
			get
			{
				return editionType;
			}
		}

		/// <summary>
		/// Gets the platform for this Microsoft SQL server version.
		/// </summary>
		public string Platform
		{
			get
			{
				return platform;
			}
		}

		public string Processor
		{
			get
			{
				return processor;
			}

		}

		#endregion

		#region Object Overloads

		public override bool Equals(object obj)
		{
			return (obj is SQLVersion) ? version.Equals(((SQLVersion)obj).version) && editionType.Equals(((SQLVersion)obj).editionType) : false;
		}

		public override int GetHashCode()
		{
			return version.GetHashCode() ^ editionType.GetHashCode();
		}

		public override string ToString()
		{
			return (this != SQLVersion.Unknown) ? string.Format("{0} ({1})", name, version) : name;
		}

		#endregion

		#region Operator Implementations

		public static bool operator ==(SQLVersion version1, SQLVersion version2)
		{
			bool v1Null = object.Equals(version1, null);
			bool v2Null = object.Equals(version2, null);

			if (v1Null || v2Null)
			{
				return v1Null && v2Null;
			}
			else
			{
				return version1.version == version2.version && version1.editionType == version2.editionType;
			}
		}

		public static bool operator !=(SQLVersion version1, SQLVersion version2)
		{
			bool v1Null = object.Equals(version1, null);
			bool v2Null = object.Equals(version2, null);

			if (v1Null || v2Null)
			{
				return !(v1Null && v2Null);
			}
			else
			{
				return version1.version != version2.version || version1.editionType != version2.editionType;
			}
		}

		public static bool operator >(SQLVersion version1, SQLVersion version2)
		{
			bool v1Null = object.Equals(version1, null);
			bool v2Null = object.Equals(version2, null);

			if (v1Null || v2Null)
			{
				return !(v1Null && v2Null) && !v1Null;
			}
			else
			{
				return version1.version > version2.version;
			}
		}

		public static bool operator <(SQLVersion version1, SQLVersion version2)
		{
			bool v1Null = object.Equals(version1, null);
			bool v2Null = object.Equals(version2, null);

			if (v1Null || v2Null)
			{
				return !(v1Null && v2Null) && !v2Null;
			}
			else
			{
				return version1.version < version2.version;
			}
		}

		public static bool operator <=(SQLVersion version1, SQLVersion version2)
		{
			bool v1Null = object.Equals(version1, null);
			bool v2Null = object.Equals(version2, null);

			if (v1Null || v2Null)
			{
				return (v1Null && v2Null) || v1Null;
			}
			else
			{
				return version1.version <= version2.version;
			}
		}

		public static bool operator >=(SQLVersion version1, SQLVersion version2)
		{
			bool v1Null = object.Equals(version1, null);
			bool v2Null = object.Equals(version2, null);

			if (v1Null || v2Null)
			{
				return (v1Null && v2Null) || v2Null;
			}
			else
			{
				return version1.version >= version2.version;
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Converts the given Version instance to an equivalent SQLVersion.
		/// </summary>
		/// <param name="version">The version to convert.</param>
		/// <returns>A SQLVersion representation of the given version.</returns>
		public static SQLVersion FromVersion(Version version)
		{
			if (version == null)
				throw new ArgumentNullException("version");

			return new SQLVersion(
					version.Major > -1 ? version.Major : 0, 
					version.Minor > -1 ? version.Minor : 0, 
					version.Build > -1 ? version.Build : 0, 
					version.Revision > -1 ? version.Revision : 0, 
					SqlServerEditionType.Unknown);
		}

        /// <summary>
        /// Converts the string retrieved from a "USE master SELECT @@version" query to a SQLVersion object.
        /// </summary>
        /// <param name="s">The string from a "USE master SELECT @@version" query.</param>
        /// <param name="version">When this method returns, contains the SQLVersion value equivalent to the string 
        /// contained in s, if the conversion succeeded, or null if the conversion failed.  The conversion fails if the 
        /// s parameter is null, or is not of the correct format.</param>
        /// <returns>True if the conversion was successful; otherwise, false.</returns>
        public static bool TryParse(string s, out SQLVersion v)
        {
            if (s == null)
                throw new ArgumentNullException("s");

            try
            {
                using (StringReader x = new StringReader(s))
                {
                    string line1 = x.ReadLine().TrimStart('\t');
                    string line2 = x.ReadLine().TrimStart('\t');
                    string line3 = x.ReadLine().TrimStart('\t');
                    string line4 = x.ReadLine().TrimStart('\t');

                    Regex versionRegex = new Regex(@"\d{1,2}\.\d{1,2}\.\d{3,4}((\.\d{0,2}|))");
                    Regex processorRegex = new Regex(@"(?!\d{1,2}\.\d{1,2}\.\d{3,4}((\.\d{0,2}\s)|(\s)))((?<=\()\w\d{2}(?=\)))");

                    int dashIndex = line1.IndexOf('-');
                    int paraIndex = line1.LastIndexOf('(');

                    Version vtest = new Version(versionRegex.Match(line1).Value);
                    string processor = processorRegex.Match(line1).Value; ;
                    SqlServerEditionType editionType =
                        line4.StartsWith("MSDE", StringComparison.InvariantCultureIgnoreCase) ||
                        line4.StartsWith("Desktop", StringComparison.InvariantCultureIgnoreCase) ?
                        SqlServerEditionType.Desktop :
                        SqlServerEditionType.Server;
                    string edition = line4.Substring(0, line4.IndexOf(" on")).Trim();
                    int platformStart = line4.IndexOf(" on ");
                    string platform = platformStart > -1 ? line4.Substring(platformStart + 4).Trim() : string.Empty;

                    v = new SQLVersion(vtest.Major > 0 ? vtest.Major : 0, vtest.Minor > 0 ? vtest.Minor : 0, vtest.Build > 0 ? vtest.Build : 0, vtest.Revision > 0 ? vtest.Revision : 0, editionType, edition, platform, processor);
                    return true;
                }
            }
            catch (Exception)
            {
                v = null;
                return false;
            }
        }

        /// <summary>
        /// Attempts to read version information from a Microsoft SQL server and create an equivalent SQLVersion object.
        /// </summary>
        /// <param name="connection">The SqlConnection to use to get version information.  Connection must already be in an Open state.</param>
        /// <param name="v">When this method returns, contains the SQLVersion value equivalent to the version information
        /// collected from a SQL server instance using connection, if the operation succeeded, or null if the operation failed.
        /// The operation fails if the connection parameter is null, or is not open.</param>
        /// <returns>True if the operation was successful; otherwise, false.</returns>
        public static bool TryRead(SqlConnection connection, out SQLVersion v)
		{
			try
			{
				if (connection != null && !(connection.State != System.Data.ConnectionState.Open))
				{
					using (SqlCommand command = new SqlCommand("USE master SELECT @@version", connection))
					{
						return TryParse((string)command.ExecuteScalar(), out v);
					}
				}
			}
			catch (Exception)
			{
			}

			v = null;
			return false;
		}

		private string GetProductName()
		{
			switch (this.version.Major)
			{
				case 0:
					return "SQL Server (unknown version)";
				case 6:
					if (this.version.Minor == 5)
						return "SQL Server 6.5";
					break;
				case 7:
					return "SQL Server 7.0"; // editionType == SqlServerEditionType.Desktop ? "SQL Server Desktop Engine 1.0" : "SQL Server 7.0";
				case 8:
					return "SQL Server 2000"; // editionType == SqlServerEditionType.Desktop ? "SQL Server Desktop Engine 2000" : "SQL Server 2000";
				case 9:
					return "SQL Server 2005";
				case 10:
               if (this.version.Minor == 50)
                  return "SQL Server 2008 R2";
					return "SQL Server 2008";
                case 11:
                    return "SQL Server 2012";
                case 12:
                    return "SQL Server 2014";
                case 13:
                    return "SQL Server 2016";
                case 14:
                    return "SQL Server 2017";
                case 15:
                    return "SQL Server 2019";

            }
			return string.Format("SQL Server {0}", version);
		}

		private bool TryGetServiceLevelName(int build, int test, string baseName, out string realName)
		{
			if (test == build)
			{
				realName = baseName;
				return true;
			}
			else if (test > build)
			{
				realName = baseName + "+";
				return true;
			}

			realName = baseName;
			return false;
		}

		private string GetServiceLevel()
		{
			int build = this.Build;
			string serviceLevel = "UNSUPPORTED";

			switch (this.version.Major)
			{
				case 0:
					return "";
				case 6:
					if (this.version.Minor == 5)
					{
						if (TryGetServiceLevelName(479, build, "SP5a Update", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(416, build, "SP5a", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(415, build, "SP5", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(281, build, "SP4", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(258, build, "SP3", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(240, build, "SP2", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(213, build, "SP1", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(201, build, "RTM", out serviceLevel))
							return serviceLevel;

						return "PRE-RELEASE";
					}

					break;
				case 7:
					if (version.Minor == 0)
					{
						if (TryGetServiceLevelName(1063, build, "SP4", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(961, build, "SP3", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(842, build, "SP2", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(699, build, "SP1", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(623, build, "RTM", out serviceLevel))
							return serviceLevel;

						return "PRE-RELEASE";
					}

					break;
				case 8:
					if (version.Minor == 0)
					{
						if (TryGetServiceLevelName(2039, build, "SP4", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(760, build, "SP3", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(534, build, "SP2", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(384, build, "SP1", out serviceLevel))
							return serviceLevel;
						if (TryGetServiceLevelName(194, build, "RTM", out serviceLevel))
							return serviceLevel;

						return "PRE-RELEASE";
					}

					break;
				case 9:
					if (version.Minor == 0)
					{
                        if (TryGetServiceLevelName(5000, build, "SP4", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(4035, build, "SP3", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(3042, build, "SP2", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(2047, build, "SP1", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(1399, build, "RTM", out serviceLevel))
                            return serviceLevel;

						return "PRE-RELEASE";
					}
					break;
                case 10:
                     //SQL Server 2008
                    if (version.Minor == 0)
                    {
                        if (TryGetServiceLevelName(5500, build, "SP3", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(4000, build, "SP2", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(2531, build, "SP1", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(1600, build, "RTM", out serviceLevel))
                            return serviceLevel;
                        return "PRE-RELEASE";
                    }
                     //SQL Server 2008 R2
                    if (version.Minor == 50)
                    {
                        if (TryGetServiceLevelName(2500, build, "SP1", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(1600, build, "RTM", out serviceLevel))
                            return serviceLevel;
                        return "PRE-RELEASE";
                    }
                    break;
                case 11:
                    //SQL Server 2012
                    if (version.Minor == 0)
                    {
                        if (TryGetServiceLevelName(5058, build, "SP2", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(3000, build, "SP1", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(2100, build, "RTM", out serviceLevel))
                            return serviceLevel;
                        return "PRE-RELEASE";
                    }
                    break;
                case 12:
                    //SQL Server 2014
                    if (version.Minor == 0)
                    {
                        if (TryGetServiceLevelName(2000, build, "RTM", out serviceLevel))
                            return serviceLevel;
                        return "PRE-RELEASE";
                    }
                    break;
                case 13:
                    //SQL Server 2016
                    if (version.Minor == 0)
                    {
                        if (TryGetServiceLevelName(1601, build, "RTM", out serviceLevel))
                            return serviceLevel;
                        return "PRE-RELEASE";
                    }
                    break;
                case 14:
                    //SQL Server 2017
                    if (version.Minor == 0)
                    {
                        if (TryGetServiceLevelName(1601, build, "RTM-GDR", out serviceLevel))
                            return serviceLevel;
                        return "PRE-RELEASE";
                    }
                    break;
                case 15:
                    //SQL Server 2019
                    if (version.Minor == 0)
                    {
                        if (TryGetServiceLevelName(2000, build, "RTM", out serviceLevel))
                            return serviceLevel;
                        if (TryGetServiceLevelName(2070, build, "GDR1+RTM", out serviceLevel))
                            return serviceLevel;
                        return "PRE-RELEASE";
                    }
                    break;
            }

			return serviceLevel;
		}

		#endregion
	}
}
