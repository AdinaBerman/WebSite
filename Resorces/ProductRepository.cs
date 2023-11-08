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

        public async Task<ICollection<Product>> GetProducts()
        {
            return await _pruductsDbContext.Products.
        }

    }
}
