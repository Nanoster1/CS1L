using CS1L.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CS1L.Server.Data;

public class TestsContext : DbContext
{
    public const string ConnectionString = "Database";
    public DbSet<Test> Tests { get; set; } = null!;
    //public DbSet<Question> Questions { get; set; } = null!;
    //public DbSet<Answer> Answers { get; set; } = null!;

    public TestsContext(DbContextOptions<TestsContext> options)
            : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestsContext).Assembly);
    }
}
