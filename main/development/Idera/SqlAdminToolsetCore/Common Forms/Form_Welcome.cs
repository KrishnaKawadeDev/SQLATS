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
  public partial class Form_Welcome : Form
  {
    public string NewLicenseKey = "";

    bool   trial;
    bool   beta;
    int    daysLeft;
    bool   aboutToExpire;
    bool   pastBetaDropDeadDate = false;

    #region CTOR / OnLoad

    public
       Form_Welcome
          (
             bool   inBeta,
             bool   inTrial,
             int    inDaysLeft,
             bool   inAboutToExpire,
             string productName
       )
    {
        InitializeComponent();

        beta          = inBeta;
        trial         = inTrial;
        daysLeft      = inDaysLeft;
        aboutToExpire = inAboutToExpire;

        labelSubtitle.Text = productName;
    }

    protected override void  OnLoad(EventArgs e)
    {
 	    base.OnLoad(e);

       labelTitle.Text = String.Format( "<div align=\"right\">Welcome to the <font color=\"#fd4703\">{0}</font></div>", CoreGlobals.suiteName);
       labelSubtitle.Visible = true;
       labelVersion.Text = "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

       if ( CoreGlobals.betaCopy && (DateTime.Now.CompareTo( CoreGlobals.betaDropDeadDate ) > 0) )
       {
          pastBetaDropDeadDate = true;

          // Beta Software has a drop dead date so that we dont have to support pre-release copies of the software
          labelIntroduction.Text = String.Format( "Thank you for your interest in the {0}. You are running the Community Technology Preview of the {0}. Please contact Idera to upgrade to the official release.", CoreGlobals.suiteName);
          labelExpiration.Text   = String.Format( "The Community Technology Preview of the {0} has expired.", CoreGlobals.suiteName);

          // mark license as exzpired and dont allow them to specify a new one
          trial = true;
          daysLeft = 0;
          linkNewLicenseKey.Enabled = false;
       }
       else if ( beta )
       {
          if (daysLeft > 0)
          {
             labelIntroduction.Text = String.Format( "Thank you for your interest in the {0}.  The Community Technology Preview license allows you unlimited use of the tools in this product during the preview period.", CoreGlobals.suiteName);
             
             if ( daysLeft < 7 )
                labelExpiration.Text   = String.Format("The Community Technology Preview will expire in {0} days.", daysLeft );
             else
                labelExpiration.Text   = String.Format("The Community Technology Preview will expire on {0}.", DateTime.Now.AddDays(daysLeft).ToShortDateString() );
          }
          else
          {
             labelIntroduction.Text = String.Format( "Thank you for your interest in the {0}.  The Community Technology Preview period for this product has expired.  To continue running this product, contact Idera for a new license key. ", CoreGlobals.suiteName);
             labelExpiration.Text   = "The current license key has expired";
          }
       }
       else if ( trial )
       {
           if (daysLeft > 0)
          {
             labelIntroduction.Text = String.Format( "Thank you for your interest in the {0}.  The trial license of this software allows you unlimited use of the tools for a limited period. Please contact Idera to purchase permanent licenses for this product.", CoreGlobals.suiteName);
             labelExpiration.Text = String.Format("There are {0} days remaining in the trial period.", daysLeft);
          }
          else
          {
              labelIntroduction.Text = String.Format( "Thank you for your interest in the {0}.  The trial period for this product has expired.  To continue running this product, contact Idera for a new license key. ", CoreGlobals.suiteName);
              labelExpiration.Text = "The trial period specified by the current license key has expired";
          }
       }
      else // purchase
      {
          if (daysLeft > 0)
          {
              labelIntroduction.Text = "Warning: The license period for this product will expire soon. To continue running this product once the license period expires, contact Idera for a new license key.";
              labelExpiration.Text = String.Format("There are {0} days remaining in the license period.", daysLeft);
          }
          else // expired
          {
              labelIntroduction.Text = "The license period specified by the current license key has expired. To continue running this product, contact Idera for a new license key.";
              labelExpiration.Text = "The license period specified by the current license key has expired.";
          }
       }
       
       // try to bring this screen to front so it is on top when it launches
       this.BringToFront();
    }

    #endregion

      private void buttonClose_Click(object sender, EventArgs e)
      {
         // warn if license expired and user didnt provide license key
         if ( daysLeft <= 0 )
         {
            if ( pastBetaDropDeadDate)
            {
               DialogResult = DialogResult.Abort;
            }
            else 
            {
                DialogResult choice;
                choice = MessageBox.Show( this,
                                          String.Format( "A valid license key is required to use the the {0}. If you do not register a new license key, this application will close.\n\nDo you want to continue and exit this application?", CoreGlobals.suiteName),
                                          "Valid License Key Required",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning );
                if ( choice == DialogResult.No ) 
                {
                    DialogResult = DialogResult.None;
                    return;
                }
                DialogResult = DialogResult.Abort;
            }
         }
         Close();
      }

      private void linkNewLicenseKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
          Form_AddLicense frm = new Form_AddLicense();
          DialogResult choice = frm.ShowDialog();
          if (choice == DialogResult.OK)
          {
              NewLicenseKey = frm.licenseKey;
              Close();
          }
      }

     private void Form_Welcome_Load( object sender, EventArgs e )
     {
     }
  }
}