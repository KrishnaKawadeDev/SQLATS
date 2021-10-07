using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using DevComponents.DotNetBar;
using Microsoft.Win32;

namespace Idera.SqlAdminToolset.Core
{
    public class Messaging
    {
        public static void
           ShowInformation(
              string message
           )
        {
            ShowInformation(message,
                             CoreGlobals.productName);
        }

        public static void
           ShowInformation(
              string message,
              string caption
           )
        {
            ShowMessageBox(message,
                            caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public static void
          ShowInformation(
             IWin32Window win,
             string message
          )
        {
            ShowInformation(win, message,
                             CoreGlobals.productName);
        }

        public static void
           ShowInformation(
              IWin32Window win,
              string message,
              string caption
           )
        {
            string wrappedMessage = Helpers.CreateWrappedString(message, 120);

            MessageBoxEx.Show(win,
                              wrappedMessage,
                             caption,
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
        }
        public static void
          ShowWarningDialog(
             string message
          )
        {
            ShowWarning(message,
                             CoreGlobals.productName);
        }

        public static void
           ShowWarning(
              string message
           )
        {
            ShowInformation(message,
                             CoreGlobals.productName);
        }

        public static void
           ShowWarning(
              string message,
              string caption
           )
        {
            ShowMessageBox(message,
                           caption,
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
        }

        public static void
           ShowException(
              string attemptedAction,
              Exception ex
           )
        {
            ShowException(attemptedAction,
                           ex,
                           CoreGlobals.productName);
        }

        public static void
           ShowException(
              string attemptedAction,
              Exception ex,
              string caption
           )
        {
            string msg = attemptedAction + "\r\n\r\nError: ";

            msg += Helpers.GetCombinedExceptionText(ex);

            ShowError(msg, caption);
        }


        public static DialogResult
           ShowError(
              string msg
           )
        {
            return ShowError(msg,
                       CoreGlobals.productName);
        }

        public static DialogResult
           ShowError(
              IWin32Window win,
              string msg
           )
        {
            return ShowError(win,
                              msg,
                              CoreGlobals.productName);
        }


        public static DialogResult
           ShowError(
              string msg,
              string caption
           )
        {
            return ShowMessageBox(msg,
                                   caption,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
        }

        public static DialogResult
           ShowError(
              IWin32Window win,
              string msg,
              string caption
           )
        {
            return ShowMessageBox(win,
                                   msg,
                                   caption,
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
        }


        public static DialogResult
           ShowError(
              IWin32Window win,
              string msg,
              string caption,
              string askToContinueMsg
           )
        {
            msg += "\r\n\r\n" + askToContinueMsg;

            return ShowMessageBox(win,
                                   msg,
                                   caption,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Error);
        }

        public static DialogResult
           ShowError(
              string msg,
              string caption,
              string askToContinueMsg
           )
        {
            msg += "\r\n\r\n" + askToContinueMsg;

            return ShowMessageBox(msg,
                                   caption,
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Error);
        }


        public static DialogResult
            ShowVersion(
            string msg
           

            )
        {
            return ShowMessageBox(msg, 
                                 "",
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Warning);
        }

        public static DialogResult
           ShowConfirmation(
              string message
           )
        {
            return ShowConfirmation(message,
                             CoreGlobals.productName);
        }

        public static DialogResult
           ShowConfirmation(
              IWin32Window win,
              string message
           )
        {
            return ShowConfirmation(win, message,
                             CoreGlobals.productName);
        }

        public static DialogResult
          ShowConfirmation(
            IWin32Window win,
             string message,
             string caption
          )
        {
            return ShowMessageBox(win,
                                  message,
                                  caption,
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);
        }

        public static DialogResult
           ShowConfirmation(
              string message,
              string caption
           )
        {
            return ShowMessageBox(message,
                                  caption,
                                  MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question);
        }

        public static DialogResult
           ShowConfirmationWithCancel(
              string message
           )
        {
            return ShowConfirmationWithCancel(message,
                             CoreGlobals.productName);
        }

        public static DialogResult
           ShowConfirmationWithCancel(
              string message,
              string caption
           )
        {
            return ShowMessageBox(message,
                                  caption,
                                  MessageBoxButtons.YesNoCancel,
                                  MessageBoxIcon.Question);
        }


        private static DialogResult
           ShowMessageBox(
              IWin32Window win,
              string msg,
              string caption,
              MessageBoxButtons buttons,
              MessageBoxIcon icon
           )
        {
            string wrappedMessage = Helpers.CreateWrappedString(msg, 120);

            if (win == null)
                return MessageBoxEx.Show(wrappedMessage, caption, buttons, icon);
            else
                return MessageBoxEx.Show(win, wrappedMessage, caption, buttons, icon);
        }

        private static DialogResult
           ShowMessageBox(
              string msg,
              string caption,
              MessageBoxButtons buttons,
              MessageBoxIcon icon
           )
        {
            string wrappedMessage = Helpers.CreateWrappedString(msg, 120);

            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;

            if (handle != (IntPtr)0)
            {
                return MessageBoxEx.Show(new WindowWrapper(handle),
                                          wrappedMessage, caption, buttons, icon);
            }
            else
            {
                return MessageBoxEx.Show(wrappedMessage, caption, buttons, icon);
            }
        }

        public static DialogResult
           ShowHideableConfirmation(
              string regValue,
              string message,
              MessageBoxButtons buttons
           )
        {
            return ShowHideableConfirmation(regValue, message, CoreGlobals.productName, buttons);
        }

        public static DialogResult
           ShowHideableConfirmation(
              string regValue,
              string message,
              string title,
              MessageBoxButtons buttons
           )
        {
            RegistryKey toolsetKey = null;
            RegistryKey optionsKey = null;

            DialogResult returnValue = DialogResult.Yes;

            int showConfirmation = 1;

            // read option
            try
            {
                toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                optionsKey = toolsetKey.CreateSubKey(CoreGlobals.shortProductName);

                showConfirmation = (int)optionsKey.GetValue(regValue, 1);
            }
            catch (Exception ex)
            {
                CoreGlobals.traceLog.ErrorFormat("ShowHideableConfirmation - ReadOptions error: {0}", ex.Message);
            }
            finally
            {
                if (toolsetKey != null) toolsetKey.Close();
                if (optionsKey != null) optionsKey.Close();
                toolsetKey = null;
                optionsKey = null;
            }


            // if hiding - just return value
            if (showConfirmation == 0)
            {
                if (buttons == MessageBoxButtons.OK)
                    returnValue = DialogResult.OK;
                else
                    returnValue = DialogResult.Yes;
            }
            else
            {
                // show form
                Form_ShowWarning frm = new Form_ShowWarning(message, title, buttons);

                returnValue = frm.ShowDialog();
                Application.DoEvents(); // repaint main form after this dialog closes

                // write option (if time to hide)
                if (frm.DontShowWarningAgain)
                {
                    try
                    {
                        toolsetKey = ToolsetOptions.optionsRootKey.CreateSubKey(ToolsetOptions.optionsRegistryKey);
                        optionsKey = toolsetKey.CreateSubKey(CoreGlobals.shortProductName);
                        optionsKey.SetValue(regValue, 0);
                    }
                    catch (Exception exWrite)
                    {
                        CoreGlobals.traceLog.ErrorFormat("ShowHideableConfirmation - WriteOptions error: {0}", exWrite.Message);
                    }
                    finally
                    {
                        if (toolsetKey != null) toolsetKey.Close();
                        if (optionsKey != null) optionsKey.Close();

                        toolsetKey = null;
                        optionsKey = null;
                    }
                }
            }

            return returnValue;
        }
    }

    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        public IntPtr Handle
        {
            get { return _hwnd; }
        }

        private IntPtr _hwnd;
    }
}
