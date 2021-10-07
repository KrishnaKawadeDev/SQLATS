using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Linq;
using BBS.TracerX;
using DeployLX.Licensing.v5;
using Idera.SqlAdminToolset.Core.LicenseViews;
using Idera.SqlAdminToolset.Core.Licensing;
using IderaTrialExperienceCommon.Common;
using BBS.License;

namespace Idera.SqlAdminToolset.Core
{
    public class LicenseUI
    {
        [Flags]
        internal enum ExitReason
        {
            OnNone = 1,
            OnRegister = 2,
            OnExtend = 4,
            OnActivate = 8,
            OnDeactivate = 16

        }

        private static void LogLicense(string msg, SecureLicense license)
        {
            if (license == null) CoreGlobals.traceLog.Info("License is NULL");

            else
            {
                CoreGlobals.traceLog.InfoFormat(
                    "{0}\nSerial Key:{1},\n IsTrial:{2},\n IsActivated:{3},\n IsActivation:{4},\n IsUnlocked:{5},\n Limits Count:{6},\n Limit[0].State:{7},\n License Version:{8}\n",
                    msg,
                    license.SerialNumber, license.IsTrial, license.IsActivated, license.IsActivation, license.IsUnlocked,
                    license.Limits.Count,
                    license.Limits[0].State, license.Version);


            }


        }
        public static bool StartupLicenseCheck()
        {

            using (CoreGlobals.traceLog.InfoCall())
            {
                // Check for persisted license key - either in product config or in trial license
                var licenseKey = BBSProductLicense.ReadProductLicense();
                if (licenseKey == "")
                {
                    // because we used to write license to registry we should check there if dont one for upgrade case
                    licenseKey = BBSProductLicense.ReadProductLicenseFromRegistry();
                }

                //if (CoreGlobals.showWelcomeScreen)
                //{
                //    if (licenseKey != "")
                //    {
                //        BBSProductLicense license = new BBSProductLicense(new Version(1, 2), licenseKey);

                //        //Only display the dialog is the license is not a trial.
                //        if (license.IsLicenseStringTrial(licenseKey) == false)
                //        {
                //            //Display a dialog stating that that an old license was found that you will get a new one in the mail
                //            Form_OldLicenseWarning newLicense = new Form_OldLicenseWarning();
                //            newLicense.LicenseKey = licenseKey;
                //            newLicense.ShowDialog();
                //        }
                //    }
                //}
                if (string.IsNullOrEmpty(licenseKey))
                {
                    try
                    {
                        var validLicense = Licensing.BypassDeployLX.IsLicensed();
                        if (validLicense)
                        {
                            CoreGlobals.isBypassLicense = true;
                            CoreGlobals.trialCopy = false;
                            CoreGlobals.activated = true;
                            return true;
                        }

                        CoreGlobals.isBypassLicense = false;
                        try
                        {
                            SecureLicenseManager.HelpRequested += HelpRequested;


                            CoreGlobals.SecureLicense = ValidateLicense(CoreGlobals.showWelcomeScreen);
                            validLicense = CoreGlobals.SecureLicense != null;

                            if ((CoreGlobals.License.IsTrial == false) && (licenseKey != ""))
                            {
                                //Remove the existing old license key
                               // BBSProductLicense.DeleteLicenseInfo();
                            }
                            licenseKey = CoreGlobals.License.SerialNumber;
                        }

                        catch (Exception e)
                        {
                            CoreGlobals.traceLog.ErrorFormat("Unknown exception on Validtion.  {0}", e.ToString());
                        }
                        CoreGlobals.trialCopy = CoreGlobals.License.IsTrial;
                        CoreGlobals.activated = CoreGlobals.License.IsActivated;

                    }
                    catch
                    {

                    }
                    if (string.IsNullOrEmpty(licenseKey)|| CoreGlobals.License.IsTrial)
                    {
                        licenseKey = BBSProductLicense.ReadTrialLicense();
                        if (string.IsNullOrEmpty(licenseKey))
                        {
                            licenseKey = BBSProductLicense.GenerateTrialLicense();
                        }
                    }
                    else if (CoreGlobals.License != null && (CoreGlobals.SecureLicense.SerialNumber.StartsWith("SPC")||CoreGlobals.License.IsActivated))
                    {
                        licenseKey = BBSProductLicense.GenerateLicense();
                    }
                }
                var BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                       licenseKey);
                CoreGlobals.trialCopy = BBSLicense.licenseData.isTrial;
                CoreGlobals.activated = BBSLicense.licenseData.licState == BBSProductLicense.LicenseState.Valid;
                return BBSLicense.licenseData.licState == BBSProductLicense.LicenseState.Valid;
                //var validLicense = Licensing.BypassDeployLX.IsLicensed();
                //if (validLicense)
                //{
                //    CoreGlobals.isBypassLicense = true;
                //    CoreGlobals.trialCopy = false;
                //    CoreGlobals.activated = true;
                //    return true;
                //}

                //CoreGlobals.isBypassLicense = false;
                //try
                //{
                //    SecureLicenseManager.HelpRequested += HelpRequested;


                //    CoreGlobals.SecureLicense = ValidateLicense(CoreGlobals.showWelcomeScreen);
                //    validLicense = CoreGlobals.SecureLicense != null;

                //    if ((CoreGlobals.License.IsTrial == false) && (licenseKey != ""))
                //    {
                //        //Remove the existing old license key
                //        BBSProductLicense.DeleteLicenseInfo();
                //    }
                //}

                //catch (Exception e)
                //{
                //    CoreGlobals.traceLog.ErrorFormat("Unknown exception on Validtion.  {0}", e.ToString());
                //}
                //CoreGlobals.trialCopy = CoreGlobals.License.IsTrial;
                //CoreGlobals.activated = CoreGlobals.License.IsActivated;
                //return validLicense;
            }
        }

