using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.WhoHasAccess
{
   /// <summary>
   /// Information on accessibility for a SQL object.
   /// </summary>
   public class AccessData
   {
      private ServerInformation _ServerInfo;
      private string _ObjectName;
      private ObjectType _Type;
      private List<AccessPermissions> _AccessList = new List<AccessPermissions>();
      private List<AccessDataGroup> _ChildData = new List<AccessDataGroup>();
      private Exception _DataException;
      private bool _PermissionsLoaded = false;
      private AccessData _Parent = null;

      public AccessData(ServerInformation serverInfo, string objectName, ObjectType type)
      {
         _ServerInfo = serverInfo;
         _ObjectName = objectName;
         _Type = type;
      }

      public AccessData(AccessData parent, string objectName, ObjectType type) 
         : this(parent.ServerInfo, objectName, type)
      {
         _Parent = parent;
      }

      /// <summary>
      /// Connection information.
      /// </summary>
      public ServerInformation ServerInfo
      {
         get { return _ServerInfo; }
      }

      /// <summary>
      /// Object name.
      /// </summary>
      public string ObjectName
      {
         get { return _ObjectName; }
      }

      /// <summary>
      /// Object type.
      /// </summary>
      public ObjectType Type
      {
         get { return _Type; }
      }

      /// <summary>
      /// List of users and groups granted access to this object.
      /// </summary>
      public List<AccessPermissions> AccessList
      {
         get { return _AccessList; }
      }

      /// <summary>
      /// Child data.
      /// </summary>
      public List<AccessDataGroup> ChildData
      {
         get { return _ChildData; }
      }

      /// <summary>
      /// Exception thrown while retrieving data.
      /// </summary>
      public Exception DataException
      {
         get { return _DataException; }
         set { _DataException = value; }
      }

      public override string ToString()
      {
         return _ObjectName;
      }

      public bool PermissionsLoaded
      {
         get { return _PermissionsLoaded; }
         set { _PermissionsLoaded = value; }
      }

      /// <summary>
      /// Parent in the access data tree.
      /// </summary>
      public AccessData Parent
      {
         get { return _Parent; }
         set { _Parent = value; }
      }
   }

   /// <summary>
   /// Level of permissions granted to each user or group.
   /// </summary>
   public class AccessPermissions
   {
      private string _LoginName;
      private string _UserName;
      private AccessDetailsRelation _DetailRelation;
      private List<AccessDetails> _Permissions = new List<AccessDetails>();
      private UserType _UserType;
      private List<AccessPermissions> _GroupMembers = new List<AccessPermissions>();

      public AccessPermissions(string loginName)
      {
         _LoginName = loginName;
      }

      public AccessPermissions(string loginName, UserType type) : this(loginName)
      {
         _UserType = type;
      }

      /// <summary>
      /// Name of user or group.
      /// </summary>
      public string LoginName
      {
         get { return _LoginName; }
      }

      /// <summary>
      /// User or role name related to login name.
      /// </summary>
      public string UserName
      {
         get { return _UserName; }
         set { _UserName = value; }
      }

      /// <summary>
      /// Permissions granted.
      /// </summary>
      public List<AccessDetails> Permissions
      {
         get { return _Permissions; }
      }

      /// <summary>
      /// User type
      /// </summary>
      public UserType UserType
      {
         get { return _UserType; }
         set { _UserType = value; }
      }

      /// <summary>
      /// Group members.  If this is not a group, and exception is thrown.
      /// </summary>
      public List<AccessPermissions> GroupMembers
      {
         get 
         {
            if (IsGroup)
            {
               return _GroupMembers;
            }
            else
            {
               throw new Exception("Group members can only be accessed for groups");
            }
         }
      }

      /// <summary>
      /// True if this is a group, otherwise false.
      /// </summary>
      public bool IsGroup
      {
         get
         {
            return (_UserType == UserType.NtGroup || _UserType == UserType.SqlRole);
         }
      }

      /// <summary>
      /// Relation between Access permissions and details.
      /// </summary>
      public AccessDetailsRelation DetailRelation
      {
         get { return _DetailRelation; }
         set { _DetailRelation = value; }
      }

      public override string ToString()
      {
         return _LoginName;
      }

      /// <summary>
      /// Makes a shallow copy of the AccessPermissions object.
      /// </summary>
      /// <returns></returns>
      public AccessPermissions Copy()
      {
         AccessPermissions _NewPermissions = new AccessPermissions(_LoginName);
         _NewPermissions.UserName = _UserName;
         _NewPermissions.UserType = _UserType;
         if (IsGroup)
         {
            _NewPermissions.GroupMembers.AddRange(_GroupMembers);
         }
         _NewPermissions.DetailRelation = _DetailRelation;
         return _NewPermissions;
      }
   }

   /// <summary>
   /// The list of objects that can be accessed by the user or group
   /// </summary>
   public class AccessDetails
   {
      string _Name;

      public AccessDetails() { }

      public AccessDetails(string name)
      {
         _Name = name;
      }

      public string Name
      {
         get { return _Name; }
         set { _Name = value; }
      }

      /// <summary>
      /// Implicit converter to string
      /// </summary>
      public static implicit operator string(AccessDetails value)
      {
         return value.Name;
      }

      /// <summary>
      /// Implicit converter from string
      /// </summary>
      public static implicit operator AccessDetails(string value)
      {
         return new AccessDetails(value);
      }

   }

   /// <summary>
   /// Specific access to an object
   /// </summary>
   public class ObjectAccessDetails : AccessDetails
   {
      string _Type; //Grant
      string _Action; //Alter
      string _Column; //(All)
      string _Owner;  

      public string Owner
      {
         get { return _Owner; }
         set { _Owner = value; }
      }

      public string Type
      {
         get { return _Type; }
         set { _Type = value; }
      }

      public string Action
      {
         get { return _Action; }
         set { _Action = value; }
      }

      public string Column
      {
         get { return _Column; }
         set { _Column = value; }
      }
   }

   /// <summary>
   /// Access data group.
   /// </summary>
   public class AccessDataGroup
   {
      string _Name;
      List<AccessData> _Items = new List<AccessData>();
      List<AccessDataGroup> _Groups = new List<AccessDataGroup>();
      private ObjectType _Type;

      public AccessDataGroup(string name, ObjectType type)
      {
         _Name = name;
         _Type = type;
      }

      /// <summary>
      /// Access data items.
      /// </summary>
      public List<AccessData> Items
      {
         get { return _Items; }
      }

      /// <summary>
      /// Access data groups.
      /// </summary>
      public List<AccessDataGroup> Groups
      {
         get { return _Groups; }
      }

      /// <summary>
      /// Object type.
      /// </summary>
      public ObjectType Type
      {
         get { return _Type; }
      }

      /// <summary>
      /// Group name.
      /// </summary>
      public string Name
      {
         get { return _Name; }
      }

      public override string ToString()
      {
         return _Name;
      }
   }

   /// <summary>
   /// Object types.
   /// </summary>
   public enum ObjectType
   {
      None,
      Server,
      Database,
      Table,
      View,
      StoredProcedure,
      Function,
      Column,
      DatabaseUser,
      DatabaseRole,
      Assembly,
      Schema,
      FullTextCatalog,
      XmlSchemaCollection,
      Synonym,
      AsymmetricKey,
      SymmetricKey,
      Certificates,
      ServerLogin,
      ServerRole,
      ServerSecurable,
      ServerEndPoint
   }

   /// <summary>
   /// User type.
   /// </summary>
   public enum UserType
   {
      NtGroup,
      NtUser,
      SqlUser,
      SqlRole,
      AppRole
   }

   /// <summary>
   /// The relationship between the Access permissions and its details.
   /// </summary>
   public enum AccessDetailsRelation
   {
      MemberOf,
      AccessTo,
      AccessibleBy
   }
}
