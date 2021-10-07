using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.InteropServices;


namespace Idera.SqlAdminToolset.Core.Security
{
   public class Impersonation
   {
      IntPtr                      existingTokenHandle = IntPtr.Zero;
      IntPtr                      duplicateTokenHandle = IntPtr.Zero;
      string                      user;
      string                      domain;
      string                      password;
      WindowsImpersonationContext impersonationContext  = null;      
      
      #region Native Code
      //------------------------------------------------------------
      // DllImport
      //------------------------------------------------------------
		[DllImport("advapi32.dll")]
		private static extern bool
		   LogonUser(
			   String lpszUsername,
			   String lpszDomain,
			   String lpszPassword,
			   int dwLogonType,
			   int dwLogonProvider,
			   ref IntPtr phToken
			);

		[DllImport("advapi32.dll")]
		private static extern bool
		   DuplicateToken(
			   IntPtr ExistingTokenHandle,
			   int ImpersonationLevel,
			   ref IntPtr DuplicateTokenHandle
			);

		[DllImport("kernel32.dll")]
		private static extern bool
		   CloseHandle(
		      IntPtr hObject
		   );

		[DllImport("advapi32.dll")]
		private static extern bool
		   ImpersonateLoggedOnUser(
		      IntPtr hToken
		   );

		[DllImport("kernel32.dll")]
		private static extern int
		   GetLastError();

		//enum impersonation levels an logon types

		private enum SecurityImpersonationLevel
		{ 
			SecurityAnonymous, 
			SecurityIdentification, 
			SecurityImpersonation, 
			SecurityDelegation 
		}

		private enum LogonTypes
		{
			LOGON32_PROVIDER_DEFAULT = 0,
			LOGON32_LOGON_INTERACTIVE = 2,
			LOGON32_LOGON_NETWORK = 3,
			LOGON32_LOGON_BATCH = 4,
			LOGON32_LOGON_SERVICE = 5,
			LOGON32_LOGON_UNLOCK = 7,
			LOGON32_LOGON_NETWORK_CLEARTEXT = 8,
			LOGON32_LOGON_NEW_CREDENTIALS = 9
		}
		
		#endregion
      
      //-----------------------------------------------------------------------
      // CTOR
      //-----------------------------------------------------------------------
      public
         Impersonation(
            string   inUser,
            string   inDomain,
            string   inPassword
         )
      {
         user     = inUser;
         domain   = inDomain;
         password = inPassword;
      }

       public
         Impersonation(
            string inUser,
            string inPassword
         )
       {
           int index = inUser.IndexOf(@"\");
           if (index > 0)
           {
               domain = inUser.Substring(0, index);
               user = inUser.Substring(index + 1, (inUser.Length - index - 1));
           }
           else
           {
               domain = "."; // use local account database
               user = inUser;
           }
           password = inPassword;
       }
      
      //-----------------------------------------------------------------------
      // Start
      //-----------------------------------------------------------------------
      public void Start()
      {
         if ( impersonationContext != null )
         {
            throw new Exception("Impersonation already in effect" );
         }
          
         try
         {
            // Call LogonUser to get a token for the user
            bool isOkay;
				isOkay = LogonUser( user,
				                    domain,
				                    password, 
					                 (int)LogonTypes.LOGON32_LOGON_INTERACTIVE,
					                 (int)LogonTypes.LOGON32_PROVIDER_DEFAULT, 
					                 ref existingTokenHandle);
            if(! isOkay)
            {
					int lastWin32Error = Marshal.GetLastWin32Error();
					int lastError = GetLastError();
					
               throw new Win32Exception( String.Format( "LogonUser failed: {0} - {1}", lastWin32Error,lastError  ));
            }
            else
            {
				   // copy the token
				   isOkay = DuplicateToken( existingTokenHandle, 
					                         (int)SecurityImpersonationLevel.SecurityImpersonation, 
					                          ref duplicateTokenHandle);
				   if (! isOkay ) 
				   {
					   int lastWin32Error = Marshal.GetLastWin32Error();
					   int lastError = GetLastError();
					   CloseHandle(existingTokenHandle); 
					   throw new Exception("DuplicateToken Failed: "+lastWin32Error+" - "+lastError);
				   }
				   else 
				   {
					   // create an identity from the token
					   WindowsIdentity newId = new WindowsIdentity(duplicateTokenHandle);
					   impersonationContext = newId.Impersonate();
				   }
   	      }
         }
         catch (Exception e)
         {
            string msg = String.Format( "Could not impersonate user {0}.\r\n\r\nError: " + e.Message, user );
            throw new Exception( msg );
         }
         finally
         {
				//free all handles
				if (existingTokenHandle != IntPtr.Zero)
				{
					CloseHandle(existingTokenHandle);
				}
				if (duplicateTokenHandle != IntPtr.Zero)
				{
					CloseHandle(duplicateTokenHandle);
				}
         }
      }
      
      //-----------------------------------------------------------------------
      // Undo
      //-----------------------------------------------------------------------
      public void Undo()
      {
         try
         {   
            if ( impersonationContext != null )
            {
               impersonationContext.Undo();
               impersonationContext = null;
            }
         }
         catch {}
      }
   }
}
