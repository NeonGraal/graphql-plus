using Microsoft.AspNetCore.Mvc;

namespace GqlPlus.StarWars.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StarWarsController : ControllerBase
{
  [HttpGet("films")]
  public IActionResult Films()
  {
    var films = new[] {
      new { id = 1, title = "A New Hope", episode = 4 },
      new { id = 2, title = "The Empire Strikes Back", episode = 5 }
    };
    return Ok(films);
  }
}
