// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Core.Sessions.Models;
using CS1L.Core.Sessions.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS1L.Server.Controllers;

[ApiController]
[Route("game")]
public class GameController : Controller
{
    private readonly HostSessionsService _hostService;

    public GameController(HostSessionsService service)
    {
        _hostService = service;
    }

    [HttpPost("connect/{id}")]
    public async Task<IActionResult> Connect([FromRoute] (Guid Id, string Name, ulong VkId) data)
    {
        HostSession? host = _hostService.GetSession(data.Id);
        if (host is null) return NotFound(data.Id);

        PlayerSession player = host.CreatePlayer(data.VkId, data.Name);
    }
}
