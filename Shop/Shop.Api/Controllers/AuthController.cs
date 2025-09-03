using System.Net;
using Common.Application.OperationResults;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtils;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.Register;
using Shop.Presentation.Facade.Users;

namespace Shop.Api.Controllers;

public class AuthController(IUserFacade userFacade, IConfiguration configuration) : ApiController
{
    [HttpPost("Login")]
    public async Task<ApiResult<string?>> Login(LoginViewModel model)
    {
        var user = await userFacade.GetByPhoneNumber(model.PhoneNumber);
        if (user == null || user.Password != model.Password.ToSha256() || user.PhoneNumber != model.PhoneNumber)
        {
            var result = OperationResult<string>.Error("کاربری با این مشخصات یافت نشد!");
            return CommandResult(result, HttpStatusCode.NotFound);
        }

        var token = JwtTokenBuilder.BuildToken(user, configuration);
        var loginResult = OperationResult<string>.Success(token, "شما با موفقیت وارد حساب کاربری خود شدید");
        return CommandResult(loginResult);
    }

    [HttpPost("Register")]
    public async Task<ApiResult> Register(RegisterViewModel model)
    {
        var result = await userFacade.Register(new RegisterUserCommand(model.PhoneNumber, model.Password));
        return CommandResult(result);
    }
}