/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD.Controllers;
using CRUD.Repository;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{id}")]
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _customerRepository.GetCustomerById(id);
        }
        [HttpGet]
        public async Task<List<Customer>> GetCustomers()
        {
            return await _customerRepository.GetCustomers();

        }
        [HttpPost]
        public async Task<ActionResult<Customer>> AddCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Invalid State");

            }
            return await _customerRepository.AddCustomer(customer);
        }
        [HttpPut]
        public async Task<ActionResult<Customer>> UpdateCustomer([FromBody] Customer customer)
        {
            if (customer ==null)
            {
                return BadRequest("Invalid State");
            }
            return await _customerRepository.UpdateCustomer(customer);
        }
        [HttpDelete]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            return await _customerRepository.DeleteCustomer(id);
        }
    }
}
*/


using CRUD.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CRUD.Models;
namespace CRUD.Controllers
{
    public class CustomerController
    {
        private readonly DefaultContext _defaultContext;

        public CustomerController(DefaultContext defaultContext)
        {
            _defaultContext = defaultContext;
        }

        [HttpPost]
        [Route("api/SaveCustomer")]
        public Object AddCustomer([FromQuery] Customer customer)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Execute(@"Insert into Customers (Customer_Id, Customer_Name, Customer_Address) Values(@Id, @Name, @Address)", new {Id = customer.Customer_Id, Name = customer.Customer_Name, Address= customer.Customer_Address });

/*                a = conn.Query("Select * from Customers");
*/
            }
            return a;
        }


        [HttpGet]
        [Route("Api/GetCustomer")]
        public Object GetCustomer()
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                /*a = conn.Query("Select Customer_Id from Customers where Customer_Id=@Id", new {Customer_Id = id});*/
                // a = conn.Query("Select * from Customers");
                a = conn.Query("Select Customers.Customer_Id, Customers.Customer_Name,Customers.Customer_Address,OrderLists.Order_Name From Customers Left Join OrderLists On Customers.Customer_Id = OrderLists.Order_Id Order By Customers.Customer_Name");
            }
            return a;
        }

        /* [HttpPut]
         [Route("{id}/{newName}/{newAddress}")]
         public Object UpdateCustomer(int id, string newName, string newAddress)
         {
             object a = " ";
             string Connection = _defaultContext.DbCon();
             using (SqlConnection conn = new SqlConnection(Connection))
             {
                 a = conn.Query(@"update Customers set Customer_Name = @newName, Customer_Address = @newAddress where Customer_Id = @id", new { NewName = newName, NewAddress = newAddress, Id = id });
             }
             return a;
         }*/
        [HttpPut]
        [Route("api/EditCustomer")]
        public Object UpdateCustomer([FromQuery] Customer customer)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                conn.Open();
                a = conn.Query(@"Update Customers Set Customer_Name = @newName, Customer_Address = @newAddress where Customer_Id = @id", new { newName = customer.Customer_Name, newAddress = customer.Customer_Address, id = customer.Customer_Id });
                conn.Close();
            }
            return a;

        }

        [HttpDelete]
        [Route("{id}")]
        public Object DeleteCustomer(int id)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query(@"Delete from Customers where Customer_Id= @id", new {Id = id});
            }
            return a;
        }
    }
}