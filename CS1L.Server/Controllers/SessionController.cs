// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Core.Sessions.Models;
using CS1L.Core.Sessions.Services;
using CS1L.Server.Controllers.Common;
using CS1L.Server.Data;
using CS1L.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS1L.Server.Controllers;

[Route("[controller]")]
public class SessionController : ApiController
{
    private readonly HostSessionsService _hostSessionService;
    private readonly IDbContextFactory<TestsContext> _dbContextFactory;

    public SessionController(HostSessionsService hostSessionService, IDbContextFactory<TestsContext> dbContextFactory)
    {
        _hostSessionService = hostSessionService;
        _dbContextFactory = dbContextFactory;
    }

    [HttpPost("create-lobby")]
    public async Task<ActionResult> CreateLobbyAsync(long userId, int testId)
    {
        using TestsContext ctx = await _dbContextFactory.CreateDbContextAsync();
        var test = ctx.Tests.FirstOrDefault(t => t.Id == testId);
        if (test is null) return NotFound(test);

        var session = _hostSessionService.CreateSession(userId, test);
        return Ok(session);
    }

    [HttpGet("connect/{hostSessionId}")]
    public ActionResult Connect(Guid hostSessionId)
    {
        var session = _hostSessionService.GetSession(hostSessionId);
        if (session is null) return NotFound();
        return Ok(session);
    }

    [HttpGet("host/check")]
    public ActionResult CheckHostSession([FromQuery] Guid hostSessionId, [FromQuery] int version)
    {
        var result = _hostSessionService.Check(hostSessionId, version);
        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpGet("player/check")]
    public ActionResult<bool> CheckPlayerSession([FromQuery] Guid hostSessionId, [FromQuery] Guid player, [FromQuery] int version)
    {
        var hostSession = _hostSessionService.GetSession(hostSessionId);
        if (hostSession is null) return NotFound();
        var playerSession = hostSession.GetPlayer(player);
        if (playerSession is null) return NotFound();
        var result = playerSession.Version == version;
        return Ok(result);
    }

    [HttpGet("host/{hostSessionId}")]
    public ActionResult<HostSession> GetHostSession(Guid hostSessionId)
    {
        var session = _hostSessionService.GetSession(hostSessionId);
        if (session is null) return NotFound();
        return Ok(session);
    }

    [HttpGet("player/{id}")]
    public ActionResult<PlayerSession> GetPlayerSession([FromQuery] Guid hostSessionId, [FromQuery] Guid playerSessionId)
    {
        var hostSession = _hostSessionService.GetSession(hostSessionId);
        if (hostSession is null) return NotFound();
        var playerSession = hostSession.GetPlayer(playerSessionId);
        return Ok(playerSession);
    }
}
