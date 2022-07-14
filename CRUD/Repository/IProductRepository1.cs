using CRUD.Models;

namespace CRUD.Repository
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<Product> DeleteProduct(int id);
        Task<List<Product>> GetProducts();
        Task<Product> UpdateProduct(Product product);
    }
}