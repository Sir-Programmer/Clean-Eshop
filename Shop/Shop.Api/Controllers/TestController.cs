using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Query.Orders.GetById;
using Shop.Query.Products.DTOs.Filter;
using Shop.Query.Products.GetByFilter;
using Shop.Query.Products.GetById;
using Shop.Query.Roles.GetById;
using Shop.Query.Sellers.Inventories.GetById;

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
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetRole(Guid roleId)
    {
        var role = await mediator.Send(new GetRoleByIdQuery(roleId));
        return Ok(role);
    }
    
    [HttpPost("[action]")]
    public async Task<IActionResult> ProductFilter(ProductFilterParams @params)
    {
        var products = await mediator.Send(new GetProductByFilterQuery(@params));
        return Ok(products);
    }
    
    [HttpGet("[action]")]
    public async Task<IActionResult> GetInventory(Guid inventoryId)
    {
        var inventory = await mediator.Send(new GetSellerInventoryByIdQuery(inventoryId));
        return Ok(inventory);
    }
}