using MediatR;
using POS.Api.DTOs.Request;

namespace POS.Api.CHQV.Commands
{
    public class CreateInventory : IRequest<bool>
    {
        public ItemRequest Item { get; set; }
    }
}
