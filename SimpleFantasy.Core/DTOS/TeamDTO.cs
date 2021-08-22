using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleFantasy.Core.DTOS
{
    public class TeamDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public DateTime FoundationDate { get; set; }
        [Required]
        public string CoachName { get; set; }
        [Required]
        public IFormFile Logo { get; set; }
        public string LogoURL { get; set; }
        [Required]
        public List<PlayerDTO> Players { get; set; }
    }
}
