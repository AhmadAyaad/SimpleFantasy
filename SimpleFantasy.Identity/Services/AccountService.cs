using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleFantasy.Identity.DTOS;
using SimpleFantasy.Identity.IServices;
using SimpleFantasy.Models.Entities;
using SimpleFantasy.Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFantasy.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly IMapper _mapper;
        public AccountService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IOptions<JWT> jwt, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _mapper = mapper;
        }

        public async Task<Response<UserDTO>> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user is null)
                return new Response<UserDTO>(null, ResponseStatus.Unauthorized, "Cannot find this email or password");
            UserDTO userDTO = new UserDTO();
            if (await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                JwtSecurityToken jwtSecurityToken = await CreateJwtToken(user);
                userDTO.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                userDTO.Email = user.Email;
                userDTO.UserName = user.UserName;
                var rolesList = await _userManager.GetRolesAsync(user);
                userDTO.Roles = rolesList.ToList();
                return new Response<UserDTO>(userDTO);
            }
            return new Response<UserDTO>(null, ResponseStatus.Unauthorized, "Something wrong with email or password.");
        }
        private async Task<JwtSecurityToken> CreateJwtToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
        public async Task<Response> RegisterUserAsync(ReigsterUserDTO reigsterUserDTO)
        {
            var user = _mapper.Map<User>(reigsterUserDTO);
            var existingUser = await _userManager.FindByEmailAsync(user.Email);
            if (existingUser is not null)
                return new Response(ResponseStatus.Failed, "This is mail already exists");
            var identityResult = await _userManager.CreateAsync(user, reigsterUserDTO.Password);
            if (!identityResult.Succeeded)
            {
                List<IdentityError> errorList = identityResult.Errors.ToList();
                var errors = string.Join(", ", errorList.Select(e => e.Description));
                return new Response(ResponseStatus.Failed, errors);
            }
            await _userManager.AddToRoleAsync(user, Authorization.DEFAULT_ROLE.ToString());
            return new Response();
        }
    }
}
