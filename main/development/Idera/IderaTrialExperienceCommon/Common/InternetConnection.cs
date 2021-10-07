using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using IderaTrialExperienceCommon.Dialogs;

namespace IderaTrialExperienceCommon.Common
{
    public class InternetConnection
    {
        private const string InternetTestUrl = @"http://idera.com";
        public static bool AvailableUrl(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(url))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Available()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead(InternetTestUrl))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool OpenWebPage(string webPageUrl, string errorMessageBoxTitle)
        {
            if (InternetConnection.Available())
            {
                if (!string.IsNullOrEmpty(webPageUrl)) System.Diagnostics.Process.Start(webPageUrl);
                return true;
            }
            var errorMsgBox = new InternetNotAvailableDialog(errorMessageBoxTitle, webPageUrl);
            errorMsgBox.ShowDialog();
            return false;
        }
    }
}
