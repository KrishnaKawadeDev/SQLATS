using System;
using System.Collections.Generic;
using System.Text;
using System.IO; // for memory stream
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;  // for the registry stuff.
using BBS.TracerX;


namespace Idera.SqlAdminToolset.JobEditor.Job_Editing_Dialogs.Utility
{
  public delegate bool ListDiffCompare(object left, object right);
  public class ListDiffs
  {
    private List<object> m_leftList;
    private List<object> m_rightList;
    public List<object> m_matching;
    public List<object> m_toAdd;
    public List<object> m_toRemove;
    ListDiffCompare m_compareMethod;

    public ListDiffs(ListDiffCompare compareMethod)
    {
      m_leftList = new List<object>();
      m_rightList = new List<object>();
      m_compareMethod = compareMethod;
    }
    
    public void AddToLeft(object lo)
    {
      m_leftList.Add(lo);
    }

    public void AddToRight(object ro)
    {
      m_rightList.Add(ro);
    }

    public void MatchEmUp()
    {
      m_matching = new List<object>();
      m_toAdd = new List<object>();
      m_toRemove = new List<object>();
      foreach(object lo in m_leftList)
      {
        Boolean bFound = false;
        foreach(object ro in m_rightList)
        {
          if (m_compareMethod(lo, ro))
          {
            bFound = true;
            m_rightList.Remove(ro); // this should be ok since we're breaking out of the ForEach
            break;
          }
        }
        if (bFound)
          m_matching.Add(lo);
        else
          m_toRemove.Add(lo);
      }
      m_toAdd = m_rightList;
    }

    public Boolean ChangesDetected
    {
      get
      {
        return (m_toAdd.Count > 0) || (m_toRemove.Count > 0);
      }
      set
      {

      }
    }
  };

  public class CaseLessList : List<string>
  {
    public CaseLessList()
    {

    }
    
    // returns true if the string is in the list.
    public Boolean InList(string a)
    {
      string workstr = a.Trim().ToLower();
      for(int i = 0; i < Count; i++)
      {
        if (base[i].Trim().ToLower() == workstr)
          return true;
      }
      return false;
    }

    // returns true if the string was added.
    public Boolean AddString(string a)
    {
      if (!InList(a))
      {
        Add(a);
        return true;
      }
      return false;
    }

    public Boolean RemoveString(string a)
    {
      string workstr = a.Trim().ToLower();
      for (int i = 0; i < Count; i++)
      {
        if (base[i].Trim().ToLower() == workstr)
        {
          RemoveAt(i);
          return true;
        }
      }
      return false;
    }
  };

  public class UsefulFunctions
  {
    [DllImport("netapi32.dll", EntryPoint = "NetRemoteTOD", SetLastError = true,
            CharSet = CharSet.Unicode, ExactSpelling = true,
            CallingConvention = CallingConvention.StdCall)]
    private static extern int NetRemoteTOD(string UncServerName, ref IntPtr BufferPtr);
    [DllImport("netapi32.dll")]
    private static extern void NetApiBufferFree(IntPtr bufptr);

    [StructLayout(LayoutKind.Sequential)]
    public struct structTIME_OF_DAY_INFO
    {
      public int itod_elapsedt;
      public int itod_msecs;
      public int itod_hours;
      public int itod_mins;
      public int itod_secs;
      public int itod_hunds;
      public int itod_timezone;
      public int itod_tinterval;
      public int itod_day;
      public int itod_month;
      public int itod_year;
      public int itod_weekday;
    }

    static public string TimeSpanToLongTimeString(TimeSpan sp)
    {
      DateTime dt = new DateTime(2000, 1, 1);
      dt = dt.Add(sp);
      return dt.ToLongTimeString();
    }

