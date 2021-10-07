using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    public partial class Form_IndexProperties : Office2007Form
    {
        private Index _index;
        public Form_IndexProperties(Index i)
        {
            _index = i;
            InitializeComponent();
        }
        private Selectivity _selectivity = new Selectivity();
        private void Form_IndexProperties_Load(object sender, EventArgs e)
        {
            this.TitleText = string.Format("Index Properties - {0}", _index.Name);

            _textBoxX_Index.Text = _index.Name;
            _textBoxX_Database.Text = _index.DatabaseName;
            _textBoxX_Table.Text = string.Format("{0}.{1}", _index.SchemaName, _index.TableName);
            _textBoxX_Columns.Text = _index.Columns;

            _textBoxX_FillFactor.Text = _index.FillFactor.ToString();
            _textBoxX_Disabled.Text = _index.IsDisabled ? "Yes" : "No";
            _textBoxX_Clustered.Text = _index.IsClustered ? "Yes" : "No";

            _textBoxX_Rows.Text = _index.Rows.ToString();
            _textBoxX_PageCount.Text = _index.CountPages.ToString();
            _textBoxX_Size.Text = Helpers.StrFormatByteSize(_index.CountPages*ProductConstants.IndexPageSize);

            if (_index.AverageFragLevel < 0.0 || _index.AverageFragLevel > 1.0)
            {
                _textBoxX_FragPercent.Text = "N/A";
            }
            else
            {
                _textBoxX_FragPercent.Text = string.Format("{0:P}", _index.AverageFragLevel);
            }

            if (_index.ServerVersion == ServerVersionType.SQL2000)
            {
                _textBoxX_Scans.Text = "N/A";
                _textBoxX_Seeks.Text = "N/A";
                _textBoxX_Lookups.Text = "N/A";
                _textBoxX_Updates.Text = "N/A";
                _textBoxX_TotalAccesses.Text = "N/A";
            }
            else
            {
                _textBoxX_Scans.Text = _index.Scans.ToString();
                _textBoxX_Seeks.Text = _index.Seeks.ToString();
                _textBoxX_Lookups.Text = _index.Lookups.ToString();
                _textBoxX_Updates.Text = _index.Updates.ToString();
                _textBoxX_TotalAccesses.Text = _index.TotalAccess.ToString();
            }
            if (_index.AverageDensity < 0.0 || _index.AverageDensity > 1.0 || (_index.Rows == 0 && _index.AverageDensity > 0.0))
            {
                _textBoxX_Selectivity.Text = "N/A";
            }
            else
            {
                _textBoxX_Selectivity.Text = string.Format("{0:P}", _selectivity.calculate_selectivity(_index.AverageDensity,_index.Rows));
            }
            if (_index.LastStatisticsUpdate == DateTime.MinValue)
            {
                _textBoxX_LastUpdated.Text = "No Statistics Available";
            }
            else
            {
                _textBoxX_LastUpdated.Text = _index.LastStatisticsUpdate.ToString();
            }
            _textBoxX_RowsModified.Text = _index.ModifiedRows.ToString();

        }        
    }
}