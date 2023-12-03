using AutoMapper;
using DTO;
using Entities;

namespace WebApiProject
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserSaveDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Category.CategoryName)).ReverseMap();
        }
    }
}
