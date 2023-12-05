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
        private static PruductsDbContext _pruductsDbContext;
        public OrderRepository(PruductsDbContext pruductsDbContext)
        {
            _pruductsDbContext = pruductsDbContext;
        }

        public async Task<Order> addOrderAsync(Order order)
        {
            await _pruductsDbContext.Orders.AddAsync(order);
            await _pruductsDbContext.SaveChangesAsync();
            return order;
        }

        public async Task<Order> getOrderByIdAsync(int id)
        {
            return await _pruductsDbContext.Orders.Where(p => p.OrderId == id).FirstOrDefaultAsync();

        }
    }
}
