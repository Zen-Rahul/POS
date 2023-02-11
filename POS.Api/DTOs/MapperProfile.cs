using AutoMapper;
using POS.Api.Data.DbModels;
using POS.Api.DTOs.Reponses;
using POS.Api.DTOs.Request;

namespace POS.Api.DTOs
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Item, ItemResponse>().ReverseMap();
            CreateMap<Item, ItemRequest>().ReverseMap();
            CreateMap<Pizza, PizzaRequest>().ReverseMap();
            CreateMap<Topping, ToppingsRequest>().ReverseMap();
            CreateMap<Sauce, SauceRequest>().ReverseMap();
            CreateMap<CheeseOptions, CheeseRequest>().ReverseMap();
            CreateMap<User, UserRequest>().ReverseMap();
            CreateMap<Order, OrderRequest>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap();
        }
    }
}
