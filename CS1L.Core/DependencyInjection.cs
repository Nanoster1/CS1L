using Core.Sessions.Interfaces;
using Core.Sessions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<ISessionManager, SessionManager>();
        return services;
    }
}
