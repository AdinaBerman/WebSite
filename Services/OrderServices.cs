using Entities;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<OrderServices> _logger;
        private readonly IProductRepository _productRepository;

        public OrderServices(IOrderRepository orderRepository, ILogger<OrderServices> logger, IProductRepository productRepository)
        {
            _repository = orderRepository;
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<Order> addOrder(Order order)
        {
            int price = order.OrderSum;
            int sumPrice = 0;
            int[] products = new int[order.OrderItems.Count()];
            //List<OrderItem> orderItems = (List<OrderItem>)order.OrderItems;
            for(int i = 0; i< order.OrderItems.Count(); i++)
            {
                products[i] = (int)order.OrderItems.ElementAt(i).ProductId;
            }

            List<Product> prods = new List<Product>();

            for(int i=0; i<products.Length; i++)
            {
                Product p = await _productRepository.getProductById(products[i]);
                prods.Add(p);
            }

            for(int i=0; i<prods.Count(); i++)
            {
                sumPrice += order.OrderItems.ElementAt(i).Quentity * prods[i].ProdPrice;
            }

            if(sumPrice != price)
            {
                _logger.LogError("someone try to create order with not valid order sum");
            }
            order.OrderSum = sumPrice;
            return await _repository.addOrder(order);
        }

        public async Task<Order> getOrderById(int id)
        {
            return await _repository.getOrderById(id);
        }
    }
}