    // timezone is the difference from the GMT.
    // timezone has to be a float since there are wacko places that are only 30 mins off
    static public DateTime RemoteTime(string machineName, ref float timeZone) 
    {
      if (!machineName.StartsWith(@"\\"))
        machineName = @"\\" + machineName;

      structTIME_OF_DAY_INFO result = new structTIME_OF_DAY_INFO();
      IntPtr pintBuffer = IntPtr.Zero;
//       int[] TOD_INFO = new int[12];

      // Get the time of day.
      int pintError = NetRemoteTOD(machineName, ref pintBuffer);
      if (pintError > 0) 
      { 
        throw new System.ComponentModel.Win32Exception(pintError); 
      }

      // Get the structure.
      result = (structTIME_OF_DAY_INFO)Marshal.PtrToStructure(pintBuffer, typeof(structTIME_OF_DAY_INFO));

//       TOD_INFO[0] = result.itod_elapsedt;
//       TOD_INFO[1] = result.itod_msecs;
//       TOD_INFO[2] = result.itod_hours;
//       TOD_INFO[3] = result.itod_mins;
//       TOD_INFO[4] = result.itod_secs;
//       TOD_INFO[5] = result.itod_hunds;
//       TOD_INFO[6] = result.itod_timezone;
//       TOD_INFO[7] = result.itod_tinterval;
//       TOD_INFO[8] = result.itod_day;
//       TOD_INFO[9] = result.itod_month;
//       TOD_INFO[10] = result.itod_year;
//       TOD_INFO[11] = result.itod_weekday;

      DateTime gmtTime = new DateTime(result.itod_year, result.itod_month, result.itod_day, result.itod_hours, result.itod_mins, result.itod_secs);
      timeZone = (result.itod_timezone * -1 / 60);
      DateTime remoteTime = gmtTime.AddMinutes(result.itod_timezone * -1); // stupid API returns the time zone backwards. positive for the west and negative for the east.
      
      // Free the buffer.
      NetApiBufferFree(pintBuffer);

      return remoteTime;
    }

    static public TimeSpan SQLDurationToSpan(Int32 runDuration)
    {
      Int32 hour = runDuration / 10000;
      Int32 min = (runDuration - hour * 10000) / 100;
      Int32 sec = runDuration % 100;
      return new TimeSpan(hour, min, sec);
    }

    static public DateTime DropSeconds(DateTime time)
    {
      return new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, 0);
    }

    static public string EncryptString(string text, string key)
    {
      Byte[] byKey;
      Byte[] IV = { 0x70, 0x72, 0x6f, 0x76, 0x69, 0x64, 0x65, 0x72 };
      byKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
      DESCryptoServiceProvider des = new DESCryptoServiceProvider();
      Byte[] inputByteArray = Encoding.UTF8.GetBytes(text);
      MemoryStream ms = new MemoryStream();
      CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
      cs.Write(inputByteArray, 0, inputByteArray.Length);
      cs.FlushFinalBlock();
      return Convert.ToBase64String(ms.ToArray());
    }

    static public string DecryptString(string text, string key)
    {
      Byte[] byKey;
      Byte[] IV = { 0x70, 0x72, 0x6f, 0x76, 0x69, 0x64, 0x65, 0x72 };
      Byte[] inputByteArray = new Byte[text.Length];

      byKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
      DESCryptoServiceProvider des = new DESCryptoServiceProvider();
      inputByteArray = Convert.FromBase64String(text);
      MemoryStream ms = new MemoryStream();
      CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
      cs.Write(inputByteArray, 0, inputByteArray.Length);
      cs.FlushFinalBlock();
      UTF8Encoding encoding = new UTF8Encoding();
      return encoding.GetString(ms.ToArray());
    }

    static public string GetEncryptedStringFromRegistry(string regkey, string valueName, string key)
    {
      string encryptedStr = (string)Registry.GetValue(regkey, valueName, "");
      if (encryptedStr.Length == 0)
        return ""; // we got a null string.

      return DecryptString(encryptedStr, valueName + key);
    }

    static public void StoreEncryptedStringInRegistry(string regkey, string valueName, string str, string key)
    {
      string encryptedStr = EncryptString(str, valueName + key);
      Registry.SetValue(regkey, valueName, encryptedStr);
    }

