using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        public Task<ICollection<Product>> GetProducts();
    }
}