using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> addOrder(Order order);
        public Task<Order> getOrderById(int id);

    }
}