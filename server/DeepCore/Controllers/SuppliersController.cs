using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.Suppliers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeepCore.Controllers
{
    [Route("api/v1/suppliers")]
    [ApiController]
    [Consumes("application/json")]
    [Authorize]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateSupplierResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] CreateSupplierRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UpdateSupplierResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateSupplierRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(SupplierListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List([FromQuery] SupplierListRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetSupplierByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(long id)
        {
            var request = new GetSupplierByIdRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        [ProducesResponseType(typeof(PatchSupplierStatusResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> ChangeStatus(long id, [FromBody] PatchSupplierStatusRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
