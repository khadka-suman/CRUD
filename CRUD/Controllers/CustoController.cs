/*using CRUD.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CRUD.Models;
using System.Linq;
using System.Data;

namespace CRUD.Controllers
{
    
    public class CustomerController : ControllerBase
    {
        private readonly DefaultContext _defaultContext;

        public CustomerController(DefaultContext defaultContext)
        {
            _defaultContext = defaultContext;
        }

        [HttpGet]
        [Route("/Customer")]
        public IActionResult CustomerName(string Name)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                 a = "Connection Successful";
                 
            }
            return Ok(a);
        }


        [HttpPost]
        [Route("api/Customer")]
        public IActionResult AddCustomer(string Customer_Name, string Customer_Address)
        {
           Customer customer = new Customer(); 
            string Connection = _defaultContext.DbCon();
           
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                try
                {
                    if (conn != null)
                    {
                       // conn.Open();
                        SqlCommand cmd = new SqlCommand("sp_Customer_Add", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Customer_Name", Customer_Name);
                        cmd.Parameters.AddWithValue("@Customer_Address", Customer_Address);




*//*                        SqlCommand Insert = new SqlCommand("INSERT INTO Customers (Customer_Name, Customer_Address) VALUES(@Customer_Name, @Customer_Address");
*//*                        //Insert.Parameters.Add("@Customer_Id)", System.Data.SqlDbType.Int, 20).Value = Customer_Id;
                       // Insert.Parameters.Add("@Customer_Name", System.Data.SqlDbType.NVarChar, 20).Value = Customer_Name;
                        //Insert.Parameters.Add("@Customer_Address", System.Data.SqlDbType.NVarChar, 20).Value = Customer_Address;
                        // Insert.ExecuteNonQuery();


                      *//*  Insert.Parameters.AddWithValue("@Customer_Name", Customer_Name);
                        Insert.Parameters.AddWithValue("@Customer_Address", Customer_Address); *//*                      
                        _defaultContext.Add(customer);
                       // _defaultContext.SaveChanges();
                        conn.Close();

                        //Insert.(customer);
                        // a= conn.Query(@"INSERT INTO Customer ( Customer_Name, Customer_Address) VALUES(@Customer_Name, @Customer_Address");
                        //a = conn.Query(@"SELECT * FROM Customer");
                        //cmd = new SqlCommand(a);
                        //cmd.Parameters.Add("@Customer_Name", "abc");
                        // cmd.Parameters.AddWithValue(Connection, Customer_Name);
                        //cmd.Parameters.AddWithValue(Connection, Customer_Address);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return Ok();
        }

        [HttpGet]
        [Route("/GetCustomer/{Customer_Id}")]
        public IActionResult GetCustomerName()
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query("Select * from Customer");
            }
            return Ok(a);
        }

        [HttpPut]
        [Route("/Updatecustomer/{Customer_Id}/{newName}/{newAddress}")]
        public IActionResult UpdateCustomer(int Customer_Id, string newName, string newAddress)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using(SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query(@"update Customer set Customer_Name = @NewName, Customer_Address = @NewAddress where Customer_ID = @id",
                new { NewName = newName,NewAddress= newAddress, id = Customer_Id});
            }
            return Ok(a);
        }


        [HttpDelete]
        [Route("/DeleteCustomer/{Customer_Id}")]
        public IActionResult DeleteCustomer(int Customer_Id)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query("select * from Customer");
            }
            return Ok(a);

        }
    }
}
*/