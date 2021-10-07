using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Idera.SqlAdminToolset.QuickReindex
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
	} ;

    public enum AuthenticationType
    {
        Windows = 0,
        SQL
    }

	public class DTIRecord
	{
        private int _id;
        private string _name;
        private string _serverName;
        private int _databaseId;
        private string _databaseName;
        private int _tableId;
        private string _tableName;
        private int _indexId;
        private string _indexName;
        private ServerVersionType _serverVersion;
        private EngineEdition _engineEdition;
        private string _schemaName;
        private AuthenticationType _authenticationType;
        private string _loginName;
        private string _password;

		public DTIRecord()
		{
			_id = ProductConstants.NullID;
		    _name = string.Empty;
		    _serverName = string.Empty;
            _databaseId = ProductConstants.NullID;
		    _databaseName = string.Empty;
            _tableId = ProductConstants.NullID;
		    _tableName = string.Empty;
            _indexId = ProductConstants.NullID;
		    _indexName = string.Empty;
			_serverVersion = ServerVersionType.Unknown;
			_engineEdition = EngineEdition.Unknown;
			_schemaName = string.Empty;

//            _analysisState = ProductConstants.NullID;
		}

        virtual public int Id
	    {
	        get { return _id; }
            set { _id = value; }
	    }
	    virtual public string Name
	    {
	        get { return _name; }
            set { _name = value; }
	    }
        virtual public string ServerName
	    {
	        get { return _serverName; }
            set { _serverName = value; }
	    }
        virtual public int DatabaseId
	    {
	        get { return _databaseId; }
            set { _databaseId = value; }
	    }
        virtual public string DatabaseName
	    {
	        get { return _databaseName; }
            set { _databaseName = value; }
	    }
        virtual public int TableId
	    {
	        get { return _tableId; }
            set { _tableId = value; }
	    }
        virtual public string TableName
	    {
	        get { return _tableName; }
            set { _tableName = value; }
	    }
	    public int IndexId
	    {
	        get { return _indexId; }
            set { _indexId = value; }
	    }
	    public string IndexName
	    {
	        get { return _indexName; }
            set { _indexName = value; }
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
	    public string SchemaName
	    {
            get { return _schemaName; }
            set { _schemaName = value; }
	    }
	    public AuthenticationType AuthenticationType
	    {
            get { return _authenticationType; }
            set { _authenticationType = value; }
	    }
	    public string LoginName
	    {
            get { return _loginName; }
            set { _loginName = value; }
	    }
	    public string Password
	    {
            get { return _password; }
            set { _password = value; }
	    }

    }
}
