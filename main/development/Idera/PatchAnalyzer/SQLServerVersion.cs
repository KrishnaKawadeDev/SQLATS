using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Globalization;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PatchAnalyzer
{
   class SQLServerVersion
   {
        #region Properties
        
        public string Product;
        public string Level;
        public string Supported;
        public string SupportStatus;
        public string UrlType;
        public string Url;
        public string KbTitle;

        private string m_version;
        public string Version
        {
           get { return m_version; }
           set
           {
              if ( value == null )
                 m_version = "";
              else
                 m_version = value;
                 
              SplitVersion();
           }
        }

        private int m_major = 0;
        private int m_minor;
        private int m_build;
        public int Major
        {
           get { return m_major; }
        }
        public int Minor
        {
           get { return m_minor; }
        }
        public int Build
        {
           get { return m_build; }
        }
        
        #endregion
        
        #region CTOR


        //---------------------------------------------------------------------------        
        // Constructors
        //---------------------------------------------------------------------------        
        public
           SQLServerVersion()
        {
           Version       = "";
           Level         = "";
           Supported     = "";
           SupportStatus = "";
           KbTitle       = "";
           Url           = "";
           UrlType       = "";
           
           Product       = "";
        }   


        public
           SQLServerVersion(
              string inVersion,
              string inLevel,
              string inSupported,
              string inSupportStatus ,
              string inUrlType,
              string inUrl,
              string inKbTitle,
              string product
           )
        {
           Level         = inLevel;
           Supported     = inSupported;
           SupportStatus = inSupportStatus;
           UrlType       = inUrlType;
           Url           = inUrl;
           KbTitle       = inKbTitle;
           
           Version = inVersion;
            Product = product;
           //switch ( m_major )
           //{
           //   case 6:
           //      Product = "SQL Server 6.5";
           //      break;
           //   case 7:
           //      Product = "SQL Server 7.0";
           //      break;
           //   case 8:
           //      Product = "SQL Server 2000";
           //      break;
           //   case 9:
           //      Product = "SQL Server 2005";
           //      break;
           //   case 10:
           //      {
           //         if (m_minor == 50)
           //            Product = "SQL Server 2008 R2";
           //         else
           //            Product = "SQL Server 2008";
           //         break;
           //      }
           //  case 11:
           //      Product = "SQL Server 2012";
           //      break;
           //  case 12:
           //      Product = "SQL Server 2014";
           //      break;

           //   default:
           //      Product = "Unknown Version";
           //      break;
           //}
           
        }   
        
        private SQLServerVersion Clone()
        {
           SQLServerVersion sqlServerVersion = new SQLServerVersion( Version,
                                                                     Level,
                                                                     Supported,
                                                                     SupportStatus,
                                                                     UrlType,
                                                                     Url,
                                                                     KbTitle ,Product);
           return sqlServerVersion;                                                    
        }
        
        //---------------------------------------------------------------------------        
        // SplitVersion
        //---------------------------------------------------------------------------        
        private void SplitVersion()
        {
           m_major = m_minor = m_build = 0;
           
           string [] pieces = Version.Split( '.' );
           if ( pieces.Length > 0 ) m_major = Convert.ToInt32(pieces[0]);
           if ( pieces.Length > 1 ) m_minor = Convert.ToInt32(pieces[1]);
           if ( pieces.Length > 2 ) m_build = Convert.ToInt32(pieces[2]);
        }
        
        #endregion
        
        #region Static Stuff
        
        
        //---------------------------------------------------------------------------        
        // GetSqlVersion
        //---------------------------------------------------------------------------        
        public static SQLServerVersion
           GetSqlVersion(
              int  matchingIndex
           )
        {
           SQLServerVersion returnVal   = null;
           
           if ( matchingIndex >= 0 && matchingIndex < SqlServerVersionList.Count )
           {
              returnVal = SqlServerVersionList[matchingIndex];
           }
           
           return returnVal;
        }
        
        //---------------------------------------------------------------------------        
        // GetMatchingVersion
        //---------------------------------------------------------------------------        
        public static SQLServerVersion
           GetMatchingVersion(
              Version  sqlVersion,
              out int  matchingIndex
           )
        {
           int i;
           bool             usePrevious = false;
           bool             useThisOne  = false;
           SQLServerVersion returnVal   = null;
           
           matchingIndex = -1;
            if (SqlServerVersionList.Count > 0)
            {
                // loop until we hit one bigger - use last entry
                for (i = 0; i < SqlServerVersionList.Count; i++)
                {
                    if (sqlVersion.Major == SqlServerVersionList[i].Major)
                    {
                        if (sqlVersion.Minor == SqlServerVersionList[i].Minor)
                        {
                            if (SqlServerVersionList[i].Build > sqlVersion.Build)
                            {
                                usePrevious = true;
                            }
                            else if (SqlServerVersionList[i].Build == sqlVersion.Build)
                            {
                                useThisOne = true;
                            }
                        }
                        else
                        {
                            if (SqlServerVersionList[i].Minor > sqlVersion.Minor)
                            {
                                usePrevious = true;
                            }
                        }
                    }
                    else
                    {
                        if (SqlServerVersionList[i].Major > sqlVersion.Major)
                        {
                            usePrevious = true;
                        }
                    }

                    if (useThisOne)
                    {
                        matchingIndex = i;
                        returnVal = SqlServerVersionList[i];
                        break;
                    }

                    if (usePrevious || i == SqlServerVersionList.Count - 1)
                    {
                        if (i == 0)
                        {
                            matchingIndex = -1;

                            // version older then 6.5 RTM
                            SQLVersion ver = SQLVersion.FromVersion(sqlVersion);

                            returnVal = new SQLServerVersion(String.Format("{0}.{1:00}.{2:0000}",
                                                                             sqlVersion.Major,
                                                                             sqlVersion.Minor,
                                                                             sqlVersion.Build),
                                                              "",
                                                              "N/A",
                                                              "",
                                                              "0",
                                                              "",
                                                              "", "");
                        }
                        else
                        {
                            if (sqlVersion.Major == SqlServerVersionList[i - 1].Major)
                            {
                                matchingIndex = i - 1;
                                i = i - 1;
                                returnVal = SqlServerVersionList[i - 1];
                            }
                            else
                            {
                                matchingIndex = i;
                                returnVal = SqlServerVersionList[i];
                            }
                            if (sqlVersion.Major == SqlServerVersionList[i].Major)
                            {
                                if (!returnVal.Level.Contains("hotfix"))
                                    returnVal.Level += " + hotfix";
                            }

                            // url
                            if (returnVal.UrlType == "0")
                            {
                                //returnVal.UrlType = "2"; // signals to say "Maybe" in KB available column
                                // since we are going to search for build number
                                //returnVal.Url = String.Format( "Search:{0}.{1:0}.{2:0000}",   
                                //                               sqlVersion.Major,
                                //                               sqlVersion.Minor,
                                //                               sqlVersion.Build );
                                returnVal.Url = "NONE";
                            }
                        }

                        break;
                    }
                }

                if (returnVal == null)
                {
                    CoreGlobals.traceLog.VerboseFormat("SQL Server Version List.Count - {0}", SqlServerVersionList.Count);

                    if (i == SqlServerVersionList.Count) i--;
                    matchingIndex = i;
                    returnVal = SqlServerVersionList[i];
                }

                return returnVal;
            }
            return null;
        }
        
        //---------------------------------------------------------------------------        
        // GetAvailableUpdateType
        //---------------------------------------------------------------------------        
        public enum AvailableUpdateType
        {
           None,
           Hotfixes,
           ServicePack,
           HotfixesAndServicePacks
        }
        
        public static string
           GetAvailableUpdateTypeAsString(
              int  index
           )
        {
           AvailableUpdateType availableUpdateType = GetAvailableUpdateType( index );
        
           string returnValue = "Unknown";
           switch ( availableUpdateType ) 
           {
              case AvailableUpdateType.None:
                 returnValue = "None";
                 break;
              case AvailableUpdateType.Hotfixes:
                 returnValue = "Hotfixes";
                 break;
              case AvailableUpdateType.ServicePack:
                 returnValue = "Service Pack";
                 break;
              case AvailableUpdateType.HotfixesAndServicePacks:
                 returnValue = "Hotfixes and SPs";
                 break;
           }
           
           return returnValue;
        }
        
        public static AvailableUpdateType
           GetAvailableUpdateType(
              int  index
           )
        {
           AvailableUpdateType availableUpdateType = AvailableUpdateType.None;
           

           for ( int i=index+1; i< SqlServerVersionList.Count; i++ )
           {
              if ( AreBuildsSameServicePack(index, i ) )
              {
                 availableUpdateType = AvailableUpdateType.Hotfixes;
              }
              else if ( AreBuildsSameVersion(index, i ) )
              {
                 if ( availableUpdateType == AvailableUpdateType.Hotfixes )
                 {
                    availableUpdateType = AvailableUpdateType.HotfixesAndServicePacks;
                 }
                 else
                 {
                    availableUpdateType = AvailableUpdateType.ServicePack;
                 }
                 break;
              }
              else
              {
                 break;
              }
           }
           
           return availableUpdateType;
        }
        
        //---------------------------------------------------------------------------        
        // AreUpdatesAvailable
        //---------------------------------------------------------------------------        
        public static bool
           AreUpdatesAvailable(
              int  index
           )
        {
           bool AvailableUpdates = false;
           
           if ( index+1 == SqlServerVersionList.Count )
              return false;
              
           // compare index to index + 1
           if ( AreBuildsSameVersion(index, index+1) )
              AvailableUpdates = true;
           
           return AvailableUpdates;
        }
        
        //---------------------------------------------------------------------------        
        // AreBuildsSameVersion
        //---------------------------------------------------------------------------        
        public static bool
           AreBuildsSameVersion(
              int index1,
              int index2
           )
        {
           bool sameVersion = false;
           
           if (index1>0&& ( SqlServerVersionList[index1].m_major == SqlServerVersionList[index2].m_major ) && 
                ( SqlServerVersionList[index1].m_minor == SqlServerVersionList[index2].m_minor ) )
           {
              sameVersion = true;
           }
           
           return sameVersion;
        }
        
        //---------------------------------------------------------------------------        
        // AreBuildsSameServicePack
        //---------------------------------------------------------------------------        
        public static bool
           AreBuildsSameServicePack(
              int index1,
              int index2
           )
        {
           bool sameServicePack = false;
           
           if (index1>0 && ( SqlServerVersionList[index1].m_major == SqlServerVersionList[index2].m_major ) && 
                ( SqlServerVersionList[index1].m_minor == SqlServerVersionList[index2].m_minor ) &&
                ( SqlServerVersionList[index1].Level.Substring(0,3) == SqlServerVersionList[index2].Level.Substring(0,3) ) )
           {
              sameServicePack = true;
           }
           
           return sameServicePack;
        }
        
        
        //---------------------------------------------------------------------------        
        // GetAvailableUpdates
        //---------------------------------------------------------------------------        
        public static List<SQLServerVersion>
           GetAvailableUpdates(
              int  matchingIndex
           )
        {
           List<SQLServerVersion> AvailableUpdates = new List<SQLServerVersion>();
           
           for ( int i=matchingIndex+1; i< SqlServerVersionList.Count; i++ )
           {
              if ( AreBuildsSameVersion(matchingIndex, i ) )
              {
                 AvailableUpdates.Add( SqlServerVersionList[i] );
              }
              else
              {
                 // we are past the current version or service pack
                 break;
              }
           }
           
           return AvailableUpdates;
        }
        
        #endregion SQL Patch File Handling

        #region SQL Patch File Handling

        public static DateTime               SqlServerVersionDate = DateTime.MinValue;
        public static List<SQLServerVersion> SqlServerVersionList = new List<SQLServerVersion>();
        
        //---------------------------------------------------------------------------        
        // GetPatchFilePath
        //---------------------------------------------------------------------------        
        public static string
           GetPatchFilePath()
        {
           bool eatOutputVariable;
           return GetPatchFilePath(out eatOutputVariable );
        }
        
        public static string
           GetPatchFilePath(
              out bool usingOverrideFile
           )
        {
            string   returnPath;
            
            string   overridePath;
            DateTime overrideFileDate;
            string   defaultPath;
            DateTime defaultFileDate;
           
            // Look for overrider patch file
            string productDir   = Helpers.GetProductDirectory( true );
            string overrideFile = Path.Combine( productDir, ProductConstants.SQLServerVersionFile );
            if ( File.Exists( overrideFile ) )
            {
               overridePath = overrideFile;
               overrideFileDate = GetSqlPatchFileDate( overridePath );
            }
            else
            {
               overridePath = "";
               overrideFileDate = DateTime.MinValue;
            }
            
            CoreGlobals.traceLog.DebugFormat( "GetPatchFilePath: Directory {0} Override File: {1}",
               productDir,
               overrideFile );
            
            // use default patch file in application directory
            defaultPath     = Helpers.GetProductDirectory( true ); //Path.GetDirectoryName(Application.ExecutablePath);
            defaultPath     = Path.Combine( defaultPath, ProductConstants.SQLServerDefaultVersionFile );
             defaultFileDate = GetSqlPatchFileDate( defaultPath );
            
            if ( DateTime.Compare( defaultFileDate, overrideFileDate ) >= 0 )
            {
               // default file is newer (or they match)
               returnPath     = defaultPath;
               usingOverrideFile = false;
            }
            else
            {
               // override file is newer
               returnPath     = overridePath;
               usingOverrideFile = true;
            }
            
            CoreGlobals.traceLog.DebugFormat( "GetPatchFilePath: Default {0} Return: {1} Using Override: {2}",
               defaultPath,
               returnPath,
               usingOverrideFile );
            
            return returnPath;
        }
        
        //---------------------------------------------------------------------------        
        // GetTempPatchFilePath
        //---------------------------------------------------------------------------        
        public static string
           GetTempPatchFilePath()
        {
            string tempFile;
           
            // Look for overrider patch file
            string productDir = Helpers.GetProductDirectory( true );
            tempFile   = Path.Combine( productDir, ProductConstants.TempSQLServerVersionFile );
            
            return tempFile;
        }

        //---------------------------------------------------------------------------        
        // LoadSqlPatchFile
        //---------------------------------------------------------------------------        
        public static DateTime
           LoadSqlPatchFile(
              string versionFileName
           )
        {
            try
            {
               CoreGlobals.traceLog.VerboseFormat( "Build List File {0}", versionFileName );
               
               SqlServerVersionList.Clear();
            
               using ( XmlTextReader textReader = new XmlTextReader(versionFileName) )
               {
                  while (textReader.Read())
                  {
                     if ( textReader.NodeType == XmlNodeType.Element )
                     {
                        if ( textReader.Name == "PatchFile" )
                        {
                           string pfv = textReader.GetAttribute(0);
                           //SqlServerVersionDate = Convert.ToDateTime(pfv);
                           CultureInfo cultureInfo =new CultureInfo("en-US");
                           SqlServerVersionDate = DateTime.Parse(pfv,cultureInfo);
                           
                          CoreGlobals.traceLog.VerboseFormat( "Build List Date {0}", SqlServerVersionDate );
                        }
                        else if ( textReader.Name == "Version" )
                        {
                           string build     = textReader.GetAttribute("Build");
                           string level     = textReader.GetAttribute("Level");
                           string supported = textReader.GetAttribute("Supported");
                           string status    = textReader.GetAttribute("Status");
                           string urlType   = textReader.GetAttribute("UrlType");
                           string url       = textReader.GetAttribute("Url");
                           string kbTitle   = textReader.GetAttribute("Title");
                           string product = textReader.GetAttribute("VersionName");
                           SQLServerVersion ver = new SQLServerVersion( build,
                                                                        level,
                                                                        supported,
                                                                        status,
                                                                        urlType,
                                                                        url,
                                                                        kbTitle,
                                                                        product);
                           SqlServerVersionList.Add( ver );                                                                        
                        }
                     }
                  }
                  textReader.Close();
               }
               CoreGlobals.traceLog.VerboseFormat( "Build List Record Count {0}", SqlServerVersionList.Count );
            }
            catch ( Exception ex )
            {
               SqlServerVersionDate = DateTime.MinValue;
               Messaging.ShowException( "Error reading Build List file.", ex );
               CoreGlobals.traceLog.VerboseFormat( "Error Reading List File {0}", ex.Message );
            }
            return SqlServerVersionDate;
        }
        
        //---------------------------------------------------------------------------        
        // GetSqlPatchFileDate
        //---------------------------------------------------------------------------        
        public static DateTime
           GetSqlPatchFileDate(
              string versionFileName
           )
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            DateTime fileVersion = DateTime.MinValue;

            try
            {
               using ( XmlTextReader textReader = new XmlTextReader(versionFileName) )
               {
                  while ((fileVersion == DateTime.MinValue) && textReader.Read())
                  {
                     if ( textReader.NodeType == XmlNodeType.Element
                          && textReader.Name == "PatchFile" )
                     {
                        string pfv = textReader.GetAttribute(0);
                        
                        CultureInfo cultureInfo =new CultureInfo("en-US");
                        fileVersion = DateTime.Parse(pfv,cultureInfo);
                        //fileVersion = Convert.ToDateTime(pfv);
                     }
                  }
                  textReader.Close();
               }
            }
            catch ( Exception ex )
            {
               fileVersion = DateTime.MinValue;
               throw ex;
            }
            return fileVersion;
        }
        
        #endregion
        
        #region Check for new file and optionally download
        
        //-----------------------------------------------------------------------
        // CheckForNewFile
        //-----------------------------------------------------------------------
        public static bool
           CheckForNewFile()
        {
           bool buildListUpdated = false;
           
         // Get current date
         DateTime currentDate = SQLServerVersion.GetSqlPatchFileDate( ProductConstants.SQLServerVersionFullPath);
         
         DateTime newDate = DateTime.MinValue;
         string tempFile = SQLServerVersion.GetTempPatchFilePath();
         
            try
            {
               
               // Download to temp
               using ( WebClient Client = new WebClient() )
               {
                  Client.DownloadFile(ProductConstants.BuildListURL, tempFile);
               }
               
               // check version of temp
               newDate = SQLServerVersion.GetSqlPatchFileDate( tempFile );
            }
            catch ( Exception ex )
            {
               Form_DownloadError frm = new Form_DownloadError( ex.Message );
               frm.ShowDialog();
               
               return false;
            }
            
            int delta = DateTime.Compare( currentDate, newDate );
            if ( delta == -1 )
            {
                  string overridePath = Path.GetDirectoryName( tempFile );
                  overridePath = Path.Combine( overridePath, ProductConstants.SQLServerVersionFile );
                  if ( File.Exists(overridePath) )
                  {
                     try { File.Delete( overridePath ); } catch {} // just in case 
                  }
                  
                  try
                  {
                     File.Move( tempFile, overridePath );
                  
                     Messaging.ShowInformation( String.Format( "A new Build List dated {0} was available and has been downloaded to your computer.",
                                                               newDate.ToShortDateString() ) );
                     buildListUpdated = true;
                  }
                  catch (Exception ex2 )
                  {
                     Messaging.ShowError( String.Format( "Unable to copy the new build list dated {0}.\r\n\r\nError: {1}",
                                                               newDate.ToShortDateString(),
                                                               ex2.Message ) );
                  }
            }
            else
            {
               Messaging.ShowInformation( "You are already using the latest version of the Build List.", "Check Build List" );
            }
            
            // delete temporary file
            try { File.Delete( tempFile ); }catch {}

            
            return buildListUpdated;
        }
        
        #endregion
    }
}
