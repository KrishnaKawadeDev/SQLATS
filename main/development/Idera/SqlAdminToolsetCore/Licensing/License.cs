#region SQL admin toolset © 2006, 2007, 2012 Idera, Inc. and Idera.

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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Reflection;
using BBS.License;
using BBS.TracerX;
using Microsoft.Win32;
using System.Net;
using System.IO;

#endregion

namespace Idera.SqlAdminToolset.Core
{

   #region Constants

   public static class BBSLicenseConstants
   {
      public const string LicenseTypeProduction = "Production";
      public const string LicenseTypeTrial = "Trial";
      public const string LicenseTypeEnterprise = "Enterprise";
      public const string LicenseNoExpirationDate = "None";
      public const string LicenseExpired = "License Expired";

      public const int ExpirationDayToWarnProduction = 45;
      public const int ExpirationDayToWarnTrial = 7;

      public const string RegistryHiveLicensing = "IDEBT";

      // Product Dependant constants
      public const int ProductID = 2400;
      public const string ProductVersion = "2.0"; // not used in license check for 1.1
      
      public const string LicenseFile = "LicenseKey.Lic";
   }

   public static class LicenseErrorMsgs
   {
      // SQL admin toolset License
      public const string LicenseCaption = "SQL admin toolset License";
      public const string LicenseInvalid = "The license key provided ({0}) is an invalid license key.";
      public const string LicenseInvalidMachine = "The license key you entered is for a different computer. Contact Idera to obtain a license for this computer: {0}.";
      public const string LicenseInvalidProductID = "This is not a license for SQL admin toolset.  Contact Idera to obtain a license for this product.";

      public const string LicenseInvalidProductVersion =
         "This license is invalid for this version of SQL admin toolset. Contact Idera to obtain a license for this version: {0}";

      public const string LicenseExpired = "This license has expired.";
      public const string LicenseExpiring = "The license {0} will expire in {1} days.";

      public const string LicenseNoValidLicense =
         "SQL admin toolset is not licensed. You must have a valid license to run SQL admin toolset."
         + "\n\nPlease contact Idera to obtain a valid license for SQL admin toolset.";

      public const string LicenseAddTitle = "Add New License";
      public const string LicenseAddHeading = "Add License for SQL admin toolset";
      public const string LicenseAddSubHeading = "Enter new license key:";

      public const string LicenseTrialExpiredText =
         "The SQL admin toolset trial license has expired. SQL admin toolset requires a valid license. Please enter your production license.";
   }

   #endregion

   public class BBSProductLicense
   {
      private static Logger logX = Logger.GetLogger("SqlAdminToolsetCore.License");

      #region Data Structs

      // Handy structure for passing information back to "Manage Licenses" form
      public  struct LicenseData
      {
         public LicenseState licState;
         public string key;
         public bool isTrial;
         public string typeStr;
         public string forStr;
         public string expirationDateStr;
         public string daysToExpireStr;
         public int daysToExpire;
         public bool isAboutToExpire;
         public bool isExpired;
         public override string ToString()
         {
            return key;
         }

         public void Initialize()
         {
            licState = LicenseState.InvalidKey;
            isTrial = true;
            key = string.Empty;
            daysToExpireStr = string.Empty;
            expirationDateStr = string.Empty;
            forStr = string.Empty;
            typeStr = string.Empty;
            daysToExpire = 0;
            isAboutToExpire = false;
         }
      }


      // License error codes, allows UI to provide more meaningful messages
      public enum LicenseState
      {
         Valid,
         InvalidKey,
         InvalidProductID,
         InvalidScope,
         InvalidExpired,
         InvalidProductVersion,
         InvalidLength,
         Expired
      }

      #endregion

      #region Properties

      public  LicenseData licenseData;
        public static string licenseKey = string.Empty;
        private string m_scopeString;
       
      public string OrginalScopeString
      {
         get { return m_scopeString; }
      }
        public static LicenseState Status = LicenseState.InvalidKey;
       private Version m_productVersion;

      #endregion

      #region CTOR

      public
         BBSProductLicense(
            Version productVersion,
            string licenseKey
         )
      {
         m_scopeString = CleanseScopeString( System.Net.Dns.GetHostName() );
         Debug.Assert(!string.IsNullOrEmpty(m_scopeString));

         m_productVersion = productVersion;

         licenseData = new LicenseData();
         licenseData.Initialize();

         if ( licenseKey != "" )
         {
            FillLicenseData( licenseKey );
         }
      }

