using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
    internal class ConfigurationOptions : JobPoolOptions
    {
        bool _IgnoreSystemDatabases = false;

        /// <summary>
        /// True if system databases should be skipped, otherwise false.
        /// </summary>
        public bool IgnoreSystemDatabases
        {
            get { return _IgnoreSystemDatabases; }
            set { _IgnoreSystemDatabases = value; }
        }
    }
}