using Microsoft.AspNetCore.Mvc;

namespace GqlPlus.StarWars.Controllers;

[ApiController]
[Route("api")]
public class HealthController : ControllerBase
{
  [HttpGet("health")]
  public IActionResult Health() => Ok(new { status = "healthy" });
}
