using CRUD.Models;
using CRUD.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
         private readonly IProductRepository2 _productRepository;
        public ProductController(IProductRepository2 productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<List<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();

        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid State");

            }
            return await _productRepository.AddProduct(product);
        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            if (product ==null)
            {
                return BadRequest("Invalid State");
            }
            return await _productRepository.UpdateProduct(product);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}
