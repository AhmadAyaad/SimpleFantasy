using SimpleFantasy.Models.Entities;
using SimpleFantasy.Models.IRepository;

namespace SimpleFantasy.Infrastructure.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(FantasyDbContext context) : base(context)
        {
        }
    }
}
