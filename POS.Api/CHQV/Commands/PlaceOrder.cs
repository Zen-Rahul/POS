using MediatR;
using POS.Api.DTOs.Reponses;
using POS.Api.DTOs.Request;

namespace POS.Api.CHQV.Commands
{
    public class PlaceOrder: IRequest<OrderResponse>
    {
        public OrderRequest Order { get; set; }
    }
}
