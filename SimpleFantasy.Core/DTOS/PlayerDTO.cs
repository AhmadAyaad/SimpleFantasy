using Microsoft.AspNetCore.Http;
using System;

namespace SimpleFantasy.Core.DTOS
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public IFormFile Image { get; set; }
        public string ImageURL { get; set; }
        public int NationalityId { get; set; }
    }
}
