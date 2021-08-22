using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleFantasy.Models.Entities;

namespace SimpleFantasy.Infrastructure.EntityConfiguration
{
    internal class NationalityConfiguration : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(250);
            builder.HasData(
            new Nationality() { Id = 1, Name = "Egyptian" },
            new Nationality() { Id = 2, Name = "Biritsh" },
            new Nationality() { Id = 3, Name = "Candian" }
                       );
        }
    }
}
