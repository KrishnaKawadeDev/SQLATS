using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.PartitionGenerator
{
   /// <summary>
   /// Partition Scheme.
   /// </summary>
   internal class PartitionScheme
   {
      private string _Name;
      private TableInfo _Table;
      private string _Column;
      private string _DataType;
      private string _Function;
      private bool _IsRightPartition;
      PartitionRange[] _RangeValues;

      /// <summary>
      /// Initializes a new instance of PartitionScheme.
      /// </summary>
      /// <param name="name"></param>
      public PartitionScheme(string name, int partitionCount)
      {
         _Name = name;
         _RangeValues = new PartitionRange[partitionCount];
      }

      /// <summary>
      /// Scheme name.
      /// </summary>
      public string Name
      {
         get { return _Name; }
         set { _Name = value; }
      }

      /// <summary>
      /// Partitioned table.
      /// </summary>
      public TableInfo Table
      {
         get { return _Table; }
         set { _Table = value; }
      }

      /// <summary>
      /// Partitioned Column.
      /// </summary>
      public string Column
      {
         get { return _Column; }
         set { _Column = value; }
      }

      /// <summary>
      /// Data type.
      /// </summary>
      public string DataType
      {
         get { return _DataType; }
         set { _DataType = value; }
      }

      /// <summary>
      /// Partition function used by the scheme.
      /// </summary>
      public string Function
      {
         get { return _Function; }
         set { _Function = value; }
      }

      /// <summary>
      /// True if the partition values are to the right of the boundaries, else false.
      /// </summary>
      public bool IsRightPartition
      {
         get { return _IsRightPartition; }
         set { _IsRightPartition = value; }
      }

      /// <summary>
      /// Range of partitioned values.
      /// </summary>
      internal PartitionRange[] RangeValues
      {
         get { return _RangeValues; }
      }
   }

   /// <summary>
   /// Range values and their assigned filegroup.
   /// </summary>
   internal class PartitionRange
   {
      private string _MinimumValue = string.Empty;
      private string _MaximumValue = string.Empty;
      private string _FileGroup = string.Empty;
      private int _RowCount = 0;
      private RangeAction _Action = RangeAction.None;

      public PartitionRange() { }

      public PartitionRange(RangeAction action)
      {
         _Action = action;
      }

      /// <summary>
      /// Minimum value.
      /// </summary>
      public string MinimumValue
      {
         get { return _MinimumValue; }
         set { _MinimumValue = value; }
      }

      /// <summary>
      /// Maximum value.
      /// </summary>
      public string MaximumValue
      {
         get { return _MaximumValue; }
         set { _MaximumValue = value; }
      }

      /// <summary>
      /// Filegroup name.
      /// </summary>
      public string FileGroup
      {
         get { return _FileGroup; }
         set { _FileGroup = value; }
      }

      /// <summary>
      /// Action that should be taken with the range.
      /// </summary>
      public RangeAction Action
      {
         get { return _Action; }
         set { _Action = value; }
      }

      /// <summary>
      /// Number of rows within the specified range
      /// </summary>
      public int RowCount
      {
         get { return _RowCount; }
         set { _RowCount = value; }
      }
   }

   /// <summary>
   /// Action that should be taken with the range values upon update.
   /// </summary>
   internal enum RangeAction
   {
      None,
      Split,
      Merge,
      New
   }
}
