using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleFantasy.Core.IServices
{
    public interface INationalityService
    {
        Task<Response<List<NationalityDTO>>> GetNationalitiesAsync();
    }
}
