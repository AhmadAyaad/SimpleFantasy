using AutoMapper;
using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Core.IServices;
using SimpleFantasy.Models.IUnitOfWork;
using SimpleFantasy.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleFantasy.Core.Services
{
    public class NationalityService : INationalityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NationalityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<List<NationalityDTO>>> GetNationalitiesAsync()
        {
            var nationalities = await _unitOfWork.NationalityRepo.GetAllAsync();
            if (nationalities is null)
                return new Response<List<NationalityDTO>>(new List<NationalityDTO>());
            var nationalitiesDTOS = _mapper.Map<List<NationalityDTO>>(nationalities);
            return new Response<List<NationalityDTO>>(nationalitiesDTOS);
        }
    }
}
