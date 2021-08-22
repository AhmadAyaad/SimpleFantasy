using SimpleFantasy.Identity.DTOS;
using SimpleFantasy.Shared;
using System.Threading.Tasks;

namespace SimpleFantasy.Identity.IServices
{
    public interface IAccountService
    {
        Task<Response> RegisterUserAsync(ReigsterUserDTO reigsterUserDTO);
        Task<Response<UserDTO>> LoginAsync(LoginDTO loginDTO);
    }
}
