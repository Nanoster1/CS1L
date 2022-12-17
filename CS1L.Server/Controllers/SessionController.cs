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

    [HttpGet("connect/{id}")]
    public ActionResult Connect(Guid hostSessionId)
    {
        var session = _hostSessionService.GetSession(hostSessionId);
        if (session is null) return NotFound();
        

        return Ok(session);
    }
}
