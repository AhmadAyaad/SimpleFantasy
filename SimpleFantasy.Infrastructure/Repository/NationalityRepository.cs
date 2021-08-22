using SimpleFantasy.Models.Entities;
using SimpleFantasy.Models.IRepository;

namespace SimpleFantasy.Infrastructure.Repository
{
    public class NationalityRepository : Repository<Nationality>, INationalityRepository
    {
        public NationalityRepository(FantasyDbContext context) : base(context)
        {
        }
    }
}
