using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.Customers;
using Microsoft.AspNetCore.Mvc;

namespace DeepCore.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    [Consumes("application/json")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateCustomerRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] CustomerListRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var request = new GetCustomerByIdRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> ChangeStatus(long id, [FromBody] PatchCustomerStatusRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
