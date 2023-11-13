using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _repository;

        public ProductServices(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<ICollection<Product>> getProduct(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _repository.getProducts( position, skip, desc, minPrice, maxPrice ,categoryIds);
        }

    }
}
