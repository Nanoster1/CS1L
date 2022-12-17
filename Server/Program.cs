using CS1L.Core;
using CS1L.Server.Data;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Server.Data;
using Server.Logger;
using Shared.Routes.Server;

var builder = WebApplication.CreateBuilder(args);
{
    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

    builder.Services.AddCors();

    builder.Services.AddControllers();

    builder.Host.UseSerilog((ctx, logger) =>
    {
        logger.ReadFrom.Configuration(ctx.Configuration);
    });

    builder.Host.AddLogger();

    builder.Services.AddCore();
    builder.Services.AddData();

    builder.Services.AddControllers();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseWebAssemblyDebugging();
    }
    else
    {
        app.UseExceptionHandler(ServerRoutes.Controllers.Error.Prefix);
    }

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseRouting();

    app.MapControllers();
    app.MapFallbackToFile(ServerRoutes.FallbackFileName);
}

app.Run();
