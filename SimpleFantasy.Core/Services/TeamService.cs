using AutoMapper;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using SimpleFantasy.Core.DTOS;
using SimpleFantasy.Core.IServices;
using SimpleFantasy.Core.Models;
using SimpleFantasy.Models.Entities;
using SimpleFantasy.Models.IUnitOfWork;
using SimpleFantasy.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFantasy.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        readonly Cloudinary _cloudinary;

        public TeamService(IUnitOfWork unitOfWork, IMapper mapper, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cloudinaryConfig = cloudinaryConfig;
            Account account = new Account
            {
                Cloud = cloudinaryConfig.Value.CloudName,
                ApiKey = cloudinaryConfig.Value.ApiKey,
                ApiSecret = cloudinaryConfig.Value.ApiSecret
            };
            _cloudinary = new Cloudinary(account);
        }
        public async Task<Response> AddNewTeamAsync(TeamDTO teamDTO)
        {
            if (teamDTO.Players.Any())
            {

                UploadTeamLogoToCloudinary(ref teamDTO);
                var playersDTOS = UploadPlayersImageToCloudinary(teamDTO.Players);
                teamDTO.Players = playersDTOS;
                var team = _mapper.Map<Team>(teamDTO);
                await _unitOfWork.TeamRepo.AddAsync(team);
                await _unitOfWork.SaveChangesAsync();
                return new Response();
            }
            return new Response(ResponseStatus.Failed, "Missing team players");
        }
        private void UploadTeamLogoToCloudinary(ref TeamDTO teamDTO)
        {
            var uploadResult = new ImageUploadResult();

            if (teamDTO.Logo.Length > 0)
            {
                using (var stream = teamDTO.Logo.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(teamDTO.Logo.Name, stream),

                        Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }
            teamDTO.LogoURL = uploadResult.Url.ToString();
        }
        private List<PlayerDTO> UploadPlayersImageToCloudinary(List<PlayerDTO> playersDTOS)
        {
            var uploadResult = new ImageUploadResult();
            foreach (var playerDTO in playersDTOS)
            {
                if (playerDTO.Image.Length > 0)
                {
                    using (var stream = playerDTO.Image.OpenReadStream())
                    {
                        var uploadParams = new ImageUploadParams()
                        {
                            File = new FileDescription(playerDTO.Image.Name, stream),

                            Transformation = new Transformation().Width(500).Height(500).Crop("fill").Gravity("face")
                        };
                        uploadResult = _cloudinary.Upload(uploadParams);
                    }
                }
                playerDTO.ImageURL = uploadResult.Url.ToString();
            }
            return playersDTOS;
        }

        public async Task<PagedResultDTO<TeamDTO>> GetTeamsAsync(int pageIndex, int pageSize)
        {
            var pagedResultTeams = await _unitOfWork.TeamRepo.GetTeamsWithCountryNameAsync(pageIndex, pageSize);
            if (pagedResultTeams is null)
                return new PagedResultDTO<TeamDTO> { Items = null, RowCount = pagedResultTeams.RowCount };
            return new PagedResultDTO<TeamDTO> { Items = _mapper.Map<List<TeamDTO>>(pagedResultTeams.Items), RowCount = pagedResultTeams.RowCount };
        }

        public async Task<Response> DeleteTeam(int teamId)
        {
            var team = await _unitOfWork.TeamRepo.GetByIdAsync(teamId);
            if (team is null)
                return new Response(ResponseStatus.Failed, "There is no team with such id");
            _unitOfWork.TeamRepo.Remove(team);
            await _unitOfWork.SaveChangesAsync();
            return new Response();
        }

        public async Task<Response<TeamDTO>> GetTeamAsync(int teamId)
        {
            var existingTeam = await _unitOfWork.TeamRepo.GetByIdAsync(teamId);
            if (existingTeam is null)
                return new Response<TeamDTO>(null, ResponseStatus.NotFound, "There is no team with such id");
            return new Response<TeamDTO>(_mapper.Map<TeamDTO>(existingTeam));
        }

    }
}
