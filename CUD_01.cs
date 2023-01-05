using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_Revision
{
    class CUD_01
    {
            public void CreateTable()
            {
                SqlConnection con = null;
                try
                {
                    // Creating Connection  
                    con = new SqlConnection("data source=.; database=ADO_db; integrated security=SSPI");

                // 01 -writing sql query  create table
                // SqlCommand cm = new SqlCommand("create table student(id int not null, name varchar(100), email varchar(50), join_date date)", con);

                // 02 -writing sql query to Insert 
                SqlCommand cm = new SqlCommand("insert into student (id, name, email, join_date) values ('101', 'Ronald Trump', 'ronald@example.com', '1/12/2017')", con);
                
                // 03 -writing sql query  to Delete
                // SqlCommand cm = new SqlCommand("delete from student where id = '101'", con);

                // Opening Connection  
                con.Open();
                    // Executing the SQL query  
                    cm.ExecuteNonQuery();
                    // Displaying a message  
                    Console.WriteLine("Action Run Successfully");
                }
                catch (Exception e)
                {
                    Console.WriteLine("OOPs, something went wrong." + e);
                }
                // Closing the connection  
                finally
                {
                    con.Close();
                }
            }

    }
    }

