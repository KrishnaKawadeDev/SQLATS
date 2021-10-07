using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Reflection;

namespace Idera.SqlAdminToolset.PartitionGenerator
{
    /// <summary>
    /// Helper class to handle conversions and comparisons with SQL types.
    /// </summary>
    internal static class ValidateUtility
    {
        static List<string> _AllowedTypes = new List<string>();
        static List<string> _NotAllowedTypes = new List<string>();

        /// <summary>
        /// Initialize static values
        /// </summary>
        static ValidateUtility()
        {
            //Initialize lists
            _AllowedTypes.Add("BINARY");
            _AllowedTypes.Add("BIGINT");
            _AllowedTypes.Add("BIT");
            _AllowedTypes.Add("CHAR");
            _AllowedTypes.Add("DATETIME");
            _AllowedTypes.Add("DATETIME2");
            _AllowedTypes.Add("DECIMAL");
            _AllowedTypes.Add("FLOAT");
            _AllowedTypes.Add("INT");
            _AllowedTypes.Add("MONEY");
            _AllowedTypes.Add("NCHAR");
            _AllowedTypes.Add("NVARCHAR");
            _AllowedTypes.Add("NUMERIC");
            _AllowedTypes.Add("REAL");
            _AllowedTypes.Add("SMALLDATETIME");
            _AllowedTypes.Add("SMALLINT");
            _AllowedTypes.Add("SMALLMONEY");
            _AllowedTypes.Add("VARIANT");
            _AllowedTypes.Add("VARCHAR");
            _AllowedTypes.Add("TINYINT");
            _AllowedTypes.Add("VARBINARY");
            _AllowedTypes.Add("VARCHAR");
            _AllowedTypes.Add("UNIQUEIDENTIFIER");

            _NotAllowedTypes.Add("IMAGE");
            _NotAllowedTypes.Add("NTEXT");
            _NotAllowedTypes.Add("TEXT");
            _NotAllowedTypes.Add("TIMESTAMP");
            _NotAllowedTypes.Add("XML");
            _NotAllowedTypes.Add("BINARY");
            _NotAllowedTypes.Add("VARBINARY");
            _NotAllowedTypes.Add("VARCHAR(MAX)");
            _NotAllowedTypes.Add("NVARCHAR(MAX)");
            _NotAllowedTypes.Add("VARBINARY(MAX)");
        }

        /// <summary>
        /// Validates that the partition's data type is supported.
        /// </summary>
        /// <remarks>
        /// MSDN: All data types are valid for use as partitioning columns, except text, ntext, image, xml, 
        /// timestamp, varchar(max), nvarchar(max), varbinary(max), alias data types, or CLR user-defined data types.
        /// BINARY AND VARBINARY were added to the list since they can't be represented in the UI easily.
        /// </remarks>
        internal static bool ValidateColumnType(string type)
        {
            type = type.Trim().ToUpperInvariant();

            if (_NotAllowedTypes.Contains(type))
            {
                return false;
            }

            //Remove size and check against allowed types to make sure that there's no custom types
            if (type.Contains("("))
            {
                type = type.Remove(type.IndexOf("("));
            }

            if (!_AllowedTypes.Contains(type))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates that grid values are SqlBoolean.
        /// </summary>
        /// <returns></returns>
        public static ValidateResults ValidateSqlBoolean(DataGridView gridView)
        {
            List<SqlBoolean> _BooleanBoundaries = new List<SqlBoolean>();
            if (gridView.Rows.Count > 2)
            {
                return ValidateResults.TooManyValues;
            }

            try
            {
                SqlBoolean.Parse(((PartitionRange)gridView.Rows[0].Tag).MaximumValue);
            }
            catch
            {
                return ValidateResults.InvalidCast;
            }
            return ValidateResults.Valid;
        }

        /// <summary>
        /// Validates that grid values are SqlString
        /// </summary>
        public static ValidateResults ValidateSqlString(DataGridView gridView)
        {
            List<SqlString> _Boundaries = new List<SqlString>();

            for (int i = 0; i < gridView.Rows.Count - 1; i++) //don't look at the last row (infinity value)
            {
                PartitionRange _Range = (PartitionRange)gridView.Rows[i].Tag;
                _Boundaries.Add(_Range.MaximumValue);
            }

            return ValidateOrder(_Boundaries);
        }

        /// <summary>
        /// Validates that grid values are of the generic Type.
        /// </summary>
        /// <remarks>
        /// Uses reflection to call the static Parse method of the specified SqlType.
        /// </remarks>
        public static ValidateResults ValidateValue<T>(DataGridView gridView) where T : IComparable
        {
            MethodInfo _ParseMethod = typeof(T).GetMethod("Parse", BindingFlags.Static | BindingFlags.Public);

            List<T> _Boundaries = new List<T>();

            for (int i = 0; i < gridView.Rows.Count - 1; i++) //don't look at the last row (infinity value)
            {
                PartitionRange _Range = (PartitionRange)gridView.Rows[i].Tag;
                try
                {
                    _Boundaries.Add((T)_ParseMethod.Invoke(null, new object[] { _Range.MaximumValue }));
                }
                catch
                {
                    return ValidateResults.InvalidCast;
                }
            }

            return ValidateOrder(_Boundaries);
        }

        /// <summary>
        /// Validates that the grid values are in ascending order.
        /// </summary>
        private static ValidateResults ValidateOrder<T>(List<T> boundaries) where T : IComparable
        {
            if (boundaries.Count > 1) //No need to compare if there's only one boundary
            {
                for (int _BoundaryIndex = 1; _BoundaryIndex < boundaries.Count; _BoundaryIndex++)
                {
                    if (boundaries[_BoundaryIndex].CompareTo(boundaries[_BoundaryIndex - 1]) < 0)
                    {
                        return ValidateResults.InvalidOrder;
                    }
                }
            }

            return ValidateResults.Valid;
        }
    }

    /// <summary>
    /// Validation Results.
    /// </summary>
    internal enum ValidateResults
    {
        Valid,
        MissingBoundaryValues,
        TooManyValues,
        InvalidCast,
        InvalidOrder
    }
}
