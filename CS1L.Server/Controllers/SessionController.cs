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
        Test? test = ctx.Tests.FirstOrDefault(t => t.Id == testId);
        if (test is null) return NotFound(test);

        var session = _hostSessionService.CreateSession(userId, test);
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
