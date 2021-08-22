using System.Collections.Generic;

namespace SimpleFantasy.Identity.DTOS
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
    }
}
