using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtils;
using Shop.Api.ViewModels.Auth;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Controllers;

public class AuthController(IUserFacade userFacade, IConfiguration configuration) : ApiController
{
    [HttpPost("Login")]
    public async Task<ApiResult<string?>> Login(LoginViewModel model)
    {
        var user = await userFacade.GetByPhoneNumber(model.PhoneNumber);
        if (user == null || user.Password != model.Password.ToSha256() || user.PhoneNumber != model.PhoneNumber)
            return new ApiResult<string?>
            {
                IsSuccess = false,
                Data = null,
                MetaData = new MetaData
                {
                    Message = "کاربری با این مشخصات یافت نشد!",
                    OperationStatusCode = OperationStatusCode.NotFound
                },
            };
        var token = JwtTokenBuilder.BuildToken(user, configuration);
        return new ApiResult<string?>
        {
            IsSuccess = true,
            Data = token,
            MetaData = new MetaData
            {
                Message = "شما با موفقیت وارد حساب کاربری خود شدید",
                OperationStatusCode = OperationStatusCode.BadRequest
            },
        };
    }
}