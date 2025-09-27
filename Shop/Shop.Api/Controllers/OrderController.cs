using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.ViewModels.Order;
using Shop.Application.Orders.AddItem;
using Shop.Application.Orders.Checkout;
using Shop.Application.Orders.DecreaseItemCount;
using Shop.Application.Orders.IncreaseItemCount;
using Shop.Application.Orders.RemoveItem;
using Shop.Application.Orders.SendOrder;
using Shop.Application.Orders.SetDiscount;
using Shop.Presentation.Facade.Coupons;
using Shop.Presentation.Facade.Orders;
using Shop.Query.Orders.DTOs;
using Shop.Query.Orders.DTOs.Filter;

namespace Shop.Api.Controllers;

public class OrderController(IOrderFacade orderFacade, ICouponFacade couponFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<OrderFilterResult?>> GetByFilter([FromQuery] OrderFilterParams filters)
    {
        var result = await orderFacade.GetByFilter(filters);
        return QueryResult(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ApiResult<OrderDto?>> GetById(Guid id)
    {
        var result = await orderFacade.GetById(id);
        return QueryResult(result);
    }

    [HttpPost("{id:guid}/send")]
    public async Task<ApiResult> Send(Guid id)
    {
        var result = await orderFacade.Send(new SendOrderCommand(id));
        return CommandResult(result);
    }

    [HttpGet("current")]
    public async Task<ApiResult<OrderDto?>> GetCurrent()
    {
        var result = await orderFacade.GetCurrentUserOrder(User.GetUserId());
        return QueryResult(result);
    }

    [HttpPost("current/checkout")]
    public async Task<ApiResult> Checkout(CheckoutOrderViewModel vm)
    {
        var result = await orderFacade.Checkout(new CheckoutOrderCommand(User.GetUserId(), vm.Province, vm.City, vm.PostalCode, vm.FullName, vm.PostalAddress, vm.PhoneNumber, vm.NationalId, vm.ShippingMethodId));
        return CommandResult(result);
    }

    [HttpPost("current/discount")]
    public async Task<ApiResult> Discount(string coupon)
    {
        var discount = await couponFacade.GetByCode(coupon);
        if (discount == null) return ApiResult.NotFound();
        var order = await orderFacade.GetCurrentUserOrder(User.GetUserId());
        if (order == null) return ApiResult.NotFound();
        var result = await orderFacade.SetDiscount(new SetOrderDiscountCommand(order.Id, discount.DiscountType, discount.DiscountAmount));
        await couponFacade.Use(coupon);
        return CommandResult(result);
    }

    [HttpPost("current/items")]
    public async Task<ApiResult> AddItem(AddOrderItemViewModel vm)
    {
        var result = await orderFacade.AddItem(new AddOrderItemCommand(User.GetUserId(), vm.InventoryId, vm.Count));
        return CommandResult(result);
    }

    [HttpDelete("current/items/{itemId:guid}")]
    public async Task<ApiResult> RemoveItem(Guid itemId)
    {
        var result = await orderFacade.RemoveItem(new RemoveOrderItemCommand(User.GetUserId(), itemId));
        return CommandResult(result);
    }

    [HttpPut("current/items/{itemId:guid}/increase-count")]
    public async Task<ApiResult> IncreaseItemCount(Guid itemId, int count)
    {
        var result = await orderFacade.IncreaseItemCount(new IncreaseOrderItemCountCommand(User.GetUserId(), itemId, count));
        return CommandResult(result);
    }


    [HttpPut("current/items/{itemId:guid}/decrease-count")]
    public async Task<ApiResult> DecreaseItemCount(Guid itemId, int count)
    {
        var result = await orderFacade.DecreaseItemCount(new DecreaseOrderItemCountCommand(User.GetUserId(), itemId, count));
        return CommandResult(result);
    }

}