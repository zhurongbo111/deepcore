using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.SalesOrders;
using Microsoft.AspNetCore.Mvc;

namespace DeepCore.Controllers
{
    [Route("api/v1/sales-orders")]
    [ApiController]
    [Consumes("application/json")]
    public class SalesOrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesOrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSalesOrderRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("{id}/submit")]
        public async Task<IActionResult> Submit(long id)
        {
            var request = new SubmitSalesOrderRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] SalesOrderListRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var request = new GetSalesOrderByIdRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel(long id)
        {
            var request = new CancelSalesOrderRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPost("{id}/stock-out")]
        public async Task<IActionResult> StockOut(long id)
        {
            var request = new StockOutSalesOrderRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