      #endregion

      #region Public Methods

      public string GetErrorMessage()
      {
          return GetErrorMessage(licenseData.licState, string.Empty);
      }

      public string GetErrorMessage(LicenseState licState, string licenseStr)
      {
         switch (licState)
         {
            case LicenseState.InvalidKey:
               return string.Format(LicenseErrorMsgs.LicenseInvalid, licenseStr);

            case LicenseState.InvalidExpired:
               return string.Format(LicenseErrorMsgs.LicenseExpired);

            case LicenseState.InvalidProductID:
               return string.Format(LicenseErrorMsgs.LicenseInvalidProductID);

            case LicenseState.InvalidProductVersion:
                return string.Format(LicenseErrorMsgs.LicenseInvalidProductVersion, Assembly.GetExecutingAssembly().GetName().Version.ToString());

            case LicenseState.InvalidScope:
                  return string.Format(LicenseErrorMsgs.LicenseInvalidMachine, CoreGlobals.hostComputer);

            default:
               return string.Format(LicenseErrorMsgs.LicenseInvalid, licenseStr);
         }
      }

      // Check to see if SQLdefrag is licensed
      public bool IsProductLicensed()
      {
          return (licenseData.licState == LicenseState.Valid);
      }

      // Check if the given string is a valid trial license
      // UI calls this before accepting license string
      public bool IsLicenseStringTrial(string licenseStr)
      {
         if (string.IsNullOrEmpty(licenseStr)) return false;

         BBSLic lic = new BBSLic();
         LicErr rc = lic.LoadKeyString(licenseStr);

         if (rc != LicErr.OK) return false;

         LicenseState licState = IsLicenseValid(lic, licenseStr);

         if (licState != LicenseState.Valid) return false;

         return lic.IsTrial;
      }

      // Check if the given string is a valid license
      // UI calls this before accepting license string
      public bool IsLicenseStringValid(string license, out LicenseState licState)
      {
         licState = LicenseState.InvalidKey;

         if (string.IsNullOrEmpty(license)) return false;

         BBSLic lic = new BBSLic();
         LicErr rc = lic.LoadKeyString(license);
         if (rc != LicErr.OK) return false;

         // check for hacked license
         if ( ! IsLicenseReasonable( lic ) ) return false;

         licState = IsLicenseValid(lic, license);

         return licState == LicenseState.Valid ? true : false;
      }

       //---------------------------------------------------------------------
       // IsLicenseReasonable - Our license key checksum is not solid so
       //                       you can change characters in the key and
       //                       still have a valid license. This could allow
       //                       a customer to bump up their license cound.
       //                       However the changes always create unresonable 
       //                       licenses like 1000s of seats. To avoid
       //                       problems of upgrading license DLL we just are
       //                       putting in a reasonableness check in the products
      //---------------------------------------------------------------------
       private static bool IsLicenseReasonable(BBSLic license)
       {
           // Trials only valid for 0-90 days
           if (license.IsTrial)
            {
                if (license.IsPermanent) return false;
                if (license.DaysToExpiration < 0) return false;
               // if (license.DaysToExpiration > 90) return false;
            }
            else // Purchase license only valid for 0-400 days or unlimited (unlimited means its a permanent license)
            {
                if (license.DaysToExpiration < 0) return false;
                if (license.DaysToExpiration > 400 && !(license.IsPermanent)) return false;
            }
            // Purchase license only valid for 0-400 days or unlimited
            if (license.IsPermanent)
           {
               if (license.DaysToExpiration < 0) return false;
              // if (license.DaysToExpiration > 400 && license.DaysToExpiration != 65535) return false;
           }
            if (license.IsEnterprise && license.IsPermanent) return false;
            //    if (!license.IsTrial && !license.IsPermanent) return false;


            // License only good for up to 500 licenses
            //if (license.Limit1 < 0) return false;
            //if (license.Limit1 > 500) return false;
            //if (license.Limit2 < -2 || license.Limit2 >1) return false; // some products code limit 2 as 1 instead of unlimited

            return true;
       }


      #endregion

      #region Helpers

      private static string CleanseScopeString(string scope)
      {
         if (string.IsNullOrEmpty(scope)) return string.Empty;

         // not much to do here since we are computer name and not instance name

         return scope.ToUpper();
      }

