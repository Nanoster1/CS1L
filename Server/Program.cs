// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Server.Data;
using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shared.Routes.Server;

var builder = WebApplication.CreateBuilder(args);

StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);

builder.Host.UseSerilog((ctx, logger) =>
{
    logger.ReadFrom.Configuration(ctx.Configuration);
});

builder.Services.AddControllers();
builder.Services.AddDbContextFactory<TestsContext>(options =>
{
    options.UseNpgsql(TestsContext.ConnectionString)
    .UseSnakeCaseNamingConvention();
});

var app = builder.Build();

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

app.Services.GetService<IDbContextFactory<TestsContext>>().CreateDbContext().Tests.Count();

app.Run();
