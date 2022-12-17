// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.AspNetCore.Mvc;

namespace CS1L.Server.Controllers;

[ApiController]
[Route("game")]
public class GameController : Controller
{
    [HttpPost("connect/{id}")]
    public async ValueTask Connect([FromRoute] Guid id)
    {

    }
}
