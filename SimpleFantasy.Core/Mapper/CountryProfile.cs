using AutoMapper;
using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Models.Entities;

namespace SimpleFantasy.Core.Mapper
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDTO>();
        }
    }
}
