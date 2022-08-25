using CRUD.Models;
using System.Collections.Generic;

namespace CRUD.Repository

{
    public interface ICustomerRepository
    {
        Task<List<CustomerModel>> GetCustomers();
        Task<CustomerModel> GetCustomerById(int id);
        Task<CustomerModel> AddCustomer (CustomerModel customer); 
        Task<CustomerModel> UpdateCustomer (CustomerModel customer);
        Task<CustomerModel> DeleteCustomer (int id);
        Task<CustomerModel> Add(CustomerModel customer);
        Task<CustomerModel> Sync();
        Task<CustomerModel> SYNCDB();
        Task<CustomerModel> AddData(CustomerModel customer);

        /*        Task<Customer> Addition();
        */

    }
} 

