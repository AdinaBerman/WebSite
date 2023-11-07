using Entities;

namespace Repositories
{
    public interface ICategoryRepository
    {
        Task<Product> addProduct(Product prod);
        Task<Product> getProductById(int id);
        Task<Product> updateProduct(int id, Product updateProd);
    }
}