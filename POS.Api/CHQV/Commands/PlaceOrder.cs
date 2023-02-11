using MediatR;
using POS.Api.DTOs.Request;

namespace POS.Api.CHQV.Commands
{
    public class PlaceOrder: IRequest<bool>
    {
        public OrderRequest Order { get; set; }
    }
}
