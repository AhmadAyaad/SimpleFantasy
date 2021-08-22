using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleFantasy.Identity.DTOS;
using SimpleFantasy.Identity.IServices;
using SimpleFantasy.Shared;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SimpleFantasy.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterNewUser(ReigsterUserDTO reigsterUserDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);
            try
            {
                var response = await _accountService.RegisterUserAsync(reigsterUserDTO);
                if (response.Status == ResponseStatus.Failed)
                    return BadRequest(response.Messages);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while registering new users.");
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);
            try
            {
                var userDTOResponse = await _accountService.LoginAsync(loginDTO);
                if (userDTOResponse.Status == ResponseStatus.Unauthorized)
                    return BadRequest(userDTOResponse.Messages);
                return Ok(userDTOResponse.Data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while registering new users.");
            }
        }
    }
}
