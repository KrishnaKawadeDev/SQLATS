using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Utility
{
   // This is copied from the SQLJmSupport file and moved to the Utility level to make this function accessible similarly for notifications
   class SQLJmSupport
   {
      public static Exception InnerMost(Exception e)
      {
         Exception workEx = e;
         while (workEx.InnerException != null)
            workEx = workEx.InnerException;

         return workEx;
      }

      public static string DropBrackets(string dbName)
      {
         string cleanName = dbName.Replace('[', ' ');
         cleanName = cleanName.Replace(']', ' ').Trim();
         return cleanName;
      }
   }
}
