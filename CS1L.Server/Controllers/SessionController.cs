using CS1L.Core.Sessions.Models;
using CS1L.Core.Sessions.Services;
using CS1L.Server.Controllers.Common;
using Microsoft.AspNetCore.Mvc;

namespace CS1L.Server.Controllers;

[Route("[controller]")]
public class SessionController : ApiController
{
    private readonly HostSessionsService _hostSessionService;

    public SessionController(HostSessionsService hostSessionService)
    {
        _hostSessionService = hostSessionService;
    }

    [HttpPost("create-lobby")]
    public ActionResult CreateLobby(long userId)
    {
        var session = _hostSessionService.CreateSession(userId);
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
