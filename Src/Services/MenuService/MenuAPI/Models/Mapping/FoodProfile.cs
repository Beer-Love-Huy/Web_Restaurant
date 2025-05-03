using AutoMapper;
using MenuAPI.Models.DTOs;
using MenuAPI.Models.Entities;

namespace MenuAPI.Models.Mapping
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Food, FoodDto>()
                .ForMember(f => f.NameFoodType, otp => otp.MapFrom(src => src.FoodType.NameFoodType))
                .ReverseMap();
            CreateMap<Food, CreateFoodDto>().ReverseMap();
            CreateMap<Food, UpdateFoodDto>().ReverseMap();
        }
    }
}
