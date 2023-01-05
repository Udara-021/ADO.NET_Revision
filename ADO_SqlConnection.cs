using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Revision
{
    class ADO__SqlConnection
    {
        //3 type constructors
        //SqlConnection();
        //SqlConnection(String connectionString);
        //SqlConnection(String connectionString, SqlCredential credential);

        public void Connecting()
        {
            try
            {
                // create a Connection Object 
                string ConnectionString = "data source=.; database=student; integrated security=SSPI";

                //store the connection string in the configuration file & call
                string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    connection.Open();
                    Console.WriteLine("Connection Established Successfully");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }
        //Note: Here, we are using the using block to close the connection automatically.
        //If you are using the using block then you don’t require to call the close() method explicitly to close the connection.
        //It is always recommended to close the database connection using the using block in C#.

        //If you don’t use the using block to create the connection object, 
        //then you have to close the connection explicitly by calling the Close method on the connection object. In the following example,
        //we are using try-block instead of using block and calling the Close method in finally block to close the database connection.
    }
}
