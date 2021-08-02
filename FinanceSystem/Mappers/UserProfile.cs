using AutoMapper;
using FinanceSystem.DtoModels.User;
using FinanceSystem.Infrastructure.Models;

namespace FinanceSystem.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            /*
                This is where we are mapping from 
                entity to view model and vice versa.
            */
            CreateMap<AppUser, UserProfileDto>()
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => src.Bio))
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.DisplayName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ReverseMap();
        }
    }
}