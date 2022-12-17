// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CS1L.Server.Data;

public class TestsContext : DbContext
{
    public DbSet<Test> Tests { get; set; } = null!;

    public TestsContext(DbContextOptions<TestsContext> options)
            : base(options)
    {
        Database.EnsureCreated();
    }


}
