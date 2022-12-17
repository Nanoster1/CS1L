// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Server.Controllers.Common;
using CS1L.Server.Data;
using CS1L.Shared.Models.Tests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS1L.Server.Controllers;

[ApiController]
[Route("tests")]
public class TestsController : Controller
{
    private readonly IDbContextFactory<TestsContext> _dbFactory;

    public TestsController(IDbContextFactory<TestsContext> dbFactory)
    {
        _dbFactory = dbFactory;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        using var ctx = await _dbFactory.CreateDbContextAsync();
        return Ok(ctx.Tests.ToArray());
    }

    [HttpPost]
    public async Task AddAsync([FromBody] Test test)
    {
        using var ctx = await _dbFactory.CreateDbContextAsync();
        ctx.Add(test);
        await ctx.SaveChangesAsync();
    }
}
