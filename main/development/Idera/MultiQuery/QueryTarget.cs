using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.MultiQuery
{
   public class QueryTarget
   {
      #region Properties
      
      public bool           isServerGroup;
      public string         server;
      public string         database;
      public SQLCredentials credentials;

      #endregion
      
      #region CTOR
      
      public
         QueryTarget(
            string inServer
         )
      {
         isServerGroup = false;
         server        = inServer;
         database      = "";
         credentials   = null;
      }
      
      public
         QueryTarget(
            bool            inServerGroup,
            string          inServer,
            string          inDatabase,
            SQLCredentials  inCredentials
         )
      {
         isServerGroup = inServerGroup;
         server        = inServer;
         database      = inDatabase;
         credentials   = inCredentials;
      }
      
      #endregion
      
      #region Match Routines
      
      //-----------------------------------------------------------------------      
      // MatchServerDatabasePairing - Just checks server/database
      //-----------------------------------------------------------------------      
      public bool
         MatchServerDatabasePairing(
            QueryTarget queryTarget
         )
      {
         // ignore credentials for match
         return ( isServerGroup      == queryTarget.isServerGroup &&
                  server.ToUpper()   == queryTarget.server.ToUpper() &&
                  database.ToUpper() == queryTarget.database.ToUpper() );
      }

      //-----------------------------------------------------------------------      
      // Match - Entire structure matches exactly
      //-----------------------------------------------------------------------      
      public bool
         Match(
            QueryTarget queryTarget
         )
      {
         if ( isServerGroup != queryTarget.isServerGroup ||
              server        != queryTarget.server       ||
              database      != queryTarget.database )
         {
            return false;
         }
         
         if ( credentials == null && queryTarget.credentials == null )
         {
            // both null - they match
            return true;
         }
         else if ( credentials == null || queryTarget.credentials == null)
         {
            // there can only be one that is null since we already checked for both
            return false;
         }
         else if ( credentials.useSqlAuthentication != queryTarget.credentials.useSqlAuthentication )
         {
            // same type of authentication?
            return false;
         }
         else if ( credentials.useSqlAuthentication &&
                   ( credentials.loginName != queryTarget.credentials.loginName ||
                     credentials.password  != queryTarget.credentials.password   ) )
         {
            // since one is SQL then both are sql so check login and password
            return false;
         }

         // must match since we got here
         return true;
      }
      
      #endregion
      
      #region IO

        public static List<QueryTarget>
           ReadQueryTargetFile(
              string fileName
           )
        {
            if ( ! File.Exists( fileName ) )
            {
               return null;
            }
        
            List<QueryTarget> queryTargetList = new List<QueryTarget>();
            
            try
            {
               using (  XmlTextReader textReader = new XmlTextReader(fileName) )
               {
                  while (textReader.Read())
                  {
                     if ( textReader.NodeType == XmlNodeType.Element )
                     {
                        if ( textReader.Name == "QueryTarget" )
                        {
                           string isGroup           = textReader.GetAttribute("IsGroup");
                           string name              = textReader.GetAttribute("Name");
                           string database          = textReader.GetAttribute("Database");
                           string isSQL             = textReader.GetAttribute("Type");
                           string login    = "";
                           string password = "";
                           //if ( isSQL == "Yes" )
                           {
                              string encryptedLogin    = textReader.GetAttribute("Param1");
                              if ( ! String.IsNullOrEmpty(encryptedLogin) ) 
                                 login = EncryptionHelper.QuickDecrypt(encryptedLogin);
                              
                              string encryptedPassword = textReader.GetAttribute("Param2");
                              if ( ! String.IsNullOrEmpty(encryptedPassword) ) 
                                 password = EncryptionHelper.QuickDecrypt(encryptedPassword);
                           }
                           
                           SQLCredentials cred = new SQLCredentials(  isSQL=="Yes",login,password);
                           QueryTarget qt = new QueryTarget( isGroup == "Yes",
                                                             name,
                                                             database,
                                                             cred );
                           queryTargetList.Add(qt);
                        }
                     }
                  }
                  textReader.Close();
               }
            }
            catch ( Exception ex )
            {
                CoreGlobals.traceLog.ErrorFormat("Error reading query target list {0} : {1}", fileName, Helpers.GetCombinedExceptionText(ex));
                throw ex;
            }
            
            return queryTargetList;
        }
        
        static public void
           WriteQueryTarget(
              string                fileName
           )
        {
           try
           {
                using (XmlTextWriter textWriter = new XmlTextWriter(fileName, Encoding.UTF8))
                {
                    textWriter.WriteStartDocument();
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteStartElement("QueryTargets");
                    textWriter.WriteWhitespace("\r\n");

                    foreach (ListViewItem lvi in ProductConstants.mainform.listQueryTargets.Items)
                    {
                        QueryTarget queryTarget = (QueryTarget)lvi.Tag;
                        WriteQueryTargetXML(textWriter, queryTarget);
                        textWriter.WriteWhitespace("\r\n");
                    }

                    textWriter.WriteEndElement(); // QueryTargets
                    textWriter.WriteWhitespace("\r\n");
                    textWriter.WriteEndDocument();

                    textWriter.Close();
                }
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.ErrorFormat("Error writing query target list: {0} : {1}", fileName, Helpers.GetCombinedExceptionText(ex));
                throw ex;
            }
        }

        static private void
           WriteQueryTargetXML(
              XmlTextWriter textWriter,
              QueryTarget   queryTarget
           )
        {
            textWriter.WriteStartElement("QueryTarget");
            
            textWriter.WriteAttributeString("IsGroup",  queryTarget.isServerGroup ? "Yes" : "No");
            textWriter.WriteAttributeString("Name",     queryTarget.server);
            textWriter.WriteAttributeString("Database", queryTarget.database);
            if ( queryTarget.credentials != null )
            {
               textWriter.WriteAttributeString("Type",     queryTarget.credentials.useSqlAuthentication ? "Yes" : "No");
               if ( queryTarget.credentials !=null )
               {
                  string encryptedLogin    = "";
                  if ( ! String.IsNullOrEmpty(queryTarget.credentials.loginName) )
                     encryptedLogin = EncryptionHelper.QuickEncrypt(queryTarget.credentials.loginName);
                     
                  string encryptedPassword = "";
                  if ( ! String.IsNullOrEmpty(queryTarget.credentials.password) )
                     encryptedPassword = EncryptionHelper.QuickEncrypt(queryTarget.credentials.password);
                     
                  textWriter.WriteAttributeString("Param1",   encryptedLogin);
                  textWriter.WriteAttributeString("Param2",   encryptedPassword);
               }
               else
               {
                  // windows auth
                  textWriter.WriteAttributeString("Param1",   "");
                  textWriter.WriteAttributeString("Param2",   "");
               }
            }

            textWriter.WriteEndElement(); // Group
        }

        #endregion
   }
}
