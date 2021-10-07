/*
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SqlServer.MessageBox
using ToolMessageBox;
using System.Windows.Forms;
using BBS.TracerX;

namespace Idera.SqlAdminToolset.Core
{
   /// <summary>
   /// ToolMessageBox is used for displaying messages, questions, and exceptions to
   /// the user.  Static methods cover most usage scenarios, but sometimes it is best to create
   /// an instance, configure it yourself, and call Show(IWin32Window parentWindow).
   /// </summary>
   public class ToolMessageBox : ExceptionMessageBox
   {
      static readonly Logger Log = Logger.GetLogger( "ToolMessageBox" );

      #region Constructors
      public ToolMessageBox()
      {
         Caption = Constants.ProductName;
         Symbol = ExceptionMessageBoxSymbol.Information;
      }

      public ToolMessageBox( string msg )
         : base( msg )
      {
         Caption = Constants.ProductName;
         Symbol = ExceptionMessageBoxSymbol.Error;
      }

      public ToolMessageBox( Exception exception )
         : base( exception )
      {
         Caption = Constants.ProductName;
         Symbol = ExceptionMessageBoxSymbol.Error;
      }

      public ToolMessageBox( string msg, Exception exception )
         : base( new ApplicationException( msg, exception ) ) // To show a text message and an exception, you must create a dummy wrapper exception.
      {
         Caption = Constants.ProductName;
         Symbol = ExceptionMessageBoxSymbol.Error;
      }
      #endregion Constructors

      #region Static Show*
      public static DialogResult ShowInfo( string message )
      {
         Log.Info( "Showing message:\n", message );
         ToolMessageBox msgbox = new ToolMessageBox( message );
         msgbox.Symbol = ExceptionMessageBoxSymbol.Information;
         return msgbox.Show( null );
      }

      public static DialogResult ShowWarning( string message )
      {
         Log.Warn( "Showing message:\n", message );
         ToolMessageBox msgbox = new ToolMessageBox( message );
         msgbox.Symbol = ExceptionMessageBoxSymbol.Warning;
         return msgbox.Show( null );
      }

      public static DialogResult ShowWarning( string message, Exception ex )
      {
         Log.Warn( "Showing message:\n", message, "\n\nand this exception:\n", ex );
         ToolMessageBox msgbox = new ToolMessageBox( message, ex );
         msgbox.Symbol = ExceptionMessageBoxSymbol.Warning;
         return msgbox.Show( null );
      }

      public static DialogResult ShowError( string message )
      {
         Log.Error( "Showing message:\n", message );
         ToolMessageBox msgbox = new ToolMessageBox( message );
         msgbox.Symbol = ExceptionMessageBoxSymbol.Error;
         return msgbox.Show( null );
      }

      public static DialogResult ShowError( string message, Exception ex )
      {
         Log.Error( "Showing message:\n", message, "\n\nand this exception:\n", ex );
         ToolMessageBox msgbox = new ToolMessageBox( message, ex );
         msgbox.Symbol = ExceptionMessageBoxSymbol.Error;
         return msgbox.Show( null );
      }

      public static DialogResult ShowStop( string message, Exception ex )
      {
         Log.Error( "Showing message:\n", message, "\n\nand this exception:\n", ex );
         ToolMessageBox msgbox = new ToolMessageBox( message, ex );
         msgbox.Symbol = ExceptionMessageBoxSymbol.Stop;
         return msgbox.Show( null );
      }

      public static DialogResult ShowQuestion( string message )
      {
         return ShowQuestion( message, ExceptionMessageBoxButtons.YesNo );
      }

      public static DialogResult ShowQuestion( string message, ExceptionMessageBoxButtons standardButtons )
      {
         using ( Log.InfoCall() )
         {
            Log.Info( "Showing message:\n", message );
            ToolMessageBox msgbox = new ToolMessageBox( message );
            msgbox.Symbol = ExceptionMessageBoxSymbol.Question;
            msgbox.Buttons = standardButtons;
            DialogResult result = msgbox.Show( null );
            Log.Info( "User's response is ", result );
            return result;
         }
      }
      #endregion Static Show*

   }
}
*/