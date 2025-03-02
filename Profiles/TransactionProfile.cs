using AutoMapper;
using commander.Dtos;
using commander.Models;

namespace commander.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<Transaction, TransactionReadDto>();
        }
    }
}
