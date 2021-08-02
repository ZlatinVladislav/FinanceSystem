using AutoMapper;
using FinanceSystem.DtoModels.TransactionType;
using FinanceSystem.Infrastructure.Models;

namespace FinanceSystem.Mappers
{
    public class TransactionTypeProfile : Profile
    {
        public TransactionTypeProfile()
        {
            CreateMap<TransactionType, TransactionTypeDto>()
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionTypes))
                .ReverseMap();
        }
    }
}