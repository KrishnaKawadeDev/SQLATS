using System.Data;
using System.Windows.Forms;

namespace Idera.SqlAdminToolset.Core.Export
{
    /// <summary>
    /// Common DataSet export functionality.
    /// </summary>
    public static class ExportToDataSet
    {
        public static DataSet CopyListView(ListView listView, string tableName)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = dataSet.Tables.Add(tableName);

            // add the columns to the dataset table
            for (int i = 0; i < listView.Columns.Count; i++ )
            {
                dataTable.Columns.Add(listView.Columns[i].Text.Replace(" ", ""));
            }

            // add the rows to the dataset table
            for (int itemCount = 0; itemCount < listView.Items.Count; itemCount++)
            {
                // array for the items in this row
                string[] subItems = new string[listView.Items[itemCount].SubItems.Count];
                
                // loop through the items and add them to the row
                for (int j = 0; j < listView.Items[itemCount].SubItems.Count; j++)
                {
                    subItems[j] = listView.Items[itemCount].SubItems[j].Text;
                }
                
                DataRow dataRow = dataTable.NewRow();

                dataRow.ItemArray = subItems;
                dataTable.Rows.Add(dataRow);
            }

            return dataSet;
        }
    }
}