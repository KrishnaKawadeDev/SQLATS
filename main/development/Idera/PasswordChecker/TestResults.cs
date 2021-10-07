using System;
using System.Collections.Generic;

namespace Idera.SqlAdminToolset.PasswordChecker
{
    /// <summary>
    /// Password checker test results.
    /// </summary>
    internal class TestResults
    {
        string _ServerName = string.Empty;
        List<LoginResults> _LoginResultsList = new List<LoginResults>();
        string _ErrorMessage = string.Empty;

        /// <summary>
        /// Initializes a new instance of TestResults.
        /// </summary>
        /// <param name="serverName"></param>
        public TestResults(string serverName)
        {
            _ServerName = serverName;
        }

        /// <summary>
        /// Server Name.
        /// </summary>
        public string ServerName
        {
            get { return _ServerName; }
            set { _ServerName = value; }
        }

        /// <summary>
        /// ErrorMessage - used to display connection failure problems
        /// </summary>
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }
        /// <summary>
        /// Results list that are part of the requested test.
        /// </summary>
        public List<LoginResults> LoginResultsList
        {
            get { return _LoginResultsList; }
        }

        /// <summary>
        /// Users that failed.
        /// </summary>
        public List<LoginResults> FailedUsers
        {
            get { return _LoginResultsList.FindAll(delegate(LoginResults results) { return results.IsLoginSuccessful; }); }
        }

        /// <summary>
        /// Number of users that failed testing.
        /// </summary>
        public int FailureLoginCount
        {
            get { return FailedUsers.Count; }
        }

        /// <summary>
        /// Number of users tested.
        /// </summary>
        public int TestedLoginCount
        {
            get { return _LoginResultsList.Count; }
        }

        /// <summary>
        /// Number of users skiped for some reason
        /// </summary>
        //private int _skippedLoginCount = 0;
        public int SkippedLoginCount
        {
            get
            {
                int skipped = 0;
                if (LoginResultsList != null)
                {
                    foreach (LoginResults lr in LoginResultsList)
                    {
                        if (lr.IsLoginSkipped) skipped++;
                    }
                }

                return skipped;
            }
        }

        /// <summary>
        /// Number of users not skipped and actually tested
        /// </summary>
        //private int _actuallyTestedCount = 0;
        public int ActuallyTestedCount
        {
            get
            {
                int tested = 0;
                if (LoginResultsList != null)
                {
                    foreach (LoginResults lr in LoginResultsList)
                    {
                        if (!lr.IsLoginSkipped) tested++;
                    }
                }

                return tested;
            }
        }

        /// <summary>
        /// True if the test passed, otherwise false.
        /// </summary>
        public bool PassedTest
        {
            get { return FailureLoginCount == 0; }
        }

        /// <summary>
        /// Total number of connections attempted across all logins tested.
        /// </summary>
        public int ConnectionAttemptCount
        {
            get
            {
                int _ConnectionAttempts = 0;
                _LoginResultsList.ForEach(delegate(LoginResults loginResults) { _ConnectionAttempts += loginResults.PasswordAttempts; });
                return _ConnectionAttempts;
            }
        }

        /// <summary>
        /// Number of test results with a blank password.
        /// </summary>
        public int BlankPasswordCount
        {
            get
            {
                int _BlankPasswords = 0;
                _LoginResultsList.ForEach(delegate(LoginResults loginResults) { if (loginResults.IsLoginSuccessful && loginResults.SuccessfulPassword == string.Empty) { _BlankPasswords++; } });
                return _BlankPasswords;
            }
        }

