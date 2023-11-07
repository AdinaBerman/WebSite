using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderRepository _repository;

        public OrderServices(IOrderRepository orderRepository)
        {
            _repository = orderRepository;
        }

        public async Task<Order> addOrder(Order order)
        {
            return await _repository.addOrder(order);
        }

        public async Task<Order> updateOrder(int id, Order order)
        {
            return await _repository.updateOrder(id, order);
        }

        public async Task<Order> getOrderById(int id)
        {
            return await _repository.getOrderById(id);
        }
    }
}
