using AutoMapper;
using MediatR;
using POS.Api.CHQV.Queries;
using POS.Api.DTOs.Reponses;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.CHQV.Handlers
{
    public class GetItemsHandler : IRequestHandler<GetItems, IEnumerable<ItemResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetItemsHandler> _logger;
        private readonly IMapper _mapper;

        public GetItemsHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetItemsHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemResponse>> Handle(GetItems request, CancellationToken cancellationToken)
        {
            try
            {
                var result = _unitOfWork.ItemRepository.GetItems(request.InventoryType);
                return _mapper.Map<IEnumerable<ItemResponse>>(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to get item of type {request.InventoryType}", ex);
                return null;
            }
            return null;
        }

    }
}
