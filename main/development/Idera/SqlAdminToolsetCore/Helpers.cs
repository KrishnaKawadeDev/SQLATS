using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using System.Web;
using Microsoft.Win32;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using System.Drawing;


namespace Idera.SqlAdminToolset.Core
{
   public class Helpers
   {
      #region Import
      
      [DllImport( "Shlwapi.dll", CharSet = CharSet.Auto )]
      public static extern long StrFormatByteSize( long fileSize,
      [MarshalAs( UnmanagedType.LPTStr )] StringBuilder buffer, int bufferSize );

      #endregion

      #region Format Routines

      /// <summary>
      /// Convert a filesize into a human readable string with appropraite metric (xxx GB)
      /// </summary>
      /// <param name="fileSize"></param>
      /// <returns></returns>
      public static string StrFormatByteSize(long fileSize)
      {
         StringBuilder sbBuffer = new StringBuilder(20);
         StrFormatByteSize(fileSize, sbBuffer, 20);
         return sbBuffer.ToString();
      }
      public static string StrFormatByteSize(ulong fileSize)
      {
         StringBuilder sbBuffer = new StringBuilder(20);
         if (fileSize <= Int64.MaxValue)
         {
             StrFormatByteSize(Convert.ToInt64(fileSize), sbBuffer, 20);
         }
         else
         {
             ulong gigaBytes = 1024 * 1024 * 1024;
             ulong teraBytes = gigaBytes * 1024;
             if(fileSize > teraBytes)
             {
                 return string.Format("{0} TB", fileSize/teraBytes);
             }
             else
             {
                 return string.Format("{0} GB", fileSize / gigaBytes);
             }
         }

         return sbBuffer.ToString();
      }

      #endregion

      #region Dealing with Exceptions

      public static string
          GetCombinedExceptionText(
             Exception ex
          )
      {
         StringBuilder msg = new StringBuilder( 1024 );

         if ( ex == null ) 
         {
            msg.Append( "Unknown error" );
         }
         else
         {
            msg.Append( ex.Message );

            int maxDepth = 0;
            Exception inner = ex.InnerException;

            while ( (maxDepth < 5) && (inner != null) )
            {
               maxDepth++;
               msg.Append( " " + inner.Message );
               inner = inner.InnerException;
            }
         }
            if (msg.ToString().Contains("A connection was successfully established with the server, but then an error occurred during the pre-login handshake."))
            {
                if (!msg.ToString().Contains("If you are using Sql Server 7, it is not supported by SQL Admin Tool Set."))
                {
                    msg.Append("\n\nIf you are using Sql Server 7, it is not supported by SQL Admin Tool Set.");
                }
            }
            return msg.ToString();
      }
      #endregion
      
      #region Application Directory
      
      public static string GetSuiteDirectory( bool createDirectory )
      {
         return GetApplicationDirectory( CoreGlobals.shortSuiteName, createDirectory );
      }

      public static string GetProductDirectory( bool createDirectory )
      {
         string productDir = Path.Combine( CoreGlobals.shortSuiteName,CoreGlobals.productName );
         return GetApplicationDirectory( productDir, createDirectory );
      }
      
      public static string GetApplicationDirectory( string subFolder, bool createDirectory  )
      {
         //string localAppData = (ToolsetOptions.optionsRootKey == Registry.CurrentUser ) ? System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
         //                                                                               : System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData);
         string localAppData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData);
         
         string ideraPath = Path.Combine( localAppData, CoreGlobals.companyName );
         
         if ( createDirectory && !Directory.Exists(ideraPath) )
         {
            Directory.CreateDirectory(ideraPath);
         }
         
         string finalPath = Path.Combine( ideraPath, subFolder );
         if ( createDirectory && !Directory.Exists(finalPath) )
         {
            Directory.CreateDirectory(finalPath);
         }
         
         return finalPath;
      }
      
      #endregion
      
      #region IP Stuff

      public static string
         GetIP4AddressString()
      {
         return GetIP4AddressString( null ) ; // force to local
      }
      
      public static string
         GetIP4AddressString(
            string host
         )
      {
        IPAddress IP4Address = GetIP4Address( host);
        
        return IP4Address.ToString();
      }
      
      public static IPAddress
         GetIP4Address()
      {
         return GetIP4Address( null ) ; // force to local
      }
      
