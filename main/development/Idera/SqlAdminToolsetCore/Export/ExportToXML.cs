using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Idera.SqlAdminToolset.Core
{
   /// <summary>
   /// Common XML file export functionality.
   /// </summary>
   public static class ExportToXML
   {
      /// <summary>
      /// Copies a the contents of a ListView into an XML file.
      /// </summary>
      public static void CopyListView(ListView listView, string datasetName, bool isDataDescriptionOnFirstColumn)
      {
         SaveFileDialog _FileDialog = new SaveFileDialog();
         _FileDialog.AddExtension = true;
         _FileDialog.CheckPathExists = true;
         _FileDialog.OverwritePrompt = true;
         _FileDialog.DefaultExt = "xml";
         _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         _FileDialog.FileName = CoreGlobals.productName + ".xml";
         _FileDialog.Filter = "XML Data(*.xml)|*.xml|All files (*.*)|*.*";

         if (_FileDialog.ShowDialog() == DialogResult.OK)
         {
            CopyListView(listView, _FileDialog.FileName, datasetName, isDataDescriptionOnFirstColumn);
         }
      }

      public static void CopyListView(ListView listView, string filePath, string datasetName, bool isDataDescriptionOnFirstColumn)
      {
         XmlDocument _XmlDocument = new XmlDocument();

         XmlElement rootNode = _XmlDocument.CreateElement(GetSafeXmlElementNameString(datasetName));
         _XmlDocument.AppendChild(rootNode);

         int _ColumnIndex = 0;
         if (isDataDescriptionOnFirstColumn)
         {
            _ColumnIndex++;
         }

         for (; _ColumnIndex < listView.Columns.Count; _ColumnIndex++)
         {
            if (listView.Columns[_ColumnIndex].Width == 0)
            {
               continue;
            }
            
            bool _UseGroups = (listView.Groups.Count > 0) && listView.ShowGroups;
            
            string columnName = GetSafeXmlString(listView.Columns[_ColumnIndex].Text );
            if ( columnName == "" ) continue;

            XmlElement _ColumnNode = _XmlDocument.CreateElement(GetSafeXmlElementNameString(columnName));
            _XmlDocument.DocumentElement.PrependChild(_ColumnNode);

            if (_UseGroups)
            {
               foreach (ListViewGroup _Group in listView.Groups)
               {
                  if (_Group.Items.Count > 0)
                  {
                     XmlElement _GroupNode = _XmlDocument.CreateElement("Group");
                     _GroupNode.SetAttribute("Name", _Group.Header);
                     _ColumnNode.AppendChild(_GroupNode);
                     ParseItems(_GroupNode, _Group.Items, _ColumnIndex, isDataDescriptionOnFirstColumn);
                  }
               }
            }
            else
            {
               ParseItems(_ColumnNode, listView.Items, _ColumnIndex, isDataDescriptionOnFirstColumn);
            }
         }
         _XmlDocument.Save(filePath);

      }

      private static void ParseItems(XmlElement appendToNode, ListView.ListViewItemCollection items, int columnIndex, bool isDataDescriptionOnFirstColumn)
      {
         foreach (ListViewItem _Item in items)
         {
            XmlElement _ItemNode = appendToNode.OwnerDocument.CreateElement("Value");
            if (isDataDescriptionOnFirstColumn)
            {
               _ItemNode.SetAttribute("Name", _Item.SubItems[0].Text);
            }
            _ItemNode.AppendChild(appendToNode.OwnerDocument.CreateTextNode(_Item.SubItems[columnIndex].Text));

            appendToNode.AppendChild(_ItemNode);
         }
      }


      /// <summary>
      /// Copies the contents of a DataGridView into an XML file.
      /// </summary>
      public static void CopyDataGridView(DataGridView dataGridView, string datasetName)
      {
         CopyDataGridView(dataGridView, datasetName, false);
      }
      
      public static void CopyDataGridView(string defaultFileName, DataGridView dataGridView, string datasetName)
      {
         CopyDataGridView(defaultFileName, dataGridView, datasetName, false);
      }
      

      /// <summary>
      /// Copies the contents of a DataGridView into an XML file.
      /// </summary>
      public static void CopyDataGridView(DataGridView dataGridView, string datasetName, bool ignoreBlankColumnHeaders)
      {
        CopyDataGridView(null, dataGridView, datasetName, ignoreBlankColumnHeaders);
      }

      public static void CopyDataGridView(string defaultFileName, DataGridView dataGridView, string datasetName, bool ignoreBlankColumnHeaders)
      {
         SaveFileDialog _FileDialog = new SaveFileDialog();
         _FileDialog.AddExtension = true;
         _FileDialog.CheckPathExists = true;
         _FileDialog.OverwritePrompt = true;
         _FileDialog.DefaultExt = "xml";
         _FileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
         _FileDialog.FileName = String.IsNullOrEmpty(defaultFileName) ? CoreGlobals.productName + ".xml" : defaultFileName;
         _FileDialog.Filter = "XML Data(*.xml)|*.xml|All files (*.*)|*.*";

         if (_FileDialog.ShowDialog() == DialogResult.OK)
         {
            CopyDataGridView(dataGridView, _FileDialog.FileName, datasetName, ignoreBlankColumnHeaders);
         }
      }

      /// <summary>
      /// Copies the contents of a DataGridView into an XML file.
      /// </summary>
      public static void CopyDataGridView(DataGridView dataGridView, string filePath, string datasetName)
      {
         CopyDataGridView(dataGridView, filePath, datasetName, false);
      }

      /// <summary>
      /// Copies the contents of a DataGridView into an XML file.
      /// </summary>
      public static void CopyDataGridView(DataGridView dataGridView, string filePath, string datasetName, bool ignoreBlankColumnHeaders)
      {
         XmlDocument _XmlDocument = new XmlDocument();

         XmlElement rootNode = _XmlDocument.CreateElement(GetSafeXmlElementNameString(datasetName));
         _XmlDocument.AppendChild(rootNode);

         foreach (DataGridViewRow row in dataGridView.Rows)
         {
            string rowName = string.Format("Row_{0}", row.Index + 1);

            XmlElement _RowNode = _XmlDocument.CreateElement(GetSafeXmlElementNameString(rowName));
            _XmlDocument.DocumentElement.AppendChild(_RowNode);

            AddRowItems(_RowNode, row, ignoreBlankColumnHeaders);
         }
         _XmlDocument.Save(filePath);
      }

      private static void AddRowItems(XmlElement appendToNode, DataGridViewRow row, bool ignoreBlankColumnHeaders)
      {
         foreach (DataGridViewCell cell in row.Cells)
         {
            if (cell.Visible && 
               (cell.OwningColumn.HeaderText.Length > 0 || !ignoreBlankColumnHeaders))
            {
               // fix column names to use default name of column index (1 based) if blank
               string columnName = cell.OwningColumn.HeaderText.TrimEnd().Length == 0 ? string.Format("Column_{0}", cell.OwningColumn.DisplayIndex + 1) :
                                                     cell.OwningColumn.HeaderText;

               XmlElement _ItemNode = appendToNode.OwnerDocument.CreateElement(GetSafeXmlElementNameString(columnName));

               _ItemNode.AppendChild(appendToNode.OwnerDocument.CreateTextNode(cell.FormattedValue.ToString()));

               if (cell.OwningColumn.DisplayIndex == cell.OwningColumn.Index ||
                     cell.OwningColumn.DisplayIndex >= appendToNode.ChildNodes.Count)
               {
                  appendToNode.AppendChild(_ItemNode);
               }
               else
               {
                  appendToNode.InsertBefore(_ItemNode, appendToNode.ChildNodes[cell.OwningColumn.DisplayIndex]);
               }
            }
         }
      }

       private static string XmlEscape(string toEscape)
       {
           StringWriter stringWriter = new StringWriter();
           XmlWriterSettings writerSettings = new XmlWriterSettings();
           writerSettings.ConformanceLevel = ConformanceLevel.Fragment;
           writerSettings.CheckCharacters = true;
           using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, writerSettings))
           {
               xmlWriter.WriteString(toEscape);
           }
           return stringWriter.ToString();
       }


      /// <summary>
      /// Removes invalid characters per W3C specifications.
      /// </summary>
      /// <remarks>
      /// Verify that no character has a hex value greater than 0xFFFD, or less than 0x20. 
      /// Check that the character is not equal to the tab (\t), the newline (\n), the carriage return (\r), or is an invalid XML character below the range of 0x20. If any of these characters occur, an exception is thrown. 
      /// </remarks>
      public static string GetSafeXmlString(string value)
      {
         string newValue = "";
         for ( int i = 0; i < value.Length; ++i)
         {
            if (value[i] > 0xFFFD) continue;
            if (value[i] <=  0x20) continue; // && value[i] != '\t' && value[i] != '\n' && value[i] != '\r') continue;
            if (value[i] ==  '\\') continue;
            if (value[i] == 0x3A) continue;
            
            newValue += value[i];
         }

          newValue = XmlEscape(newValue);

         return newValue;
      }

      /// <summary>
      /// Removes invalid characters per W3C specifications.
      /// </summary>
      /// <remarks>
      /// Verify that no character has a hex value greater than 0xFFFD, or less than 0x20. 
      /// Check that the character is not equal to the tab (\t), the newline (\n), the carriage return (\r), or is an invalid XML character below the range of 0x20. If any of these characters occur, an exception is thrown. 
      /// </remarks>
      private static string GetSafeXmlElementNameString(string value)
      {
          StringBuilder workingSpace = new StringBuilder();

          for (int i = 0; i < value.Length; ++i)
          {
              // Add any characters we want to override the encode behavior

              if (value[i] > 0xFFFD) continue;
              else if (value[i] < 0x20) continue; // && value[i] != '\t' && value[i] != '\n' && value[i] != '\r') continue;
              else if (value[i] == '\\') continue;
              else if (value[i] == 0x20) workingSpace.Append("_"); // Space: " " => "_"                
              else if (value[i] == 0x25) workingSpace.Append("Percent"); // "%" => "Percent"
              else workingSpace.Append(value[i]); // Default just copy char to new string
          }

          return XmlConvert.EncodeName(workingSpace.ToString());
      }

   }
}
