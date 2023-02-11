using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using POS.Api.CHQV.Commands;
using POS.Api.CHQV.Queries;
using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;
using POS.Api.DTOs.Reponses;

namespace POS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InventoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("toppings")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> GetToppings()
        {
            var data = await _mediator.Send(new GetItems
            {
                InventoryType = InventoryType.Topping
            });
            return Ok(data);
        }

        [HttpGet("sauces")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> GetSauces()
        {
            var data = await _mediator.Send(new GetItems
            {
                InventoryType = InventoryType.Sauce
            });
            return Ok(data);
        }

        [HttpGet("pizza-base")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> GetBase()
        {
            var data = await _mediator.Send(new GetItems
            {
                InventoryType = InventoryType.PizzaBase
            });
            return Ok(data);
        }

        [HttpGet("crust")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> GetCrust()
        {
            var data = await _mediator.Send(new GetItems
            {
                InventoryType = InventoryType.Crust
            });
            return Ok(data);
        }

        [HttpGet("cheese")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> Getcheese()
        {
            var data = await _mediator.Send(new GetItems
            {
                InventoryType = InventoryType.Cheese
            });
            return Ok(data);
        }

        [HttpPost("create-item")]
        [ProducesResponseType(typeof(bool), 201)]
        public async Task<IActionResult> CreateItem(CreateInventory request)
        {
            var result = await _mediator.Send(request);
            return result ? Created(Request.GetDisplayUrl(), request.Item) : Problem("Unable to create Item");
        }
    }
}
