// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Server.Data;
using CS1L.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS1L.Server.Controllers.Common;

[ApiController]
[Route("tests")]
public class TestsController : Controller
{
    private readonly IDbContextFactory<TestsContext> _dbfactory;

    public TestsController(IDbContextFactory<TestsContext> dbfactory)
    {
        _dbfactory = dbfactory;
    }

    [HttpGet]
    public async Task<IActionResult> FetchAllAsync()
    {
        using TestsContext ctx = await _dbfactory.CreateDbContextAsync();

        return Ok(ctx.Tests.ToArray());
    }

    [HttpPost]
    public async Task AddAsync([FromBody] Test test)
    {
        using TestsContext ctx = await _dbfactory.CreateDbContextAsync();
        ctx.Add(test);
        await ctx.SaveChangesAsync();
    }
}
