using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Core.IServices;
using SimpleFantasy.Shared;
using System.Net;
using System.Threading.Tasks;

namespace SimpleFantasy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddNewTeam([FromForm] TeamDTO teamDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);
            try
            {
                var response = await _teamService.AddNewTeamAsync(teamDTO);
                if (response.Status != ResponseStatus.Succeeded)
                    return BadRequest(response.Messages);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while adding new team.");
            }
        }
        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public async Task<IActionResult> GetTeams([FromQuery] PaginationFilter paginationFilter)
        {
            try
            {
                var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
                var pagedTeamsResult = await _teamService.GetTeamsAsync(validFilter.PageNumber, validFilter.PageSize);
                return Ok(pagedTeamsResult);
            }
            catch (System.Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retireving teams.");

            }
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("{teamId}")]
        public async Task<IActionResult> GetTeam(int teamId)
        {
            try
            {
                var teamResponse = await _teamService.GetTeamAsync(teamId);
                if (teamResponse.Status != ResponseStatus.Succeeded)
                    return BadRequest(teamResponse.Messages);
                return Ok(teamResponse.Data);
            }
            catch (System.Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retireving team.");
            }
        }

    }
}
