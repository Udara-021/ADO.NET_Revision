using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Revision
{
    class ADO_SqlDataReader
    {
            //        used to read data from the SQL Server database in the most efficient manner.It reads data in the forward-only direction.
            //        It means, once it read a record, it will then read the next record, there is no way to go back and read the previous record.

            //The SqlDataReader is connection-oriented.It means it requires an open or active connection to the data source while reading the data.
            //The data is available as long as the connection with the database exists

            //SqlDataReader is read-only.It means it is also not possible to change the data using SqlDataReader.
            //You also need to open and close the connection explicitly.

        public void DataRead()
        {
            try
            {
                string ConString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    // Creating the command object
                    SqlCommand cmd = new SqlCommand("select Name, Email, Mobile from student", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Looping through each record
                    while (sdr.Read())
                    {
                        //Using the string key names,
                        Console.WriteLine(sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                        //Using the index number
                        Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }
    }
}
