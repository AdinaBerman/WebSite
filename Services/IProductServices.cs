using Entities;

namespace Services
{
    public interface IProductServices
    {
        Task<Product> addProduct(Product product);
        Task<Product> getProductById(int id);
        Task<Product> updateProduct(int id, Product product);
    }
}