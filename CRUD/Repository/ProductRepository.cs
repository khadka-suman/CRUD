using CRUD.Data;
using CRUD.Models;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CRUD.Repository
{
    public class ProductRepository : IProductRepository2
    {
        private readonly DefaultContext _defaultContext;
        public ProductRepository(DefaultContext defaultContext)
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

        public async Task<List<Product>> GetProducts()
        {
            /* try
             {
             */
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_Product";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "A");

                var result = await conn.QueryAsync<Product>(Query, param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
            /* }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/
        }
        public async Task<Product> AddProduct(Product product)
        {
            /* try
             {*/
            using (IDbConnection conn = connection)
            {
                string sQuery = "CRUD_Product";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "E");
                param.Add("@Product_Name", product.Product_Name);
                var result = await conn.QueryAsync<Product>(sQuery, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }
            /* }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/

        }
        public async Task<Product> UpdateProduct(Product product)
        {
            /* try
             {
                */
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_Product";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "U");
                param.Add("@Product_Id", product.Product_Id);
                param.Add("Product_Name", product.Product_Name);
                var result = await conn.QueryAsync<Product>(Query, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }


            /*}
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*/
        }

        public async Task<Product> DeleteProduct(int id)
        {
            /* try
             {*/
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_Product";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "D");
                param.Add("@Product_Id", id);
                var result = await conn.QueryAsync<Product>(Query, param, commandType: CommandType.StoredProcedure);
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




