using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.ServerStatistics
{
    /// <summary>
    /// Statistics Details
    /// </summary>
    class StatisticalData
    {
        string _Name;
        StatisticsHeader[] _DetailNames;
        NodeIcon _IconImage = NodeIcon.None;
        NodeIcon _DetailIconImage = NodeIcon.None;
        DataTable _Data;
        PopulateData _PopulateDataMethod;
        PopulateData _PreviewDataMethod;
        PopulateData _BulkLoadMethod;
        bool _IsDataLoaded = false;
        List<StatisticalData> _ChildData = new List<StatisticalData>();
        StatisticalData _ParentData = null;
        Exception _DataException = null;
        DataType _Type = DataType.RawData;
        int _EstimatedCount = 0;
        bool _ShowCount = false;
        ServerInformation _Credentials = null;

        /// <summary>
        /// Initializes a new instance of StatisticalData.
        /// </summary>
        public StatisticalData(string name, StatisticsHeader[] detailNames)
        {
            _Name = name;
            DetailNames = detailNames;
        }

        public StatisticalData(string name, PopulateData populateData, PopulateData previewData, DataType type, NodeIcon icon)
        {
            _Name = name;
            _PopulateDataMethod = populateData;
            _PreviewDataMethod = previewData;
            _Type = type;
            _DetailIconImage = _IconImage = icon;
        }

        public StatisticalData(string name, PopulateData populateData, PopulateData previewData, DataType type, NodeIcon icon, ServerInformation serverInfo) : 
            this(name, populateData, previewData, type, icon)
        {
            _Credentials = serverInfo;
        }

        public StatisticalData(string name, PopulateData populateData, PopulateData previewData, PopulateData bulkLoadData, DataType type, NodeIcon icon) :
            this(name, populateData, previewData, type, icon)
        {
            _BulkLoadMethod = bulkLoadData;
        }

        public string Name
        {
            get { return _Name; }
        }

        /// <summary>
        /// Column Headers
        /// </summary>
        public StatisticsHeader[] DetailNames
        {
            get { return _DetailNames; }
            set 
            { 
                _DetailNames = value;
                if (value != null)
                {
                    _Data = new DataTable(_Name);
                    foreach (StatisticsHeader _Column in _DetailNames)
                    {
                        if (_Column != null)
                        {
                            switch (_Column.DataType)
                            {
                                case HeaderType.IntValue:
                                    _Data.Columns.Add(_Column.HeaderText, typeof(DataValue<int>));
                                    break;
                                case HeaderType.DoubleValue:
                                    _Data.Columns.Add(_Column.HeaderText, typeof(DataValue<double>));
                                    break;
                                case HeaderType.DateValue:
                                    _Data.Columns.Add(_Column.HeaderText, typeof(DataValue<DateTime>));
                                    break;
                                case HeaderType.StringValue:
                                    _Data.Columns.Add(_Column.HeaderText, typeof(DataValue<string>));
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Values
        /// </summary>
        public DataTable Values
        {
            get
            {
                return _Data;
            }
        }

        /// <summary>
        /// Image that should be used when displaying statistical headers.
        /// </summary>
        public NodeIcon IconImage
        {
            get { return _IconImage; }
            set { _IconImage = value; }
        }

        /// <summary>
        /// Image that should be used when displaying statistical details.
        /// </summary>
        public NodeIcon DetailIconImage
        {
            get { return _DetailIconImage; }
            set { _DetailIconImage = value; }
        }

        /// <summary>
        /// Delegate for method that should be called to populate data.
        /// </summary>
        public PopulateData PopulateMethod
        {
            get { return _PopulateDataMethod; }
        }

        /// <summary>
        /// Delegate for method that should be called to preview data.
        /// </summary>
        public PopulateData PreviewMethod
        {
            get { return _PreviewDataMethod; }
        }

        /// <summary>
        /// Delegate for method that should be called to load data and its children.
        /// </summary>
        public PopulateData BulkLoadMethod
        {
            get { return _BulkLoadMethod; }
        }

        public bool IsDataLoaded
        {
            get { return _IsDataLoaded; }
            set { _IsDataLoaded = value; }
        }

        /// <summary>
        /// Detailed data.
        /// </summary>
        public List<StatisticalData> ChildData
        {
            get { return _ChildData; }
        }

        /// <summary>
        /// Parent data.
        /// </summary>
        public StatisticalData Parent
        {
            get { return _ParentData; }
            set { _ParentData = value; }
        }

        /// <summary>
        /// Exception thrown while retrieving data.
        /// </summary>
        public Exception DataException
        {
            get { return _DataException; }
            set { _DataException = value; }
        }

        /// <summary>
        /// Type of data contained within the object.
        /// </summary>
        public DataType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// Number of data items contained within the object.
        /// </summary>
        public int ItemCount
        {
            get
            {
                return (_Data == null) ? _EstimatedCount : _Data.Rows.Count;
            }
            set
            {
                _ShowCount = true;
                _EstimatedCount = value;
            }
        }

        /// <summary>
        /// True if the item count should be displayed, otherwise false.
        /// </summary>
        public bool ShowCount
        {
            get { return _ShowCount; }
        }

        public ServerInformation Credentials
        {
            get { return _Credentials; }
            private set { _Credentials = value; }
        }

        /// <summary>
        /// Adds a new row of items.
        /// </summary>
        /// <param name="values"></param>
        public void AddRow(object[] values)
        {
            if (values.Length != _DetailNames.Length)
            {
                throw new InvalidOperationException("There number of items in the row must match the column count.");
            }

            for (int i = 0; i < _DetailNames.Length; i++)
            {
                if (values[i] == null)
                {
                    continue;
                }
                StatisticsHeader _Column = _DetailNames[i];
                switch (_Column.DataType)
                {
                    case HeaderType.IntValue:
                        if (!(values[i] is DataValue<int>))
                        {
                            values[i] = new DataValue<int>((int)values[i]);
                        }
                        break;
                    case HeaderType.DoubleValue:
                        if (!(values[i] is DataValue<double>))
                        {
                            values[i] = new DataValue<double>((double)values[i]);
                        }
                        break;
                    case HeaderType.DateValue:
                        if (!(values[i] is DataValue<DateTime>))
                        {
                            values[i] = new DataValue<DateTime>((DateTime)values[i]);
                        }
                        break;
                    case HeaderType.StringValue:
                        if (!(values[i] is DataValue<DateTime>))
                        {
                            values[i] = new DataValue<string>(values[i].ToString());
                        }
                        break;
                }
            }

            _Data.Rows.Add(values);
        }

        public StatisticalData AddChild(StatisticalData child)
        {
            child.Parent = this;
            child.Credentials = _Credentials;
            this.ChildData.Add(child);
            return child;
        }

        /// <summary>
        /// String representation of Statistical Data.
        /// </summary>
        public override string ToString()
        {
            return _Name;
        }
    }

    /// <summary>
    /// Represents the details header
    /// </summary>
    internal class StatisticsHeader
    {
        string _HeaderText;
        HorizontalAlignment _TextAlign;
        HeaderType _DataType;
        

        private StatisticsHeader(string headerText, HorizontalAlignment textAlign, HeaderType dataType)
        {
            _HeaderText = headerText;
            _TextAlign = textAlign;
            _DataType = dataType;
        }

        public string HeaderText
        {
            get { return _HeaderText; }
        }

        public HorizontalAlignment TextAlign
        {
            get { return _TextAlign; }
        }

        /// <summary>
        /// Implicit converter from string
        /// </summary>
        public static implicit operator StatisticsHeader(string s)
        {
            return new StatisticsHeader(s, HorizontalAlignment.Left, HeaderType.StringValue);
        }

        /// <summary>
        /// Implicit converter to string
        /// </summary>
        public static implicit operator string(StatisticsHeader header)
        {
            return header.HeaderText;
        }

        /// <summary>
        /// Creates a header with right-alignment
        /// </summary>
        public static StatisticsHeader Right(string s)
        {
            return new StatisticsHeader(s, HorizontalAlignment.Right, HeaderType.StringValue);
        }

        /// <summary>
        /// Creates a header with left-alignment
        /// </summary>
        public static StatisticsHeader Center(string s)
        {
            return new StatisticsHeader(s, HorizontalAlignment.Center, HeaderType.StringValue);
        }

        public static StatisticsHeader IntCenter(string s)
        {
            return new StatisticsHeader(s, HorizontalAlignment.Center, HeaderType.IntValue);
        }

        public static StatisticsHeader Int(string s)
        {
            return new StatisticsHeader(s, HorizontalAlignment.Right, HeaderType.IntValue);
        }

        public static StatisticsHeader Double(string s)
        {
            return new StatisticsHeader(s, HorizontalAlignment.Right, HeaderType.DoubleValue);
        }

        public static StatisticsHeader Date(string s)
        {
            return new StatisticsHeader(s, HorizontalAlignment.Right, HeaderType.DateValue);
        }

        /// <summary>
        /// Column Type
        /// </summary>
        public HeaderType DataType
        {
            get { return _DataType; }
        }
    }

    /// <summary>
    /// Contains the display value and the underlying value for statistical data in order to provide accurate sorting.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DataValue<T>
    {
        private T _Value;
        private string _DisplayValue;

        public DataValue(T value) : this(value, value.ToString()) { }

        public DataValue(T value, string displayValue)
        {
            _Value = value;
            _DisplayValue = displayValue;
        }

        /// <summary>
        /// Underlying value.
        /// </summary>
        public T Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
            }
        }

        /// <summary>
        /// Value that should be displayed to the user.
        /// </summary>
        public string DisplayValue
        {
            get
            {
                return _DisplayValue;
            }
            set
            {
                _DisplayValue = value;
            }
        }

        /// <summary>
        /// Implicit converter to string
        /// </summary>
        public static implicit operator string(DataValue<T> value)
        {
            return value.DisplayValue;
        }

        /// <summary>
        /// Implicit converter from string
        /// </summary>
        public static implicit operator DataValue<T>(T value)
        {
            return new DataValue<T>(value);
        }

        /// <summary>
        /// String representation of DataValue.
        /// </summary>
        public override string ToString()
        {
            return (_DisplayValue == null) ? string.Empty : _DisplayValue;
        }
    }

    /// <summary>
    /// Index for the icon that should be used to display data.
    /// </summary>
    internal enum NodeIcon
    {
        Server = 0,
        Database = 1,
        DbCompatibility = 2,
        DbState = 3,
        DataFiles = 4,
        LogFiles = 5,
        Logins = 6,
        LoginType = 7,
        LoginEnabled = 8,
        LoginPolicy = 9,
        BackupDevices = 10,
        LinkedServers = 11,
        Agent = 12,
        Jobs = 13,
        Operators = 14,
        Processes = 15,
        Media = 16,
        ErrorLogs = 17,
        Locks = 18,
        PerformanceCounter = 19,
        Login = 20,
        None = 100
    }

    /// <summary>
    /// Type of data contained in the object.
    /// </summary>
    internal enum DataType
    {
        RawData,
        Rollup,
        RawDataGroup
    }

    /// <summary>
    /// Type of data stored by a DataTable Column
    /// </summary>
    internal enum HeaderType
    {
        StringValue,
        IntValue,
        DoubleValue,
        DateValue
    }

    /// <summary>
    /// Method used to populate statistical data.
    /// </summary>
    internal delegate void PopulateData(Server server, StatisticalData data);
}
