using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleFantasy.Core.IServices
{
    public interface IPlayerService
    {
        Task<Response> AddTeamPlayersAsync(List<PlayerDTO> playersDTOS);
    }
}
