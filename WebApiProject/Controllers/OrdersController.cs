using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        IMapper _mapper;
        IOrderServices _orderServices;

        public OrdersController(IMapper mapper, IOrderServices orderServices)
        {
            _mapper = mapper;
            _orderServices = orderServices;
        }

        // POST: OrdersController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Order>> Post([FromBody] OrderDTO orderDTO)
        {
            try
            {
                OrderItemDTO orderItemDTO = orderDTO.OrderItems;
                OrderItem orderItemParse = _mapper.Map<OrderItem, OrderItemDTO>(orderDTO.OrderItems);
                Order OrderParse = _mapper.Map<OrderDTO, Order>(orderDTO);
                Order newOrder = await _orderServices.addOrder(OrderParse);
                if (newOrder == null)
                    return BadRequest();
                return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrder);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Get(int id)
        {
            Order user = await _orderServices.getOrderById(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }
    }
}
