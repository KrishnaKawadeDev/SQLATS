using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Idera.SqlAdminToolset.PartitionGenerator
{
   internal partial class Form_PartitionInfo : Form
   {
      ServerInformation _ServerInfo;
      string _Database;
      Dictionary<string, string> _TableColumns;

      List<string> _AllowedTypes = new List<string>();
      List<string> _NotAllowedTypes = new List<string>();
      
      public Form_PartitionInfo(ServerInformation serverInfo, string database, PartitionAction action, List<string> filegroups)
      {
         InitializeComponent();
         _Action = action;
         _FileGroups = filegroups;
         _ServerInfo = serverInfo;
         _Database = database;
      }

      #region Accessors
      private PartitionScheme _Scheme;
      private PartitionAction _Action;
      private List<string> _FileGroups;
      private TableInfo _Table;

      /// <summary>
      /// Partition scheme.
      /// </summary>
      public PartitionScheme Scheme
      {
         get
         {
            return _Scheme;
         }
         set
         {
            _Scheme = value;
         }
      }

      /// <summary>
      /// Table information.
      /// </summary>
      public TableInfo Table
      {
         get { return _Table; }
         set { _Table = value; }
      }
      #endregion

      protected override void OnLoad(EventArgs e)
      {
         base.OnLoad(e);

         columnFileGroup.Items.AddRange(_FileGroups.ToArray());
         textTableName.Text = _Table.Name;
         _TableColumns = PartitionHelper.GetTableColumns(_ServerInfo, _Database, _Table);

         DisplayData();
      }

      /// <summary>
      /// Displays form data depending on the requested action.
      /// </summary>
      private void DisplayData()
      {
         switch (_Action)
         {
            case PartitionAction.View:
               textColumnName.Text = _Scheme.Column;
               textFunctionName.Text = _Scheme.Function;
               textSchemeName.Text = _Scheme.Name;
               textBoundaryType.Text = _Scheme.IsRightPartition ? "RIGHT" : "LEFT";
               textIndex.Text = _Table.ClusteredIndex;

               columnFileGroup.ReadOnly = textBoundaryType.ReadOnly = textColumnName.ReadOnly = 
                  textFunctionName.ReadOnly = textSchemeName.ReadOnly = textIndex.ReadOnly = true;
               textColumnName.Visible = textBoundaryType.Visible = true;
               linkAddNewRange.Visible = listColumns.Visible = listBoundaryType.Visible = false;
               textIndex.WatermarkEnabled = false;

               foreach (PartitionRange _Range in _Scheme.RangeValues)
               {
                  AddRangeRow(_Range, _Scheme.IsRightPartition);
               }

               textDataType.Text = _TableColumns[_Scheme.Column];
               SetCellReadOnly(gridRanges.Rows[0].Cells[columnMerge.Index], true);
               break;
            case PartitionAction.Create:
               textFunctionName.ReadOnly = textSchemeName.ReadOnly = false;
               columnRowCount.Visible = columnMerge.Visible = columnSplit.Visible = textColumnName.Visible = textBoundaryType.Visible = false;
               linkAddNewRange.Visible = listColumns.Visible = listBoundaryType.Visible = true;
               listBoundaryType.SelectedIndex = 0;

               if (_Table.HasClusteredIndex)
               {
                  textIndex.Text = _Table.ClusteredIndex;
                  textIndex.ReadOnly = true;
               }

               foreach (KeyValuePair<string, string> _Column in _TableColumns)
               {
                  listColumns.ValueMember = "value";
                  listColumns.DisplayMember = "key";
                  listColumns.Items.Add(_Column);
               }

               if (listColumns.Items.Count > 0)
               {
                  listColumns.SelectedIndex = 0;
               }

               AddEmptyRangeRow();
               AddEmptyRangeRow();
               break;
         }
      }

      /// <summary>
      /// Adds an empty range row at the specified index.
      /// </summary>
      private void AddEmptyRangeRow(int rowIndex, int selectedRowIndex)
      {
         gridRanges.Rows.Insert(rowIndex, 1);
         if (rowIndex == 0)
         {
            SetCellReadOnly(gridRanges.Rows[rowIndex].Cells[columnMinimum.Name], true);
         }
         else
         {
            SetCellReadOnly(gridRanges.Rows[rowIndex].Cells[columnMinimum.Name], false);
         }

         if (rowIndex == gridRanges.Rows.Count - 1)
         {
            SetCellReadOnly(gridRanges.Rows[rowIndex].Cells[columnMaximum.Name], true);
            if (rowIndex > 0)
            {
               SetCellReadOnly(gridRanges.Rows[rowIndex - 1].Cells[columnMaximum.Name], false);
            }
         }
         gridRanges.Rows[rowIndex].Cells[columnFileGroup.Name].ReadOnly = false;
         gridRanges.Rows[rowIndex].Cells[columnFileGroup.Name].Value = _FileGroups[0];
         gridRanges.UpdateCellValue(gridRanges.Rows[rowIndex].Cells[columnFileGroup.Name].ColumnIndex, rowIndex);
         gridRanges.Rows[selectedRowIndex].Cells[0].Selected = true;
         //((DataGridViewImageCell)gridRanges.Rows[rowIndex].Cells[columnSplit.Index]).ReadOnly = true;
         //((DataGridViewImageCell)gridRanges.Rows[rowIndex].Cells[columnMerge.Index]).ReadOnly = true;
         SetCellReadOnly(gridRanges.Rows[rowIndex].Cells[columnSplit.Index], true);
         SetCellReadOnly(gridRanges.Rows[rowIndex].Cells[columnMerge.Index], true);
         gridRanges.Rows[rowIndex].Tag = new PartitionRange(RangeAction.New);
         
      }

      /// <summary>
      /// Adds an empty range row to the grid.
      /// </summary>
      private int AddEmptyRangeRow()
      {
         int _RowIndex = gridRanges.Rows.Count;
         AddEmptyRangeRow(_RowIndex, _RowIndex);         
         return _RowIndex;
      }

      /// <summary>
      /// Adds a partition range to the grid.
      /// </summary>
      private int AddRangeRow(PartitionRange range, bool isRightPartition)
      {
         int _RowIndex = gridRanges.Rows.Add(FormatMinimumRange(range.MinimumValue, isRightPartition), 
                                             FormatMaximumRange(range.MaximumValue, isRightPartition), 
                                             range.FileGroup,
                                             range.RowCount);
         gridRanges.Rows[_RowIndex].Tag = range;
         return _RowIndex;
      }

      /// <summary>
      /// Formats the minimum value of a partition range depending on whether the partition is a Right or Left partition.
      /// </summary>
      private string FormatMinimumRange(string value, bool isRightPartition)
      {
         if (string.IsNullOrEmpty(value))
         {
            return string.Empty;
         }
         else
         {
            return isRightPartition ? string.Format(">= {0}", value) : string.Format("> {0}", value);
         }
      }

      /// <summary>
      /// Formats the maximum value of a partition range depending on whether the partition is a Right or Left partition.
      /// </summary>
      private string FormatMaximumRange(string value, bool isRightPartition)
      {
         if (string.IsNullOrEmpty(value))
         {
            return string.Empty;
         }
         else
         {
            return isRightPartition ? string.Format("< {0}", value) : string.Format("<= {0}", value);
         }
      }

      /// <summary>
      /// Sets a cell as read-only and formats it.
      /// </summary>
      /// <param name="cell"></param>
      /// <param name="isReadOnly"></param>
      private void SetCellReadOnly(DataGridViewCell cell, bool isReadOnly)
      {
         cell.ReadOnly = isReadOnly;

         if (cell is DataGridViewImageCell)
         {
            ((DataGridViewImageCell)cell).Value = new Bitmap(1, 1);
         }
         else
         {
            cell.Style.BackColor = isReadOnly ? Color.LightGray : Color.White;
         }
      }

      private void linkAddNewRange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         AddEmptyRangeRow();
      }

      private void gridRanges_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
      {
         PartitionRange _Range = gridRanges.Rows[e.RowIndex].Tag as PartitionRange;
         if(_Range != null)
         {
            if (e.ColumnIndex == columnMinimum.Index)
            {
               gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Range.MinimumValue;
            }
            if (e.ColumnIndex == columnMaximum.Index)
            {
               gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Range.MaximumValue;
            }
         }
      }

      private void gridRanges_CellEndEdit(object sender, DataGridViewCellEventArgs e)
      {
         bool _IsRightPartition = (_Scheme == null) ? (listBoundaryType.SelectedItem == BoundaryRight) : _Scheme.IsRightPartition;
         PartitionRange _Range = gridRanges.Rows[e.RowIndex].Tag as PartitionRange;
         if (_Range != null)
         {
            if (gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) //if they cleared the row, revert to old value
            {
               if (e.ColumnIndex == columnMinimum.Index)
               {
                  gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Range.MinimumValue;
               }
               else if (e.ColumnIndex == columnMaximum.Index)
               {
                  gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Range.MaximumValue;
               }
            }

            if (e.ColumnIndex == columnMinimum.Index)
            {
               _Range.MinimumValue = gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
               gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = FormatMinimumRange(_Range.MinimumValue, _IsRightPartition);
               if (e.RowIndex > 0) //update the previous row's maximum value
               {
                  PartitionRange _PreviousRowRange = gridRanges.Rows[e.RowIndex-1].Tag as PartitionRange;
                  if(_PreviousRowRange != null)
                  {
                     _PreviousRowRange.MaximumValue = _Range.MinimumValue;
                     gridRanges.Rows[e.RowIndex - 1].Cells[columnMaximum.Index].Value = FormatMaximumRange(_PreviousRowRange.MaximumValue, _IsRightPartition);
                  }
               }
            }
            else if (e.ColumnIndex == columnMaximum.Index)
            {
               _Range.MaximumValue = gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
               gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = FormatMaximumRange(_Range.MaximumValue, _IsRightPartition);

               if (e.RowIndex < gridRanges.Rows.Count - 1) //update the next row's minimum value
               {
                  PartitionRange _NextRowRange = gridRanges.Rows[e.RowIndex + 1].Tag as PartitionRange;
                  if (_NextRowRange != null)
                  {
                     _NextRowRange.MinimumValue = _Range.MaximumValue;
                     gridRanges.Rows[e.RowIndex + 1].Cells[columnMinimum.Index].Value = FormatMinimumRange(_NextRowRange.MinimumValue, _IsRightPartition);
                  }
               }
            }
         }
      }

      /// <summary>
      /// Handle split request and merge.
      /// </summary>
      private void gridRanges_CellContentClick(object sender, DataGridViewCellEventArgs e)
      {
         if (e.RowIndex > -1 && !gridRanges.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
         {
            if (e.ColumnIndex == columnSplit.Index)
            {
               _Action = PartitionAction.Edit;
               //LEFT Partition = Add to the Top, RIGHT Partition = Add to the bottom
               if (_Scheme.IsRightPartition)
               {
                  AddEmptyRangeRow(e.RowIndex + 1, e.RowIndex + 1);
                  //Copy the current cell's max to the next cell
                  PartitionRange _CurrentRange = gridRanges.Rows[e.RowIndex].Tag as PartitionRange;
                  PartitionRange _NewRange = gridRanges.Rows[e.RowIndex + 1].Tag as PartitionRange;
                  _NewRange.Action = RangeAction.Split;
                  _NewRange.MaximumValue = _CurrentRange.MaximumValue;
                  _CurrentRange.MaximumValue = string.Empty;
                  gridRanges.Rows[e.RowIndex].Cells[columnMaximum.Index].Value = FormatMaximumRange(_CurrentRange.MaximumValue, true);
                  gridRanges.Rows[e.RowIndex].Cells[columnMaximum.Index].ReadOnly = false;
                  gridRanges.Rows[e.RowIndex + 1].Cells[columnMaximum.Index].Value = FormatMaximumRange(_NewRange.MaximumValue, true);
                  //((DataGridViewImageCell)gridRanges.Rows[e.RowIndex].Cells[columnSplit.Index]).ReadOnly = true;
                  SetCellReadOnly(gridRanges.Rows[e.RowIndex].Cells[columnSplit.Index], true);
                  //((DataGridViewImageCell)gridRanges.Rows[e.RowIndex].Cells[columnMerge.Index]).ReadOnly = true;
                  SetCellReadOnly(gridRanges.Rows[e.RowIndex].Cells[columnMerge.Index], true);
               }
               else
               {
                  AddEmptyRangeRow(e.RowIndex, e.RowIndex + 1);
                  //Copy the current cell's min to the previous cell
                  PartitionRange _CurrentRange = gridRanges.Rows[e.RowIndex + 1].Tag as PartitionRange;
                  PartitionRange _NewRange = gridRanges.Rows[e.RowIndex].Tag as PartitionRange;
                  _NewRange.Action = RangeAction.Split;
                  _NewRange.MinimumValue = _CurrentRange.MinimumValue;
                  _CurrentRange.MinimumValue = string.Empty;
                  gridRanges.Rows[e.RowIndex + 1].Cells[columnMinimum.Index].Value = FormatMinimumRange(_CurrentRange.MinimumValue, false);
                  gridRanges.Rows[e.RowIndex + 1].Cells[columnMinimum.Index].ReadOnly = false;
                  gridRanges.Rows[e.RowIndex].Cells[columnMinimum.Index].ReadOnly = true;
                  gridRanges.Rows[e.RowIndex].Cells[columnMaximum.Index].ReadOnly = false;
                  gridRanges.Rows[e.RowIndex].Cells[columnMinimum.Index].Value = FormatMinimumRange(_NewRange.MinimumValue, false);
                  //((DataGridViewImageCell)gridRanges.Rows[e.RowIndex + 1].Cells[columnSplit.Index]).ReadOnly = true;
                  SetCellReadOnly(gridRanges.Rows[e.RowIndex + 1].Cells[columnSplit.Index], true);
                  //((DataGridViewImageCell)gridRanges.Rows[e.RowIndex + 1].Cells[columnMerge.Index]).ReadOnly = true;
                  SetCellReadOnly(gridRanges.Rows[e.RowIndex + 1].Cells[columnMerge.Index], true);
               }
            }
            else if (e.ColumnIndex == columnMerge.Index)
            {
               _Action = PartitionAction.Edit;
               if (e.RowIndex > 0)
               {
                  PartitionRange _CurrentRange = gridRanges.Rows[e.RowIndex].Tag as PartitionRange;
                  _CurrentRange.Action = RangeAction.Merge;
                  PartitionRange _PreviousRange = gridRanges.Rows[e.RowIndex - 1].Tag as PartitionRange;
                  _PreviousRange.MaximumValue = _CurrentRange.MaximumValue;
                  gridRanges.Rows.RemoveAt(e.RowIndex);
                  gridRanges.Rows[e.RowIndex - 1].Cells[columnMaximum.Index].Value = FormatMaximumRange(_PreviousRange.MaximumValue, _Scheme.IsRightPartition);
                  //((DataGridViewImageCell)gridRanges.Rows[e.RowIndex - 1].Cells[columnSplit.Index]).ReadOnly = true;
                  SetCellReadOnly(gridRanges.Rows[e.RowIndex - 1].Cells[columnSplit.Index], true);
                  //((DataGridViewImageCell)gridRanges.Rows[e.RowIndex - 1].Cells[columnMerge.Index]).ReadOnly = true;
                  SetCellReadOnly(gridRanges.Rows[e.RowIndex - 1].Cells[columnMerge.Index], true);
                  if (!_Scheme.IsRightPartition)
                  {
                     gridRanges.Rows[e.RowIndex - 1].Cells[columnFileGroup.Index].Value = _CurrentRange.FileGroup;
                  }
               }
            }
         }
      }

      private void listBoundaryType_SelectedIndexChanged(object sender, EventArgs e)
      {
         foreach (DataGridViewRow _Row in gridRanges.Rows)
         {
            PartitionRange _Range = _Row.Tag as PartitionRange;
            if (_Range != null)
            {
               _Row.Cells[columnMinimum.Index].Value = FormatMinimumRange(_Range.MinimumValue, listBoundaryType.SelectedItem == BoundaryRight);
               _Row.Cells[columnMaximum.Index].Value = FormatMaximumRange(_Range.MaximumValue, listBoundaryType.SelectedItem == BoundaryRight);
            }
         }
      }

      private void listColumns_SelectedIndexChanged(object sender, EventArgs e)
      {
         textDataType.Text = ((KeyValuePair<string, string>)listColumns.Items[listColumns.SelectedIndex]).Value;
      }

      private void buttonOk_Click(object sender, EventArgs e)
      {
         if (_Action == PartitionAction.Create)
         {

            try
            {
               //Validate values
               if (textFunctionName.Text.Trim().Length == 0)
               {
                  Messaging.ShowError(ProductConstants.ErrorMissingFunctionName);
                  return;
               }

               if (textSchemeName.Text.Trim().Length == 0)
               {
                  Messaging.ShowError(ProductConstants.ErrorMissingSchemeName);
                  return;
               }

               if (!ValidateUtility.ValidateColumnType(textDataType.Text))
               {
                  Messaging.ShowError(ProductConstants.ErrorTypeNotSupported);
                  return;
               }

               if (ValidateGridValues() != ValidateResults.Valid)
               {
                  return;
               }

               if (Messaging.ShowConfirmation(ProductConstants.PromptCreate) == DialogResult.Yes)
               {
                  Cursor = Cursors.WaitCursor;
                  if (textIndex.Text.Trim().Length > 0 && !_Table.HasClusteredIndex)
                  {
                     _Table.ClusteredIndex = textIndex.Text.Trim();
                  }

                  PartitionScheme _Scheme = new PartitionScheme(textSchemeName.Text, gridRanges.Rows.Count);
                  _Scheme.Column = listColumns.Text;
                  _Scheme.Function = textFunctionName.Text;
                  _Scheme.IsRightPartition = (listBoundaryType.SelectedItem == BoundaryRight);
                  _Scheme.Table = _Table;
                  for (int i = 0; i < gridRanges.Rows.Count; i++)
                  {
                     _Scheme.RangeValues[i] = (PartitionRange)gridRanges.Rows[i].Tag;
                     _Scheme.RangeValues[i].FileGroup = gridRanges.Rows[i].Cells[columnFileGroup.Index].Value.ToString();
                  }
                  _Scheme.DataType = textDataType.Text;
                  PartitionHelper.CreatePartition(_ServerInfo, _Database, _Scheme);
                  this.DialogResult = DialogResult.OK;
                  Cursor = Cursors.Default;
               }
               else
               {
                  return;
               }
            }
            catch (Exception exc)
            {
               Cursor = Cursors.Default;
               Messaging.ShowException("Save Partition", exc);
               return;
            }
         }
         else if (_Action == PartitionAction.Edit)
         {
            try
            {
               if (ValidateGridValues() != ValidateResults.Valid)
               {
                  return;
               }

               if (Messaging.ShowConfirmation(ProductConstants.PromptEdit) == DialogResult.Yes)
               {
                  Cursor = Cursors.WaitCursor;
                  List<PartitionRange> _SplitRanges = new List<PartitionRange>();
                  List<PartitionRange> _MergeRanges = new List<PartitionRange>();
                  //Find the splits
                  foreach (DataGridViewRow _Row in gridRanges.Rows)
                  {
                     PartitionRange _Range = _Row.Tag as PartitionRange;
                     if (_Range != null)
                     {
                        if (_Range.Action == RangeAction.Split)
                        {
                           _Range.FileGroup = _Row.Cells[columnFileGroup.Index].Value.ToString();
                           _SplitRanges.Add(_Range);
                        }
                     }
                  }
                  //Find the merges
                  foreach (PartitionRange _Range in _Scheme.RangeValues)
                  {
                     if (_Range.Action == RangeAction.Merge)
                     {
                        _MergeRanges.Add(_Range);
                     }
                  }

                  PartitionHelper.AlterPartition(_ServerInfo, _Database, _Scheme, _SplitRanges, _MergeRanges);
                  Cursor = Cursors.Default;
               }
               else
               {
                  return;
               }
            }
            catch (Exception exc)
            {
               Cursor = Cursors.Default;
               Messaging.ShowException("Save Partition", exc);
               return;
            }
         }
         this.Close();
      }

      /// <summary>
      /// Validates that all expected values were entered into the grid.
      /// </summary>
      /// <returns></returns>
      private bool ValidateExistingBoundaryValues()
      {
         foreach (DataGridViewRow _Row in gridRanges.Rows)
         {
            if (!_Row.Cells[columnMinimum.Index].ReadOnly && (_Row.Cells[columnMinimum.Index].Value == null || _Row.Cells[columnMinimum.Index].Value.ToString().Trim().Length == 0))
            {
               return false;
            }
            if (!_Row.Cells[columnMaximum.Index].ReadOnly && (_Row.Cells[columnMaximum.Index].Value == null || _Row.Cells[columnMaximum.Index].Value.ToString().Trim().Length == 0))
            {
               return false; ;
            }
         }
         return true;
      }

      /// <summary>
      /// Validates that all boundary values match the specified column type.
      /// </summary>
      private ValidateResults ValidateGridValues()
      {
         ValidateResults _Results = ValidateResults.Valid;
         
         string _ColumnType = textDataType.Text.ToUpperInvariant();
         if (_ColumnType.Contains("("))
         {
            _ColumnType = _ColumnType.Remove(_ColumnType.IndexOf("("));
         }

         if (ValidateExistingBoundaryValues())
         {
            switch (_ColumnType)
            {
               case "BIT":
                  _Results = ValidateUtility.ValidateSqlBoolean(gridRanges);
                  break;
               case "TINYINT":
                  _Results = ValidateUtility.ValidateValue<SqlByte>(gridRanges);
                  break;
               case "DATETIME":
               case "SMALLDATETIME":
                  _Results = ValidateUtility.ValidateValue<SqlDateTime>(gridRanges);
                  break;
               case "NUMERIC":
               case "DECIMAL":
                  _Results = ValidateUtility.ValidateValue<SqlDecimal>(gridRanges);
                  break;
               case "FLOAT":
                  _Results = ValidateUtility.ValidateValue<SqlDouble>(gridRanges);
                  break;
               case "UNIQUEIDENTIFIER":
                  _Results = ValidateUtility.ValidateValue<SqlGuid>(gridRanges);
                  break;
               case "SMALLINT":
                  _Results = ValidateUtility.ValidateValue<SqlInt16>(gridRanges);
                  break;
               case "INT":
                  _Results = ValidateUtility.ValidateValue<SqlInt32>(gridRanges);
                  break;
               case "BIGINT":
                  _Results = ValidateUtility.ValidateValue<SqlInt64>(gridRanges);
                  break;
               case "MONEY":
               case "SMALLMONEY":
                  _Results = ValidateUtility.ValidateValue<SqlMoney>(gridRanges);
                  break;
               case "REAL":
                  _Results = ValidateUtility.ValidateValue<SqlSingle>(gridRanges);
                  break;
               case "CHAR":
               case "NCHAR":
               case "NVARCHAR":
               case "VARCHAR":
                  _Results = ValidateUtility.ValidateSqlString(gridRanges);
                  break;
            }
         }
         else
         {
            _Results = ValidateResults.MissingBoundaryValues;
         }

         switch (_Results)
         {
            case ValidateResults.InvalidCast:
               Messaging.ShowError(string.Format(ProductConstants.ErrorBoundaryInvalidCast, _ColumnType));
               break;
            case ValidateResults.InvalidOrder:
               Messaging.ShowError(ProductConstants.ErrorBoundaryInvalidOrder);
               break;
            case ValidateResults.TooManyValues:
               Messaging.ShowError(ProductConstants.ErrorBoundaryTooManyValues);
               break;
            case ValidateResults.MissingBoundaryValues:
               Messaging.ShowError(ProductConstants.ErrorMissingBoundaryValues);
               break;
         }

         return _Results;
      }

      private void buttonCancel_Click(object sender, EventArgs e)
      {
         switch (_Action)
         {
            case PartitionAction.Edit:
               if (Messaging.ShowConfirmation(ProductConstants.PromptCancelEdit) == DialogResult.Yes)
               {
                  this.Close();
               }
               break;
            case PartitionAction.Create:
               if (Messaging.ShowConfirmation(ProductConstants.PromptCancelCreate) == DialogResult.Yes)
               {
                  this.Close();
               }
               break;
            case PartitionAction.View:
               this.Close();
               break;
         }
      }

   }

   internal enum PartitionAction
   {
      View,
      Create,
      Edit
   }
}