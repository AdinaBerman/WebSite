using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : ICategoryRepository
    {
        private static PruductsDbContext _pruductsDbContext = new PruductsDbContext();

        public async Task<Product> addProduct(Product prod)
        {
            await _pruductsDbContext.Products.AddAsync(prod);
            await _pruductsDbContext.SaveChangesAsync();
            return prod;

        }

        public async Task<Product> updateProduct(int id, Product updateProd)
        {
            _pruductsDbContext.Products.Update(updateProd);
            await _pruductsDbContext.SaveChangesAsync();
            return updateProd;
        }

        public async Task<Product> getProductById(int id)
        {
            return await _pruductsDbContext.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();

        }

    }
}
