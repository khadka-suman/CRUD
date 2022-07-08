using CRUD.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace CRUD.Controllers
{
    
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DefaultContext _defaultContext;
        private readonly ILogger _logger;
       // private readonly DbConnection _dbConnection;
        public CustomerController(IConfiguration configuration, DefaultContext defaultContext /*DbConnection dbConnection*/, ILogger logger)
        {
            _configuration = configuration;
            _defaultContext = defaultContext;
            _logger = logger;
            // _dbConnection = dbConnection;
        }

        [HttpGet]
        [Route("/Customer")]
        public object CustomerName(string Name)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = "connection sucessful";

            }
            return a;
        }


        [HttpPost]
        [Route("/Customer/{Name}")]
        public object CustomerName(string Name, string Address)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query("select * from tblCustomer");

            }
            return a;
        }

        [HttpGet]
        [Route("/GetCustomer/{Id}")]
        public object GetCustomerName()
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query("Select * from tblCustomer");
            }
            return a;
        }

        [HttpPut]
        [Route("/Updatecustomer/{Id}/{newName}/{newAddress}")]
        public object UpdateCustomer(int Id, String newName, string newAddress)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using(SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query(@"update tblCustomer set CustomerName = @NewName, CustomerAddress = @NewAddress where ID = @id",
                new { NewName = newName,NewAddress= newAddress, id = Id});
            }
            return a;
        }


        [HttpDelete]
        [Route("/DeleteCustomer/{Id}")]
        public object DeleteCustomer(int Id)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query("select * from tblCustomer");
                    }
            return a;

        }




       /* [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
