using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Collections.Generic;

namespace WebApiProject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        IMapper _mapper;
        IProductServices _productService;

        public ProductsController(IMapper mapper, IProductServices productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> Get(int position, int skip, string? desc, int? minPrice, int? maxPrice, [FromQuery] int?[] categoryIds)
        {
            IEnumerable <Product>  products = await _productService.getProduct(position, skip, desc, minPrice, maxPrice, categoryIds);
            IEnumerable<ProductDTO> productDTOs = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(products);
            return productDTOs;
        }
    }
}
