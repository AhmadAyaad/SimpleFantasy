using Microsoft.EntityFrameworkCore;
using SimpleFantasy.Infrastructure.Extensions;
using SimpleFantasy.Models.Entities;
using SimpleFantasy.Models.IRepository;
using SimpleFantasy.Shared;
using System.Threading.Tasks;

namespace SimpleFantasy.Infrastructure.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(FantasyDbContext context) : base(context)
        {
        }

        public Task<PagedResultDTO<Team>> GetTeamsWithCountryNameAsync(int pageIndex, int pageSize)
        {
            return _context.Teams.Include(t => t.Country).GetPagedAsync(pageIndex, pageSize);
        }
    }
}
