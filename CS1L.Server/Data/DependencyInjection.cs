﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Server.Data;
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

        return services;
    }
}
