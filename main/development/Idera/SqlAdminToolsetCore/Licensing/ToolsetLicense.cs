using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BBS.License;
using DeployLX.Licensing.v5;


namespace Idera.SqlAdminToolset.Core.Licensing
{
    public class ToolsetLicense
    {
        public string SerialNumber { get; set; }


        public string LicenseType { get; set; }

        public bool IsExpired { get; set; }

        public string LimitCode { get; set; }

        public bool IsTrial { get; set; }

        public bool IsBeta { get; set; }

        public bool IsActivated { get; set; }

        public bool IsUnlimited { get; set; }

        public bool IsPermanent { get; set; }

        public int Limit { get; set; }

        public int DaysToExpire { get; set; }

        public string Expiration { get; set; }
        public static ToolsetLicense FromSecureLicense(SecureLicense license)
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                try
                {

                    var daysToExp = 0;
                    if (CoreGlobals.SecureLicense != null)
                    {
                        if (CoreGlobals.SecureLicense.IsTrial || CoreGlobals.SecureLicense.SerialNumber.StartsWith("SPC"))
                        {
                            var timeMonitor = CoreGlobals.SecureLicense.GetTimeMonitor();

                            if (timeMonitor != null)
                                daysToExp = (int)decimal.Ceiling((decimal)timeMonitor.TimeRemaining.TotalDays);
                        }

                        return new ToolsetLicense
                        {

                            DaysToExpire = daysToExp,
                            IsActivated = CoreGlobals.SecureLicense.IsActivated,
                            IsBeta = CoreGlobals.betaCopy,
                            IsExpired = daysToExp <= 0,
                            IsPermanent = !CoreGlobals.SecureLicense.IsTrial? !CoreGlobals.SecureLicense.SerialNumber.StartsWith("SPC"):false,
                            IsTrial = CoreGlobals.SecureLicense.IsTrial,
                            LicenseType = CoreGlobals.SecureLicense.Type,
                            LimitCode = LicenseUI.GetLimitCode(),
                            SerialNumber = CoreGlobals.SecureLicense.SerialNumber

                        };
                    }
                }
                catch (Exception e)
                {
                    //ignor
                }
                return null;
                //return new ToolsetLicense
                //{
                //    DaysToExpire = 0,
                //    IsActivated = false,
                //    IsBeta = CoreGlobals.betaCopy,
                //    IsExpired = true,
                //    IsPermanent = false,
                //    IsTrial = true,
                //    LicenseType = "Trial"

                //};
            }
        }

        public static ToolsetLicense FromSecureLicense(BBSLic license)
        {
            using (CoreGlobals.traceLog.InfoCall())
            {
                try
                {

                    
                    if (license != null)
                    {


                        return new ToolsetLicense
                        {
                            Expiration = license.IsPermanent ? "Never" : license.ExpirationDate.ToShortDateString(),
                            DaysToExpire = license.DaysToExpiration < 0 ? 0 : license.DaysToExpiration,
                            IsActivated = CoreGlobals.activated,
                            IsBeta = CoreGlobals.betaCopy,
                            IsExpired = license.DaysToExpiration <= 0,
                            IsPermanent = !license.IsTrial,
                            IsTrial = license.IsTrial,
                            LicenseType = license.IsEnterprise ? BBSLicenseConstants.LicenseTypeEnterprise :license.IsTrial?BBSLicenseConstants.LicenseTypeTrial:BBSLicenseConstants.LicenseTypeProduction,
                            

                        };
                    }
                }
                catch (Exception e)
                {
                    //ignor
                }

                return new ToolsetLicense
                {
                    Expiration = DateTime.Now.AddDays(-14).ToShortDateString(),
                    DaysToExpire = 0,
                    IsActivated = false,
                    IsBeta = CoreGlobals.betaCopy,
                    IsExpired = true,
                    IsPermanent = false,
                    IsTrial = true,
                    LicenseType = "Trial"

                };
            }
        }
    }
}
