using CS1L.Shared.Models.Tests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CS1L.Server.Data.Configurations;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.OwnsMany(t => t.Questions, qBuilder =>
        {
            qBuilder.OwnsMany(q => q.Answers);
        });
    }
}