      public static IPAddress
         GetIP4Address(
            string host
         )
      {
        IPAddress     IP4Address = null;
        
        if ( String.IsNullOrEmpty(host) )
           host = Dns.GetHostName();

        foreach (IPAddress IPA in Dns.GetHostAddresses(host))
        {
          if (IPA.AddressFamily.ToString() == "InterNetwork")
          {
            IP4Address = IPA;
            break;
          }
        }
        return IP4Address;
      }
      
      
      #endregion
      
      #region Compare Routines for ListView Sorting
      
      public static int CompareInt( int value1, int value2 )
      {
         int returnVal = 0;
         
         if ( value1 < value2 )
           returnVal = -1;
         else if ( value1 > value2 )
            returnVal = 1;
         
         return returnVal;
      }
      
      public static int CompareIntString( string sValue1, string sValue2 )
      {
         int returnVal = 0;

         int value1, value2;
         
         try { value1 = System.Convert.ToInt32(sValue1); }
         catch { value1 = 0; }
         try { value2 = System.Convert.ToInt32(sValue2); }
         catch { value2 = 0; }
         
         if ( value1 < value2 )
           returnVal = -1;
         else if ( value1 > value2 )
            returnVal = 1;
         else
            returnVal = 0;
         
         return returnVal;
      }
      
      public static int CompareLong( long value1, long value2 )
      {
         int returnVal = 0;
         
         if ( value1 < value2 )
           returnVal = -1;
         else if ( value1 > value2 )
            returnVal = 1;
         else
            returnVal = 0;
         
         return returnVal;
      }

      public static int CompareIP( string ip1, string ip2 )
      {
         int returnVal = 0;
         int value1, value2;
         
         if ( ip1=="" && ip2=="" ) return 0;
         if ( ip1=="") return -1;
         if ( ip2=="") return 1;
         
         string [] ip1tokens = ip1.Split('.');
         string [] ip2tokens = ip2.Split('.');
         
         // validate input
         if (ip1tokens.Length != 4 || ip1tokens.Length != 4 )
         {
            return 0;
         }
         
         for ( int i=0; (returnVal==0) && (i<4); i++ )
         {
            try { value1 = System.Convert.ToInt32(ip1tokens[i]); }
            catch { value1 = 0; }
            try { value2 = System.Convert.ToInt32(ip2tokens[i]); }
            catch { value2 = 0; }
            
            returnVal = CompareInt( value1, value2 );
            
            if ( returnVal != 0 ) break;
         }
         
         return returnVal;
      }
      
      public static int CompareVersionString( string version1, string version2 )
      {
         int returnVal = 0;
         
         if ( version1=="" && version2=="" ) return 0;
         if ( version1=="") return -1;
         if ( version2=="") return 1;
         
         string [] parts1 = version1.Split('.');
         string [] parts2 = version2.Split('.');
         
         int top = Math.Min( parts1.Length, parts2.Length );
         int p1,p2;
         for ( int i=0; (returnVal==0) && (i<top); i++ )
         {
            try
            {
               p1 = System.Convert.ToInt32(parts1[i]);
            }
            catch 
            {
               p1 = 0;
            }
            
            try
            {
               p2 = System.Convert.ToInt32(parts2[i]);
            }
            catch 
            {
               p2 = 0;
            }
            
            returnVal = CompareInt( p1, p2 );
            
            if ( returnVal != 0 ) break;
         }
         
         if ( returnVal == 0 )
         {
            returnVal = CompareInt( parts1.Length, parts2.Length );
         }
         
         return returnVal;
      }

      public static int CompareDouble(double value1, double value2)
      {
          int returnVal = 0;

          if (value1 < value2)
               returnVal = -1;
          else if (value1 > value2)
               returnVal = 1;

          return returnVal;
      }


      
      
      #endregion
      
      #region String Manipulators
      
      public static string
         StripFormatCharacters(
            string inString
         )
      {
          inString = inString.Replace( "\r\n", " " );
          inString = inString.Replace( "\r",   " " );
          inString = inString.Replace( "\n",   " " );
          inString = inString.Replace( "\t",   "        " );
          
          return inString;
      }
      
