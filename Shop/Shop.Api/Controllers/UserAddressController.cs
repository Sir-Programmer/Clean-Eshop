using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Presentation.Facade.Users.Addresses;
using Shop.Query.Users.DTOs;

namespace Shop.Api.Controllers;

public class UserAddressController(IUserAddressFacade addressFacade) : ApiController
{
    [HttpGet]
    public async Task<ApiResult<List<UserAddressDto>>> GetList()
    {
        var result = await addressFacade.GetList(User.GetUserId());
        return QueryResult(result);
    }
}