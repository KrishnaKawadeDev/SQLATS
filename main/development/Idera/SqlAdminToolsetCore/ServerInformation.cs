using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.Core
{
    public class ServerInformation
    {
        #region variables
        private string         _Name;
        private SQLCredentials _sqlCredentials;
        private object         _Tag;
        #endregion

        #region .ctor
        /// <summary>
        /// Initializes a new intance of ServerInformation.
        /// </summary>
        public ServerInformation(string name)
        {
            _Name = name;
        }

        /// <summary>
        /// Initializes a new intance of ServerInformation with SQL Authentication enabled.
        /// </summary>
        public ServerInformation(string name, string loginName, string password)
        {
           _sqlCredentials = new SQLCredentials( true, loginName, password );
           _Name = name;
        }

        /// <summary>
        /// Initializes a new intance of ServerInformation with SQL Credentials
        /// </summary>
        public ServerInformation( string name, SQLCredentials inSqlCredentials )
        {
           _sqlCredentials = inSqlCredentials;
           _Name = name;
        }

        #endregion

        #region accessors
        /// <summary>
        /// Server Name
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

       /// <summary>
        /// Server Name without port specification
        /// </summary>
        public string ActualName
        {
           get
           {
              if (_Name.Contains(","))
              {
                 return _Name.Substring(0, _Name.IndexOf(","));
              }
              else
              {
                 return _Name;
              }
           }
        }

        /// <summary>
        /// SQL Credentials
        /// </summary>
        public SQLCredentials SqlCredentials
        {
           get
           {
              return _sqlCredentials;
           }
           set
           {
              _sqlCredentials = value;
           }
        }


        /// <summary>
        /// True if SQL Authentication should be used, otherwise false.
        /// </summary>
        public bool UseSqlAuthentication
        {
            get
            {
               return (_sqlCredentials == null) ? false : _sqlCredentials.useSqlAuthentication;
            }
            set
            {
               if ( _sqlCredentials == null )
                  _sqlCredentials = new SQLCredentials();

               _sqlCredentials.useSqlAuthentication = value;
            }
        }

        /// <summary>
        /// Login Name to be used with SQL Authentication.
        /// </summary>
        public string LoginName
        {
            get
            {
               return (_sqlCredentials==null) ? null : _sqlCredentials.loginName;
            }
            set
            {
               if ( _sqlCredentials == null )
                  _sqlCredentials = new SQLCredentials();

               _sqlCredentials.loginName = value;
            }
        }

        /// <summary>
        /// Password to be used with SQL Authentication.
        /// </summary>
        public string Password
        {
            get
            {
               return (_sqlCredentials == null) ? null : _sqlCredentials.password;
            }
            set
            {
               if ( _sqlCredentials == null )
                  _sqlCredentials = new SQLCredentials();

               _sqlCredentials.password = value;
            }
        }
        
        /// <summary>
        /// Tag
        /// </summary>
        public Object Tag
        {
           get
           {
              return _Tag;
           }
           set
           {
              _Tag = value;
           }
        }
        
        #endregion

        public override string ToString()
        {
           return string.Format( "{0} ({1})",
                                 String.IsNullOrEmpty(_Name) ? string.Empty : _Name,
                                 (_sqlCredentials == null || _sqlCredentials.useWindowsAuthentication) ? 
                                       "Integrated Security" :
                                       "SQL Authentication");
        }
    }
}
