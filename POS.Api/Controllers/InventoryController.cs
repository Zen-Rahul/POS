using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMediator mediator;

        public InventoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("toppings")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> GetToppings()
        {
            var data = await this.mediator.Send(new GetItems
            {
                InventoryType = InventoryType.Topping
            });
            return Ok(data);
        }

        [HttpGet("sauces")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> GetSauces()
        {
            var data = await this.mediator.Send(new GetItems
            {
                InventoryType = InventoryType.Sauce
            });
            return Ok(data);
        }

        [HttpGet("pizza-base")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> GetBase()
        {
            var data = await this.mediator.Send(new GetItems
            {
                InventoryType = InventoryType.PizzaBase
            });
            return Ok(data);
        }

        [HttpGet("crust")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> GetCrust()
        {
            var data = await this.mediator.Send(new GetItems
            {
                InventoryType = InventoryType.Crust
            });
            return Ok(data);
        }

        [HttpGet("cheese")]
        [ProducesResponseType(typeof(List<ItemResponse>), 200)]
        public async Task<IActionResult> Getcheese()
        {
            var data = await this.mediator.Send(new GetItems
            {
                InventoryType = InventoryType.Cheese
            });
            return Ok(data);
        }
    }
}