      private static byte[] PW()
      {
         Process currentProcess = Process.GetCurrentProcess();
         string data = currentProcess.MachineName + currentProcess.Id;
            return BBSLic.GetHash(data);
            //SHA1 sha1 = new SHA1Managed();
            //UnicodeEncoding ue = new UnicodeEncoding();

            //return sha1.ComputeHash(ue.GetBytes(data));
        }

      // Returns display string for the scope
      // License is validated when class is instanciated.
      // Since license is valid then scope is either enterprise or current computer
      private string GetLicenseScopeStr(BBSLic bbsLic)
      {
         if (bbsLic == null) return string.Empty;

         if (bbsLic.IsEnterprise) return BBSLicenseConstants.LicenseTypeEnterprise;

         return m_scopeString;
      }

      // Returns display string for type (Production or Trial)
      private static string GetLicenseTypeStr(BBSLic bbsLic)
      {
         if (bbsLic == null) return string.Empty;

         if (bbsLic.IsTrial) return BBSLicenseConstants.LicenseTypeTrial;

         return BBSLicenseConstants.LicenseTypeProduction;
      }

      // Returns display string for expiration date (None if no expiration)
      private static string GetLicenseExpirationDateStr(BBSLic bbsLic)
      {
         if (bbsLic == null) return string.Empty;

         if (bbsLic.IsPermanent) return BBSLicenseConstants.LicenseNoExpirationDate;

         return bbsLic.ExpirationDate.ToShortDateString();
      }

      // Returns display string for days to expiration or None if no expiration date
      private static string GetLicenseDaysToExpirationStr(BBSLic bbsLic)
      {
         if (bbsLic == null) return string.Empty;

         if (bbsLic.IsPermanent) return BBSLicenseConstants.LicenseNoExpirationDate;

         if (bbsLic.IsExpired) return BBSLicenseConstants.LicenseExpired;

         return bbsLic.DaysToExpiration.ToString();
      }

      private static int GetLicenseCount(BBSLic bbsLic)
      {
         if (bbsLic == null) return 0;

         return bbsLic.Limit1;
      }

      private static bool IsLicenseTrial(BBSLic bbsLic)
      {
         if (bbsLic == null) return false;

         return bbsLic.IsTrial;
      }

      // Fill the LicenseData structure with information about this license key
      private void FillLicenseData(string licenseKey)
      {
         if (string.IsNullOrEmpty(licenseKey)) return;

         BBSLic bbsLic;
         licenseData.Initialize();
         licenseData.licState = LoadAndValidateLicense(licenseKey, out bbsLic);
         Status = licenseData.licState;
         if (bbsLic == null) return;
         
         licenseData.isTrial = IsLicenseTrial(bbsLic);
         licenseData.key = licenseKey;
         licenseData.forStr = GetLicenseScopeStr(bbsLic);
         licenseData.typeStr = GetLicenseTypeStr(bbsLic);
         licenseData.expirationDateStr = GetLicenseExpirationDateStr(bbsLic);
         licenseData.daysToExpireStr = GetLicenseDaysToExpirationStr(bbsLic);
         licenseData.daysToExpire = bbsLic.DaysToExpiration;
          licenseData.isExpired=  bbsLic.IsExpired;
         licenseData.isAboutToExpire = (licenseData.typeStr == BBSLicenseConstants.LicenseTypeProduction &&
                                        licenseData.daysToExpire <= BBSLicenseConstants.ExpirationDayToWarnProduction ||
                                        licenseData.typeStr == BBSLicenseConstants.LicenseTypeTrial &&
                                        licenseData.daysToExpire <= BBSLicenseConstants.ExpirationDayToWarnTrial);
            CoreGlobals.BBSLic = bbsLic;
            if (licenseKey != "2.0")
                BBSProductLicense.licenseKey = licenseKey;
            else
                BBSProductLicense.licenseKey = "";
      }

      // Checks if license is valid for SQLadmintoolset
      // Checks ProductID, Version, Scope, Expiration, Is Duplicate
      private LicenseState IsLicenseValid(BBSLic lic, string licenseKey)
      {
         if (lic == null) return LicenseState.InvalidKey;

         // Is the product ID for SQLadmintoolset
         if (!IsLicenseProductIDValid(lic))
            return LicenseState.InvalidProductID;

            // Is it registered for this computer or enterprise
            if (!IsLicenseScopeValid(lic))
                return LicenseState.InvalidScope;

            // Is license expired
            if (lic.IsExpired)
            return LicenseState.InvalidExpired;

         return LicenseState.Valid;
      }

