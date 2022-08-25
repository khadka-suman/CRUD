using CRUD.Data;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Data;
using CRUD.Models;
using CRUD.Repository;
using static CRUD.Data.DefaultContext;

namespace CRUD.Repository
{
    public class _customerRepository : ICustomerRepository
    {
        private readonly DefaultContext _defaultContext;
        private readonly IConfiguration _configuration;
        public _customerRepository(DefaultContext defaultContext, IConfiguration configuration)
        {
            _defaultContext = defaultContext;
            _configuration = configuration;
        }
        public IDbConnection connection
        {
            get
            {
                return new SqlConnection(_defaultContext.DbCon());
            }
        }
        public async Task<List<CustomerModel>> GetCustomers()
        {/*
            try
            {*/
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_Customer";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "A");

                var result = await conn.QueryAsync<CustomerModel>(Query, param, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
        public async Task<CustomerModel> AddCustomer(CustomerModel customer)
        {
            /* try
             {*/
            using (IDbConnection conn = connection)
            {
                string sQuery = "CRUD_Customer";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "E");
                param.Add("@Customer_Id", customer.Customer_Id);
                param.Add("@Customer_Name", customer.Customer_Name);
                param.Add("@Customer_Address", customer.Customer_Address);
                var result = await conn.QueryAsync<CustomerModel>(sQuery, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }


            /* }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/

        }
        public async Task<CustomerModel> UpdateCustomer(CustomerModel customer)
        {
            /* try
             {*/
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_Customer";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "U");
                param.Add("@Customer_Id", customer.Customer_Id);
                param.Add("@Customer_Name", customer.Customer_Name);
                param.Add("@Customer_Address", customer.Customer_Address);
                var result = await conn.QueryAsync<CustomerModel>(Query, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }


            /* }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/
        }
        public async Task<CustomerModel> GetCustomerById(int id)
        {
            /* try
             {*/
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_Customer";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "G");
                param.Add("@Customer_Id", id);
                var result = await conn.QueryAsync<CustomerModel>(Query, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            /* }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }
 */
        }


        public async Task<CustomerModel> DeleteCustomer(int id)
        {
            /*try
            {*/
            using (IDbConnection conn = connection)
            {
                string Query = "CRUD_Customer";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "D");
                param.Add("@Customer_Id", id);
                var result = await conn.QueryAsync<CustomerModel>(Query, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
            /* }
             catch (Exception ex)
             {
                 Console.WriteLine(ex);
             }*/
        }

        public async Task<CustomerModel> Add(CustomerModel customer)
        {
            using (IDbConnection conn = connection)
            {
                string sQuery = "CRUD_UpdateCustomer";
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "E");
                param.Add("@Customer_Id", customer.Customer_Id);
                param.Add("@Customer_Name", customer.Customer_Name);
                param.Add("@Customer_Address", customer.Customer_Address);
                var result = await conn.QueryAsync<CustomerModel>(sQuery, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();

            }
            /*  using (IDbConnection conn = connection)
              {
                  string qry = conn.Query(@"INSERT INTO UpdateCustomers( Customer_Id, Customer_Name, Customer_Address)VALUES( @Customer_Id, @Customer_Name, @Customer_Address", new { Customer_Id = customer.Customer_Id, Customer_Name = customer.Customer_Name, Customer_Address = customer.Customer_Address });
                  var res = await conn.QueryAsync<CustomerModel>(qry);
                  return res.FirstOrDefault();
              }*/
        }
        public async Task<CustomerModel> Sync()
        {

            using (IDbConnection conn = connection)
            {
               /* try
                {*/
                    string Query = @"MERGE UpdateCustomer AS TARGET USING Customers AS SOURCE ON (TARGET.Customer_Id = SOURCE.Customer_Id) 
                                    WHEN MATCHED AND TARGET.CUstomer_Name<> SOURCE.Customer_Name OR TARGET.Customer_Address<> SOURCE.Customer_Address 
                    THEN UPDATE SET TARGET.Customer_Name = SOURCE.Customer_Name, TARGET.Customer_Address = SOURCE.Customer_Address
                     WHEN NOT MATCHED BY TARGET THEN INSERT(Customer_Id, Customer_Name, Customer_Address)
                    VALUES(SOURCE.Customer_Id, SOURCE.Customer_Name, SOURCE.Customer_Address)
                    WHEN NOT MATCHED BY SOURCE THEN DELETE OUTPUT $action,
                     DELETED.Customer_Id AS TargetCustomer_Id, DELETED.Customer_Name AS TargetCustomer_Name,
                     DELETED.Customer_Address AS TargetCustomer_Address, INSERTED.Customer_ID AS SourceCustomer_Id,
                    INSERTED.Customer_Name AS SourceCustomer_Name, INSERTED.Customer_Address AS Customer_Address; SELECT @@ROWCOUNT;";
                    var res = await conn.QueryAsync<CustomerModel>(Query);
                return res.FirstOrDefault();
                /* catch (Exception ex)
                 {
                     Console.WriteLine(ex);
                 }*/


            }

        }
        public async Task<CustomerModel> SYNCDB()
        {
            /*using (IDbConnection conn = connection)
            {
                string Query = @"Select * from Customers";
                var res = conn.Execute(Query);
                    }
            string constr = _configuration.GetConnectionString("DefaultcontextConn");
                using (SqlConnection conn = new SqlConnection(constr))
            {
                string Query = @"MERGE Customers AS TARGET USING UpdateCustomer AS SOURCE ON (TARGET.Customer_Id = SOURCE.Customer_Id) Insert into DATA_B.dbo.CustomerB (Customer_Id, CUstomer_Name, Customer_Address) select * from CRUDEX.dbo.Customers";
             WHEN MATCHED AND TARGET.CUstomer_Name<> SOURCE.Customer_Name OR TARGET.Customer_Address<> SOURCE.Customer_Address 
                    THEN UPDATE SET TARGET.Customer_Name = SOURCE.Customer_Name, TARGET.Customer_Address = SOURCE.Customer_Address
            WHEN NOT MATCHED BY SOURCE THEN DELETE OUTPUT
             DELETED.Customer_Id AS TargetCustomer_Id, DELETED.Customer_Name AS TargetCustomer_Name,
                     DELETED.Customer_Address AS TargetCustomer_Address,

             $action,
                     INSERTED.Customer_ID AS SourceCustomer_Id,
                    INSERTED.Customer_Name AS SourceCustomer_Name, INSERTED.Customer_Address AS Customer_Address; SELECT @@ROWCOUNT;
        }*/
            using (IDbConnection conn = connection)
            {
                /* try
                 {*/
                string Query = @"MERGE DATA_B.dbo.CustomerB AS TARGET USING CRUDEX.dbo.Customers AS SOURCE ON (TARGET.Customer_Id = SOURCE.Customer_Id) 
                                  
                     WHEN NOT MATCHED BY TARGET THEN INSERT(Customer_Id, Customer_Name, Customer_Address, timeStamp)
                    VALUES(SOURCE.Customer_Id, SOURCE.Customer_Name, SOURCE.Customer_Address, SOURCE.timeStamp);";
                var res = await conn.QueryAsync<CustomerModel>(Query);
                return res.FirstOrDefault();
                
                /* catch (Exception ex)
                 {
                     Console.WriteLine(ex);
                 }*/


            }

        }

      
         
        public async Task<CustomerModel> AddData(CustomerModel customer)
        {
            string connstr = _configuration.GetConnectionString("DefaultContextConn");
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                string sQuery = "CRUD_DATA";
                DynamicParameters param = new DynamicParameters();
                param.Add("@ACTION", "E");
                param.Add("@Customer_Id", customer.Customer_Id);
                param.Add("@Customer_Name", customer.Customer_Name);
                param.Add("@Customer_Address", customer.Customer_Address);
                var result = await conn.QueryAsync<CustomerModel>(sQuery, param, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();


            }

        }
    }
}






