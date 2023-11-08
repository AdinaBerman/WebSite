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
        private readonly ICategoryReposirory _repository;

        public CatogoryServices(ICategoryReposirory categoryRepository)
        {
            _repository = categoryRepository;
        }

        public async Task<ICollection<Category>> getCategory()
        {
            return await _repository.getCategory();
        }
    }
}
