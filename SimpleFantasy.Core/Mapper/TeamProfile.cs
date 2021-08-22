using AutoMapper;
using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Models.Entities;
using System.Linq;

namespace SimpleFantasy.Core.Mapper
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamDTO, Team>().ReverseMap().ForMember(dest => dest.Players, opt => opt.MapFrom(src => src.Players.Select(p => new Player
            {
                DateOfBirth = p.DateOfBirth,
                ImageURL = p.ImageURL,
                Name = p.Name,
                NationalityId = p.NationalityId
            })));
        }
    }
}
