using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApiProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        IProductServices _productService;

        public ProductsController(IProductServices productService)
        {
            _productService = productService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.getProduct();
        }
    }
}
