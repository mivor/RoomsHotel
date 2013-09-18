using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Diagnostics;
using System.IO;

namespace RoomsHotel
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using ( Process app = Process.GetProcessesByName("Hotel").FirstOrDefault() )
            {
                if (app != default(Process))
                {
                    return;
                }
            }

            // Visual part
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}

