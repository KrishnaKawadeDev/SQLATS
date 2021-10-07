using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace IderaTrialExperienceCommon.Common
{
    public sealed class LicenseInformationFieldNames
    {
        public const string SerialNumber = "SerialNumber";
        public const string LicenseType = "LicenseType";
        public const string IsExpired = "IsExpired";
        public const string LimitCode = "LimitCode";
        public const string IsTrial = "IsTrial";
        public const string IsBeta = "IsBeta";
        public const string IsActivated = "IsActivated";
        public const string IsUnlimited = "IsUnlimited";
        public const string IsPermanent = "IsPermanent";
        public const string Limit = "Limit";
        public const string DaysToExpire = "DaysToExpire";
    }
    public class LicenseInformation : INotifyPropertyChanged
    {
        private string _serialNumber;
        //private static string _licenseType;
        private string _licenseType;
        private bool _isExpired;
        private string _limitCode;
        private bool _isTrial;
        private bool _isBeta;
        private bool _isActivated;
        private bool _isUnlimited;
        private bool _isPermanent;
        private int _limit;
        private int _daysToExpire;
        //private SecureLicense _secureLicense = null;
        public string SerialNumber
        {
            get { return _serialNumber; }
            set
            {
                _serialNumber = value;
                OnPropertyChanged(LicenseInformationFieldNames.SerialNumber);
            }
        }


        public  string LicenseType
        {
            get { return _licenseType; }
            set
            {
                _licenseType = value;
                OnPropertyChanged(LicenseInformationFieldNames.LicenseType);
            }
        }

        //public static string LicenseTypeName
        //{
        //    get { return _licenseType; }
        //    set
        //    {
        //        _licenseType = value;
        //    }
        //}

        public bool IsExpired
        {
            get { return _isExpired && IsTrial; }
            set
            {
                _isExpired = value;
                OnPropertyChanged(LicenseInformationFieldNames.IsExpired);
            }
        }

        public string LimitCode
        {
            get { return _limitCode; }
            set
            {
                _limitCode = value;
                OnPropertyChanged(LicenseInformationFieldNames.LimitCode);
            }
        }

        public bool IsTrial
        {
            get { return _isTrial; }
            set
            {
                _isTrial = value;
                OnPropertyChanged(LicenseInformationFieldNames.IsTrial);
            }
        }

        public bool IsBeta
        {
            get { return _isBeta; }
            set
            {
                _isBeta = value;
                OnPropertyChanged(LicenseInformationFieldNames.IsBeta);
            }
        }

        public bool IsActivated
        {
            get { return _isActivated; }
            set
            {
                _isActivated = value;
                OnPropertyChanged(LicenseInformationFieldNames.IsActivated);
            }
        }

        public bool IsUnlimited
        {
            get { return _isUnlimited; }
            set
            {
                _isUnlimited = value;
                OnPropertyChanged(LicenseInformationFieldNames.IsUnlimited);
            }
        }

        public bool IsPermanent
        {
            get { return _isPermanent; }
            set
            {
                _isPermanent = value;
                OnPropertyChanged(LicenseInformationFieldNames.IsPermanent);
            }
        }

        public int Limit
        {
            get { return _limit; }
            set
            {
                _limit = value;
                OnPropertyChanged(LicenseInformationFieldNames.Limit);
            }
        }

        public int DaysToExpire
        {
            get { return _daysToExpire; } 
            set
            {
                _daysToExpire = value;
                OnPropertyChanged(LicenseInformationFieldNames.DaysToExpire);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
