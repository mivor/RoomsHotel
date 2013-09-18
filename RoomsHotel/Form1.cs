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

            String query = textBoxQuery.Text;
                //"SELECT * FROM REZLIN WHERE CodRez_ BETWEEN 5198 AND 51205";

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
