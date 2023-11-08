using Entities;

namespace Repositories
{
    public interface ICategoryReposirory
    {
        Task<ICollection<Category>> getCategory();
    }
}