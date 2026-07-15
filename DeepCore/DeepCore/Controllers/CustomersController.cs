using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
        [ProducesResponseType(typeof(CreateCustomerResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateCustomerResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateCustomerRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(CustomerListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List([FromQuery] CustomerListRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetCustomerByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(long id)
        {
            var request = new GetCustomerByIdRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        [ProducesResponseType(typeof(PatchCustomerStatusResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStatus(long id, [FromBody] PatchCustomerStatusRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
