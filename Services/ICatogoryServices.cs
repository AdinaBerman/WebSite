using Entities;

namespace Services
{
    public interface ICatogoryServices
    {
        Task<ICollection<Category>> getCategory();
    }
}