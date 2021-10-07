using System;
using System.Windows.Forms;
using System.IO;

namespace Idera.SqlAdminToolset.Core
{
   public class DisplayHelp
   {
        //---------------------
        // Help File Constants
        //---------------------
        public static string CHMFILE = "http://wiki.idera.com/display/SQLAdminToolset";
        public static string MAINTOPIC = @"http://wiki.idera.com/display/SQLAdminToolset";
        public static string OPTIONS = @"http://wiki.idera.com/display/SQLAdminToolset/Set+SQL+Admin+Toolset+options";
        public static string SERVERGROUPS = @"http://wiki.idera.com/display/SQLAdminToolset/Manage+server+groups";
        public static string LICENSE = @"http://wiki.idera.com/display/SQLAdminToolset/Manage+license";
        public static string LAUNCHPAD = @"http://wiki.idera.com/display/SQLAdminToolset/Get+started";

        private DisplayHelp()
      {
      }

      public static void ShowHelp(/*Control control,*/string topic)
      {
         string helpfilepath = AppDomain.CurrentDomain.BaseDirectory + @"\Documentation\" + CHMFILE;

         try
         {
            IntPtr hWnd;

            if (!Idera.WebHelp.WebHelpLauncher.TryShowWebHelp(topic, out hWnd))
            {
               if (!File.Exists(helpfilepath))
               {
                  throw new Exception("The help file does not exist.");
               }
               /*Help.ShowHelp(control,
                             helpfilepath,
                             HelpNavigator.Topic,
                             topic);*/
            }
         }
         catch (Exception ex)
         {
            string msg = String.Format( "Unable to display the SQL admin toolset help file: {0}",  helpfilepath );
            Messaging.ShowException( msg, ex );
         }
      }
   }
}