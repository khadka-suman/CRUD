using CRUD.Data;
using CRUD.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CRUD.Repository
{
    public class OrderListRepository : IOrderListRepository

    {

        private readonly DefaultContext _defaultContext;
        public OrderListRepository(DefaultContext defaultContext)
        {
            _defaultContext = defaultContext;
        }
        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(_defaultContext.DbCon());
            }
        }
        public async Task<List<OrderList>> GetOrders()
        {
            /* try
             {
             */
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_OrderList";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "A");

                var result = await conn.QueryAsync<OrderList>(Query, param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            /* }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/
        }
        public async Task<OrderList> AddOrders(OrderList orderList)
        {
            /* try
             {*/
            using (IDbConnection conn = connection)
            {
                string sQuery = "CRUD_OrderList";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "E");
                param.Add("@Order_Name", orderList.Order_Name);
                var result = await conn.QueryAsync<OrderList>(sQuery, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }
            /* }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/

        }
        public async Task<OrderList> UpdateOrder(OrderList orderList)
        {
            /* try
             {
                */
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_OrderList";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "U");
                param.Add("@Order_Id", orderList.Order_Id);
                param.Add("@Order_Name", orderList.Order_Name);
                var result = await conn.QueryAsync<OrderList>(Query, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }


            /*}
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/
        }
     

        public async Task<OrderList> DeleteOrder(int id)
        {
            /* try
             {*/
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_OrderList";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "D");
                param.Add("@Order_Id", id);
                var result = await conn.QueryAsync<OrderList>(Query, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            /* }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/
        }
    }
}
