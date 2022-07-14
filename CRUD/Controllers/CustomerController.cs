using Microsoft.AspNetCore.Http;
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
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            return await _customerRepository.DeleteCustomer(id);
        }
    }
}
