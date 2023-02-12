using MediatR;
using POS.Api.DTOs.Reponses;

namespace POS.Api.CHQV.Queries
{
    public class GetOrder: IRequest<OrderResponse>
    {
        public int Id { get; set; }
    }
}
