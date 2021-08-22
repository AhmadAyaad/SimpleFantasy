using SimpleFantasy.Models.Entities;
using SimpleFantasy.Models.IRepository;

namespace SimpleFantasy.Infrastructure.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(FantasyDbContext context) : base(context)
        {
        }
    }
}
