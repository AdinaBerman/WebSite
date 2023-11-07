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
        private static PruductsDbContext _pruductsDbContext = new PruductsDbContext();

        public async Task<Category> addCategory(Category category)
        {
            await _pruductsDbContext.Categories.AddAsync(category);
            await _pruductsDbContext.SaveChangesAsync();
            return category;

        }

        public async Task<Category> updateCategory(int id, Category updateCategory)
        {
            _pruductsDbContext.Categories.Update(updateCategory);
            await _pruductsDbContext.SaveChangesAsync();
            return updateCategory;
        }

        public async Task<Category> getCategoryById(int id)
        {
            return await _pruductsDbContext.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();

        }
    }
}
