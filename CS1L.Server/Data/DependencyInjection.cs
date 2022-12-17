using CS1L.Core.Tests.Interfaces;
using CS1L.Server.Data;
using CS1L.Server.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CS1L.Server.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddDbContextFactory<TestsContext>(options =>
        {
            options.UseNpgsql(TestsContext.ConnectionString)
                .UseSnakeCaseNamingConvention();
        });

        services.AddScoped(s => s.GetService<IDbContextFactory<TestsContext>>()!.CreateDbContext());

        services.AddScoped<ITestRepository, TestRepository>();

        return services;
    }
}
