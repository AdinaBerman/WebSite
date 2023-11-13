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
        private static PruductsDbContext _pruductsDbContext = new PruductsDbContext();

        public async Task<ICollection<Product>> getProducts(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            var query = _pruductsDbContext.Products.Where(product =>
            (desc == null ? (true) : (product.ProdName.Contains(desc)))
            && ((minPrice == null) ? (true) : (product.ProdPrice >= minPrice))
            && ((maxPrice == null) ? (true) : (product.ProdPrice <= maxPrice))
            && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId))))
                .OrderBy(product => product.ProdPrice);

            Console.WriteLine(query.ToQueryString());
            List<Product> products = await query.ToListAsync();
            return products;
        }

    }
}
