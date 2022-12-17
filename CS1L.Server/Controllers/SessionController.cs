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

    [HttpPost("create-lobby")]
    public async Task<ActionResult> Create(CreateLobbyDTO dto)
    {
        var session = await _hostSessionService.CreateHostSessionAsync(dto.UserId, dto.TestId);
        return Ok(session);
    }

    
}
