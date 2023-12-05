using Entities;

namespace Services
{
    public interface IOrderServices
    {
        Task<Order> addOrderAsync(Order order);
        Task<Order> getOrderByIdAsync(int id);

    }
}