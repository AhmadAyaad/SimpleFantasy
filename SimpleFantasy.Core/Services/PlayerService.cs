using AutoMapper;
using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Core.IServices;
using SimpleFantasy.Models.Entities;
using SimpleFantasy.Models.IUnitOfWork;
using SimpleFantasy.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleFantasy.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlayerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response> AddTeamPlayersAsync(List<PlayerDTO> playersDTOS)
        {
            var players = _mapper.Map<List<Player>>(playersDTOS);
            await _unitOfWork.PlayerRepo.AddRangeAsync(players);
            return new Response();
        }
    }
}
