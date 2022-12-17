// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Core.Sessions.Services;
using CS1L.Server.Controllers.Common;
using CS1L.Server.Data;
using CS1L.Shared.Models.DTOs;
using CS1L.Shared.Models.Sessions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CS1L.Server.Controllers;

[Route("[controller]")]
public class SessionController : ApiController
{
    private readonly SessionService _hostSessionService;

    public SessionController(SessionService hostSessionService)
    {
        _hostSessionService = hostSessionService;
    }

    [HttpPost("[action]")]
    public async Task<ActionResult> Create(long userId, int testId)
    {
        var session = await _hostSessionService.CreateHostSessionAsync(userId, testId);
        return Ok(session);
    }

    [HttpPost("connect")]
    public ActionResult<PlayerSession> Connect(GameConnectDto dto)
    {
        var session = _hostSessionService.Connect(dto);
        if (session is null) return NotFound();
        return Ok(session);
    }

    [HttpGet("host/check")]
    public ActionResult CheckHostSession([FromQuery] Guid hostSessionId, [FromQuery] int version)
    {
        var result = _hostSessionService.CheckHostSession(hostSessionId, version);
        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpGet("player/check")]
    public ActionResult<bool> CheckPlayerSession(
        [FromQuery] Guid hostSessionId,
        [FromQuery] Guid playerSessionId,
        [FromQuery] int version)
    {
        var result = _hostSessionService.CheckPlayerSession(hostSessionId, playerSessionId, version);
        if (result is null) return NotFound();
        return Ok(result);
    }

    [HttpGet("host")]
    public ActionResult<HostSession> GetHostSession([FromQuery] Guid hostSessionId)
    {
        var session = _hostSessionService.GetHostSession(hostSessionId);
        if (session is null) return NotFound();
        return Ok(session);
    }

    [HttpGet("player")]
    public ActionResult<PlayerSession> GetPlayerSession([FromQuery] Guid hostSessionId, [FromQuery] Guid playerSessionId)
    {
        var playerSession = _hostSessionService.GetPlayer(hostSessionId, playerSessionId);
        if (playerSession is null) return NotFound();
        return Ok(playerSession);
    }
}
