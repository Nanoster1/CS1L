using Microsoft.AspNetCore.Mvc;
using Server.Controllers.Common;
using Shared.Routes.Server;

namespace Server.Controllers;

[Route(ServerRoutes.Controllers.Error.Prefix)]
public class ErrorController : ApiController
{
    public ActionResult Error()
    {
        return Problem();
    }
}
