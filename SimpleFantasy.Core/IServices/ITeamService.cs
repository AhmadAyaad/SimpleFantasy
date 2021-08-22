using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Shared;
using System.Threading.Tasks;

namespace SimpleFantasy.Core.IServices
{
    public interface ITeamService
    {
        Task<Response> AddNewTeamAsync(TeamDTO teamDTO);
        Task<PagedResultDTO<TeamDTO>> GetTeamsAsync(int pageIndex, int pageSize);
        Task<Response> DeleteTeam(int teamId);
        Task<Response<TeamDTO>> GetTeamAsync(int teamId);
    }
}
