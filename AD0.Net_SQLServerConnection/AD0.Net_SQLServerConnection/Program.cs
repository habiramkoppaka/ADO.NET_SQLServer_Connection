using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD0.Net_SQLServerConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            //"Data Source=RAM;Initial Catalog=RestaturantSignup;Integrated Security=SSPI;" User Id=sa Password=Venkata.66,
            //"Integrated Security=SSPI;Initial Catalog=Employee;Data Source=(local);"
            string ConnectionString = "Integrated Security=SSPI;Initial Catalog=Employee;Data Source=(local);";

            // Provide the query string with a parameter placeholder.
            string queryString = "SELECT TOP 2 [Employeeid],[EmployeeName],[Age] FROM [Employee].[dbo].[EmployeeDetails];";

            // Create and open the connection in a using block. This
            // ensures that all resources will be closed and disposed
            // when the code exits.
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            { //intial
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection in a try/catch block.
                // Create and execute the DataReader, writing the result
                // set to the console window.
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}",
                            reader[0], reader[1], reader[2]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
