using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DeployLX.Licensing.v5;

namespace Idera.SqlAdminToolset.Core.LicenseViews.Panels
{
    public partial class RegisterOnline : RegisterOnlinePanel
    {
        public RegisterOnline(RegistrationLimit limit, LicenseValuesDictionary regInfo) : base(limit, regInfo)
        {
            
        }
    }
}
