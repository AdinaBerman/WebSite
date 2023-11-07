using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private static PruductsDbContext _pruductsDbContext = new PruductsDbContext();

        public async Task<Order> addOrder(Order order)
        {
            await _pruductsDbContext.Orders.AddAsync(order);
            await _pruductsDbContext.SaveChangesAsync();
            return order;

        }

        public async Task<Order> updateOrder(int id, Order orderUPdate)
        {
            _pruductsDbContext.Orders.Update(orderUPdate);
            await _pruductsDbContext.SaveChangesAsync();
            return orderUPdate;
        }

        public async Task<Order> getOrderById(int id)
        {
            return await _pruductsDbContext.Orders.Where(o => o.OrderId == id).FirstOrDefaultAsync();

        }
    }
}
