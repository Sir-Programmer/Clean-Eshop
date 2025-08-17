using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Users.Register;
using Shop.Query.Orders.GetById;
using Shop.Query.Products.GetById;

namespace Shop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController(IMediator mediator) : ControllerBase
{
    [HttpGet("[action]")]
    public async Task<IActionResult> GetOrder(Guid orderId)
    {
        var order = await mediator.Send(new GetOrderByIdQuery(orderId));
        return Ok(order);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetProduct(Guid productId)
    {
        var product = await mediator.Send(new GetProductByIdQuery(productId));
        return Ok(product);
    }
}