      // Is the scope hash valid for our repository
      private bool IsLicenseScopeValid(BBSLic lic)
      {
         if (lic == null) return false;

         return (lic.IsEnterprise || lic.CheckScopeHash(m_scopeString));
      }

      // Is the ProductID valid for SQLdefrag
      private bool IsLicenseProductIDValid(BBSLic lic)
      {
         if (lic == null) return false;

         return (lic.ProductID == BBSLicenseConstants.ProductID);
      }

      private LicenseState LoadAndValidateLicense(string license, out BBSLic bbsLic)
      {
            bbsLic = new BBSLic();
            LicErr rc = bbsLic.LoadKeyString(license);
            if (rc == LicErr.OK)
                return IsLicenseValid(bbsLic, license);
            else if (rc == LicErr.InvalidLength)
                return LicenseState.InvalidLength;
            else if (rc == LicErr.ChecksumError)
                return LicenseState.InvalidLength;
            else
                return LicenseState.InvalidKey;
        }

      #endregion

      #region Persistence Functions

      //-----------------------------------------------------
      // ReadProductLicense - Read license from product hive
      //-----------------------------------------------------
      static internal string
         ReadProductLicense()
      {
          string licenseKey = "";
          
          string folder      = Helpers.GetSuiteDirectory(true);
          string licenseFile = Path.Combine( folder, BBSLicenseConstants.LicenseFile);
          
          if ( File.Exists( licenseFile ) )
          {
             string encryptedLicense = "";
             
             try
             {
                using (TextReader textReader = new StreamReader(licenseFile))
                {
                   // read
                   encryptedLicense = textReader.ReadLine();
                   
                   // Decrypt
                   if ( ! String.IsNullOrEmpty(encryptedLicense) && encryptedLicense.Length>50) 
                   {
                      licenseKey = EncryptionHelper.QuickDecrypt(encryptedLicense);
                   }
                        else
                        {
                            licenseKey = encryptedLicense;
                        }
                   textReader.Close();
                }
             }
             catch
             {
                licenseKey = "";
             }
          }

          return licenseKey;
      }

      static internal void DeleteLicenseInfo()
      {
         string folder      = Helpers.GetSuiteDirectory(true);
         string licenseFile = Path.Combine( folder, BBSLicenseConstants.LicenseFile);
         RegistryKey rk = null;

         try
         {
            File.Delete(licenseFile);
         }
         catch { }

         try
         {
                if (SecurityRole.IsLocalAdmin())
                    rk = Registry.LocalMachine;
                else
                    rk = Registry.CurrentUser;
                rk.DeleteSubKey(CoreGlobals.licenseRegistryKey, false);
         }
         catch { }
      }

      //-----------------------------------------------------
      // WriteProductLicense - Write license to product hive
      //-----------------------------------------------------
      static internal void
        WriteProductLicense(
           string   newLicenseKey
        )
      {
          string folder      = Helpers.GetSuiteDirectory(true);
          string licenseFile = Path.Combine( folder, BBSLicenseConstants.LicenseFile);
          
          if ( File.Exists( licenseFile ) )
          {
             try
             {
                File.Delete( licenseFile );
             }
             catch ( Exception ex )
             {
                // cant delete = cant update license
                CoreGlobals.traceLog.ErrorFormat( "WriteProductLicense - error deleting existing license file, " +
                                                  "unable to update license file: {0}", ex.Message );
                return;                                                  
             }
          }
          
          if ( ! String.IsNullOrEmpty(newLicenseKey) )
          {
                string encryptedLicense = string.Empty;
                try
                {
                    encryptedLicense = EncryptionHelper.QuickEncrypt(newLicenseKey);
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("FIPS"))
                    {
                        encryptedLicense = newLicenseKey;
                    }
                    else
                    {
                        throw;
                    }
                }
                try
                {
                    using (TextWriter textWriter = new StreamWriter(licenseFile))
                    {
                        textWriter.WriteLine(encryptedLicense);
                        textWriter.Close();
                    }
                }

                catch (Exception ex)
                {
                    Messaging.ShowError("Unable to write the license key. The new license key will take effect only " +
                                         "for this execution of this tool. Correct the problem that caused this " +
                                         "failure to allow license keys to be written permanently.\r\n\r\nError: " +
                                         ex.Message);

                    CoreGlobals.traceLog.ErrorFormat("WriteProductLicense - error writing license file, " +
                                                      "unable to update license file: {0}", ex.Message);
                }

            }
      }

