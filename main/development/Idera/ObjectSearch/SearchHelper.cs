using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ObjectSearch
{
    public class SearchHelper
    {
       public delegate void ShowInformationDelegate(string msg);
       public delegate DialogResult ShowConfirmationDelegate(string msg);

       public  static string           m_server;
       public  static SQLCredentials   m_credentials;
       
       public  static string           m_databaseString;
       public  static string           m_searchString;
       public  static bool             m_caseSensitiveSearch;
       public  static bool             m_excludeSystemObjects;
       public  static int              m_searchLimit;
       public  static bool             m_allowWildcards;
       public  static ShowInformationDelegate m_ShowInfomationDelegate = null;
        public static ShowConfirmationDelegate m_ShowConfirmationDelegate = null;
       
       public static string []         m_databaseList;
        private static object threadLock = new object();

        public static bool
         PerformSearch(
            ServerInformation serverInformation,
            int               commandTimeout,
            JobPoolOptions    options            
          )
      {
            lock (threadLock)
            {
                Debug.Write("Enter PerformSearch" + serverInformation.Name);

                // Set Database List
                if (String.IsNullOrEmpty(m_databaseString))
                    m_databaseList = null;
                else
                    m_databaseList = m_databaseString.Split(';');

                try
                {
                    int sqlVersion = 9;

                    // connect to server
                    using (SqlConnection conn = Connection.OpenConnection(serverInformation.Name,
                                                                            serverInformation.SqlCredentials))
                    {
                        sqlVersion = SQLHelpers.GetSqlVersion(conn);
                        conn.Close();
                    }

                    if (sqlVersion > 8) // 2005 or greater
                    {
                        SearchSql2005 search = new SearchSql2005(serverInformation.Name,
                                                                  serverInformation.SqlCredentials,
                                                                  m_databaseList,
                                                                  m_searchString,
                                                                  m_caseSensitiveSearch,
                                                                  m_excludeSystemObjects,
                                                                  m_allowWildcards,
                                                                  m_ShowInfomationDelegate,
                                                                  m_ShowConfirmationDelegate);
                        search.PerformSearch();
                    }
                    else //if (sqlVersion == 8) // 2000
                    {
                        SearchSql2000 search = new SearchSql2000(serverInformation.Name,
                                                                  serverInformation.SqlCredentials,
                                                                  m_databaseList,
                                                                  m_searchString,
                                                                  m_caseSensitiveSearch,
                                                                  m_excludeSystemObjects,
                                                                  m_allowWildcards,
                                                                  m_ShowInfomationDelegate,
                                                                  m_ShowConfirmationDelegate);
                        search.PerformSearch();
                    }
                    //else  // version prior to 2000
                    //{
                    //   throw new Exception ("Object Search only supports SQL Server 2000 and higher." );
                    //}
                }
                catch (Exception ex)
                {
                    if (!ex.Message.Contains("being aborted"))
                    {
                        CoreGlobals.traceLog.ErrorFormat("Perform Search  - Error in {0} - {1}", serverInformation.Name, ex.Message);
                        throw ex;
                    }
                }

                Debug.Write("Leaving PerformSearch" + serverInformation.Name);
            }
            return true;
        }
        
        #region Icon Enum
        
        public enum IconType
        {
           Unknown          = 0,
           Database         = 1,
           Table            = 2,
           Column           = 3,
           Index            = 4,
           View             = 5,
           Trigger          = 6,
           Constraint       = 7,
           StoredProcedure  = 8,
           Function         = 8,
           Log              = 9,
           WindowsUser      = 10,
           SqlUser          = 10,
           WindowsGroup      = 11,
           Role             = 11,
           Job              = 12
        }

        #endregion
         
        #region Database Matching
        
        public static bool 
           IsDatabaseInDatabaseList(
              string    database,
              string[]  databaseList
           )
        {
           if ( databaseList == null ) return true;
           
           bool found = false;
           for (int i=0; i<databaseList.Length; i++ )
           {
              if ( database.ToUpper() == databaseList[i].ToUpper() )
              {
                 found = true;
                 break;
              }
           }
           return found;
        }
        
        #endregion
   }
   
   class SearchTypeDesc
   {
      public string                 type;
      public string                 displayString;
      public SearchHelper.IconType  icon;
      
      public SearchTypeDesc(
            string inType, 
            string inDisplayString, 
            SearchHelper.IconType inIcon
         )
      {
         type          = inType;
         displayString = inDisplayString;
         icon          = inIcon;
      }
   }
}
