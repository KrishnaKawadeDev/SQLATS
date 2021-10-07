using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Idera.SqlAdminToolset.Core
{
   public class SQLCredentials
   {
      //-------------
      // Contructors
      //-------------
      public SQLCredentials()
      {
         useSqlAuthentication = false;
         loginName            = null;
         password             = null;
      }

      public SQLCredentials( bool inSqlAuthentication)
      {
         useSqlAuthentication = inSqlAuthentication;
         loginName = null;
         password = null;
      }

      public SQLCredentials( bool inSqlAuthentication, string inLoginName, string inPassword )
      {
         useSqlAuthentication = inSqlAuthentication;
         loginName            = inLoginName;
         password             = inPassword;
      }

      public SQLCredentials( SQLCredentials inSqlCredentials )
      {
         useSqlAuthentication = inSqlCredentials.useSqlAuthentication;
         loginName            = inSqlCredentials.loginName;
         password             = inSqlCredentials.password;
      }

       public SQLCredentials(string connectionString)
       {
           SqlConnectionStringBuilder _Builder = new SqlConnectionStringBuilder(connectionString);
           useSqlAuthentication = !_Builder.IntegratedSecurity;
           loginName = _Builder.UserID;
           password = _Builder.Password;
       }

      //------------
      // Properties
      //------------
      public bool   useSqlAuthentication;
      public string loginName;
      public string password;

      public bool useWindowsAuthentication
      {
         get { return ( !useSqlAuthentication ); }
         set { useSqlAuthentication = !value; }
      }

      //-------------------------------------------------------------------
      // GetCredentialsString
      //-------------------------------------------------------------------
      static public string
         GetCredentialsString( SQLCredentials sqlCredentials )
      {
         string credentialsString;

         if ( sqlCredentials == null || sqlCredentials.useWindowsAuthentication )
         {
            credentialsString = "Integrated Security=SSPI";
         }
         else
         {
            credentialsString = String.Format( "User ID={0};Password={1}",
                                               CreateDoubleQuotedString(sqlCredentials.loginName),
                                               CreateDoubleQuotedString(sqlCredentials.password) );
         }

         return credentialsString;
      }

       static private string CreateDoubleQuotedString(string propName)
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

   }
}
