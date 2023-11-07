using Entities;

namespace Services
{
    public interface ICatogoryServices
    {
        Task<Category> addCategory(Category category);
        Task<Category> getCategoryById(int id);
        Task<Category> updateCategory(int id, Category category);
    }
}