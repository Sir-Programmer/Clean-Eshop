using Microsoft.AspNetCore.Mvc;

namespace Shop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController() : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok();
    }
}