      //-----------------------------------------------------
      // ReadProductLicense - Read license from product hive
      //-----------------------------------------------------
      static internal string
         ReadProductLicenseFromRegistry()
      {
          string licenseKey = "";
          RegistryKey rk = null;
          RegistryKey rks = null;

          try
          {
                if (SecurityRole.IsLocalAdmin())
                    rk = Registry.LocalMachine;
                else
                    rk = Registry.CurrentUser;
                rks = rk.CreateSubKey(CoreGlobals.licenseRegistryKey);

                string encryptedKey = (string)rks.GetValue(CoreGlobals.licenseRegistryValue, "");
                if (encryptedKey == "")
                {
                    if (rk == Registry.LocalMachine)
                    {
                        rk = Registry.CurrentUser;
                        rks = rk.CreateSubKey(CoreGlobals.licenseRegistryKey);

                        encryptedKey = (string)rks.GetValue(CoreGlobals.licenseRegistryValue, "");
                        if (encryptedKey != "")
                        {
                            licenseKey = EncryptionHelper.QuickDecrypt(encryptedKey);
                        }
                        else
                        {
                            licenseKey = "";
                        }
                    }
                    else
                    {
                        licenseKey = "";
                    }
                }
                else
                    licenseKey = EncryptionHelper.QuickDecrypt(encryptedKey);

            }
          catch (Exception ex)
          {
              logX.ErrorFormat("ReadProductLicense error: {0}", ex.Message);
          }
          finally
          {
              if (rks != null) rks.Close();
              if (rk != null) rk.Close();
          }

          return licenseKey;
      }

      //-----------------------------------------------------
      // WriteProductLicense - Write license to product hive
      //-----------------------------------------------------
      static internal void
        WriteProductLicenseFromRegistry(
           string   newLicenseKey
        )
      {
          RegistryKey rk = null;
          RegistryKey rks = null;

          try
          {
                if (SecurityRole.IsLocalAdmin())
                {
                    rk = Registry.LocalMachine;
                    rks = rk.CreateSubKey(CoreGlobals.licenseRegistryKey);

                    string encryptedKey = EncryptionHelper.QuickEncrypt(newLicenseKey);
                    rks.SetValue(CoreGlobals.licenseRegistryValue, encryptedKey);
                    rk = Registry.CurrentUser;
                    rks = rk.CreateSubKey(CoreGlobals.licenseRegistryKey);

                    encryptedKey = EncryptionHelper.QuickEncrypt(newLicenseKey);
                    rks.SetValue(CoreGlobals.licenseRegistryValue, encryptedKey);
                }
                else
                {
                    rk = Registry.CurrentUser;
                    rks = rk.CreateSubKey(CoreGlobals.licenseRegistryKey);

                    string encryptedKey = EncryptionHelper.QuickEncrypt(newLicenseKey);
                    rks.SetValue(CoreGlobals.licenseRegistryValue, encryptedKey);
                }
          }
          catch (Exception ex)
          {
              logX.ErrorFormat("WriteProductLicense error: {0}", ex.Message);
          }
          finally
          {
              if (rks != null) rks.Close();
              if (rk != null) rk.Close();
          }
      }


      #endregion

      #region Trial License Handling

