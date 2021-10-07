using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.PartitionGenerator
{
   /// <summary>
   /// Table information.
   /// </summary>
   internal class TableInfo
   {
      #region variables
      private string _Name;
      private string _Schema;
      private bool _HasClusteredIndex;
      private string _ClusteredIndex;
      private Int64 _RowCount;
      private bool _IsPartitioned;
      private string _PartitionScheme;
      #endregion

      #region Accessors
      /// <summary>
      /// Initializes a new instance of TableInfo.
      /// </summary>
      public TableInfo(string name)
      {
         _Name = name;
      }

      /// <summary>
      /// Table Name.
      /// </summary>
      public string Name
      {
         get { return _Name; }
      }

      /// <summary>
      /// Table schema.
      /// </summary>
      public string Schema
      {
         get { return _Schema; }
         set { _Schema = value; }
      }

      /// <summary>
      /// True if the table has a clustered index, otherwise false.
      /// </summary>
      public bool HasClusteredIndex
      {
         get { return _HasClusteredIndex; }
         set { _HasClusteredIndex = value; }
      }

      /// <summary>
      /// Name of the table's clustered index, empty string if no index is found.
      /// </summary>
      public string ClusteredIndex
      {
         get 
         {
            if (_ClusteredIndex == null)
            {
               return string.Empty;
            }
            return _ClusteredIndex; 
         }
         set { _ClusteredIndex = value; }
      }

      /// <summary>
      /// Table Row count.
      /// </summary>
      public Int64 RowCount
      {
         get { return _RowCount; }
         set { _RowCount = value; }
      }

      /// <summary>
      /// True if the table is partitioned, otherwise false.
      /// </summary>
      public bool IsPartitioned
      {
         get { return _IsPartitioned; }
         set { _IsPartitioned = value; }
      }

      /// <summary>
      /// Partition scheme used by the table, empty string if no scheme is used.
      /// </summary>
      public string PartitionScheme
      {
         get
         {
            if (_PartitionScheme == null)
            {
               return string.Empty;
            }
            return _PartitionScheme;
         }
         set { _PartitionScheme = value; }
      }
      #endregion

      #region Methods

      public override string ToString()
      {
         return string.Format("{0} ({1})", Name, IsPartitioned ? string.Format("Partitioned - {0}", _PartitionScheme) : "Not Partitioned");
      }
      #endregion
   }
}
