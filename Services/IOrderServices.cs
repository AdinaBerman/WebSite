using Entities;

namespace Services
{
    public interface IOrderServices
    {
        Task<Order> addOrder(Order order);
        Task<Order> getOrderById(int id);

    }
}