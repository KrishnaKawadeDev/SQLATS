using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.MultiQuery
{
   internal class MultiQueryOptions
   {
      public string  database;
      public int     queryIndex;
      
      public MultiQueryOptions( string inDatabase, int inIndex )
      {
          database   = inDatabase;
          queryIndex = inIndex;
      }
   }
}
