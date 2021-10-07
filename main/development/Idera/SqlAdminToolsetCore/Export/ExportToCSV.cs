using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Idera.SqlAdminToolset.Core
{
   /// <summary>
   /// Common CSV file export functionality.
   /// </summary>
   public static class ExportToCSV
   {
      /// <summary>
      /// Copies the contents of a listview into a csv file.
      /// </summary>
      public static void CopyListView(ListView listView)
      {
         SaveFileDialog _FileDialog = new SaveFileDialog();
         _FileDialog.AddExtension = true;
         _FileDialog.CheckPathExists = true;
         _FileDialog.OverwritePrompt = true;
         _FileDialog.DefaultExt = "csv";
         _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         _FileDialog.FileName = CoreGlobals.productName + ".csv";
         _FileDialog.Filter = "CSV File (Comma Separated Values)(*.csv)|*.csv|All files (*.*)|*.*";

         if (_FileDialog.ShowDialog() == DialogResult.OK)
         {
            CopyListView(listView, _FileDialog.FileName);
         }
      }
      
      /// <summary>
      /// Copies the contents of a listview into a csv file.
      /// </summary>
      public static void CopyListView(string defaultFileName, ListView listView)
      {
         SaveFileDialog _FileDialog = new SaveFileDialog();
         _FileDialog.AddExtension = true;
         _FileDialog.CheckPathExists = true;
         _FileDialog.OverwritePrompt = true;
         _FileDialog.DefaultExt = "csv";
         _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         _FileDialog.FileName = defaultFileName;
         _FileDialog.Filter = "CSV File (Comma Separated Values)(*.csv)|*.csv|All files (*.*)|*.*";

         if (_FileDialog.ShowDialog() == DialogResult.OK)
         {
            CopyListView(listView, _FileDialog.FileName);
         }
      }

      /// <summary>
      /// Copies the contents of a listview into the specified csv file.
      /// </summary>
      public static void CopyListView(ListView listView, string filePath)
      {
         StringBuilder _CsvData = new StringBuilder();
         bool _HasData = false;
         //Header
         for (int _ColumnIndex = 0; _ColumnIndex < listView.Columns.Count; _ColumnIndex++)
         {
            if ( ! isBlankColumn( listView, _ColumnIndex) )
            {
               _CsvData.Append(GetCsvString(listView.Columns[_ColumnIndex].Text, _HasData));
               _HasData = true;
            }
         }
         _CsvData.Append(Environment.NewLine);

         if ((listView.Groups.Count > 0) && listView.ShowGroups)
         {
            foreach (ListViewGroup _Group in listView.Groups)
            {
               if (_Group.Items.Count > 0)
               {
                  _CsvData.Append(GetCsvString("=====" + _Group.Header + "=====", false));
                  _CsvData.Append(Environment.NewLine);
                  _CsvData.Append(ParseItems(listView, _Group.Items));
               }
            }
         }
         else
         {
            _CsvData.Append(ParseItems(listView, listView.Items));
         }
         
         if (File.Exists(filePath))
         {
            try
            {
               File.Delete(filePath);
            }
            catch ( Exception ex )
            {
               Messaging.ShowError( 
                  String.Format( "An error occurred trying to overwrite the existing file.\r\n\r\nError: {0}", 
                                 ex.Message ) );
               return; // we cant write so just give up                                 
            }
         }

         using (FileStream _Stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
         using (StreamWriter _Writer = new StreamWriter(_Stream))
         {
            _Writer.Write(_CsvData.ToString());
         }
      }
      
      static private bool isBlankColumn( ListView listView, int column )
      {
         bool blankColumn = false;
         
         if (listView.Columns[column].Width <= 0 || listView.Columns[column].Text.Length == 0 )
         {
            blankColumn = true;
         }
            
         return blankColumn;
      }
      

      private static string ParseItems(ListView listView, ListView.ListViewItemCollection items)
      {
         StringBuilder _CsvData = new StringBuilder();
         foreach (ListViewItem _Item in items)
         {
            bool _HasData = false;

            for (int _SubItemIndex = 0; _SubItemIndex < _Item.SubItems.Count; _SubItemIndex++)
            {
               if ( ! isBlankColumn( listView, _SubItemIndex) )
               {
                  _CsvData.Append(GetCsvString(_Item.SubItems[_SubItemIndex].Text, _HasData));
                  _HasData = true;
               }
            }
            _CsvData.Append(Environment.NewLine);
         }
         return _CsvData.ToString();
      }

      /// <summary>
      /// Returns a string with the correct format to fit into a csv file.
      /// </summary>
      public static string GetCsvString(string value, bool lineHasData)
      {
         string _ReturnValue = lineHasData ? "," : string.Empty;
         
         bool wrapInQuotes = false;

         if (value.Length > 0 )
         {
            if ( value[0] == '-')
            {
               if (value.Length == 1 )
                  wrapInQuotes = true;
               else
               {
                  for ( int i=1; i<value.Length; i++)
                  {
                     if ( ! Char.IsNumber( value,i) )
                        wrapInQuotes = true;
                  }
               }
            }
            else if (value[0] == '=')
            {
               wrapInQuotes = true;
            }
         }

         if (wrapInQuotes)
         {
            value = "'" + value;
         }
         _ReturnValue += string.Format("\"{0}\"", value.Trim());
         return _ReturnValue;
      }


      /// <summary>
      /// Copies the contents of a datagridview into a csv file.
      /// </summary>
      public static void CopyDataGridView(DataGridView dataGridView)
      {
         CopyDataGridView(dataGridView, false);
      }
      
      public static void CopyDataGridView(string defaultFileName, DataGridView dataGridView)
      {
         CopyDataGridView(defaultFileName, dataGridView, false);
      }

      /// <summary>
      /// Copies the contents of a datagridview into a csv file.
      /// </summary>
      public static void CopyDataGridView(DataGridView dataGridView, bool ignoreBlankColumnHeaders)
      {
          SaveFileDialog _FileDialog = new SaveFileDialog();
          _FileDialog.AddExtension = true;
          _FileDialog.CheckPathExists = true;
          _FileDialog.OverwritePrompt = true;
          _FileDialog.DefaultExt = "csv";
          _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
          _FileDialog.FileName = CoreGlobals.productName + ".csv";
          _FileDialog.Filter = "CSV File (Comma Separated Values)(*.csv)|*.csv|All files (*.*)|*.*";

          if (_FileDialog.ShowDialog() == DialogResult.OK)
          {
              CopyDataGridView(dataGridView, _FileDialog.FileName, ignoreBlankColumnHeaders);
          }
      }
      
      /// <summary>
      /// Copies the contents of a datagridview into a csv file.
      /// </summary>
      public static void CopyDataGridView(string defaultFileName, DataGridView dataGridView, bool ignoreBlankColumnHeaders)
      {
          SaveFileDialog _FileDialog = new SaveFileDialog();
          _FileDialog.AddExtension = true;
          _FileDialog.CheckPathExists = true;
          _FileDialog.OverwritePrompt = true;
          _FileDialog.DefaultExt = "csv";
          _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
          _FileDialog.FileName = defaultFileName;
          _FileDialog.Filter = "CSV File (Comma Separated Values)(*.csv)|*.csv|All files (*.*)|*.*";

          if (_FileDialog.ShowDialog() == DialogResult.OK)
          {
              CopyDataGridView(dataGridView, _FileDialog.FileName, ignoreBlankColumnHeaders);
          }
      }

      /// <summary>
      /// Copies the contents of a datagridview into the specified csv file.
      /// </summary>
      public static void CopyDataGridView(DataGridView dataGridView, string filePath)
      {
         CopyDataGridView(dataGridView, filePath, false);
      }

      /// <summary>
      /// Copies the contents of a datagridview into the specified csv file.
      /// </summary>
      public static void CopyDataGridView(DataGridView dataGridView, string filePath, bool ignoreBlankColumnHeaders)
      {
          StringBuilder _CsvData = new StringBuilder();
          bool _HasData = false;
          //Header
          for (int _ColumnIndex = 0; _ColumnIndex < dataGridView.ColumnCount; _ColumnIndex++)
          {
             if (dataGridView.Columns[_ColumnIndex].Visible &&
                (!ignoreBlankColumnHeaders || dataGridView.Columns[_ColumnIndex].HeaderText.Length > 0))
             {
                _CsvData.Append(GetCsvString(dataGridView.Columns[_ColumnIndex].HeaderText, _HasData));
                _HasData = true;
             }
          }
          _CsvData.Append(Environment.NewLine);
          _CsvData.Append(ParseItems(dataGridView, ignoreBlankColumnHeaders));

          if (File.Exists(filePath))
          {
              File.Delete(filePath);
          }

          using (FileStream _Stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
          using (StreamWriter _Writer = new StreamWriter(_Stream))
          {
              _Writer.Write(_CsvData.ToString());
          }
      }

      private static string ParseItems(DataGridView dataGridView, bool ignoreBlankColumnHeaders)
      {
         StringBuilder _CsvData = new StringBuilder();
         foreach (DataGridViewRow row in dataGridView.Rows)
         {
            bool _HasData = false;

            for (int cell = 0; cell < row.Cells.Count; cell++)
            {
               if (row.Cells[cell].Visible &&
                  (row.Cells[cell].OwningColumn.HeaderText.Length > 0 || !ignoreBlankColumnHeaders))
               {
                  _CsvData.Append(GetCsvString(row.Cells[cell].FormattedValue.ToString(), _HasData));
                  _HasData = true;
               }
            }
            _CsvData.Append(Environment.NewLine);
         }
         return _CsvData.ToString();
      }
   }
}
