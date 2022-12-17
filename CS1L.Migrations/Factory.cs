// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
using CS1L.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CS1L.Migrations;

public class Factory : IDesignTimeDbContextFactory<TestsContext>
{
    public TestsContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();

        var configuration = configurationBuilder.Build();
        var connectionString = configuration.GetConnectionString(TestsContext.ConnectionString);
        var optionsBuilder = new DbContextOptionsBuilder<TestsContext>()
            .UseNpgsql(connectionString,
                builder => builder.MigrationsAssembly(typeof(Factory).Assembly.GetName().Name))
            .UseSnakeCaseNamingConvention();

        return new TestsContext(optionsBuilder.Options);
    }
}
