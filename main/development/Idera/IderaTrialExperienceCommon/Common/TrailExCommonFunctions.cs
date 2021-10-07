using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace IderaTrialExperienceCommon.Common
{
    public class TrailExCommonFunctions
    {
        public static Boolean IsUserRestrictted()
        {
            bool IsRestricted = false;
            try
            {
                EventLog.WriteEntry(Application.ProductName, "Check Permissions");
                return IsRestricted;
            }
            catch (Exception)
            {
                IsRestricted = true;
            }
            return IsRestricted;
        }
    }
}
