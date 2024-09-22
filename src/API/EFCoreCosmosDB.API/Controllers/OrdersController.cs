using EFCoreCosmosDB.Application.Contract;
using EFCoreCosmosDB.Entity.Request;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCosmosDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager orderManager;
        private readonly ILogger<OrdersController> logger;

        /// <summary></summary>
        /// <param name="_orderManager"></param>
        /// <param name="_logger"></param>
        public OrdersController(IOrderManager _orderManager, ILogger<OrdersController> _logger) => (orderManager, logger) = (_orderManager, _logger);

        [HttpPost]
        public async Task<IActionResult> SaveOrdersAsync([FromBody] OrderRequest orderRequest)
        {
            var result = await orderManager.CreateOrderAsync(orderRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var result = await orderManager.OrderListAsync();
            return Ok(result);
        }
    }
}
