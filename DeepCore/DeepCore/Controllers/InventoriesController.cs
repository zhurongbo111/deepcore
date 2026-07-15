using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.Inventories;
using Microsoft.AspNetCore.Mvc;

namespace DeepCore.Controllers
{
    [Route("api/v1/inventories")]
    [ApiController]
    [Consumes("application/json")]
    public class InventoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] InventoryListRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetByProduct(long productId)
        {
            var request = new GetInventoryByProductRequest { ProductId = productId };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("adjust")]
        public async Task<IActionResult> Adjust([FromBody] AdjustInventoryRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
