﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace BSBTAC.LoadSearch
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            #if(!DEBUG)
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
	            { 
                    new LoadSearch() 
	            };
                ServiceBase.Run(ServicesToRun);
            #else
                LoadSearch loadSearch = new LoadSearch();
                loadSearch.ManualOnStart();
            #endif
        }
    }
}
