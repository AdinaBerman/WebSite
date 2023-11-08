using Entities;

namespace Services
{
    public interface IProductServices
    {
        Task<ICollection<Product>> getProduct();
    }
}