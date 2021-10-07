using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace Idera.SqlAdminToolset.Core
{
   public class Launchpad
   {
      static public bool
         RunAndClose( Form parent )
      {
         bool success;

         success = Run( parent );
         if ( success )
         {
            // delay to avoid blank screen when we close to early
            Thread.Sleep(500);
            parent.Close();
         }

         return success;
      }

      static public bool
         Run( Form  parent )
      {
         bool launchSuccessful = true;
         string fullPath = "<path not set>";

         try
         {
            if ( parent != null ) parent.Cursor = Cursors.WaitCursor;

            string path = System.IO.Path.GetDirectoryName( Application.ExecutablePath );
            fullPath = Path.Combine( path, CoreGlobals.toolsLaunchpadExe );
            Process.Start( fullPath, "/NOWELCOMESCREEN" );
         }
         catch ( Exception ex )
         {
            launchSuccessful = false;
            Messaging.ShowException( "Error starting SQL admin toolset launchpad", ex );
         }
         finally
         {
            if ( parent != null ) parent.Cursor = Cursors.Default;
         }
          return launchSuccessful;
      }
   }
}
