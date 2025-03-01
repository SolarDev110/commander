using AutoMapper;
using commander.Dtos;
using commander.Models;

namespace commander.Profiles
{
    public class RateProfile : Profile
    {
        public RateProfile()
        {
            CreateMap<Rate, RateReadDto>();
        }
    }
}