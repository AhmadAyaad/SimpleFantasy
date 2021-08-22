using System;

namespace SimpleFantasy.Models.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageURL { get; set; }
        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
