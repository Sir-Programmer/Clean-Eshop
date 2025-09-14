using System.Net;
using Common.Application.OperationResults;
using Common.Application.SecurityUtil;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.JwtUtils;
using Shop.Api.ViewModels.Auth;
using Shop.Application.Users.AddToken;
using Shop.Application.Users.DeleteToken;
using Shop.Application.Users.Register;
using Shop.Presentation.Facade.Users;
using Shop.Query.Users.DTOs;
using UAParser;

namespace Shop.Api.Controllers;

public class AuthController(IUserFacade userFacade, IConfiguration configuration) : ApiController
{
    [HttpPost("login")]
    public async Task<ApiResult<LoginResultDto?>> Login(LoginViewModel model)
    {
        var user = await userFacade.GetByPhoneNumber(model.PhoneNumber);
        if (user != null && user.Password == model.Password.ToSha256() && user.PhoneNumber == model.PhoneNumber)
            return CommandResult(await GenerateLoginResult(user));
        var result = OperationResult<LoginResultDto>.Error("کاربری با این مشخصات یافت نشد!");
        return CommandResult(result, HttpStatusCode.NotFound);
    }

    [HttpPost("register")]
    public async Task<ApiResult> Register(RegisterViewModel model)
    {
        var result = await userFacade.Register(new RegisterUserCommand(model.PhoneNumber, model.Password));
        return CommandResult(result);
    }
    
    [HttpPost("refresh-token")]
    public async Task<ApiResult<LoginResultDto?>> RefreshToken(string refreshToken)
    {
        var token = await userFacade.GetByRefreshToken(refreshToken);
        if (token == null)
            return CommandResult(OperationResult<LoginResultDto?>.NotFound());
        if (token.RefreshTokenExpireDate < DateTime.Now)
            return CommandResult(OperationResult<LoginResultDto?>.Error("زمان استفاده از رفرش توکن منقضی شده است"));
        
        var user = await userFacade.GetById(token.UserId);
        if (user == null)
            return CommandResult(OperationResult<LoginResultDto?>.Error("مشکل در دریافت اطلاعات"));
        
        await userFacade.DeleteToken(new DeleteUserTokenCommand(token.UserId, token.Id));
        var loginResult = await GenerateLoginResult(user);
        return CommandResult(loginResult);
    }

    [HttpDelete("logout")]
    public async Task<ApiResult> Logout()
    {
        var jwtToken = await HttpContext.GetTokenAsync("access_token");
        if (jwtToken == null)
            return CommandResult(OperationResult.NotFound());
        var token = await userFacade.GetByJwtToken(jwtToken);
        if (token == null)
            return CommandResult(OperationResult.NotFound());
        var result = await userFacade.DeleteToken(new DeleteUserTokenCommand(token.UserId, token.Id));
        return CommandResult(result);
    }

    private async Task<OperationResult<LoginResultDto?>> GenerateLoginResult(UserDto user)
    {
        var userAgent = HttpContext.Request.Headers.UserAgent.ToString();
        var ua = Parser.GetDefault().Parse(userAgent);
        var device = $"{ua.Device.Family} | {ua.OS.Family} {ua.OS.Major}.{ua.OS.Minor} | {ua.UA.Family}";

        var token = JwtTokenBuilder.BuildToken(user, configuration);
        var refreshToken = Guid.NewGuid().ToString();
        var tokenHash = token.ToSha256();
        
        var refreshTokenHash = refreshToken.ToSha256();

        await userFacade.AddToken(new AddUserTokenCommand(user.Id, tokenHash, refreshTokenHash, DateTime.Now.AddDays(30), DateTime.Now.AddDays(35), device));
        var loginResult =  new LoginResultDto()
        {
            Token = token,
            RefreshToken = refreshToken,
        };
        return OperationResult<LoginResultDto?>.Success(loginResult);
    }
}