using MediatR;
using POS.Api.DTOs.Request;

namespace POS.Api.CHQV.Commands
{
    public class CreateInventoryCommand : IRequest<bool>
    {
        public ItemRequest Item { get; set; }
    }
}
