using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.PurchaseOrders;
using Microsoft.AspNetCore.Mvc;

namespace DeepCore.Controllers
{
    [Route("api/v1/purchase-orders")]
    [ApiController]
    [Consumes("application/json")]
    public class PurchaseOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PurchaseOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseOrderRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdatePurchaseOrderRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PurchaseOrderListRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var request = new GetPurchaseOrderByIdRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(long id)
        {
            var request = new CancelPurchaseOrderRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("{id}/submit")]
        public async Task<IActionResult> Submit(long id)
        {
            var request = new SubmitPurchaseOrderRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("{id}/stock-in")]
        public async Task<IActionResult> StockIn(long id)
        {
            var request = new StockInPurchaseOrderRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
