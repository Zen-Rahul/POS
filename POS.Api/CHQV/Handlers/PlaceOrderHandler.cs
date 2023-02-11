using AutoMapper;
using MediatR;
using POS.Api.CHQV.Commands;
using POS.Api.Data.DbModels;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.CHQV.Handlers
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrder, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PlaceOrder> _logger;

        public PlaceOrderHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PlaceOrder> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(PlaceOrder request, CancellationToken cancellationToken)
        {
            try
            {
                var order = _mapper.Map<Order>(request.Order);
                await _unitOfWork.OrderRepository.AddOrder(order);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to accept Order", ex);
                return false;
            }
        }
    }
}