        /// <summary>
        /// Number of test results with the password the same as the login.
        /// </summary>
        public int PasswordSameAsLoginCount
        {
            get
            {
                int _SameAsLoginCount = 0;
                _LoginResultsList.ForEach(delegate(LoginResults loginResults) { if (loginResults.IsLoginSuccessful && loginResults.SuccessfulPassword == loginResults.UserName) { _SameAsLoginCount++; } });
                return _SameAsLoginCount;
            }
        }
    }

    /// <summary>
    /// Login results for specified user.
    /// </summary>
    internal class LoginResults : EventArgs
    {
        private string _UserName;
        private string _Password;
        private int _PasswordAttempts;
        private LoginSkippedType _WhySkipped = LoginSkippedType.NotSkipped;

        //      List<PasswordAttempt> _PasswordAttemptList = new List<PasswordAttempt>();

        public void SetSkipped(LoginSkippedType whySkipped)
        {
            _WhySkipped = whySkipped;
        }

        /// <summary>
        /// Initializes a new instance of LoginResults.
        /// </summary>
        public LoginResults(string userName)
        {
            _UserName = userName;
        }

        /// <summary>
        /// User name.
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
        }

        /// <summary>
        /// Password attempts.
        /// </summary>
        public int PasswordAttempts
        {
            get { return _PasswordAttempts; }
            set { _PasswordAttempts = value; }
        }

        /// <summary>
        /// True if a login attempt was successful.
        /// </summary>
        public bool IsLoginSkipped
        {
            get { return _WhySkipped != LoginSkippedType.NotSkipped; }
        }

        public string WhySkippedString
        {
            get
            {
                return GetWhySkippedString(_WhySkipped);
            }
        }

        /// <summary>
        /// True if a login attempt was successful.
        /// </summary>
        public bool IsLoginSuccessful
        {
            get { return !IsLoginSkipped && _Password != null; }
        }

        /// <summary>
        /// Password that successfully opened the connection.
        /// </summary>
        public string SuccessfulPassword
        {
            get
            {
                if (!IsLoginSkipped)
                    return _Password;

                return null;
            }
            set
            {
                _Password = value;
            }
        }

        /// <summary>
        /// String representation of LoginResults.
        /// </summary>
        public override string ToString()
        {
            return _UserName;
        }

        public static string GetWhySkippedString(LoginSkippedType whySkipped)
        {
            string resultString;

            switch (whySkipped)
            {
                case LoginSkippedType.NotSkipped:
                    resultString = "Not Skipped";
                    break;
                case LoginSkippedType.LoginLockedOut:
                    resultString = "Skipped: Login locked out";
                    break;
                case LoginSkippedType.LoginEnforcesPasswordPolicy:
                    resultString = "Skipped: Password Policy On";
                    break;
                case LoginSkippedType.CantChangePasswordPolicy:
                    resultString = "Skipped: Can't change password policy";
                    break;
                case LoginSkippedType.LoginDisabled:
                    resultString = "Skipped: Login disabled";
                    break;
                case LoginSkippedType.LoginDefaultDatabase:
                    resultString = "Skipped: Can't access default database";
                    break;
                case LoginSkippedType.LoginDoesntExist:
                    resultString = "Skipped: Login doesn't exist";
                    break;
                case LoginSkippedType.LoginLocked:
                    resultString = "Skipped: Login locked out";
                    break;
                case LoginSkippedType.LoginDenyAccess:
                    resultString = "Skipped: Login denied access";
                    break;
                case LoginSkippedType.CantAccessUser:
                    resultString = "Skipped: Insufficient Permissions";
                    break;
                case LoginSkippedType.PasswordExpired:
                    resultString = "Skipped: Password expired";
                    break;
                case LoginSkippedType.NotSupportedEncryption:
                    resultString = "Skipped: Password uses unsupported encryption";
                    break;
                default:
                    resultString = "Unknown";
                    break;
            }

            return resultString;
        }
    }

    enum LoginSkippedType
    {
        NotSkipped,
        LoginLockedOut,
        LoginEnforcesPasswordPolicy,
        CantChangePasswordPolicy,
        LoginDisabled,
        LoginDefaultDatabase,
        LoginDoesntExist,
        LoginLocked,
        LoginDenyAccess,
        CantAccessUser,
        PasswordExpired,
        NotSupportedEncryption
    }
}