        private static void HelpRequested(Object sender, ValidationHelpEventArgs e)
        {
            Process.Start("http://wiki.idera.com/display/SQLAdminToolset/Manage+license");
        }



        public static void KillLaunchPad()
        {
            string processName = "Launchpad";
            Process currentProcess = Process.GetCurrentProcess();

            foreach (Process process in Process.GetProcesses())
            {
                //Found the launchpad
                if (process.ProcessName.StartsWith(processName))
                {
                    //Don't kill it if it is the calling process or in another session.
                    if (process.Id != currentProcess.Id && process.SessionId == currentProcess.SessionId)
                    {
                        if (process.CloseMainWindow() == false)
                        {
                            // if the launch pad does not close gracefully, force it to close.
                            process.Kill();
                        }
                    }
                }
            }
        }



        public static SecureLicense ValidateLicense(bool showForm)
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                try
                {
                    LicenseValidationRequestInfo validationRequest;
                    LogLicense("License Before Validation: ", CoreGlobals.SecureLicense);
                    //SecureLicenseManager.ResetCache();
                    if (CoreGlobals.SecureLicense != null)
                    {
                        var sc = SecureLicenseContext.CreateResolveContext(CoreGlobals.SecureLicense);
                        validationRequest = sc.RequestInfo;
                        validationRequest.DontShowForms = !showForm;
                        validationRequest.DisableCache = true;
                    }
                    else
                        validationRequest = new LicenseValidationRequestInfo
                        {
                            DontShowForms = !showForm
                            ,
                            DisableCache = true
                        };


                    var license = SecureLicenseManager.Validate(null, typeof(LicenseUI), validationRequest);
                    LogLicense("License After Validation: ", license);


                    if (license.Version.Major < 4)
                    {
                        CoreGlobals.traceLog.Info("Possibly found unsupported license. Removing license data...");
                        license.ClearSerialNumbersAndActivationData(true);
                        license.LicenseFile.Delete(true, true);
                        return SecureLicenseManager.Validate(null, typeof(LicenseUI), validationRequest); ;
                    }
                    return license;
                }
                catch (Exception e)
                {

                    CoreGlobals.traceLog.ErrorFormat("No LicenseExcpetion on Validation.  {0}", e.Message);
                    return null;
                }
            }
        }

        public static void ShowLicenseManagementForm()
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                try
                {
                    ManageBBSLicense manageBBSLicense = new ManageBBSLicense();
                    manageBBSLicense.ShowDialog();


                    //SecureLicense prevLicense = CoreGlobals.SecureLicense;
                    //string oldLimitCode = GetLimitCode();
                    //LogLicense("License Before Show Management Form:", CoreGlobals.SecureLicense);
                    //if (CoreGlobals.SecureLicense == null)
                    //    CoreGlobals.SecureLicense = ValidateLicense(true) ?? ValidateLicense(false);
                    //// revalidate to prevent null license on cross button closing
                    //else
                    //if (CoreGlobals.SecureLicense != null &&
                    //    (CoreGlobals.SecureLicense.Type == "Special Edition" && CoreGlobals.SecureLicense.Limits.FindLimitsByType(typeof(TimeLimit), false).Any()) || //Possibly we want to extend by SPC key
                    //         (CoreGlobals.SecureLicense.IsActivated && CoreGlobals.SecureLicense.IsActivation))
                    //{
                    //    CoreGlobals.SecureLicense = ValidateLicense(false);
                    //    //revalidate to prevent deactivation issue

                    //    var rInfo = new LicenseValidationRequestInfo();
                    //    SecureLicense license = CoreGlobals.SecureLicense.ShowForm((ISuperFormLimit)CoreGlobals.SecureLicense.Limits[0], null,
                    //        null, typeof(LicenseUI), rInfo);
                    //    LogLicense("License After Show Management Form [CoreGlobals]:", CoreGlobals.SecureLicense);
                    //    LogLicense("License After Show Management Form [Returned By ShowForm]:", license);

                    //}
                    //else
                    //{
                    //    CoreGlobals.SecureLicense = ValidateLicense(true);
                    //    // revalidate to prevent null license on cross button closing
                    //}


                    //string newLimitCode = GetLimitCode();
                    ////ExitApplication(prevLicense, oldLimitCode, newLimitCode, ExitReason.OnExtend);
                    //if (CoreGlobals.SecureLicense == null)
                    //    CoreGlobals.SecureLicense = ValidateLicense(false);
                    ////revalidate if possibly closed by cross button



                }
                catch (Exception e)
                {
                    // ignored
                    CoreGlobals.traceLog.ErrorFormat("License validation exception: {0}", e.Message);
                }
            }
        }

        private static void ExitApplication(SecureLicense prevLicense, string oldLimitCode, string newLimitCode,
            ExitReason exitReason)
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                if (GetExitReason(prevLicense, oldLimitCode, newLimitCode).HasFlag(exitReason))
                {
                    Application.Exit();
                }
            }
        }

        private static ExitReason GetExitReason(SecureLicense prevLicense, string oldLimitCode, string newLimitCode)
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                ExitReason reason = ExitReason.OnNone;
                if (CoreGlobals.BBSLic == null) return ExitReason.OnNone; //Stop processing if license not valid

                if ((prevLicense == null && CoreGlobals.BBSLic.IsTrial) || //If extended from expired
                    (!oldLimitCode.Equals(newLimitCode)))
                    reason |= ExitReason.OnExtend; // or if changed limit code than extended


                if ((prevLicense == null && !CoreGlobals.BBSLic.IsTrial) ||
                    (prevLicense != null && prevLicense.IsTrial && !CoreGlobals.BBSLic.IsTrial))
                    reason |= ExitReason.OnRegister;

                //if ((prevLicense == null && CoreGlobals.SecureLicense.IsActivated &&
                //     CoreGlobals.SecureLicense.IsActivation) ||
                //    (prevLicense != null && !prevLicense.IsActivated && !prevLicense.IsActivation &&
                //     CoreGlobals.SecureLicense.IsActivated && CoreGlobals.SecureLicense.IsActivation))
                //    reason |= ExitReason.OnActivate;


                return reason;
            }
        }

        public static string GetLimitCode()
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                try
                {

                    if (CoreGlobals.SecureLicense == null) CoreGlobals.SecureLicense = ValidateLicense(false);
                    if (CoreGlobals.SecureLicense == null) return String.Empty;

                    var context = SecureLicenseContext.CreateResolveContext(CoreGlobals.SecureLicense);
                    if (CoreGlobals.SecureLicense.Limits.Count == 0) return string.Empty;
                    var limit =
                        CoreGlobals.SecureLicense.Limits.FindLimitByType(typeof(IExtendableLimit), true) as
                            IExtendableLimit;
                    if (limit == null) return string.Empty;
                    var limitCode = string.Empty;
                    if (CoreGlobals.SecureLicense.IsTrial && limit.CanExtend)
                        limitCode = context.MakeExtensionLimitCode(limit);
                    return limitCode;
                }
                catch
                    (Exception
                    ex)
                {
                    CoreGlobals.traceLog.ErrorFormat("LimitCode generation exception: {0}", ex.Message);
                    return string.Empty;
                }
            }

        }

        public static BBSLic ShowRegistrationForm()
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                ShowLicenseManagementForm();
                return CoreGlobals.BBSLic;
            }


        }


        public static LicenseInformation GetLicenseInfo()
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                var licenseInfo = new LicenseInformation();
                if (CoreGlobals.isBypassLicense)
                {
                    licenseInfo.IsActivated = CoreGlobals.activated;
                    licenseInfo.IsTrial = CoreGlobals.trialCopy;
                }
                else
                {
                    var license = CoreGlobals.License;
                    if (license == null) return null;

                    licenseInfo = new LicenseInformation
                    {

                        DaysToExpire = license.DaysToExpire,
                        IsActivated = license.IsActivated,
                        IsBeta = license.IsBeta,
                        IsExpired = license.DaysToExpire <= 0,
                        IsPermanent = !license.IsTrial,
                        IsTrial = license.IsTrial,
                        LicenseType = license.LicenseType,
                        LimitCode = license.LimitCode,
                        SerialNumber = license.SerialNumber

                    };
                }
                return licenseInfo;
            }

        }

    }
}
