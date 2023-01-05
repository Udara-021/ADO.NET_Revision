using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Revision
{
    class ADO_DataReader_NextResult
    {
            public void NextResultDTR()
            {
                try
                {
                    string ConString = @"data source=.; database=ADO_db; integrated security=SSPI";
                    using (SqlConnection connection = new SqlConnection(ConString))
                    {
                        // Creating the command object
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Customers; SELECT * FROM Orders", connection);

                        // Opening Connection  
                        connection.Open();

                        // Executing the SQL query  
                        SqlDataReader reader = cmd.ExecuteReader();

                        //Looping through First Result Set
                        Console.WriteLine("First Result Set:");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0] + ",  " + reader[1] + ",  " + reader[2]);
                        }

                        //To retrieve the second result set from SqlDataReader object, use the NextResult(). 
                        //The NextResult() method returns true and advances to the next result-set.
                        while (reader.NextResult())
                        {
                            Console.WriteLine("\nSecond Result Set:");
                            //Looping through each record
                            while (reader.Read())
                            {
                                Console.WriteLine(reader[0] + ",  " + reader[1] + ",  " + reader[2]);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception Occurred: {ex.Message}");
                }
            }
        }
    }


