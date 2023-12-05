using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> addOrderAsync(Order order);
        public Task<Order> getOrderByIdAsync(int id);

    }
}