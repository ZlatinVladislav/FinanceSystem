using AutoMapper;
using FinanceSystem.Application.DtoModels.TransactionType;
using FinanceSystem.Infrastructure.Models;

namespace FinanceSystem.Application.Mappers
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