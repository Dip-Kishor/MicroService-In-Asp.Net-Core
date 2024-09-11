using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Models;
using OrderMicroservice.Services;

namespace OrderMicroservice.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderApiController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }
        [HttpGet]
        [Route("GetOrderById/{id}")]
        public async Task<ActionResult<OrderModel>> GetOrder(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        [Route("PlaceOrder")]
        public async Task<ActionResult<OrderModel>> PlaceOrder(OrderModel order)
        {
            var createdOrder = await _orderService.PlaceOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = createdOrder.Id }, createdOrder);
        }
    }

}
