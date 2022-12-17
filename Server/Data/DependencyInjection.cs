using CS1L.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace Server.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services)
    {
        services.AddDbContextFactory<TestsContext>(options =>
        {
            options.UseNpgsql(TestsContext.ConnectionString)
                .UseSnakeCaseNamingConvention();
        });

        return services;
    }
}
