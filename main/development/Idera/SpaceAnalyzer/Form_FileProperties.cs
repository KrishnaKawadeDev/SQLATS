using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.SpaceAnalyzer
{
    public partial class Form_FileProperties : Office2007Form
    {
        private FileRecord _file;

        public Form_FileProperties(FileRecord f)
        {
            _file = f;
            InitializeComponent();
        }

        private void Form_FileProperties_Load(object sender, EventArgs e)
        {
            this.TitleText = string.Format("File Properties - {0}", _file.LogicalName);

            //General
            _textBoxX_LogicalFileName.Text = _file.LogicalName;
            _textBoxX_FullPath.Text = _file.FullPathName;
            _textBoxX_ComputerName.Text = _file.ComputerName;
            _textBoxX_DriveLetter.Text = _file.DriveLetter;
            _textBoxX_SQLServer.Text = _file.ServerName;
            _textBoxX_Database.Text = _file.DatabaseName;
            _textBoxX_Type.Text = _file.Type.ToString();
            _textBoxX_FileGroup.Text = _file.FileGroup;

            // File Space 
            _textBoxX_FileSize.Text = Helpers.StrFormatByteSize(_file.Size);
            _textBoxX_PercentUsed.Text = string.Format("{0:P}", _file.PercentUsed);
            _textBoxX_UsedSize.Text = Helpers.StrFormatByteSize(_file.UsedSize);
            _textBoxX_FreeSize.Text = Helpers.StrFormatByteSize(_file.Size - _file.UsedSize);
            _textBoxX_Growth.Text = string.Format("{0} ({1})", _file.AutoGrowth, _file.MaxSize);
            _textBoxX_PercentFree.Text = string.Format("{0:P}", 1.0 - _file.PercentUsed);

            // Disk Usage
            if (_file.DiskSize == 0)
            {
                _textBoxX_DiskFree.Text = "unavailable";
                _textBoxX_DiskPercentFree.Text = "unavailable";
                _textBoxX_DiskPercentUsed.Text = "unavailable";
                _textBoxX_DiskSize.Text = "unavailable";
                _textBoxX_DiskUsed.Text = "unavailable";
            }
            else
            {
                _textBoxX_DiskFree.Text = Helpers.StrFormatByteSize(_file.DiskFreeSpace);
                _textBoxX_DiskPercentFree.Text = string.Format("{0:P}", _file.DiskPercentFree);
                _textBoxX_DiskPercentUsed.Text = string.Format("{0:P}", _file.DiskPercentUsed);
                _textBoxX_DiskSize.Text = Helpers.StrFormatByteSize(_file.DiskSize);
                _textBoxX_DiskUsed.Text = Helpers.StrFormatByteSize(_file.DiskUsedSize);
            }           

        }

   }
}