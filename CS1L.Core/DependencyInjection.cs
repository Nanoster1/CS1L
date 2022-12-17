using CS1L.Core.Sessions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CS1L.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<SessionStorage>();
        services.AddScoped<SessionService>();
        return services;
    }
}
