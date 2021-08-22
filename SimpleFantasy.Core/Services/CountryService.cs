using AutoMapper;
using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Core.IServices;
using SimpleFantasy.Models.IUnitOfWork;
using SimpleFantasy.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleFantasy.Core.Services
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<List<CountryDTO>>> GetCountriesAsync()
        {
            var countries = await _unitOfWork.CountryRepo.GetAllAsync();
            if (countries is null)
                return new Response<List<CountryDTO>>(new List<CountryDTO>());
            var countriesDTOS = _mapper.Map<List<CountryDTO>>(countries);
            return new Response<List<CountryDTO>>(countriesDTOS);
        }

    }
}
