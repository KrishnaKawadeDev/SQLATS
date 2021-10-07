using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using BBS.TracerX;
using System.Configuration;
using Microsoft.Win32;

namespace Idera.SqlAdminToolset.Core
{
   public delegate object InterfaceFactoryDelegate( bool useGUI );

   public static class ToolStartup
   {
      [DllImport( "kernel32.dll", SetLastError = true )]
      static extern bool AttachConsole( uint dwProcessId );
      const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;

      //-----------------------------------------------------------------------
      // ToolMain
      //
      /// <summary>
      /// ToolMain - The common entry point logic for all tools
      /// </summary>
      //-----------------------------------------------------------------------
      public static int
         ToolMain(
            string[]                    args,
            string                      productName,
            string                      productDescription,
            string                      shortProductName,
            bool                        productSupportsCommandLine,
            InterfaceFactoryDelegate    interfaceFactory
         )
      {
            try
            {

                bool useGUI = true;
                bool showWelcomeScreen = true;
                int returnVal = 0;

                // set whether user is local admin
                if (SecurityRole.IsLocalAdmin())
                {
                    ToolsetOptions.optionsRootKey = Registry.LocalMachine;
                }
                else
                {
                    ToolsetOptions.optionsRootKey = Registry.CurrentUser;
                }

                AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

                CoreGlobals.configurationPath = Path.GetDirectoryName(Application.ExecutablePath);
                CoreGlobals.configurationPath = Path.Combine(CoreGlobals.configurationPath, "SQLadminToolset.config");

                // start logging
                //Logger.FileLogging.Open();
                CoreGlobals.traceLog = Logger.GetLogger(productName);
                Logger.Xml.Configure(new FileInfo(CoreGlobals.configurationPath));
                Logger.FileLogging.Open();

                CoreGlobals.traceLog.InfoFormat("Started {0} - Version: {1}",
                                      productName,
                                      System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());
                // switch to shared config file
                try
                {
                    AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", CoreGlobals.configurationPath);
                }
                catch (Exception ex)
                {
                    CoreGlobals.traceLog.DebugFormat("Error opening configuration file {0} - Error: {1}", CoreGlobals.configurationPath, ex.Message);
                }

                // save command line args
                if (args.Length == 0)
                {
                    CoreGlobals.commandLineArgs = new string[0];
                }
                else
                {
                    CoreGlobals.commandLineArgs = new string[args.Length];
                    for (int i = 0; i < args.Length; i++)
                    {
                        CoreGlobals.commandLineArgs[i] = args[i];
                    }
                }

                using (CoreGlobals.traceLog.InfoCall())
                {
                    try
                    {
                        CoreGlobals.productName = productName;
                        CoreGlobals.shortProductName = shortProductName;
                        CoreGlobals.productDescription = productDescription;

                        // Load Toolset Options & Server Groups
                        ToolsetOptions.ReadOptions();
                        ToolServerGroup.InitializeServerGroupList();


                        // if no arguments then we are running the GUI with a welcome screen
                        if (args.Length == 0)
                        {
                            showWelcomeScreen = true;
                            useGUI = true;
                        }
                        else
                        {
                            // if we have command line arguments we are either running as a command line
                            // or are running with the one argument to suppress the welcome screen when
                            // the product is started from the product launchpad

                            // Check for special command line parameter to prevent welcome screen when launched from
                            // launchpad since launchpad already shows the welcome screen
                            if (args.Length > 0 && args[0].ToUpper() == "/NOWELCOMESCREEN")
                            {
                                showWelcomeScreen = false;
                                useGUI = true;
                            }
                            else if (productSupportsCommandLine)
                            {
                                useGUI = false;
                            }
                        }

                        if (useGUI)
                        {
                            CoreGlobals.traceLog.Info("Launching product GUI");

                            //-----
                            // GUI 
                            //-----
                            CoreGlobals.showWelcomeScreen = showWelcomeScreen;

                            Form startupForm = (Form)interfaceFactory(true);
                            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                            Application.Run(startupForm);
                        }
                        else
                        {
                            CoreGlobals.traceLog.Verbose("Launching product CLI");

                            //--------------
                            // Command Line
                            //--------------
                            if (!AttachConsole(ATTACH_PARENT_PROCESS))
                            {
                                // cant write this error to the console so launch a messagebox - not the friendliest 
                                Messaging.ShowError("AttachConsole failed");
                            }


                            ToolCommandLineHandler cli = (ToolCommandLineHandler)interfaceFactory(false);


                            returnVal = cli.Run(args);
                            if (returnVal == -1)
                            {
                                Application.Exit();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string exMsg = Helpers.GetCombinedExceptionText(ex);

                        CoreGlobals.traceLog.FatalFormat("Unhandled Exception in {0}\r\n{1}",
                                               productName,
                                               exMsg);
                        if (useGUI)
                        {
                            Messaging.ShowException("An Unhandled Exception occured.", ex);
                        }
                        else
                        {
                            Console.WriteLine("An Unhandled Exception occured.");
                            Console.WriteLine(Helpers.GetCombinedExceptionText(ex));
                        }
                    }
                    return returnVal;
                }
            }
            catch(Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("Could not load file or assembly 'License4Net"))
                {
                    MessageBox.Show("Some of the required dependencies are missing.\nPlease download and install the Microsoft Visual C++ 2015 Redistributable package from the link below\n\nhttps://www.microsoft.com/en-us/download/details.aspx?id=52685", "IDERA SQL admin toolset");
                }
                else
                {
                    MessageBox.Show(ex.InnerException.ToString());
                }
                return 0;
            }
      }

       /// <summary>
       /// Resolves any assemblies that fail to load
       /// </summary>
       static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
       {
            string pathToAssembly = "..\\..\\..\\..\\redist\\BBSLicense";

            var parts = args.Name.Split(',');
            if (parts[0].Equals("License4Net", StringComparison.InvariantCultureIgnoreCase))
            {

                if (IntPtr.Size == 8)
                    pathToAssembly += "\\x64\\License4Net.dll";
                else
                    pathToAssembly += "\\x86\\License4Net.dll";

                return Assembly.LoadFrom(pathToAssembly);
            }
           string _SearchPaths = ConfigurationManager.AppSettings["AssemblyLoadFolders"];
           if(_SearchPaths != null)
           {
               foreach(string _Path in _SearchPaths.Split(','))
               {
                   string _NewAssemblyPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("{0}\\{1}.dll", _Path.Trim(), args.Name.Substring(0, args.Name.IndexOf(","))));
                   if (File.Exists(_NewAssemblyPath))
                   {
                       Assembly _LoadedAssembly = Assembly.LoadFrom(_NewAssemblyPath);
                       CoreGlobals.traceLog.InfoFormat("Loaded {0}", _LoadedAssembly.FullName);
                       return _LoadedAssembly;
                   }
               }
           }
           return null;
       }

       static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
       {
           string exMsg = Helpers.GetCombinedExceptionText(e.Exception);

           CoreGlobals.traceLog.FatalFormat("Unhandled Exception in {0}\r\n{1}\r\n{2}",
                                  CoreGlobals.productName,
                                  exMsg,
                                  e.Exception.StackTrace);
            
           Messaging.ShowException("An Unhandled Exception occurred and the application will shut down immediately.", e.Exception);
           Application.Exit();
       }
   }
}