using System;
using System.Collections.Generic;
using System.Text;
using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.DatabaseConfiguration
{
   /// <summary>
   /// Results of a configuration change request.
   /// </summary>
   internal class ConfigurationChangeResults
   {
      private ConfigurationData _Data;
      private bool _IsSuccessful;
      private Exception _ChangeException = null;
      private ServerInformation _Server;
      private string _Database;

      /// <summary>
      /// Initializes a new instance of ConfigurationChangeResults
      /// </summary>
      public ConfigurationChangeResults(ServerInformation server, string database, ConfigurationData data, bool isSuccessful)
            : this(server, database, data, isSuccessful, null) { }

      /// <summary>
      /// Initializes a new instance of ConfigurationChangeResults
      /// </summary>
      public ConfigurationChangeResults(ServerInformation server, string database, ConfigurationData data, bool isSuccessful, Exception changeException)
      {
         _Data = data;
         _IsSuccessful = isSuccessful;
         _ChangeException = changeException;
         _Server = server;
         _Database = database;
      }

      /// <summary>
      /// Configuration data that was requested for the update.
      /// </summary>
      public ConfigurationData Data
      {
         get { return _Data; }
      }

      /// <summary>
      /// True if the request was successful, else false.
      /// </summary>
      public bool IsSuccessful
      {
         get { return _IsSuccessful; }
      }

      /// <summary>
      /// Exception thrown by change request.  Null if no exception found.
      /// </summary>
      public Exception ChangeException
      {
         get { return _ChangeException; }
      }

      /// <summary>
      /// Server that the request was submitted against.
      /// </summary>
      public ServerInformation Server
      {
         get { return _Server; }
      }

      /// <summary>
      /// Database that the request was submited against.
      /// </summary>
      public string Database
      {
         get { return _Database; }
      }

   }
}
