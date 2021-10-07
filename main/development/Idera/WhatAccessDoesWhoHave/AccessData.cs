using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.WhatAccessDoesWhoHave
{
   /// <summary>
   /// Information on accessibility for a SQL object.
   /// </summary>
   public class AccessData
   {
      private ServerInformation _ServerInfo;
      private string _ObjectName;
      private ObjectType _Type;
      private List<string> _AccessList = new List<string>();
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
      public List<string> AccessList
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
