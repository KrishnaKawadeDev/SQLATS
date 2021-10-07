using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Utility
{
  public delegate void HandleGreyItemEvent();
  public class UserControlWithLoadAndSave : UserControl
  {
    public event HandleGreyItemEvent m_handleGreyItem;
    virtual public void LoadSettings() { }
    virtual public void SaveSettings() { }
    virtual public void RefreshView(UserControlWithLoadAndSave prevUC) { }
    public override string ToString()
    {
      return "Nothing";
    }

    public virtual Boolean EnableOK()
    {
      return true;
    }

    public virtual void OnOK()
    {

    }

    public virtual void OnCancel()
    {

    }

    public virtual void HandleGreyItems()
    {
      if (m_handleGreyItem != null)
        m_handleGreyItem();
    }
  }

  // I have to use this for dumb classes like UserControl where you can't override "Tostring"
  public class ListBoxItem
  {
    public object m_obj;
    public ListBoxItem(object obj)
    {
      m_obj = obj;
    }
    public override string ToString()
    {
      return m_obj.ToString();
    }
  };

  public class WinFormFunctions
  {
    public static int FindInListboxIgnoreCaseAndTrim(ListBox lb, string str)
    {
      int index = 0;
      foreach (string s in lb.Items)
      {
        if (s.Trim().ToLower() == str.Trim().ToLower())
          return index;
        index++;
      }
      return -1;
    }

    public static Control FindFormParent(Control child)
    {
      Control currentPos = child;
      while (currentPos.Parent != null)
        currentPos = currentPos.Parent;
      return currentPos;
    }

    public static void SelectStringObject(ComboBox combo, string str)
    {
      foreach (object o in combo.Items)
      {
        StringObject so = (StringObject)o;
        if (so.m_sValue == str)
        {
          combo.SelectedItem = o;
          return;
        }
      }
    }

    public static StringObject SelectedStringObject(ComboBox combo)
    {
      if (combo.SelectedItem == null)
        return null;

      StringObject so = (StringObject)combo.SelectedItem;
      return so;
    }

    public static void SelectIntString(ComboBox combo, Int32 iValue)
    {
      foreach (object o in combo.Items)
      {
        IntString i = (IntString)o;
        if (i.m_iValue == iValue)
        {
          combo.SelectedItem = o;
          return;
        }
      }
    }

    public static IntString SelectedIntString(ComboBox combo)
    {
      IntString i = (IntString)combo.SelectedItem;
      return i;
    }

    public static void SelectIntObject(ComboBox combo, Int32 iValue)
    {
      foreach (object o in combo.Items)
      {
        IntObject i = (IntObject)o;
        if (i.m_iValue == iValue)
        {
          combo.SelectedItem = o;
          return;
        }
      }
    }

    public static IntObject SelectedIntObject(ComboBox combo)
    {
      IntObject i = (IntObject)combo.SelectedItem;
      return i;
    }

    public static void SelectIntStringObject(ComboBox combo, Int32 iValue)
    {
      foreach (object o in combo.Items)
      {
        IntStringObject i = (IntStringObject)o;
        if (i.m_iValue == iValue)
        {
          combo.SelectedItem = o;
          return;
        }
      }
    }

    public static IntStringObject SelectedIntStringObject(ComboBox combo)
    {
      IntStringObject i = (IntStringObject)combo.SelectedItem;
      return i;
    }
  };


}