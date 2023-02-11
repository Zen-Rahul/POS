using AutoMapper;
using MediatR;
using POS.Api.CHQV.Commands;
using POS.Api.Data.DbModels;
using POS.Api.DTOs.Reponses;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.CHQV.Handlers
{
    public class CreateInventoryHandler : IRequestHandler<CreateInventoryCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateInventoryHandler> _logger;

        public CreateInventoryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateInventoryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(CreateInventoryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var item = _mapper.Map<Item>(command.Item);
                item.Name = $"{item.Type}-{item.Size}";
                await _unitOfWork.ItemRepository.AddItem(item);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unable to save item of type {command.Item.Type} and size {command.Item.Size}", ex);
                return false;
            }
        }
    }
}
