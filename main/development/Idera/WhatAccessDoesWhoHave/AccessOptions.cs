using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.WhatAccessDoesWhoHave
{
   public class AccessOptions : JobPoolOptions
   {
      private string _LoginName;

      /// <summary>
      /// Login Name.
      /// </summary>
      public string LoginName
      {
         get { return _LoginName; }
         set { _LoginName = value; }
      }
   }
}
