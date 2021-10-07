using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PasswordChecker
{
   internal class PasswordCheckerOptions : JobPoolOptions
   {
      private UsersToTest _UserType;
      private string[] _ServerRoles;
      private string[] _DatabaseRoles;
      private string[] _Users;
      private List<string> _PasswordList = new List<string>();
      private bool _TestCommonVariations = false;

      /// <summary>
      /// Server Roles.
      /// </summary>
      public string[] ServerRoles
      {
         get { return _ServerRoles; }
         set { _ServerRoles = value; }
      }

      /// <summary>
      /// Database roles.
      /// </summary>
      public string[] DatabaseRoles
      {
         get { return _DatabaseRoles; }
         set { _DatabaseRoles = value; }
      }

      /// <summary>
      /// Users
      /// </summary>
      public string[] Users
      {
         get { return _Users; }
         set { _Users = value; }
      }

      /// <summary>
      /// Users to test.
      /// </summary>
      internal UsersToTest UserType
      {
         get { return _UserType; }
         set { _UserType = value; }
      }

      /// <summary>
      /// List of passwords that should be tried.
      /// </summary>
      public List<string> PasswordList
      {
         get { return _PasswordList; }
         set { _PasswordList = value; }
      }

      /// <summary>
      /// Test common variations of passwords.
      /// </summary>
      public bool TestCommonVariations
      {
         get { return _TestCommonVariations; }
         set { _TestCommonVariations = value; }
      }
   }

   /// <summary>
   /// Types of users to test.
   /// </summary>
   internal enum UsersToTest
   {
      All,
      ServerRole,
      DatabaseRole,
      SpecifiedUser,
      Sa
   }
}
