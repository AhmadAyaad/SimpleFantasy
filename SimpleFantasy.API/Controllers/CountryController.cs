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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countriesDTOSResponse = await _countryService.GetCountriesAsync();
                return Ok(countriesDTOSResponse.Data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while retriving all countries.");
            }
        }
    }
}
