using Microsoft.AspNetCore.Mvc;
using SimpleFantasy.Core.IServices;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SimpleFantasy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityService _nationalityService;

        public NationalityController(INationalityService nationalityService)
        {
            _nationalityService = nationalityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetNationalities()
        {
            try
            {
                var nationalitiesDTOSResponse = await _nationalityService.GetNationalitiesAsync();
                return Ok(nationalitiesDTOSResponse.Data);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retriving all nationalities.");
            }
        }
    }
}
