using AutoMapper;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using POS.Api;
using POS.Api.CHQV.Handlers;
using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;
using POS.Api.DTOs.Reponses;
using POS.Api.DTOs.Request;
using POS.Api.Repositories.Interfaces;
using Shouldly;

namespace POS.Test.Handlers
{
    public class GetOrderHandlerTest
    {
        GetOrderHandler _handler;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetOrderHandlerTest()
        {
            _unitOfWork = A.Fake<IUnitOfWork>();
            _mapper = A.Fake<IMapper>();
            _handler = new GetOrderHandler(_unitOfWork, _mapper);
        }

        [Fact]
        public async Task TestGetOrderSuccess()
        {
            var orderResult = new Order
            {
                Id = 1,
                Pizzas = new List<Pizza> {
                        new()
                        {
                            Id=1,
                            BasePrice = 160,
                            Cheese = new List<CheeseOptions>{
                            new ()
                            {
                                ExtraCheesePrice=10,
                                Price = 30,
                                Id = 1
                            } },
                            Crust=CrustType.FreshPan,
                            Size = PizzaSize.Small,
                            Sauces = new List<Sauce>
                            {
                                new()
                                {
                                    Id= 2,
                                    Price=60,
                                    Type = SauceType.Marinara
                                }
                            },
                            Toppings = new List<Topping>
                            {
                                new()
                                {
                                    Id=6,
                                    Type = ToppingType.Mushrooms,
                                    Price = 80
                                }
                            }
                        }
                    },
                Value = 340
            };
            var orderResponse = new OrderResponse
            {
                Id = 1,
                Pizzas = new List<PizzaRequest> {
                        new()
                        {
                            BasePrice = 160,
                            Cheese = new List<CheeseRequest>
                            {
                                new()
                                {
                                    ExtraCheesePrice=10,
                                    Price = 30
                                }
                            },
                            Crust=CrustType.FreshPan,
                            Size = PizzaSize.Small,
                            Sauces = new List<SauceRequest>
                            {
                                new()
                                {
                                    Price=60,
                                    Type = SauceType.Marinara
                                }
                            },
                            Toppings = new List<ToppingsRequest>
                            {
                                new()
                                {
                                    Type = ToppingType.Mushrooms,
                                    Price = 80
                                }
                            }
                        }
                    }
            };
            var orderId = 1;
            A.CallTo(() => _mapper.Map<OrderResponse>(orderResult)).Returns(orderResponse);
            A.CallTo(() => _unitOfWork.OrderRepository.GetOrderById(orderId)).Returns(orderResult);

            var result = await _handler.Handle(new Api.CHQV.Queries.GetOrder
            {
                Id = orderId,
            }, CancellationToken.None);
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
            result.Pizzas.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestGetOrderException()
        {
            var orderId = 1;
            var orderResult = new Order
            {
                Id = 1,
                Pizzas = new List<Pizza> {
                        new()
                        {
                            Id=1,
                            BasePrice = 160,
                            Cheese = new List<CheeseOptions>{
                            new ()
                            {
                                ExtraCheesePrice=10,
                                Price = 30,
                                Id = 1
                            } },
                            Crust=CrustType.FreshPan,
                            Size = PizzaSize.Small,
                            Sauces = new List<Sauce>
                            {
                                new()
                                {
                                    Id= 2,
                                    Price=60,
                                    Type = SauceType.Marinara
                                }
                            },
                            Toppings = new List<Topping>
                            {
                                new()
                                {
                                    Id=6,
                                    Type = ToppingType.Mushrooms,
                                    Price = 80
                                }
                            }
                        }
                    }
            };
            var orderResponse = new OrderResponse
            {
                Id = 1,
                Pizzas = new List<PizzaRequest> {
                        new()
                        {
                            BasePrice = 160,
                            Cheese = new List<CheeseRequest>
                            {
                                new()
                                {
                                    ExtraCheesePrice=10,
                                    Price = 30
                                }
                            },
                            Crust=CrustType.FreshPan,
                            Size = PizzaSize.Small,
                            Sauces = new List<SauceRequest>
                            {
                                new()
                                {
                                    Price=60,
                                    Type = SauceType.Marinara
                                }
                            },
                            Toppings = new List<ToppingsRequest>
                            {
                                new()
                                {
                                    Type = ToppingType.Mushrooms,
                                    Price = 80
                                }
                            }
                        }
                    }
            };

            A.CallTo(() => _mapper.Map<OrderResponse>(orderResult)).Returns(orderResponse);
            A.CallTo(() => _unitOfWork.OrderRepository.GetOrderById(orderId)).Throws(new DbUpdateException());

            Should.Throw(async () =>
            {
                await _handler.Handle(new Api.CHQV.Queries.GetOrder { Id = orderId }, CancellationToken.None);
            }, typeof(DbUpdateException));
        }
    }
}
