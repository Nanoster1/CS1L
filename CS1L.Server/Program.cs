using CS1L.Core;
using CS1L.Server.Data;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Serilog;
using CS1L.Server.Logger;
using CS1L.Shared.Routes.Server;
using CS1L.Server.Hubs;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);
{
    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

    builder.Services.AddCors();

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddRazorPages();
    builder.Services.AddSignalR();
    builder.Services.AddResponseCompression(opts =>
    {
        opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
            new[] { "application/octet-stream" });
    });

    builder.Host.UseSerilog((ctx, logger) =>
    {
        logger.ReadFrom.Configuration(ctx.Configuration);
    });

    builder.Host.AddLogger();

    builder.Services.AddCore();
    builder.Services.AddData(builder.Configuration);

    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseResponseCompression();

    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseWebAssemblyDebugging();

    app.UseBlazorFrameworkFiles();
    app.UseStaticFiles();

    app.UseRouting();

    app.MapRazorPages();
    app.MapHubs();
    app.MapControllers();
    app.MapFallbackToFile(ServerRoutes.FallbackFileName);
}

app.Run();