      //--------------------------------------------------------------------------------------------------
      // ReadTrialLicense - Check special registry location to see if trial has been used for this server
      //                    if it has return the old license key so we can reuse if it hasnt expired
      //--------------------------------------------------------------------------------------------------
      static internal string ReadTrialLicense()
      {
          string oldKey = "";
          RegistryKey hkSoftware = null;
          RegistryKey hkMicrosoft = null;
          RegistryKey hkLicensing = null;

          try
          {
              RegistryKey hklm = null;
                if (SecurityRole.IsLocalAdmin())
                    hklm = Registry.LocalMachine;
                else
                    hklm = Registry.CurrentUser;
                //hkSoftware = hklm.OpenSubKey("SOFTWARE");
                //hkMicrosoft = hkSoftware.OpenSubKey("Microsoft", true);
                //string key = BBSLicenseConstants.RegistryHiveLicensing + BBSLicenseConstants.ProductID + BBSLicenseConstants.ProductVersion;
                hkLicensing = hklm.OpenSubKey(CoreGlobals.licenseRegistryKey, true);

                if (hkLicensing == null)
                {
                    oldKey = "";
                    if (hklm == Registry.LocalMachine)
                    {
                        hklm = Registry.CurrentUser;
                        hkLicensing = hklm.OpenSubKey(CoreGlobals.licenseRegistryKey, true);

                        if (hkLicensing == null)
                            oldKey = "";
                        string encryptedKey = (string)hkLicensing.GetValue(CoreGlobals.licenseTrialRegistryValue, "");
                        if (encryptedKey == "")
                        {
                            hkLicensing = hkLicensing.OpenSubKey(CoreGlobals.trialRegistryKey);
                            if (hkLicensing == null)
                                oldKey = "";
                            else
                                oldKey = (string)hkLicensing.GetValue(CoreGlobals.trialRegistryKey, "");
                        }
                        else
                        {
                            oldKey = EncryptionHelper.QuickDecrypt(encryptedKey);

                        }
                    }
                }
                else
                {
                    string encryptedKey = (string)hkLicensing.GetValue(CoreGlobals.licenseTrialRegistryValue, "");
                    if (encryptedKey == "")
                    {
                        hkLicensing = hkLicensing.OpenSubKey(CoreGlobals.trialRegistryKey);
                        if (hkLicensing == null)
                        {
                            if (hklm == Registry.LocalMachine)
                            {
                                hklm = Registry.CurrentUser;
                                hkLicensing = hklm.OpenSubKey(CoreGlobals.licenseRegistryKey, true);

                                if (hkLicensing == null)
                                    oldKey = "";
                                encryptedKey = (string)hkLicensing.GetValue(CoreGlobals.licenseTrialRegistryValue, "");
                                if (encryptedKey == "")
                                {
                                    hkLicensing = hkLicensing.OpenSubKey(CoreGlobals.trialRegistryKey);
                                    if (hkLicensing == null)
                                        oldKey = "";
                                    else
                                        oldKey = (string)hkLicensing.GetValue(CoreGlobals.trialRegistryKey, "");
                                }
                                else
                                {
                                    oldKey = EncryptionHelper.QuickDecrypt(encryptedKey);

                                }

                            }
                            else
                            {
                                oldKey = "";
                            }
                        }
                        else
                            oldKey = (string)hkLicensing.GetValue(CoreGlobals.trialRegistryKey, "");
                    }
                    else
                    {
                        oldKey = EncryptionHelper.QuickDecrypt(encryptedKey);
                    }
                }
            }
            catch (Exception ex)
            {
                // if we dont have permissions to read/write this entry we just let trials be generated
                // better to err on side of leting someone who wants to use the project use it then
                // stopping pirates who will never pay anyway
                oldKey = "";

                logX.ErrorFormat("ReadTrialLicense: {0}", ex.Message);
            }
            finally
            {
                if (hkSoftware != null) hkSoftware.Close();
                if (hkMicrosoft != null) hkMicrosoft.Close();
                if (hkLicensing != null) hkLicensing.Close();
            }

            return oldKey;
        }

