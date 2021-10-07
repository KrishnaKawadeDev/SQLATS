using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Security;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

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
        public SQLCredentials(bool inSqlAuthentication, string inLoginName, string inPassword,string inSearchPattern)
        {
            useSqlAuthentication = inSqlAuthentication;
            loginName = inLoginName;
            password = inPassword;
            searchPattern =inSearchPattern;
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
           if (!String.IsNullOrEmpty(_Builder.Password))
           {
               _Builder.Password = DecryptSecurePassword(_Builder.Password);
           }

           useSqlAuthentication = !_Builder.IntegratedSecurity;
           loginName = _Builder.UserID;
           password = _Builder.Password;
       }

       /// <summary>
       /// Decrypts a secure password from the registered servers.
       /// </summary>
       internal string DecryptSecurePassword(string password)
       {
           byte[] userData = Convert.FromBase64String(password);
           
           int _Index = 0;
           bool _Decrypted = false;
           byte[] inArray = null;
           while ((_Index < 10) && !_Decrypted)
           {
               try
               {
                   inArray = ProtectedData.Unprotect(userData, null, DataProtectionScope.LocalMachine);
                   _Decrypted = true;
               }
               catch (CryptographicException)
               {
                   if (_Index == 9)
                   {
                       throw;
                   }
               }
               catch (OutOfMemoryException)
               {
                   if (_Index == 9)
                   {
                       throw;
                   }
               }
               _Index++;
           }
           if (inArray == null)
           {
               return string.Empty;
           }
           return Encoding.Unicode.GetString(inArray);
       }



      //------------
      // Properties
      //------------
      public bool   useSqlAuthentication;
      public string loginName;
      public string password;
        public string searchPattern = string.Empty;

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
