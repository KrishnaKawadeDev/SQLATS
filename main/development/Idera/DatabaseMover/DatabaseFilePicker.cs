using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using Idera.SqlAdminToolset.DatabaseMoverLibrary;
using Microsoft.SqlServer.Management.Smo;
using System.IO;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.DatabaseMover
{
   /// <summary>
   /// Contains a DataGridView with a custom column that uses the TextBoxX control.
   /// </summary>
   public partial class DatabaseFilePicker : UserControl
   {
      /// <summary>
      /// Initializes a new instance of DatabaseFilePicker.
      /// </summary>
      public DatabaseFilePicker()
      {
         InitializeComponent();
      }

      public void AddItem(DatabaseMoverFile file)
      {
         int _RowIndex = dataGridFileOptions.Rows.Add(new object[] { file.DestinationLogicalName, file.Type, file.DestinationDirectory, file.DestinationFileName });
         dataGridFileOptions.Rows[_RowIndex].Tag = file;
         ((CustomTextControlCell)dataGridFileOptions.Rows[_RowIndex].Cells[columnFilePath.Name]).BrowseButtonClick += new EventHandler<EventArgs>(DatabaseFilePicker_BrowseButtonClick);
      }


      /// <summary>
      /// Clears the contains DataGridView.
      /// </summary>
      public void Clear()
      {
         dataGridFileOptions.Rows.Clear();
      }

      /// <summary>
      /// Clears all the log file entries from the list.
      /// </summary>
      public void ClearLogFiles()
      {
         for (int i = dataGridFileOptions.Rows.Count - 1; i >= 0; i--)
         {
            DatabaseMoverFile _File = dataGridFileOptions.Rows[i].Tag as DatabaseMoverFile;
            if (_File != null && _File.Type == DatabaseMoverFile.DatabaseFileType.Log)
            {
               dataGridFileOptions.Rows.RemoveAt(i);
            }
         }
      }

      /// <summary>
      /// Updates all rows with the specified file path.
      /// </summary>
      public void UpdateAllPaths(string newValue)
      {
         foreach (DataGridViewRow _Row in dataGridFileOptions.Rows)
         {
            _Row.Cells[columnFilePath.Name].Value = newValue;
         }
      }

      /// <summary>
      /// List of database files based on the values found in the contained DataGridView.
      /// </summary>
      public List<DatabaseMoverFile> Files
      {
         get
         {
            List<DatabaseMoverFile> _Files = new List<DatabaseMoverFile>();
            foreach (DataGridViewRow _Row in dataGridFileOptions.Rows)
            {
               DatabaseMoverFile _File = _Row.Tag as DatabaseMoverFile;
               if (_File != null)
               {
                  _File.DestinationDirectory = _Row.Cells[columnFilePath.Name].Value.ToString();
                  _File.DestinationFileName = _Row.Cells[columnFileName.Name].Value.ToString();
                  _File.DestinationLogicalName = _Row.Cells[columnLogicalName.Name].Value.ToString();
                  _Files.Add(_File);
               }
            }
            return _Files;
         }
      }

      public bool ValidateGrid()
      {
          foreach (DataGridViewRow _Row in dataGridFileOptions.Rows)
          {
              foreach (DataGridViewCell _Cell in _Row.Cells)
              {
                  if (_Cell.FormattedValue == null || _Cell.FormattedValue.ToString().Trim().Length == 0)
                  {
                      dataGridFileOptions.CurrentCell = _Cell;
                      Messaging.ShowError(ProductConstants.ErrorGridValidationValueIsEmpty);
                      return false;
                  }
                  //Verify the file name
                  if (_Cell.ColumnIndex == dataGridFileOptions.Columns[columnFileName.Name].Index)
                  {
                      if (!Path.HasExtension(_Cell.FormattedValue.ToString()))
                      {
                          dataGridFileOptions.CurrentCell = _Cell;
                          Messaging.ShowError(ProductConstants.ErrorGridValidationMissingExtenstion);
                          return false;
                      }
                  }
                  //Verify file path
                  if (_Cell.ColumnIndex == dataGridFileOptions.Columns[columnFilePath.Name].Index)
                  {
                      if (!Path.IsPathRooted(_Cell.FormattedValue.ToString()) || _Cell.FormattedValue.ToString().StartsWith(@"\\"))
                      {
                          dataGridFileOptions.CurrentCell = _Cell;
                          Messaging.ShowError(ProductConstants.ErrorGridValidationInvalidPath);
                          return false;
                      }
                  }
              }
          }
          return true;
      }

      #region Datagrid events
      private void dataGridFileOptions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
      {
         if (e.ColumnIndex == dataGridFileOptions.Columns[columnLogicalName.Name].Index)
         {
            //if (dataGridFileOptions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dataGridFileOptions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length > 0)
            {
               DataGridViewCell _FileNameCell = dataGridFileOptions.Rows[e.RowIndex].Cells[dataGridFileOptions.Columns[columnFileName.Name].Index];
               _FileNameCell.Value = _FileNameCell.Value.ToString().Replace(Path.GetFileNameWithoutExtension(_FileNameCell.Value.ToString()), dataGridFileOptions.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }
         }
      }

      private void dataGridFileOptions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
      {
          if (e.ColumnIndex != dataGridFileOptions.Columns[columnFilePath.Name].Index)
          {
              if (e.FormattedValue == null || e.FormattedValue.ToString().Trim().Length == 0)
              {
                  Messaging.ShowError(ProductConstants.ErrorGridValidationValueIsEmpty);
                  e.Cancel = true;
                  return;
              }
              //Verify the file name
              if (e.ColumnIndex == dataGridFileOptions.Columns[columnFileName.Name].Index)
              {
                  if (!Path.HasExtension(e.FormattedValue.ToString()))
                  {
                      Messaging.ShowError(ProductConstants.ErrorGridValidationMissingExtenstion);
                      e.Cancel = true;
                      return;
                  }
              }
          }
      }
      #endregion

      #region Browse button event handler

      void DatabaseFilePicker_BrowseButtonClick(object sender, EventArgs e)
      {
         if (this.BrowseButtonClickEventHandler != null)
         {
            this.BrowseButtonClickEventHandler(sender, e);
         }
      }

      private EventHandler<EventArgs> _BrowseButtonClick;

      public EventHandler<EventArgs> BrowseButtonClickEventHandler
      {
         get { return _BrowseButtonClick; }
         set { _BrowseButtonClick = value; }
      }

      /// <summary>
      /// Raised when a task completes on a server.
      /// </summary>
      public event EventHandler<EventArgs> BrowseButtonClick
      {
         add { _BrowseButtonClick += value; }
         remove { _BrowseButtonClick -= value; }
      }
      #endregion

      #region Custom Text Column

      /// <summary>
      /// Creates a custom text column by implementing the TextBoxX control with a custom button at the end to pick a folder.
      /// </summary>
      internal class CustomTextColumn : DataGridViewColumn
      {
         public CustomTextColumn()
         {
            this.CellTemplate = new CustomTextControlCell();
         }

         private void InitializeComponent()
         {
         }
      }

      internal class CustomTextControlCell : DataGridViewTextBoxCell
      {
         //private object _Tag = null;

         public CustomTextControlCell()
            : base()
         {

         }

         public override void InitializeEditingControl(int rowIndex, object
                 initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
         {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CustomTextEditingControl _CustomControl = DataGridView.EditingControl as CustomTextEditingControl;
            if (_CustomControl != null)
            {
               _CustomControl.Text = this.Value == null ? string.Empty : this.Value.ToString();
               _CustomControl.Tag = DataGridView.Rows[this.RowIndex].Tag;
               _CustomControl.BrowseButtonClick += new EventHandler<EventArgs>(ctl_BrowseButtonClick);
            }
         }

         public override void DetachEditingControl()
         {
            CustomTextEditingControl _CustomControl = DataGridView.EditingControl as CustomTextEditingControl;
            if (_CustomControl != null)
            {
               _CustomControl.BrowseButtonClick -= new EventHandler<EventArgs>(ctl_BrowseButtonClick);
            }
            base.DetachEditingControl();
         }

         public override Type EditType
         {
            get
            {
               // Return the type of the editing contol that CustomControlCell uses.
               return typeof(CustomTextEditingControl);
            }
         }

         public override Type ValueType
         {
            get
            {
               // Return the type of the value that CustomControlCell contains.
               return typeof(String);
            }
         }

         public override object DefaultNewRowValue
         {
            get
            {
               return string.Empty;
            }
         }

         ///// <summary>
         ///// Sets the object that contains data about the control.
         ///// </summary>
         //public new object Tag
         //{
         //   set
         //   {
         //      _Tag = value;
         //   }
         //}

         #region Browse control handler
         void ctl_BrowseButtonClick(object sender, EventArgs e)
         {
            if (this.BrowseButtonClickEventHandler != null)
            {
               this.BrowseButtonClickEventHandler(sender, e);
            }
         }

         private EventHandler<EventArgs> _BrowseButtonClick;

         public EventHandler<EventArgs> BrowseButtonClickEventHandler
         {
            get { return _BrowseButtonClick; }
            set { _BrowseButtonClick = value; }
         }

         /// <summary>
         /// Raised when a task completes on a server.
         /// </summary>
         public event EventHandler<EventArgs> BrowseButtonClick
         {
            add { _BrowseButtonClick += value; }
            remove { _BrowseButtonClick -= value; }
         }
         #endregion

      }

      internal class CustomTextEditingControl : TextBoxX, IDataGridViewEditingControl
      {
         DataGridView dataGridView;
         private bool valueChanged = false;
         int rowIndex;

         public CustomTextEditingControl()
         {
            this.Border.Border = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.Border.Class = "TextBoxBorder";
            this.ButtonCustom.Visible = true;
            this.Dock = DockStyle.Fill;
            this.Margin = new Padding(0);
            this.ButtonCustomClick += new EventHandler(CustomTextEditingControl_ButtonCustomClick);
         }

         // Implements the IDataGridViewEditingControl.EditingControlFormattedValue 
         // property.
         public object EditingControlFormattedValue
         {
            get
            {
               return this.Text;
            }
            set
            {
               this.Text = value.ToString();
            }
         }

         // Implements the IDataGridViewEditingControl.GetEditingControlFormattedValue method.
         public object GetEditingControlFormattedValue(
             DataGridViewDataErrorContexts context)
         {
            return EditingControlFormattedValue;
         }

         // Implements the IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
         public void ApplyCellStyleToEditingControl(
             DataGridViewCellStyle dataGridViewCellStyle)
         {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
         }

         // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
         // property.
         public int EditingControlRowIndex
         {
            get
            {
               return rowIndex;
            }
            set
            {
               rowIndex = value;
            }
         }

         /// <summary>
         /// Implements the IDataGridViewEditingControl.EditingControlWantsInputKey method.
         /// </summary>
         /// <remarks>
         /// Adapted from DataGridViewTextBoxEditingControl.EditingControlWantsInputKey
         /// </remarks>
         public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
         {
            switch ((key & Keys.KeyCode))
            {
               case Keys.Prior:
               case Keys.Next:
                  if (!this.valueChanged)
                  {
                     break;
                  }
                  return true;

               case Keys.End:
               case Keys.Home:
                  if (this.SelectionLength == this.Text.Length)
                  {
                     break;
                  }
                  return true;

               case Keys.Left:
                  if (((this.RightToLeft != RightToLeft.No) || ((this.SelectionLength == 0) && (base.SelectionStart == 0))) && ((this.RightToLeft != RightToLeft.Yes) || ((this.SelectionLength == 0) && (base.SelectionStart == this.Text.Length))))
                  {
                     break;
                  }
                  return true;

               case Keys.Up:
                  if ((this.Text.IndexOf("\r\n") < 0) || ((base.SelectionStart + this.SelectionLength) < this.Text.IndexOf("\r\n")))
                  {
                     break;
                  }
                  return true;

               case Keys.Right:
                  if (((this.RightToLeft != RightToLeft.No) || ((this.SelectionLength == 0) && (base.SelectionStart == this.Text.Length))) && ((this.RightToLeft != RightToLeft.Yes) || ((this.SelectionLength == 0) && (base.SelectionStart == 0))))
                  {
                     break;
                  }
                  return true;

               case Keys.Down:
                  {
                     int startIndex = base.SelectionStart + this.SelectionLength;
                     if (this.Text.IndexOf("\r\n", startIndex) == -1)
                     {
                        break;
                     }
                     return true;
                  }
               case Keys.Delete:
                  if ((this.SelectionLength <= 0) && (base.SelectionStart >= this.Text.Length))
                  {
                     break;
                  }
                  return true;

               case Keys.Return:
                  if ((((key & (Keys.Alt | Keys.Control | Keys.Shift)) == Keys.Shift) && this.Multiline) && base.AcceptsReturn)
                  {
                     return true;
                  }
                  break;
            }
            return !dataGridViewWantsInputKey;
         }


         // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
         // method.
         public void PrepareEditingControlForEdit(bool selectAll)
         {
            // No preparation needs to be done.
         }

         // Implements the IDataGridViewEditingControl.RepositionEditingControlOnValueChange property.
         public bool RepositionEditingControlOnValueChange
         {
            get
            {
               return false;
            }
         }

         // Implements the IDataGridViewEditingControl.EditingControlDataGridView property.
         public DataGridView EditingControlDataGridView
         {
            get
            {
               return dataGridView;
            }
            set
            {
               dataGridView = value;
            }
         }

         // Implements the IDataGridViewEditingControl.EditingControlValueChanged property.
         public bool EditingControlValueChanged
         {
            get
            {
               return valueChanged;
            }
            set
            {
               valueChanged = value;
            }
         }

         // Implements the IDataGridViewEditingControl.EditingPanelCursor property.
         public Cursor EditingPanelCursor
         {
            get
            {
               return base.Cursor;
            }
         }

         protected override void OnTextChanged(EventArgs eventargs)
         {
            // notify the datagridview that the contents of the cell
            // have changed.
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnTextChanged(eventargs);
         }

         #region Custom Button Event
         void CustomTextEditingControl_ButtonCustomClick(object sender, EventArgs e)
         {
            if (this.BrowseButtonClickEventHandler != null)
            {
               this.BrowseButtonClickEventHandler(sender, e);
            }
         }

         private EventHandler<EventArgs> _BrowseButtonClick;

         public EventHandler<EventArgs> BrowseButtonClickEventHandler
         {
            get { return _BrowseButtonClick; }
            set { _BrowseButtonClick = value; }
         }

         /// <summary>
         /// Raised when a task completes on a server.
         /// </summary>
         public event EventHandler<EventArgs> BrowseButtonClick
         {
            add { _BrowseButtonClick += value; }
            remove { _BrowseButtonClick -= value; }
         }

         #endregion
      }

      #endregion
   }


}
