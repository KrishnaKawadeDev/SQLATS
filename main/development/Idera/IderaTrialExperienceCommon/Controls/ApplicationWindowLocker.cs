using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using IderaTrialExperienceCommon.Common;

namespace IderaTrialExperienceCommon.Controls
{
    public class ApplicationWindowLocker
    {

        private static Dictionary<string, bool> _controlState;
        private static bool _isFormLocked;
        public Form ParentForm { get; set; }


        public void LockForm(Form parentForm, IderaTitleBar ideraTitleBar)
        {
            try
            {
                if (!_isFormLocked && parentForm!=null)
                {
                    GetCurrentFormControlsState(parentForm); //To prevent of unlocking controls that should be locked
                    foreach (Control control in parentForm.Controls)
                    {
                        if (control != ideraTitleBar) control.Enabled = false; //false
                    }
                    _isFormLocked = true;
                }
            }
            catch (Exception ex)
            {
                if (!TrailExCommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName,
                    string.Format("{0}\nStackTrace:\n{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }

        public void UnlockForm(Form parentForm)
        {
            try
            {
                if (_isFormLocked && parentForm!=null)
                {
                    foreach (Control control in parentForm.Controls)
                    {
                        if (_controlState != null && _controlState.ContainsKey(control.Name))
                        {

                            control.Enabled = _controlState[control.Name];
                        }
                        else control.Enabled = true;
                    }
                    _isFormLocked = false;
                }
            }
            catch (Exception ex)
            {
                if (!TrailExCommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName,
                    string.Format("{0}\nStackTrace:\n{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }

        private void GetCurrentFormControlsState(Form parentForm)
        {
            try
            {
                if (parentForm != null)
                {
                    _controlState = new Dictionary<string, bool>();
                    foreach (Control control in parentForm.Controls)
                    {
                        if (!_controlState.ContainsKey(control.Name))
                        {
                            _controlState.Add(control.Name, control.Enabled);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (!TrailExCommonFunctions.IsUserRestrictted())
                {
                    EventLog.WriteEntry(Application.ProductName,
                    string.Format("{0}\nStackTrace:\n{1}", ex.Message, ex.StackTrace), EventLogEntryType.Error);
                }
            }
        }


    }
}
