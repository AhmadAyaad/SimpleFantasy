using SimpleFantasy.Models.IRepository;
using System.Threading.Tasks;

namespace SimpleFantasy.Models.IUnitOfWork
{
    public interface IUnitOfWork
    {
        ITeamRepository TeamRepo { get; }
        IPlayerRepository PlayerRepo { get; }
        ICountryRepository CountryRepo { get; }
        INationalityRepository NationalityRepo { get; }
        Task<int> SaveChangesAsync();
    }
}
