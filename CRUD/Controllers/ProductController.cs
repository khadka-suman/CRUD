/*using CRUD.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        // private readonly IConfiguration _configuration;
        private readonly DefaultContext _defaultContext;
        private ProductController(*//*IConfiguration configuration,*//* DefaultContext defaultContext)
        {
            //  _configuration = configuration;
            _defaultContext = defaultContext;
        }

        [HttpPost]
        [Route("/Product/{Name}")]
        public object ProductName(string Name)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new(Connection))
            {
                a = conn.Query("select * from tblProduct");

            }
            return a;
        }

        [HttpGet]
        [Route("/GetProduct/{Id}")]
        public object GetProductName()
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new(Connection))
            {
                a = conn.Query("Select * from tblProduct");
            }
            return a;
        }

        [HttpPut]
        [Route("/Updatecustomer/{Id}/{newName}/{newAddress}")]
        public object UpdateProduct(int Id, String newName, string newAddress)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new(Connection))
            {
                a = conn.Query(@"update tblProduct set CustomerName = @NewName, CustomerAddress = @NewAddress where ID = @id",
                new { NewName = newName, NewAddress = newAddress, id = Id });
            }
            return a;
        }


        [HttpDelete]
        [Route("/DeleteProduct/{Id}")]
        public object DeleteProduct(int Id)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new(Connection))
            {
                a = conn.Query("select * from tblProduct");
            }
            return a;

        }
    }
}
*/