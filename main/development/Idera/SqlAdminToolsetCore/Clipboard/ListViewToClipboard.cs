using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
   public class ToolClipboard
   {
      static public void
         CopyListView(
            string   heading, 
            ListView listView,
            int[]    columnWidths
         )
      {
         int separator = 2;

         StringBuilder clipboard = new StringBuilder( 2048 );

         if ( heading != null && heading.Length != 0 )
         {
            clipboard.AppendFormat( "{0}\r\n\r\n", heading );
         }

         clipboard.Append( GetHeaderRows( listView, columnWidths, separator ) );
         clipboard.Append( GetDataRows(   listView, columnWidths, separator ) );

         Clipboard.SetDataObject( clipboard.ToString() );
      }

      static private string
         GetDataRows(
            ListView listView,
            int[]    columnWidths,
            int      separator )
      {
         bool groups   = ( listView.Groups.Count != 0 ) && (listView.ShowGroups );
         ListViewGroup lastGroup = new ListViewGroup();

         StringBuilder report = new StringBuilder(2048);

         for ( int i=0; i< listView.Items.Count; i++ )
         {
            // group support
            if ( groups )
            {
               if ( listView.Items[i].Group != lastGroup )
               {
                  lastGroup = listView.Items[i].Group;

                  report.AppendFormat( "\r\n===== {0} =====\r\n\r\n",
                                       (listView.Items[i].Group == null )
                                          ? "Default"         
                                          : listView.Items[i].Group.Header );
               }
            }

            // data
            int  numLines      = 0;
            bool needMoreLines = true;
            while ( needMoreLines )
            {
               StringBuilder ln = new StringBuilder(512);
               needMoreLines = false;

               for ( int c = 0; c < columnWidths.GetLength(0); c++ )
               {
                  if ( columnWidths[c] != 0 )  // use columnWidth = 0 to ignore column for clipboard
                  {
                     bool columnNeedsMoreLines = false;  
                     string thisColumn  = CreatePrintColumn( listView.Items[i].SubItems[c].Text,
                                                             numLines,
                                                             columnWidths[c],
                                                             (c == listView.Columns.Count-1 ) ? 0 : separator,
                                                             out columnNeedsMoreLines );
                     if ( columnNeedsMoreLines ) needMoreLines = true;
                     ln.Append( thisColumn );
                  }
               }
               numLines ++;
               report.AppendFormat( "{0}\r\n", ln.ToString() );
            }
         }
         return report.ToString();
      }

      static private string 
         GetHeaderRows(
            ListView   listView,
            int[]      columnWidths,
            int        separator
         )
      {
         // row titles
         StringBuilder columnHeaders = new StringBuilder( 1024 );

         int numLines = 0;
         bool needMoreLines = true;
         while ( needMoreLines )
         {
            StringBuilder ln = new StringBuilder( 512 );
            needMoreLines = false;

            for ( int c = 0; c < columnWidths.GetLength( 0 ); c++ )
            {
               if ( columnWidths[c] != 0 )  // use columnWidth = 0 to ignore column for clipboard
               {
                  bool columnNeedsMoreLines = false;
                  string thisColumn = CreatePrintColumn( listView.Columns[c].Text,
                                                         numLines,
                                                         columnWidths[c],
                                                         (c == listView.Columns.Count - 1) ? 0 : separator,
                                                         out columnNeedsMoreLines );
                  if ( columnNeedsMoreLines ) needMoreLines = true;
                  ln.Append( thisColumn );
               }
            }
            numLines++;
            columnHeaders.AppendFormat( "{0}\r\n", ln.ToString() );
         }

         // Dashes
         string dashes = "";
         for (int c=0; c<columnWidths.GetLength(0); c++)
         {
            if ( columnWidths[c] != 0 )  // use columnWidth = 0 to ignore column for clipboard
            {
               if ( String.IsNullOrEmpty(listView.Columns[c].Text) )
                  dashes += new String( ' ', columnWidths[c]  );
               else
                  dashes += new String( '-', columnWidths[c]  );

               if ( c != listView.Columns.Count - 1 ) dashes += new String( ' ', separator );
            }
         }

         // Add them together
         string header = columnHeaders + dashes + "\r\n";
         return header.ToString();
      }

      static private string
         CreatePrintColumn(
            string      cellValue,       // the initial string value for this cell of data
            int         numLines,        // number of lines printed so far for this row of data
            int         columnWidth,     // max width for this column
            int         separatorSpace,  // amount of space between columns
            out bool    needMoreLines
         )
      {
         needMoreLines = false;

         string thisColumn  = "";

         int amountLeft     = Math.Max( 0, cellValue.Length - (numLines*columnWidth) );
         int lengthThisLine = Math.Min( columnWidth, amountLeft );

         if ( lengthThisLine != 0 )
         {
            thisColumn  += cellValue.Substring( numLines*columnWidth, lengthThisLine );
         
            // if any line that needs spaces on this line doesnt finish its string we need more lines
            if ( numLines*columnWidth + lengthThisLine < cellValue.Length ) needMoreLines  = true;
         }
         if ( columnWidth != lengthThisLine ) thisColumn += new String( ' ', columnWidth - lengthThisLine );

         // separate columns
         thisColumn += new String( ' ', separatorSpace );

         return( thisColumn );
      }
   }
}
