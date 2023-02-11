using AutoMapper;
using POS.Api.Data.DbModels;
using POS.Api.DTOs.Reponses;

namespace POS.Api.DTOs
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Item, ItemResponse>().ReverseMap();
        }
    }
}
