using AutoMapper;
using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Models.Entities;

namespace SimpleFantasy.Core.Mapper
{
    public class NationalityProfile : Profile
    {
        public NationalityProfile()
        {
            CreateMap<Nationality, NationalityDTO>();
        }
    }
}