    static public int WeekNumber_Entire4DayWeekRule(DateTime date)
    {
      // Updated 2004.09.27. Cleaned the code and fixed a bug. Compared the algorithm with
      // code published here . Tested code successfully against the other algorithm 
      // for all dates in all years between 1900 and 2100.
      // Thanks to Marcus Dahlberg for pointing out the deficient logic.
      // Calculates the ISO 8601 Week Number
      // In this scenario the first day of the week is monday, 
      // and the week rule states that:
      // [...] the first calendar week of a year is the one 
      // that includes the first Thursday of that year and 
      // [...] the last calendar week of a calendar year is 
      // the week immediately preceding the first 
      // calendar week of the next year.
      // The first week of the year may thus start in the 
      // preceding year

      const int JAN = 1;
      const int DEC = 12;
      const int LASTDAYOFDEC = 31;
      const int FIRSTDAYOFJAN = 1;
      const int THURSDAY = 5;  // changed to 5 since I want the week to start on Sunday not monday
      bool ThursdayFlag = false;

      // Get the day number since the beginning of the year
      int DayOfYear = date.DayOfYear;

      // Get the numeric weekday of the first day of the 
      // year (using sunday as FirstDay)
      int StartWeekDayOfYear =
           (int)(new DateTime(date.Year, JAN, FIRSTDAYOFJAN)).DayOfWeek;
      int EndWeekDayOfYear =
           (int)(new DateTime(date.Year, DEC, LASTDAYOFDEC)).DayOfWeek;

      // Compensate for the fact that we are using monday
      // as the first day of the week
      if (StartWeekDayOfYear == 0)
        StartWeekDayOfYear = 7;
      if (EndWeekDayOfYear == 0)
        EndWeekDayOfYear = 7;

      // Calculate the number of days in the first and last week
      int DaysInFirstWeek = 8 - (StartWeekDayOfYear);
      int DaysInLastWeek = 8 - (EndWeekDayOfYear);

      // If the year either starts or ends on a thursday it will have a 53rd week
      if (StartWeekDayOfYear == THURSDAY || EndWeekDayOfYear == THURSDAY)
        ThursdayFlag = true;

      // We begin by calculating the number of FULL weeks between the start of the year and
      // our date. The number is rounded up, so the smallest possible value is 0.
      int FullWeeks = (int)Math.Ceiling((DayOfYear - (DaysInFirstWeek)) / 7.0);

      int WeekNumber = FullWeeks;

      // If the first week of the year has at least four days, then the actual week number for our date
      // can be incremented by one.
      if (DaysInFirstWeek >= THURSDAY)
        WeekNumber = WeekNumber + 1;

      // If week number is larger than week 52 (and the year doesn't either start or end on a thursday)
      // then the correct week number is 1. 
      if (WeekNumber > 52 && !ThursdayFlag)
        WeekNumber = 1;

      // If week number is still 0, it means that we are trying to evaluate the week number for a
      // week that belongs in the previous year (since that week has 3 days or less in our date's year).
      // We therefore make a recursive call using the last day of the previous year.
      if (WeekNumber == 0)
        WeekNumber = WeekNumber_Entire4DayWeekRule(
             new DateTime(date.Year - 1, DEC, LASTDAYOFDEC));
      return WeekNumber;
    }
  }

  public class SQLjmLog
  {
    //private static readonly Logger log = Logger.GetLogger("SQLjm");
    //private static bool LogFileOpened = InitLogging();
    //private static bool InitLogging()
    //{
    //  // Configure logging for this process using the App.config file.
    //  // This includes setting the output directory.
    //  // If this doesn't work, the default properties of the 
    //  // TracerX.Configuration object are probably OK.
    //  bool configRc = BBS.TracerX.XmlConfig.Configure();

    //  // The name of the log file is set in code here (the directory 
    //  // was loaded from the .config file).
    //  Configuration.LogFileName = "SQLjm.tx1";

    //  // Threads should be named, but an exception occurs if 
    //  // you try to change the name.
    //  if (Thread.CurrentThread.Name == null) Thread.CurrentThread.Name = "Main";

    //  // Now open the log file using the configuration 
    //  // settings that were previously loaded or set.
    //  return Logger.OpenLog();
    //}

    //static public Logger Log
    //{
    //  get
    //  {
    //    return log;
    //  }
    //  set
    //  {

    //  }
    //}

     // use the admin toolset log instead of Job Manager
     static public Logger Log
     {
        get
        {
           return Core.CoreGlobals.traceLog;
        }
        set
        {

        }
     }
  };

  public class TwoStrings
  {
    public string m_str1;
    public string m_str2;

    public TwoStrings(string str1, string str2)
    {
      m_str1 = str1;
      m_str2 = str2;
    }

    public override string ToString()
    {
      return m_str1;
    }
  };

  public class IntString
  {
    public Int32 m_iValue;
    public string m_sValue;

    public IntString(Int32 iValue, string sValue)
    {
      m_iValue = iValue;
      m_sValue = sValue;
    }

    public override string ToString()
    {
      return m_sValue;
    }
  };

  public class IntObject
  {
    public Int32 m_iValue;
    public object m_object;

    public IntObject(Int32 iValue, object obj)
    {
      m_iValue = iValue;
      m_object = obj;
    }

    public override string ToString()
    {
      return m_object.ToString();
    }
  };

  public class IntStringObject
  {
    public Int32 m_iValue;
    public string m_sValue;
    public object m_object;

    public IntStringObject(Int32 iValue, string sValue, object obj)
    {
      m_iValue = iValue;
      m_sValue = sValue;
      m_object = obj;
    }

    public override string ToString()
    {
      return m_sValue;
    }
  };

  public class StringObject
  {
    public string m_sValue;
    public object m_object;

    public StringObject(string sValue, object obj)
    {
      m_sValue = sValue;
      m_object = obj;
    }

    public override string ToString()
    {
      return m_sValue;
    }
  };
}
