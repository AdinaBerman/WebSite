using Entities;

namespace Services
{
    public interface IProductServices
    {
        Task<ICollection<Product>> getProductAsync(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}