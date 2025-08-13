using Microsoft.AspNetCore.Mvc;

namespace Shop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    public IActionResult Index()
    {
        return Ok();
    }
}