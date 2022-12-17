// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CS1L.Server.Data;

public class TestsContext : DbContext
{
    public const string ConnectionString =
        "Password=slava_pussy;Host=un1ver5e.ddns.net;Port=7777;Database=postgres;";
    public DbSet<Test> Tests { get; set; } = null!;

    public TestsContext(DbContextOptions<TestsContext> options)
            : base(options)
    {
        Database.EnsureCreated();
    }


}
