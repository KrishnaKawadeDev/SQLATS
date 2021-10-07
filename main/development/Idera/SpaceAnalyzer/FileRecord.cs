using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Idera.SqlAdminToolset.SpaceAnalyzer
{
    public enum ServerVersionType
    {
        Unknown = 1,
        SQL2000,
        SQL2005,
        SQL2008,
        SQL2012,
        SQL2014,
        SQL2016,
        SQL2017
    };

    public enum EngineEdition
    {
        Unknown = 0,
        Personal,   //1 = Personal or Desktop Engine 
        Standard,   //2 = Standard 
        Enterprise, //3 = Enterprise (This is returned for Enterprise, Enterprise Evaluation, and Developer.)
        Express     //4 = Express
    };

    public enum FileType
    {
        Unknown = -1,
        Data = 0,
        Log,
        //Reservered1,
        //Reservered2,
        // FullText       
    }

    public class FileRecord : DiskRecord
    {
        private int _id;
        private string _logicalName;
        private string _fullPathName;
        private FileType _type;
        private string _fileGroup;
        private string _autoGrowth;
        private bool _isGrowthPercent;
        private long _size;
        private string _maxSize;
        private long _usedSize;
        private double _percentUsed;
        private double _percentUsedRelativeToDisk;

        private string _serverName;
        private int _databaseId;
        private string _databaseName;
        private ServerVersionType _serverVersion;
        private EngineEdition _engineEdition;

        public FileRecord()
        {
            _id = ProductConstants.NullID;
            _logicalName = string.Empty;
            _fullPathName = string.Empty;
            _type = FileType.Unknown;
            _fileGroup = string.Empty;
            _autoGrowth = string.Empty;
            _isGrowthPercent = true;
            _size = -1;
            _maxSize = string.Empty;
            _usedSize = -1;
            _percentUsed = 0.0;
            _percentUsedRelativeToDisk = 0.0;
            _serverName = string.Empty;
            _databaseId = ProductConstants.NullID;
            _databaseName = string.Empty;
            _serverVersion = ServerVersionType.Unknown;
            _engineEdition = EngineEdition.Unknown;
        }

        public override string ToString()
        {
            return LogicalName;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string LogicalName
        {
            get { return _logicalName; }
            set { _logicalName = value; }
        }
        public string FullPathName
        {
            get { return _fullPathName; }
            set { _fullPathName = value; }
        }
        public FileType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string FileGroup
        {
            get { return _fileGroup; }
            set { _fileGroup = value; }
        }
        public string AutoGrowth
        {
            get { return _autoGrowth; }
            set { _autoGrowth = value; }
        }
        public bool IsGrowthPercent
        {
            get { return _isGrowthPercent; }
            set { _isGrowthPercent = value; }
        }
        public long Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public string MaxSize
        {
            get { return _maxSize; }
            set { _maxSize = value; }
        }
        public long UsedSize
        {
            get { return _usedSize; }
            set { _usedSize = value; }
        }
        public double PercentUsed
        {
            get { return _percentUsed; }
            set { _percentUsed = value; }
        }
        public double PercentUsedRelativeToDisk
        {
            get { return _percentUsedRelativeToDisk; }
            set { _percentUsedRelativeToDisk = value; }
        }
        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }
        public int DatabaseId
        {
            get { return _databaseId; }
            set { _databaseId = value; }
        }
        public string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }
        public ServerVersionType ServerVersion
        {
            get { return _serverVersion; }
            set { _serverVersion = value; }
        }
        public EngineEdition EngineEdition
        {
            get { return _engineEdition; }
            set { _engineEdition = value; }
        }

        public bool IsFiltered
        {
            get
            {
                bool filtered = false;
                if (ProductConstants.globalHideDataFiles && Type == FileType.Data)
                {
                    filtered = true;
                }
                if (ProductConstants.globalHideLogFiles && Type == FileType.Log)
                {
                    filtered = true;
                }
                return filtered;
            }
        }

        public bool IsDiskSpaceCritical
        {
            get
            {
                bool critical = false;
                if (DiskPercentUsed >= ProductConstants.CriticalPercentUsed)
                {
                    critical = true;
                }
                return critical;
            }
        }

        public bool IsDiskSpaceCaution
        {
            get
            {
                bool caution = false;
                if (DiskPercentUsed < ProductConstants.CriticalPercentUsed && DiskPercentUsed > ProductConstants.AcceptablePercentUsed)
                {
                    caution = true;
                }
                return caution;
            }
        }
    }
}