      //-----------------------------------------------------------------------------------------
      // GenerateTrialLicense - Generate a trial license and mark registry that we generated one
      //-----------------------------------------------------------------------------------------
       static internal string GenerateTrialLicense()
      {
          string newLicenseKey = "";

          try
          {
              BBSLic lic = new BBSLic();

              lic.IsTrial = true;
              lic.KeyID = 0;
              lic.DaysToExpiration = CoreGlobals.License!=null?CoreGlobals.License.DaysToExpire:14;
                if (lic.DaysToExpiration == 0)
                {
                    var date = DateTime.Now.AddDays(-14);
                    lic.SetExpirationDate((uint)date.Year, (uint)date.Month, (uint)date.Day);
                }
              lic.ProductID = (short)BBSLicenseConstants.ProductID;
              lic.SetScopeHash(System.Net.Dns.GetHostName());
              lic.Limit1 = 1;
              lic.Limit2 = 1;
              lic.ProductVersion = new Version( 1, 9 );

              newLicenseKey = lic.GetKeyString(PW());

              WriteProductLicense(newLicenseKey);
              WriteTrialLicense(newLicenseKey);
          }
          catch ( Exception ex )
          {
              logX.ErrorFormat("GenerateTrialLicense error: {0}", ex.Message);
          }

          return newLicenseKey;
      }
        static internal string GenerateLicense()
        {
            string newLicenseKey = "";

            try
            {
                BBSLic lic = new BBSLic();

                lic.IsTrial = false;
                lic.KeyID = 0;
                lic.SetScopeHash(System.Net.Dns.GetHostName());

                //lic.DaysToExpiration = 14;
                lic.ProductID = (short)BBSLicenseConstants.ProductID;
                lic.Limit1 = 1;
                lic.Limit2 = 1;
                lic.ProductVersion = new Version(1, 9);
                if(CoreGlobals.License.IsPermanent)
                {
                    lic.MakePermanent();

                }
                else
                {
                    lic.DaysToExpiration = CoreGlobals.License.DaysToExpire;
                    
                }
                newLicenseKey = lic.GetKeyString(PW());
                
                WriteProductLicense(newLicenseKey);
                WriteProductLicenseFromRegistry(newLicenseKey);
            }
            catch (Exception ex)
            {
                logX.ErrorFormat("GenerateTrialLicense error: {0}", ex.Message);
            }

            return newLicenseKey;
        }
        //-----------------------------------------------------------------------------------------
        // GenerateBetaLicense - Generate a beta license with a drop dead date and mark
        //                       registry that we generated one
        //-----------------------------------------------------------------------------------------
        static internal string GenerateBetaLicense( DateTime betaDropDeadDate )
      {
         string newLicenseKey = "";

         try
         {
            // cant generate beta licenses after beta license end date 
            if ( DateTime.Now.CompareTo( betaDropDeadDate ) < 0 )
            {
               // still before date - allow a license to be generated
               BBSLic lic = new BBSLic();

               lic.IsTrial = true;
               lic.KeyID = 0;

               lic.ExpirationDate = betaDropDeadDate;
               //lic.DaysToExpiration = 14;

               lic.ProductID = (short)BBSLicenseConstants.ProductID;
               lic.SetScopeHash( System.Net.Dns.GetHostName() );
               lic.Limit1 = 1;
               lic.Limit2 = 1;
               lic.ProductVersion = new Version( 1, 1 );

               newLicenseKey = lic.GetKeyString( PW() );

               WriteProductLicense( newLicenseKey );
               WriteTrialLicense( newLicenseKey );
            }
         }
         catch ( Exception ex )
         {
            logX.ErrorFormat( "GenerateTrialLicense error: {0}", ex.Message );
         }

         return newLicenseKey;
      }

      //------------------------------------------------------------------------------------------------
      // WriteTrialLicense - Write to special registry location that trial has been used on this server
      //------------------------------------------------------------------------------------------------
       static internal void
          WriteTrialLicense(string newLicenseKey)
      {
          RegistryKey hkSoftware = null;
          RegistryKey hkMicrosoft = null;
          RegistryKey hkLicensing = null;

          try
          {
              using (logX.InfoCall())
              {
                    RegistryKey hklm = null;
                    if (SecurityRole.IsLocalAdmin())
                        hklm = Registry.LocalMachine;
                    else
                        hklm = Registry.CurrentUser;
                    //hkSoftware = hklm.OpenSubKey("SOFTWARE");
                    //hkMicrosoft = hkSoftware.OpenSubKey("Microsoft", true);
                    //string key = BBSLicenseConstants.RegistryHiveLicensing + BBSLicenseConstants.ProductID + BBSLicenseConstants.ProductVersion;
                    hkLicensing = hklm.CreateSubKey(CoreGlobals.licenseRegistryKey);
                  string encryptedKey = EncryptionHelper.QuickEncrypt(newLicenseKey);
                  hkLicensing.SetValue(CoreGlobals.licenseTrialRegistryValue, encryptedKey);
                  hkLicensing = hkLicensing.CreateSubKey(CoreGlobals.trialRegistryKey);
             
                  hkLicensing.SetValue(CoreGlobals.trialRegistryKey,"2.0");
                    if(hklm==Registry.LocalMachine)
                    {
                        if (hkLicensing != null) hkLicensing.Close();
                        hklm = Registry.CurrentUser;
                        hkLicensing = hklm.CreateSubKey(CoreGlobals.licenseRegistryKey);
                        encryptedKey = EncryptionHelper.QuickEncrypt(newLicenseKey);
                        hkLicensing.SetValue(CoreGlobals.licenseTrialRegistryValue, encryptedKey);
                        hkLicensing = hkLicensing.CreateSubKey(CoreGlobals.trialRegistryKey);
                    }
              }
          }
          catch (Exception ex)
          {
              // if dont have permissions to write, we just continue on - we dont care that much
              logX.ErrorFormat("TagTrialLicenseUsed: {0}", ex.Message);
          }
          finally
          {
              if (hkSoftware != null) hkSoftware.Close();
              if (hkMicrosoft != null) hkMicrosoft.Close();
              if (hkLicensing != null) hkLicensing.Close();
          }
      }

