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
        private readonly ICategoryRepository _repository;

        public ProductServices(ICategoryRepository productRepository)
        {
            _repository = productRepository;
        }

        public async Task<Product> addProduct(Product product)
        {
            return await _repository.addProduct(product);
        }

        public async Task<Product> updateProduct(int id, Product product)
        {
            return await _repository.updateProduct(id, product);
        }

        public async Task<Product> getProductById(int id)
        {
            return await _repository.getProductById(id);
        }
    }
}
