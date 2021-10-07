using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Idera.SqlAdminToolset.ServerConfiguration
{
   public class ConfigurationData
   {
      #region Variables
      private string _Name;
      private string _Description;
      private int _MinimumValue;
      private int _MaximumValue;
      private int _ConfiguredValue;
      private int _RunningValue;
      private bool _RestartRequired;
      private ConfigurationType _Type = ConfigurationType.Standard;
      private bool _IsDirty = false;
      private SetDirtyDelegate _SetDirty;
      private string _RegistryKeyName;
      private Dictionary<int, string> _Lookup = new Dictionary<int, string>();
      private string _DisplayValue;

      #endregion

      #region .ctor
      public ConfigurationData() { }

      public ConfigurationData(string name, string description, int minimumValue, int maximumValue, int configuredValue, int runningValue, bool restartRequired, ConfigurationType type, SetDirtyDelegate setDirty)
      {
         _Name = name;
         _Description = description;
         _MinimumValue = minimumValue;
         _MaximumValue = maximumValue;
         _ConfiguredValue = configuredValue;
         _RunningValue = runningValue;
         _RestartRequired = restartRequired;
         _Type = type;
         _SetDirty = setDirty;
      }

      public ConfigurationData(string name, string description, bool restartRequired, SetDirtyDelegate setDirty, string registryKey)
      {
          _Name = name;
          _Description = description;
          _Type = ConfigurationType.Security;
          _RestartRequired = restartRequired;
          _SetDirty = setDirty;
          _RegistryKeyName = registryKey;
      }

       public ConfigurationData(string name, string description, bool restartRequired, SetDirtyDelegate setDirty, string registryKey, int configuredValue, Dictionary<int, string> lookUp)
       {
           _Name = name;
           _Description = description;
           _Type = ConfigurationType.Security;
           _RestartRequired = restartRequired;
           _SetDirty = setDirty;
           _RegistryKeyName = registryKey;
           _ConfiguredValue = configuredValue;
           _Lookup = lookUp;
       }

      #endregion

      #region Accessors
      /// <summary>
      /// Name.
      /// </summary>
      public string Name
      {
         get { return _Name; }
         set { _Name = value; }
      }

      /// <summary>
      /// Description.
      /// </summary>
      public string Description
      {
         get { return _Description; }
         set { _Description = value; }
      }

      /// <summary>
      /// Minimum Value.
      /// </summary>
      public int MinimumValue
      {
         get { return _MinimumValue; }
         set { _MinimumValue = value; }
      }

      /// <summary>
      /// Maximum Value
      /// </summary>
      public int MaximumValue
      {
         get { return _MaximumValue; }
         set { _MaximumValue = value; }
      }

      /// <summary>
      /// Configured value.
      /// </summary>
      public int ConfiguredValue
      {
         get { return _ConfiguredValue; }
         set
         {
            if (_ConfiguredValue != value)
            {
               _ConfiguredValue = value;
               IsDirty = true;
            }
         }
      }

      /// <summary>
      /// Currently running value.
      /// </summary>
      public int RunningValue
      {
         get { return _RunningValue; }
         set { _RunningValue = value; }
      }

      /// <summary>
      /// True if restart required after changing the value, otherwise false.
      /// </summary>
      public bool RestartRequired
      {
         get { return _RestartRequired; }
         set { _RestartRequired = value; }
      }

      /// <summary>
      /// True if this is an advanced option, otherwise false.
      /// </summary>
      public ConfigurationType Type
      {
         get { return _Type; }
         set { _Type = value; }
      }

      /// <summary>
      /// True if this is an advanced option, otherwise false.
      /// </summary>
      public bool IsAdvancedOption
      {
          get { return _Type == ConfigurationType.Advanced; }
          set 
          {
              if (value)
              {
                  _Type = ConfigurationType.Advanced;
              }
          }
      }

      /// <summary>
      /// True when the configuration value has changed, else false.
      /// </summary>
      [XmlIgnore]
      public bool IsDirty
      {
         get { return _IsDirty; }
         private set
         {
            if (_SetDirty != null)
            {
               _IsDirty = value;
               _SetDirty();
            }
         }
      }

      /// <summary>
      /// True if the value needs attention because its out of sync, otherwise false.
      /// </summary>
      /// <param name="name"></param>
      /// <returns></returns>
      public bool NeedsAttention
      {
          get
          {
              if (_Type == ConfigurationType.Security)
              {
                  return false;
              }
              if (_RunningValue == _ConfiguredValue)
              {
                  return false;
              }
              else
              {
                  if ((_Name == ProductConstants.SelfConfiguringIndexCreateMemory || _Name == ProductConstants.SelfConfiguringLocks ||
                     _Name == ProductConstants.SelfConfiguringMaxServerMemory || _Name == ProductConstants.SelfConfiguringMinServerMemory ||
                     _Name == ProductConstants.SelfConfiguringRecoveryInterval || _Name == ProductConstants.SelfConfiguringScanForStartupProcs ||
                     _Name == ProductConstants.SelfConfiguringUserConnections) &&
                     !_RestartRequired && _ConfiguredValue == _MinimumValue)
                  {
                      return false;
                  }
              }
              return true;
          }
      }
      
      /// <summary>
      /// Registry key name to be used when updating and retrieving security-related data.
      /// </summary>
      public string RegistryKeyName
      {
          get { return _RegistryKeyName; }
          set { _RegistryKeyName = value; }
      }

      /// <summary>
      /// Lookup values
      /// </summary>
      internal Dictionary<int, string> Lookup
      {
          get { return _Lookup; }
          set { _Lookup = value; }
      }

       public string DisplayValue
       {
           get
           {
               if (_Type == ConfigurationType.Security)
               {
                   if (_Lookup.Count > 0)
                   {
                       return _Lookup[_ConfiguredValue];
                   }
                   else
                   {
                       return _DisplayValue;
                   }
               }
               else
               {
                   return _ConfiguredValue.ToString();
               }
           }
           set
           {
               _DisplayValue = value;
           }
       }
      #endregion

      /// <summary>
      /// Returns a new instance of Configuratoin data with the same values as the original.
      /// </summary>
      /// <returns></returns>
      public ConfigurationData Copy()
      {
          if (_Type == ConfigurationType.Security)
          {
              return new ConfigurationData(_Name, _Description, _RestartRequired, null, _RegistryKeyName, _ConfiguredValue, _Lookup);
          }
          else
          {
              return new ConfigurationData(_Name, _Description, _MinimumValue, _MaximumValue, _ConfiguredValue, _RunningValue, _RestartRequired, _Type, null);
          }
      }
   }

    /// <summary>
    /// Configuration type
    /// </summary>
    public enum ConfigurationType
    {
        None = 0,
        /// <summary>
        /// Standard Configurations, accessible without enabling advanced options.
        /// </summary>
        Standard = 1,
        /// <summary>
        /// Configuration values accessible only by enabling advance options.
        /// </summary>
        Advanced = 2,
        /// <summary>
        /// Security-related options, accessible through the registry.
        /// </summary>
        Security = 3
    }
}
