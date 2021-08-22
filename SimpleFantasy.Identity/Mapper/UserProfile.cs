using AutoMapper;
using SimpleFantasy.Identity.DTOS;
using SimpleFantasy.Models.Entities;

namespace SimpleFantasy.Identity.Mapper
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ReigsterUserDTO, User>();
        }
    }
}
