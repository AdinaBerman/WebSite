using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CatogoryServices : ICatogoryServices
    {
        private readonly ICategoryRepository _repository;

        public CatogoryServices(ICategoryRepository categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<Category> addCategory(Category category)
        {
            return await _repository.addCategory(category);
        }

        public async Task<Category> updateCategory(int id, Category category)
        {
            return await _repository.updateCategory(id, category);
        }

        public async Task<Category> getCategoryById(int id)
        {
            return await _repository.getCategoryById(id);
        }
    }
}