      public static string
        CreateWrappedString(
           string  input,
           int     columnWrap )
      {
         StringBuilder output = new StringBuilder(1024);
         
         int  columnCount = 0;
         bool timeToWrap = false;
         
         for ( int i=0; i<input.Length; i++ )
         {
            if ( input[i] == '\r' || input[i] == '\n' )
            {
               timeToWrap = false;
               columnCount = 0;
               output.Append(input[i]);
            }
            else
            {
               if ( (columnCount+1) % columnWrap == 0 )
               {
                  timeToWrap= true;
               }
               
               if ( timeToWrap && input[i] == ' ' )
               {
                  timeToWrap = false;
                  columnCount = 0;
                  output.Append("\r\n");
               }
               else
               {
                  output.Append(input[i]);
                  columnCount++;
               }
            }
         }
         
         return output.ToString();
      }
      
      //-----------------------------------------------------------------------
      // CreateSafeString - creates safe string parameter includes
      //                    single quotes; used to create sql parameters
      //-----------------------------------------------------------------------
      static public string CreateSafeString(string propName)
      {
         return CreateSafeString(propName, int.MaxValue);
      }
      
      //-----------------------------------------------------------------------
      // CreateSafeString - creates safe string parameter includes
      //                    single quotes; used to create sql parameters with
      //                    length limit
      //-----------------------------------------------------------------------
      static public string CreateSafeString(string propName, int limit)
      {
         StringBuilder newName;
         string        tmpValue;
         
         if (propName == null)
         {
			   newName = new StringBuilder("null");
         }
         else
         {
			   newName = new StringBuilder("'");
			   tmpValue = propName.Replace("'", "''");

            if (tmpValue.Length > limit)
            {
               if (tmpValue[limit-1] == '\'')
               {
                  limit--;
                  if (tmpValue[limit-1] == '\'')
                     limit--;
               }
               tmpValue = tmpValue.Remove(limit, tmpValue.Length - limit);
            }
            newName.Append(tmpValue);
		      newName.Append("'");
		   }
         return newName.ToString();
      } 
      #endregion

      #region ListView formatting

      /// <summary>
      /// Applies colors to alternating rows in a listview
      /// </summary>
      /// <param name="listView"></param>
      public static void ApplyAlternateColorsToListView(ListViewEx listView)
      {
          ApplyAlternateColorsToListView(listView, false, -1);
      }

      /// <summary>
      /// Applies colors to alternating rows in a listview and highlights the requested column
      /// </summary>
      /// <param name="listView"></param>
      public static void ApplyAlternateColorsToListView(ListViewEx listView, bool highlightColumn, int columnIndex)
      {
          foreach (ListViewGroup _Group in listView.Groups)
          {
              for (int _Row = 0; _Row < _Group.Items.Count; _Row++)
              {
                  Color _BackColor = Color.White;

                  ListViewItem _Item = _Group.Items[_Row];

                  if (_Row == 0 || _Group.Items[_Row - 1].BackColor == Color.White)
                  {
                      _BackColor = Color.WhiteSmoke;
                  }

                  for (int i = 0; i < _Item.SubItems.Count; i++)
                  {
                      if (highlightColumn && columnIndex == i)
                      {
                          _Item.SubItems[i].BackColor = Color.LightSteelBlue;
                      }
                      else
                      {
                          _Item.SubItems[i].BackColor = _BackColor;
                      }
                  }
              }
          }
      }

      #endregion

      #region Operating System
      /// <summary>
      /// Returns the human-readable Operating System name derived from the specified version string.
      /// </summary>
      public static string GetWindowsVersion(string versionString)
      {
          const string WindowsNTString = "Windows NT";
          const string Windows2000String = "Microsoft Windows 2000";
          const string WindowsXPString = "Microsoft Windows XP";
          const string Windows2003String = "Microsoft Windows Server 2003";
          const string Windows2008String = "Microsoft Windows Server 2008";


          if (versionString.Substring(0, 1) == "4")
              return WindowsNTString;
          switch (versionString.Substring(0, 3))
          {
              case "5.0":
                  return Windows2000String;
              case "5.1":
                  return WindowsXPString;
              case "5.2":
                 return Windows2003String;
              case "6.0":
                  return Windows2008String;
              default:
                  return "Windows " + versionString;
          }
      }
      #endregion
  }
}
