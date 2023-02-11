using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using POS.Api.CHQV.Commands;
using POS.Api.DTOs.Request;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IMediator mediator, ILogger<OrderController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder(PlaceOrder request)
        {
            try
            {
                var order = await _mediator.Send(request);
                return Created(Request.GetDisplayUrl(), order);
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to place order", ex);
                return Problem("Unable accept order. Some error occured.");
            }
        }
    }
}
