using Microsoft.AspNetCore.Mvc;
using CS1L.Server.Controllers.Common;
using CS1L.Shared.Routes.Server;

namespace CS1L.Server.Controllers;

[Route(ServerRoutes.Controllers.Error.Prefix)]
public class ErrorController : ApiController
{
    [NonAction]
    public ActionResult Error()
    {
        return Problem();
    }
}
