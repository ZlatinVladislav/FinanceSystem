using AutoMapper;
using FinanceSystem.DtoModels.Transaction;
using FinanceSystem.DtoModels.TransactionType;
using FinanceSystem.Infrastructure.Models;

namespace FinanceSystem.Mappers
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionType, TransactionTypeDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.TransactionTypes))
                .ReverseMap();

            CreateMap<Transaction, TransactionGetDto>()
                .ForMember(dest => dest.TransactionType,
                    opt => opt.MapFrom(src => src.TransactionType.TransactionTypes))
                .ReverseMap();


            CreateMap<TransactionDto, Transaction>()
                .ForMember(dest => dest.TransactionTypeId, opt => opt.MapFrom(src => src.TransactionTypeId))
                .ReverseMap();
        }
    }
}