        public static void AddLicenseKey(string newLicenseKey)
        {
            string oldLicensekey = BBSProductLicense.licenseKey;
            LicenseState status = BBSProductLicense.Status;
            bool ispermanent = CoreGlobals.BBSLic.IsPermanent;
            DateTime expirationDate = CoreGlobals.BBSLic.ExpirationDate;
            bool isTrial = CoreGlobals.BBSLic.IsTrial;
            var BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                                  newLicenseKey);
            string msg = string.Empty;
            var lic = CoreGlobals.BBSLic;
            if(BBSLicense.licenseData.licState==LicenseState.Valid)
            {
                if (lic.ProductID != BBSLicenseConstants.ProductID)
                {
                   msg= "Key is for another product.";
                }
                else if (!lic.IsEnterprise && !lic.CheckScopeHash(System.Net.Dns.GetHostName()))
                {
                   msg = string.Format("Key is not for repository '{0}'.", System.Net.Dns.GetHostName());
                }
                else if (!IsLicenseReasonable(lic))
                {
                    msg = "License Key is invalid. Please enter a valid License Key.";
                }
                else if (status== LicenseState.Valid && !lic.IsPermanent && expirationDate > lic.ExpirationDate)
                {
                    msg= "Existing license cannot be replaced by a new license with earlier expiration date.";
                }
                else if(lic.IsTrial && !isTrial)
                {
                    msg = "Existing production license cannot be replaced by a trial license.";

                }

                if (msg != string.Empty)
                {
                    BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                                   oldLicensekey);
                    Core.Messaging.ShowError(msg);
                }
                else
                {
                    WriteProductLicense(newLicenseKey);
                    WriteProductLicenseFromRegistry(newLicenseKey);
                }
            }
            else if(BBSLicense.licenseData.licState==LicenseState.InvalidLength)
            {
                msg="Key is not a valid license key.";
                BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                                 oldLicensekey);
                Core.Messaging.ShowError(msg);
            }
            else if (BBSLicense.licenseData.licState == BBSProductLicense.LicenseState.InvalidProductID)
            {
                msg = "Key is for another product.";
                BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                                  oldLicensekey);
                Core.Messaging.ShowError(msg);
            }
            else if (!lic.IsEnterprise && !lic.CheckScopeHash(System.Net.Dns.GetHostName()))
            {
                msg = string.Format("Key is not valid for '{0}'.", System.Net.Dns.GetHostName());
                BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                                oldLicensekey);
                Core.Messaging.ShowError(msg);
            }
            else if (!IsLicenseReasonable(lic))
            {
                msg = "License Key is invalid. Please enter a valid License Key.";
                BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                                oldLicensekey);
                Core.Messaging.ShowError(msg);
            }
            else if (status == LicenseState.Valid && !lic.IsPermanent && expirationDate > lic.ExpirationDate)
            {
                msg = "Existing license cannot be replaced by a new license with earlier expiration date.";
                BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                                oldLicensekey);
                Core.Messaging.ShowError(msg);
            }
            else
            {
                msg = "License Key is invalid. Please enter a valid License Key.";
                BBSLicense = new BBSProductLicense(Assembly.GetExecutingAssembly().GetName().Version,
                                                                    oldLicensekey);
                Core.Messaging.ShowError(msg);
            }
        }

        #endregion
    }
}