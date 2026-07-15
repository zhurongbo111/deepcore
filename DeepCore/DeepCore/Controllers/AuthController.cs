using DeepCore.RequestHandlers;
using DeepCore.RequestHandlers.AuthLogin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeepCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthLoginRequest request)
        {
            var result = await _mediator.SendAsync(request, HttpContext.RequestAborted);
            return Ok(result);
        }
    }
}
