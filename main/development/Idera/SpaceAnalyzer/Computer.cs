using System;
using System.Collections.Generic;
using System.Text;

namespace Idera.SqlAdminToolset.SpaceAnalyzer
{
    class Computer
    {
        private string _name;

        private List<Disk> _disks;

        public Computer(string name)
        {
            _name = name;
            _disks = new List<Disk>();
        }

        public List<Disk> Disks
        {
            get { return _disks; }
            set { _disks = value; }
        }
        public string Name
        {
            get { return _name; }
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || GetType() != obj.GetType()) return false;

            Computer c = (Computer)obj;
            return (_name == c.Name);
        }

       public override int GetHashCode()
       {
          return base.GetHashCode();
       }

        public List<string> SQLServers
        {
            get
            {
                List<string> sqlservers = new List<string>();
                foreach(Disk d in _disks)
                {
                    foreach (FileRecord f in d.Files)
                    {
                        if(!sqlservers.Contains(f.ServerName))
                        {
                            sqlservers.Add(f.ServerName);
                        }                        
                    }
                }
                return sqlservers;
            }
        }

        public List<FileRecord> GetFilesForSQLServer(string serverName)
        {
            List<FileRecord> files = new List<FileRecord>();
            foreach (Disk d in _disks)
            {
                foreach (FileRecord f in d.Files)
                {
                    if(f.ServerName == serverName)
                    {
                        files.Add(f);
                    }
                }
            }
            return files;
        }

        public List<string> DatabasesForSQLServer(string serverName)
        {
            List<string> databases = new List<string>();
            foreach (Disk d in _disks)
            {
                foreach (FileRecord f in d.Files)
                {
                    if (f.ServerName == serverName)
                    {
                        if (!databases.Contains(f.DatabaseName))
                        {
                            databases.Add(f.DatabaseName);
                        }
                    }
                }
            }
            return databases;
        }

        public List<FileRecord> GetFilesForDatabase(string serverName, string databaseName)
        {
            List<FileRecord> files = new List<FileRecord>();
            foreach (Disk d in _disks)
            {
                foreach (FileRecord f in d.Files)
                {
                    if (f.ServerName == serverName && f.DatabaseName == databaseName)
                    {
                        files.Add(f);
                    }
                }
            }
            return files;
        }


        public int NumberCriticalDisks
        {
            get
            {
                int count = 0;
                foreach (Disk _disk in _disks)
                {
                    if (_disk.DiskPercentUsed >= ProductConstants.CriticalPercentUsed)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public int NumberCautionDisks
        {
            get
            {
                int count = 0;
                foreach (Disk _disk in _disks)
                {
                    if (_disk.DiskPercentUsed < ProductConstants.CriticalPercentUsed && _disk.DiskPercentUsed > ProductConstants.AcceptablePercentUsed)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public int NumberAcceptableDisks
        {
            get
            {
                int count = 0;
                foreach (Disk _disk in _disks)
                {
                    if (_disk.DiskPercentUsed <= ProductConstants.AcceptablePercentUsed)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }

    class Disk : DiskRecord
    {
        private List<FileRecord> _files;

        public Disk(DiskRecord dr)
        {
            this.ComputerName = dr.ComputerName;
            this.DiskFreeSpace = dr.DiskFreeSpace;
            this.DiskPercentFree = dr.DiskPercentFree;
            this.DiskPercentUsed = dr.DiskPercentUsed;
            this.DiskSize = dr.DiskSize;
            this.DiskUsedSize = dr.DiskUsedSize;
            this.DriveOS = dr.DriveOS;
            this.DriveType = dr.DriveType;
            this.DriveLetter = dr.DriveLetter;
            this.ContainsDatabases = dr.ContainsDatabases;

            _files = new List<FileRecord>();
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if (obj == null || GetType() != obj.GetType()) return false;

            Disk d = (Disk)obj;
            return (this.ComputerName == d.ComputerName && this.DriveLetter == d.DriveLetter);
        }
        
       public override int GetHashCode()
       {
          return base.GetHashCode();
       }

        public List<FileRecord> Files
        {
            get { return _files; }
        }
        
        public bool IsDiskSpaceCritical
        {
            get { return DiskPercentUsed >= ProductConstants.CriticalPercentUsed; }
        }
        public bool IsDiskSpaceCaution
        {
            get { return (DiskPercentUsed < ProductConstants.CriticalPercentUsed && DiskPercentUsed > ProductConstants.AcceptablePercentUsed); }
        }

        public int NumberCriticalFiles
        {
            get
            {
                int count = 0;
                foreach (FileRecord _file in _files)
                {
                    if(!_file.IsFiltered && _file.DiskPercentUsed >= ProductConstants.CriticalPercentUsed)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

    }
}
