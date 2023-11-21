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
        IOrderServices _orderServices;

        public OrdersController(IOrderServices orderervice)
        {
            _orderServices = orderervice;
        }

        // POST: OrdersController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            try
            {
                Order newOrder = await _orderServices.addOrder(order);
                if (newOrder == null)
                    return BadRequest();
                return CreatedAtAction(nameof(Get), new { id = order.OrderId }, newOrder);
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
