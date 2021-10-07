using System;
using System.Collections.Generic;
using System.Text;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ObjectSearch
{
   public class SearchResult
   {
      public string server;
      public string database;
      
      public string schema;
      public string name;
      public string objectType;
      
      public string parentSchema;
      public string parentName;
      public string parentObjectType;
      
      public string details;
      public bool   showEnabled;
      public bool   enabled;
      
      public SearchHelper.IconType iconIndex = SearchHelper.IconType.Unknown;

      public SearchResult()
      {
         server           = "";
         database         = "";
         schema           = "";
         name             = "";
         objectType       = "";
         parentSchema     = "";
         parentName       = "";
         parentObjectType = "";
         details          = "";
         showEnabled      = false;
         enabled          = true;
      }
      
      public SearchResult( string inServer ) : base()
      {
         server = SQLHelpers.NormalizeInstanceName(inServer);
      }
      
        
      public SearchResult(
            string inDatabase,
            string inSchema,
            string inName,
            string inObjectType,
            string inParentSchema,
            string inParentName,
            string inParentObjectType,
            bool   inShowEnabled,
            bool   inEnabled,
            string inDetails
         )
      {
         database         = inDatabase;
         schema           = inSchema;
         name             = inName;
         objectType       = inObjectType;
         parentSchema     = inParentSchema;
         parentName       = inParentName;
         parentObjectType = inParentObjectType;
         showEnabled      = inShowEnabled;
         enabled          = inEnabled;
         details          = inDetails;
      }
        
      public string DisplayMember { get { return name; } }
      override public string ToString() { return name; }

      public string GetFullName()
      {
         string nm = name;
         if ( schema != null && schema != "" && schema != "dbo" )
         {
            nm = schema + "." + nm;
         }
         return nm;
      }
      
      public string GetFullParentName()
      {
         string nm = "";
         
         if ( ! String.IsNullOrEmpty(parentName) )
         {
            nm = parentName;
            if ( parentSchema != null && parentSchema != "" && parentSchema != "dbo" )
            {
               nm = parentSchema + "." + nm;
            }
         }
         return nm;
      }
   }
}
