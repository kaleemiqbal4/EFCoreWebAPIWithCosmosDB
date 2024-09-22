using EFCoreCosmosDB.Application.Contract;
using EFCoreCosmosDB.Entity.Request;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreCosmosDB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly ILogger<ProductsController> logger;

        /// <summary> </summary>
        /// <param name="_productManager"></param>
        /// <param name="_logger"></param>
        public ProductsController(IProductManager _productManager, ILogger<ProductsController> _logger) => (productManager, logger) = (_productManager, _logger);

        [HttpPost]
        public async Task<IActionResult> SaveProductsAsync([FromBody] ProductRequest productRequest)
        {
            var response = await productManager.CreateProductAsync(productRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var response = await productManager.ProductListAsync();
            return Ok(response);
        }
    }
}
