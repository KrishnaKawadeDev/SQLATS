using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    class IndexViewMode
    {
        public delegate int GetCriticalIndexesDelagate(object obj);
        public delegate int GetCautionIndexesDelagate(object obj);
        public delegate int GetAcceptableIndexesDelagate(object obj);

        private GetCriticalIndexesDelagate _GetCriticalIndexesDelegate;
        private GetCautionIndexesDelagate _GetCautionIndexesDelegate;
        private GetAcceptableIndexesDelagate _GetAcceptableIndexesDelegate;

        private string _viewMode;
        private string _groupBoxText;
        private string _criticalText;        
        private string _cautionText;
        private string _acceptableText;
        private double _criticalPercent;
        private double _acceptablePercent;
        private string _helpText;
        private string _helpTitle;

        public override string ToString()
        {
            return _viewMode;
        }

        public string ViewMode
        {
            get { return _viewMode; }
            set { _viewMode = value; }
        }
        public string GroupBoxText
        {
            get { return _groupBoxText; }
            set { _groupBoxText = value; }
        }
        public string CriticalText
        {
            get { return _criticalText; }
            set { _criticalText = value; }
        }
        public string CautionText
        {
            get { return _cautionText; }
            set { _cautionText = value; }
        }
        public string AcceptableText
        {
            get { return _acceptableText; }
            set { _acceptableText = value; }
        }
        public double CriticalPercent
        {
            get { return _criticalPercent; }
            set { _criticalPercent = value; }
        }
        public double AcceptablePercent
        {
            get { return _acceptablePercent; }
            set { _acceptablePercent = value; }
        }
        public string HelpText
        {
            get { return _helpText; }
            set { _helpText = value; }
        }
        public string HelpTitle
        {
            get { return _helpTitle; }
            set { _helpTitle = value; }
        }


        public GetCriticalIndexesDelagate GetCritcalIndexesDelegate
        {
            set { _GetCriticalIndexesDelegate = new GetCriticalIndexesDelagate(value); }
        }
        public GetCautionIndexesDelagate GetCautionIndexesDelegate
        {
            set { _GetCautionIndexesDelegate = new GetCautionIndexesDelagate(value); }
        }
        public GetAcceptableIndexesDelagate GetAcceptableIndexesDelegate
        {
            set { _GetAcceptableIndexesDelegate = new GetAcceptableIndexesDelagate(value); }
        }

        public int GetCriticalIndexes(object obj)
        {
            int ret = 0;
            if (_GetCriticalIndexesDelegate != null)
            {
                ret = _GetCriticalIndexesDelegate(obj);
            }
            return ret;
        }
        public int GetCautionIndexes(object obj)
        {
            int ret = 0;
            if (_GetCautionIndexesDelegate != null)
            {
                ret = _GetCautionIndexesDelegate(obj);
            }
            return ret;
        }
        public int GetAcceptableIndexes(object obj)
        {
            int ret = 0;
            if (_GetAcceptableIndexesDelegate != null)
            {
                ret = _GetAcceptableIndexesDelegate(obj);
            }
            return ret;
        }
    }
}
