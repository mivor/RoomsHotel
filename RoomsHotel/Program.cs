using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Diagnostics;

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

            bool isRunning;

            Process app = Process.GetProcessesByName("Hotel").FirstOrDefault();

            isRunning = app != default(Process);

            string connectionString = @"Driver={{Microsoft Paradox Driver (*.db )}};DriverID=538;
                   Fil=Paradox 7.X;DefaultDir=C:\\DB;Dbq=C:\\DB;
                   CollatingSequence=ASCII;";

            OdbcConnection DbConnection = new OdbcConnection(connectionString);

            // Visual part
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
