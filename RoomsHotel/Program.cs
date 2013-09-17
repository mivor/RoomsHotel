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

            bool isRunning;

            Process app = Process.GetProcessesByName("Hotel").FirstOrDefault();

            isRunning = app != default(Process);

            string AppLocation = "C:\\mivor\\sources\\Gestbal Hotel";
            string DbLocation = "C:\\mivor\\projects\\vstudio\\RoomsHotel\\DbSample\\DAT";

            string connectionString = "Driver={Microsoft Paradox Driver (*.db )};DriverID=538;Fil=Paradox 5.X;";
            connectionString += "DefaultDir=" + DbLocation + ";Dbq=" + DbLocation + ";CollatingSequence=ASCII;";

            OdbcConnection DbConnection = new OdbcConnection(connectionString);

            DbConnection.Open();

            OdbcCommand DbCommand = DbConnection.CreateCommand();

            DbCommand.CommandText = "SELECT * FROM REZ";

            OdbcDataReader DbReader = DbCommand.ExecuteReader();

            int fCount = DbReader.FieldCount;
            string fName = DbReader.GetName(4);

            string output = fCount + ":" + fName;

            // Visual part
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}

