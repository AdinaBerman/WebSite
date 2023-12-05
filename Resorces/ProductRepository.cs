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
    public class ProductRepository : IProductRepository
    {
        private static PruductsDbContext _pruductsDbContext;
        public ProductRepository(PruductsDbContext pruductsDbContext)
        {
            _pruductsDbContext = pruductsDbContext;
        }

        public async Task<ICollection<Product>> getProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _pruductsDbContext.Products.Where(product =>
            (desc == null ? (true) : (product.ProdName.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.ProdPrice >= minPrice))
            && ((maxPrice == null) ? (true) : (product.ProdPrice <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .Include(i => i.Category)
                .OrderBy(product => product.ProdPrice);

            List<Product> products = await query.ToListAsync();
            return products;
        }

        public async Task<Product> getProductById(int id)
        {
            return await _pruductsDbContext.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
        }

    }
}
