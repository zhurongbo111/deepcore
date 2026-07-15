using DeepCore.RequestHandlers.Products;
using DeepCore.RequestHandlers.Shared;
using DeepCore.RequestHandlers;
using Microsoft.AspNetCore.Mvc;

namespace DeepCore.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    [Consumes("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] UpdateProductRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> PatchStatus(long id, [FromBody] PatchProductStatusRequest request)
        {
            request.Id = id;
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ProductListRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var request = new GetProductByIdRequest { Id = id };
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
