using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleFantasy.Core.IServices
{
    public interface ICountryService
    {
        Task<Response<List<CountryDTO>>> GetCountriesAsync();
    }
}
