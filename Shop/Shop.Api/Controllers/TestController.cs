using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Register;
using Shop.Query.Orders.GetById;

namespace Shop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Index(Guid orderId)
    {
        var order = await mediator.Send(new GetOrderByIdQuery(orderId));
        return Ok(order);
    }
}