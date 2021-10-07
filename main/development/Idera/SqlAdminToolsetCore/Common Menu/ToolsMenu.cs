using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
   #region Tools Menu stuff

   public class ToolsMenu
   {
      static public void LoadToolsMenu( ToolStripMenuItem toolsMenu )
      {
         IList<RegisteredTool> companyTools = ToolFinder.GetRegisteredTools( CoreGlobals.RegKeyIderaProducts );

         if ( companyTools.Count != 0 )
         {
            ToolStripSeparator separator = new ToolStripSeparator();
            toolsMenu.DropDownItems.Add( separator );
         }

         foreach (Core.RegisteredTool tool in companyTools)
         {
            if ( tool.IsValid && tool.Name != CoreGlobals.shortSuiteName )
            {
               ToolStripMenuItem menuEntry = new ToolStripMenuItem( tool.Name, null, new EventHandler( tool.LaunchEvent ) );
               toolsMenu.DropDownItems.Add( menuEntry );
            }
         }
      }
      
      static public DialogResult ManageServerGroups()
      {
         Application.DoEvents();
         
         Form_ManageServerGroups frm = new Form_ManageServerGroups();
         DialogResult choice = frm.ShowDialog();

         if ( choice == DialogResult.OK )
         {
            CoreGlobals.ServerGroupList.RaiseServerGroupsChangedEvent();
         }

         return choice;
      }
      
      static public DialogResult ShowToolsetOptions()
      {
         Application.DoEvents();
         
          Form_Options frm = new Form_Options();
          DialogResult choice = frm.ShowDialog();
          return choice;
      }

      static public bool RunLaunchpad( Form parent )
      {
         return Launchpad.Run( parent );
      }
   }

   #endregion

   #region ToolFinder - Class to find registered prodcuts for Tools Menu
	/// <summary>
	/// Summary description for ToolFinder.
	/// </summary>
	public class ToolFinder
	{
      public static IList<RegisteredTool> GetRegisteredTools(string containerKeyName)
      {
         if(containerKeyName == null)
            return new List<RegisteredTool>() ;

         using(RegistryKey key = Registry.LocalMachine.OpenSubKey(containerKeyName, false))
         {
            if(key == null)
               return new List<RegisteredTool>() ;
            else
               return GetRegisteredTools(key) ;
         }
      }

      public static List<RegisteredTool> GetRegisteredTools(RegistryKey containerKey)
      {
         List<RegisteredTool> retVal = new List<RegisteredTool>();
         if(containerKey == null)
            return retVal ;

         string sAssembly = Assembly.GetExecutingAssembly().Location ;

         foreach(string subKeyName in containerKey.GetSubKeyNames())
         {
            using(RegistryKey subKey = containerKey.OpenSubKey(subKeyName, false))
            {
               string sName = null ;
               string sPath = null ;
               object o ;

               o = subKey.GetValue("ProductName") ;
               if(o is string)
                  sName = (string)o ;
               o = subKey.GetValue("ProductPath") ;
               if(o is string)
                  sPath = (string)o ;
               if(sName != null && sPath != null)
               {
                  // We don't add ourselves
                  if(String.Compare(sPath.Trim(), sAssembly, true) != 0)
                     retVal.Add(new RegisteredTool(sName, sPath)) ;
               }
               else
               {
                  //Invalid entries
               }
            }
         }
         return retVal ;
      }
	}

   #endregion

   #region RegisteredTool class

   public class RegisteredTool
   {
      private string _name ;
      private string _path ;

      public RegisteredTool(string name, string path)
      {
         _name = name ;
         _path = path ;
      }

      public string Name
      {
         get { return _name ; }
         set { _name = value ; }
      }

      public string Path
      {
         get { return _path ; }
         set { _path = value ; }
      }

      public bool IsValid
      {
         get 
         {
            // No null names or empty names (spaces)
            if(_name == null || _name.Trim().Length == 0)
               return false ;
            // No null paths or invalid files
            if(_path == null || !File.Exists(_path))
               return false ;
            return true ;
         }
      }

      public void Launch()
      {
         if(IsValid)
         {
            ProcessStartInfo pInfo = new ProcessStartInfo(_path) ;
            FileInfo file = new FileInfo(_path) ;

            pInfo.UseShellExecute = false ;
            pInfo.WorkingDirectory = file.DirectoryName ;
            Process.Start(pInfo) ;
         }
         else
            throw new Exception("Invalid Registered Tool"); 
      }

      public void LaunchEvent(object sender, EventArgs e)
      {
         Launch() ;
      }
   }
   #endregion
}
