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

            using ( Process app = Process.GetProcessesByName("Hotel").FirstOrDefault() )
            {
                isRunning = app != default(Process);
            }

            string AppLocation = "C:\\mivor\\sources\\Gestbal Hotel";
            string DbLocation = "C:\\mivor\\projects\\vstudio\\RoomsHotel\\DbSample\\DAT";

            string connectionString = "Driver={Microsoft Paradox Driver (*.db )};DriverID=538;Fil=Paradox 5.X;";
            connectionString += "DefaultDir=" + DbLocation + ";Dbq=" + DbLocation + ";CollatingSequence=ASCII;";

            OdbcConnection DbConnection = new OdbcConnection(connectionString);

            try
            {
                DbConnection.Open();
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("connection to the Database failed.");
                Console.WriteLine("The OdbcConnection returned the following message");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                return;
            }
            
            String query = "SELECT * FROM REZ WHERE DenClient_ = 'BARTA TUNDE'";

            OdbcCommand DbCommand = new OdbcCommand(query, DbConnection);

            DbCommand.CommandText = query;

            try
            {
                OdbcDataReader DbReader = DbCommand.ExecuteReader();
                int fCount = DbReader.FieldCount;
                string fName = DbReader.GetName(4);

                string output = fCount + ":" + fName;

                DbReader.Close();
            }
            catch (OdbcException ex)
            {
                Console.WriteLine("Executing the query '" + query + "' failed.");
                Console.WriteLine("The OdbcCommand returned the following message");
                Console.WriteLine(ex.Message);
                return;
            }
            
            DbCommand.Dispose();
            DbConnection.Close();

            // Visual part
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}

