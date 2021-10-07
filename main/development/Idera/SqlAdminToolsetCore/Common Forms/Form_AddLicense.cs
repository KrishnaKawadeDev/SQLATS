#region SQL admin toolset © 2007, 2012 Idera, Inc. and Idera.

/* 
 * Idera reserves all rights in the program and source code as delivered.  The program 
 * or any portion thereof may not be reproduced or reverse engineered in any form 
 * whatsoever without the written consent of Idera.  
 * 
 * A license to the software does not constitute authorization.
 */

#endregion

#region Using Directives

using System;
using System.Windows.Forms;
using System.Reflection;
using Idera.SqlAdminToolset.Core;

#endregion

namespace Idera.SqlAdminToolset.Core
{
  public partial class Form_AddLicense : Form
  {
    public string licenseKey = "";

    #region CTOR

    public Form_AddLicense()
    {
      InitializeComponent();
    }

    #endregion

    #region Events

    private void button_OK_Click(object sender, EventArgs e)
    {
      textBox_NewKey.Text = textBox_NewKey.Text.Trim();

      // validate license - product, expiration date etc
      BBSProductLicense lic = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                    textBox_NewKey.Text);

      if ( lic.licenseData.licState != BBSProductLicense.LicenseState.Valid
            || lic.licenseData.isTrial && lic.licenseData.expirationDateStr == BBSLicenseConstants.LicenseNoExpirationDate )
      {
         MessageBox.Show( this,
                          lic.GetErrorMessage(lic.licenseData.licState, textBox_NewKey.Text),
                          "Invalid License Key",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error );
         return;
      }
      else
      {
           licenseKey = textBox_NewKey.Text;
           DialogResult = DialogResult.OK;
      }
    }

    private void button_Cancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
    }

    #endregion

    private void textBox_NewKey_TextChanged(object sender, EventArgs e)
    {
      buttonOK.Enabled = (textBox_NewKey.Text.Trim().Length != 0);
    }
  }
}