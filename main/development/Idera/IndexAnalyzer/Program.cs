using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

using Idera.SqlAdminToolset.Core;

namespace Idera.SqlAdminToolset.IndexAnalyzer
{
    static class Program
    {
        //-----------------------------------------------------------------------
        // Main
        //
        /// <summary>
        /// Main - The main entry point for the application.
        /// </summary>
        //-----------------------------------------------------------------------
        [STAThread]
        static int
           Main(
              string[] args
           )
        {
            int retval = 0;

            retval = Core.ToolStartup.ToolMain(args,
                                                ProductConstants.productName,
                                                ProductConstants.productDescription,
                                                ProductConstants.shortProductName,
                                                ProductConstants.supportsCommandLine,
                                                InterfaceFactory);
            return retval;
        }

        //--------------------------------------------
        // Class Factories for GUI and CLI interfaces
        //--------------------------------------------
        static public object InterfaceFactory(bool useGUI)
        {
            object userInterface = null;

            if (useGUI)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                userInterface = new Form_Main();
            }
            else
            {
                userInterface = new CommandLineHandler();
            }
            return userInterface;
        }
    }
    public class Selectivity
    {
        public double calculate_selectivity(double value, double rows)
        {
            double selectivity;
            if (value > 0)
            {
                if (rows == 0)
                {
                    selectivity = -2;
                }
                else
                {
                    selectivity = 1 / (value * rows);
                    if (selectivity > 1)
                        selectivity = 1;
                }
            }
            else
            {
                selectivity = value;
            }
            return selectivity;

        }
    }
}
