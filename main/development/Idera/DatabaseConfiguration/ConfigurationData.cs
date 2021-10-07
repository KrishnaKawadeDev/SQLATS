using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
    [Serializable]
    public class ConfigurationData
    {
        #region private variables

        private string _Name;
        private string _InternalName;
        private string _Description;
        private string _Value;
        private OptionGroup _Group;
        private Dictionary<string, string> _ValidValues;
        private bool _IsDirty;

        #endregion

        #region .ctor

        public ConfigurationData(string name, string internalName, OptionGroup group)
        {
            _Name = name;
            _InternalName = internalName;
            _Group = group;
        }

        public ConfigurationData(string name, string internalName, Dictionary<string, string> validValues, OptionGroup group)
            : this(name, internalName, group)
        {
            _ValidValues = validValues;
        }

        public ConfigurationData(string name, Dictionary<string, string> validValues, OptionGroup group)
            : this(name, string.Empty, validValues, group)
        {
        }

        public ConfigurationData() { }

        #endregion

        #region accessors
        /// <summary>
        /// Name displayed to the user.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Name used to update/retrive data from the system.
        /// </summary>
        public string InternalName
        {
            get { return _InternalName; }
            set { _InternalName = value; }
        }

        /// <summary>
        /// Description of configuration data.
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        /// <summary>
        /// Current value.
        /// </summary>
        public string Value
        {
            get { return _Value; }
            set
            {
                if (_Value != null && _Value.CompareTo(value) != 0)
                {
                    _IsDirty = true;
                }
                _Value = value;
            }
        }

        /// <summary>
        /// Configuration grouping.
        /// </summary>
        public OptionGroup Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        /// <summary>
        /// Allowed values.
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> ValidValues
        {
            get { return _ValidValues; }
        }

        /// <summary>
        /// Retrieves the value that should be used internally to update the database.
        /// </summary>
        public string InternalValue
        {
            get
            {
                foreach (KeyValuePair<string, string> _ValueItem in _ValidValues)
                {
                    if (_ValueItem.Value == _Value)
                    {
                        return _ValueItem.Key;
                    }
                }
                return null;
                //TODO: throw exception
            }
        }

        /// <summary>
        /// True if the value has changed, else false.
        /// </summary>
        public bool IsDirty
        {
            get { return _IsDirty; }
        }
        #endregion

        public override string ToString()
        {
            return _Value;
        }

        public ConfigurationData Copy()
        {
            ConfigurationData _Data = new ConfigurationData(Name, InternalName, ValidValues, Group);
            _Data.Value = Value;
            return _Data;
        }
    }
}