using SimpleFantasy.Models.Entities;
using SimpleFantasy.Shared;
using System.Threading.Tasks;

namespace SimpleFantasy.Models.IRepository
{
    public interface ITeamRepository : IRepository<Team>
    {
        Task<PagedResultDTO<Team>> GetTeamsWithCountryNameAsync(int pageIndex, int pageSize);
    }
}
