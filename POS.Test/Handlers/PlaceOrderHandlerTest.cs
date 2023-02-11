using AutoMapper;
using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using POS.Api;
using POS.Api.CHQV.Commands;
using POS.Api.CHQV.Handlers;
using POS.Api.Data.DbModels;
using POS.Api.Data.Enums;
using POS.Api.DTOs.Reponses;
using POS.Api.DTOs.Request;
using POS.Api.Repositories.Interfaces;
using Shouldly;

namespace POS.Test.Handlers
{
    public class PlaceOrderHandlerTest
    {
        PlaceOrderHandler _handler;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public PlaceOrderHandlerTest()
        {
            _unitOfWork = A.Fake<IUnitOfWork>();
            _mapper = A.Fake<IMapper>();
            _handler = new PlaceOrderHandler(_unitOfWork, _mapper);
        }

        [Fact]
        public async Task TestOrderPlacementSuccess()
        {
            var command = new PlaceOrder
            {
                Order = new OrderRequest
                {
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
                }
            };
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

            A.CallTo(() => _mapper.Map<Order>(command.Order)).Returns(orderResult);
            A.CallTo(() => _mapper.Map<OrderResponse>(orderResult)).Returns(orderResponse);
            A.CallTo(() => _unitOfWork.OrderRepository.AddOrder(orderResult)).Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
            result.Pizzas.Count.ShouldBe(1);
        }

        [Fact]
        public async Task TestOrderPlacementException()
        {
            var command = new PlaceOrder
            {
                Order = new OrderRequest
                {
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
                }
            };
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

            A.CallTo(() => _mapper.Map<Order>(command.Order)).Returns(orderResult);
            A.CallTo(() => _mapper.Map<OrderResponse>(orderResult)).Returns(orderResponse);
            A.CallTo(() => _unitOfWork.OrderRepository.AddOrder(orderResult)).Returns(Task.CompletedTask);
            A.CallTo(() => _unitOfWork.SaveAsync()).Throws(new DbUpdateException());

            Should.Throw(async () =>
            {
                await _handler.Handle(command, CancellationToken.None);
            }, typeof(DbUpdateException));
        }
    }
}
