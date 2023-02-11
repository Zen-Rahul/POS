using MediatR;
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

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("take-order")]
        public async Task<IActionResult> TakeOrder(PlaceOrder request)
        {
            var order = await _mediator.Send(request);
            return order ? Accepted() : Problem("Unable accept order. Some error occured.");
        }
    }
}
