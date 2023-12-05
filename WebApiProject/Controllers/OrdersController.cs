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
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDTO)
        {
            Order OrderParse = _mapper.Map<OrderDTO, Order>(orderDTO);
            Order newOrder = await _orderServices.addOrderAsync(OrderParse);
            OrderDTO newOrderDTO = _mapper.Map<Order, OrderDTO>(newOrder);
            return newOrder != null ? CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrderDTO) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Get(int id)
        {
            Order user = await _orderServices.getOrderByIdAsync(id);
            if (user == null)
                return NoContent();
            return Ok(user);
        }
    }
}
