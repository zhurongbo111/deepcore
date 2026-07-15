using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.PurchaseOrders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
        [ProducesResponseType(typeof(CreatePurchaseOrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreatePurchaseOrderRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdatePurchaseOrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdatePurchaseOrderRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(PurchaseOrderListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List([FromQuery] PurchaseOrderListRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetPurchaseOrderByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(long id)
        {
            var request = new GetPurchaseOrderByIdRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("{id}/cancel")]
        [ProducesResponseType(typeof(CancelPurchaseOrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Cancel(long id)
        {
            var request = new CancelPurchaseOrderRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("{id}/submit")]
        [ProducesResponseType(typeof(SubmitPurchaseOrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Submit(long id)
        {
            var request = new SubmitPurchaseOrderRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("{id}/stock-in")]
        [ProducesResponseType(typeof(StockInPurchaseOrderResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> StockIn(long id)
        {
            var request = new StockInPurchaseOrderRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
