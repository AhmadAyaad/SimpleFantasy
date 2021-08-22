using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleFantasy.Models.Entities;

namespace SimpleFantasy.Infrastructure.EntityConfiguration
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(250);
            builder.HasData(
                new Country() { Id = 1, Name = "Egypt" },
                new Country() { Id = 2, Name = "England" },
                new Country() { Id = 3, Name = "Canda" }
                           );
        }
    }
}
