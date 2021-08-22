using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleFantasy.Models.Entities;

namespace SimpleFantasy.Infrastructure.EntityConfiguration
{
    internal class PlayerConfiguration : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(250);
            builder.Property(t => t.ImageURL).IsRequired().HasMaxLength(250);
        }

    }
}
