using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleFantasy.Infrastructure.EntityConfiguration;
using SimpleFantasy.Models.Entities;

namespace SimpleFantasy.Infrastructure
{
    public class FantasyDbContext : IdentityDbContext<User>
    {
        public FantasyDbContext(DbContextOptions<FantasyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TeamConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new NationalityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
    }
}
