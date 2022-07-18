/*using CRUD.Data;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Data;
using CRUD.Models;
using CRUD.Repository;

namespace CRUD.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DefaultContext _defaultContext;
        public CustomerRepository(DefaultContext defaultContext)
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
        public async Task<List<Customer>> GetCustomers()
        {
           *//* try
            {
            *//*    using (IDbConnection conn = connection)
                {
                    string Query = "CRUD_Customer";
                    conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "A");

                    var result = await conn.QueryAsync<Customer>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
           *//* }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*//*
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
           *//* try
            {*//*
                using (IDbConnection conn = connection)
                {
                    string sQuery = "CRUD_Customer";
                    conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "E");
                   // param.Add("@Customer_Id", customer.Customer_Id);
                    param.Add("@Customer_Name", customer.Customer_Name);
                    param.Add("@Customer_Address", customer.Customer_Address);
                    var result = await conn.QueryAsync<Customer>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();

                }
           *//* }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*//*

        }
            public async Task<Customer> UpdateCustomer(Customer customer)
            {
               *//* try
                {
                   *//* using (IDbConnection conn = connection)
                    {
                        string Query = "CRUD_Customer";
                        conn.Open();
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@ACTION", "U");
                        param.Add("@Customer_Id", customer.Customer_Id);
                        param.Add("@Customer_Name", customer.Customer_Name);
                        param.Add("@Customer_Address", customer.Customer_Address);
                        var result = await conn.QueryAsync<Customer>(Query, param, commandType: CommandType.StoredProcedure);
                        return result.FirstOrDefault();

                    }


                *//*}
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }*//*
            }
            public async Task<Customer> GetCustomerById(int id)
            {
               *//* try
                {*//*
                    using (IDbConnection conn = connection)
                    {
                        string Query = "CRUD_Customer";
                        conn.Open();
                        DynamicParameters param = new DynamicParameters();
                        param.Add("@ACTION", "G");
                        param.Add("@Customer_Id", id);
                        var result = await conn.QueryAsync<Customer>(Query, param, commandType: CommandType.StoredProcedure);
                        return result.FirstOrDefault();
                    }
               *//* }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }*//*
            
            }


        public async Task<Customer>DeleteCustomer(int id)
        {
           *//* try
            {*//*
                using (IDbConnection conn = connection)
                {
                    string Query = "CRUD_Customer";
                    conn.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@ACTION", "D");
                    param.Add("@Customer_Id", id);
                    var result = await conn.QueryAsync<Customer>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.FirstOrDefault();
                }
           *//* }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }*//*
        }
    }
}

*/



