using System.Data.SqlClient;
using System;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Data
{
    public class DefaultContext
    {
        public string DbCon()
        {
            string txtpath = @"C:\Users\97798\source\repos\CRUD\CRUD\DbConnection.txt";
            try
            {
                if (File.Exists(txtpath))
                {
                    using StreamReader sr = new(txtpath);
                    txtpath = sr.ReadToEnd();
/*                    string ss = sr.ReadToEnd();
                    string[] txtsplit = ss.Split(';');
                    string Server = txtsplit[0].ToString();
                    string Database = txtsplit[1].ToString();
                    string Trusted_Connection = txtsplit[2].ToString();*/


                    
                    //yaa join garnu parna
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return txtpath;
             
        }


        /*  static void Main(string[] args)
          {
              try
              {
                  SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                  builder.DataSource = "<SUMAN>";
                  builder.InitialCatalog = "<CRUDEX>";

                  using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                  {

                      connection.Open();

                      String sql = "SELECT name, collation_name FROM sys.databases";

                      using (SqlCommand command = new SqlCommand(sql, connection))
                      {
                          using (SqlDataReader reader = command.ExecuteReader())
                          {
                              while (reader.Read())
                              {
                                  Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                              }
                          }
                      }
                  }
              }
              catch (SqlException e)
              {
                  Console.WriteLine(e.ToString());
              }
              Console.WriteLine("\nDone. Press enter.");
              Console.ReadLine();
          }

      }*/
    }
}





