using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;
using System.Data.SqlClient;
using System.Data;

namespace Idera.SqlAdminToolset.SpaceAnalyzer
{

    public class DiskRecord 
    {

        private string _driveLetter;
        private string _volumeName;
        private string _driveType;      // Removeable Disk, Local Disk, Network Disk, Compact Disk, RAM Disk, Unknown
        private string _driveOS;        // FAT, FAT32, NTFS, ...
        private string _computerName;
        private ulong _diskSize;
        private ulong _diskUsedSize;
        private ulong _diskFreeSpace;
        private double _diskPercentUsed;
        private double _diskPercentFree;
        private SQLCredentials _sqlCredentials;
        private bool _containsDatabases;

        public DiskRecord()
        {
            _driveLetter = string.Empty;
            _volumeName = string.Empty;
            _driveType = string.Empty;
            _driveOS = string.Empty;
            _computerName = string.Empty;
            _diskSize = 0;
            _diskUsedSize = 0;
            _diskFreeSpace = 0;
            _diskPercentUsed = 0.0;
            _diskPercentFree = 0.0;
        }

        public string DriveLetter
        {
            get { return _driveLetter; }
            set { _driveLetter = value; }
        }
        public string VolumeName
        {
            get { return _volumeName; }
            set { _volumeName = value; }
        }
        public string DriveType
        {
            get { return _driveType; }
            set { _driveType = value; }
        }
        public string DriveOS
        {
            get { return _driveOS; }
            set { _driveOS = value; }
        }
        public string ComputerName
        {
            get { return _computerName; }
            set { _computerName = value; }
        }
        public ulong DiskSize
        {
            get { return _diskSize; }
            set { _diskSize = value; }
        }
        public ulong DiskUsedSize
        {
            get { return _diskUsedSize; }
            set { _diskUsedSize = value; }
        }
        public ulong DiskFreeSpace
        {
            get { return _diskFreeSpace; }
            set { _diskFreeSpace = value; }
        }
        public double DiskPercentFree
        {
            get { return _diskPercentFree; }
            set { _diskPercentFree = value; }
        }
        public double DiskPercentUsed
        {
            get { return _diskPercentUsed; }
            set { _diskPercentUsed = value; }
        }
        public SQLCredentials SqlCredentials
        {
            get { return _sqlCredentials; }
            set { _sqlCredentials = value; }
        }
        public bool ContainsDatabases
        {
            get { return _containsDatabases; }
            set { _containsDatabases = value; }
        }
    }
}
