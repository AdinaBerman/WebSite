using Entities;

namespace Repositories
{
    public interface IProductRepository
    {
        //public Task<ICollection<Product>> getProducts();

        public Task<ICollection<Product>> getProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);

        public Task<Product> getProductById(int id);

    }
}