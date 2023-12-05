using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryReposirory : ICategoryReposirory
    {
        private static PruductsDbContext _pruductsDbContext;
        public CategoryReposirory(PruductsDbContext pruductsDbContext)
        {
            _pruductsDbContext = pruductsDbContext;
        }

        public async Task<ICollection<Category>> getCategory()
        {
            return await _pruductsDbContext.Categories.ToListAsync();
        }
    }
}
