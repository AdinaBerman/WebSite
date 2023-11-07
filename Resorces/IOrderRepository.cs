using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> addOrder(Order order);
        Task<Order> getOrderById(int id);
        Task<Order> updateOrder(int id, Order orderUPdate);
    }
}