using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core
{
   public class ExportToClipboard
   {
      #region
   
      //-----------------------------------------------------------------------------
      // CopyListViewToTabbedFormat
      //-----------------------------------------------------------------------------
      static public void
         CopyListViewToTabbedFormat(
            ListView listView,
            bool     hasIconColumn
         )
      {
         CopyListViewToTabbedFormat( "", listView, hasIconColumn, true );
      }
      
      static public void
         CopyListViewToTabbedFormat(
            ListView listView,
            bool     hasIconColumn,
            bool     selectedOnly
         )
      {
         CopyListViewToTabbedFormat( "", listView, hasIconColumn, selectedOnly );
      }
      
      static public void
         CopyListViewToTabbedFormat(
            string   heading,
            ListView listView,
            bool     hasIconColumn
         )
      {
         CopyListViewToTabbedFormat( listView, hasIconColumn, true );
      }
      
      static public void
         CopyListViewToTabbedFormat(
            string   heading,
            ListView listView,
            bool     hasIconColumn,
            bool     selectedOnly
         )
      {
         int firstColumn = (hasIconColumn ) ? 1 : 0;

         StringBuilder clipboard = new StringBuilder( 1024 ) ;
         
         if ( ! String.IsNullOrEmpty(heading) )
         {
            clipboard.AppendLine(heading);
            clipboard.AppendLine("");
         }
         
         // column header
         if ( listView.HeaderStyle != ColumnHeaderStyle.None )
         {
            for ( int c=firstColumn; c < listView.Columns.Count; c++ )
            {
               if ( c > firstColumn )  clipboard.Append( "\t" );
               
               string hdr = Helpers.StripFormatCharacters( listView.Columns[c].Text );
               clipboard.Append( hdr );
            }
            clipboard.Append( "\r\n" );
         }
         
         // data
         if ( selectedOnly )
         {
            foreach ( ListViewItem lvi in listView.SelectedItems )
            {
               clipboard.Append( GetItemString( listView, lvi, firstColumn ) );
            }
         }
         else
         {
            foreach ( ListViewItem lvi in listView.Items )
            {
               clipboard.Append( GetItemString( listView, lvi, firstColumn) );
            }
         }
         
         Clipboard.SetDataObject( clipboard.ToString() );
      }
      
      static private string
         GetItemString( 
            ListView     listView,
            ListViewItem lvi,
            int          firstColumn
         )
      {
         StringBuilder itemString = new StringBuilder(1024);
         
         for ( int i=firstColumn;i< listView.Columns.Count; i++ )
         {
            if ( i > firstColumn )  itemString.Append( "\t" );
            string col = Helpers.StripFormatCharacters( lvi.SubItems[i].Text );
            itemString.Append( col );
         }
         itemString.Append( "\r\n" );
         
         return itemString.ToString();
      }
      
      #endregion

      static string m_heading;
      static int[] m_columnWidths;
      static bool m_hasHeaderColumn;
      static int m_columnsPerPage;
      static string m_columnSeparator;
      
      #region CopyListView to report style format
      static ListView m_listView;
      


      //-----------------------------------------------------------------------------
      // CopyListView
      //-----------------------------------------------------------------------------
      static public void
         CopyListView(
            string   heading, 
            ListView listView,
            int[]    columnWidths
         )
      {
         CopyListView( heading, listView, columnWidths, false );
      }

      static public void
         CopyListView(
            string   heading, 
            ListView listView,
            int[]    columnWidths,
            bool     selectedOnly
         )
      {
         string output = CopyListViewToString( heading, listView, columnWidths, selectedOnly );
         Clipboard.SetDataObject( output );
      }
      
      static public void
         CopyListView(
            string   heading, 
            ListView listView,
            int[]    columnWidths,
            bool     hasHeaderColumn,
            int      columnsPerPage
         )
      {
         CopyListView( heading, listView, columnWidths, hasHeaderColumn, columnsPerPage, false );
      }

      static public void
         CopyListView(
            string   heading, 
            ListView listView,
            int[]    columnWidths,
            bool     hasHeaderColumn,
            int      columnsPerPage,
            bool     selectedOnly
         )
      {
         string output = CopyListViewToString( heading, listView, columnWidths, hasHeaderColumn, columnsPerPage );
         Clipboard.SetDataObject( output );
      }
      

      //-----------------------------------------------------------------------------
      // CopyListViewToString
      //-----------------------------------------------------------------------------
      static public string
         CopyListViewToString(
            string   heading, 
            ListView listView,
            int[]    columnWidths
         )
      {
         return CopyListViewToString( heading, listView, columnWidths, false );
      }
      
      static public string
         CopyListViewToString(
            string   heading, 
            ListView listView,
            int[]    columnWidths,
            bool     selectedOnly
         )
      {
         return CopyListViewToString( heading,
                                      listView,
                                      columnWidths,
                                      false,
                                      0,
                                      selectedOnly);
      }

      static public string
         CopyListViewToString(
            string   heading, 
            ListView listView,
            int[]    columnWidths,
            bool     hasHeaderColumn,
            int      columnsPerPage
         )
      {
         return CopyListViewToString( heading, listView, columnWidths, hasHeaderColumn, columnsPerPage, false );
      }
      
      static public string
         CopyListViewToString(
            string   heading, 
            ListView listView,
            int[]    columnWidths,
            bool     hasHeaderColumn,
            int      columnsPerPage,
            bool     selectedOnly
         )
      {
         // initialize properties
         m_heading         = heading;
         m_listView        = listView;
         m_columnWidths    = columnWidths;
         m_hasHeaderColumn = hasHeaderColumn;
         m_columnsPerPage  = (columnsPerPage <= 0) ? listView.Columns.Count : columnsPerPage;
         m_columnSeparator = new String( ' ', 2 );

         // get to work
         StringBuilder clipboard = new StringBuilder( 2048 );

         if ( m_heading != null && m_heading.Length != 0 )
         {
            clipboard.AppendFormat( "{0}\r\n\r\n", heading );
         }

         bool firstPage = true;
         int nextColumn = 0;
         for ( int c=(m_hasHeaderColumn) ? 1 : 0; c < m_listView.Columns.Count; c=nextColumn )
         {
            if ( firstPage )
               firstPage = false;
            else
               clipboard.Append( "\r\n\r\n\r\n\r\n" );

            clipboard.Append( GetPageHeading( c, out nextColumn ) );
            clipboard.Append( GetPageDataRows(c, nextColumn-1, selectedOnly ) );
         }
         
         return clipboard.ToString();
     }

      //-----------------------------------------------------------------------------
      // GetPageDataRows
      //-----------------------------------------------------------------------------
      static private string
         GetPageDataRows(
            int  startColumn, 
            int  endColumn,
            bool selectedOnly
         )
      {
         StringBuilder report = new StringBuilder(2048);
         if ((m_listView.Groups.Count != 0) && (m_listView.ShowGroups))
         {
            foreach (ListViewGroup _Group in m_listView.Groups)
            {
               if (selectedOnly && m_listView.SelectedItems.Count != 0)
               {
                  bool _GroupItemSelected = false;
                  foreach (ListViewItem _SelectedItem in m_listView.SelectedItems)
                  {
                     if (_Group.Items.Contains(_SelectedItem))
                     {
                        _GroupItemSelected = true;
                        break;
                     }
                  }
                  if (!_GroupItemSelected)
                  {
                     continue;
                  }
               }

               report.AppendFormat("\r\n===== {0} =====\r\n\r\n", _Group.Header);
               report.Append(Environment.NewLine);
               report.Append(ParseListViewItems(_Group.Items, startColumn, endColumn, selectedOnly));
            }
         }
         else
         {
            report.Append(ParseListViewItems(m_listView.Items, startColumn, endColumn, selectedOnly));
         }
         return report.ToString();
      }

      static private string ParseListViewItems(ListView.ListViewItemCollection items, 
            int startColumn,
            int endColumn, 
            bool selectedOnly)
      {
         StringBuilder report = new StringBuilder(2048);

         for (int i = 0; i < items.Count; i++)
         {
            if (selectedOnly && (m_listView.SelectedItems.Count != 0) && (!items[i].Selected))
            {
               continue;
            }

            // data
            string thisColumn = "";
            int numLines = 0;
            bool needMoreLines = true;
            while (needMoreLines)
            {
               StringBuilder ln = new StringBuilder(512);
               needMoreLines = false;

               // headerColumn
               if (m_hasHeaderColumn && m_columnWidths[0] != 0)
               {
                  bool hdrColumnNeedsMoreLines = false;
                  thisColumn = CreatePrintColumn(items[i].SubItems[0].Text,
                                                   numLines,
                                                   m_columnWidths[0],
                                                   m_columnSeparator,
                                                   out hdrColumnNeedsMoreLines);
                  if (hdrColumnNeedsMoreLines) needMoreLines = true;
                  ln.Append(thisColumn);
               }

               // dataColumns
               for (int c = startColumn; c <= endColumn; c++)
               {
                  if (m_columnWidths[c] != 0)  // use columnWidth = 0 to ignore column for clipboard
                  {
                     bool columnNeedsMoreLines = false;
                     thisColumn = CreatePrintColumn(items[i].SubItems[c].Text,
                                                      numLines,
                                                      m_columnWidths[c],
                                                      (c == endColumn) ? "" : m_columnSeparator,
                                                      out columnNeedsMoreLines);
                     if (columnNeedsMoreLines) needMoreLines = true;
                     ln.Append(thisColumn);
                  }
               }
               numLines++;
               report.AppendFormat("{0}\r\n", ln.ToString());
            }
         }
         return report.ToString();
      }

      //-----------------------------------------------------------------------------
      // GetPageHeading - Column headers underlined by dashes
      //-----------------------------------------------------------------------------
      static private string 
         GetPageHeading(
            int     startColumn, 
            out int nextColumn
         )
      {
         nextColumn = m_listView.Columns.Count;

         // row titles
         StringBuilder columnHeaders = new StringBuilder( 1024 );

         string thisColumn = "";
         int numLines = 0;
         bool needMoreLines = true;
         while ( needMoreLines )
         {
            int columnsLeftToProcess = m_columnsPerPage;
            StringBuilder ln = new StringBuilder( 512 );
            needMoreLines = false;

            // headerColumn
            if ( m_hasHeaderColumn && m_columnWidths[0] != 0 )
            {
               bool hdrColumnNeedsMoreLines = false;
               thisColumn = CreatePrintColumn( m_listView.Columns[0].Text,
                                               numLines,
                                               m_columnWidths[0],
                                               m_columnSeparator,
                                               out hdrColumnNeedsMoreLines );
               if ( hdrColumnNeedsMoreLines ) needMoreLines = true;
               ln.Append( thisColumn );
            }


            // dataColumns
            int c;
            for ( c = startColumn;
                  (columnsLeftToProcess != 0) && (c < m_listView.Columns.Count);
                  c++ )
            {
               if ( m_columnWidths[c] != 0 )  // use columnWidth = 0 to ignore column for clipboard
               {
                  columnsLeftToProcess--;

                  bool columnNeedsMoreLines = false;
                  thisColumn = CreatePrintColumn( m_listView.Columns[c].Text,
                                                  numLines,
                                                  m_columnWidths[c],
                                                  (c == m_listView.Columns.Count - 1) ? "" : m_columnSeparator,
                                                  out columnNeedsMoreLines );
                  if ( columnNeedsMoreLines ) needMoreLines = true;
                  ln.Append( thisColumn );
               }
            }

            // set starting column for next page
            nextColumn = c;

            numLines++;
            columnHeaders.AppendFormat( "{0}\r\n", ln.ToString() );
         }


         // Dashes
         string dashes = "";

         // header column dashes
         if ( m_hasHeaderColumn && m_columnWidths[0] != 0 )
         {
            if ( String.IsNullOrEmpty(m_listView.Columns[0].Text) )
               dashes += new String( ' ', m_columnWidths[0] );
            else
               dashes += new String( '-', m_columnWidths[0] );

            dashes += m_columnSeparator;
         }

         // data column dashes
         for ( int c = startColumn; c < nextColumn; c++)
         {
            if ( m_columnWidths[c] != 0 )
            {
               if ( String.IsNullOrEmpty(m_listView.Columns[c].Text) )
                  dashes += new String( ' ', m_columnWidths[c]  );
               else
                  dashes += new String( '-', m_columnWidths[c]  );

               if ( c != m_listView.Columns.Count - 1 ) dashes += m_columnSeparator;
            }
         }

         // Add them together
         string header = columnHeaders + dashes + "\r\n";
         return header.ToString();
      }


      //-----------------------------------------------------------------------------
      // CreatePrintColumn
      //-----------------------------------------------------------------------------
      static private string
         CreatePrintColumn(
            string      cellValue,       // the initial string value for this cell of data
            int         numLines,        // number of lines printed so far for this row of data
            int         columnWidth,     // max width for this column
            string      separator,       // spacing between columns (not include for last column on page)
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
         thisColumn += separator;

         return( thisColumn );
      }
      
      #endregion


      #region Copy DataGridView to Clipboard

       static DataGridView m_dataGridView;

       static public string
            CopyDataGridViewToString(
               string heading,
               DataGridView dataGridView,
               int[] columnWidths,
               int columnsPerPage,
               bool selectedOnly
            )
       {
           // initialize properties
           m_heading = heading;
           m_dataGridView = dataGridView;
           m_columnWidths = columnWidths;
           m_columnsPerPage = (columnsPerPage <= 0) ? dataGridView.Columns.Count : columnsPerPage;
           m_columnSeparator = new String(' ', 2);

           // get to work
           StringBuilder clipboard = new StringBuilder(2048);

           if (m_heading != null && m_heading.Length != 0)
           {
               clipboard.AppendFormat("{0}\r\n\r\n", heading);
           }

           bool firstPage = true;
           int nextColumn = 0;
           for (int c = 0; c < m_dataGridView.Columns.Count; c = nextColumn)
           {
               if (firstPage)
                   firstPage = false;
               else
                   clipboard.Append("\r\n\r\n\r\n\r\n");

               clipboard.Append(GetPageHeadingForGrid(c, out nextColumn));
               clipboard.Append(GetPageDataRowsForGrid(c, nextColumn - 1, selectedOnly));
           }

           return clipboard.ToString();
       }

       static private string GetPageHeadingForGrid( int startColumn,
                                                    out int nextColumn)
       {
           nextColumn = m_dataGridView.Columns.Count;

           int columnsLeftToProcess = m_columnsPerPage;

           // row titles
           StringBuilder columnHeaders = new StringBuilder(1024);

           string thisColumn = "";
           int numLines = 0;
           bool needMoreLines = true;
           while (needMoreLines)
           {
               StringBuilder ln = new StringBuilder(512);
               needMoreLines = false;

               //// headerColumn
               //if ( m_hasHeaderColumn && m_columnWidths[0] != 0 )
               //{
               //   bool hdrColumnNeedsMoreLines = false;
               //   thisColumn = CreatePrintColumn( m_gridDataView.Co,
               //                                   numLines,
               //                                   m_columnWidths[0],
               //                                   m_columnSeparator,
               //                                   out hdrColumnNeedsMoreLines );
               //   if ( hdrColumnNeedsMoreLines ) needMoreLines = true;
               //   ln.Append( thisColumn );
               //}


               // dataColumns
               int c;
               for (c = startColumn;
                    (columnsLeftToProcess != 0) && (c < m_dataGridView.Columns.Count);
                    c++)
               {
                   if (m_columnWidths[c] != 0) // use columnWidth = 0 to ignore column for clipboard
                   {
                       columnsLeftToProcess--;

                       bool columnNeedsMoreLines = false;
                       thisColumn = CreatePrintColumn(m_dataGridView.Columns[c].HeaderText,
                                                      numLines,
                                                      m_columnWidths[c],
                                                      (c == m_dataGridView.Columns.Count - 1) ? "" : m_columnSeparator,
                                                      out columnNeedsMoreLines);
                       if (columnNeedsMoreLines) needMoreLines = true;
                       ln.Append(thisColumn);
                   }
               }

               // set starting column for next page
               nextColumn = c;

               numLines++;
               columnHeaders.AppendFormat("{0}\r\n", ln.ToString());
           }
           // Dashes
         string dashes = "";

         // header column dashes
         //if ( m_hasHeaderColumn && m_columnWidths[0] != 0 )
         //{
         //   if ( String.IsNullOrEmpty(m_listView.Columns[0].Text) )
         //      dashes += new String( ' ', m_columnWidths[0] );
         //   else
         //      dashes += new String( '-', m_columnWidths[0] );

         //   dashes += m_columnSeparator;
         //}

         // data column dashes
         for ( int c = startColumn; c < nextColumn; c++)
         {
            if ( m_columnWidths[c] != 0 )
            {
               if ( String.IsNullOrEmpty(m_listView.Columns[c].Text) )
                  dashes += new String( ' ', m_columnWidths[c]  );
               else
                  dashes += new String( '-', m_columnWidths[c]  );

               if ( c != m_listView.Columns.Count - 1 ) dashes += m_columnSeparator;
            }
         }

         // Add them together
         string header = columnHeaders + dashes + "\r\n";
         return header.ToString();
      }
       

       static private string GetPageDataRowsForGrid( int startColumn,
                                              int endColumn,
                                              bool selectedOnly)
       {
           // are we including groups?
           //bool groups = (m_listView.Groups.Count != 0) && (m_listView.ShowGroups);
           //ListViewGroup lastGroup = new ListViewGroup();

           StringBuilder report = new StringBuilder(2048);

           for (int i = 0; i < m_dataGridView.Rows.Count; i++)
           {
               if (selectedOnly && (m_dataGridView.SelectedRows.Count != 0) && (!m_dataGridView.Rows[i].Selected))
               {
                   continue;
               }

               //// group support
               //if (groups)
               //{
               //    if (m_listView.Items[i].Group != lastGroup)
               //    {
               //        lastGroup = m_listView.Items[i].Group;

               //        report.AppendFormat("\r\n===== {0} =====\r\n\r\n",
               //                             (m_listView.Items[i].Group == null)
               //                                ? "Default"
               //                                : m_listView.Items[i].Group.Header);
               //    }
               //}

               // data
               string thisColumn = "";
               int numLines = 0;
               bool needMoreLines = true;
               while (needMoreLines)
               {
                   StringBuilder ln = new StringBuilder(512);
                   needMoreLines = false;

                   //// headerColumn
                   //if (m_hasHeaderColumn && m_columnWidths[0] != 0)
                   //{
                   //    bool hdrColumnNeedsMoreLines = false;
                   //    thisColumn = CreatePrintColumn(m_listView.Items[i].SubItems[0].Text,
                   //                                     numLines,
                   //                                     m_columnWidths[0],
                   //                                     m_columnSeparator,
                   //                                     out hdrColumnNeedsMoreLines);
                   //    if (hdrColumnNeedsMoreLines) needMoreLines = true;
                   //    ln.Append(thisColumn);
                   //}

                   // dataColumns
                   for (int c = startColumn; c <= endColumn; c++)
                   {
                       if (m_columnWidths[c] != 0)  
                       {
                           bool columnNeedsMoreLines = false;
                           thisColumn = CreatePrintColumn(m_dataGridView.Rows[i].Cells[c].FormattedValue.ToString(),
                                                            numLines,
                                                            m_columnWidths[c],
                                                            (c == endColumn) ? "" : m_columnSeparator,
                                                            out columnNeedsMoreLines);
                           if (columnNeedsMoreLines) needMoreLines = true;
                           ln.Append(thisColumn);
                       }
                   }
                   numLines++;
                   report.AppendFormat("{0}\r\n", ln.ToString());
               }
           }
           return report.ToString();
       }

       #endregion

      #region Copy DataGridView to Clipboard Tabbed
   
      //-----------------------------------------------------------------------------
      // CopyListViewToTabbedFormat - Loads clipboard object with string
      //-----------------------------------------------------------------------------
      static public void
         CopyDataGridViewToTabbedFormat(
            DataGridView dataGridView
         )
      {
          CopyDataGridViewToTabbedFormat(dataGridView, true);
      }

      static public void
         CopyDataGridViewToTabbedFormat(
            DataGridView dataGridView,
            bool selectedOnly
         )
      {
         CopyDataGridViewToTabbedFormat(dataGridView, selectedOnly, false);
      }
      
      static public void
        CopyDataGridViewToTabbedFormat(
            DataGridView dataGridView,
            bool     selectedOnly,
            bool     ignoreBlankColumnHeaders
         )
      {
         Clipboard.SetDataObject( GetDataGridViewInTabbedFormat(dataGridView,selectedOnly,ignoreBlankColumnHeaders) );
      }
      
      //--------------------------------------------------------------------------------------------
      // GetDataGridViewInTabbedFormat - Gets string to put in clipboard - doesnt load to clipboard
      //--------------------------------------------------------------------------------------------
      static public string GetDataGridViewInTabbedFormat(DataGridView dataGridView)
      {
          return GetDataGridViewInTabbedFormat(dataGridView, true, false);
      }

      static public string GetDataGridViewInTabbedFormat(
                                    DataGridView dataGridView,
                                    bool selectedOnly)
      {
         return GetDataGridViewInTabbedFormat(dataGridView, selectedOnly, false);
      }

      static public string GetDataGridViewInTabbedFormat(
            DataGridView dataGridView,
            bool     selectedOnly,
            bool     ignoreBlankColumnHeaders
         )
      {
         StringBuilder clipboard = new StringBuilder( 1024 ) ;
         
         // column header
         
        for ( int c = 0; c < dataGridView.Columns.Count; c++ )
        {
           if (dataGridView.Columns[c].Visible &&
              (!ignoreBlankColumnHeaders || dataGridView.Columns[c].HeaderText.Length > 0))
           {
              if (clipboard.Length > 0) clipboard.Append("\t");

              string hdr = Helpers.StripFormatCharacters(dataGridView.Columns[c].HeaderText);
              clipboard.Append(hdr);
           }
        }
        clipboard.Append( "\r\n" );
         
         // data
         if ( selectedOnly )
         {
            SortedList<int, int> items = new SortedList<int, int>();
            foreach ( DataGridViewRow row in dataGridView.SelectedRows )
            {
               items.Add(row.Index, row.Index);
            }
            foreach (int idx in items.Values)
            {
               clipboard.Append(GetItemString(dataGridView.Rows[idx], ignoreBlankColumnHeaders));
            }
         }
         else
         {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
               clipboard.Append(GetItemString(row, ignoreBlankColumnHeaders));
            }
         }
         
         return clipboard.ToString();
      }

      static private string
         GetItemString( DataGridViewRow row, bool ignoreBlankColumnHeaders)
      {
         StringBuilder itemString = new StringBuilder(1024);

         for ( int i=0 ;i< row.Cells.Count; i++ )
         {
            if (row.Cells[i].OwningColumn.Visible &&
              (!ignoreBlankColumnHeaders || row.Cells[i].OwningColumn.HeaderText.Length > 0))
            {
               if (itemString.Length > 0) itemString.Append("\t");
               string col = Helpers.StripFormatCharacters(row.Cells[i].FormattedValue.ToString());
               itemString.Append(col);
            }
         }
         itemString.Append( "\r\n" );

         return itemString.ToString();
     }

      #endregion
 }
}
