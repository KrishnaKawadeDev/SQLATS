using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Principal;
using System.Threading;

namespace Idera.SqlAdminToolset.Core
{
   class SecurityRole
   {
      public static bool
         IsLocalAdmin()
      {
         bool isAdmin = false;

         try
         {
            AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal principal = (WindowsPrincipal)Thread.CurrentPrincipal;
            WindowsIdentity identity = (WindowsIdentity)principal.Identity;
            isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
         }
         catch { }

         return isAdmin;
      }
   }
}
