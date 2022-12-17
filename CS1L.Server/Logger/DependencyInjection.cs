using Serilog;

namespace CS1L.Server.Logger;

public static class DependencyInjection
{
    public static IHostBuilder AddLogger(this IHostBuilder host)
    {
        host.UseSerilog((ctx, logger) =>
        {
            logger.ReadFrom.Configuration(ctx.Configuration);
        });
        return host;
    }
}
