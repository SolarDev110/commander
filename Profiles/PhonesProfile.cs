using AutoMapper;
using commander.Dtos;
using commander.Models;

namespace commander.Profiles
{
    public class PhonesProfile : Profile
    {
        public PhonesProfile()
        {
            CreateMap<Phone, PhoneReadDto>();
        }
    }
}