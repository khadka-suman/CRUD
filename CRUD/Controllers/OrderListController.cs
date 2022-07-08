/*using CRUD.Data;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListController : ControllerBase
    {
        // private readonly IConfiguration _configuration;
        private readonly DefaultContext _defaultContext;
        public OrderListController(*//*IConfiguration configuration,*//* DefaultContext defaultContext)
        {
            //  _configuration = configuration;
            _defaultContext = defaultContext;
        }

        [HttpPost]
        [Route("/OrderList/{Name}")]
        public object OrderName(string Name, string Address)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query("select * from tblOrderList");

            }
            return a;
        }

        [HttpGet]
        [Route("/GetOrderList/{Id}")]
        public object GetOrderName()
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query("Select * from tblOrderList");
            }
            return a;
        }

        [HttpPut]
        [Route("/UpdateOrderList/{Id}/{newName}")]
        public object UpdateOrderList(int Id, String newName)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query(@"update tblOrderList set OrderListName = @NewName where ID = @id",
                new { NewName = newName, id = Id });
            }
            return a;
        }


        [HttpDelete]
        [Route("/DeleteCustomer/{Id}")]
        public object DeleteOrderList(int Id)
        {
            object a = " ";
            string Connection = _defaultContext.DbCon();
            using (SqlConnection conn = new SqlConnection(Connection))
            {
                a = conn.Query("select * from tblOrderList");
            }
            return a;

        }
    }
}
*/