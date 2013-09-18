using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace RoomsHotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AppLocation = "C:\\mivor\\sources\\Gestbal Hotel";
            string DbLocation = "C:\\mivor\\projects\\vstudio\\RoomsHotel\\DbSample\\DAT";

            DateTime StartDate = new DateTime(2013, 08, 01);
            DateTime EndDate = new DateTime(2013, 09, 01);
            EndDate.AddDays(-1);

            String query = textBoxQuery.Text;
            if (query.Length == 0)
            {
                query = "SELECT CodRez_, DenClient_, CodCam_, Denum_, NrPat_, REZLIN.D1_, REZLIN.D2_, Adulti_, REZLIN.TipTarif_ "; 
                query += "FROM REZLIN, REZ, CAM WHERE (REZLIN.CodRez_ = REZ.Cod_) AND (REZLIN.CodCam_ = CAM.Cod_) ";
                query += "AND ((CodCam_ BETWEEN 61 AND 70) OR (CodCam_ BETWEEN 106 AND 115))";
                query += "AND (REZLIN.D1_ BETWEEN " + StartDate.ToOADate() + " AND " + EndDate.ToOADate() + ")";
            }

            string connectionString = "Driver={Microsoft Paradox Driver (*.db )};DriverID=538;Fil=Paradox 5.X;";
            connectionString += "DefaultDir=" + DbLocation + ";Dbq=" + DbLocation + ";CollatingSequence=ASCII;";

            using (OdbcConnection DbConnection = new OdbcConnection(connectionString))
            {
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

                using (OdbcCommand DbCommand = new OdbcCommand(query, DbConnection))
                {
                    try
                    {
                        using (OdbcDataReader DbReader = DbCommand.ExecuteReader())
                        {
                            int fCount = DbReader.FieldCount;
                            string fName = DbReader.GetName(4);
                            string output = fCount + ":" + fName;
                        }
                    }
                    catch (OdbcException ex)
                    {
                        Console.WriteLine("Executing the query '" + query + "' failed.");
                        Console.WriteLine("The OdbcCommand returned the following message");
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
            }
        }
    }
}
