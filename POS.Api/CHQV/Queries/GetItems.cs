using MediatR;
using POS.Api.Data.Enums;
using POS.Api.DTOs.Reponses;

namespace POS.Api.CHQV.Queries
{
    public class GetItems : IRequest<IEnumerable<ItemResponse>>
    {
        public InventoryType InventoryType { get; set; }
    }
}
