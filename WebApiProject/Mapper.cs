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
        }
    }
}
