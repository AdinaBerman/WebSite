using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICatogoryServices _categoryService;
        IMapper _mapper;

        public CategoriesController(IMapper mapper, ICatogoryServices categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            IEnumerable<Category> category = await _categoryService.getCategoryAsync();
            IEnumerable<CategoryDTO> categoryDTO = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(category);
            return categoryDTO;
        }

    }
}
