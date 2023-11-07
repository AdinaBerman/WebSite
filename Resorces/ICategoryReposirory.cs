using Entities;

namespace Repositories
{
    public interface ICategoryReposirory
    {
        Task<Category> addCategory(Category category);
        Task<Category> getCategoryById(int id);
        Task<Category> updateCategory(int id, Category updateCategory);
    }
}