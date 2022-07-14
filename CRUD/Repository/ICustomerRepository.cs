using CRUD.Models;

namespace CRUD.Repository

{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> AddCustomer (Customer customer); 
        Task<Customer> UpdateCustomer (Customer customer);
        Task<Customer> DeleteCustomer (int id);

    }
}

