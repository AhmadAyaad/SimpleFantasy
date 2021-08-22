using SimpleFantasy.Infrastructure.Repository;
using SimpleFantasy.Models.IRepository;
using SimpleFantasy.Models.IUnitOfWork;
using System.Threading.Tasks;

namespace SimpleFantasy.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ITeamRepository _teamRepository;
        private IPlayerRepository _playerRepository;
        private INationalityRepository _nationalityRepository;
        private ICountryRepository _countryRepository;

        private readonly FantasyDbContext _context;

        public UnitOfWork(FantasyDbContext context)
        {
            _context = context;
        }
        public ITeamRepository TeamRepo
        {
            get
            {
                if (_teamRepository is null)
                    _teamRepository = new TeamRepository(_context);
                return _teamRepository;
            }
        }
        public IPlayerRepository PlayerRepo
        {
            get
            {
                if (_playerRepository is null)
                    _playerRepository = new PlayerRepository(_context);
                return _playerRepository;
            }
        }
        public INationalityRepository NationalityRepo
        {
            get
            {
                if (_nationalityRepository is null)
                    _nationalityRepository = new NationalityRepository(_context);
                return _nationalityRepository;
            }
        }
        public ICountryRepository CountryRepo
        {
            get
            {
                if (_countryRepository is null)
                    _countryRepository = new CountryRepository(_context);
                return _countryRepository;
            }
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
