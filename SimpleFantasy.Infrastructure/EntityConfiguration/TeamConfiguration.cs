using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleFantasy.Models.Entities;

namespace SimpleFantasy.Infrastructure.EntityConfiguration
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(250);
            builder.Property(t => t.LogoURL).IsRequired().HasMaxLength(250);
            builder.Property(t => t.CoachName).IsRequired().HasMaxLength(250);
            builder.HasMany(t => t.Players)
                  .WithOne(p => p.Team)
                  .HasForeignKey(p => p.TeamId);
        }
    }
}
