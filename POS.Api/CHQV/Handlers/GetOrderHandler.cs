using AutoMapper;
using MediatR;
using POS.Api.CHQV.Queries;
using POS.Api.DTOs.Reponses;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.CHQV.Handlers
{
    public class GetOrderHandler : IRequestHandler<GetOrder, OrderResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderResponse?> Handle(GetOrder request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderRepository.GetOrderById(request.Id);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<OrderResponse>(order);
        }
    }
}
