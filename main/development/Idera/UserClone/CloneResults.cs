using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.UserClone
{
    internal class CloneResults
    {
        string _Script = string.Empty;
        UserCloneStatus _userClone;
        public static List<string> _listScript = new List<string>();
        public static List<UserCloneStatus> _userCloneList = new List<UserCloneStatus>();
        bool _IsRequestSuccessful = true;
        Dictionary<string, string> _InaccessibleDatabases = new Dictionary<string, string>();
        Exception _CloningException = null;

        /// <summary>
        /// Cloning script.
        /// </summary>
        public string Script
        {
            get { return _Script; }
            set { _Script = value; }
        }

        /// <summary>
        /// User Clone Name.
        /// </summary>
        public UserCloneStatus UserCloneName
        {
            get { return _userClone; }
            set { _userClone = value; }
        }

        /// <summary>
        /// Cloning list script.
        /// </summary>
        public List<string> ListScript
        {
            get { return _listScript; }
            set { _listScript.Add(_Script); }
        }

        /// <summary>
        /// Already exist user list on destination server.
        /// </summary>
        public List<UserCloneStatus> UserCloneList
        {
            get { return _userCloneList; }
            set { _userCloneList.Add(_userClone); }
        }

        /// <summary>
        /// True if the request was completed successfully, otherwise false.
        /// </summary>
        public bool IsRequestSuccessful
        {
            get { return _IsRequestSuccessful; }
            set { _IsRequestSuccessful = value; }
        }

        /// <summary>
        /// List of inaccessible source databases.  Database name and reason.
        /// </summary>
        public Dictionary<string, string> InaccessibleDatabases
        {
            get { return _InaccessibleDatabases; }
        }

        /// <summary>
        /// Exception raised during cloning operations.  Null if no exception found.
        /// </summary>
        public Exception CloningException
        {
            get { return _CloningException; }
            set
            {
                _IsRequestSuccessful = false;
                _CloningException = value;
            }
        }
    }


    internal class UserCloneStatus
    {
       public string userName { get; set; }
       public bool cloneStatus { get; set; }
    }
}
