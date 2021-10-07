
using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Idera.SqlAdminToolset.SqlDiscovery
{
	/// <summary>
	/// SQLEnum  
	/// Uses NetServerEnum to find SQL Server instances from the browser service
    /// 
    /// Had to call out to some system DLLs here.  
    ///</summary>
	public class SQLNetServerEnum : IEnumerable, IDisposable
	{		
		[Flags]
		internal enum SvType
		{
			WORKSTATION   = 0x00000001,
			SERVER    = 0x00000002,
			SQLSERVER   = 0x00000004,
			DOMAIN_CTRL   = 0x00000008,
			DOMAIN_BAKCTRL  = 0x00000010,
			TIME_SOURCE   = 0x00000020,
			AFP     = 0x00000040,
			NOVELL    = 0x00000080,
			DOMAIN_MEMBER  = 0x00000100,
			PRINTQ_SERVER  = 0x00000200,
			DIALIN_SERVER  = 0x00000400,
			XENIX_SERVER  = 0x00000800,
			NT     = 0x00001000,
			WFW     = 0x00002000,
			SERVER_MFPN   = 0x00004000,
			SERVER_NT   = 0x00008000,
			POTENTIAL_BROWSER = 0x00010000,
			BACKUP_BROWSER  = 0x00020000,
			MASTER_BROWSER  = 0x00040000,
			DOMAIN_MASTER  = 0x00080000,
			SERVER_OSF   = 0x00100000,
			SERVER_VMS   = 0x00200000,
			WINDOWS    = 0x00400000,
			DFS     = 0x00800000,
			CLUSTER_NT   = 0x01000000,
			TERMINALSERVER  = 0x02000000,
			CLUSTER_VS_NT  = 0x04000000,
			DCE     = 0x10000000,
			ALTERNATE_XPORT  = 0x20000000,
			LOCAL_LIST_ONLY  = 0x40000000,
			DOMAIN_ENUM   = unchecked( (int) 0x80000000 ),
			ALL     = unchecked( (int) 0xFFFFFFFF )
		}

		
		[StructLayoutAttribute(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
			internal struct SERVER_INFO_101
		{
			public Int32 Id;
			public string Name;
			public Int32 VerMaj;
			public Int32 VerMin;
			public SvType Typ;
			public string Comment;
		}

	
		// NetServerEnum API call to enumerate servers
		[DllImport("Netapi32", CharSet=CharSet.Unicode, ExactSpelling=true)]
		private static extern int NetServerEnum( string servername, Int32 level, out IntPtr bufptr,
			Int32 prefmaxlen, out Int32 entriesread, out Int32 totalentries, SvType servertype, string domain, IntPtr resume_handle );

		[DllImport("netapi32.dll", ExactSpelling=true)]
		private extern static int NetApiBufferFree( IntPtr bufptr );
		
		private const int ERROR_MORE_DATA = 234;
		
		private SqlServer[] _servers;
		
		public SQLNetServerEnum()
		{			
			int read;
			int total;
			int status;
			
			IntPtr ptr; 
						
			Type type = typeof( SERVER_INFO_101 );
			int size = Marshal.SizeOf( type );
			
			SERVER_INFO_101 si;

			status = NetServerEnum( null, 101, out ptr, -1, out read, out total, SvType.SQLSERVER, null, IntPtr.Zero );
			
			if((status != 0) && (status != ERROR_MORE_DATA)) 
			{ 
				return; 
			}
			else
			{
				_servers = new SqlServer[read];
			
				int tmpPtr = (int)ptr;
				for(int i = 0; i < read; i++ )
				{
					si = (SERVER_INFO_101)Marshal.PtrToStructure((IntPtr)tmpPtr, type );
					
					_servers[i] = new SqlServer(si);
				
					tmpPtr += size;
				}
			
				NetApiBufferFree(ptr); 
				ptr = IntPtr.Zero;
			}
		}

		
		public int Length
		{
			get
			{ 
				if(_servers!=null)
				{
					return _servers.Length;
				}
				else
				{
					return 0;
				}
			
			}
		}
		
				
		public IEnumerator GetEnumerator()
		{
			return new ServerEnumerator(_servers);		
		}
		
		public void Dispose()
		{
			_servers = null;	
		}

		public SqlServer this[int item]
		{
			get 
			{ 
				if(item < this.Length -1)
				{
					return _servers[item];
				}
				else
				{
					throw new IndexOutOfRangeException();
				}	
			}
		}

	}
	
	public struct SqlServer
	{
		SQLNetServerEnum.SERVER_INFO_101 _serverinfo;

		internal SqlServer(SQLNetServerEnum.SERVER_INFO_101 info)
		{
			_serverinfo = info;
		}
		
		public string Name
		{
			get{ return _serverinfo.Name; }
		}
	}

	
	[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
	public class ServerEnumerator : IEnumerator
	{
		private SqlServer[] g_Servers;
		private int Index;
		
		internal ServerEnumerator(SqlServer[] Servers)
		{
			g_Servers = Servers;
			Index = -1;
		}
		
		public void Reset()
		{
			Index = -1;
		}
		
		public object Current
		{
			get
			{
				if ((Index < 0) || (Index == g_Servers.Length)) throw new InvalidOperationException();
				return g_Servers[Index];
			}
		}

		public bool MoveNext()
		{
			if(g_Servers == null) { return false; }
			if (Index < g_Servers.Length) Index++;
			return (!(Index == g_Servers.Length));
		}
	}
}
