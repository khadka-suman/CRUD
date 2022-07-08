using System;
using System.Data;
using System.Data.SqlClient;
namespace CRUD.Data
{
    public class DbConnection
    {
        public string DbCon()
        {
            string connectionString = "Server = SUMAN; Database = CRUDEX; Trusted_Connection = True";
            string queryString = "Select CustomerId, CustomerName, CustomerAddress";
            int paramvalue = 5;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@CustomerId", paramvalue);
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

            return connectionString;

        }
    }
}
