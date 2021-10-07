using System;
using System.Collections.Generic;
using System.Text;
using System.Management;

namespace Idera.SqlAdminToolset.Core
{
   public class WmiHelpers
   {
      static public int
         GetInt(
            ManagementObject managementObject,
            string           column
         )
      {
         int returnValue = 0;
         
         if (managementObject[column] != null)
         {
            returnValue = (int)managementObject[column];
         }
      
         return returnValue;
      }

      static public bool
         GetBool(
            ManagementObject managementObject,
            string           column
         )
      {
         bool returnValue = false;
         
         if (managementObject[column] != null)
         {
             returnValue = (bool)managementObject[column];
         }
      
         return returnValue;
      }

      static public ulong
         GetUlong(
            ManagementObject managementObject,
            string           column
         )
      {
         ulong returnValue = 0;
         
         if (managementObject[column] != null)
         {
             returnValue = (ulong)managementObject[column];
         }
      
         return returnValue;
      }

      static public string
         GetString(
            ManagementObject managementObject,
            string           column
         )
      {
         string returnValue = "";
         
         if (managementObject[column] != null)
         {
             returnValue = managementObject[column].ToString();
         }
      
         return returnValue;
      }
   }
}
