using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.PatchEditor
{
   static class Program
   {
      //-----------------------------------------------------------------------
      // Main
      //
      /// <summary>
      /// Main - The main entry point for the application.
      /// </summary>
      //-----------------------------------------------------------------------
      [STAThread]
      static void Main()
      {
         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault( false );
         Application.Run( new Form_Main() );
      }
   }
}
