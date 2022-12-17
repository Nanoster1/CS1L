using CS1L.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.Data.Configurations;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.HasMany(t => t.Questions)
            .WithOne();
    }
}
