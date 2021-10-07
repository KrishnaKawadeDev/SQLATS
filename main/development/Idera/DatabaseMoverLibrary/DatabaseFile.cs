using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Idera.SqlAdminToolset.DatabaseMoverLibrary
{
   /// <summary>
   /// Datafile information
   /// </summary>
   public class DatabaseMoverFile
   {
      #region variables
      private string _SourceFileName;
      private string _DestinationFileName;
      private string _SourceLogicalName;
      private string _DestinationLogicalName;
      private string _SourceServerName;
      private string _SourceDirectory;
      private string _DestinationServerName;
      private string _DestinationDirectory;
      private DatabaseFileType _Type = DatabaseFileType.Data;
      #endregion

      #region .ctor
      public DatabaseMoverFile() { }

      public DatabaseMoverFile(string sourceServer, string destinationServer, string sourceFileName, string sourceLogicalName, DatabaseFileType type)
      {
         _SourceFileName = _DestinationFileName = Path.GetFileName(sourceFileName);
         _SourceDirectory = _DestinationDirectory = Path.GetDirectoryName(sourceFileName);
         _Type = type;
         _SourceLogicalName = _DestinationLogicalName = sourceLogicalName;
         _SourceServerName = sourceServer;
         _DestinationServerName = destinationServer;
      }
      #endregion

      #region accessors
      /// <summary>
      /// File name.
      /// </summary>
      public string SourceFileName
      {
         get { return _SourceFileName; }
         set { _SourceFileName = value; }
      }

      /// <summary>
      /// Logical Name of the file at the source.
      /// </summary>
      public string SourceLogicalName
      {
         get { return _SourceLogicalName; }
      }

      /// <summary>
      /// Logical Name of the file at the destination.
      /// </summary>
      public string DestinationLogicalName
      {
         get { return _DestinationLogicalName; }
         set { _DestinationLogicalName = value; }
      }

      /// <summary>
      /// Source Server Name;
      /// </summary>
      public string SourceServerName
      {
         get { return _SourceServerName; }
      }

      /// <summary>
      /// Source directory.
      /// </summary>
      public string SourceDirectory
      {
         get { return _SourceDirectory; }
      }

      /// <summary>
      /// Destination Server Name.
      /// </summary>
      public string DestinationServerName
      {
         get { return _DestinationServerName; }
      }

      /// <summary>
      /// Destination Directory
      /// </summary>
      public string DestinationDirectory
      {
         get { return _DestinationDirectory; }
         set 
         {
            value = value.Trim();
            if (!value.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
               value += Path.DirectorySeparatorChar;
            }
            _DestinationDirectory = value.Trim(); 
         }
      }

      /// <summary>
      /// Full path to the destination file.
      /// </summary>
      public string FullDestinationPath
      {
         get
         {
            return Path.Combine(_DestinationDirectory, _DestinationFileName);
         }
      }

      /// <summary>
      /// Full path to the source file.
      /// </summary>
      public string FullSourcePath
      {
         get
         {
            return Path.Combine(_SourceDirectory, _SourceFileName);
         }
      }

      /// <summary>
      /// Network share for destination server
      /// </summary>
      public string SourceNetworkShare
      {
         get 
         {
            return ConvertLocalToAdminSharePath(_SourceServerName, FullSourcePath);
         }
      }

      /// <summary>
      /// Network share for destination server
      /// </summary>
      public string DestinationNetworkShare
      {
         get 
         {
            return ConvertLocalToAdminSharePath(_DestinationServerName, FullDestinationPath);
         }
      }

      /// <summary>
      /// Destination file name.
      /// </summary>
      public string DestinationFileName
      {
         get { return _DestinationFileName; }
         set { _DestinationFileName = value; }
      }

      /// <summary>
      /// File type
      /// </summary>
      public DatabaseFileType Type
      {
         get { return _Type; }
         set { _Type = value; }
      }
      #endregion

      #region Methods

      /// <summary>
      /// Converts a local file path to an admin share.
      /// </summary>
      public static string ConvertLocalToAdminSharePath(string serverName, string filePath)
      {
         return string.Format(@"\\{0}\{1}", serverName, filePath.Replace(Path.VolumeSeparatorChar, '$'));
      }

      #endregion

      public enum DatabaseFileType
      {
         Data,
         Log 
      }

   }
}
