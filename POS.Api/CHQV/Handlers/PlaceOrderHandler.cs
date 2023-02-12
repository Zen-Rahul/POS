using AutoMapper;
using MediatR;
using POS.Api.CHQV.Commands;
using POS.Api.Data.DbModels;
using POS.Api.DTOs.Reponses;
using POS.Api.Repositories.Interfaces;

namespace POS.Api.CHQV.Handlers
{
    public class PlaceOrderHandler : IRequestHandler<PlaceOrder, OrderResponse?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlaceOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OrderResponse?> Handle(PlaceOrder request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request.Order);
            await _unitOfWork.OrderRepository.AddOrder(order);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<OrderResponse>(order);
        }

        private decimal GetOrderValue(List<Pizza> pizzas)
        {
            var value = 0M;
            foreach (var pizza in pizzas)
            {
                value += pizza.BasePrice;
                foreach (var ch in pizza.Cheese)
                {
                    value = value + ch.Price + ch.ExtraCheesePrice;
                }

                foreach (var sauce in pizza.Sauces)
                {
                    value += sauce.Price;
                }

                foreach (var topping in pizza.Toppings)
                {
                    value += topping.Price;
                }
            }

            return value;
        }
    }
}
