using System;
using System.Collections.Generic;

namespace SimpleFantasy.Models.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public DateTime FoundationDate { get; set; }
        public string CoachName { get; set; }
        public string LogoURL { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
