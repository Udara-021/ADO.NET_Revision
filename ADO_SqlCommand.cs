using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Revision
{
    class ADO_SqlCommand
    {
         //constructors in detail.
//        SqlCommand();
//        SqlCommand(string cmdText);
//        SqlCommand(string cmdText, SqlConnection connection);
//        SqlCommand(string cmdText, SqlConnection connection, SqlTransaction transaction);

        public void GetData()
        {
            try
            {
                string ConString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    //1 Creating SqlCommand objcet   
                    SqlCommand cm = new SqlCommand("select * from student", connection);

                    //=========================
                    //2 Creating SqlCommand objcet 
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select * from student";
                    cmd.Connection = connection;


                    // Opening Connection  
                    connection.Open();

                    //=========================
                    //1 Executing the SQL query  
                    SqlDataReader sdr = cm.ExecuteReader();
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                    }

                    //=========================
                    //2 Since the return type of ExecuteScalar() is object, we are type casting to int datatype
                    int TotalRows = (int)cmd.ExecuteScalar();
                    Console.WriteLine("TotalRows in Student Table :  " + TotalRows);

                    //=========================
                    //3 Method Type 03
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted Rows = " + rowsAffected);
                    //Set to CommandText to the update query. We are reusing the command object, 
                    //instead of creating a new command object
                    cmd.CommandText = "update Student set Name = 'Ramesh Changed' where Id = 105";
                    rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated Rows = " + rowsAffected);
                    //Set to CommandText to the delete query. We are reusing the command object, 
                    //instead of creating a new command object
                    cmd.CommandText = "Delete from Student where Id = 105";

                    rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted Rows = " + rowsAffected);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
        }
    }
    
}
